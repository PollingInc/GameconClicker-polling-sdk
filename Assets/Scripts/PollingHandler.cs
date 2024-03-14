using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polling;

public class PollingHandler : MonoBehaviour
{

    public Animator pollingButton;

    public string customerId;
    private string apiKey;
    Survey survey;


    public void InfoSetup()
    {
        customerId = Random.Range(1, 1000).ToString();
        apiKey = "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a";
    }

    public void ToggleButton()
    {
        pollingButton.SetBool("toggle", !pollingButton.GetBool("toggle"));
    }

    void Start()
    {
        InfoSetup();

        Identifier request = new Identifier(customerId, apiKey);
        CallbackHandler callbacks = new(this.gameObject, OnSuccess, OnFailure);

        survey = new Survey(request, callbacks);
    }


    private void OnSuccess(string response)
    {
        Debug.Log("SUCCESS: " + response);
    }

    private void OnFailure(string error)
    {
        Debug.Log("ERROR: " + error);
    }


    public void AvailableSurveysApi()
    {
        survey.AvailableSurveys();
    }
    public void PopupSurveyBottom()
    {
        survey.AvailableSurveys(ViewType.Bottom);
    }
    public void PopupSurveyDialog()
    {
        survey.AvailableSurveys(ViewType.Dialog);
    }
}
