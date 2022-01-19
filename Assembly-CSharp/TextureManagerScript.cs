using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001E9B RID: 7835 RVA: 0x001AD790 File Offset: 0x001AB990
	public Texture2D MergeTextures(Texture2D BackgroundTex, Texture2D TopTex)
	{
		Texture2D texture2D = new Texture2D(1024, 1024);
		Color32[] pixels = BackgroundTex.GetPixels32();
		Color32[] pixels2 = TopTex.GetPixels32();
		for (int i = 0; i < pixels2.Length; i++)
		{
			if (pixels2[i].a != 0)
			{
				pixels[i] = pixels2[i];
			}
		}
		texture2D.SetPixels32(pixels);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x04003F31 RID: 16177
	public Texture[] UniformTextures;

	// Token: 0x04003F32 RID: 16178
	public Texture[] CasualTextures;

	// Token: 0x04003F33 RID: 16179
	public Texture[] SocksTextures;

	// Token: 0x04003F34 RID: 16180
	public Texture2D PurpleStockings;

	// Token: 0x04003F35 RID: 16181
	public Texture2D GreenStockings;

	// Token: 0x04003F36 RID: 16182
	public Texture2D Base2D;

	// Token: 0x04003F37 RID: 16183
	public Texture2D Overlay2D;
}
