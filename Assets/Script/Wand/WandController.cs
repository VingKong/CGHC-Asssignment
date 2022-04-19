using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Wand wand;
    [SerializeField] private Transform holder;

    public PlayerController PlayerController { get; set; }
    public Mana Mana;
    public static float manaRemaining;
    
    private Wand _wandEquipped;

    private void Start()
    {        
        PlayerController = GetComponent<PlayerController>();
        Mana = GetComponent<Mana>();

        EquipWand(wand);
    }

    private void Update()
    {
        manaRemaining = Mana.manaAmount;
        if (Input.GetMouseButtonDown(0) && manaRemaining >= 10)
        {
          
            Fire();
        }
    }

    

    // Fires Projectiles
    private void Fire()
    {
       
        Mana.UseMana();
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
