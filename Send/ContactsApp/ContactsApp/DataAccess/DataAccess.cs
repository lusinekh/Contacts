using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.DataAccess
{
    public class DataAccess
    {
        private static ContactsEntities dbContext = new ContactsEntities();

        public static List<Contact> GetAllContacts()
        {
            return dbContext.Contacts
                .Include("EmailAddresses")
                .Include("PhoneNumbers")
                .Include("MailingAddresses").ToList();
        }

        public static List<Contact> Search(string input)
        {
            return null;
        }

        #region Contacts


        public static void UpdateContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = dbContext.Contacts.Find(contact.Id);
                if (result != null)
                    result = contact;
                else
                    dbContext.Contacts.Add(contact);
            }

            dbContext.SaveChanges();
        }

        public static void DeleteContact(int contactId)
        {
            var result = dbContext.Contacts.Find(contactId);
            if (result != null)
            {
                dbContext.Contacts.Remove(result);
            }
        }
        #endregion

        #region Emails


        public static void UpdateEmails(List<EmailAddress> emails)
        {
            foreach (var email in emails)
            {
                var result = dbContext.EmailAddresses.Find(email.Id);
                if (result != null)
                    result = email;
                else
                    dbContext.EmailAddresses.Add(email);
            }

            dbContext.SaveChanges();
        }

        public static void DeleteEmail(int emailId)
        {
            var result = dbContext.EmailAddresses.Find(emailId);
            if (result != null)
            {
                dbContext.EmailAddresses.Remove(result);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region Phones

        public static void UpdatePhones(List<PhoneNumber> phones)
        {
            foreach (var phone in phones)
            {
                var result = dbContext.PhoneNumbers.Find(phone.Id);
                if (result != null)
                    result = phone;
                else
                    dbContext.PhoneNumbers.Add(phone);
            }

            dbContext.SaveChanges();
        }

        public static void DeletePhone(int phoneId)
        {
            var result = dbContext.PhoneNumbers.Find(phoneId);
            if (result != null)
            {
                dbContext.PhoneNumbers.Remove(result);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region Mails

        public static void UpdateMails(List<MailingAddress> mails)
        {
            foreach (var mail in mails)
            {
                var result = dbContext.MailingAddresses.Find(mail.Id);
                if (result != null)
                    result = mail;
                else
                    dbContext.MailingAddresses.Add(mail);
            }
            dbContext.SaveChanges();
        }

        public static void DeleteMail(int mailId)
        {
            var result = dbContext.MailingAddresses.Find(mailId);
            if (result != null)
            {
                dbContext.MailingAddresses.Remove(result);
                dbContext.SaveChanges();
            }
        }


        #endregion


    }
}
