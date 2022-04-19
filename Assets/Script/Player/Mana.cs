using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    private Image barImage;
    private float manaRegenSpeed = 30f;

    public static float manaAmount = 0;
    public const int maxMana = 100;

    private void Awake() {
        barImage = transform.Find("Bar").GetComponent<Image>();
    }

    private void Update(){
        UpdateMana();
        barImage.fillAmount = RefillMana();
    }

    public void UpdateMana() {
        manaAmount += manaRegenSpeed * Time.deltaTime;
        // prevent overflow mana
        manaAmount = Mathf.Clamp(manaAmount, 0f, maxMana);
    }

    public void UseMana(){
        
        if (manaAmount >= 10) {
            manaAmount -= 10;
        }
        
    }

    public float RefillMana(){
        return manaAmount / maxMana;
    }

}
