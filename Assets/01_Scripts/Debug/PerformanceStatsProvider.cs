using UnityEngine;

public class PerformanceStatsProvider : MonoBehaviour
{
    public static PerformanceStatsProvider Instance { get; private set; }

    public float FPS { get; private set; }
    public float FrameTime { get; private set; }
    public int ActiveUnits { get; private set; }
    public long GCAlloc { get; private set; }

    private float _deltatime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        _deltatime += (Time.unscaledDeltaTime - _deltatime) * 0.1f;
        FPS = 1.0f / _deltatime;
        FrameTime = _deltatime * 1000.0f;
        GCAlloc = System.GC.GetTotalMemory(false);
    }

    public void SetActiveUnits(int count)
    {
        ActiveUnits = count;
    }

}
