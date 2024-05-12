using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象主题角色.
/// </summary>
public abstract class TeacherSubject:MonoBehaviour {

    private List<StudentObserver> observerList = new List<StudentObserver>();

    public void Add(StudentObserver observer)
    {
        observerList.Add(observer);
    }

    public void Remove(StudentObserver observer)
    {
        observerList.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observerList.Count; i++)
        {
            observerList[i].UpdateSelf();
        }
    }

}
