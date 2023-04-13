using LiStream.DataHandler.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler
{
    public class DataHandler : IDataHandler
    {
        private IDataReader _reader;
        private IDataWriter _writer;

        public DataHandler(IDataWriter writer, IDataReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public bool Create<T>(T obj)
        {
            return _writer.WriteData(obj);
        }

        public bool Create<T>(IEnumerable<T> obj)
        {
            return _writer.WriteData(obj);
        }

        public bool Update<T>(T obj)
        {
            return _writer.UpdateData(obj);
        }

        public bool Delete<T>(T obj)
        {
            return _writer.DeleteData(obj);
        }

        public T GetSingle<T>(Expression<Func<T, bool>>? expression) where T : class
        {
            return _reader.ReadFirstData(expression);
        }

        public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class
        {
            return _reader.ReadData(expression);
        }
    }
}
