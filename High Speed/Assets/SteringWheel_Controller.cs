using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteringWheel_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotations = 0;
    Quaternion defaultRotation;
    public float turnSpeed =200;
    private bool isPlayerOne;
    
    public float maxTurnAngle = 20;
    

    void Start()
    {
        defaultRotation = transform.localRotation;
        isPlayerOne = transform.parent.parent.parent.GetComponent<CarAssistant>().isPlayerOne;
    }

    void Update()
    {
        if(Input.GetKey (KeyCode.A) && isPlayerOne)
        {
            if (rotations > -7000)
            {
                rotations -= turnSpeed;
                transform.Rotate(-Vector3.back * Time.deltaTime * turnSpeed);
            }
        }
        else if(Input.GetKey (KeyCode.D) && isPlayerOne)
        {
            if (rotations < 7000)
            {
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
            rotations += turnSpeed;
            }
        }
        else if(Input.GetKey (KeyCode.LeftArrow) && !isPlayerOne)
        {
            if (rotations > -7000)
            {
                rotations -= turnSpeed;
                transform.Rotate(-Vector3.back * Time.deltaTime * turnSpeed);
            }
        }
        else if(Input.GetKey (KeyCode.RightArrow) && !isPlayerOne)
        {
            if (rotations < 7000)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
                rotations += turnSpeed;
            }
        }
        else    //rotate to default
        {
            if (rotations < -turnSpeed )
            {
                transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
                rotations += turnSpeed;
            }
            else if (rotations > turnSpeed )
            {
                transform.Rotate(-Vector3.back * Time.deltaTime * turnSpeed);
                rotations -= turnSpeed;
            }
            else if (rotations != 0)
            {
                transform.localRotation = defaultRotation;
                rotations = 0;
            }
        }
    }
}
