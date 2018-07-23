using ContactsApp.DataAccess;
using ContactsApp.ViewModels;
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

namespace ContactsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ContactsGrid.CellEditEnding += DataGridCellEnding;
            EmailGrid.CellEditEnding += DataGridCellEnding;
            PhoneGrid.CellEditEnding += DataGridCellEnding;
            MailingAddressGrid.CellEditEnding += DataGridCellEnding;
        }


        public void DataGridCellEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid _sender = (DataGrid)sender;
            var dataContext = _sender.DataContext as ViewModel;
            switch (_sender.Name)
            {
                case "ContactsGrid":
                  var contact =  (Contact)e.EditingElement.DataContext;
                    contact.ModelStateChanged = true;
                    break;
                case "EmailGrid":
                    var email = (EmailAddress)e.EditingElement.DataContext;
                    email.ModelStateChanged = true;
                    break;
                case "PhoneGrid":
                    var phone = (PhoneNumber)e.EditingElement.DataContext;
                    phone.ModelStateChanged = true;
                    break;
                case "MailingAddressGrid":
                    var mail = (MailingAddress)e.EditingElement.DataContext;
                    mail.ModelStateChanged = true;
                    break;
                default:
                    break;
            }
        }

    }
}
