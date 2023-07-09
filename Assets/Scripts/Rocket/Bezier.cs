using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector2 GetPoint(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t)
    {
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * oneMinusT * p1
            + 3f * oneMinusT * oneMinusT * t * p2
            + 3f * oneMinusT * t * t * p3
            + t * t * t * p4;
    }

    public static Vector2 GetFirstDerivative(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t)
    {
        float oneMinusT = 1f - t;
        return 3f * oneMinusT * oneMinusT * (p2 - p1)
            + 6f * oneMinusT * t * (p3 - p2)
            + 3f * t * t * (p4 - p3);
    }
}
