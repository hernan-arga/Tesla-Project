using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puzzle_TicTacToe : MonoBehaviour
{
    public Slot_TicTacToe[] Slots;
    public Sprite[] SlotsSprites;
    private int[] puzzleSolution = { 1, 3, 0, 3, 2, 3, 0, 3, 1};
    private int[] currentSolution = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeSlotImage(int numberSlot)
    {
        int slotNumberSprite = Slots[numberSlot].ChangeCurrentNumber();
        Slots[numberSlot].SetSprite(SlotsSprites[slotNumberSprite]);
        currentSolution[numberSlot] = slotNumberSprite;

        if (puzzleSolution.SequenceEqual(currentSolution))
        {
            Debug.Log("¡Puzzle Resuelto!");
        }

    }
}
