using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Quest Item", menuName ="Inventory System/Item/Quest")]
public class QuestObject : ItemObject
{
private void Awake() 
{
    type = ItemType.Quest;
}

}
