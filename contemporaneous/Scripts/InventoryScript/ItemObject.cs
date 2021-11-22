using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Food,
    Equipment,
    Rune,
    Perk,
    Quest
}
public class ItemObject : ScriptableObject
{
    public GameObject perfab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
