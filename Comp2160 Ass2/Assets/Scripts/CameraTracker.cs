using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
  // Used https://www.youtube.com/watch?v=eDlDhzGPeps to help work out the math behind how to achive this
  public GameObject target;
  public float distance = 6.4f;
  public float height = 1.4f;
  public float rotateThreshold = -1.5f;
  public float rotationDamping = 3.0f;
  public float heightDamping = 2.0f;
  public float zoomRatio = 0.5f;
  public float DefaultFOV = 60f;
  private Vector3 rotationVector;
  private Rigidbody rb;
  private Camera camera;

  void Start()
  {
    rb = target.GetComponent<Rigidbody>();
    camera = Camera.main;
  }

  // Update is called once per frame
  void LateUpdate()
  {
    if (target != null)
    {
      float wantedAngle = rotationVector.y;//target.transform.eulerAngles.y;
      float wantedHeight = target.transform.position.y + height;
      float pivotAngle = transform.eulerAngles.y;
      float pivotHeight = transform.position.y;
      pivotAngle = Mathf.LerpAngle(pivotAngle, wantedAngle, rotationDamping * Time.deltaTime);
      pivotHeight = Mathf.Lerp(pivotHeight, wantedHeight, heightDamping * Time.deltaTime);
      Quaternion currentRotation = Quaternion.Euler(0, pivotAngle, 0);
      transform.position = target.transform.position;
      transform.position -= currentRotation * Vector3.forward * distance;
      transform.position = new Vector3(transform.position.x, pivotHeight, transform.position.z);
      transform.LookAt(target.transform);

      Vector3 localVelocity = target.transform.InverseTransformDirection(rb.velocity);
      if (localVelocity.z < rotateThreshold)
      {
        rotationVector.y = target.transform.eulerAngles.y + 180;
      }
      else
      {
        rotationVector.y = target.transform.eulerAngles.y;
      }
      float acc = rb.velocity.magnitude;
      camera.fieldOfView = DefaultFOV + acc * zoomRatio;
    }
  }
}
