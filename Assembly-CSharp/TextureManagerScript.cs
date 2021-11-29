using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001E82 RID: 7810 RVA: 0x001AAF00 File Offset: 0x001A9100
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

	// Token: 0x04003EDF RID: 16095
	public Texture[] UniformTextures;

	// Token: 0x04003EE0 RID: 16096
	public Texture[] CasualTextures;

	// Token: 0x04003EE1 RID: 16097
	public Texture[] SocksTextures;

	// Token: 0x04003EE2 RID: 16098
	public Texture2D PurpleStockings;

	// Token: 0x04003EE3 RID: 16099
	public Texture2D GreenStockings;

	// Token: 0x04003EE4 RID: 16100
	public Texture2D Base2D;

	// Token: 0x04003EE5 RID: 16101
	public Texture2D Overlay2D;
}
