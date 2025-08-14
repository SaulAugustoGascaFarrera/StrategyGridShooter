using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainerTransform;

    // Start is called before the first frame update
    void Start()
    {
        CreateUnitActionButtons();
    }

    private void CreateUnitActionButtons()
    {
        foreach (Transform buttonTransform in actionButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        Unit selectedUnit = UnitActionSystem.Instance.GetUnitSelected();

        foreach(BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);

            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();

            actionButtonUI.SetBaseAction(baseAction);
        }

    }
}
