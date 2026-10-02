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
        private bool isNameValid()
        {
            string Name = txtName.Text.Trim();

            if (Name == "")
            {
                MessageBox.Show("Kérlek add meg a nevedet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Name.Length < 3)
            {
                MessageBox.Show("Több ,mint 3 karakter hosszúnak kell lennie a névnek", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private bool isAgeValid()
        {
            string ageInput = txtAge.Text.Trim();
            if (ageInput == "")
            {
                MessageBox.Show("Kérlek add meg az életkorodat!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            try
            {
                int age = int.Parse(ageInput);
                if (age < 0 || age > 120)
                {
                    MessageBox.Show("Kérlek reális életkort adj meg(0 és 120 között)!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Az életkor csak szám lehet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("A megadott szám túl nagy!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool isMovieValid()
        {
            if (myComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Kérlek válassz egy filmet", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;


        }
        private bool isTicketValid()
        {
            if (rbNormal.IsChecked == true || rbStudent.IsChecked == true || rbVIP.IsChecked == true)
            {
                return true;

            }
            MessageBox.Show("Kérlek válassz egy jegytípust!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;


        }
        private bool isTicketNumberValid()
        {
            string tNumberInput = txtTicketCount.Text.Trim();

            if (tNumberInput == "")
            {
                MessageBox.Show("Kérlek add meg a jegyek számat!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            try
            {
                int numberT = int.Parse(tNumberInput);
                if (numberT < 1 || numberT > 10)
                {
                    MessageBox.Show("Kérlek 1-10 között add meg a jegyek számát.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Kérlek csak számot adj meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Megadott érték túl hosszú", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
        private int extraThings()
        {
            int extraPrice = 0;

            if (checkPopcorn.IsChecked == true)
            {
                extraPrice += 1200;
            }
            if (checkDrink.IsChecked == true)
            {
                extraPrice += 800;
            }
            if (check3D.IsChecked == true)
            {
                extraPrice += 500;
            }
            return extraPrice;
        }
        private bool isChecked()
        {
            if (checkAgree.IsChecked == true)
            {
                return true;

            }
            else
            {
                MessageBox.Show("Kérlek fogadd el a vásárlási feltételeket!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private int ticketTypePrice()
        {
            if (rbStudent.IsChecked == true)
            {
                return 1900;
            }
            if (rbVIP.IsChecked == true)
            {
                return 4000;
            }
            return 2500;
        }
        private string getSelectedTicketType()
        {
            if (rbStudent.IsChecked == true) return "Diákjegy";
            if (rbVIP.IsChecked == true) return "VIP jegy";
            return "Normál jegy";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isNameValid()) return;
            if (!isAgeValid()) return;
            if (!isMovieValid()) return;
            if (!isTicketValid()) return;
            if (!isTicketNumberValid()) return;
            if (!isChecked()) return;

            int ticketCount = int.Parse(txtTicketCount.Text.Trim());
            int TotalPrice = (ticketCount * ticketTypePrice()) + extraThings();

            string selectedMovie = (myComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            MessageBox.Show($"Sikeres foglalás!\n" +
                            $"Név: {txtName.Text.Trim()}\n" +
                            $"Film: {selectedMovie}\n" +
                            $"Jegytípus: {getSelectedTicketType()}\n" +
                            $"Jegyek száma: {ticketCount} db\n" +
                            $"Extrák: {extraThings()} Ft\n" +
                            $"Fizetendő: {TotalPrice} Ft",
                            "Foglalás visszaigazolása",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}