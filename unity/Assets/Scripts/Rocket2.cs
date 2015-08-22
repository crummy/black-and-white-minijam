using UnityEngine;
using System.Collections;

public class Rocket2 : MonoBehaviour
{

    private Rigidbody rigidbody;
    public float exploteIn;
    private bool blackColor;
    public float speed = 100;

    public Vector3 offset = new Vector3(0,0,100);
    public GameObject prefab;


	

    public void StartMe(float lifetime, bool blackColor)
    {
        this.blackColor = blackColor;
        exploteIn = Time.time + lifetime;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed);
    }


    public void Update()
    {
        if (Time.time > exploteIn)
        {
            GameObject ge = (GameObject)Instantiate(prefab, transform.position + offset, Quaternion.LookRotation(-transform.forward));
            if (blackColor)
                ge.GetComponent<Shoot>().color = Color.black;
            GameObject.Destroy(gameObject);
        }
    }

	
	
}
