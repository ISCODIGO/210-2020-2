using System;
using System.Windows;

namespace CalculadoraSimple
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

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            int n1 = Convert.ToInt32(txtNumero1.Text);
            int n2 = Convert.ToInt32(txtNumero2.Text);

            txtResultado.Text = (n1 + n2).ToString();      
        }

        private void btnRestar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMultiplicar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
