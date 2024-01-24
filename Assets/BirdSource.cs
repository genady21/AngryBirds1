using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSource : MonoBehaviour
{
   [SerializeField] private Bird birdPref;

   public Bird GitBird()
   {
      return Instantiate(birdPref, transform.position, Quaternion.identity);
   }
      
}
