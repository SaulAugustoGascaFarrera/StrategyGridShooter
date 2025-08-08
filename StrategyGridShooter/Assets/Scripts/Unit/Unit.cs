using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private GridPosition unitGridPosition;

    private void Awake()
    {
        
    }


    private void Start()
    {
        unitGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(unitGridPosition, this);
    }

    public GridPosition GetUnitGridPosition()
    {
        return unitGridPosition;
    }

}
