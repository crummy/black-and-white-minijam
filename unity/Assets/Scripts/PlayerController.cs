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
    public float maxForwardsSpeed = 1f;
    public float maxBackwardsSpeed = 0.5f;
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
            //body.rotation.AngleAxis(new Vector3(0, 1, 0), maxRotationSpeed);
        } else if (Input.GetKey(rotateRightKey))
        {
            //body.rotation.y -= maxRotationSpeed;
        } else if (Input.GetKey(forwardsKey))
        {
            body.AddForce(new Vector2(0, maxForwardsSpeed));
        } else if (Input.GetKey(backwardsKey))
        {
            body.AddForce(new Vector2(0, -maxBackwardsSpeed));
        }
	}
}
