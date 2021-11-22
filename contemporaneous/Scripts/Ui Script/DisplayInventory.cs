using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public IventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETTEEN_ITEMS;
    public int NUMBER_OF_COLUM;
    public int Y_SPACE_BETTEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreatDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void CreatDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.perfab, Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        }
    }
   
    
   public Vector3 GetPosition(int i)
   {
       return new Vector3(X_START + X_SPACE_BETTEEN_ITEMS *(i % NUMBER_OF_COLUM), Y_START + (-Y_SPACE_BETTEEN_ITEMS * (i/NUMBER_OF_COLUM)), 0f);
   }
    
     public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }else
            {
             var obj = Instantiate(inventory.Container[i].item.perfab, Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
