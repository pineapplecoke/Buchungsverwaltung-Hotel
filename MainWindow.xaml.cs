using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DFI_U2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (string land in GastInformation.lander)
            {
                ComboBox_Herkunft.Items.Add(land);
            }
            foreach (string buchungsart in GastInformation.buchungsarten)
            {
                ComboBox_Buchungsart.Items.Add(buchungsart);
            }
            foreach (string zimmerart in GastInformation.zimmerarten)
            {
                ComboBox_Zimmer_Art.Items.Add(zimmerart);
            }
        }

        private void Neuer_kunder_Click(object sender, RoutedEventArgs e)
        {
            NeuGast neugast = new NeuGast();
            neugast.Left = 500;
            neugast.Top = 500;
            bool? result = neugast.ShowDialog();
            if (result == true)
            {
                GastInformation gast = new GastInformation(neugast.TextBox_Vorname.Text, neugast.TextBox_Nachname.Text, neugast.TextBox_Telefone.Text, neugast.ComboBox_Herkunft.Text, neugast.ComboBox_Buchungsart.Text, neugast.Data_Check_In.SelectedDate.Value, neugast.Data_Check_Out.SelectedDate.Value, int.Parse(neugast.TextBox_Kinder.Text), int.Parse(neugast.TextBox_Erwachsene.Text), neugast.ComboBox_Zimmer_Art.Text, int.Parse(neugast.TextBox_Zimmer_Nr.Text));
                Listbox_Gast.Items.Add(gast);
            }
        }

        private void Import_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file (*.csv)|*.csv|Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
               string ext = System.IO.Path.GetExtension(openFileDialog.FileName);
                if (ext == ".CSV")
                {
                    Import_CSV(openFileDialog.FileName).ForEach(gast => Listbox_Gast.Items.Add(gast));
                }
                else if (ext == ".xlsx")
                {
                    Import_xlsx(openFileDialog.FileName).ForEach(gast => Listbox_Gast.Items.Add(gast));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
        //TODO
        private void Export_file_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        //TODO
        //nicht robust, wenn leere Daten eingegeben sind.
        private void Aenderung_Click(object sender, RoutedEventArgs e)
        {
            if (Listbox_Gast.SelectedIndex > -1)
            {
                GastInformation gastinfo = (GastInformation)Listbox_Gast.SelectedItem;
                gastinfo.Vorname = TextBox_Vorname.Text;
                gastinfo.Nachname = TextBox_Nachname.Text;
                gastinfo.Telefon = TextBox_Telefone.Text;
                gastinfo.Herkunft = ComboBox_Herkunft.Text;
                gastinfo.Bunungsart = ComboBox_Buchungsart.Text;
                gastinfo.Zimmerart = ComboBox_Zimmer_Art.Text;
                //Wenn DateTime nicht eingegeben ist, wird heutiges Datum eingegeben.
                //Zwar moechte gerne Eingeben von Datum erforderlich machen. Sorge Checkin < Checkout muss gelten.
                try
                {
                    gastinfo.CheckIn = Data_Check_In.SelectedDate.Value;

                }
                catch (InvalidOperationException)
                {
                    gastinfo.CheckIn = DateTime.Now;
                    Data_Check_In.SelectedDate = DateTime.Now;
                }
                try
                {
                    gastinfo.CheckOut = Data_Check_Out.SelectedDate.Value;

                }
                catch (InvalidOperationException)
                {
                    gastinfo.CheckOut = DateTime.Now;
                    Data_Check_Out.SelectedDate = DateTime.Now;
                }
                //Wenn keine Zahl eingegeben, wird die Eingabe mit 0 ersetzt.
                //moechte gerne eingabe ausser Zahlen nicht moeglich erfordern.
                try
                {
                    gastinfo.ErwachsenAnzahl = int.Parse(TextBox_Erwachsene.Text);
                }
                catch (FormatException)
                {
                    gastinfo.ErwachsenAnzahl = 0;
                    TextBox_Erwachsene.Text = "0";
                }
                try
                {
                    gastinfo.KinderAnzahl = int.Parse(TextBox_Kinder.Text);
                }
                catch (FormatException)
                {
                    gastinfo.KinderAnzahl = 0;
                    TextBox_Kinder.Text = "0";
                }
                try
                {
                    gastinfo.Zimmernum = int.Parse(TextBox_Zimmer_Nr.Text);
                }
                catch (FormatException)
                {
                    gastinfo.Zimmernum = 000;
                    TextBox_Zimmer_Nr.Text = "000";
                }

                Listbox_Gast.Items.Refresh();
            }
        }
        //TODO
        //moechte gerne ein Popup Fenst zur Bestaetigung haben.
        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if(Listbox_Gast.SelectedIndex > -1)
            {
                Listbox_Gast.Items.Remove(Listbox_Gast.SelectedItem);
                TextBox_Vorname.Text = "";
                TextBox_Nachname.Text = "";
                TextBox_Telefone.Text = "";
                ComboBox_Herkunft.Text = "";
                ComboBox_Buchungsart.Text = "";
                Data_Check_In.Text = "";
                Data_Check_Out.Text = "";
                TextBox_Erwachsene.Text = "";
                TextBox_Kinder.Text = "";
                ComboBox_Zimmer_Art.Text = "";
                TextBox_Zimmer_Nr.Text = "";

                Listbox_Gast.Items.Refresh();
            }
        }
        //TODO
        //moechte gerne ein Popup Fenst zur Bestaetigung haben.
        private void Alle_loeschen_Click(object sender, RoutedEventArgs e)
        {
                Listbox_Gast.Items.Clear();
                TextBox_Vorname.Text = "";
                TextBox_Nachname.Text = "";
                TextBox_Telefone.Text = "";
                ComboBox_Herkunft.Text = "";
                ComboBox_Buchungsart.Text = "";
                Data_Check_In.Text = "";
                Data_Check_Out.Text = "";
                TextBox_Erwachsene.Text = "";
                TextBox_Kinder.Text = "";
                ComboBox_Zimmer_Art.Text = "";
                TextBox_Zimmer_Nr.Text = "";
        }
        //TODO
        //nicht robust, wenn leere Daten eingegeben sind.
        private List<GastInformation> Import_CSV(string path)
        {
            List<GastInformation> list = new List<GastInformation>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.ReadLine();
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    String[] checkIndatum = fields[6].Split('/');
                    int injahr = int.Parse(checkIndatum[0]);
                    int inmonat = int.Parse(checkIndatum[1]);
                    int intag = int.Parse(checkIndatum[2]);
                    String[] checkOutdatum = fields[7].Split('/');
                    int outjahr = int.Parse(checkOutdatum[0]);
                    int outmonat = int.Parse(checkOutdatum[1]);
                    int outtag = int.Parse(checkOutdatum[2]);

                    DateTime checkIn = new DateTime(injahr, inmonat, intag);
                    DateTime checkOut = new DateTime(outjahr, outmonat, outtag);

                    string vorname = fields[1];
                    string nachname = fields[2];
                    string telefon = fields[3];
                    string herkunft = fields[4];
                    string buchungsart = fields[5];
                    int kinderAnzahl = int.Parse(fields[8]);
                    int erwachsenAnzahl = int.Parse(fields[9]);
                    string zimmerart = fields[10];
                    int zimmernum = int.Parse(fields[11]);
                    list.Add(new GastInformation(vorname, nachname, telefon, herkunft, buchungsart, checkIn, checkOut, kinderAnzahl, erwachsenAnzahl, zimmerart, zimmernum));
                }
            }
            return list;
        }
        //TODO
        private List<GastInformation> Import_xlsx(string path)
        {
            List<GastInformation> list = new List<GastInformation>();
            
            return list;
        }

        private void Listbox_Gast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listbox_Gast.SelectedIndex > -1)
            {
                GastInformation gastinfo = (GastInformation)Listbox_Gast.SelectedItem;
                TextBox_Vorname.Text = gastinfo.Vorname;
                TextBox_Nachname.Text = gastinfo.Nachname;
                TextBox_Telefone.Text = gastinfo.Telefon;
                ComboBox_Herkunft.Text = gastinfo.Herkunft;
                ComboBox_Buchungsart.Text = gastinfo.Bunungsart;
                Data_Check_In.SelectedDate = gastinfo.CheckIn;
                Data_Check_Out.SelectedDate = gastinfo.CheckOut;
                TextBox_Erwachsene.Text = gastinfo.ErwachsenAnzahl.ToString();
                TextBox_Kinder.Text = gastinfo.KinderAnzahl.ToString();
                ComboBox_Zimmer_Art.Text = gastinfo.Zimmerart;
                TextBox_Zimmer_Nr.Text = gastinfo.Zimmernum.ToString();
            }
        }
    }
}
