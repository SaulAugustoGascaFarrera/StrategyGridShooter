using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    [SerializeField] private Transform debugGridObjectTransform;
    private GridSystem gridSystem;
    private void Awake()
    {
        gridSystem = new GridSystem(10, 10, 2);
        gridSystem.GridDebugObject(debugGridObjectTransform);

        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }


    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public GridObject GetGridObject(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition);
    public int GetWidth() => gridSystem.GetWidth();

    public int GetHeight() => gridSystem.GetHeight();

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);


    public void AddUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public bool HasAnyUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        return  gridObject.HasAnyUnit();
    }


}
