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

    public partial class Window_ListView : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> listString = new ObservableCollection<string>();
        private  CollectionView _stringi;
        private string _phonebookEntry;
        private CollectionView _phonebookEntries;
        private PhoneBookEntry phoneData;
        private string myDataProperty;
        private ObservableCollection<Rates> ratesCollection;
        private List<Rates> ratesList;
        public List<Rates> RatesList
        {
            get
            {
                return ratesList;
            }
            set
            {
                ratesList = value;
                OnPropertyChanged();
            }
        }

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
            RatesList=NbpSetData();
            DataContext = this;
        }

        void LoadTodataContext()
        {
            //Task<ObservableCollection<Rates>> task1 = Task.Run(loadNbp);
            //var collections = task1.GetAwaiter().GetResult();
            //RatesCollection = collections;

            Setdata();
        }

        async Task<ObservableCollection<Rates>> loadNbp()
        {
            var myTask = Task.Run(() => NBPclass.LoadDataFromNbp());
            ObservableCollection<Rates> ratesCol = await myTask;
            return ratesCol;
        }

        List<Rates> NbpSetData()
        {
            DateTime fromDate = new DateTime(2021, 9, 15);
            Nbp dataNbp = NBPclass.StockDataNbp(fromDate);
            return dataNbp.Rates;          
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
