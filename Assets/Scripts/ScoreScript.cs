using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public Sprite[] DigitSprites = new Sprite[10];
    private List<GameObject> DigitRenderer = new List<GameObject>();
    private List<int> Digits = new List<int>();
    private int ScoreCount = 0;

    void Start()
    {
        ScoreCount = 0;

        ClearDigits();

        Digits.Add(0);
        DigitRenderer.Add(new GameObject("Digit", typeof(SpriteRenderer)));
        DigitRenderer[0].transform.SetParent(gameObject.transform, false);
        DigitRenderer[0].GetComponent<SpriteRenderer>().sprite = DigitSprites[0];
    }

    public void Increment()
    {
        ScoreCount++;
        InitializeDigits();
    }

    void ClearDigits()
    {
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

        int k = 1;
        float offset = 0.0f;
        while ((ScoreCount / k) != 0)
        {
            Digits.Add((ScoreCount / k) % 10);
            k *= 10;
        }

        for (int i = Digits.Count - 1; i >= 0; i--)
        {
            DigitRenderer.Add(new GameObject($"Digit_{i}", typeof(SpriteRenderer)));
            DigitRenderer.Last().GetComponent<SpriteRenderer>().sprite = DigitSprites[Digits[i]];
            DigitRenderer.Last().transform.SetParent(gameObject.transform, false);
            DigitRenderer.Last().transform.position += (Vector3.right * offset);

            if (Digits[i] == 1)
            {
                offset += 0.75f;
                continue;
            }
            offset += 0.9f;
        }
    }
}
