using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_19 : MonoBehaviour {

	void Start () {
        Matrix2x2 m2x2 = new Matrix2x2(new Vector2(1, 3), new Vector2(2, 4));
        Matrix2x2 m2x2_2 = new Matrix2x2(new Vector2(5, 7), new Vector2(6, 8));

        Matrix3x3 m3x3 = new Matrix3x3(
            new Vector3(1, 4, 7),
            new Vector3(2, 5, 8),
            new Vector3(3, 6, 9)
            );
        Matrix3x3 m3x3_2 = new Matrix3x3(
            new Vector3(5, 0, 0),
            new Vector3(0, 5, 0),
            new Vector3(0, 0, 5)
            );
        Matrix3x3 m3x3_3 = new Matrix3x3(
            new Vector3(4, 6, 7),
            new Vector3(5, 5, 3),
            new Vector3(8, 9, 1)
            );

        Matrix4x4 m4x4 = new Matrix4x4(
            new Vector4(1, 5, 9, 13),
            new Vector4(2, 6, 10, 14),
            new Vector4(3, 7, 11, 15),
            new Vector4(4, 8, 12, 16)
            );

        Matrix4x4 m4x4_2 = new Matrix4x4(
            new Vector4(2, 4, 5, 1),
            new Vector4(3, 3, 5, 2),
            new Vector4(2, 7, 4, 1),
            new Vector4(5, 8, 2, 6)
            );

        Vector3 v3 = new Vector3(2, 3, 4);
        Vector4 v4 = new Vector4(2, 4, 6, 8);

        Debug.Log(m2x2);
        Debug.Log(m3x3);
        Debug.Log(m4x4);

        //矩阵置换测试.
        Debug.Log(m2x2.Transpose);
        Debug.Log(m3x3.Transpose);
        Debug.Log(m4x4.transpose);

        //矩阵相乘.
        Debug.Log(m2x2 * m2x2_2);
        Debug.Log(m2x2_2 * m2x2);
        Debug.Log(m4x4 * m4x4_2);
        Debug.Log(m4x4_2 * m4x4);

        //矩阵与向量相乘.
        Debug.Log(m3x3 * v3);
        Debug.Log(m4x4 * v4);

        //矩阵行列式.
        Debug.Log(m2x2.Determinant);
        Debug.Log(m3x3.Determinant);
        Debug.Log(m3x3_2.Determinant);
        Debug.Log(m4x4.determinant);

        //逆矩阵.
        Debug.Log(m3x3_3);
        Debug.Log(m3x3_3.Determinant);
        Debug.Log(m3x3_3.Inverse);

        Debug.Log(m4x4.inverse);
        Debug.Log(m4x4_2.determinant);
        Debug.Log(m4x4_2.inverse);
        Debug.Log(m4x4_2 * m4x4_2.inverse);
    }
	
}
