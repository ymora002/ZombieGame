using UnityEngine;
using System.Collections;
using System;

public class ClockScript : MonoBehaviour {
   
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    public Transform hourHand, minuteHand, secondHand;
    public bool analog;

    void FixedUpdate () {
        if (analog) {
            TimeSpan timespan = DateTime.Now.TimeOfDay;

            if (hourHand)
                hourHand.localRotation =
                Quaternion.Euler(0f,0f,(float)timespan.TotalHours * hoursToDegrees);

            if (minuteHand)
                minuteHand.localRotation =
                Quaternion.Euler(0f,0f,(float)timespan.TotalMinutes * minutesToDegrees);

            if (secondHand)
                secondHand.localRotation =
                Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * secondsToDegrees);
        }
        else {
            DateTime time = DateTime.Now;
            if (hourHand)
                hourHand.localRotation = Quaternion.Euler(0f, 0f, time.Hour * hoursToDegrees);

            if (minuteHand)
                minuteHand.localRotation = Quaternion.Euler(0f, 0f, time.Minute * minutesToDegrees);

            if (secondHand)
                secondHand.localRotation = Quaternion.Euler(0f, 0f, time.Second * secondsToDegrees);
        }
    }
}