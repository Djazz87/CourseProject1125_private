using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CourseProject1125.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void BtnLogin_Click(object sender, RoutedEventArgs e)
    {
        string login = TxtLogin.Text;
        string pass = TxtPassword.Text;
        
        if (login == "admin" && pass == "1234")
        {
            var nextWindow = new MainAppWindow(); 
            nextWindow.Show();
            this.Close();
        }
        else
        {
            LblError.Text = "Неверный логин или пароль";
        }
    }

}