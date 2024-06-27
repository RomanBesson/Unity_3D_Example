using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix3x3 {

    public float m00;   //1.
    public float m01;   //2.
    public float m02;   //3.

    public float m10;   //4.
    public float m11;   //5.
    public float m12;   //6.

    public float m20;   //7.
    public float m21;   //8.
    public float m22;   //9.

    /// <summary>
    /// 逆矩阵.
    /// </summary>
    public Matrix3x3 Inverse
    {
        get
        {
            return new Matrix3x3(
                new Vector3(+(m11 * m22 - m12 * m21) / this.Determinant, -(m10 * m22 - m12 * m20) / this.Determinant, +(m10 * m21 - m11 * m20) / this.Determinant),
                new Vector3(-(m01 * m22 - m02 * m21) / this.Determinant, +(m00 * m22 - m02 * m20) / this.Determinant, -(m00 * m21 - m01 * m20) / this.Determinant),
                new Vector3(+(m01 * m12 - m02 * m11) / this.Determinant, -(m00 * m12 - m02 * m10) / this.Determinant, +(m00 * m11 - m01 * m10) / this.Determinant)
                );
        }
    }


    /// <summary>
    /// 行列式.
    /// </summary>
    public float Determinant
    {
        get
        {
            return m00 * m11 * m22 + m01 * m12 * m20 + m02 * m10 * m21 -
                m02 * m11 * m20 - m01 * m10 * m22 - m00 * m12 * m21;
        }
    }

    public static Vector3 operator *(Matrix3x3 a, Vector3 b)
    {
        return new Vector3(
            a.m00 * b.x + a.m01 * b.y + a.m02 * b.z, 
            a.m10 * b.x + a.m11 * b.y + a.m12 * b.z, 
            a.m20 * b.x + a.m21 * b.y + a.m22 * b.z
            );
    }

    /// <summary>
    /// 矩阵置换.
    /// </summary>
    public Matrix3x3 Transpose
    {
        get
        {
            return new Matrix3x3(
                new Vector3(m00, m01, m02),
                new Vector3(m10, m11, m12),
                new Vector3(m20, m21, m22)
                );
        }
    }

    public Matrix3x3(Vector3 column0, Vector3 column1, Vector3 column2)
    {
        m00 = column0.x;
        m01 = column1.x;
        m02 = column2.x;

        m10 = column0.y;
        m11 = column1.y;
        m12 = column2.y;

        m20 = column0.z;
        m21 = column1.z;
        m22 = column2.z;
    }

    public override string ToString()
    {
        return string.Format("{0}\t{1}\t{2}\n{3}\t{4}\t{5}\n{6}\t{7}\t{8}", 
            m00, m01, m02,
            m10, m11, m12,
            m20, m21, m22
            );
    }


}
