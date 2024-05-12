using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 具体主题角色.
/// </summary>
public class Teacher : TeacherSubject {

    private string teacherState;
    public string TeacherState
    {
        get { return teacherState; }
        set { teacherState = value; }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Function1();
            base.Notify();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Function2();
            base.Notify();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Function3();
            base.Notify();
        }
    }
    public void Function1()
    {
        teacherState = "上课";
    }
    public void Function2()
    {
        teacherState = "下课";
    }
    public void Function3()
    {
        teacherState = "交学费";
    }
}
