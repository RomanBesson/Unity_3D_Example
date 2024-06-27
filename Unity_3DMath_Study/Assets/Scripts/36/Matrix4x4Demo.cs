using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix4x4Demo : MonoBehaviour {

    private Mesh mesh_Cube;
    private List<Vector3> v3List = new List<Vector3>(); 

	void Start () {
        mesh_Cube = GameObject.Find("Cube").GetComponent<MeshFilter>().mesh;
        //Matrix4x4 m4x4 = Matrix4x4.Scale(new Vector3(10, 10, 10));
        Quaternion rot =  Quaternion.Euler(new Vector3(70, 0, 0));
        Matrix4x4 m4x4 = Matrix4x4.Rotate(rot);

        for (int i = 0; i < mesh_Cube.vertices.Length; i++)
        {
            v3List.Add(m4x4.MultiplyPoint3x4(mesh_Cube.vertices[i]));
        }
        mesh_Cube.SetVertices(v3List);
	}
	

}
