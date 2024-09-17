using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider energyBar;
    private bool pause;

    [SerializeField] private GameObject Menu;

    private void Start()
    {
        pause = false;   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Time.timeScale = 0.1f;
            Menu.SetActive(true);
            pause = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            Continue();
        }

    }


    public void Continue()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        pause = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

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
