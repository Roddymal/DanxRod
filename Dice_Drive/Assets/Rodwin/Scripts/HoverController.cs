using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoverController : MonoBehaviour
{
    Rigidbody rb;
    public List<GameObject> engines;
    public GameObject propulsion;
    public GameObject centreOfMass;
    public float thrust = 400f;
    public float turnSpeed = 300f;
    public float height = 3f;
    public float stabilization = 250f;
    public float turnFriction = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.centerOfMass = centreOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * thrust, propulsion.transform.position);
        rb.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * turnSpeed);
        foreach (GameObject engine in engines)
        {
            RaycastHit hit;
            if (Physics.Raycast(engine.transform.position, transform.TransformDirection(Vector3.down), out hit, height))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(height - hit.distance, 2) / height * stabilization, engine.transform.position);
            }
            Debug.Log(hit.distance);
        }
        rb.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(rb.velocity).x * turnFriction);
    }
}
