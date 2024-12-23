using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshFilter meshFiler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int vertexIndex = 0;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int faceIdx = 0; faceIdx < 6; faceIdx++)
        {
            for (int vertexIdx = 0; vertexIdx < 6; vertexIdx++)
            {
                int triangleIndex = VoxelData.voxelTries[faceIdx, vertexIdx];
                vertices.Add(VoxelData.voxelVerts[triangleIndex]);
                triangles.Add(vertexIndex);

                uvs.Add(VoxelData.voxelUvs[vertexIdx]);
            
                vertexIndex++;
            }
        }
        
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();

        meshFiler.mesh = mesh;
    }
}
