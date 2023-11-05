
using UnityEngine;
using TMPro;

public class ZahlenartenScript : MonoBehaviour
{
    public TextMeshProUGUI ergebnisText;
    public TextMeshProUGUI randomNumberText;


    private float randomNumber;

    void Start()
    {
        GenerateAndCheckNumber();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckGuessedNumber(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckGuessedNumber(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckGuessedNumber(3);
        }
    }

    void GenerateAndCheckNumber()
    {
        GenerateRandomNumber();
        randomNumberText.text = randomNumber.ToString();
    }

    void CheckGuessedNumber(int guess)
    {
        bool isNatural = IsNaturalNumber(randomNumber);
        bool isWhole = IsWholeNumber(randomNumber);

        if ((guess == 1 && isNatural) || (guess == 2 && isWhole) || (guess == 3 && !isWhole))
        {
            ergebnisText.text = ("Richtig! Die Zahl " + randomNumber + " ist eine " + (isNatural ? "natürliche" : (isWhole ? "ganze" : "Gleitkommazahl")));
        }
        else
        {
            ergebnisText.text = ("Falsch! Die Zahl " + randomNumber + " ist eine " + (isNatural ? "natürliche" : (isWhole ? "ganze" : "Gleitkommazahl")));
        }

        GenerateAndCheckNumber();
    }

    bool IsNaturalNumber(float number)
    {
        return number >= 0 && Mathf.Approximately(number, Mathf.Floor(number));
    }

    bool IsWholeNumber(float number)
    {
        return Mathf.Approximately(number, Mathf.Floor(number));
    }

    void GenerateRandomNumber()
    {
        int a;
        float randomType = UnityEngine.Random.value;

        
        if (randomType < 1f / 3f)
        {
            a = UnityEngine.Random.Range(1, 10);
            randomNumber = a;
        }
        else if (randomType < 2f / 3f)
        {
            randomNumber = UnityEngine.Random.Range(-10f, 10f);
        }
        else
        {
            a = UnityEngine.Random.Range(-10, 10);
            randomNumber = a;
        }
    }
}
