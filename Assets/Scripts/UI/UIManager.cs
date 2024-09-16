using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider energyBar;

    public void SetMaxHealth(float health) //Fonction à appeler dans le start d'une entité
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        Debug.Log("ya");
    }

    public void SetMaxEnergy(float energy) //Fonction à appeler dans le start d'une entité
    {
        energyBar.maxValue = energy;
        energyBar.value = energy;
    }

    public void SetHealth(float health)
    {
        healthBar.value = health;
    }
    public void SetEnergy(float energy)
    {
        energyBar.value = energy;
    }

}
