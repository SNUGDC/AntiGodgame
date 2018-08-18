using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextControl : MonoBehaviour {

    public float runSpeedByMeterPerSec;

    public Text debugText;
    public Text timerText;
    public Text runMeterText;
    public Text timerDecreaseText;
    public GameObject onHitText;
    public GameObject result;

    private GameControl gc;
    private Character ch;
    private float timer;
    private bool isCreatedText = false;

	// Use this for initialization
	void Start () {
        gc = GetComponent<GameControl>();
        ch = GameObject.Find("Character").GetComponent<Character>();
	}

    // Update is called once per frame
    void Update()
    {
        timer = gc.GetTimer();
        debugText.text = Time.time.ToString();
        timerText.text = "TIMER: " + timer.ToString("N2");
        if (timer > 0)
        {
            runMeterText.text = "RUN: " + (Time.time * runSpeedByMeterPerSec).ToString("N2") + "m";
        }
        if (ch.isHit && !isCreatedText)
        {
            InstantiateText();
        }
        if (!ch.isHit && isCreatedText)
        {
            isCreatedText = false;
        }
        if (GameControl.isGameEnd)
        {
            result.SetActive(true);
        }
    }

    private void InstantiateText()
    {
        isCreatedText = true;
        Instantiate(timerDecreaseText, new Vector3(timerText.transform.position.x - 20.0f, timerText.transform.position.y, 0.0f), Quaternion.identity).rectTransform.SetParent(GameObject.Find("UICanvas").transform);
        Instantiate(onHitText, new Vector3(440.0f, 190.0f, 0.0f), Quaternion.identity).transform.SetParent(GameObject.Find("UICanvas").transform);
    }
}
