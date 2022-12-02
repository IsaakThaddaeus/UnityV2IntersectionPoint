using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Intersection
{
    bool getIntersectionV2Cramer(Vector2 aStart, Vector2 aEnd, Vector2 bStart, Vector2 bEnd, out Vector2 intersection)
    {
        intersection = new Vector2(0, 0);

        Vector2 ab = aEnd - aStart;
        Vector2 cd = bEnd - bStart;

        //no intersection because of colinearity
        if (ab.normalized == cd.normalized)
        {
            return false;
        }


        //Solving equation by Cramers Rule
        float a1 = ab.x;
        float b1 = -cd.x;
        float c1 = bStart.x - aStart.x;

        float a2 = ab.y;
        float b2 = -cd.y;
        float c2 = bStart.y - aStart.y;

        float D = (a1 * b2) - (b1 * a2);
        float Dx = (c1 * b2) - (b1 * c2);
        float Dy = (a1 * c2) - (c1 * a2);

        float x = Dx / D;
        float y = Dy / D;

        intersection = aStart + x * (ab);


        //is intersectionpoint on Vector?
        float siA = Vector2.Distance(aStart, intersection);
        float ieA = Vector2.Distance(intersection, aEnd);
        float seA = Vector2.Distance(aStart, aEnd);

        float siB = Vector2.Distance(bStart, intersection);
        float ieB = Vector2.Distance(intersection, bEnd);
        float seB = Vector2.Distance(bStart, bEnd);


        if (siA + ieA > seA + 0.01 || siB + ieB > seB + 0.01)
        {
            return false;
        }

        return true;
    }
}
