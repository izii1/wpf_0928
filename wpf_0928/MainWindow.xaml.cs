using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_0928
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private bool isNameValid()
        {
           string Name = txtName.Text.Trim();
           
            if (Name == "")
            {
                MessageBox.Show("Kérlek add meg a nevedet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Name.Length < 3)
            {
                MessageBox.Show("Több ,mint 3 karakter hosszúnak kell lennie a névnek", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        } 
    }
}