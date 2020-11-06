using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody rb;
  public float thrust;

  public float angle;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {


    float moveDir = Input.GetAxisRaw("Vertical");
    //rb.MovePosition(transform.position + (transform.forward * (moveDir * thrust)) * Time.fixedDeltaTime);
    rb.AddForce(transform.forward * (moveDir * thrust), ForceMode.VelocityChange);
    //rb.velocity = new Vector3(0, rb.velocity.y, thrust * moveDir);

    float rotDir = Input.GetAxisRaw("Horizontal");
    Vector3 EulerAngleVelocity = new Vector3(0, angle, 0);

    Quaternion deltaRot;

    if (moveDir != 0)
    {
      if (moveDir > 0)
      {
        deltaRot = Quaternion.Euler((EulerAngleVelocity * rotDir) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
      }
      else
      {
        deltaRot = Quaternion.Euler((EulerAngleVelocity * -rotDir) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
      }
    }


  }
}
