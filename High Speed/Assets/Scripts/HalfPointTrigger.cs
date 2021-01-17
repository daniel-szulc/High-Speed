using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrig01;
    public GameObject HalfLapTrig01;
    public GameObject LapCompleteTrig02;
    public GameObject HalfLapTrig02;
    public bool isMode01; 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player01") && isMode01)
        {
            LapCompleteTrig01.SetActive(true);
            HalfLapTrig01.SetActive(false);
            Debug.Log("Triggered");
        }
        if (other.CompareTag("Player02") && !isMode01)
        {
            LapCompleteTrig02.SetActive(true);
            HalfLapTrig02.SetActive(false);
            Debug.Log("Triggered");
        }
    }
}
