using LiStream.DataHandler.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.DBDataHandler
{
    public class DBDataWriter : IDataWriter
    {
        private readonly LiStreamContext _context;

        public DBDataWriter(LiStreamContext context)
        {
            _context = context;
        }

        public bool DeleteData<T>(T obj)
        {
            try
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                _context.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateData<T>(T obj)
        {
            try
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool WriteData<T>(T obj)
        {
            try
            {
                if (obj is null) throw new ArgumentNullException(nameof(obj));
                _context.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool WriteData<T>(IEnumerable<T> obj)
        {
            try
            {
                if (obj is null) throw new ArgumentNullException(nameof(obj));
                _context.AddRange(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
