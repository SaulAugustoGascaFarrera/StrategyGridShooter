using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private GridPosition unitGridPosition;
    [SerializeField] private MoveAction moveAction;
    [SerializeField] private SpinAction spinAction;
    private BaseAction[] baseActionArray;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
        baseActionArray = GetComponents<BaseAction>();
    }


    private void Start()
    {
        unitGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(unitGridPosition, this);
    }

    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != unitGridPosition)
        {
            LevelGrid.Instance.MovedAtGridPosition(unitGridPosition, newGridPosition, this);

            unitGridPosition = newGridPosition;
        }

    }

    public GridPosition GetUnitGridPosition()
    {
        return unitGridPosition;
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {  
        return spinAction;
    }

    public BaseAction[] GetBaseActionArray()
    { 
        return baseActionArray; 
    }


}
