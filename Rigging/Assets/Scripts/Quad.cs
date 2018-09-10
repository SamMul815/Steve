using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    public Vector3 cubeSize;
    public Vector2 baseUV;
    public float uvDistance;
	// Use this for initialization
	void Start ()
    {
        //MeshFilter mf = GetComponent<MeshFilter>();
        //Mesh m = new Mesh();
        //Vector3[] testVertices = Cube.GetCubeVertices(5, 15, 5);
        //int[] triangles = Cube.GetCubeIndex();
        //Vector2[] uvs = Cube.GetCubeUV(5, 15, 5, 0, 0.5f,0.125f / 2.0f);
        //m.vertices = testVertices;
        //m.triangles = triangles;
        //m.uv = uvs;
        //m.RecalculateNormals();
        //mf.mesh = m;

        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();
        Vector3[] testVertices = Cube.GetCubeVertices(cubeSize.x, cubeSize.y, cubeSize.z);
        int[] triangles = Cube.GetCubeIndex();
        Vector2[] uvs = Cube.GetCubeUV(cubeSize.x, cubeSize.y, cubeSize.z, baseUV.x, baseUV.y,uvDistance);
        m.vertices = testVertices;
        m.triangles = triangles;
        m.uv = uvs;
        m.RecalculateNormals();
        mf.mesh = m;
    }
}
