using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 具体观察者角色.
/// </summary>
public class Student : StudentObserver {

    private string name;
    private Teacher subject;

    public void InitStudent(string name, Teacher subject)
    {
        this.name = name;
        this.subject = subject;
    }

    public override void UpdateSelf()
    {
        Debug.Log("学生:" + name + "老师安排的任务是:" + subject.TeacherState);
    }
}
