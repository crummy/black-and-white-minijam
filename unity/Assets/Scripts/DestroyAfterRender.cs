using UnityEngine;
using System.Collections;

public class DestroyAfterRender : MonoBehaviour
{


    public int destroy = 1;
	
    void Update ()
	{
	    if (destroy <= 0)
	    {
	        GameObject.Destroy(gameObject);
	    }
	    destroy--;
	}

    
}
