using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPooler : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private LayerMask collideWith;

    private Fireball _fireball;

    private void Start()
    {
        _fireball = GetComponent<Fireball>();
    }

    private void Update()
    {
        CheckCollisions();
    }

    // when the fireball collide, this function runs
    private void CheckCollisions()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _fireball.ShootDirection,
            _fireball.Speed * Time.deltaTime + 0.2f, collideWith);

        if (hit)
        {
            _fireball.DisableProjectile();
            gameObject.SetActive(false);
        }
    }
}

