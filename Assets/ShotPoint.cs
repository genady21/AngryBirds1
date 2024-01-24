using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotPoint : MonoBehaviour
{
  [SerializeField] private float maxDistance = 3;
  private Vector2 startPoint;
  
  public UnityEvent<Vector2> onRelease;
  private Camera camera;

  private void Start()
  {
    startPoint = transform.position;
    camera = Camera.main;
  }

  private void OnMouseDrag()
  {
    
    Vector2 mousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
    

    if (Vector3.Distance(startPoint, mousPosition) < maxDistance)
    {
      transform.position = mousPosition;
    }
    else
    {
      var direction = (mousPosition - startPoint).normalized * maxDistance;
      transform.position = startPoint + direction;
    }
  }

  private void OnMouseUp()
  {
    Vector2 releasePosition = transform.position;
    transform.position = startPoint;

    Vector2 delta = releasePosition - startPoint;

    onRelease?.Invoke(delta.normalized * (delta.magnitude / maxDistance));
  }
}


