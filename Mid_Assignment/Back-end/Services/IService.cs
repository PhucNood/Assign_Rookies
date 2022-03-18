namespace Back_end.Services
{
    public interface IService<T>
    {
        public ICollection<T> GetAll();
        public T GetById(int id);

        public void Add(T item);

        public void Update(T item);

        public void Remove(T item);

        public bool Existed(int id);

        public bool IsIncorrectFK(T item);

        public void Transact(Action<T> action, T item); //Action same void delegate



    }
}