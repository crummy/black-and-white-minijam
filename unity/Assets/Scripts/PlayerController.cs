using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody body;
    public KeyCode rotateLeftKey;
    public KeyCode rotateRightKey;
    public KeyCode forwardsKey;
    public KeyCode backwardsKey;
    public KeyCode shootKey;
    public float maxRotationSpeed = 0.1f;
    public float forwardsSpeed = 1f;
    public float backwardsSpeed = 0.5f;
    public float maxSpeed = 10f;
    public float initialRotation = 0f;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        body.rotation.Set(0, initialRotation, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(rotateLeftKey))
        {
            body.angularVelocity = new Vector3(0, -maxRotationSpeed, 0);
        } else if (Input.GetKey(rotateRightKey))
        {
            body.angularVelocity = new Vector3(0, maxRotationSpeed, 0);
        } else
        {
            body.angularVelocity *= 0.5f;
        }

        if (Input.GetKey(forwardsKey))
        {
            body.velocity += transform.forward * forwardsSpeed;
        } else if (Input.GetKey(backwardsKey))
        {
            body.velocity += transform.forward * -backwardsSpeed;
        } else
        {
            body.velocity *= 0.9f;
        }

        Vector3.ClampMagnitude(body.velocity, maxSpeed);
	}
}
