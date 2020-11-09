using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
  // Start is called before the first frame update

  private static UIManager instance;

  public static UIManager Instance
  {
    get
    {
      if (instance == null)
      {
        instance = GameObject.FindObjectOfType<UIManager>();
      }
      return instance;
    }
  }

  public Slider healthBar;
  public Text timer;

  public void SetHealthValue(float amount)
  {
    healthBar.value = amount;
  }

  public float GetHealthBarValue()
  {
    return healthBar.value;
  }

  public void SetTimerText(float timeElapsed)
  {
    TimeSpan t = TimeSpan.FromSeconds(timeElapsed);
    String formattedTimeElapsed = string.Format("{0,1:0}:{1,2:00}.{2,3:00}", t.Minutes, t.Seconds, t.Milliseconds);
    timer.text = formattedTimeElapsed;
  }

  public String GetTimerText()
  {
    return timer.text;
  }

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
