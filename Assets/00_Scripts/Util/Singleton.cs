using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
                instance = GameObject.FindAnyObjectByType<T>() ?? new GameObject(typeof(T).Name).AddComponent<T>();

            return instance;
        }
    }

    protected virtual bool IsDontDestroy => false;

    protected virtual void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this as T;

        if(IsDontDestroy)
            DontDestroyOnLoad(gameObject);
    }
}
