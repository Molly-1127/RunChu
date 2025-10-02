using UnityEngine;

public static class Extension
{
    public static readonly WaitForSeconds ZeroPointZeroOneWfs = new WaitForSeconds(.01f);
    public static readonly WaitForSeconds OneWfs = new WaitForSeconds(1f);
}

public static class ExtensionMethods
{
    public static bool IsSameLayer(LayerMask layerMask, int layer)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }
}