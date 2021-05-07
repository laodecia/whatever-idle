using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{

    public TextMeshProUGUI TimeText;

    private void OnEnable(){TimeManager.OneSecondChanged += UpdateTime;}
    private void OnDisable(){TimeManager.OneSecondChanged -= UpdateTime;}

    void UpdateTime()
    {
        TimeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}:{TimeManager.Second:00}";
    }
}
