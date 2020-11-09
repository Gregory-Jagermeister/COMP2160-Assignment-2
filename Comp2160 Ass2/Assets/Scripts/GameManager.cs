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
  //Time elapsed since scene started.
  public float timeElapsed;
  //Reference to smoke particle system prefab
  public ParticleSystem smokePrefab;
  //Reference to explosion particle system prefab
  public ParticleSystem explosionPrefab;
  //flag to with hold whether the player is lower then 50% of their health.
  private bool isHalfHealth = false;

  public void PlayerHurt(float damage)
  {
    playerHealth -= damage / impactReduction;
  }

  public IEnumerator PlayerDeath()
  {
    Destroy(player.gameObject);
    ParticleSystem explosion = Instantiate(explosionPrefab, player.position, Quaternion.identity);
    explosion.Play();
    Debug.Log(explosion.main.duration);
    yield return new WaitForSeconds(explosion.main.duration);
    PlayerHealthRestored();
  }

  public void PlayerHealthRestored()
  {
    playerHealth += healthRestored;
  }

  // Update is called once per frame
  void Update()
  {
    timeElapsed += Time.deltaTime;
    UIManager.Instance.SetTimerText(timeElapsed);
    UIManager.Instance.SetHealthValue(playerHealth);
    if (playerHealth <= 0.1 && player != null)
    {
      playerHealth = 0;
      StartCoroutine(PlayerDeath());
    }
    else if (playerHealth <= 50 && !isHalfHealth)
    {
      ParticleSystem smoke = Instantiate(smokePrefab, player);
      smoke.Play();
      isHalfHealth = true;
    }
  }
}
