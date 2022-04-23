﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{    
    [Header("Settings")] 
    [SerializeField] private LayerMask collideWith;

    private Projectile _projectile;

    private void Start()
    {
        _projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        CheckCollisions();
    }

    // Checks for collisions in order to call some logic
    private void CheckCollisions()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _projectile.ShootDirection,
            _projectile.Speed * Time.deltaTime + 0.2f, collideWith);

        if (hit)
        {
            _projectile.DisableProjectile();
            gameObject.SetActive(false);
        }
    }
}