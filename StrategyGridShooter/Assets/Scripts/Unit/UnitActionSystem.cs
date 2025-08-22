using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public static UnitActionSystem Instance { get; private set; }
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private bool isBusy;
    private BaseAction selectedAction;

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

        SetSelectedUnit(selectedUnit);
    }


    private void Instance_OnSelectMoveUnit(object sender, EventArgs e)
    {
        if (TryGetSelectedUnit() || isBusy) return;


        //GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMousePosition());

        //if(selectedUnit.GetMoveAction().IsValidActionAtGridPosition(gridPosition))
        //{
        //    selectedUnit.GetMoveAction().TakeAction(gridPosition,ClearBusy);
        //    SetBusy();
        //}

        GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMousePosition());

        if(selectedAction.IsValidActionGridPosition(mouseGridPosition))
        {
            SetBusy();
            selectedAction.TakeAction(mouseGridPosition, ClearBusy);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //if (isBusy) return;

        //if (Input.GetMouseButton(1))
        //{
        //    selectedUnit.GetSpinAction().TakeAction(ClearBusy);
        //    SetBusy();
        //}

    }

    public bool TryGetSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit raycastHit,float.MaxValue,1 << 7))
        {
            if(raycastHit.transform.gameObject.TryGetComponent(out Unit unit))
            {
                if(unit == selectedUnit)
                {
                    //this unit is already selected
                    return false;
                }

                SetSelectedUnit(unit);

                return true;
            }
        }

        return false;
    }


    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

       SetSelectedAction(unit.GetMoveAction());

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetUnitSelected()
    {
        return selectedUnit;
    }

    private void SetBusy()
    {
        isBusy = true;
    }

    private void ClearBusy()
    {
        isBusy = false;
    }


    public void SetSelectedAction(BaseAction baseAction)
    {
        selectedAction = baseAction;
    }

    public BaseAction GetSelectedAction()
    {
        return selectedAction;
    }

}
