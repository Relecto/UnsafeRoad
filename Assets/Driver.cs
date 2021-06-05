using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class Driver : MonoBehaviour
{

    public float reactionTime = 0.5f;

    [Range(0, 10000)]
    public float acceleration = 0f;

    Rigidbody rigidbody;

    float startTime;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();

        startTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = new Vector3(0, 0, 1) * acceleration * Time.fixedDeltaTime;
        rigidbody.AddForce(force, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Stolb")) {
            acceleration = 0;
        }

        if (other.CompareTag("Finish")) {
            Debug.Log("Dead!");
        }
    }
}
