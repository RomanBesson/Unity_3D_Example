using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 帮子线程调用Unity方法的类
/// </summary>
public class HandlerThread : MonoBehaviour {

    public static HandlerThread Instance;
    private List<NormalDelegate> DelegateList = null;

	void Awake () {
        Instance = this;
	}

    void Start()
    {
        DelegateList = new List<NormalDelegate>();
        StartCoroutine("ChildThread");
    }


    private IEnumerator ChildThread()
    {
        while (true)
        {
            if(DelegateList.Count > 0)
            {
                foreach (NormalDelegate item in DelegateList)
                {
                    item();
                }
                DelegateList.Clear();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }


    public void AddDelegate(NormalDelegate del)
    {
        DelegateList.Add(del);
    }
}
