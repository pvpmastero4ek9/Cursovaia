using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ListExtentions
{
    public class CountdownTimer : MonoBehaviour
    {
        public TimeSpan totalDuration { get; private set; }
        public TimeSpan elapsedTime { get; private set; }
        public bool isCancelled { get; private set; } = true;

        public delegate void ChangedTimeDelegate(TimeSpan timeSpan);
        public event ChangedTimeDelegate ChangedTime;
        public delegate void EndedTimeDelegate();
        public event EndedTimeDelegate EndedTime;

        public async Task WaitUntil(DateTime targetTime, Action onTimeReached)
        {
            try
            {
                DateTime startTime = DateTime.Now; // как сохранить?
                totalDuration = targetTime - startTime;
                isCancelled = false;

                while (DateTime.Now < targetTime && !isCancelled)
                {
                    TimeSpan remainingTime = targetTime - DateTime.Now;
                    elapsedTime = DateTime.Now - startTime;

                    ChangedTime?.Invoke(remainingTime);

                    await Task.Delay(100);
                    if (Application.isPlaying == false)
                    {
                        return;
                    }
                }

                elapsedTime = totalDuration;

                isCancelled = true;
                EndedTime?.Invoke();
                onTimeReached?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void Cancel()
        {
            isCancelled = true;
        }
    }
}
