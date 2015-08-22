using UnityEngine;
using System.Collections;
using System;

public class RocketController : MonoBehaviour {

    public AudioClip explodeSound;
    public AudioClip fireSound;

    public float initialVelocity = 1f;
    public float acceleration = 5f;
    public float maxVelocity = 10f;
    public float maxDistance = 20f;

    private Vector3 firedPosition;
    private Vector3 velocity;
    private enum Status { ready, fired, hit }
    private Status status;

    private Rigidbody body;

	void Awake () {
        status = Status.ready;
        body = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        body.AddForce(transform.forward * acceleration * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
	    if (status == Status.fired)
        {
            float distanceTravelled = Vector3.Distance(transform.position, firedPosition);
            if (distanceTravelled > maxDistance)
            {
                rocketExplode();
            }
        }
	}

    public bool Fire(Vector3 from, Vector3 direction)
    {
        if (status == Status.ready)
        {
            transform.position = from;
            transform.forward = direction;
            firedPosition = from;
            status = Status.fired;
            velocity = transform.forward * initialVelocity;
            body.AddForce(velocity, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(fireSound, Vector3.zero);
            return true;
        } else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rocketExplode();
    }

    private void rocketExplode()
    {
        Debug.Log("Rocket exploded");
        AudioSource.PlayClipAtPoint(explodeSound, Vector3.zero);
        ColorBlobStackManager.Instances.SpawnSpericalColorBlob(ColorBlob.BlobColor.Black, transform.position / 2);
        status = Status.ready;
        gameObject.SetActive(false);
    }
}
