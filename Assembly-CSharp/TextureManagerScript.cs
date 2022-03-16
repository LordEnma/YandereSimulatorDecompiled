using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EC4 RID: 7876 RVA: 0x001B0F78 File Offset: 0x001AF178
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

	// Token: 0x04003FBB RID: 16315
	public Texture[] UniformTextures;

	// Token: 0x04003FBC RID: 16316
	public Texture[] CasualTextures;

	// Token: 0x04003FBD RID: 16317
	public Texture[] SocksTextures;

	// Token: 0x04003FBE RID: 16318
	public Texture2D PurpleStockings;

	// Token: 0x04003FBF RID: 16319
	public Texture2D GreenStockings;

	// Token: 0x04003FC0 RID: 16320
	public Texture2D Base2D;

	// Token: 0x04003FC1 RID: 16321
	public Texture2D Overlay2D;
}
