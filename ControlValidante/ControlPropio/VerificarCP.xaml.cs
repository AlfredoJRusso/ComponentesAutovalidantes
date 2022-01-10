using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ControlValidante.ControlPropio
{
    /// <summary>
    /// Lógica de interacción para VerificarCP.xaml
    /// </summary>
    public partial class VerificarCP : UserControl
    {
        public string TipoVali { get; set; }
        Regex Validacion;
        Match m;

        public VerificarCP()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }


        private void CajaText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CajaText.Text.Equals(""))
            {
                Etiqueta.Content = "El campo está vacío";
            }
            else
            {
                switch (TipoVali)
                {
                    case "CP":
                        validar("0[1-9][0-9]{3}|[1-4][0-9]{4}|5[0-2][0-9]{3}");
                        break;
                    case "DNI":
                        validar("/^[a-z]{3}[0-9]{6}[a-z]?$/i");
                        break;
                    case "tel":
                        validar("(\\+34|0034|34)?[ -]*(6|7)[ -]*([0-9][ -]*){8}");
                        break;
                    default:
                        CajaText.IsEnabled = false;
                        Etiqueta.Content = "No hay validacion";
                        break;
                }

            }
        }
        private void validar(string expresion)
        {
            Validacion = new Regex(expresion);
            m = Validacion.Match(CajaText.Text);
            if (m.Success)
            {
                Etiqueta.Content = "Validacion exitosa";
            }
            else
            {
                Etiqueta.Content = "Error de validacion";
            }
        }
    }
}
