using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int wynik = 0;

    public Text score_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wynik = (int)Math.Round(Time.timeSinceLevelLoad, 0);
        
        score_text.text = wynik.ToString();
    }
}
