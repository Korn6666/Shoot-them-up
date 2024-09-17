using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAvatar : BaseAvatar
{

    public float MaxEnergy;
    [SerializeField] private float Energy;
    public bool waitForFullEnergy;
    [SerializeField] private float energyChargeSpeed;
    public float drainShoot;
    public bool Shooting;

    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        type = AvatarType.PlayerAvatar;
        health = maxHealth;
        Energy = MaxEnergy;

        uIManager.SetMaxHealth(maxHealth);
        uIManager.SetMaxEnergy(MaxEnergy);
    }

    void Update(){
        if (Energy<=0){
            waitForFullEnergy = true;
            TakeEnergy(energyChargeSpeed* Time.deltaTime);
        }else if (Energy< MaxEnergy && !Shooting){
            TakeEnergy(energyChargeSpeed* Time.deltaTime);
        } else if (Energy>=MaxEnergy){
            Energy = MaxEnergy;
            uIManager.SetMaxEnergy(MaxEnergy);
            waitForFullEnergy = false;
        }
    }

    public override void TakeDamage(float damage){
        base.TakeDamage(damage);
        uIManager.SetHealth(health);
    }

    public void TakeEnergy(float energy){
        Energy += energy;

        uIManager.SetEnergy(Energy);
    }

    public override void Die(){
        base.Die();
        SceneManager.LoadScene(0);
    }


}
