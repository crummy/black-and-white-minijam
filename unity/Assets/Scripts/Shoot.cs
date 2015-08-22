using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public ParticleSystem effect;
    public float duration;

    public Color color
    {
        set { effect.startColor = value; }
        get { return effect.startColor;  }
    }

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(WaitAndDestroy(duration));
	}


    IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
    }
}
