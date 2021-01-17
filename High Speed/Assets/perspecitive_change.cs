using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perspecitive_change : MonoBehaviour
{

    public GameObject car;
    public GameObject camtpp;
    public GameObject camfpp;
    private bool isFPS=false;
    private GameObject camera;

    private CameraStable _cameraStable;
    // Start is called before the first frame update
    void Start()
    {
        _cameraStable = car.GetComponentInChildren<CameraStable>();
        camera = car.GetComponentInChildren<CameraStable>().gameObject.GetComponentInChildren<Camera>().gameObject;
       // pos1 = camera.transform.localPosition;
       // pos2 = new Vector3(0.39f, -1.52f, 0.77f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isFPS)
            {
                camfpp.SetActive(false);
               camtpp.SetActive(true);
                isFPS = false;
                _cameraStable.enabled = true;
            }
            else
            {
                camfpp.SetActive(true);
                camtpp.SetActive(false);
                isFPS = true;
                _cameraStable.enabled = false;
            }
        }
    }

}
