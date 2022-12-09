using UnityEngine;

public static class VisualEffectsExtension
{
    public static void SpawnSingleVFX(GameObject vfxPrefab, Vector3 pos, float destroyTime = 2f)
    {
        if (vfxPrefab != null)
        {
            var vfx = GameObject.Instantiate(vfxPrefab, pos, Quaternion.identity);
            GameObject.Destroy(vfx, destroyTime);
        }
    }
}