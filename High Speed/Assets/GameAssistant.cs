using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameAssistant : MonoBehaviour
{
   
    public GameObject CarYellowDayPrefab;
    public GameObject CarRedDayPrefab;
    public GameObject CarYellowNightPrefab;
    public GameObject CarRedNightPrefab;
    public GameObject dayLight, nightLight;
    public GameObject finishobjC, oneplayerobjC, twoplayerobjC;
    public Transform player1map1, player2map1, player1map2, player2map2;
    public TextMeshProUGUI PlayerOneBestTime;
    public GameObject canvas_player_two;
    public Text MinDisplayBest, SecDisplayBest, MillDisplayBest;
    private bool ended = false;
    public GameObject pauseMenu;
    private bool paused = false;
    /*Vector3 P1Map1 = new Vector3(83.55f, 0.576f, 440.253f);
    Vector3 P2Map1 = new Vector3(81.55f, 0.699f, 444.529f);
    private Quaternion QMap1 = new Quaternion(0, 244.99f, 0, -0.537f);*/
    void Start()
    {
        dayLight.SetActive(GameManager.isDay);
        nightLight.SetActive(!GameManager.isDay);
        if (GameManager.isTwoPlayers)
            {
                CreateNewMultiGame();
                canvas_player_two.SetActive(true);
                         }
            else
            {
               CreateNewSingleGame();
               canvas_player_two.SetActive(false);
            }
    }

    public void EndGame(bool isPlayerOneMode, bool isPlayerOneLap)
    {
        if (!ended)
        {
            ended = true;
            StartCoroutine(End(isPlayerOneMode, isPlayerOneLap));
        }
    }
    
    

    IEnumerator End(bool isPlayerOne, bool isPlayerOneLap)
    {
        finishobjC.SetActive(true);
        yield return new WaitForSeconds(3);
        Time.timeScale = 0.0f;
        finishobjC.SetActive(false);
        if (isPlayerOne)
        {
            oneplayerobjC.SetActive(true);
            PlayerOneBestTime.text = MinDisplayBest.text  + SecDisplayBest.text  + MillDisplayBest.text;
        }
        else
        {
            twoplayerobjC.SetActive(true);
            if (isPlayerOneLap)
            {
                twoplayerobjC.GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 wins";
            }
            else
            {
                twoplayerobjC.GetComponentInChildren<TextMeshProUGUI>().text = "Player 2 wins";
            }
        }
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void CreateNewSingleGame()
    {
        GameObject car;
        if (GameManager.isMapOne)
        {
            if (GameManager.isPlayerOneRed)
            {
                if (GameManager.isDay)
                {
                    car =  Instantiate(CarRedDayPrefab, player1map1.position, player1map1.rotation);
                }
                else
                {
                    car =  Instantiate(CarRedNightPrefab, player1map1.position, player1map1.rotation);
                }
            }
            else
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarYellowDayPrefab, player1map1.position, player1map1.rotation);
                }
                else
                {
                    car = Instantiate(CarYellowNightPrefab, player1map1.position, player1map1.rotation);
                }
            }
        }
        else
        {
            if (GameManager.isPlayerOneRed)
            {
                if (GameManager.isDay)
                {
                    car =  Instantiate(CarRedDayPrefab, player1map2.position, player1map2.rotation);
                }
                else
                {
                    car = Instantiate(CarRedNightPrefab, player1map2.position, player1map2.rotation);
                }
            }
            else
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarYellowDayPrefab, player1map2.position, player1map2.rotation);
                }
                else
                {
                    car = Instantiate(CarYellowNightPrefab, player1map2.position, player1map2.rotation);
                }
            }
        }

        car.GetComponent<CarAssistant>().isPlayerOne = true;
        car.tag = "Player01";
    }

    private void CreateNewMultiGame()
    {
        CreateNewSingleGame();
        GameObject car;
        if (GameManager.isMapOne)
        {
            if (GameManager.isPlayerTwoRed)
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarRedDayPrefab, player2map1.position, player2map1.rotation);
                }
                else
                {
                    car =  Instantiate(CarRedNightPrefab, player2map1.position, player2map1.rotation);
                }
            }
            else
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarYellowDayPrefab, player2map1.position, player2map1.rotation);
                }
                else
                {
                    car = Instantiate(CarYellowNightPrefab, player2map1.position, player2map1.rotation);
                }

            }
        }
        else
        {
            if (GameManager.isPlayerTwoRed)
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarRedDayPrefab, player2map2.position, player2map2.rotation);
                }
                else
                {
                    car = Instantiate(CarRedNightPrefab,player2map2.position, player2map2.rotation);
                }
            }
            else
            {
                if (GameManager.isDay)
                {
                    car = Instantiate(CarYellowDayPrefab, player2map2.position, player2map2.rotation);
                }
                else
                {
                    car =  Instantiate(CarYellowNightPrefab, player2map2.position, player2map2.rotation);
                }
            }
            
        }
        car.GetComponent<CarAssistant>().isPlayerOne = false;
        car.tag = "Player02";
    }

    public void Pause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ended)
        {
            Pause();
        }
    }
}
