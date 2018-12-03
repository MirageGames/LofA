using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Sounds
    public AudioSource MineSFX;
    public AudioSource HarvestSFX;
    public AudioSource KillSFX;
    public AudioSource ChopSFX;

    Rigidbody2D rb;
    PlayerInventory inventory;
    Animator anim;

    float moveSpeed = 4.0f;
    Vector3 target;
    Vector3 dir;
    bool facingRight = true;
    public bool canMove = true;
    public bool canSacrifice = false;
    public bool canDonate = false;

    bool resetAnim = false;
    float animCD;
    float animWait = 0.5f;

    // Use this for initialization
    void Start()
    {
        target = transform.position;
        animCD = animWait;
        // There should only every be one instance of the player Prefab
        // So there will only be one of each item in the world.
        inventory = FindObjectOfType<PlayerInventory>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (canMove)
        {
            HandleMovement();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GatherResource();
        }

        if(resetAnim)
        {
            canMove = false;
            animCD -= Time.deltaTime;
            if(animCD <= 0)
            {
                resetAnimator();
                canMove = true;
                animCD = animWait;
                resetAnim = false;     
            }
        }
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0)) // LeftClick
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
        }

        dir = target - transform.position;
        float step = moveSpeed * Time.deltaTime;

        if (dir.magnitude >= step) // If we will reach out destination in one frame or less don't move
        {
            transform.Translate(dir.normalized * step, Space.World);
            anim.SetBool("IsMoving", true);
        }
        else if(dir.magnitude <= step)
        {
            anim.SetBool("IsMoving", false);
        }

        // Checks our sprite's facing direction vs the direction of travel.
        // and swaps if needed
        if (dir.normalized.x < 0 && facingRight || dir.normalized.x > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    private void GatherResource()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
        if (!hit.collider)
        {
            print("noCollider");
            return;
        }
        string resourceType = hit.collider.tag;

        switch (resourceType)
        {
            case "Crop":
                {
                    
                    CollectCrop(hit.collider);
                    break;
                }
            case "Stone":
                {
                    
                    CollectStone(hit.collider);
                    break;
                }
            case "Tree":
                {
                    
                    CollectWood(hit.collider);
                    break;
                }
            case "Animal":
                {
                    
                    CollectAnimal(hit.collider);
                    break;
                }
            case "Altar":
                {
                    if (canSacrifice)
                    {                       
                        FindObjectOfType<AltarManager>().SetPanelActive();
                    }
                    break;
                }
            case "Village":
                {
                    if(canDonate)
                    {
                        FindObjectOfType<VillageController>().SetPanelActive();
                    }
                    break;
                }
            case "Enemy":
                {
                    CollectGold(hit.collider);
                    break;
                }
            default:
                {
                    print("default");
                }
                break;
        }

    } 
    void resetAnimator()
    {
        anim.SetBool("IsHarvest", false);
        anim.SetBool("IsMine", false);
        anim.SetBool("IsChop", false);
        anim.SetBool("IsAttack", false);
    }
    private void CollectCrop(Collider2D collider)
    {
        CropController crop = collider.GetComponent<CropController>();

        if (crop.Collectable && !crop.Depleted)
        {
            canMove = false;
            HarvestSFX.Play();
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsHarvest", true);
            inventory.AddCrops(1);
            crop.SetStateDepleted();
            resetAnim = true;
        }
    }
    private void CollectStone(Collider2D collider)
    {
        StoneController stone = collider.GetComponent<StoneController>();
        if(stone.Collectable && !stone.Depleted)
        {
            canMove = false;
            MineSFX.Play();
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsMine", true);
            inventory.AddStone(1);
            stone.SetStateDepleted();
            resetAnim = true;
        }
    }
    private void CollectWood(Collider2D collider)
    {
        TreeController tree = collider.GetComponent<TreeController>();
        if (tree.Collectable && !tree.Depleted)
        {
            canMove = false;
            ChopSFX.Play();
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsChop", true);
            inventory.AddWood(1);
            tree.SetStateDepleted();
            resetAnim = true;
        }
    }    
    private void CollectAnimal(Collider2D collider)
    {
        AnimalController animal = collider.GetComponent<AnimalController>();
        if (animal.Collectable && !animal.Depleted)
        {
            canMove = false;
            KillSFX.Play();
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsAttack", true);
            inventory.AddAnimal(1);
            animal.SetStateDepleted();
            resetAnim = true;
        }
    }

    private void CollectGold(Collider2D collider)
    {
        GoldController gold = collider.GetComponent<GoldController>();
        if(gold.Collectable && !gold.Depleted)
        {
            canMove = false;
            KillSFX.Play();
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsAttack", true);
            inventory.AddGold(1);
            gold.SetStateDepleted();
            resetAnim = true;
        }
    }
}


