using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] private float totalSpinAmount = 0;

    [SerializeField] float spinAddAmount;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        spinAddAmount = 360.0f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        totalSpinAmount += spinAddAmount;

        if (totalSpinAmount >= 360.0f)
        {
            totalSpinAmount = 0.0f;
            isActive = false;
            onActionComplete();
        }

    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }
    public override List<GridPosition> GetValidActionAtGridPosition()
    {
       

        GridPosition unitGridPosition = unit.GetUnitGridPosition();

        return new List<GridPosition> { unitGridPosition };
    }

}
