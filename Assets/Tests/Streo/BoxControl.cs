using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxControl : MonoBehaviour
{
    bool inside = false;

    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().enabled)
        {
            return;
        }
        var positionX = transform.position.x;
        var positionY = transform.position.y;
        
        var StreoRedBar = GameObject.Find("StreoRedBar");
        var barX = StreoRedBar.transform.position.x;
        var barY = StreoRedBar.transform.position.y;

        var gap = 0.6;
        if (positionX - gap < barX && positionX + gap > barX && positionY - gap < barY && positionY + gap > barY)
        {
            inside = true;
            GetComponent<Renderer>().material.color = Color.red;
        } else
        {
            inside = false;
            GetComponent<Renderer>().material.color = Color.white;
        }

        if (inside && Input.GetKeyDown("k"))
        {
            var streoMainScript = GameObject.Find("Streoscopic").GetComponent<StreoTestScript>();
            streoMainScript.setBlocks();
        }
        
    }

}
