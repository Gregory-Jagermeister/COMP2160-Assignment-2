using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
  // Start is called before the first frame update
  protected Rigidbody rb;
  public Vector3 centreMass;
  public float maxSpeed;
  public float accel;
  private float speed;
  public float angle;
  public float groundThreshold;

  public LayerMask groundLayer;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame

  private bool IsGrounded()
  {
    Ray ray = new Ray(transform.position, Vector3.down);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer) && (hit.distance <= groundThreshold))
    {
      Debug.Log("Ground Hit");
      Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.white);
      return true;
    }
    else
    {
      Debug.Log("ground Not hit");
      Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.white);
      return false;

    }
  }

  void FixedUpdate()
  {
    if (IsGrounded())
    {
      DriveController();
    }
  }

  private void DriveController()
  {
    rb.centerOfMass = centreMass;
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
    float speedAdjustment = speed - transform.InverseTransformDirection(rb.velocity).z;
    float sideSpeedAdjustment = -transform.InverseTransformDirection(rb.velocity).x;
    rb.AddRelativeForce(sideSpeedAdjustment, 0f, speed + speedAdjustment, ForceMode.Acceleration);

    Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);

    Quaternion deltaRot;

    if (moveDir != 0)
    {
      if (moveDir > 0)
      {
        deltaRot = Quaternion.Euler((eulerAngleVelocity * rotDir) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
      }
      else
      {
        deltaRot = Quaternion.Euler((eulerAngleVelocity * -rotDir) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
      }
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawSphere(transform.position + transform.rotation * centreMass, 1f);
  }
}
