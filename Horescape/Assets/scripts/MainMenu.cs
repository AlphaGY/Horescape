using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	private Vector3 offset;
	private Transform crawlerTrans;
	public Animator anim;

	// Use this for initialization
	void Start () {
		crawlerTrans = GameObject.FindGameObjectWithTag ("crawler").transform;
	}
	
	// Update is called once per frame
	void Update () {
		offset.x = crawlerTrans.position.x;
		if (crawlerTrans.position.z > 15) {
			offset.z = crawlerTrans.position.z - Time.deltaTime * 1.5f;
		}
		else if (crawlerTrans.position.z > 14) {
		anim.SetBool ("craw_fast", true);
		}

		offset.y = crawlerTrans.position.y;
		crawlerTrans.position = offset;


	}

	public void Sstart(){
		

		//anim.SetBool ("DoorStartOpen",true);
		SceneManager.LoadScene ("prototype");
	}
}
