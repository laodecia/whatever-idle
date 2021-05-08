using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    public static Action OneSecondChanged;
    public static Action OneMinuteChanged;
    public static Action OneHourChanged;
    
    public static int Second { get; private set; }
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    [Range(0.1f,2f)]
    public float TimeScale = 1f;
    private float timer;

    private void Start()
    {

    }

    private void Awake()
    {
        timer = TimeScale;
        Second = 30;
        Minute = 57;
        Hour = 12;

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Second++;
            if(Second >= 60)
            {
                Second = 00;
                Minute++;
                if (Minute >= 60)
                {
                    Minute = 00;
                    Hour++;
                    if (Hour >= 13) Hour = 1;
                    OneHourChanged?.Invoke();
                }
                OneMinuteChanged?.Invoke();
            }
            OneSecondChanged?.Invoke();
                        
            //revist
            //without + timer, i'm missing out on time that might have been beyond the time.
            //like there could have been an extra .4F out there that i'm not accounting for.
            timer = TimeScale + timer;
        }
    }
}
