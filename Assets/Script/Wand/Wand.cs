using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Fireball fireballPrefab;
    [SerializeField] private Transform firePoint;

    public WandController WandController { get; set; }

    [Header("Gun Settings")]
    [SerializeField] private float msBetweenShots = 100;

    private float _nextShotTime;    
    
    // Fire the wand
    public void Fire()
    {
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + msBetweenShots / 1000f;
            Fireball fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
            fireball.WandEquipped = this;  
        }
    }    

}
