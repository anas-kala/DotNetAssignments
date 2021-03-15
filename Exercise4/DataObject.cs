using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExercise
{
    public enum EGender
    {
        Male, 
        Female,
        Unknown
    }

    public class DataObject
    {
        private static Random rand = new Random();

        private int _age;

        public int Age
        {
            get { return _age; }
        }

        private EGender _gender;

        public EGender Gender
        {
            get { return _gender; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }

        private bool _isHealthy;

        public bool IsHealthy
        {
            get { return _isHealthy; }
        }

        private DataObject(int age, string name, EGender gender, bool isHealthy)
        {
            _age = age;
            _name = name;
            _gender = gender;
            _isHealthy = isHealthy;
        }

        public static DataObject CreateRandomObject()
        {
            var namesMale = new List<string>
                {"Robert", "John" , " ", null, "William", "Richard", "Charles", "Donald", "Georg"};

            var namesFemale = new List<string>
                {"Mary", "Betty" , " ", null, "Barbara", "Shirley", "Patricia", "Dorothy", "Joan"};


            int randNum = rand.Next(1, 100);
            EGender gender;
            if (randNum <= 10)
            {
                gender = EGender.Unknown;
            }else if (randNum < 60)
            {
                gender = EGender.Female;
            }
            else
            {
                gender = EGender.Male;
            }

            int randName = rand.Next(0, namesMale.Count - 1);
            string name;
            if (gender == EGender.Female)
            {
                name = namesFemale[randName];
            }
            else
            {
                name = namesMale[randName];
            }

            bool isHealthy;
            int randNum2 = rand.Next(1, 100);
            if (randNum2 > 90)
            {
                isHealthy = true;
            }
            else
            {
                isHealthy = false;
            }

            int age = rand.Next(1, 100);

            return new DataObject(age, name, gender, isHealthy);
        }
        
    }


}
