using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
  public Transform target;
  public LayerMask groundLayer;
  void LateUpdate()
  {
    // fire a ray at the ground
    Ray ray = new Ray(target.position, Vector3.down);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
    {
      // move the pivot to the point it hit
      transform.position = hit.point;
      Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.white);
    }
  }
}
