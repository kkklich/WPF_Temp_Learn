using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Text.Json;

using System.Data;
using System.Web;

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using Wpf_TEMP_Revit.Classes;
using static Wpf_TEMP_Revit.Classes.Stock;



namespace Wpf_TEMP_Revit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Person
    {
        public string FirstName { get; set; }
        public string SureName { get; set; }
    
    
        public Person() { }
        public Person(string FirstName, String SureName) 
        {
            this.FirstName = FirstName;
            this.SureName = SureName;
        }
    }

    public class Identificator
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Identificator() { }
        public Identificator(string Name, int Number)
        {
            this.Name = Name; ;
            this.Number = Number;
        }
    }

    public class ListyClass
    {
        public List<Identificator> Lista { get; set; }
        public List<Person> ListPerson { get; set; }
        public Rates[] Rates{ get; set; }
        public ListyClass() { }   

        public ListyClass(List<Identificator> ListIdentificator)
        {
            this.Lista = ListIdentificator;
        }

        public ListyClass(List<Person> ListPerson )
        {
            this.ListPerson = ListPerson;
        }

        private ListyClass(Rates[] rates)
        {
            this.Rates = rates;
        }

        
    }

    public class RatyNbp
    {
        public Rates[] Rates { get; set; }

        public RatyNbp(Rates[] rates)
        {
            this.Rates = rates;
        }
    }

    public partial class MainWindow : Window
    {

        public List<Identificator> Lista { get; set; }
        public List<Person> ListPerson { get; set; }

        public Person selectedPerson;
        string Result { get; set; }

        public String TimeClockNow { get; set; }

        private MetaData stockCollection;
        public MetaData StockCollection
        {
            get
            {
                return stockCollection;
            }
            set
            {
                stockCollection = value;
                OnPropertyChanged();
            }
        }


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

        public Person SelectedPerson
        {
            get{
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
           InitializeComponent();
           //LoadTodataContext();
           //AsynchoricMethod();
            StockDataShow();
        }

        void AsynchoricMethod()
        {

            //var parent = Task.Factory.StartNew(() =>
            //{
            //    MessageBox.Show("xd 1");
            //    var child = Task.Factory.StartNew(() =>
            //    {
            //        MessageBox.Show("dzzzz21");
            //        Thread.Sleep(3000);
            //        MessageBox.Show("dzzzz22");
            //    });

            //    MessageBox.Show("Xd 2");

            //});

            
            //parent.GetAwaiter();
        }

        int doSmth()
        {
            return 1434;
        }

        void DoMethod()
        {

        }

        void LoadTodataContext()
        {
           // DateTime time1 = DateTime.Now;
            Task<ObservableCollection<Rates>> task1 = Task.Run(loadNbp);          
            var collections = task1.GetAwaiter().GetResult();
            RatesCollection = collections;


            Task<MetaData> metaDatas = Task.Run(loadStock);
            var collectionsStocks = metaDatas.GetAwaiter().GetResult();
            StockCollection = collectionsStocks;

            //DateTime time2 = DateTime.Now;
            //TimeSpan ts = time2.Subtract(time1);
            //MessageBox.Show(ts.ToString());

            // List<Person> listyPerson = addListPerson();
            //List<Identificator> listyIdentyfikator = addToLista();

            DataContext = this;
        }

        async Task<ObservableCollection<Rates>> loadNbp()
        {
            var myTask = Task.Run(() => NBPclass.LoadDataFromNbp());                      
            ObservableCollection<Rates> ratesCol = await myTask;
            return ratesCol;

        }

        async Task<MetaData> loadStock()
        {
            var myTask1 = Task.Run(() => Stock.DownloadStockAPI());
            MetaData stockData = await myTask1;
            MessageBox.Show("stockData.Information: "+stockData.Information + " stockData.TimeSeries: " + stockData.TimeSeries);
            return stockData;
        }

        void StockDataShow()
        {
            var x = Stock.StockData();
            foreach (var item in x)
            {
               // MessageBox.Show("Key: " + item.Key.ToString()+" Value: " + item.Value.ToString());
                //MessageBox.Show("Value: "+item.Value.ToString());
                //if(item.Key=="rates")
                //{
                //    dynamic ratesValue = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(item.Value);

                //    foreach(var rates in ratesValue)
                //    {
                //        MessageBox.Show(rates.key.ToString()+ "  value: " + rates.value.ToString());
                //    }
                //}
            }
          //  MessageBox.Show("xxx: "+x +"  type "+x.GetType());
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Identificator> addToLista()
        {
            Lista = new List<Identificator>();
            Lista.Add(new Identificator("Krzys", 78));
            Lista.Add(new Identificator("Krzysztofe", 123));

            return Lista;
        }

        List<Person> addListPerson()
        {
            ListPerson = new List<Person>();
            ListPerson.Add(new Person("Andrzej", "Janowski"));
            ListPerson.Add(new Person("Krzys", "oski"));
            ListPerson.Add(new Person("Marek", "kowalski"));

            return ListPerson;                
        }

        private void cmb_Pole1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListPerson = new List<Person>();
            ListPerson.Add(new Person("Krzys", "oski123"));
            ListPerson.Add(new Person("Marek", "kowalski123"));
        }

        
        private void cmb_Pole3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Result = SelectedPerson.FirstName.ToString();
            //TxtB_Pole6.Text = SelectedPerson.SureName;
            //listyPerson.ListPerson.Add(new Person("asd", "qwe"));

           // DataContext = Result;
        }

        private void HyperLink_NewTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pokazuje", "OK");
        }
               
        private void BtnUseClick(object sender, RoutedEventArgs e)
        {
            Window_ListView window_List = new Window_ListView();
            window_List.ShowDialog();
        }

        public string ReadResource(string nameUrl)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = nameUrl;                       

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
