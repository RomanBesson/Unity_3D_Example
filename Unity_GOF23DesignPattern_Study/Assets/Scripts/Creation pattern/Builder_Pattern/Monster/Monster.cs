using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物的实体类
/// </summary>
public class Monster : MonoBehaviour {

    //定义字段/属性：id，名字，血量，音效，特效，血条；

    private int id;
    private string name;
    private int lifeValue;
    private string audios;
    private string effects;
    private string bloodBar;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int LifeValue
    {
        get { return lifeValue; }
        set { lifeValue = value; }
    }

    public string Audios
    {
        get { return audios; }
        set { audios = value; }
    }

    public string Effects
    {
        get { return effects; }
        set { effects = value; }
    }

    public string BloodBar
    {
        get { return bloodBar; }
        set { bloodBar = value; }
    }

    //定义构造方法：通过id，名字，血量完成构造；

    public void InitMonster(int id, string name, int lifeValue)
    {
        this.id = id;
        this.name = name;
        this.lifeValue = lifeValue;
    }


    //定义行为方法：显示血条，释放特效，播放音效；

    public void ShowBloodBar()
    {
        Debug.Log("当前小怪的血条:" + bloodBar);
    }

    public void ShowEffects()
    {
        Debug.Log("释放特效:" + effects);
    }

    public void PlayAudios()
    {
        Debug.Log("播放音效:" + audios);
    }
}
