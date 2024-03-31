using UnityEngine;

public static class Extensions
{
    public static T[] GetLastElements<T>(this T[] array, int elementsCount)
    {
        elementsCount = Mathf.Clamp(elementsCount, 0, array.Length);

        var lastElements = new T[elementsCount];
        for (int i = elementsCount-1; i >= 0; i--)
        {
            lastElements[i] = array[i];
        }

        return lastElements;
    }
}