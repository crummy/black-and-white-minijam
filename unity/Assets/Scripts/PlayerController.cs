﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody body;
    public GameObject rocket;
    private GameObject iRocket;
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

    private float currentVelocity = 0.0f;

    public GameObject rocketPrefab;
    public bool blackPlayer;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        body.rotation.Set(0, initialRotation, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject iRocket = (GameObject)GameObject.Instantiate(rocketPrefab, transform.position, transform.rotation);
            Physics.IgnoreCollision(iRocket.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            Rocket2 r2 = iRocket.GetComponent<Rocket2>();
            r2.StartMe(1,blackPlayer);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
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
            currentVelocity += forwardsSpeed;
        } else if (Input.GetKey(backwardsKey))
        {
            currentVelocity += -backwardsSpeed;
        } else
        {
            currentVelocity *= 0.9f;
        }

        currentVelocity = Mathf.Clamp(currentVelocity,-maxSpeed, maxSpeed);
        body.AddForce(transform.forward * currentVelocity - body.velocity, ForceMode.VelocityChange);

        
	}
}
