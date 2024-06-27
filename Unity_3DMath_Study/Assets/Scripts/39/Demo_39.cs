using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_39 : MonoBehaviour {

    private Transform m_Transform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        Debug.Log("四元数:" + m_Transform.rotation);
        Debug.Log("四元数X:" + m_Transform.rotation.x);
        Debug.Log("四元数Y:" + m_Transform.rotation.y);
        Debug.Log("四元数Z:" + m_Transform.rotation.z);
        Debug.Log("四元数W:" + m_Transform.rotation.w);

        Debug.Log("欧拉角:" + m_Transform.rotation.eulerAngles);

        //MyQuaternion mq = new MyQuaternion(0.1f, 0.1f, 0.1f, 0.1f);
        //Debug.Log(mq);

        //Debug.Log("默认四元数的单位四元数:" + Quaternion.identity);
        //Debug.Log("自定义四元数的单位四元数:" + MyQuaternion.Identity);

        MyQuaternion mq = MyQuaternion.ToQuaternion(40, Vector3.right);
        Debug.Log("四元数:" + mq + "旋转角度:" + mq.GetAngle() + "旋转轴向:" + mq.GetAxis());



        float angle;
        Vector3 axis;
        m_Transform.rotation.ToAngleAxis(out angle, out axis);
        Debug.Log("旋转轴向:" + axis + "旋转角度:" + angle);

    }

}
