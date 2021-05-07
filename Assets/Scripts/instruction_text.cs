using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instruction_text : MonoBehaviour
{
    public TextMeshProUGUI Instructions;
    public Controls controls;

    // Start is called before the first frame update
    private void Start()
    {
        SetInstructions(controls);
    }
    public void SetInstructions(Controls control)
    {
        Instructions.text =
            "Coat Makers are harvesting Fuzzy's Hair! Help him cross NOMAN's land to live freely with the other bears. " +
            "Press " + control.Jump.ToString() +
            " to jump over puddles, " + control.Roll.ToString() +
            " to roll under bridges and " +control.Shoot.ToString() +
            " to destroy the birds.";
        
    }
}
