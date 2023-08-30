using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDeath, enemyShoot, gunShoot, health, playerHurt;




    private void Awake()
    {
        instance = this;
    }


    public void PlayAmmoPickup()
    {
        ammo.Stop();
        ammo.Play();
    }

    public void PlayEnemyShot()
    {
        enemyShoot.Stop();
        enemyShoot.Play();
    }   
    
    public void PlayEnemyDeath()
    {
        enemyShoot.Stop();
        enemyShoot.Play();
    }

    public void PlayGunShoot()
    {
        gunShoot.Stop();
        gunShoot.Play();
    }

    public void PlayHealthPickup()
    {
        health.Stop();
        health.Play();
    }

    public void PlayPlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }


}
