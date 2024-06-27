using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthogonalMatrix : MonoBehaviour {

    private Transform cubeA;
    private Transform cubeB;
    private Transform cubeC;
    private Transform cubeD;
    private Mesh mesh_Sphere;

    private Matrix3x3 m3x3;
    private List<Vector3> v3List = new List<Vector3>();

	void Start () {
        cubeA = GameObject.Find("CubeA").GetComponent<Transform>();
        cubeB = GameObject.Find("CubeB").GetComponent<Transform>();
        cubeC = GameObject.Find("CubeC").GetComponent<Transform>();
        cubeD = GameObject.Find("CubeD").GetComponent<Transform>();
        mesh_Sphere = GameObject.Find("Sphere").GetComponent<MeshFilter>().mesh;

        m3x3 = new Matrix3x3(
            new Vector3(1, 0, 0), 
            new Vector3(0, 1, 0), 
            new Vector3(0, 0, 0)
            );

        cubeA.position = m3x3 * cubeA.position;
        cubeB.position = m3x3 * cubeB.position;
        cubeC.position = m3x3 * cubeC.position;
        cubeD.position = m3x3 * cubeD.position;

        for (int i = 0; i < mesh_Sphere.vertices.Length; i++)
        {
            v3List.Add(m3x3 * mesh_Sphere.vertices[i]);
        }
        mesh_Sphere.SetVertices(v3List);
	}
}
