using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExercise
{
    interface IDataProcessor<T>
    {
        void AddDataConstraint(Predicate<T> constraint);

        void AddDataFiltered(List<T> data);

        G Execute<G>(Func<List<T>, G> func);
    }
}
