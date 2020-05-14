using Fove.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftEyeScript : MonoBehaviour
{
    private RawImage img;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("texture updating");
        //img.texture = ;
        if(FoveResearch.EyesTexture)
        {
            Debug.Log("is");
        } else
        {
            Debug.Log("is not");
        }
    }
}
