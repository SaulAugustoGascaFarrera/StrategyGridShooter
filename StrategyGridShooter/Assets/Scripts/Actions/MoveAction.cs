using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{

    [SerializeField] private float movementSpeed = 6.5f;
    [SerializeField] private float rotationSpeed = 8.0f;
    [SerializeField] private float distanceToMove = 0.2f;
    [SerializeField] private int maxMoveDistance = 1;
    private Vector3 targetPosition;


    public override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    private void Update()
    {
        Vector3 moveDiretion = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(targetPosition,transform.position) > distanceToMove)
        {
            
            transform.position += moveDiretion * movementSpeed * Time.deltaTime;

           
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDiretion, rotationSpeed * Time.deltaTime);
    }


    public void Move(GridPosition gridPosition)
    {
        Debug.Log($"Unit Moved at: {gridPosition}");

        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


    public override string GetActionName()
    {
        return "Move";
    }


    public bool IsValidActionAtGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionAtGridPosition();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionAtGridPosition()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetUnitGridPosition();
        

        for(int x=-maxMoveDistance;x<=maxMoveDistance;x++)
        {
            for(int z=-maxMoveDistance;z<=maxMoveDistance;z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);

                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                {
                    continue;
                }


                if(unitGridPosition == testGridPosition)
                {
                    continue;
                }


                validGridPositionList.Add(testGridPosition);
            }
        }


        return validGridPositionList;
    }
    
}
