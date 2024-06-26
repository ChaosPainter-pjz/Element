
namespace Base
{
    public class SingletonBase<T> where T : new()
    {
        private static T _instance;
        private static readonly object Locker = new object();
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (Locker)
                {
                    _instance ??= new T();
                }
                return _instance;
            }
        }
    }
}
