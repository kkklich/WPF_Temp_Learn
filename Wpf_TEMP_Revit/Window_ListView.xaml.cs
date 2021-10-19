//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Wpf_TEMP_Revit
{
    /// <summary>
    /// Interaction logic for Window_ListView.xaml
    /// </summary>
    /// 

    //public class MyData : INotifyPropertyChanged
    //{
    //    private string myDataProperty;

    //    public MyData() { }

    //    public MyData(DateTime dateTime)
    //    {
    //        myDataProperty = "Last bound time was " + dateTime.ToLongTimeString();
    //    }

    //    public String MyDataProperty
    //    {
    //        get { return myDataProperty; }
    //        set
    //        {
    //            myDataProperty = value;
    //            OnPropertyChanged("MyDataProperty");
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(string info)
    //    {
    //        PropertyChangedEventHandler handler = PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, new PropertyChangedEventArgs(info));
    //        }
    //    }
    //}

    public class PhoneBookEntry 
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public PhoneBookEntry() { }

        public PhoneBookEntry(string Name)
        {
            this.Name = Name;
        }
        public override string ToString()
        {
            return Name;
        }
    }


    //public class ConnectionViewModel : INotifyPropertyChanged
    //{
        //public event PropertyChangedEventHandler PropertyChanged;
        //private string _phonebookEntry;

        //private readonly CollectionView _phonebookEntries;

        //public ConnectionViewModel()
        //{
        //    IList<PhoneBookEntry> list = new List<PhoneBookEntry>()
        //    {
        //        //new PhoneBookEntry(){ Name = "test1", Number = 5 }
        //    };

        //    list.Add(new PhoneBookEntry("test2"));
        //    list.Add(new PhoneBookEntry("test3"));
        //    list.Add(new PhoneBookEntry("test4"));
        //    _phonebookEntries = new CollectionView(list);

        //    listString.Add("Słowo 1");
        //    listString.Add("Słowo 2");
        //    listString.Add("Słowo 3");
        //    listString.Add("Słowo 4");
        //    _stringi = new CollectionView(listString);

        //}

        //public CollectionView PhonebookEntries
        //{
        //    get { return _phonebookEntries; }
        //}

        //public string PhonebookEntry
        //{
        //    get { return _phonebookEntry; }
        //    set
        //    {
        //        if (_phonebookEntry == value) return;
        //        _phonebookEntry = value;
        //        OnPropertyChanged("PhonebookEntry");
        //    }
        //}

        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}



        ////Stringi

        //ObservableCollection<string> listString = new ObservableCollection<string>();
        //private readonly CollectionView _stringi;


        //public CollectionView Stringi
        //{
        //    get { return _stringi; }
        //}

    //}


    public partial class Window_ListView : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> listString = new ObservableCollection<string>();
        private  CollectionView _stringi;
        private string _phonebookEntry;
        private CollectionView _phonebookEntries;
        private PhoneBookEntry phoneData;
        private string myDataProperty;
        private ObservableCollection<Rates> ratesCollection;

        public ObservableCollection<Rates> RatesCollection
        {
            get
            {
                return ratesCollection;
            }
            set
            {
                ratesCollection = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Window_ListView()
        {
            InitializeComponent();

            LoadTodataContext();

           // DataContext = this;
        }

        void LoadTodataContext()
        {
            DateTime time1 = DateTime.Now;

            Task<ObservableCollection<Rates>> task1 = Task.Run(loadNbp);
            var collections = task1.GetAwaiter().GetResult();
            RatesCollection = collections;

            DateTime time2 = DateTime.Now;
            TimeSpan ts = time2.Subtract(time1);
            MessageBox.Show(ts.ToString());

            JsonAlphaVantage();
            Setdata();

            DataContext = this;
        }

        async Task<ObservableCollection<Rates>> loadNbp()
        {
            var myTask = Task.Run(() => NBPclass.LoadDataFromNbp());
            ObservableCollection<Rates> ratesCol = await myTask;
            return ratesCol;
        }

        private void GetDataJson()
        {
            string Query_Url = "http://api.nbp.pl/api/exchangerates/rates/A/USD/2020-09-28/2021-09-28";
            Uri uriQuery = new Uri(Query_Url);


           // string str = "type your json url here";
            WebClient webClient = new WebClient();
            if (webClient == null)
            {
                webClient = new WebClient();
            }
            else
            {
                webClient.Dispose();
                webClient = null;
                webClient = new WebClient();
            }
            DataTable JsonDataTable = new DataTable();
            //Set Header  
            //webClient.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            //Download Content  
            string JsonSting = webClient.DownloadString(Query_Url);
            //Convert JSON to Datatable  
           // JsonDataTable = (DataTable)JsonConvert.DeserializeObject(JsonSting, (typeof(DataTable)));
            JsonDataTable.TableName = "JSON_MAST";
            //JsonDataTable.
            Grid_Json.DataContext = JsonDataTable.DefaultView;
        }


        void JsonAlphaVantage()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
              //  var json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

                //json_data.GetType();
              //  MessageBox.Show(json_data.Values.Count.ToString());
            }
            
        }

        void Setdata()
        {
            IList<PhoneBookEntry> list = new List<PhoneBookEntry>();
           
            list.Add(new PhoneBookEntry("test2"));
            list.Add(new PhoneBookEntry("test3"));
            list.Add(new PhoneBookEntry("test4"));
            _phonebookEntries = new CollectionView(list);

            listString.Add("Słowo 1");
            listString.Add("Słowo 2");
            listString.Add("Słowo 3");
            listString.Add("Słowo 4");
            _stringi = new CollectionView(listString);

            phoneData = new PhoneBookEntry();
            phoneData.Name = "Krzysztof ";
            phoneData.Number = 456;

            myDataProperty = "Last bound time was " + DateTime.Today.ToLongDateString();
        }

        public CollectionView Stringi
        {
            get { return _stringi; }
        }

        public CollectionView PhonebookEntries
        {
            get { return _phonebookEntries; }
        }

        public PhoneBookEntry phoneDataKrzy
        {
            get { return phoneData; }
            set
            {
                if (phoneData == value)
                    return;
                phoneData = value;
                OnPropertyChanged("phoneDataKrzy");
            }
        }
                
       

        public string ButtonName
        {
            get { return "Przycisk"; }
        }


        public string PhonebookEntry
        {
            get { return _phonebookEntry; }
            set
            {
                if (_phonebookEntry == value) return;
                _phonebookEntry = value;
                OnPropertyChanged("PhonebookEntry");
            }
        }       

        int nr = 4;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  string cmbChoose = (DataContext).PhonebookEntry;
            if (cmb_name.SelectedIndex > -1)
            {
                string nextItem = "słowo " + nr++;
                listString.Add(nextItem);
                _stringi = new CollectionView(listString);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonNameGet = (PhoneBookEntry)phoneDataKrzy;
            MessageBox.Show(buttonNameGet.Name+"   Nr: "+buttonNameGet.Number);
        }
    }
}
