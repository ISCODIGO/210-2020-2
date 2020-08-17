using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Archivos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum EOpcion { ARCHIVO, DIRECTORIO}

        private EOpcion OpcionApertura;

        public MainWindow()
        {
            InitializeComponent();            
        }
        private void DirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            string dir = @"C:\Temp\MiDir";

            if (Directory.Exists(dir))
            {
                MessageBox.Show("Directorio existe");
                Directory.Delete(dir);
            }
            else
            {
                Directory.CreateDirectory(dir);
            }
        }

        private void FileBtn_Click(object sender, RoutedEventArgs e)
        {
            string dir = @"C:\Temp\MiDir\MiFile.txt";
            
            FileStream fs = null;

            // Version 0: Esta puede generar otras excepciones (No usar).
            //fs = File.Create(dir);
            //fs.Close();

            // Version 1.
            /*try
            {
                // Puede existir una excepcion.
                fs = File.Create(dir);
                
            } catch(Exception ex)
            {
                // Ha ocurrido una excepcion (Opcional, si existe un finally).
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Ocurra o no una excepcion (Opcional).
                if (fs != null)
                {
                    fs.Close();
                }
            }*/

            // Version 2.
            try
            {
                using (fs = File.Create(dir))
                {
                    // Para manipular el archivo creado.
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void EscribirBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(RutaTxt.Text, FileMode.Append)))
                {
                    sw.WriteLine("Tercer parcial");
                    sw.WriteLine("clase de manejo de ficheros");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RutaTxt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Este dialogo es para abrir archivos, se adapto para que lo haga con
            // directorios. De hecho es posible utilizar librerias de terceros ya
            // que en WPF no hay una solución nativa para esto.
            OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.CheckPathExists = false;
            openDialog.CheckFileExists = false;

            if (this.OpcionApertura == EOpcion.DIRECTORIO)
            {
                openDialog.Title = "Escoja un directorio";
                openDialog.Filter = "Directory|*.this.directory";
                openDialog.FileName = "select";

                if (openDialog.ShowDialog() == true)
                {
                    RutaTxt.Text = openDialog.FileName.Replace("select.this.directory", "");
                }
            } else if (this.OpcionApertura == EOpcion.ARCHIVO)
            {
                openDialog.Title = "Escoja un archivo";
                openDialog.Filter = "Archivo TXT|*.txt";
                openDialog.FileName = "Prueba.txt";

                if (openDialog.ShowDialog() == true)
                {
                    RutaTxt.Text = openDialog.FileName;
                }
            }
        }

        private void LeerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.OpcionApertura != EOpcion.ARCHIVO)
            {
                MessageBox.Show("Solo es posible leer archivos", "Advertencia", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    var sb = new StringBuilder();
                    string linea;

                    using (StreamReader sr = new StreamReader(RutaTxt.Text))
                    {
                        while ((linea = sr.ReadLine()) != null)
                        {
                            sb.Append(linea);
                            sb.Append("\n");
                        } 
                    }

                    MessageBox.Show(sb.ToString(), "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton Radio = sender as RadioButton;

            // Coloque esta opcion por defecto al activar el atributo IsChecked en
            // el RadioButton.
            if (Radio.Content == null)
            {
                this.OpcionApertura = EOpcion.ARCHIVO;
            }
            else if (Radio.Content.ToString() == "Archivo")
            {
                this.OpcionApertura = EOpcion.ARCHIVO;
            } else
            {
                this.OpcionApertura = EOpcion.DIRECTORIO;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
