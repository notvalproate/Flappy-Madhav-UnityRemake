using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    //Public sprite array to store all digits
    public Sprite[] DigitSprites = new Sprite[10];

    //List of gameobjects to hole a digit with a sprite renderer, and list of integers that store each digit value
    private List<GameObject> DigitRenderer = new List<GameObject>();
    private List<int> Digits = new List<int>();
    private int ScoreCount;

    void Start()
    {
        //Initialze the count to 0 on start
        ScoreCount = 0;

        ClearDigits();

        //Add 0 to the digits and a new object to the list of gameobjects
        Digits.Add(0);
        DigitRenderer.Add(new GameObject("Digit_0", typeof(SpriteRenderer)));

        //Set it's parent to the Score and set the sprite to 0's sprite
        DigitRenderer[0].transform.SetParent(gameObject.transform, false);
        DigitRenderer[0].GetComponent<SpriteRenderer>().sprite = DigitSprites[0];
    }

    public void Increment()
    {
        //Incremenet the score and get the digits
        ScoreCount++;
        InitializeDigits();
    }

    void ClearDigits()
    {
        //Destroy all the gameobjects in the list and clear both lists
        //Using this function to start with a clean slate when needed
        for (int i = 0; i < DigitRenderer.Count; i++)
        {
            Destroy(DigitRenderer[i]);
        }
        DigitRenderer.Clear();
        Digits.Clear();
    }

    void InitializeDigits()
    {
        ClearDigits();

        //Get each digit and add it to the list
        int k = 1;
        while ((ScoreCount / k) != 0)
        {
            Digits.Add((ScoreCount / k) % 10);
            k *= 10;
        }

        //Based on each digit, add a new gameobject to the list and assign corressponding sprite
        //Offset to the position to move digits to the right
        float offset = 0.0f;

        //i starts at the end as the Digits is in reverse order, 0 is 1s place, 1 is 10s place, 2 is 100s place and so on.
        //Since we are going left to right we need the highest place first, hence start at end of the digits list
        for (int i = Digits.Count - 1; i >= 0; i--)
        {
            DigitRenderer.Add(new GameObject($"Digit_{i}", typeof(SpriteRenderer)));
            DigitRenderer.Last().transform.SetParent(gameObject.transform, false);
            DigitRenderer.Last().GetComponent<SpriteRenderer>().sprite = DigitSprites[Digits[i]];
            DigitRenderer.Last().transform.position += (Vector3.right * offset);

            //Increment the offset as desired. Digit 1 is thin compared to others hence offset incremented less
            if (Digits[i] == 1)
            {
                offset += 0.75f;
                continue;
            }
            //Else increment it normally
            offset += 0.9f;
        }
    }
}
