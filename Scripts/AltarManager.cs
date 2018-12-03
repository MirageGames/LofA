using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour {

    PlayerController playerRef;
    public GameObject altarGUI; 
	// Use this for initialization
	void Start () {
        playerRef = FindObjectOfType<PlayerController>();

    }

    public void SetPanelActive()
    {
        altarGUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerRef.canSacrifice = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRef.canSacrifice = false;
        }
    }
}
