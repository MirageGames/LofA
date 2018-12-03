using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public bool Collectable = false;
    public bool Depleted = false;

    SpriteRenderer sr;
    BoxCollider2D bc;
    CapsuleCollider2D cc;
    Color32 highlight;
    public Sprite treeFull;
    public Sprite treeEmpty;
    float respawnCD;
    float respawnWait = 20f;
    // Use this for initialization
    void Start()
    {
        highlight = new Color32(98,255,0,255);
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent < CapsuleCollider2D>();
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
        sr.sprite = treeEmpty;
        sr.color = Color.white;
        bc.enabled = false;
        cc.enabled = false;
    }

    public void SetStateFull()
    {
        Depleted = false;
        sr.sprite = treeFull;
        sr.color = Color.white;
        bc.enabled = true;
        cc.enabled = true;
        
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
