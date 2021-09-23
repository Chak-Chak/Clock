using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Clock.Annotations;
using Xamarin.Forms;

namespace Clock.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private string _backgroundColor = "#333333";
        private string _notActiveColor = "#2D2D2D";
        private string _activeColor = "Red";
        //public string[,] ClockColor = new string[6, 8];
        private string _currentTime = "00:00:00";
        private ObservableCollection<Number> _display { get; set; }
        public MainViewModel()
        {
            _display = new ObservableCollection<Number>();
            for (int i = 0; i < 6; i++)
            {
                Display.Add(new Number {
                    Indicator0 = notActiveColor,
                    Indicator1 = notActiveColor,
                    Indicator2 = notActiveColor,
                    Indicator3 = notActiveColor,
                    Indicator4 = notActiveColor,
                    Indicator5 = notActiveColor,
                    Indicator6 = notActiveColor
                });
            }
            Device.StartTimer(TimeSpan.FromMilliseconds(200), OnTimer);
        }

        private bool OnTimer()
        {
            DateTime dateTime = DateTime.Now;
            currentTime = dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString();
            int hour = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;
            List<int> digits = new List<int>();
            digits = hour.ToString().Select(c => (int)char.GetNumericValue(c)).ToList();

            if (digits.Count() == 1)
            {
                SetTime(0, "0");
                SetTime(1, digits[0].ToString());
            }
            else
            {
                SetTime(0, digits[0].ToString());
                SetTime(1, digits[1].ToString());
            }

            digits.Clear();

            digits = minute.ToString().Select(c => (int)char.GetNumericValue(c)).ToList();

            if (digits.Count() == 1)
            {
                SetTime(2, "0");
                SetTime(3, digits[0].ToString());
            }
            else
            {
                SetTime(2, digits[0].ToString());
                SetTime(3, digits[1].ToString());
            }

            digits.Clear();

            digits = second.ToString().Select(c => (int)char.GetNumericValue(c)).ToList();

            if (digits.Count() == 1)
            {
                SetTime(4, "0");
                SetTime(5, digits[0].ToString());
            }
            else
            {
                SetTime(4, digits[0].ToString());
                SetTime(5, digits[1].ToString());
            }
            return true;
        }

        private int SetTime(int num, string value)
        {
            switch(value)
            {
                case "0":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = activeColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = notActiveColor;
                    break;
                case "1":
                    Display[num].Indicator0 = notActiveColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = notActiveColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = notActiveColor;
                    Display[num].Indicator6 = notActiveColor;
                    break;
                case "2":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = notActiveColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = activeColor;
                    Display[num].Indicator5 = notActiveColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "3":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = notActiveColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "4":
                    Display[num].Indicator0 = notActiveColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = notActiveColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "5":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = notActiveColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "6":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = notActiveColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = activeColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "7":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = notActiveColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = notActiveColor;
                    Display[num].Indicator6 = notActiveColor;
                    break;
                case "8":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = activeColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = activeColor;
                    break;
                case "9":
                    Display[num].Indicator0 = activeColor;
                    Display[num].Indicator1 = activeColor;
                    Display[num].Indicator2 = activeColor;
                    Display[num].Indicator3 = activeColor;
                    Display[num].Indicator4 = notActiveColor;
                    Display[num].Indicator5 = activeColor;
                    Display[num].Indicator6 = activeColor;
                    break;
            }
            return 0;
        }

        public class Number : INotifyPropertyChanged
        {
            private string _indicator0;
            private string _indicator1;
            private string _indicator2;
            private string _indicator3;
            private string _indicator4;
            private string _indicator5;
            private string _indicator6;

            public string Indicator0
            {
                get => _indicator0;
                set
                {
                    _indicator0 = value;
                    RaisePropertyChanged(nameof(Indicator0));
                }
            }

            public string Indicator1
            {
                get => _indicator1;
                set
                {
                    _indicator1 = value;
                    RaisePropertyChanged(nameof(Indicator1));
                }
            }

            public string Indicator2
            {
                get => _indicator2;
                set
                {
                    _indicator2 = value;
                    RaisePropertyChanged(nameof(Indicator2));
                }
            }

            public string Indicator3
            {
                get => _indicator3;
                set
                {
                    _indicator3 = value;
                    RaisePropertyChanged(nameof(Indicator3));
                }
            }

            public string Indicator4
            {
                get => _indicator4;
                set
                {
                    _indicator4 = value;
                    RaisePropertyChanged(nameof(Indicator4));
                }
            }

            public string Indicator5
            {
                get => _indicator5;
                set
                {
                    _indicator5 = value;
                    RaisePropertyChanged(nameof(Indicator5));
                }
            }

            public string Indicator6
            {
                get => _indicator6;
                set
                {
                    _indicator6 = value;
                    RaisePropertyChanged(nameof(Indicator6));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public ObservableCollection<Number> Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged(nameof(_display));
            }
        }

        public string BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                if (_backgroundColor != value)
                {
                    _backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }

        public string notActiveColor
        {
            get => _notActiveColor;
            set
            {
                if (_notActiveColor != value)
                {
                    _notActiveColor = value;
                    OnPropertyChanged(nameof(notActiveColor));
                }
            }
        }

        public string activeColor
        {
            get => _activeColor;
            set
            {
                if (_activeColor != value)
                {
                    _activeColor = value;
                    OnPropertyChanged(nameof(activeColor));
                }
            }
        }

        public string currentTime
        {
            get => _currentTime;
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged(nameof(currentTime));
                }
            }
        }
    }
}
