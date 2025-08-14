using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnSelectMoveUnit;
    public static GameInput Instance {  get; private set; }

    private InputManager inputManager;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);  
            return;
        }

        Instance = this;

        inputManager = new InputManager();

        inputManager.Player.Enable();

        inputManager.Player.SelectMove.performed += SelectMove_performed;
    }


    

    private void SelectMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSelectMoveUnit?.Invoke(this, EventArgs.Empty);
    }

    
}
