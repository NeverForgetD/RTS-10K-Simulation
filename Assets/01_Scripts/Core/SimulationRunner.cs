using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 테스트용 Runner
/// </summary>
public class SimulationRunner : MonoBehaviour
{
    Simulation simulation = new Simulation();

    [SerializeField] private int targetUnitCount = 1000;

    private void Start()
    {
        // 테스트 유닛 추가
        //AddTestUnit(targetUnitCount);
    }

    private void Update()
    {
        simulation.Update(Time.deltaTime);

        // 마우스 휠클릭 시 전체 목표 설정
        if (Input.GetMouseButtonDown(2))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            simulation.SetGlobalTarget(mousePos);
        }

        // 마우스 좌클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            AddTestUnit(targetUnitCount);
        }

        // 마우스 우클릭 시
        if (Input.GetMouseButtonDown(1))
        {
            
        }

        PerformanceStatsProvider.Instance.SetActiveUnits(simulation.Units.Count);
    }

    private void AddTestUnit(int targetUnitCount)
    {
        // 테스트  유닛 추가
        for (int i = 0; i < targetUnitCount; i++)
        {
            simulation.AddUnit(new UnitData
            {
                id = i,
                pos = Random.insideUnitCircle * 10f,
                targetPos = Vector2.zero,
                moveSpeed = 5f,
                state = UnitState.Idle
            });
        }
    }
}
