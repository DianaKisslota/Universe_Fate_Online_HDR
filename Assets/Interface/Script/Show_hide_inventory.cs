using UnityEngine;

public class Show_hide_inventory : MonoBehaviour
{
    public static Show_hide_inventory Instance;

    public GameObject panel; // ѕанель, которую нужно открыть/закрыть

    private void Awake()
    {
        // ќбеспечиваем, что экземпл€р менеджера единственный
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ћетод дл€ переключени€ видимости панели
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
