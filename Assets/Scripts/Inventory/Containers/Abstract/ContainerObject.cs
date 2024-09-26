using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerObject : MonoBehaviour
{
    public Container Container {  get; set; }

    public GameObject Light { get; set; }

    private void Start()
    {
        Light.SetActive(false);
    }

    public void LightOff()
    {
        Light.SetActive(false);
    }

    private void OnMouseOver()
    {
        Light.SetActive(true);
    }

    private void OnMouseExit()
    {
        Light.SetActive(false);
    }

    public void ShowSelf(bool show)
    {
        gameObject.SetActive(show);
    }

    public void CheckVisibility()
    {
        if (Container.IsEmpty && Container.DeleteOnEmpty)
        {
            ShowSelf(false);
        }
    }

}
