using UnityEngine;
using System.Collections;

public static class InitSet  {

	public static void  InitTexture( Texture2D Tex)
	{
		Tex.wrapMode = TextureWrapMode.Repeat;
		Tex.filterMode = FilterMode.Bilinear;
		Tex.anisoLevel = 9;
		//Tex.Compress (true);
	}
}
