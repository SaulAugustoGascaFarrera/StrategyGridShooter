using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro txtMeshPro;
    private GridObject gridObject;
    
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    // Update is called once per frame
    void Update()
    {
        txtMeshPro.text = gridObject.ToString();
    }
}
