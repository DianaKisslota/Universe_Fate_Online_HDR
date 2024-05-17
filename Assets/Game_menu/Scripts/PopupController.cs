using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject staticWindow;
    public AudioSource popupSound;

    // ¬ызываетс€ при нажатии на UI кнопку дл€ открыти€ или закрыти€ всплывающего окна
    public void TogglePopup()
    {
        if (popupWindow != null)
        {
            bool newState = !popupWindow.activeSelf; // Ќовое состо€ние всплывающего окна

            popupWindow.SetActive(newState);

            // ≈сли всплывающее окно открыто, закрываем статическое окно
            if (newState && staticWindow != null)
            {
                staticWindow.SetActive(false);
            }
            // ≈сли всплывающее окно закрыто, открываем статическое окно
            else if (!newState && staticWindow != null)
            {
                staticWindow.SetActive(true);
            }

            // ¬оспроизводим звук при открытии всплывающего окна
            if (newState && popupSound != null)
            {
                popupSound.Play();
            }
        }
    }

    void Update()
    {
        // ѕровер€ем нажатие на клавишу Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ≈сли всплывающее окно открыто, закрываем его
            if (popupWindow.activeSelf)
            {
                TogglePopup();
            }
            // ≈сли всплывающее окно закрыто, открываем его
            else
            {
                TogglePopup();
            }
        }
    }
}
