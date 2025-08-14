using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public static UnitActionSystem Instance { get; private set; }
    [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnSelectMoveUnit += Instance_OnSelectMoveUnit;
    }

    private void Instance_OnSelectMoveUnit(object sender, EventArgs e)
    {
        if (TryGetSelectedUnit()) return;


        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMousePosition());


        if(LevelGrid.Instance.IsValidGridPosition(gridPosition))
        {
            selectedUnit.GetMoveAction().Move(gridPosition);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    TryGetSelectedUnit();
        //}
        
    }

    public bool TryGetSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit raycastHit,float.MaxValue,1 << 7))
        {
            if(raycastHit.transform.gameObject.TryGetComponent(out Unit unit))
            {

                SetSelectedUnit(unit);

                return true;
            }
        }

        return false;
    }


    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetUnitSelected()
    {
        return selectedUnit;
    }

}
