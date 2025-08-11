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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateUnitActionButtons()
    {
        foreach (Transform buttonTransform in actionButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        Unit selectedUnit = UnitActionSystem.Instance.GetUnitSelected();
    }
}
