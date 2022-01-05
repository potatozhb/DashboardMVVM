using UIDesign.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace UIDesign.ViewModels
{
    public class CurrencyViewModel: DependencyObject,INotifyPropertyChanged
    {


        private string _changedcurrency;

        public string ChangedCurrency
        {
            get { return _changedcurrency; }
            set 
            { 
                _changedcurrency = value;
                OnPropertyChanged(nameof(ChangedCurrency));
            }
        }

        private List<CurrencyModel> _currenciesfrom = new List<CurrencyModel>();
        public List<CurrencyModel> CurrenciesFrom
        {
            get { return _currenciesfrom; }
        }

        private CurrencyModel selectfrom;

        public CurrencyModel SelectFrom
        {
            get { return selectfrom; }
            set
            { 
                selectfrom = value;
                OnPropertyChanged(nameof(SelectFrom));
            }
        }


        private List<CurrencyModel> _currenciesto = new List<CurrencyModel>();
        public List<CurrencyModel> CurrenciesTo
        {
            get { return _currenciesto; }
        }


        private CurrencyModel selectto;

        public CurrencyModel SelectTo
        {
            get { return selectto; }
            set 
            { 
                selectto = value;
                OnPropertyChanged(nameof(SelectTo));
            }
        }

        private double inputmoney =0;

        public double InputMoney
        {
            get { return inputmoney; }
            set
            {
                inputmoney  = value;
                OnPropertyChanged(nameof(InputMoney));
            }
        }

        public CurrencyViewModel()
        {

            _currenciesfrom.Add(new CurrencyModel { CurrencyName="USD", ConvertRatio =1 });
            _currenciesfrom.Add(new CurrencyModel { CurrencyName="CAD", ConvertRatio =0.71 });
            _currenciesfrom.Add(new CurrencyModel { CurrencyName="RMB", ConvertRatio =0.18 });
            _currenciesfrom.Add(new CurrencyModel { CurrencyName="JPY", ConvertRatio =0.081 });
            _currenciesfrom.Add(new CurrencyModel { CurrencyName="ERD", ConvertRatio =1.5 });
            _currenciesfrom.Add(new CurrencyModel { CurrencyName="RSD", ConvertRatio =0.01 });


            _currenciesto.Add(new CurrencyModel { CurrencyName="USD", ConvertRatio =1 });
            _currenciesto.Add(new CurrencyModel { CurrencyName="CAD", ConvertRatio =0.71 });
            _currenciesto.Add(new CurrencyModel { CurrencyName="RMB", ConvertRatio =0.18 });
            _currenciesto.Add(new CurrencyModel { CurrencyName="JPY", ConvertRatio =0.081 });
            _currenciesto.Add(new CurrencyModel { CurrencyName="ERD", ConvertRatio =1.5 });
            _currenciesto.Add(new CurrencyModel { CurrencyName="RSD", ConvertRatio =0.01 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private ICommand _convert;

        public ICommand Convert
        {
            get
            {
                if( _convert == null )
                {
                    _convert = new RelayCommands(para => ConvertCurrent(para));
                }

                return _convert;
            }
        }

        private void ConvertCurrent(object obj)
        {
            if(SelectFrom != null && SelectTo != null)
            {
                double fr = SelectFrom.ConvertRatio * InputMoney;
                double money = fr/ SelectTo.ConvertRatio;

                ChangedCurrency = money + ", From " + SelectFrom.CurrencyName + " to " + SelectTo.CurrencyName; 
            }
            else
            {

                ChangedCurrency = "Invalid Input";
            }
        }


        private ICommand _cleardata;

        public ICommand ClearData
        {
            get
            {
                if (_cleardata == null)
                {
                    _cleardata = new RelayCommands(para => Clear());
                }

                return _cleardata;
            }
        }

        private void Clear()
        {
            ChangedCurrency = "****";
            SelectFrom = null;
            SelectTo = null;
            InputMoney = 0;
        }
    }
}
