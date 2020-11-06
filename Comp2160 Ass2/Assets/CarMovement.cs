using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody rb;
  public float thrust;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    float moveDir = Input.GetAxisRaw("Vertical");
    rb.AddForce(transform.forward * (moveDir * thrust));
  }
}
