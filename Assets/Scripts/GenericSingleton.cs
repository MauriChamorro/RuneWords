using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    private static readonly object padlock = new object();

    public static T Instance { get { return instance; } private set { instance = value; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = this as T;
                    DontDestroyOnLoad(this.gameObject);
                }

            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


}
