using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	public float offset = 16f;

	private bool offscreen;

	private float offscreenY = 0;
	private Rigidbody2D body2d;

	void Awake() {
		body2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		offscreenY = (Screen.height / 2) + offset;
		print (offscreenY);

	}

	// Update is called once per frame
	void Update () {
		var posY = transform.position.y;
		var dirY = body2d.linearVelocity.y;

		if (Mathf.Abs (posY) > offscreenY) {
			if (dirY < 0 && posY < -offscreenY) {
				offscreen = true;
			} else if (dirY > 0 && posY > offscreenY) {
				offscreen = true;
			}
		} else {
			offscreen = false;
		}

		if (offscreen) {
			OnOutOfBounds ();
		}

	}

	public void OnOutOfBounds() {
		offscreen = false;
		Destroy (gameObject);
	}
}