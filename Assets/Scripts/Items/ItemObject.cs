using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private Rigidbody RigidBody
    {
        get
        {
            if ( _rigidBody == null )
                _rigidBody = GetComponent<Rigidbody>();
            return _rigidBody;
        }
    }
    public Item Item {  get; set; }
    public GameObject Light {  get; set; }

    private bool _isFree  = true;


    private void Start()
    {
        Light.SetActive(false);
    }

    public void Drop()
    {
        _isFree = true;
        SetKinematic(false);
    }

    public void Take()
    {
        _isFree = false;
        LightOff();
        SetKinematic(true);
    }

    public void SetKinematic(bool kinematic)
    {
        RigidBody.isKinematic = kinematic;
    }

    public void LightOff()
    {
        Light.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (_isFree)
            Light.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (_isFree)
            Light.SetActive(false);
    }
}
