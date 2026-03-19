using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionReceiver : MonoBehaviour
{

  float energy = 100;

  private GameObject life_bar;
  private Vector2 original_scale;
  private Vector2 new_scale;

  // Use this for initialization
  void Start ()
  {
    life_bar = GameObject.Find("healthbar");
    original_scale = life_bar.transform.localScale;
    new_scale = original_scale;
  }

  // Update is called once per frame
  void Update ()
  {

  }


  void touched (float val)
  {
    //subtract energy
    energy -= val;

    new_scale.x = original_scale.x * (energy / 100f );

    life_bar.transform.localScale = new_scale;

    print ("I've been touched and my energy is " + energy);
    if (energy <= 0) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }

}