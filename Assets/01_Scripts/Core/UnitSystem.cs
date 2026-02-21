using UnityEngine;
using System.Collections.Generic;

public class UnitSystem
{
    const float stopDistance = 0.1f;

    /// <summary>
    /// 전체 유닛 이동 업데이트
    /// </summary>
    public void Tick(List<UnitData> units, float tickTime)
    {
        for (int i = 0; i < units.Count; i++)
        {
            var unit = units[i];

            if (unit.state == UnitState.Move)
            {
                Move(ref unit, tickTime);
            }

            units[i] = unit;
        }
    }

    /// <summary>
    /// 목표 지점으로 이동
    /// </summary>
    void Move(ref UnitData unit, float tickTime)
    {
        Vector2 toTarget = unit.targetPos - unit.pos;
        float distance = toTarget.magnitude;

        if (distance < stopDistance)
        {
            unit.state = UnitState.Idle;
            unit.velocity = Vector2.zero;
            return;
        }

        Vector2 dir = Vector2.Normalize(toTarget);

        unit.velocity = dir * unit.moveSpeed;
        unit.pos += unit.velocity * tickTime;
    }
}
