using UnityEngine;
using System.Collections;

public class DestroyYourSelfOnStart : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	    GameObject.Destroy(gameObject);
	}
	
}
