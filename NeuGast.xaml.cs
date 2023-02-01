using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DFI_U2
{
    /// <summary>
    /// NeuGast.xaml 的交互逻辑
    /// </summary>
    public partial class NeuGast : Window
    {
        public NeuGast()
        {
            InitializeComponent();
            Button_Speichern.IsEnabled = false;
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
            Data_Check_In.SelectedDate = DateTime.Now;
            Data_Check_Out.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        //Ueberpruefen, ob alle Felder gefuellt sind.
        private bool IsInformation_voll(string textbox_vorname, string textbox_nachname, string textbox_telefone, string combobox_herkunft, string combobox_buchungsart, string data_check_in, string data_check_out, string textbox_kinder, string textbox_erwachsene, string combobox_zimmer_art, string textbox_zimmer_nr)
        {
            return textbox_vorname != "" && textbox_nachname != "" && textbox_telefone != "" && combobox_herkunft != "" && combobox_buchungsart != "" && data_check_in != "" && data_check_out != "" && textbox_kinder != "" && textbox_erwachsene != "" && combobox_zimmer_art != "" && textbox_zimmer_nr != "";
        }
        
        private void ButtonActiv_TextChanged(object sender, TextChangedEventArgs e)
        {
            Button_Speichern.IsEnabled = IsInformation_voll(TextBox_Vorname.Text, TextBox_Nachname.Text, TextBox_Telefone.Text, ComboBox_Herkunft.Text, ComboBox_Buchungsart.Text, Data_Check_In.Text, Data_Check_Out.Text, TextBox_Kinder.Text, TextBox_Erwachsene.Text, ComboBox_Zimmer_Art.Text, TextBox_Zimmer_Nr.Text);
        }

        private void ButtonActiv_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_Speichern.IsEnabled = IsInformation_voll(TextBox_Vorname.Text, TextBox_Nachname.Text, TextBox_Telefone.Text, ComboBox_Herkunft.Text, ComboBox_Buchungsart.Text, Data_Check_In.Text, Data_Check_Out.Text, TextBox_Kinder.Text, TextBox_Erwachsene.Text, ComboBox_Zimmer_Art.Text, TextBox_Zimmer_Nr.Text);
        }

        //Nur Zahlen erlaubt
        private void Keyfillter_Textinput(object sender, TextCompositionEventArgs e)
        {
            if (!(e.Text).All(char.IsDigit))
            {
                e.Handled = true;
            }
        }
        //Zahlen * # + sind erlaubt
        private void Keyfillter_Telefon_Textinput(object sender, TextCompositionEventArgs e)
        {
            if (!(e.Text.All(char.IsDigit) || e.Text.Equals("*") || e.Text.Equals("+") || e.Text.Equals("#")))
            {
                e.Handled = true;
            }
        }
    }
}
