using UnityEngine;
using System.Collections;


public class MyKinectInterface  {

	public Texture2D GetColorImage()
	{
		KinectManager manager = KinectManager.Instance;
		return manager.GetUsersLblTex ();
	}
}
