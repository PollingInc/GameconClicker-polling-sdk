using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using System.Linq;

public class InputLockButton : MonoBehaviour
{
    public Button targetButton;
    public List<TMP_InputField> exclusiveInputs;

    private Dictionary<TMP_InputField, bool> checkedInputs;



    public void Changed(TMP_InputField input)
    {
        if (exclusiveInputs.Contains(input))
        {
            checkedInputs[input] = !string.IsNullOrEmpty(input.text);
            Check();
        }
    }




    void Awake()
    {
        checkedInputs = new();

        targetButton.interactable = false;
        

        foreach(var input in exclusiveInputs)
        {
            checkedInputs.Add(input, !string.IsNullOrEmpty(input.text));
        }

        Check();
    }


    private void Check()
    {
        if(checkedInputs.Where(c => c.Value).Count() == checkedInputs.Count())
        {
            targetButton.interactable = true;
        }

    }


}
