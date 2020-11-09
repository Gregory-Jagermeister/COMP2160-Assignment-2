using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
  public float maxSafeThreshold;
  public float maxHurtThreshold;
  private void OnCollisionEnter(Collision other)
  {
    float collisionForce = other.impulse.magnitude / Time.fixedDeltaTime;
    if (collisionForce < maxSafeThreshold)
    {
      return;
    }
    else if (collisionForce < maxHurtThreshold)
    {
      GameManager.Instance.PlayerHurt(collisionForce);
    }
    else
    {
      GameManager.Instance.PlayerDeath();
    }

  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
