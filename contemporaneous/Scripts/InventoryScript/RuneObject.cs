using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Rune", menuName ="Inventory System/Pickup/Rune")]
public class RuneObject : ItemObject
{


private void Awake() 
{
    type = ItemType.Rune;
}

}
