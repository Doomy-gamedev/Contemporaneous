using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Perk", menuName ="Inventory System/Pickup/Perk")]
public class PerkObject : ItemObject
{

private void Awake() 
{
    type = ItemType.Perk;
}

}
