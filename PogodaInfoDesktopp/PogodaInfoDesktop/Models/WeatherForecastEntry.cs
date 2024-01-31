using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PogodaInfoDesktop.Models
{
    public class WeatherForecastEntry
    {
        [JsonPropertyName("id_stacji")]
        public string IdStacji { get; set; }

        [JsonPropertyName("stacja")]
        public string Stacja { get; set; }

        [JsonPropertyName("data_pomiaru")]
        public string DataPomiaru { get; set; }

        [JsonPropertyName("godzina_pomiaru")]
        public string GodzinaPomiaru { get; set; }

        [JsonPropertyName("temperatura")]
        public string Temperatura { get; set; }

        [JsonPropertyName("predkosc_wiatru")]
        public string PredkoscWiatru { get; set; }

        [JsonPropertyName("kierunek_wiatru")]
        public string KierunekWiatru { get; set; }

        [JsonPropertyName("wilgotnosc_wzgledna")]
        public string WilgotnoscWzgledna { get; set; }

        [JsonPropertyName("suma_opadu")]
        public string SumaOpadu { get; set; }

        [JsonPropertyName("cisnienie")]
        public string Cisnienie { get; set; }

        public String toString()
        {

            return Environment.NewLine +"---STACJA: " + Stacja.ToUpper() +"---"
              + Environment.NewLine + "ID stacji: " + IdStacji
              + Environment.NewLine + "Data pomiaru: " + DataPomiaru
              + Environment.NewLine + "Godzina pomiaru: " + GodzinaPomiaru
              + Environment.NewLine + "Temperatura: " + Temperatura
              + Environment.NewLine + "Prędkość wiatru: " + PredkoscWiatru
              + Environment.NewLine + "Kierunek wiatru: " + KierunekWiatru
              + Environment.NewLine + "Wilgotność względna: " + WilgotnoscWzgledna
              + Environment.NewLine + "Suma opadów: " + SumaOpadu
              + Environment.NewLine + "Ciśnienie: " + Cisnienie;
        }
    }
}
