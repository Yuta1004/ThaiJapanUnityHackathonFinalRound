using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAnimationCharacter : MonoBehaviour {
	public String animationName;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent (typeof(Animator)) as Animator;
	}
	
	// Update is called once per frame
	void Update () {
		if(!animator.GetCurrentAnimatorStateInfo(0).shortNameHash.Equals(Animator.StringToHash(animationName))){
			animator.Play(animationName);
		}
	}
	
	public void OnCallChangeFace(){}

}
