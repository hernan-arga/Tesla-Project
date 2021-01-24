using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public GameObject detectedObject;

    [Header("Examine Parameters")]

    public GameObject examineWindow;
    public Image examineImage;
    public TextMeshProUGUI examineText;
    public bool isExamining = false;

    [Header("Others")]

    public Inventory inventory;
    public List<GameObject> pickedItems = new List<GameObject>();



    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();

            }
        }

    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;

        }
    }

    public void PickUpItem(Item item)
    {
        Debug.Log("El inventario es:");
        Debug.Log(GetComponent<Inventory>());
        Debug.Log("El Item es:");
        Debug.Log(item);
        Debug.Log(GetComponent<Item>());
        Debug.Log(item.GetComponent<Item>());

        inventory.GetComponent<Inventory>().pickUp(item.GetComponent<Item>());
    }

    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            Debug.Log("Close");
            examineWindow.SetActive(false);
            isExamining = false;
        }
        else
        {
            Debug.Log("Examine");
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            isExamining = true;
        }

    }


}