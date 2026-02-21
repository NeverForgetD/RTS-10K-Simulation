using UnityEngine;

/// <summary>
/// ¿Ø¥÷ ªÛ≈¬
/// </summary>
public enum UnitState
{
    Idle,
    Move
}

/// <summary>
/// ¿Ø¥÷ µ•¿Ã≈Õ
/// </summary>
public struct UnitData
{
    public int id;

    public Vector2 pos;
    public Vector2 targetPos;
    public Vector2 velocity;

    public float moveSpeed;

    public UnitState state;
}
