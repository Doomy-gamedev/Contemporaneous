using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food", menuName ="Inventory System/Item/Food")]
public class FoodObject : ItemObject
{
public int manaRestore;
public int healthRestore;
public int staminaRestore;
private void Awake() 
{
    type = ItemType.Food;
}

}
