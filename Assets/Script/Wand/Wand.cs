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
    private ObjectPooler _pooler;

    private void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
    }


    // Shoot fireball from the firePoint
    private void FireProjectile()
    {
        GameObject newProjectile = _pooler.GetObjectFromPool();
        newProjectile.transform.position = firePoint.position;
        newProjectile.SetActive(true);

        Fireball fireball = newProjectile.GetComponent<Fireball>();
        fireball.WandEquipped = this;
        fireball.SetDirection(WandController.PlayerController.FacingRight ? Vector3.right : Vector3.left);
    }   

    
    // Fire the wand
    public void Fire()
    {
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + msBetweenShots / 1000f;
            FireProjectile();
        }
    }    

}
