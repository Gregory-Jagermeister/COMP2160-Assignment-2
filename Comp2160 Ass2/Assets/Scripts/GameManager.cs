using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
  // ------------------------------- SINGLETON SET UP ---------------------//
  private static GameManager instance;

  public static GameManager Instance
  {
    get
    {
      if (instance == null)
      {
        instance = GameObject.FindObjectOfType<GameManager>();
      }
      return instance;
    }
  }
  // ------------------------------- SINGLETON SET UP ---------------------//

  //refence to the player.
  public Transform player;
  //variable to track player health.
  public float playerHealth = 100F;
  //health restored on checkpoint entry.
  public float healthRestored;
  // value to contain the dampen the damage sent based on collision impluse;
  public float impactReduction;

  public void PlayerHurt(float damage)
  {
    playerHealth -= damage / impactReduction;
  }

  public void PlayerDeath()
  {
    Destroy(player.gameObject);
    UIManager.Instance.SetHealthValue(0F);
  }

  public void PlayerHealthRestored()
  {
    playerHealth += healthRestored
  }

  // Update is called once per frame
  void LateUpdate()
  {
    UIManager.Instance.SetHealthValue(playerHealth);
    if (playerHealth <= 0 && player != null)
    {
      PlayerDeath();
    }
  }
}
