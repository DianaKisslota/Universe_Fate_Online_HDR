using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplaySystemTimeOnPanel : MonoBehaviour
{
    public Text timeText;  // Ссылка на компонент Text

    void Update()
    {
        // Получаем текущее системное время
        DateTime now = DateTime.Now;

        // Форматируем его как строку
        string timeString = now.ToString("HH:mm");

        // Устанавливаем текстовое значение
        timeText.text = timeString;
    }
}
