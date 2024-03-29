﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    public void RestartGame() {
        Invoke("LoadGamePlay", 2f);
    }

    void LoadGamePlay() {
        print("game end");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

}
