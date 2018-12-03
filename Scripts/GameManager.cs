using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ClockText;
    public Text NewDayText;
    public Image GodsFavorImage;
    public Image VillageFavorImage;

    float godsFavor;
    float villageFavor;

    PlayerController playerRef;
    bool isPaused;
    float dayLength = 60f;
    float dayCD;
    int dayNumber;

    // GOD Items
    public int G_Crops;
    public int G_Ore;
    public int G_Wood;
    public int G_Gold;
    public int G_Animals;
    public Text G_CropText;
    public Text G_WoodText;
    public Text G_AnimalText;
    public Text G_OreText;
    public Text G_GoldText;

    // Village Items
    public int V_Crops;
    public int V_Ore;
    public int V_Wood;
    public int V_Gold;
    public int V_Animals;
    public Text V_CropText;
    public Text V_WoodText;
    public Text V_AnimalText;
    public Text V_OreText;
    public Text V_GoldText;

    // Use this for initialization
    void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();
        isPaused = false;
        dayCD = dayLength;
        dayNumber = 1;
        godsFavor = 50f;     // Maybe random?
        villageFavor = 50f;  // Maybe random?
        SetFirstDay();
        GodsFavorImage.fillAmount = godsFavor / 100;
        VillageFavorImage.fillAmount = villageFavor / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            dayCD -= Time.deltaTime;
            ClockText.text = Mathf.RoundToInt(dayCD).ToString();
            if(dayCD <=0)
            {
                EndDay();
            }
        }
        if(dayCD >=50)
        {
            NewDayText.enabled = true;
        }
        else if(dayCD <50)
        {
            if(NewDayText.enabled == true)
            {
                NewDayText.enabled = false;
            }
        }
       
    }

    public void UpdateAltarGUI()
    {
        G_CropText.text = G_Crops.ToString();
        G_WoodText.text = G_Wood.ToString();
        G_AnimalText.text = G_Animals.ToString();
        G_OreText.text = G_Ore.ToString();
        G_GoldText.text = G_Gold.ToString();
    }

    public void UpdateVillageGUI()
    {
        V_CropText.text = V_Crops.ToString();
        V_WoodText.text = V_Wood.ToString();
        V_AnimalText.text = V_Animals.ToString();
        V_OreText.text = V_Ore.ToString();
        V_GoldText.text = V_Gold.ToString();
    }

    private void EndDay()
    {
        PauseClock();
        int godFavorCost = (G_Animals + G_Crops + G_Gold + G_Ore + G_Wood) * 5;
        int villageFavorCost = (V_Animals + V_Crops + V_Gold + V_Ore + V_Wood) * 5;

        // Check God Score;
        if (godFavorCost > 0)
        {
            godsFavor -= godFavorCost;
            if(godsFavor <= 0)
            {
                // trigger God Lose condition
                SceneManager.LoadScene("GodLose");
            }
        }
        else if (godFavorCost <= 0)
        {           
            godsFavor += 15f;
           
        }   

        // Check Village Score
        if(villageFavorCost > 0)
        {
            villageFavor -= villageFavorCost;
            if(villageFavor <= 0)
            {
                //Trigger Village Lose condition
                SceneManager.LoadScene("VillageLose");
            }
        }
        else if (villageFavorCost <= 0)
        {
            villageFavor += 15f;           
        }

        // Win conditions
        if (godsFavor >= 100 && villageFavor >=100)
        {                       
            SceneManager.LoadScene("BothWin");
        }
        else if(godsFavor >= 100)
        {
            SceneManager.LoadScene("GodWin");
        }
        else if(villageFavor >= 100)
        {
            SceneManager.LoadScene("VillageWin");
        }

        // Display stats
        GodsFavorImage.fillAmount = godsFavor / 100;
        VillageFavorImage.fillAmount = villageFavor / 100;
        StartDay();
    }

    private void StartDay()
    {
        dayNumber++;
        int maxRand = Random.Range(2, dayNumber + 3);

        G_Crops = Random.Range(0, maxRand);
        G_Ore = Random.Range(0, maxRand);
        G_Wood = Random.Range(0, maxRand);
       G_Gold = Random.Range(0, maxRand);
        G_Animals = Random.Range(0, maxRand);

        V_Crops = Random.Range(0, maxRand);
        V_Ore = Random.Range(0, maxRand);
        V_Wood = Random.Range(0, maxRand);
        V_Gold = Random.Range(0, maxRand);
        V_Animals = Random.Range(0, maxRand);

        dayCD = dayLength;
        StartClock();
    }
    

    private void SetFirstDay()
    {
        G_Crops = 1;
        G_Wood = 1;
        G_Ore = 1;
        G_Animals = 1;

        V_Crops = 2;
        V_Wood = 1;
    }

    public void PauseClock()
    {
        isPaused = true;
        playerRef.canMove = false;
    }

    public void StartClock()
    {
        isPaused = false;
        playerRef.canMove = true;
    }
}
