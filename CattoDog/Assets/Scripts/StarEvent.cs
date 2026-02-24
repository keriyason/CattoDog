using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class StarEvent
{
    public static Action<int, UnityEngine.Vector3> OnStarCollected; //calls to when a star gets picked up, how many stars were collected and the last checkpoint tied to it!
}

