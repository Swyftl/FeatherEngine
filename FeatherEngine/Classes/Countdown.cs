using System.Diagnostics;
using System.Runtime.InteropServices.Swift;

namespace FeatherEngine;

public class Countdown(float seconds)
{
    private float _seconds = seconds;
    public bool IsActive;

    /// <summary>
    /// Starts the countdown timer asynchronously on a new thread.
    /// </summary>
    public void Start()
    {
        Thread startThread = new Thread(Start_Threaded);
        startThread.Start();
    }

    /// <summary>
    /// Runs the countdown timer on a separate thread, setting IsActive to true while the countdown is in progress and false when complete.
    /// </summary>
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

    /// <summary>
    /// Updates the countdown duration to the specified number of seconds.
    /// </summary>
    /// <param name="seconds">The new countdown duration in seconds.</param>
    public void ChangeTime(float seconds)
    {
        this._seconds = seconds;
    }
}