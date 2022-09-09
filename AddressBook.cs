using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemDay23
{
    public class AddressBook
    {
        //Creating Object Of Class
        PersonContacts tempContact = new PersonContacts();
        //Creating Dictionary
        public Dictionary<string, PersonContacts> contacts;

        //Initializing Dictionary
        public AddressBook()
        {
            contacts = new Dictionary<string, PersonContacts>();
        }

        //Method Used To Create Contacts
        public void CreateContact()
        {
            tempContact.GetUserInfo();
            string name = tempContact.GetName();
            if (contacts.ContainsKey(name) is false)
            {
                contacts.Add(name, tempContact);
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        //Method Used To Add Contacts
        public void AddContacts()
        {
            tempContact.GetUserInfo();
            //UC-7 Ensuring No Duplicates
            try
            {
                if (contacts.Any(e => e.Value.Equals(tempContact)) is false)
                {
                    contacts.Add(tempContact.GetName(), tempContact);
                }
            }
            catch
            {
                Console.WriteLine("Contact already exist\n Please Please Check The Address Book ...");
            }

            //string name = tempContact.GetName();
            //if (contacts.ContainsKey(name) is false)
            //{
            //    contacts.Add(name, tempContact);
            //    Console.WriteLine("Successfully Added A New Contact!!!");
            //}
            //else
            //{
            //    Console.WriteLine("error");
            //}

        }

        //Method Used To Edit Contacts
        public void EditContact()
        {
            Console.WriteLine("Enter name of contact to edit: ");
            string name = Console.ReadLine();
            if (contacts.ContainsKey(name) is true)
            {
                PersonContacts tempContact = new PersonContacts();
                tempContact.GetUserInfo();
                string editName = tempContact.GetName();
                if (contacts.ContainsKey(editName) is false || editName == name)
                {
                    contacts.Remove(name);
                    contacts.Add(editName, tempContact);
                    Console.WriteLine("Successfully Edited And Saved!!!");
                    Display();
                }
                else
                    Console.WriteLine("Edited name is invalid");
            }
            else
                Console.WriteLine("Name does not exist");
        }

        //Method Used To Delete Contact
        public void DeleteContact()
        {
            Console.WriteLine("Enter name of contact to delete: ");
            string name = Console.ReadLine();
            if (contacts.ContainsKey(name) is true)
            {
                contacts.Remove(name);
                Console.WriteLine("Successfully Deleted!!!");
            }
            else
                Console.WriteLine("Name does not exist");
        }
        public void AddMultiple()
        {
            Console.WriteLine("Enter no of contacts to add");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                AddContacts();
            }
            Display();
            Console.WriteLine("Successfully Added New Contacts");
        }


        //Method Used To Display The Contacts
        //Display
        public void Display()
        {
            foreach (string name in contacts.Keys)
            {
                contacts[name].Display();
            }
        }
    }
    internal class AdressBookSystem
    {
        public Dictionary<string, AddressBook> adressBooks = new Dictionary<string, AddressBook>();
        public void AddAddressBook()
        {
            AddressBook adressBook = new AddressBook();
            adressBook.AddMultiple();
            Console.WriteLine("enter the addressbook name");
            string addressName = Convert.ToString(Console.ReadLine());
            adressBooks.Add(addressName.ToLower(), adressBook);

        }
    }
}

