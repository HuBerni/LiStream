using LiStream.DataHandler.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.DBDataHandler
{
    public class DBDataReader : IDataReader
    {
        private readonly LiStreamContext _context;

        public DBDataReader(LiStreamContext context)
        {
            _context = context;
        }

        public IEnumerable<T> ReadData<T>(Expression<Func<T, bool>>? expression = null) where T : class
        {
            IEnumerable<T>? items;

            try
            {   
                if (expression == null)
                {
                    items = _context.Set<T>();
                    return items;
                }  

                items = _context.Set<T>().Where(expression);

                return items;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T ReadFirstData<T>(Expression<Func<T, bool>>? expression) where T : class
        {
            T item;

            try
            {
                item = _context.Set<T>().FirstOrDefault(expression);
            }
            catch (Exception)
            {
                return null;
            }

            return item;
        }
    }
}
