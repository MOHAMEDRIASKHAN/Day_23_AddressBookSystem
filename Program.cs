// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace AddressBookSystemDay23
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=============Welcome To Address Book================");
            AddressBook address = new AddressBook();
            address.CreateContact();
            address.Display();
            Console.ReadKey();
        }
    }
}