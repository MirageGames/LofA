using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    public enum Resource
    {
       none, crop, stone, tree, animal, enemy
    };

    Resource currentResource = Resource.none;
    public Resource CurrentResource { get { return currentResource; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Crop"))
        {
            currentResource = Resource.crop;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentResource = Resource.none;
    }
}
