using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    Image slotImage;

    // Start is called before the first frame update
    void Start()
    {
        slotImage = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void SetImage(Image image)
    {
        slotImage = image;
    }
}
