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
    if (coll.gameObject.tag == "player") {
      Debug.Log("HIT HIT HIT");
      if (gameObject.tag != "friend") {
        //if I have a reference to a specific object I can call a method (function attached) on it
        //so I don't have to detect the collision on the other object as well
        coll.gameObject.SendMessage ("touched", 10);

        //destroy bill
        //Destroy (gameObject);
      } else {
        coll.gameObject.SendMessage ("increase_score", 10);
      }
    }

  }
}