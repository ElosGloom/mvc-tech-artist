using System.Collections.Generic;

public class ClearableContainer
{
    private readonly HashSet<IClearable> _clearableObjects = new HashSet<IClearable>();

    public void Add(IClearable clearable) => _clearableObjects.Add(clearable);

    public void Clear()
    {
        foreach (var clearableObject in _clearableObjects)
        {
            clearableObject.Clear();
        }
        _clearableObjects.Clear();
    }
}