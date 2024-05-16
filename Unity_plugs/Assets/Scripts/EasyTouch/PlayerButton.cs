using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour {

    private ETCButton m_Button;
   // private Animator player_Animator;

	void Start () {

        //player_Animator = GameObject.Find("RoyalKnight").GetComponent<Animator>();

        m_Button = gameObject.GetComponent<ETCButton>();
        m_Button.onPressed.AddListener(() => Debug.Log("onPressed"));
       // m_Button.onDown.AddListener(() => player_Animator.SetTrigger("attack2"));
        m_Button.onUp.AddListener(() => Debug.Log("onUp"));
        m_Button.onPressedValue.AddListener((f) => Debug.Log("onPressedValue:" + f));
	}
	
}
