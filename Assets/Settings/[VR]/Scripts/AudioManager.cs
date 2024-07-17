using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource exhibitOneSource;
    [SerializeField]
    private AudioSource exhibitTwoSource;
    [SerializeField]
    private AudioSource exhibitThreeSource;
    [SerializeField]
    private AudioSource exhibitFourSource;
    [SerializeField]
    private AudioSource exhibitFiveSource;
    [SerializeField]
    private AudioSource exhibitSixSource;
    [SerializeField]
    private AudioSource exhibitSevenSource;
    [SerializeField]
    private AudioSource exhibitEightSource;
    [SerializeField]
    private AudioSource exhibitNineSource;
    [SerializeField]
    private AudioSource exhibitTenSource;

    public void PlayExhibitOne()
    {
        if (exhibitOneSource.isPlaying == false) { exhibitOneSource.Play(); }
    }
    public void PlayExhibitTwo()
    {
        if (exhibitTwoSource.isPlaying == false) { exhibitTwoSource.Play(); }
    }
    public void PlayExhibitThree()
    {
        if (exhibitThreeSource.isPlaying == false) { exhibitThreeSource.Play(); }
    }
    public void PlayExhibitFour()
    {
        if (exhibitFourSource.isPlaying == false) { exhibitFourSource.Play(); }
    }
    public void PlayExhibitFive()
    {
        if (exhibitFiveSource.isPlaying == false) { exhibitFiveSource.Play(); }
    }
    public void PlayExhibitSix()
    {
        if (exhibitSixSource.isPlaying == false) { exhibitSixSource.Play(); }
    }
    public void PlayExhibitSeven()
    {
        if (exhibitSevenSource.isPlaying == false) { exhibitSevenSource.Play(); }
    }
    public void PlayExhibitEight()
    {
        if (exhibitEightSource.isPlaying == false) { exhibitEightSource.Play(); }
    }
    public void PlayExhibitNine()
    {
        if (exhibitNineSource.isPlaying == false) { exhibitNineSource.Play(); }
    }
    public void PlayExhibitTen()
    {
        if (exhibitTenSource.isPlaying == false) { exhibitTenSource.Play(); }
    }
    public void StopExhibitOne()
    {
        exhibitOneSource.Stop();
    }

    public void StopExhibitTwo()
    {
        exhibitTwoSource.Stop();
    }
    public void StopExhibitThree()
    {
        exhibitThreeSource.Stop();
    }
    public void StopExhibitFour()
    {
        exhibitFourSource.Stop();
    }
    public void StopExhibitFive()
    {
        exhibitFiveSource.Stop();
    }
    public void StopExhibitSix()
    {
        exhibitSixSource.Stop();
    }
    public void StopExhibitSeven()
    {
        exhibitSevenSource.Stop();
    }
    public void StopExhibitEight()
    {
        exhibitEightSource.Stop();
    }
    public void StopExhibitNine()
    {
        exhibitNineSource.Stop();
    }
    public void StopExhibitTen()
    {
        exhibitTenSource.Stop();
    }
}
