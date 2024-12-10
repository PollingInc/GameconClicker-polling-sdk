using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using System.Linq;

public class InputLockButton : MonoBehaviour
{
    public Button targetButton;
    public List<TMP_InputField> inputs;
    private List<TMP_InputField> optionalInputs;

    private Dictionary<TMP_InputField, bool> checkedInputs;



    public void Changed(TMP_InputField input)
    {
        if (inputs.Contains(input))
        {
            checkedInputs[input] = true;
            Check();
        }
    }




    void Awake()
    {
        targetButton.enabled = false;

        foreach(var input in inputs)
        {
            checkedInputs.Add(input, !string.IsNullOrEmpty(input.text));
        }

        Check();
    }


    private void Check()
    {
        if(checkedInputs.Where(c => c.Value).Count() == checkedInputs.Count())
        {
            targetButton.enabled = true;
        }

    }


}
