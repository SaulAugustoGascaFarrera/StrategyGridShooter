using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;


    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;

        unitList = new List<Unit>();
    }


    public override string ToString()
    {
        string unitString = "";

        if (HasAnyUnit())
        {
            
            foreach(Unit unit in unitList)
            {
                unitString += unit.ToString() + "\n";
            }

            return gridPosition.ToString() + "\n" + unitString;

        }


        return gridPosition.ToString();
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public bool HasAnyUnit()
    { 
        return unitList.Count > 0;
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }


    


}
