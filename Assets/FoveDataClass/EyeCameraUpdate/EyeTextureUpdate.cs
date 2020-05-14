using Fove.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeTextureUpdate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var eyes = GameObject.Find("eyes").GetComponent<RawImage>();

        eyes.texture = FoveResearch.EyesTexture;

    }
}
