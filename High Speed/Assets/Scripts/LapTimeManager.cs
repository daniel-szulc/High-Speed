using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{

	public int MinuteCount;
	public  int SecondCount;
	public float MilliCount;
	public string MilliDisplay;

	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject MilliBox;
	public GameObject LapsBox;
	private static int allLaps = 1;
	private int lap = 1;
	public GameAssistant gameAssistant;
	private void Start()
	{
		if (GameManager.isMapOne)
		{
			allLaps = 3;
		}
		else
		{
			allLaps = 1;
		}

		LapsBox.GetComponent<Text>().text = lap + "/" + allLaps;
	}

	public void AddLap(bool isPlayerOneMode, bool isPlayerOneLap)
	{
		if (lap >= allLaps)
		{
		gameAssistant.EndGame(isPlayerOneMode, isPlayerOneLap);
		}
		else
		{
			lap++;
			LapsBox.GetComponent<Text>().text = lap + "/" + allLaps;
		}
	}

	void Update()
	{
		MilliCount += Time.deltaTime * 10;
		MilliDisplay = MilliCount.ToString("F0");
		MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

		if (MilliCount >= 10)
		{
			MilliCount = 0;
			SecondCount += 1;
		}

		if (SecondCount <= 9)
		{
			SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
		}
		else
		{
			SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
		}

		if (SecondCount >= 60)
		{
			SecondCount = 0;
			MinuteCount += 1;
		}

		if (MinuteCount <= 9)
		{
			MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
		}
		else
		{
			MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
		}

	}
}