using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DivisionScript : MonoBehaviour
{
    int randomNumber;

    public TextMeshProUGUI randomNumberText;
    public TextMeshProUGUI outputText;

    private void Start()
    {
        RandomNumberFinder();
    }

    void RandomNumberFinder()
    {
        outputText.text = "Neues Spiel";
        randomNumber = Random.Range(1, 100);
        randomNumberText.text = randomNumber.ToString();
    }

    public void Division(int a)
    {
        if (randomNumber % a == 0 && a != 1)
        {
            outputText.text = "Gut gemacht!";
        }
        else if (randomNumber % a != 0 || (randomNumber % 2 == 0 || randomNumber % 3 == 0 || randomNumber % 5 == 0|| randomNumber % 7 == 0 || randomNumber % 11 == 0 && a == 1))
        {
            outputText.text = "Probiers gleich nochmal!";
        }
        else if (randomNumber % 2 != 0 && a == 1)
        {
            outputText.text = "Gut erkannt, das ist eine Primzahl!";
        }

        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3);

        RandomNumberFinder();
    }
}
