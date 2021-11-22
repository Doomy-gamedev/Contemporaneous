using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory System/Item/Equipment")]
public class EquipmentObject : ItemObject
{

    public float attckBounus;
    public float defenceBounus;
    public int slots;
    public int manaMax;
    public int manarRegen;
    public float castDelay;
    public int spellCasts;



private void Awake() 
{
    type = ItemType.Equipment;
}

}
