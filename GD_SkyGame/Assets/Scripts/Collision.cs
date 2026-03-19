using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter2D (Collision2D coll)
  {
    if (coll.gameObject.tag == "Player") {
      Debug.Log("HIT HIT HIT");
      //if I have a reference to a specific object I can call a method (function attached) on it
      //so I don't have to detect the collision on the other object as well
      coll.gameObject.SendMessage ("touched", 10);
    }
    Destroy (gameObject);

  }
}