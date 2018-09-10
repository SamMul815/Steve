using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour {

    public Vector3 cubeSize;
    public Vector2 baseUV;
    public float uvDistance;
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();
        Vector3[] testVertices = Cube.GetCubeVertices(cubeSize.x, cubeSize.y, cubeSize.z);
        int[] triangles = Cube.GetCubeIndex();
        Vector2[] uvs = Cube.GetCubeUV(cubeSize.x, cubeSize.y, cubeSize.z, baseUV.x, baseUV.y, uvDistance);
        m.vertices = testVertices;
        m.triangles = triangles;
        m.uv = uvs;
        m.RecalculateNormals();
        mf.mesh = m;
    }
}
