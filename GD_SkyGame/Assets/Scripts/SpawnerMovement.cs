using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour {
  public Rigidbody2D rb;
  public float speed = 10;
  Vector2 vel;

  public float overflow = .05f; //<<<<<REMEMBER THE STUPID f

  // Use this for initialization
  void Start () {
    vel = rb.linearVelocity;

    vel.x = speed;

    rb.linearVelocity = vel;
  }

  // Update is called once per frame
  void Update () {
    var cam = Camera.main;
    var viewportPosition = cam.WorldToViewportPoint(transform.position);
    //new position is the current position in case nothing changes
    var newPosition = viewportPosition;

    if (viewportPosition.x > 1 + overflow)
    newPosition.x = 0 - overflow;
    if (viewportPosition.x < 0 - overflow)
    newPosition.x = 1 + overflow;

    transform.position = cam.ViewportToWorldPoint(newPosition);
  }
}