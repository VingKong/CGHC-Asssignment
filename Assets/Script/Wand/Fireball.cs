using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float speed = 30f;

    public Wand WandEquipped { get; set; }

    // find the shooting direction
    public Vector3 ShootDirection => _shootDirection;

    public float Speed { get; set; }


    private Vector3 _shootDirection;

    private void Update() 
    {
        transform.Translate(_shootDirection  * speed * Time.deltaTime);
    }   

    // set the shooting direction
        public void SetDirection(Vector3 newDirection)
    {
        _shootDirection = newDirection;
    }   
 

}
