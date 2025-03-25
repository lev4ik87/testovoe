using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class InputController : MonoBehaviour
{
 
    [SerializeField] private InputActionReference OneTapEvent;

    public static event Action OnOneTap;

    private void OnEnable()
    {    
        OneTapEvent.action.started += OneTap;
    }
    private void OnDisable()
    {
        OneTapEvent.action.started -= OneTap;
    }



    public void OneTap(InputAction.CallbackContext context)
    {
        OnOneTap?.Invoke();
    }
}
