using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public AudioSource DonateSFX;
    public Text GodCropText;
    public Text GodWoodText;
    public Text GodAnimalText;
    public Text GodOreText;
    public Text GodGoldText;
    public Text VillageCropText;
    public Text VillageWoodText;
    public Text VillageAnimalText;
    public Text VillageOreText;
    public Text VillageGoldText;

    GameManager gm;

    private int crops = 0;
    private int stone = 0;
    private int wood = 0;
    private int animal = 0;
    private int gold = 0;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void UpdateGUI()
    {
        GodCropText.text = crops.ToString();
        GodWoodText.text = wood.ToString();
        GodAnimalText.text = animal.ToString();
        GodOreText.text = stone.ToString();
        GodGoldText.text = gold.ToString();
        VillageCropText.text = crops.ToString();
        VillageWoodText.text = wood.ToString();
        VillageAnimalText.text = animal.ToString();
        VillageOreText.text = stone.ToString();
        VillageGoldText.text = gold.ToString();
    }
    // CROPS
    public void AddCrops(int amount)
    {
        crops += amount;
        // Update HUD
        print("CropCount: " + crops);
    }

    public void SubtractCrop(int amount)
    {
        crops -= amount;
        // Update HUD
        print("CropCount: " + crops);
    }
    public void SacrificeCrop()
    {
        if (crops > 0)
        {
            gm.G_Crops -= 1;           
            SubtractCrop(1);
            DonateSFX.Play();
            gm.UpdateAltarGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    public void DonateCrop()
    {
        if (crops > 0)
        {
            gm.V_Crops -= 1;
            SubtractCrop(1);
            DonateSFX.Play();
            gm.UpdateVillageGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    
    // STONE
    public void AddStone(int amount)
    {
        stone += amount;
        // Update HUD
        print("StoneCount: " + stone);
    }
    public void SubtractStone(int amount)
    {
        stone -= amount;
        // Update HUD
        print("StoneCount: " + stone);
    }
    public void SacrificeStone()
    {
        if (stone > 0)
        {
            gm.G_Ore -= 1;
            SubtractStone(1);
            DonateSFX.Play();
            gm.UpdateAltarGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    public void DonateStone()
    {
        if (stone > 0)
        {
            gm.V_Ore -= 1;
            SubtractStone(1);
            DonateSFX.Play();
            gm.UpdateVillageGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }

    // WOOD
    public void AddWood(int amount)
    {
        wood += amount;
        // Update HUD
        print("WoodCount: " + wood);
    }
    public void SubtractWood(int amount)
    {
        wood -= amount;
        // Update HUD
        print("WoodCount: " + wood);
    }
    public void SacrificeWood()
    {
        if (wood > 0)
        {
            gm.G_Wood -= 1;
            SubtractWood(1);
            DonateSFX.Play();
            gm.UpdateAltarGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    public void DonateWood()
    {
        if (wood > 0)
        {
            gm.V_Wood -= 1;
            SubtractWood(1);
            DonateSFX.Play();
            gm.UpdateVillageGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    // ANIMALS
    public void AddAnimal(int amount)
    {
        animal += amount;
        // Update HUD
        print("AnimalCount: " + animal);
    }
    public void SubtractAnimal(int amount)
    {
        animal -= amount;
        // Update HUD
        print("AnimalCount: " + animal);
    }
    public void SacrificeAnimal()
    {
        if (animal > 0)
        {
            gm.G_Animals -= 1;
            SubtractAnimal(1);
            DonateSFX.Play();
            gm.UpdateAltarGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    public void DonateAnimal()
    {
        if (animal > 0)
        {
            gm.V_Animals -= 1;
            SubtractAnimal(1);
            DonateSFX.Play();
            gm.UpdateVillageGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }

    // GOLD
    public void AddGold(int amount)
    {
        gold += amount;
        // Update HUD
        print("GoldCount: " + gold);
    }
    public void SubtractGold(int amount)
    {
        gold -= amount;
        // Update HUD
        print("GoldCount: " + gold);
    }
    public void SacrificeGold()
    {
        if (gold > 0)
        {
            gm.G_Gold -= 1;
            SubtractGold(1);
            DonateSFX.Play();
            gm.UpdateAltarGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
    public void DonateGold()
    {
        if (gold > 0)
        {
            gm.V_Gold -= 1;
            SubtractGold(1);
            DonateSFX.Play();
            gm.UpdateVillageGUI();
            UpdateGUI();
        }
        else
        {
            return;
        }
    }
}

