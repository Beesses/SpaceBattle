using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public float ScoreValue = 0;
    private Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        MyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MyText.text = "Score: " + ScoreValue;
    }
}
