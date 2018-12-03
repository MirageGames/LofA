using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour {

    public bool Collectable = false;
    public bool Depleted = false;

    SpriteRenderer sr;
    Color32 highlight;
    BoxCollider2D bc;
    float respawnCD;
    float respawnWait = 20f;
    // Use this for initialization
    void Start()
    {
        highlight = new Color32(255, 150, 100, 255);
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        respawnCD = respawnWait;
        SetStateFull();
    }

    private void Update()
    {
        if (Depleted)
        {
            respawnCD -= Time.deltaTime;
            if (respawnCD <= 0)
            {
                respawnCD = respawnWait;
                SetStateFull();
            }
        }
    }

    public void SetStateDepleted()
    {
        Depleted = true;
        sr.enabled = false;
        bc.enabled = false;
        sr.color = Color.white;
    }

    public void SetStateFull()
    {
        Depleted = false;
        sr.enabled = true;
        bc.enabled = true;
        sr.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Depleted)
        {
            return;
        }
        else if (collision.CompareTag("Player"))
        {
            Collectable = true;
            sr.color = highlight;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collectable = false;
            sr.color = Color.white;
        }
    }
}
