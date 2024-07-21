using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh_Script : MonoBehaviour
{
    void OnEnable()
    {
        Mesh mesh = new Mesh { name = "Procedural Mesh" };

        mesh.vertices = new Vector3[] { new Vector3(0.5f, -0.5f), new Vector3(-0.5f, -0.5f), 
                                        new Vector3(-0.5f, 0.5f), new Vector3(0.5f, 0.5f) };
        mesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
        mesh.normals = new Vector3[] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
        mesh.uv = new Vector2[] { new Vector2(1, 0), new Vector2(0, 0),
                                  new Vector2(0, 1), new Vector2(1, 1) };
        mesh.tangents = new Vector4[] { new Vector4(1.0f, 0.0f, 0.0f, -1.0f),
                                        new Vector4(1.0f, 0.0f, 0.0f, -1.0f),
                                        new Vector4(1.0f, 0.0f, 0.0f, -1.0f),
                                        new Vector4(1.0f, 0.0f, 0.0f, -1.0f) };

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
