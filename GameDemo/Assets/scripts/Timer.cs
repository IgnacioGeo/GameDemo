using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeDuration = 3f * 60F;

    [SerializeField]
    private bool countDown = true;

    private float timer;

    public Text firstMinute, secondMinute, separator, firstSecond, secondSecond;

    private float flashTimer;
    private float flashDuration = 1f;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (countDown && timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else if (!countDown && timer < timeDuration)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else
        {
            Flash();
        }

    }

    private void ResetTimer()
    {
        if (countDown)
        {
            timer = timeDuration;
        }
        else
        {
            timer = 0;
        }
        SetTextDisplay(true);

    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if (countDown && timer != 0)
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (!countDown && timer != timeDuration)
        {
            timer = timeDuration;
            UpdateTimerDisplay(timer);
        }

        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }
        else if (flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}

