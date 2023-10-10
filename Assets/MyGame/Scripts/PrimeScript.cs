using System.Collections;
using UnityEngine;
using TMPro;

public class PrimeScript : MonoBehaviour
{
    bool mode1Active = true;
    bool mode2Active = false;
    int randomNumber;

    public TextMeshProUGUI randomNumberText1;
    public TextMeshProUGUI checkText1;
    public TextMeshProUGUI checkText2;
    public TMP_InputField input2;
    
    public GameObject mode1Package;
    public GameObject mode2Package;
    

    private void Start()
    {
        mode2Package.SetActive(false);
        mode1Package.SetActive(true);
        checkText1.text = "New Game";
        Mode1Random();
    }

    private void Mode1Random()
    {
        randomNumber = Random.Range(1, 100);
        randomNumberText1.text = randomNumber.ToString();
    }

    public void Mode1Check(bool a)
    {
        IsPrime(randomNumber);

        if (IsPrime(randomNumber) == a)
        {
            checkText1.text = "Correct Answer";
        }
        else
        {
            checkText1.text = "Wrong Answer. Try again";
        }

        StartCoroutine(Waiter());
    }





    public void Mode2Check()
    {
        int parsedInt;
        int.TryParse(input2.text, out parsedInt);

        IsPrime(parsedInt);

        if (IsPrime(parsedInt) == true)
        {
            checkText2.text = "Super, das ist eine Primzahl!";
        }
        else
        {
            checkText2.text = "Das ist leider keine Primzahl.";
        }
    }

    public void ChangeMode()
    {
        mode1Active = !mode1Active;
        mode2Active = !mode2Active;

        if (mode1Active)
        {
            mode2Package.SetActive(false);
            mode1Package.SetActive(true);
            checkText1.text = "New Game";
            Mode1Random();
        }
        else if (mode2Active)
        {
            mode1Package.SetActive(false);
            mode2Package.SetActive(true);
            checkText2.text = "Finde eine neue Primzahl";
        }
    }

    bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        if (number <= 3)
        {
            return true;
        }

        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3);


        if (mode1Active)
        {
            checkText1.text = "New Game";
            Mode1Random();
        }
        else if (mode2Active)
        {
            checkText2.text = "Finde eine neue Primzahl";
            Mode2Check();
        }
    }
}
