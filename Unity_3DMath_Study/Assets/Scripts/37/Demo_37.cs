using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_37 : MonoBehaviour {

    private Transform cube_Transform;
    private Mesh mesh;
    private List<Vector3> v3List = new List<Vector3>();

	void Start () {
        cube_Transform = GameObject.Find("Cube").GetComponent<Transform>();
        mesh = GameObject.Find("candelabra").GetComponent<MeshFilter>().mesh;
        Demo_5();
	}

    /// <summary>
    /// 自定义“缩放+平移”矩阵.
    /// </summary>
    private void Demo_5()
    {
        Matrix4x4 m4x4 = new Matrix4x4(
            new Vector4(3, 0, 0, 0),
            new Vector4(0, 3, 0, 0),
            new Vector4(0, 0, 3, 0),
            new Vector4(2, 3, 4, 1)
            );
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            v3List.Add(m4x4.MultiplyPoint3x4(mesh.vertices[i]));
        }
        mesh.SetVertices(v3List);
    }

    /// <summary>
    /// 自定义缩放矩阵，平移矩阵，完成两次变换.
    /// </summary>
    private void Demo_4()
    {
        Matrix4x4 m4x4S = new Matrix4x4(
            new Vector4(3, 0, 0, 0),
            new Vector4(0, 3, 0, 0),
            new Vector4(0, 0, 3, 0),
            new Vector4(0, 0, 0, 1)
            );
        Matrix4x4 m4x4T = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(2, 3, 4, 1)
            );

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            v3List.Add(m4x4S.MultiplyPoint3x4(mesh.vertices[i]));
        }
        List<Vector3> tempV3 = new List<Vector3>();
        for (int i = 0; i < v3List.Count; i++)
        {
            tempV3.Add(m4x4T.MultiplyPoint3x4(v3List[i]));
        }
        mesh.SetVertices(tempV3);
    }


    /// <summary>
    /// 平移矩阵操作模型Mesh顶点.
    /// </summary>
    private void Demo_3()
    {
        Matrix4x4 m4x4 = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(3, 4, 5, 1)
            );

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            v3List.Add(m4x4.MultiplyPoint3x4(mesh.vertices[i]));
        }
        mesh.SetVertices(v3List);
    }


    /// <summary>
    /// Unity API定义平移矩阵.
    /// </summary>
    private void Demo_2()
    {
        Matrix4x4 m4x4 = Matrix4x4.Translate(new Vector3(1, 2, 3));
        cube_Transform.position = m4x4.MultiplyPoint3x4(cube_Transform.position);
    }

    /// <summary>
    /// 自定义平移矩阵.
    /// </summary>
    private void Demo_1()
    {
        Matrix4x4 m4x4 = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(3, -4, 5, 1)
            );
        Vector4 tempV4 = new Vector4(cube_Transform.position.x, cube_Transform.position.y, cube_Transform.position.z, 1);
        tempV4 = m4x4 * tempV4;
        Vector3 tempV3 = new Vector3(tempV4.x, tempV4.y, tempV4.z);
        cube_Transform.position = tempV3;
    }

}
