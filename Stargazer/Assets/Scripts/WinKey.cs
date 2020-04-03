using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinKey : MonoBehaviour {
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.completeLevel();
    }
}
