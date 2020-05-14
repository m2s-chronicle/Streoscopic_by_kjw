using Fove.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveControll : MonoBehaviour
{
    public void Calibration()
    {
        FoveManager.EnsureEyeTrackingCalibration();
    }

    public void resetHMDRotation()
    {
        FoveManager.Headset.TareOrientationSensor();
    }

}
