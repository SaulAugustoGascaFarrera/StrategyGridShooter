using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance {  get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if(Physics.Raycast(ray,out RaycastHit raycastHit,float.MaxValue,1 << 6))
        { 
            return raycastHit.point;
        }

        return Vector3.zero;
    }

}
