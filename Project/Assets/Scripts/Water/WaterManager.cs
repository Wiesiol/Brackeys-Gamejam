using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        var verts = meshFilter.mesh.vertices;

        for(int i = 0; i < verts.Length; i++)
        {
            verts[i].y = WaveManager.Instance.GetWaveHeight(transform.position.x + verts[i].x);
        }

        meshFilter.mesh.vertices = verts;
        meshFilter.mesh.RecalculateNormals();
    }
}