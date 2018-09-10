using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {


    static public Vector3[] GetCubeVertices(float sizeX = 1.0f, float sizeY = 1.0f, float sizeZ = 1.0f)
    {
        List<Vector3> vertices = new List<Vector3>();

        //RIGHT
        vertices.Add(new Vector3(-0.5f, -0.5f, 1f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 0f));
        vertices.Add(new Vector3(-0.5f, -0.5f, 0f));

        //FRONT
        vertices.Add(new Vector3(-0.5f, -0.5f, 0f));
        vertices.Add(new Vector3(-0.5f,  0.5f, 0f));
        vertices.Add(new Vector3( 0.5f,  0.5f, 0f));
        vertices.Add(new Vector3( 0.5f, -0.5f, 0f));

        //LEFT
        vertices.Add(new Vector3(0.5f, -0.5f, 0f));
        vertices.Add(new Vector3(0.5f, 0.5f, 0f));
        vertices.Add(new Vector3(0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(0.5f, -0.5f, 1f));
        //BACK
        vertices.Add(new Vector3(-0.5f, -0.5f, 1f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(0.5f, -0.5f, 1f));

        //TOP
        vertices.Add(new Vector3(-0.5f, 0.5f, 0f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(0.5f, 0.5f, 1f));
        vertices.Add(new Vector3(0.5f, 0.5f, 0f));

        //BOTTOM
        vertices.Add(new Vector3(-0.5f, -0.5f, 0f));
        vertices.Add(new Vector3(-0.5f, -0.5f, 1f));
        vertices.Add(new Vector3(0.5f, -0.5f, 1f));
        vertices.Add(new Vector3(0.5f, -0.5f, 0f));

        int count = vertices.Count;
        Vector3 vertex;
        for(int i = 0; i<count; i++)
        {
            vertex = vertices[i];
            vertex.x *= sizeX;
            vertex.y *= sizeY;
            vertex.z *= sizeZ;
            vertices[i] = vertex;
        }
        return vertices.ToArray();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sizeX">큐브x축 크기</param>
    /// <param name="sizeY">큐브y축 크기</param>
    /// <param name="sizeZ">큐브z축 크기</param>
    /// <param name="standU">RightU</param>
    /// <param name="standV">RightV</param>
    /// <returns></returns>
    static public Vector2[] GetCubeUV(float sizeX, float sizeY, float sizeZ, float standU, float standV,float uvDistance)
    {
        List<Vector2> uvs = new List<Vector2>();
        float uvSize = uvDistance;

        //5 15 5
        float ratioX = 1.0f;
        float ratioY = sizeY / sizeX;
        float ratioZ = sizeZ / sizeX; 

        //RIGHT
        //new Vector2(0.0f, 0.75f),
        //new Vector2(0.0f, 0.875f),
        //new Vector2(0.125f, 0.875f),
        //new Vector2(0.125f, 0.75f),
        //Right
        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioZ, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioZ, standV));
        standU += uvSize * ratioZ;
        
        //FRONT
        //new Vector2(0.125f,0.75f),
        //new Vector2(0.125f,0.875f),
        //new Vector2(0.25f,0.875f),
        //new Vector2(0.25f,0.75f),

        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioX, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioX , standV));
        standU += uvSize * ratioX;

        //LEFT
        //new Vector2(0.25f,0.75f),
        //new Vector2(0.25f,0.875f),
        //new Vector2(0.375f,0.875f),
        //new Vector2(0.375f,0.75f),
        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioZ, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioZ, standV));
        standU += uvSize * ratioZ;

        //BACK
        //new Vector2(0.375f,0.75f),
        //new Vector2(0.375f,0.875f),
        //new Vector2(0.5f,0.875f),
        //new Vector2(0.5f,0.75f),
        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioX, standV + uvSize * ratioY));
        uvs.Add(new Vector2(standU + uvSize * ratioX, standV));

        //TOP
        //new Vector2(0.125f,0.875f),
        //new Vector2(0.125f,1f),
        //new Vector2(0.25f,1f),
        //new Vector2(0.25f,0.875f),
        //StandU = 0.125;
        //StandV = 0.875;
        standU -= uvSize*ratioZ + uvSize * ratioX;
        standV += uvSize * ratioY;
        //Top
        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize*ratioZ));
        uvs.Add(new Vector2(standU + uvSize*ratioX, standV + uvSize*ratioZ));
        uvs.Add(new Vector2(standU + uvSize*ratioX, standV));
        standU += uvSize * ratioX;

        //BOTTOM
        //new Vector2(0.25F,0.875f),
        //new Vector2(0.25f,1f),
        //new Vector2(0.375f,1f),
        //new Vector2(0.375f,0.875f),
        uvs.Add(new Vector2(standU, standV));
        uvs.Add(new Vector2(standU, standV + uvSize * ratioZ));
        uvs.Add(new Vector2(standU + uvSize * ratioX, standV + uvSize * ratioZ));
        uvs.Add(new Vector2(standU + uvSize * ratioX, standV));

        return uvs.ToArray();
    }

    static public int[] GetCubeIndex()
    {
        int[] triangles = new int[]
        {
            //RIGHT
            0,1,2, 0,2,3,
            //FRONT
            4,5,6, 4,6,7,
            //LEFT
            8,9,10, 8,10,11,
            //BACK
            //12,13,14, 12,14,15,
            12,14,13, 12,15,14,
            //TOP
            16,17,18, 16,18,19,
            //BOTTOM
            //20,21,22, 20,22,23,
            20,22,21, 20,23,22,
        };
        return triangles;
    }
}
