using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoverBody : MonoBehaviour
{
    Rigidbody rb;
    public List<GameObject> engines;
    public GameObject centreOfMass;
    public float height = 3f;
    public float stabilization = 250f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindObjectOfType<Rigidbody>();
        rb.centerOfMass = centreOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject engine in engines)
        {
            RaycastHit hit;
            if (Physics.Raycast(engine.transform.position, transform.TransformDirection(Vector3.down), out hit, height))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(height - hit.distance, 2) / height * stabilization, engine.transform.position);
            }
            Debug.Log(hit.distance);
        }
    }
}
