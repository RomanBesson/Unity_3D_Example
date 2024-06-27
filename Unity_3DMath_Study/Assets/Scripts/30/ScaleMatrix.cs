using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMatrix : MonoBehaviour {

    private Transform a_1;
    private Transform a_2;
    private Transform a_3;
    private Transform a_4;
    private Mesh mesh_A;
    private List<Vector3> v3List = new List<Vector3>();

    private Matrix3x3 m3x3;

	void Start () {
        a_1 = GameObject.Find("A_1").GetComponent<Transform>();
        a_2 = GameObject.Find("A_2").GetComponent<Transform>();
        a_3 = GameObject.Find("A_3").GetComponent<Transform>();
        a_4 = GameObject.Find("A_4").GetComponent<Transform>();
        //mesh_A = GameObject.Find("A").GetComponent<MeshFilter>().mesh;
        mesh_A = GameObject.Find("Sphere").GetComponent<MeshFilter>().mesh;

        m3x3 = new Matrix3x3(
            new Vector3(10, 0, 0), 
            new Vector3(0, 10, 0), 
            new Vector3(0, 0, 10)
            );

        a_1.position = m3x3 * a_1.position;
        a_2.position = m3x3 * a_2.position;
        a_3.position = m3x3 * a_3.position;
        a_4.position = m3x3 * a_4.position;

        Debug.Log("mesh_A网格的顶点个数：" + mesh_A.vertexCount);
        for (int i = 0; i < mesh_A.vertices.Length; i++)
        {
            v3List.Add(m3x3 * mesh_A.vertices[i]);
        }
        mesh_A.SetVertices(v3List);
	}

}
