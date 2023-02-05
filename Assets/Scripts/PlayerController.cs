using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //private variables

    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRB;
    [SerializeField] GameObject centreOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        playerRB.centerOfMass = centreOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //using the input manager to get player's input (-1,0,1)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //We will move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (IsOnGround())
        {
            playerRB.AddRelativeForce(Vector3.forward * verticalInput * horsePower);


            //We will make the vehicle rotate
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = playerRB.velocity.magnitude * 3.6f;
            speedometerText.SetText("Speed: " + Mathf.RoundToInt(speed) + " Km/h");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + Mathf.RoundToInt(rpm));
        }
        

        

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}
