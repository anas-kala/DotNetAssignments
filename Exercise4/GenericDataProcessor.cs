using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExercise
{
    public class GenericDataProcessor<T> : IDataProcessor<T>
    {
        private List<Predicate<T>> _predicates = new List<Predicate<T>>();
        private List<T> _dataBuffer = new List<T>();

        public void AddDataConstraint(Predicate<T> constraint)
        {
            _predicates.Add(constraint);
        }

        public void AddDataFiltered(List<T> data)
        {
            foreach(T obj in data)
            {
                int count = 0;
                foreach(Predicate<T> pre in _predicates)
                {
                    Predicate<T> predicate = pre;
                    if (!pre(obj))
                        break;
                    count++;
                }
                if (count == _predicates.Count)
                {
                    _dataBuffer.Add(obj);
                }
            }
        }

        public G Execute<G>(Func<List<T>, G> func)
        {
            return func(_dataBuffer);
        }
    }
}
