namespace Core.Intarfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepo<T> repo { get; }
        void save();

    }

}
