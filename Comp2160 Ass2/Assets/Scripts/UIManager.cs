using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
