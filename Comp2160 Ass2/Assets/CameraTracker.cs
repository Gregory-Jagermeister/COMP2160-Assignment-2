using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
  public Transform target;
  //public LayerMask groundLayer;
  public float smoothSpeed;
  public Vector3 offset;
  void FixedUpdate()
  {
    // fire a ray at the ground
    // Ray ray = new Ray(target.position, Vector3.down);
    // RaycastHit hit;
    // if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
    // {
    //   // move the pivot to the point it hit
    //   transform.position = hit.point;
    //   Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.white);
    // }

    //transform.position = target.position;
    // Vector3 rot = new Vector3(0, target.rotation.y, 0);

    Vector3 desiredPos = target.position + offset;
    Vector3 vel = Vector3.zero;
    Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.fixedDeltaTime);

    transform.position = smoothedPos;


  }

  private void LateUpdate()
  {
    if (Input.GetKey(KeyCode.E))
    {
      transform.RotateAround(target.position, Vector3.up, smoothSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.Q))
    {
      transform.RotateAround(target.position, -Vector3.up, smoothSpeed * Time.deltaTime);
    }
  }
}
