using UnityEngine;
using System.Collections;

public class ColorImgShow : MonoBehaviour {
	MyKinectOperate mko;
	// Use this for initialization
	void Start () {
		mko = new MyKinectOperate ();
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer> ().material.mainTexture = mko.GetKinectColorDepth ();
	}
}
