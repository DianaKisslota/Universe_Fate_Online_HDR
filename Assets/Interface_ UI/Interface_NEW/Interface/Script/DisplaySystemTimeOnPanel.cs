using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplaySystemTimeOnPanel : MonoBehaviour
{
    public Text timeText;  // ������ �� ��������� Text

    void Update()
    {
        // �������� ������� ��������� �����
        DateTime now = DateTime.Now;

        // ����������� ��� ��� ������
        string timeString = now.ToString("HH:mm");

        // ������������� ��������� ��������
        timeText.text = timeString;
    }
}
