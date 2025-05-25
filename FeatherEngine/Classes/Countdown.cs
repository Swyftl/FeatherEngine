using System.Diagnostics;
using System.Runtime.InteropServices.Swift;

namespace FeatherEngine;

public class Countdown(float seconds)
{
    private float _seconds = seconds;
    public bool IsActive;

    public void Start()
    {
        Thread startThread = new Thread(Start_Threaded);
        startThread.Start();
    }

    private void Start_Threaded()
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _seconds)
        {
            IsActive = true;
        }
        
        IsActive = false;
    }

    public void ChangeTime(float seconds)
    {
        this._seconds = seconds;
    }
}