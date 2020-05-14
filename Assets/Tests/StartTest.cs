using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTest : MonoBehaviour
{
    string getTestName = "";
    float interval = 0f;
    bool onTimmer = false;
    public void endTests()
    {
        Debug.Log("endedit");

        var foveCamera = GameObject.Find("Fove Rig");
        //foveCamera.transform.Translate(new Vector3(0, 0, -3f));
        var target = new Vector3(0, 0, 0);
        foveCamera.transform.position = target;

        var introMessage = GameObject.Find("Intro.message");
        introMessage.GetComponent<Renderer>().enabled = true;

        var StreoRedBar = GameObject.Find("StreoRedBar");
        StreoRedBar.GetComponent<Renderer>().enabled = false;

        var streoIntro = GameObject.Find("Streo intro");
        streoIntro.GetComponent<Renderer>().enabled = false;

        var box1 = GameObject.Find("StreoBox1");
        box1.GetComponent<Renderer>().enabled = false;

        var box2 = GameObject.Find("StreoBox2");
        box2.GetComponent<Renderer>().enabled = false;

        var box3 = GameObject.Find("StreoBox3");
        box3.GetComponent<Renderer>().enabled = false;

        var box4 = GameObject.Find("StreoBox4");
        box4.GetComponent<Renderer>().enabled = false;

        var BoxCover = GameObject.Find("BoxCover");
        BoxCover.GetComponent<Renderer>().enabled = false;

        var TestStatusText = GameObject.Find("TestStatusText");
        TestStatusText.GetComponent<Text>().text = "검사 준비중";


        getTestName = "";


    }
    public void testStart_streo()
    {
        if (getTestName != "")
        {
            return;
        }

        var foveCamera = GameObject.Find("Fove Rig");
        //foveCamera.transform.Translate(new Vector3(0, 0, -3f));
        var target = new Vector3(0, 0, 4f);
        foveCamera.transform.position = target;

        var introMessage = GameObject.Find("Intro.message");
        introMessage.GetComponent<Renderer>().enabled = false;

        var StreoRedBar = GameObject.Find("StreoRedBar");
        StreoRedBar.GetComponent<Renderer>().enabled = true;

        var streoIntro = GameObject.Find("Streo intro");
        streoIntro.GetComponent<TextMesh>().text = "방향키로 바를 움직여\n조금 더 앞으로 튀어나와있는 블럭에서\nk를 눌러 선택하세요";
        streoIntro.GetComponent<Renderer>().enabled = true;

        var streoConter = GameObject.Find("Streo Counter");
        streoConter.GetComponent<Renderer>().enabled = true;
        streoConter.GetComponent<TextMesh>().text = "5";


        var TestStatusText = GameObject.Find("TestStatusText");
        TestStatusText.GetComponent<Text>().text = "검사중 0/10 SUC: 0";

        onTimmer = true;
        interval = 0;
        getTestName = "streo";

    }

    private void Update()
    {
        if (!onTimmer)
        {
            return;
        }
        interval += 1;
        switch (getTestName)
        {
            case "streo":
                if (interval > 5 * 60)
                {
                    onTimmer = false;

                    var streoIntro = GameObject.Find("Streo intro");
                    streoIntro.GetComponent<Renderer>().enabled = false;
                    var streoConter = GameObject.Find("Streo Counter");
                    streoConter.GetComponent<Renderer>().enabled = false;

                    var box1 = GameObject.Find("StreoBox1");
                    box1.GetComponent<Renderer>().enabled = true;

                    var box2 = GameObject.Find("StreoBox2");
                    box2.GetComponent<Renderer>().enabled = true;

                    var box3 = GameObject.Find("StreoBox3");
                    box3.GetComponent<Renderer>().enabled = true;

                    var box4 = GameObject.Find("StreoBox4");
                    box4.GetComponent<Renderer>().enabled = true;

                    var streoMainScript = GameObject.Find("Streoscopic").GetComponent<StreoTestScript>();
                    streoMainScript.initDatas();
                    streoMainScript.setBlocks();

                } else
                {
                    var streoConter = GameObject.Find("Streo Counter");
                    if (interval % 60 == 0)
                    {
                        streoConter.GetComponent<TextMesh>().text = "" + (5 - (interval / 60));
                    }
                }
                break;

            default:
                interval = 0;
                break;
        }
    }
}
