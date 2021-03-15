using System;
using System.Collections.Generic;


/**
* @author $Anas Al Kala$
*
* @date - $time$ 
*/
namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook.Add("Luka", "+4366736363");
            phoneBook.Add("Meck", "+436754309");
            phoneBook.Add("Max", "+4368098042");
            phoneBook.Add("Daniel", "+436744093");
            phoneBook.Add("Stefan", "+436256521");
            phoneBook.Add("Eric", "+430098978");
            phoneBook.Add("Enes", "+436675543");
            phoneBook.Add("Patrick", "+436611211");

            while (true)
            {
                Console.WriteLine("Enter your name");
                string keyName = Console.ReadLine();
                string value = "";
                if (phoneBook.TryGetValue(keyName, out value))
                {
                    Console.WriteLine($"the telefon number of {keyName} is: {value}");
                }
                else
                {
                    Console.WriteLine($"{keyName} is not registered in the phonebook");
                    Console.WriteLine($"Enter the phone number of  {keyName}");
                    int newPersonNumber = 0;
                    try
                    {
                        string NumberEntered = Console.ReadLine();
                        int.TryParse(NumberEntered, out newPersonNumber);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.GetType().Name);
                    }

                    phoneBook.Add(keyName, newPersonNumber.ToString());
                }
                Console.WriteLine("Would you like to look for another name? y/n");
                string input = Console.ReadLine();
                if (string.Equals("n", input, StringComparison.OrdinalIgnoreCase))
                    break;
                else
                    continue;
            }
        }
    }
}
