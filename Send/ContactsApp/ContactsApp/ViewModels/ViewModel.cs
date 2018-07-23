using ContactsApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp.Commands;
using System.Windows.Input;

namespace ContactsApp.ViewModels
{
    public class ViewModel: INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<Contact> contacts;
        private Contact selectedContact;
        private ObservableCollection<EmailAddress> emails;
        private EmailAddress selectedEmail;
        private ObservableCollection<MailingAddress> mails;
        private MailingAddress selectedMail;
        private ObservableCollection<PhoneNumber> phones;
        private PhoneNumber selectedPhone;



        #endregion

        #region Ctor

        public ViewModel()
        {
            contacts = new ObservableCollection<Contact>();
            selectedContact = new Contact();
            emails = new ObservableCollection<EmailAddress>();
            selectedEmail = new EmailAddress();
            mails = new ObservableCollection<MailingAddress>();
            selectedMail = new MailingAddress();
            phones = new ObservableCollection<PhoneNumber>();
            selectedPhone = new PhoneNumber();

            this.PropertyChanged += PropertyChangedExecute;
        }

        private void PropertyChangedExecute(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedContact":
                    LoadAllEntities(1);
                    LoadAllEntities(2);
                    LoadAllEntities(3);
                    break;
                default:
                    break;
            }
        }



        #endregion

        #region Properties

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
                RisePropertyChanged("Contacts");
            }
        }

        public Contact SelectedContact
        {
            get
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;
                RisePropertyChanged("SelectedContact");
            }
        }

        public ObservableCollection<EmailAddress> Emails
        {
            get
            {
                return emails;
            }
            set
            {
                emails = value;
                RisePropertyChanged("Emails");
            }
        }

        public EmailAddress SelectedEmail
        {
            get
            {
                return selectedEmail;
            }
            set
            {
                selectedEmail = value;
                RisePropertyChanged("SelectedEmail");
            }
        }

        public ObservableCollection<MailingAddress> Mails
        {
            get
            {
                return mails;
            }
            set
            {
                mails = value;
                RisePropertyChanged("Mails");
            }
        }

        public MailingAddress SelectedMail
        {
            get
            {
                return selectedMail;
            }
            set
            {
                selectedMail = value;
                RisePropertyChanged("SelectedMail");
            }
        }

        public ObservableCollection<PhoneNumber> Phones
        {
            get
            {
                return phones;
            }
            set
            {
                phones = value;
                RisePropertyChanged("Phones");
            }
        }

        public PhoneNumber SelectedPhone
        {
            get
            {
                return selectedPhone;
            }
            set
            {
                selectedPhone = value;
                RisePropertyChanged("SelectedPhone");
            }
        }

        #endregion

        #region Commands
        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                    add = new RelayCommand(AddEntity);
                return add;
            }
        }

        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                    delete = new RelayCommand(DeleteEntity);
                return delete;
            }
        }

        private ICommand load;
        public ICommand Load
        {
            get
            {
                if (load == null)
                    load = new RelayCommand(LoadAllEntities);
                return load;
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                    save = new RelayCommand(SaveEntities);
                return save;
            }
        }

        #endregion

        #region Execution
        private void AddEntity(object param)
        {
            int paramValue = GetParam(param);

            switch (paramValue)
            {
                case 0:
                    Contacts.Add(new Contact { ModelStateChanged = true });
                    break;
                case 1:
                    Emails.Add(new EmailAddress { ModelStateChanged = true });             
                    break;
                case 2:
                    Phones.Add(new PhoneNumber { ModelStateChanged = true });
                    break;
                case 3:
                    Mails.Add(new MailingAddress { ModelStateChanged = true });
                    break;
                default:
                    break;
            }
        }

        private void DeleteEntity(object param)
        {
            int paramValue = GetParam(param);
            switch (paramValue)
            {
                case 0:
                    DataAccess.DataAccess.DeleteContact(SelectedContact.Id);
                    break;
                case 1:
                    DataAccess.DataAccess.DeleteEmail(SelectedEmail.Id);
                    break;
                case 2:
                    DataAccess.DataAccess.DeletePhone(SelectedPhone.Id);
                    break;
                case 3:
                    DataAccess.DataAccess.DeleteMail(SelectedMail.Id);
                    break;
                default:
                    break;
            }
        }

        private void LoadAllEntities(object param)
        {
            int paramValue = GetParam(param);
            switch (paramValue)
            {
                case 0:
                    Contacts = new ObservableCollection<Contact>(DataAccess.DataAccess.GetAllContacts());
                    break;
                case 1:
                    if (SelectedContact != null)
                        Emails = new ObservableCollection<EmailAddress>(SelectedContact.EmailAddresses);
                    break;
                case 2:
                    if (SelectedContact != null)
                        Phones = new ObservableCollection<PhoneNumber>(SelectedContact.PhoneNumbers);
                    break;
                case 3:
                    if (SelectedContact != null)
                        Mails = new ObservableCollection<MailingAddress>(SelectedContact.MailingAddresses);
                    break;
                default:
                    break;
            }
        }


        private void SaveEntities(object param)
        {
            int paramValue = GetParam(param);
            switch (paramValue)
            {
                case 0:
                    List<Contact> changedContacts = new List<Contact>();
                    foreach (var c in Contacts)
                    {
                        if (c.ModelStateChanged)
                        {
                            changedContacts.Add(c);
                        }
                    }
                    if (changedContacts.Any())
                        DataAccess.DataAccess.UpdateContacts(changedContacts);
                    break;
                case 1:

                    List<EmailAddress> changedEmails = new List<EmailAddress>();
                    foreach (var e in Emails)
                    {
                        if (e.ModelStateChanged)
                        {
                            changedEmails.Add(e);
                        }
                    }
                    if (changedEmails.Any())
                        DataAccess.DataAccess.UpdateEmails(changedEmails);
                    break;
                case 2:
                    List<PhoneNumber> changedPhones = new List<PhoneNumber>();
                    foreach (var p in Phones)
                    {
                        if (p.ModelStateChanged)
                        {
                            changedPhones.Add(p);
                        }
                    }
                    if (changedPhones.Any())
                        DataAccess.DataAccess.UpdatePhones(changedPhones);
                    break;
                case 3:
                    Mails = new ObservableCollection<MailingAddress>(SelectedContact.MailingAddresses);
                    List<MailingAddress> changedMails = new List<MailingAddress>();
                    foreach (var m in Mails)
                    {
                        if (m.ModelStateChanged)
                        {
                            changedMails.Add(m);
                        }
                    }
                    if (changedMails.Any())
                        DataAccess.DataAccess.UpdateMails(changedMails);

                    break;
                default:
                    break;
            }


        }

        private int GetParam(object param)
        {
            if (param is string)
                return int.Parse((string)param);
            if (param is int)
                return(int)param;
            return 0;
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
