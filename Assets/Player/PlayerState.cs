using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void EnterState(Player player);

    public abstract void UpdateState(Player player);

    public abstract void ExitState(Player player);
}
