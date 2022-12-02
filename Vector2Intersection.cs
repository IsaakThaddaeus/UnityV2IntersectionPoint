using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Intersection
{
    bool getIntersectionV2(Vector2 aStart, Vector2 aEnd, Vector2 bStart, Vector2 bEnd, out Vector2 intersection)
    {
        intersection = new Vector2(0, 0);

        Vector2 ab = aEnd - aStart;
        Vector2 cd = bEnd - bStart;


        //no intersection because of colinearity
        if (ab.normalized == cd.normalized)
        {
            return false;
        }


        //equation solving
        float tn = (bStart.x - aStart.x) / ab.x;
        float tx = cd.x / ab.x;

        float sx = cd.y - (tx * ab.y);
        float erg = (aStart.y + (tn * ab.y) - bStart.y) / sx;

        intersection = bStart + cd * erg;


        //is intersectionpoint on Vector?
        float si = Vector2.Distance(aStart, intersection);
        float ie = Vector2.Distance(intersection, aEnd);
        float se = Vector2.Distance(aStart, aEnd);

        if (si + ie > se + 0.01)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
