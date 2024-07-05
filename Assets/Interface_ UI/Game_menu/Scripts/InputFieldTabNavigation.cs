using UnityEngine;
using TMPro; // ����������� ������������ ���� ��� ���������� TMP_InputField �� TextMeshPro

public class InputFieldTabNavigation : MonoBehaviour
{
    public TMP_InputField[] inputFields; // ���������� TMP_InputField ������ InputField

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
