using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 25f;
    [SerializeField] float horsePower = 0;
    public float rotationSpeed = 15f;
    public float verticalInput;

    private Rigidbody carRB;

    // Start is called before the first frame update
    void Start()
    {
        carRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        carRB.AddForce(Vector3.forward * horsePower * verticalInput);
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
