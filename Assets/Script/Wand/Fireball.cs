using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float speed = 30f;

    public Wand WandEquipped { get; set; }

    private Vector3 _shootDirection;

    private void Start() 
    {
        _shootDirection = WandEquipped.WandController.PlayerController.FacingRight ? Vector3.right : Vector3.left;
    }    


    private void Update() 
    {
        transform.Translate(_shootDirection  * speed * Time.deltaTime);
    }    

}
