using UnityEngine;
using System.Collections;

public class MyKinectOperate  {

	public Texture2D GetKinectImg()
	{
		KinectManager km = KinectManager.Instance;
		return km.GetUsersClrTex ();
	}

	public Texture2D GetKinectDepth()
	{
		KinectManager km = KinectManager.Instance;
		return km.GetUsersLblTex ();
	}
	public Texture2D GetKinectColorDepth()
	{
		KinectManager km = KinectManager.Instance;
		return km.GetUsersClrLblTex ();

	}

}
