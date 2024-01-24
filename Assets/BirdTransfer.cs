using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



[Serializable]
public class BirdTransfer
{
  [SerializeField] private float animationDuration = 1f;
  [SerializeField] private float animationForce = 2f;

  public IEnumerator TransferBird(Bird bird, Vector3 target)
  {
    yield return bird.transform.DOJump(target, animationForce, 1,animationDuration).WaitForCompletion();
  }
}
