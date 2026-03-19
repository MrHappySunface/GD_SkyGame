using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI GameTime;
    private float startTime;
    private bool finished = false;

    private float totalTime = 20;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
      startTime = Time.time;
      panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if (finished) return;

      float t = totalTime - (Time.time - startTime); //total minus elapsed time

      //https://www.youtube.com/watch?v=x-C95TuQtf0

      if (t <= 0) Finish();

      if (t < 0) t = 0; //make sure time is never below 0
      string minutes = ((int) t / 60).ToString();
      string seconds = (t % 60).ToString("f2");

      GameTime.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
      finished = true;
      Debug.Log("GAME OVER");
      panel.SetActive(true);

      GameObject.Find("hero").SetActive(false);
    }
}