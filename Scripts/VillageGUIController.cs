using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageGUIController : MonoBehaviour {
    // Use this for initialization
    void OnEnable()
    {
        FindObjectOfType<PlayerController>().canMove = false;
        GameManager gm = FindObjectOfType<GameManager>();
        gm.PauseClock();
        gm.UpdateVillageGUI();
        FindObjectOfType<PlayerInventory>().UpdateGUI();
    }


    public void ButtonExit()
    {
        FindObjectOfType<PlayerController>().canMove = true;
        FindObjectOfType<GameManager>().StartClock();
        gameObject.SetActive(false);
    }
}
