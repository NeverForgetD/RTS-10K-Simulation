using TMPro;
using UnityEngine;

public class PerformanceUIController : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI frameTimeText;
    public TextMeshProUGUI unitText;
    public TextMeshProUGUI gcText;

    void Update()
    {
        var stats = PerformanceStatsProvider.Instance;

        //TODO
        //fpsText.text = stats.FPS.ToString("F0");
        //frameTimeText.text = stats.FrameTimeMs.ToString("F2");
        //unitText.text = stats.ActiveUnits.ToString();
        //gcText.text = (stats.GCAlloc / 1024f).ToString("F0") + " KB";
    }
}
