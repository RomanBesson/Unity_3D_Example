using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            //构建Boss
            Director director = new Director();
            Builder builder = new BossBuilder(2, "QQ", 99999999);
            director.Construct(builder);

            //测试
            GameObject Boss = builder.GetResult();
            Monster m1 = Boss.GetComponent<Monster>();

            m1.PlayAudios();
            m1.ShowBloodBar();
            m1.ShowEffects();

            //构建小怪
            Builder builder_new = new MonsterBuilder(1, "QQ", 999);
            director.Construct(builder);

            //测试
            GameObject monster = builder.GetResult();
            Monster m2 = monster.GetComponent<Monster>();

            m1.PlayAudios();
            m1.ShowBloodBar();
            m1.ShowEffects();
        }
		
	}
}
