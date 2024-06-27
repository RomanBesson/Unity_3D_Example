using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMatrix : MonoBehaviour {

    private Transform cubeA_1;
    private Transform cubeA_2;
    private Transform cubeA_3;

    private Transform cubeB_1;
    private Transform cubeB_2;
    private Transform cubeB_3;

    private Transform cubeC_1;
    private Transform cubeC_2;
    private Transform cubeC_3;

    private Matrix3x3 m3x3x;
    private Matrix3x3 m3x3y;
    private Matrix3x3 m3x3z;

    private Mesh mesh_candelabra;
    private List<Vector3> v3List = new List<Vector3>();

	void Start () {
        cubeA_1 = GameObject.Find("A_1").GetComponent<Transform>();
        cubeA_2 = GameObject.Find("A_2").GetComponent<Transform>();
        cubeA_3 = GameObject.Find("A_3").GetComponent<Transform>();

        cubeB_1 = GameObject.Find("B_1").GetComponent<Transform>();
        cubeB_2 = GameObject.Find("B_2").GetComponent<Transform>();
        cubeB_3 = GameObject.Find("B_3").GetComponent<Transform>();

        cubeC_1 = GameObject.Find("C_1").GetComponent<Transform>();
        cubeC_2 = GameObject.Find("C_2").GetComponent<Transform>();
        cubeC_3 = GameObject.Find("C_3").GetComponent<Transform>();

        mesh_candelabra = GameObject.Find("candelabra").GetComponent<MeshFilter>().mesh;

        m3x3x = new Matrix3x3(
            new Vector3(-1, 0, 0), 
            new Vector3(0, 1, 0), 
            new Vector3(0, 0, 1)
            );

        m3x3y = new Matrix3x3(
            new Vector3(1, 0, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 1)
            );

        m3x3z = new Matrix3x3(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, -1)
            );

        cubeA_1.position = m3x3x * cubeA_1.position;
        cubeA_2.position = m3x3x * cubeA_2.position;
        cubeA_3.position = m3x3x * cubeA_3.position;

        cubeB_1.position = m3x3y * cubeB_1.position;
        cubeB_2.position = m3x3y * cubeB_2.position;
        cubeB_3.position = m3x3y * cubeB_3.position;

        cubeC_1.position = m3x3z * cubeC_1.position;
        cubeC_2.position = m3x3z * cubeC_2.position;
        cubeC_3.position = m3x3z * cubeC_3.position;

        for (int i = 0; i < mesh_candelabra.vertices.Length; i++)
        {
            v3List.Add(m3x3x * mesh_candelabra.vertices[i]);
        }
        mesh_candelabra.SetVertices(v3List);
	}
	
}
