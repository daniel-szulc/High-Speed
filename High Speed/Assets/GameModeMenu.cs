using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenu : MonoBehaviour
{
    public GameObject[] carYellow = new GameObject[2];
    public GameObject[] carRed = new GameObject[2];
    public GameObject numberPlayerCanvas;
    public GameObject mapCanvas;
    public GameObject dayCanvas;
    public GameObject ColorOneCanvas;
    public GameObject ColorTwoCanvas;
    private bool isTwoPlayers = false;
    private bool isMapOne = true;
    private bool playerOneReady = false;
    private bool playerTwoReady = false;
    private bool[] PlayerIsRed = new bool[2];
    private bool isDay = true;
    public GameObject[] colorbox1 = new GameObject[2];
    public GameObject[] readytext1 = new GameObject[2];

    void Start()
    {
        PlayerIsRed[0] = true;
        PlayerIsRed[1] = false;
    }

    public void PlayerNumber(int players)
    {
        if (players == 1)
        {
            isTwoPlayers = false;
        }
        else
        {
            isTwoPlayers = true;
        }
        numberPlayerCanvas.SetActive(false);
        mapCanvas.SetActive(true);
    }
    
    /*public void TwoPlayers()
    {
        isTwoPlayers = true;
        numberPlayerCanvas.SetActive(false);
        mapCanvas.SetActive(true);
    }*/

    public void MapOne()
    {
        isMapOne = true;
        mapCanvas.SetActive(false);
        dayCanvas.SetActive(true);
    }

    public void MapTwo()
    {
        isMapOne = false;
        mapCanvas.SetActive(false);
       dayCanvas.SetActive(true);
    }

    public void DayMode()
    {
        isDay = true;
        dayCanvas.SetActive(false);
        if (isTwoPlayers)
        {
            ColorTwoCanvas.SetActive(true);
        }
        else
        {
            ColorOneCanvas.SetActive(true);
        }
    }
    
    public void NightMode()
    {
        isDay = false;
        dayCanvas.SetActive(false);
        if (isTwoPlayers)
        {
            ColorTwoCanvas.SetActive(true);
        }
        else
        {
            ColorOneCanvas.SetActive(true);
        }
    }
    
    public void RedColor(int player)
    {
        carYellow[player].SetActive(false);
        carRed[player].SetActive(true);
        PlayerIsRed[player] = true;
    }
    
    public void YellowColor(int player)
    {
        carRed[player].SetActive(false);
        carYellow[player].SetActive(true);
        PlayerIsRed[player] = false;
    }

    public void PlayerOneAccept()
    {
        if (isTwoPlayers)
        {
            ReadyBox(0);
            playerOneReady = true;
            if (playerTwoReady)
            {
                NewGame();
            }
        }
        else
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        GameManager.isTwoPlayers = isTwoPlayers;
        GameManager.isMapOne = isMapOne;
        GameManager.isPlayerOneRed = PlayerIsRed[0];
        GameManager.isPlayerTwoRed = PlayerIsRed[1];
        GameManager.isDay = isDay;
        SceneManager.LoadScene("Game");
    }

    public void PlayerTwoAccept()
    {
        ReadyBox(1);
        playerTwoReady = true;
        if (playerOneReady)
        {
            NewGame();
        }
    }

    private void ReadyBox(int player)
    {
        colorbox1[player].SetActive(false);
        readytext1[player].SetActive(true);
    }
}
