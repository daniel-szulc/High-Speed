using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isTwoPlayers;
    public static bool isMapOne;
    public static bool isPlayerOneRed;
    public static bool isPlayerTwoRed;
    public static bool isDay;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
