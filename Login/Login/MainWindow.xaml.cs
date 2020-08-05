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

namespace Login
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (ComprobarCredenciales(UsuarioInput.Text, PasswordInput.Password))
            {
                // Mostrar la otra ventana.
                SecretWindow sw = new SecretWindow();                
                sw.Show();

                // Se cierra esta ventana.
                this.Close();
            }

            // Limpia el contenido, ingrese o no; dos formas de quitar el texto.
            UsuarioInput.Text = "";
            PasswordInput.Password = String.Empty;
        }

        private bool ComprobarCredenciales(String usuario, String password)
        {
            // Esta funcion se puede adaptar para usar con una base de datos
            // o con un fichero.
            return (usuario.Equals("admin") && password.Equals("admin"));
        }
    }
}
