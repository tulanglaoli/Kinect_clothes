using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {
	MyKinectOperate mko;
	public GameObject plane;
	// Use this for initialization
	void Start () {
		mko = new MyKinectOperate ();
	}
	
	// Update is called once per frame
	void Update () {
		plane.GetComponent<Renderer> ().material.mainTexture = mko.GetKinectImg ();
	}
}
