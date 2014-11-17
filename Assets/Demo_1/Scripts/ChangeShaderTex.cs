using UnityEngine;
using System.Collections;

public class ChangeShaderTex : MonoBehaviour {

	private Material Mainrander;
	private MyKinectInterface MKI;
	public Texture test;
	// Use this for initialization
	void Start () {
		Mainrander = this.GetComponent<Renderer>().materials [0];
		//MKI = new MyKinectInterface ();
	}
	
	// Update is called once per frame
	void Update () {
		KinectManager manager = KinectManager.Instance;
		Mainrander.SetTexture("_Detail",manager.GetUsersLblTex ());
	}

	void OnGUI()
	{
		KinectManager manager = KinectManager.Instance;
		GUI.DrawTexture(new Rect(100,100,100,100),test);
		//GUI.DrawTexture(new Rect(100,100,100,100), MKI.GetColorImage());
	}
}
