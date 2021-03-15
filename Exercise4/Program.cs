using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
* @author $Anas Al Kala$
*
* @date - $time$ 
*/

namespace LamdaExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            var population = new List<DataObject>();
            for (int i = 0; i < 10000; i++)
            {
                var obj = DataObject.CreateRandomObject();
                population.Add(obj);
            }

            var verifier = new GenericDataProcessor<DataObject>();

            // adding contraints the list
            Predicate<DataObject> nameIsNotNull = NameIsNotNull;
            Predicate<DataObject> genderIsKnown = GenderIsKnown;
            verifier.AddDataConstraint(nameIsNotNull);
            verifier.AddDataConstraint(genderIsKnown);

            // filtering the population
            verifier.AddDataFiltered(population);
            double unhealthyWomen = verifier.Execute(fracktionOfUnhealthyFemalesAgedBtween30_50);
            Console.WriteLine("fraction of unhealthy women As double: " + unhealthyWomen + "\tAs an approximate fraction: " + unhealthyWomen.ToFractions(2000));
            double healthyMen = verifier.Execute(fractionOfHealthyMalesAgedBetween75_90);
            Console.WriteLine("\nfraction of healthy men As double: " + healthyMen+"\tAs an approximate fraction: "+healthyMen.ToFractions(2000));
            Console.ReadLine();
        }

        // constraints
        static bool NameIsNotNull(DataObject obj) => !string.IsNullOrEmpty(obj.Name) && !obj.Name.Equals(" ");
        static bool GenderIsKnown(DataObject obj) => obj.Gender != EGender.Unknown;

        static Func<List<DataObject>, double> fracktionOfUnhealthyFemalesAgedBtween30_50 = list =>
        {
            int count = 0;
            foreach (DataObject dataObject in list)
            {
                if (dataObject.Gender == EGender.Female && dataObject.IsHealthy == false && dataObject.Age < 50 && dataObject.Age > 30)
                {
                    count++;
                }
            }
            double d=(double) count / list.Count;
            return d;
        };

        static Func<List<DataObject>, double> fractionOfHealthyMalesAgedBetween75_90 = list =>
        {
            int count = 0;
            foreach (DataObject dataObject in list)
            {
                if (dataObject.Gender == EGender.Male && dataObject.IsHealthy == true && dataObject.Age < 90 && dataObject.Age > 75)
                {
                    count++;
                }
            }
            double d = (double)count / list.Count;
            return d;
        };
    }
}
