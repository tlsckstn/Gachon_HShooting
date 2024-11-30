using UnityEngine;

/// <summary>
/// 이 클래스를 상속받아 싱글톤 클래스로 만들 수 있음
/// 만드는 법: 클래스이름 : Singleton<클래스이름>
/// DontDestroy를 override해서 true로 만들면 Scene을 바꿔도 사라지지 않음
/// </summary>
/// <typeparam name="T"></typeparam>
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
