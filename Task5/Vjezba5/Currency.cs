using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Vjezba5
{
    class Currency
    {

        [JsonProperty("Broj tečajnice")]
        public string ExchangeRateNumber { get;set;}
        [JsonProperty("Datum primjene")]
        public string Date { get; set; }
        [JsonProperty("Država")]
        public string Country { get; set; }
        [JsonProperty("Šifra valute")]
        public string CurrenyCode { get; set; }
        [JsonProperty("Valuta")]
        public string Curreny { get; set; }
        [JsonProperty("Jedinica")]
        public int Unit { get; set; }
        [JsonProperty("Kupovni za devize")]
        public double BuyingCurrency { get; set; }
        [JsonProperty("Srednji za devize")]
        public double MiddleCurrecy { get; set; }
        [JsonProperty("Prodajni za devize")]
        public double SellingCurrency { get; set; }

      


    }
}
    