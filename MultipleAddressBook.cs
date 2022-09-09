using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemDay23
{
    public class MultipleAddressBook
    {
        public List<PersonContacts> userList;
        public MultipleAddressBook()
        {
            this.userList = new List<PersonContacts>();
        }
        public void AddContact(String firstName, String lastName, String address, String city, String state, String zip, String contact, String email)
        {
            bool duplicate = equals(firstName);
            if (duplicate)
            {
                Console.WriteLine($"Duplicate Contact not allowed '{0}' is already in address book", firstName);
            }
            else
            {
                PersonContacts user = new PersonContacts(firstName, lastName, address, city, state, zip, contact, email);
                userList.Add(user);
            }
        }
        public bool equals(string first_name)
        {
            if (userList.Any(e => e.FirstName == first_name))
                return true;
            else
                return false;
        }

        public void Display()
        {
            if (userList.Count() > 0)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("FirstName   LastName   Address,  City,  State,  Zip,   Contact,  Email");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (PersonContacts cont in userList)
                {
                    cont.print();
                }
                Console.WriteLine("-----------------------------End_of_book------------------------------");
            }
            else
            {
                Console.WriteLine("Address_Book is Empty...!!!!!");
            }
        }
        public void EditContact(string fname)
        {
            int size = userList.Count;
            int check = 0;
            foreach (PersonContacts user in userList)
            {
                check++;
                if (user.FirstName.Equals(fname))
                {
                    userList.Remove(user);
                    Console.Write("Enter FirstName: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter LastName: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter Address : ");
                    string address = Console.ReadLine();
                    Console.Write("Enter City : ");
                    string city = Console.ReadLine();
                    Console.Write("Enter State : ");
                    string state = Console.ReadLine();
                    Console.Write("Enter zip : ");
                    string zip = Console.ReadLine();
                    Console.Write("Enter Contact No: ");
                    string contact = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    AddContact(firstName, lastName, address, city, state, zip, contact, email);
                    break;
                }
                else if (size == check)
                {
                    Console.WriteLine(fname + " not found in addressbook...");
                    break;
                }
            }
        }

        public void DeletContact(string Fname)
        {
            int size = userList.Count;
            int check = 0;
            foreach (PersonContacts user in userList)
            {
                check++;
                if (user.FirstName.Equals(Fname))
                {
                    userList.Remove(user);
                    Console.WriteLine("Contact Deleted Successfully...");

                    break;
                }
                else if (size == check)
                {
                    Console.WriteLine(Fname + " not found in addressbook...");
                    break;
                }
            }
        }
        public void SerchContact(string place)
        {
            List<string> person = new List<string>();
            bool exits = isPlaceExist(place);
            if (exits)
            {
                Console.WriteLine("Contacts From Place: " + place);
                foreach (PersonContacts user in userList.FindAll(x => x.Address.Equals(place)).ToList())
                {
                    string name = user.FirstName + " " + user.LastName;
                    person.Add(name);
                }
                foreach (PersonContacts user in userList.FindAll(x => x.State.Equals(place)).ToList())
                {
                    string name = user.FirstName + " " + user.LastName;
                    person.Add(name);
                }
                foreach (string val in person)
                {
                    Console.WriteLine(val);
                }
            }
            else
            {
                Console.WriteLine($"Contect not Found From {0}", place);
            }
        }
        public bool isPlaceExist(string place)
        {
            if (this.userList.Any(e => e.City == place) || this.userList.Any(e => e.State == place))
                return true;
            else
                return false;
        }
        public void CountContact(string countPlace)
        {
            int count = 0;
            bool exits = isPlaceExist(countPlace);
            if (exits)
            {
                Console.WriteLine("Contacts From Place: " + countPlace);
                foreach (PersonContacts user in userList.FindAll(x => x.Address.Equals(countPlace)).ToList())
                {
                    count++;
                }
                foreach (PersonContacts user in userList.FindAll(x => x.State.Equals(countPlace)).ToList())
                {
                    count++;
                }
                Console.WriteLine($"Total Contacts From {countPlace} : {count}");
            }
            else
            {
                Console.WriteLine($"Contect not Found From {0}", countPlace);
            }
        }
        public void SortAlphabetically()
        {
            List<string> sortedList = new List<string>();
            foreach (PersonContacts getContacts in userList)
            {
                string sortByFirstName = getContacts.FirstName.ToString();
                sortedList.Add(sortByFirstName);
            }
            sortedList.Sort();
            foreach (string sortedContact in sortedList)
            {
                Console.WriteLine(sortedContact);
            }
        }
    }
}
