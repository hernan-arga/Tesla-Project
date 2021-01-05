/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> itemList;

    public GameObject itemSlotContainer;
    public float itemSlotCellSizeX = 1.37f;
    public float itemSlotCellSizeY = 1.41f;
    public Vector2 originalPositionFirstSlot;

   
    private int slotX = 0;
    private int slotY = 0;

    public Item prefab1;

    // Start is called before the first frame update
    void Start()
    {
        originalPositionFirstSlot = new Vector2(-4.15f, 3.07f);
        itemList = new List<Item>();
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
        addItem(prefab1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item item)
    {
        itemList.Add(item);
        SetInventoryItem(item);
    }

    public void pickUp( Item item)
    {
        addItem(item);
       
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public bool GetActive()
    {
        return gameObject.activeSelf;
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    private void SetInventoryItem(Item item)
    {       
        RectTransform itemSlotRectTransform = Instantiate(itemSlotContainer.transform, transform)
            .GetComponent<RectTransform>();
        itemSlotRectTransform.gameObject.SetActive(true);
        itemSlotRectTransform.anchoredPosition = new Vector2(
                originalPositionFirstSlot.x + slotX * itemSlotCellSizeX,
                originalPositionFirstSlot.y - slotY * itemSlotCellSizeY);
        slotX++;
        if (slotX >= 3)
        {
            slotX = 0;
            slotY++;
        }
    }
    
}
*/