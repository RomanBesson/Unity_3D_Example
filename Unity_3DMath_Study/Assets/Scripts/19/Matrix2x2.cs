using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix2x2 {

    public float m00; //1.
    public float m01; //2.
    public float m10; //3.
    public float m11; //4.

    public static Matrix2x2 operator *(Matrix2x2 a, Matrix2x2 b)
    {
        return new Matrix2x2(
                new Vector2(a.m00 * b.m00 + a.m01 * b.m10, a.m10 * b.m00 + a.m11 * b.m10),
                new Vector2(a.m00 * b.m01 + a.m01 * b.m11, a.m10 * b.m01 + a.m11 * b.m11)
            );
    }

    /// <summary>
    /// 行列式.
    /// </summary>
    public float Determinant
    {
        get
        {
            return m00 * m11 - m01 * m10;
        }
    }

    /// <summary>
    /// 矩阵置换.
    /// </summary>
    public Matrix2x2 Transpose
    {
        get
        {
            return new Matrix2x2(new Vector2(m00, m01), new Vector2(m10, m11));
        }
    }



    public Matrix2x2(Vector2 column0, Vector2 column1)
    {
        m00 = column0.x;
        m01 = column1.x;
        m10 = column0.y;
        m11 = column1.y;
    }

    public override string ToString()
    {
        return string.Format("{0}\t{1}\n{2}\t{3}",m00, m01, m10, m11);
    }

}
