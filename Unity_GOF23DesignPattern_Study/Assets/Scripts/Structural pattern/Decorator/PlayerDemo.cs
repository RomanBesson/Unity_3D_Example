using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : MonoBehaviour {

    private Player player;
    private Fashion fashion;
    private Title title;
    private int index;

	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        fashion = new Fashion();
        title = new Title();
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            fashion.SetFashion(index, player);
            title.SetDecorator(player);
            title.SetTitle(index);
        }


	}
}
