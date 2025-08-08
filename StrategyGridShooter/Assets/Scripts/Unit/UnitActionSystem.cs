using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Unit GetUnitSelected()
    {
        return selectedUnit;
    }

}
