using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 전체 시뮬레이션 루프 관리
/// </summary>
public class Simulation
{
    public List<UnitData> Units { get; private set; } = new List<UnitData>();

    UnitSystem unitSystem = new UnitSystem();

    float accumulator = 0f;
    const float tickTime = 1f / 60f;

    /// <summary>
    /// 외부에서 매 프레임 호출
    /// </summary>
    public void Update(float deltaTime)
    {
        accumulator += deltaTime;

        while (accumulator >= tickTime)
        {
            Tick();
            accumulator -= tickTime;
        }
    }

    /// <summary>
    /// 고정 Tick 실행
    /// </summary>
    void Tick()
    {
        unitSystem.Tick(Units, tickTime);
    }

    /// <summary>
    /// 유닛 추가
    /// </summary>
    public void AddUnit(UnitData unit)
    {
        Units.Add(unit);
    }
    /// <summary>
    /// 전체 목표 설정 (집결)
    /// </summary>
    public void SetGlobalTarget(Vector2 target)
    {
        for (int i = 0; i < Units.Count; i++)
        {
            var unit = Units[i];
            unit.targetPos = target;
            unit.state = UnitState.Move;
            Units[i] = unit;
        }
    }
}
