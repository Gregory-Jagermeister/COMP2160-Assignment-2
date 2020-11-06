using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody rb;
  public float maxSpeed;
  public float accel;
  private float speed;
  public float angle;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {


    float moveDir = Input.GetAxis("Vertical");
    float rotDir = Input.GetAxis("Horizontal");
    if (moveDir > 0)
    {
      if (speed < maxSpeed) speed += accel;
    }
    else if (moveDir < 0)
    {
      if (speed > -maxSpeed) speed -= accel;
    }
    else
    {
      if (speed > -.1f && speed < .1f) speed = 0f;
      if (speed != 0f) speed = speed * 0.9f;
    }

    Mathf.Clamp(speed, -maxSpeed, maxSpeed);
    Vector3 currentVelocityVector = transform.InverseTransformDirection(rb.velocity);
    currentVelocityVector.z = speed;
    currentVelocityVector.x = 0f;

    rb.velocity = transform.TransformDirection(currentVelocityVector);

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
