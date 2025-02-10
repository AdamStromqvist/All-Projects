using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration1_AAAV.DataLayer
{
    //-----------------------------------------------------------------------------------------------------------------------
    //Generic Repository which means it connects to all enteties so you dont need make one repository per entity!
    //-----------------------------------------------------------------------------------------------------------------------
    public class Repository<T> where T : class
    {    // Private list to store data entities.
        private readonly List<T> data;
        //  Constructor to give the repository a list of data entities.
        public Repository(List<T> data)
        {
            this.data = data;
        }

        public DataLayer.UnitOfWork UnitOfWork
        {
            get => default;
            set
            {
            }
        }
        // Method to add a new entity to the repository.
        public void Add(T entity)
        {
            data.Add(entity);
        }
        // Method to remove an entity from the repository
        public bool Remove(T entity)
        {
            return data.Remove(entity);
        }
        // Method to find entities based on a specified condition
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return data.Where(predicate);
        }
        // Method to find the first entity that matches a specified condtion or a null value.
        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return data.FirstOrDefault(predicate);
        }
        // Method to check if the repository is empty.
        public bool IsEmpty()
        {
            return data.Count == 0;
        }
        // Method to get the count of entities in the repository.
        public int Count()
        {
            return data.Count();
        }
    }
}
