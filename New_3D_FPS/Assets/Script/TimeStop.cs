using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    //    public UnityEngine.Rendering.Volume volume;
    public UnityEngine.Rendering.Volume volume;
    private ColorAdjustments color = null;
    private ChromaticAberration ca;
    private Vignette vi;
    private LensDistortion lens;
    private Rigidbody rb;
    public bool TimeStopped;


    private void Awake()
    {
        volume.profile.TryGet<ColorAdjustments>(out color);
        volume.profile.TryGet<ChromaticAberration>(out ca);
        volume.profile.TryGet<Vignette>(out vi);
        volume.profile.TryGet<LensDistortion>(out lens);
    }

    public void TimeResume()
    {
        TimeStopped = false;
        var objects = FindObjectsOfType<TimeBody>();
        for(int i = 0;i<objects.Length;i++)
        {
            objects[i].GetComponent<TimeBody>().ContinueTime();
        }
        color.hueShift.Override(0f);
        ca.intensity.Override(0.169f);
        vi.intensity.Override(0);
        vi.smoothness.Override(0);
        vi.rounded.Override(false);
    }

    public void StopTime()
    {
        TimeStopped = true;
        color.hueShift.Override(180f);
        ca.intensity.Override(1);
        vi.intensity.Override(0.257f);
        vi.smoothness.Override(0.412f);
        vi.rounded.Override(true);
    }



}
