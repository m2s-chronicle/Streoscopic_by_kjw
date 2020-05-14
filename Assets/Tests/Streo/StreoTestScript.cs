using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreoTestScript : MonoBehaviour
{

    int testCount = 0;
    int successCount = 0;
    bool endEdit = false;
    int rand = 0;
    int interval = 0;
    bool checking = false;
    int checkingInterval = 0;

    public void initDatas()
    {
        testCount = 0;
        successCount = 0;
        endEdit = false;
        rand = 0;
    }

    public void setBlocks()
    {
        if (testCount != 0 && testCount <= 10) {
            checking = true;
            checkSuccess();
        }
        if (testCount > 10)
        {
            endTest();
            return;
        }

        testCount += 1;

        rand = Random.Range(0, 4);

        var box1Z = 9.5f;
        var box2Z = 9.5f;
        var box3Z = 9.5f;
        var box4Z = 9.5f;
        var comRange = 0.2f;
        switch (rand)
        {
            case 0:
                box1Z -= comRange;
                break;
            case 1:
                box2Z -= comRange;
                break;
            case 2:
                box3Z -= comRange;
                break;
            case 3:
                box4Z -= comRange;
                break;
        }

        var gap = 1;

        var box1 = GameObject.Find("StreoBox1");
        box1.transform.position = new Vector3(-gap, gap, box1Z);

        var box2 = GameObject.Find("StreoBox2");
        box2.transform.position = new Vector3(gap, gap, box2Z);

        var box3 = GameObject.Find("StreoBox3");
        box3.transform.position = new Vector3(-gap, -gap, box3Z);

        var box4 = GameObject.Find("StreoBox4");
        box4.transform.position = new Vector3(gap, -gap, box4Z);

    }

    private void checkSuccess()
    {
        var boxObject = GameObject.Find("StreoBox1");
        switch (rand)
        {
            case 0:
                boxObject = GameObject.Find("StreoBox1");
                break;
            case 1:
                boxObject = GameObject.Find("StreoBox2");
                break;
            case 2:
                boxObject = GameObject.Find("StreoBox3");
                break;
            case 3:
                boxObject = GameObject.Find("StreoBox4");
                break;
        }

        var positionX = boxObject.transform.position.x;
        var positionY = boxObject.transform.position.y;

        var StreoRedBar = GameObject.Find("StreoRedBar");
        var barX = StreoRedBar.transform.position.x;
        var barY = StreoRedBar.transform.position.y;

        var gap = 0.6;
        if (positionX - gap < barX && positionX + gap > barX && positionY - gap < barY && positionY + gap > barY)
        {
            successCount += 1;
        }
        var TestStatusText = GameObject.Find("TestStatusText");
        TestStatusText.GetComponent<Text>().text = "검사중 "+ (testCount) + "/10 SUC: "+successCount;
    }

    private void endTest()
    {
        var box1_ = GameObject.Find("StreoBox1");
        box1_.GetComponent<Renderer>().enabled = false;

        var box2_ = GameObject.Find("StreoBox2");
        box2_.GetComponent<Renderer>().enabled = false;

        var box3_ = GameObject.Find("StreoBox3");
        box3_.GetComponent<Renderer>().enabled = false;

        var box4_ = GameObject.Find("StreoBox4");
        box4_.GetComponent<Renderer>().enabled = false;

        var BoxCover_ = GameObject.Find("BoxCover");
        BoxCover_.GetComponent<Renderer>().enabled = false;

        endEdit = true;

        var streoIntro = GameObject.Find("Streo intro");
        var resultText = "검사가 종료되었습니다\n총 10번중 " + successCount + "번의 성공을 했습니다\n";
        if (successCount < 4)
        {
            resultText += "정밀 검사를 위해 안과에 방문해보세요";
        }
        else if (successCount < 7)
        {
            resultText += "눈 건강이 좋은편이시네요";
        }
        else
        {
            resultText += "평소에 눈 관리를 잘하시는 것 같네요!";
        }
        streoIntro.GetComponent<TextMesh>().text = resultText;
        streoIntro.GetComponent<Renderer>().enabled = true;

    }

    private void Update()
    {
        if (checking)
        {
            checkingInterval += 1;
            var BoxCover = GameObject.Find("BoxCover");
            BoxCover.GetComponent<Renderer>().enabled = true;
            if (checkingInterval > 60)
            {
                checkingInterval = 0;
                checking = false;
                BoxCover.GetComponent<Renderer>().enabled = false;
            }

        }

        if (!endEdit)
        {
            return;
        }
        interval += 1;
        if (interval > 5 * 60)
        {
            endEdit = false;
            var testStartScript = GameObject.Find("StartTestsFunc").GetComponent<StartTest>();
            testStartScript.endTests();
        }
    }
}
