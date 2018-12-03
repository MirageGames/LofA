using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageController : MonoBehaviour {

    PlayerController playerRef;
    public GameObject villageGUI;
    // Use this for initialization
    void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();

    }

    public void SetPanelActive()
    {
        villageGUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRef.canDonate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRef.canDonate = false;
        }
    }
}
