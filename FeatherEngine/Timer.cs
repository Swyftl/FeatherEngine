using System.Diagnostics;
using System.Runtime.InteropServices.Swift;

namespace FeatherEngine;

public class Timer
{
    private float _seconds;
    public bool IsActive;
    
    public Timer(float seconds)
    {
        this._seconds = seconds;
    }

    public void Start()
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