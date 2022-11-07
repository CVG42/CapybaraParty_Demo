using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int _score;
    public TextMeshProUGUI scoreDisplay;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        scoreDisplay.text = _score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Orange"))
        {
            _score++;
        }
    }
}
