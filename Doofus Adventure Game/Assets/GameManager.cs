using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject panel;
    public bool isGameplay;
    public GameObject doofus;

    void Awake()
    {
        isGameplay = false;
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }


    public void StartGame()
    {
        isGameplay = true;
        panel.SetActive(false);
    }

}
