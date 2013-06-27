using System;
using System.Windows.Input;
using System.Windows.Threading;
using DocumentFormat.OpenXml.EMMA;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OxyPlot;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System.Globalization;


namespace WpfApplicationOxyPlot.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        /// 

     
        Random rand = new Random();
        public Collection<CollectionDataValue> Data { get; set; }

        public class CollectionDataValue
        {
            public double xData { get; set; }
            public double yData { get; set; }
        }
        
        public MainViewModel()
        {
            IncrementValue = new RelayCommand(() => IncrementValueExecute(), () => true);   //binding with button in XAML -> Command="{Binding IncrementValue}"
            ExampleValue = 0;                                                               //binding with textblock in XAML -> Text="{Binding ExampleValue}"         
            Data = new Collection<CollectionDataValue>();
            ComboBox1 = new RelayCommand(() => ComboBox1Execute(), () => true);
            
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        int flag = 1;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (flag == 1)
            {
            TimeCommand = DateTime.Now;
            RandomNumberValue = 21.5 + rand.NextDouble();
            Data.Add(new CollectionDataValue { xData = ExampleValue, yData = 21.5 + rand.NextDouble() });
            CollectionToString = Data.Count.ToString();
            ExampleValue += 1;
            }
            
        }

        #region logic

        public ICommand IncrementValue { get; private set; }

        private void IncrementValueExecute()
        {
            ExampleValue += 1;
        }

        public ICommand ComboBox1 { get; private set; }

        private void ComboBox1Execute()
        {
            int temp = 0;
        }


        private int _exampleValue;
        public int ExampleValue
        {
            get { return _exampleValue; }
            set
            {
                if (_exampleValue == value)
                    return;
                _exampleValue = value;
                RaisePropertyChanged("ExampleValue");
            }
        }


        private DateTime _timeCommand;
        public DateTime TimeCommand
        {
            get { return _timeCommand; }
            set
            {
                if (_timeCommand == value)
                    return;
                _timeCommand = value;
                RaisePropertyChanged("TimeCommand");
            }
        }

        private double _randomNumberValue;
        public double RandomNumberValue
        {
            get { return _randomNumberValue; }
            set
            {
                if (_randomNumberValue == value)
                    return;
                _randomNumberValue = value;
                RaisePropertyChanged("RandomNumberValue");
            }
        }

        private string _strTemp;
        public string CollectionToString
        {
            get { return _strTemp; }
            set
            {
                if (_strTemp == value)
                    return;
                _strTemp = value;
                RaisePropertyChanged("CollectionToString");
            }
        }


        //private string _comboBox;
        //public string ComboBox1
        //{
        //    get { return _comboBox; }
        //    set
        //    {
        //        if (_comboBox == value)
        //            return;
        //        _comboBox = value;
        //        RaisePropertyChanged("ComboBox1");
        //    }
        //}

        #endregion

       
    }
}