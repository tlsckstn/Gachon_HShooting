using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null && !isQuitting)
                instance = GameObject.FindAnyObjectByType<T>(FindObjectsInactive.Include) ?? new GameObject(typeof(T).Name).AddComponent<T>();

            return instance;
        }
    }

    private static bool isQuitting;
    protected virtual bool IsDontDestroy => false;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (IsDontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    protected virtual void OnApplicationQuit() => isQuitting = true;
}
