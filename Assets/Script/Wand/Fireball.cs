using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float speed = 30f;

    private void Update() 
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }    

}
