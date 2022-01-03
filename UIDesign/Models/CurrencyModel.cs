using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesign.Models
{
    public class CurrencyModel
    {
        private string _currencyname;

        public string CurrencyName
        {
            get { return _currencyname; }
            set { _currencyname = value; }
        }

        private double _convertratio;
        /// <summary>
        /// Convert ratio with USD, assume USD is 1
        /// </summary>
        public double ConvertRatio
        {
            get { return _convertratio; }
            set { _convertratio = value; }
        }

    }
}
