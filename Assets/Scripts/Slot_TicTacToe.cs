using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_TicTacToe : MonoBehaviour
{
    public Puzzle_TicTacToe puzzleParent;
    public int slotNumber;
    public int currentNumber;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        puzzleParent.ChangeSlotImage(slotNumber);
    }

    public void SetSprite(Sprite _sprite)
    {
        spriteRenderer.sprite = _sprite;
    }

    public int ChangeCurrentNumber()
    {        
        if (currentNumber+1 > puzzleParent.SlotsSprites.Length-1)
        {
            return currentNumber = 0;
        }

        return ++currentNumber;
    }
}
