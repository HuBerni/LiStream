namespace LiStream.DataHandler.Interfaces
{
    public interface IDataFactory<TEntity, TDto> where TEntity : class where TDto : class
    {
        IList<TEntity> GetAll();
        TEntity Get(Guid id);
        bool Create(TDto dto);
        bool Update(TDto dto);
        bool Delete(Guid id);
    }
}
