using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarGUIController : MonoBehaviour
{

    // Use this for initialization
    void OnEnable()
    {
        FindObjectOfType<PlayerController>().canMove = false;
        GameManager gm = FindObjectOfType<GameManager>();
        gm.PauseClock();
        gm.UpdateAltarGUI();
        FindObjectOfType<PlayerInventory>().UpdateGUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonExit()
    {
        FindObjectOfType<PlayerController>().canMove = true;
        FindObjectOfType<GameManager>().StartClock();
        gameObject.SetActive(false);
    }
}
