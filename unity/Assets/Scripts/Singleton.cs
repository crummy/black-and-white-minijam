using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	public T Instances {get; private set;}
	
	public bool Exists {get; private set;}
	
	protected virtual void Awake()
	{
	
		if (Instances == null || Instances == this) {
			Instances = this as T;
			Exists = true;
		} else {
			Debug.LogError ( "Destroying superflous" + typeof(T));
			Destroy (this);
		}
	}
}
