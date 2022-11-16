using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float WaitSec;
    private float WaitSecFloat;
    public TextMeshProUGUI text;

    private void FixedUpdate()
    {
        if(WaitSec > 00)
        {
            WaitSec -= Time.deltaTime;
            WaitSecFloat = (float)WaitSec;
            text.text = WaitSecFloat.ToString("00");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
