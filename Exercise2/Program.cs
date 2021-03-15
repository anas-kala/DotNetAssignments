using System;
using System.Collections.Generic;
using System.Linq;


/**
* @author $Anas Al Kala$
*
* @date - $time$ 
*/
namespace Exercise2
{
    class Program
    {
        public static List<string> list = new List<string>();
        public static void Main()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += IsPalindrome; // register with an event handler within this subscriber class.
            while (true)
            {
                Console.WriteLine("Enter a string here:");
                string s = Console.ReadLine();
                //bool isPalindorm = IsPalindrome(s);
                bl.StartProcess(s, IsPalindrome);
                Console.WriteLine("the list of palindorms you entered are:");
                foreach(string p in list)
                {
                    Console.WriteLine("-"+p);
                }
                Console.WriteLine("\nwould you like to continure? y/n");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("n"))
                    break;
                else
                    continue;
            }
        }

        // event handler
        public static bool IsPalindrome(string s)
        {
            int n = s.Length;
            char[] ch = s.ToCharArray();
            for (int i = 0; i < (n / 2); ++i)
            {
                if (ch[i] != ch[n - i - 1])
                {
                    return false;
                }
            }            
            list.Add(s);
            list = list.Distinct().ToList();
            return true;
        }
    }

    public delegate bool Notify(string str);  // delegate

    // publisher class
    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // event
        public string EnteredValue { get; set; }
        public void StartProcess(string s,Notify notify)
        {
            if (notify(s))
            {
                EnteredValue = s;
                Console.WriteLine("it is a palindorm");
                OnProcessCompleted();
            }
            else
            {
                Console.WriteLine("it is not palindorm");
            }
        }

        //protected virtual method 
        // Protected and virtual enable derived classes to override the logic for raising the event. 
        //However, A derived class should always call the On<EventName> method of the base class to ensure that registered delegates receive the event.
        protected virtual void OnProcessCompleted()
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke(EnteredValue);

        }
    }



}
