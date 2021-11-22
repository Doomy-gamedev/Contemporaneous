using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
public HUDBar healthBar;
public Text healthNumbers;
public int healthMax = 100;
 public int healthCurrent;
public HUDBar staminaBar;
public Text staminaNumbers;
 public int staminaMax = 100;
 public int staminaCurrent;
public float staminaRegenDecimal = 1;
private int staminaRegen;
[SerializeField]private bool staminaIsfull;
public HUDBar manaBar;
public Text manaNumbers;
 public int manaMax = 100;
public int manaCurrent;
public int manaRegen = 1;


    private void Start() 
    {
    healthCurrent = healthMax;

    healthBar.SetMaxValue(healthMax);

    healthNumbers.text = healthCurrent.ToString() + "/" +  healthMax.ToString();;

    staminaCurrent = staminaMax;

    staminaBar.SetMaxValue(staminaMax);

    staminaNumbers.text = staminaCurrent.ToString() + "/" +  staminaMax.ToString();
  
    manaCurrent = manaMax;

    manaBar.SetMaxValue(manaMax);

    manaNumbers.text = manaCurrent.ToString() + "/" +  manaMax.ToString();
    
    }

    private void FixedUpdate() 
    {
        StaminaIsfull();
        SaminaIsRegening();
    }
    private void StaminaIsfull()
    {
      staminaIsfull = staminaCurrent == staminaMax;
    }
    public void TakeDamage(int damage)
    {

    healthCurrent -= damage;

    healthBar.SetValue(healthCurrent);

    healthNumbers.text = healthCurrent.ToString() + "/" +  healthMax.ToString();;
    }
    public void TakeFatigue(int fatigue)
    {
      if (staminaCurrent >= 0F)
      {
      staminaCurrent -= fatigue;

      staminaBar.SetValue(staminaCurrent);

      staminaNumbers.text = staminaCurrent.ToString() + "/" +  staminaMax.ToString();  
      }
    
    }
     public void SaminaIsRegening()
    {
    if (!staminaIsfull)
    {
      
      staminaRegenDecimal += Time.deltaTime;
      staminaRegen = Mathf.RoundToInt( staminaRegenDecimal ) ;
      staminaCurrent += staminaRegen;

    staminaBar.SetValue(staminaCurrent);

    staminaNumbers.text = staminaCurrent.ToString() + "/" +  staminaMax.ToString();  
    }    
    
    }
    public void TakeExhaust(int exhaust)
    {

    manaCurrent -= exhaust;

    manaBar.SetValue(((int)manaCurrent));

    manaNumbers.text = manaCurrent.ToString() + "/" +  manaMax.ToString();
    }
}

