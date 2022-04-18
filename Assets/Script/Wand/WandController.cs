using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Wand wand;
    [SerializeField] private Transform holder;

    public PlayerController PlayerController { get; set; }
    
    private Wand _wandEquipped;

    private void Start()
    {        
        PlayerController = GetComponent<PlayerController>();
        EquipWand(wand);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    // Fires Projectiles
    private void Fire()
    {
        _wandEquipped.Fire();
    }
    
    // Equipp the wand
    public void EquipWand(Wand newWand)
    {
        if (_wandEquipped == null)
        {
            _wandEquipped = Instantiate(newWand, holder.position, Quaternion.identity);
            _wandEquipped.WandController = this; 
            _wandEquipped.transform.SetParent(holder);
        }
    }
}
