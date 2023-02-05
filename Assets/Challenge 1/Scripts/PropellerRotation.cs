using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 rotationPropellor = new Vector3(0, 0, 20);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationPropellor * Time.deltaTime);
    }
}
