using UnityEngine;
using TMPro; // Импортируем пространство имен для компонента TMP_InputField из TextMeshPro

public class InputFieldTabNavigation : MonoBehaviour
{
    public TMP_InputField[] inputFields; // Используем TMP_InputField вместо InputField

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SelectNextInputField();
        }
    }

    void SelectNextInputField()
    {
        for (int i = 0; i < inputFields.Length; i++)
        {
            if (inputFields[i].isFocused)
            {
                int nextIndex = (i + 1) % inputFields.Length;
                inputFields[nextIndex].Select();
                break;
            }
        }
    }
}
