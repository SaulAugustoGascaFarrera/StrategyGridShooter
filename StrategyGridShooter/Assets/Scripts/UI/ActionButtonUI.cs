using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txtMeshPro;
    [SerializeField] private Button button;
 
    public void SetBaseAction(BaseAction baseAction)
    {
        txtMeshPro.text = baseAction.GetActionName().ToUpper(); 
    }
}
