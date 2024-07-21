using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AdvancedProceduralMesh_Script : MonoBehaviour
{
    void OnEnable()
    {
        int vertexAttributeCount = 4;
        int vertexCount = 4;
        int triangleIndexCount = 6;

        // Allocate pool of writable meshes
        Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
        Mesh.MeshData meshData = meshDataArray[0];

        var vertexAttributes = new NativeArray<VertexAttributeDescriptor>(vertexAttributeCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
        vertexAttributes[0] = new VertexAttributeDescriptor( VertexAttribute.Position,  dimension: 3, stream: 0);
        vertexAttributes[1] = new VertexAttributeDescriptor( VertexAttribute.Normal,    dimension: 3, stream: 1);
        vertexAttributes[2] = new VertexAttributeDescriptor( VertexAttribute.Tangent,   dimension: 4, stream: 2);
        vertexAttributes[3] = new VertexAttributeDescriptor( VertexAttribute.TexCoord0, dimension: 2, stream: 3);
        meshData.SetVertexBufferParams(vertexCount, vertexAttributes);
        meshData.SetIndexBufferParams(triangleIndexCount, IndexFormat.UInt32);
        vertexAttributes.Dispose();


        NativeArray<float3> positions = meshData.GetVertexData<float3>();
        positions[0] = new float3(-0.5f, -0.5f, 0.0f);
        positions[1] = new float3( 0.5f, -0.5f, 0.0f);
        positions[2] = new float3( 0.5f,  0.5f, 0.0f);
        positions[3] = new float3(-0.5f,  0.5f, 0.0f);

        NativeArray<float3> normals = meshData.GetVertexData<float3>(1);
        normals[0] = normals[1] = normals[2] = normals[3] = new float3(0.0f, 0.0f, -1.0f);

        NativeArray<float4> tangents = meshData.GetVertexData<float4>(2);
        tangents[0] = tangents[1] = tangents[2] = tangents[3] = new float4(1.0f, 0.0f, 0.0f, -1.0f);

        NativeArray<float2> texCoords = meshData.GetVertexData<float2>(3);
        texCoords[0] = new float2(0.0f, 0.0f);
        texCoords[1] = new float2(1.0f, 0.0f);
        texCoords[2] = new float2(1.0f, 1.0f);
        texCoords[3] = new float2(0.0f, 1.0f);

        NativeArray<uint> triangleIndices = meshData.GetIndexData<uint>();
        triangleIndices[0] = 0;
        triangleIndices[1] = 3;
        triangleIndices[2] = 2;
        triangleIndices[3] = 2;
        triangleIndices[4] = 1;
        triangleIndices[5] = 0;

        var bounds = new Bounds(new Vector3(0.5f, 0.5f), new Vector3(1.0f, 1.0f));
        meshData.subMeshCount = 1;
        meshData.SetSubMesh(0, new SubMeshDescriptor(0, triangleIndexCount) 
            { bounds = bounds, vertexCount = vertexCount}, MeshUpdateFlags.DontRecalculateBounds);

        Mesh mesh = new Mesh { bounds = bounds, name = "Procedural Mesh" };

        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
