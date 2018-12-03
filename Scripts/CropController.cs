using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropController : MonoBehaviour
{
    public bool Collectable = false;
    public bool Depleted = false;

    SpriteRenderer sr;
    BoxCollider2D bc;
    Color32 highlight;
    public Sprite cropFull;
    public Sprite cropEmpty;
    float respawnCD;
    float respawnWait = 20f;
    // Use this for initialization
    void Start()
    {
        highlight = new Color32(150, 255, 82, 255);
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
        sr.sprite = cropEmpty;
        sr.color = Color.white;
        bc.enabled = false;
    }

    public void SetStateFull()
    {
        Depleted = false;
        sr.sprite = cropFull;
        sr.color = Color.white;
        bc.enabled = true;
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
