using UnityEngine;

namespace Base
{
    public class SingletonMonoBase<T> : MonoBehaviour where T:MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {

            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this as T;
            }

        }
    }
}
