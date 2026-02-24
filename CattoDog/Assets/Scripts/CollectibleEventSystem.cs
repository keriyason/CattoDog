using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectibleEventSystem
{
    public static event Action<Vector3> OnCheckpointReached;

    public static void RaiseCheckpointReached(Vector3 checkpointPosition)
    {
        OnCheckpointReached?.Invoke(checkpointPosition);
    }
}


