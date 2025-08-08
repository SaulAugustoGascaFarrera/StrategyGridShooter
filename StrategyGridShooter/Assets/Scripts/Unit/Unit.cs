using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private GridPosition unitGridPosition;
    [SerializeField] private MoveAction moveAction;
    [SerializeField] private SpinAction spinAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
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

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {  
        return spinAction;
    }


}
