using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorValue : MonoBehaviour {
	public Animator animator;
	public string name1;

	public bool value;

	public void SetValue() {
		animator.SetBool(name1, value);
	}

	// Use this for initialization
	
}
