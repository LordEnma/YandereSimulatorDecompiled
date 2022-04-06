using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B29F4 File Offset: 0x001B0BF4
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

	// Token: 0x04003FEB RID: 16363
	public Texture[] UniformTextures;

	// Token: 0x04003FEC RID: 16364
	public Texture[] CasualTextures;

	// Token: 0x04003FED RID: 16365
	public Texture[] SocksTextures;

	// Token: 0x04003FEE RID: 16366
	public Texture2D PurpleStockings;

	// Token: 0x04003FEF RID: 16367
	public Texture2D GreenStockings;

	// Token: 0x04003FF0 RID: 16368
	public Texture2D Base2D;

	// Token: 0x04003FF1 RID: 16369
	public Texture2D Overlay2D;
}
