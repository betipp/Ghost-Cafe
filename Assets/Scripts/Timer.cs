using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image uiFill;
    [SerializeField] private UnityEngine.UI.Image uiClock;
    [SerializeField] private TMPro.TextMeshProUGUI uiText;

    public int Duration;
    public int remainingDuration;

    public bool Pause;

    bool isFreePlayEnabled = true;

    public IEnumerator currentCoroutine;

    void Start()
    {

        isFreePlayEnabled = PlayerPrefs.GetString("isFreePlayEnabled") == "True";
        if (isFreePlayEnabled)
        {
            uiFill.enabled = false;
            uiClock.enabled = false;
            uiText.enabled = false;
        }
        else
        {
            Being(Duration);
        }

    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        currentCoroutine = UpdateTimer();
        StartCoroutine(currentCoroutine);

    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }

        }
        OnEnd();
    }

    private void OnEnd()
    {
        this.GetComponent<DeskBell>().forceNewTask();
        Being(Duration);
    }





}
