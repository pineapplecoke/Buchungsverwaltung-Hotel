using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_U2
{
    public class GastInformation
    {   //TODO
        //Entragnr. fehlt noch. Ich habe mich noch nicht entscheidet, wie man das am besten machen kann.
        private string vorname;
        private string nachname;
        private string telefon;
        private string herkunft;
        private string buchungsart;
        private DateTime checkIn;
        private DateTime checkOut;
        private int kinderAnzahl;
        private int erwachsenAnzahl;
        private string zimmerart;
        private int zimmernum;

        //TODO
        //Ich plane eine List von Lander erstellen, damit kann man im Combobox direkt auswaehlen.
        public static string[] lander = { "testland" };
        public static string[] buchungsarten = { "Internet", "Vergleichsporta", "Telefonisch", "Reisebuero" };
        public static string[] zimmerarten = { "Standard" };

        public GastInformation(string vorname, string nachname, string telefon, string herkunft, string buchungsart, DateTime checkIn, DateTime checkOut, int kinderAnzahl, int erwachsenAnzahl, string zimmerart, int zimmernum)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.telefon = telefon;
            this.herkunft = herkunft;
            this.buchungsart = buchungsart;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.kinderAnzahl = kinderAnzahl;
            this.erwachsenAnzahl = erwachsenAnzahl;
            this.zimmerart = zimmerart;
            this.zimmernum = zimmernum;
        }

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Herkunft { get => herkunft; set => herkunft = value; }
        public string Bunungsart { get => buchungsart; set => buchungsart = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }
        public int KinderAnzahl { get => kinderAnzahl; set => kinderAnzahl = value; }
        public int ErwachsenAnzahl { get => erwachsenAnzahl; set => erwachsenAnzahl = value; }
        public string Zimmerart { get => zimmerart; set => zimmerart = value; }
        public int Zimmernum { get => zimmernum; set => zimmernum = value; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.vorname, this.nachname);
        }

    }
}
