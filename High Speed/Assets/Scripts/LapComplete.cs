using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{

	public GameObject LapCompleteTrig01;
	public GameObject HalfLapTrig01;
	public GameObject MinuteDisplay01;
	public GameObject SecondDisplay01;
	public GameObject MilliDisplay01;
	public GameObject LapCompleteTrig02;
	public GameObject HalfLapTrig02;
	public GameObject MinuteDisplay02;
	public GameObject SecondDisplay02;
	public GameObject MilliDisplay02;
	private GameObject LapCompleteTrig;
	private GameObject HalfLapTrig;
	private GameObject MinuteDisplay;
	private GameObject SecondDisplay;
	private GameObject MilliDisplay;
	public LapTimeManager _lapTimeManager1;
	public LapTimeManager _lapTimeManager2;
	private  LapTimeManager _lapTimeManager;
	public bool isMode01;
	public GameObject LapTimeBox;

	private void Start()
	{
		if (isMode01)
		{
			LapCompleteTrig = LapCompleteTrig01;
			HalfLapTrig = HalfLapTrig01;
			MinuteDisplay = MinuteDisplay01;
			SecondDisplay = SecondDisplay01;
			MilliDisplay = MilliDisplay01;
			_lapTimeManager = _lapTimeManager1;
		}
		else
		{
			LapCompleteTrig = LapCompleteTrig02;
			HalfLapTrig = HalfLapTrig02;
			MinuteDisplay = MinuteDisplay02;
			SecondDisplay = SecondDisplay02;
			MilliDisplay = MilliDisplay02;
			_lapTimeManager = _lapTimeManager2;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player01") && isMode01 || other.CompareTag("Player02") && !isMode01)
		{
			if (_lapTimeManager.SecondCount <= 9)
			{
				SecondDisplay01.GetComponent<Text>().text = "0" + _lapTimeManager.SecondCount + ".";
			}
			else
			{
				SecondDisplay.GetComponent<Text>().text = "" + _lapTimeManager.SecondCount + ".";
			}

			if (_lapTimeManager.MinuteCount <= 9)
			{
				MinuteDisplay.GetComponent<Text>().text = "0" + _lapTimeManager.MinuteCount + ".";
			}
			else
			{
				MinuteDisplay.GetComponent<Text>().text = "" + _lapTimeManager.MinuteCount + ".";
			}

			MilliDisplay.GetComponent<Text>().text = "" + _lapTimeManager.MilliCount;

			_lapTimeManager.MinuteCount = 0;
			_lapTimeManager.SecondCount = 0;
			_lapTimeManager.MilliCount = 0;

			HalfLapTrig.SetActive(true);
			LapCompleteTrig.SetActive(false);
			if (other.CompareTag("Player01"))
			{
				_lapTimeManager.AddLap(isMode01, true);
			}
			else
			{
				_lapTimeManager.AddLap(isMode01, false);
			}
		}
		
	}

}