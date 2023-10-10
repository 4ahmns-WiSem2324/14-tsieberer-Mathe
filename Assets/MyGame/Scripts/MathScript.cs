using UnityEngine;
using TMPro;

public class MathScript : MonoBehaviour
{
    int input1;
    int input2;
    
    public TextMeshProUGUI outputText;
    public TMP_InputField field1;
    public TMP_InputField field2;

    private void Start()
    {
        outputText.text = "Bitte wählen Sie eine Eingabe";
    }

    public void Calculation(int a)
    {
        int.TryParse(field1.text, out input1);
        int.TryParse(field2.text, out input2);

        if (a == 1)
        {
            outputText.text = (input1 + input2).ToString();
        }
        else if (a == 2)
        {
            outputText.text = (input1 - input2).ToString();
        }
        else if (a == 3)
        {
            outputText.text = (input1 * input2).ToString();
        }
        else if (a == 4 && input2 != 0)
        {
            outputText.text = (input1 / input2).ToString();
        }
        else
        {
            outputText.text = "Keine gültige Eingabe";
        }
    }

}
