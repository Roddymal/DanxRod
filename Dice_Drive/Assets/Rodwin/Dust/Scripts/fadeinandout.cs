using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeinandout : MonoBehaviour {
    public Image fade;
    public float fadeSpeed = .1f;
    public bool isBegining = true;
    public Color Solid;
    public Color Transparent;
    float percentile ;

    // Use this for initialization
    void Start () {
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b,255);
        percentile = fade.color.a;
    }

    // Update is called once per frame
    void Update () {
		if(isBegining && (fade.color.a != Transparent.a))
        {
            FadeIn();
        }
        if (isBegining == false && (fade.color.a != Solid.a))
        {
            FadeOut();
        }
    }


    void FadeIn()
    {
       if (fade.color.a > Transparent.a)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a - (percentile*fadeSpeed ));
       
        }
        return;
    }

    void FadeOut()
    {
        if (fade.color.a < Solid.a)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + (percentile * fadeSpeed));
        }
        return;
    }

}
