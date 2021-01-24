using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> itemList;

    public GameObject itemSlotContainer;
    public float itemSlotCellSizeX;
    public float itemSlotCellSizeY;
    public Vector2 originalPositionFirstSlot;

   
    private int slotX = 0;
    private int slotY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //originalPositionFirstSlot = new Vector2(-4.15f, 3.07f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item item)
    {
        if (itemList == null) {
            itemList = new List<Item>();
        }
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
        GameObject itemImage = itemSlotRectTransform.transform.Find("SlotIcon").gameObject;
        if (itemImage != null)
        {
            itemImage.GetComponent<UnityEngine.UI.Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
        slotX++;
        if (slotX >= 3)
        {
            slotX = 0;
            slotY++;
        }
    }
    
}
