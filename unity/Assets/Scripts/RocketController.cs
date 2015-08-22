using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

    private Vector3 startPosition;
    private enum Status { ready, fired, hit }
    private Status status;

    public Rigidbody body;

	// Use this for initialization
	void Start () {
        startPosition = transform.localPosition;
        status = Status.ready;
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    bool Fire(Vector3 direction)
    {
        if (status == Status.ready)
        {
            status = Status.fired;
            return true;
        } else
        {
            return false;
        }
    }
}
