using UnityEngine;

/// <summary>
/// Always add protected ctor to derived classes.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	static T instance;
	static object locker = new object();

	public static T Instance {
		get {
			lock (locker) {
				if(instance == null) {
					GameObject singleton = new GameObject {
						name = "(singleton) " + typeof(T).ToString(),
					};
					instance = singleton.AddComponent<T>();

					DontDestroyOnLoad(singleton);
				}
				return instance;
			}
		}
	}
}