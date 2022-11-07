using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public static int _ammo;
    public TextMeshProUGUI ammoDisplay;
    void Start()
    {
        _ammo = 5;
    }

    void Update()
    {
        ammoDisplay.text = _ammo.ToString();
    }
}
