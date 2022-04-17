using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EDC RID: 7900 RVA: 0x001B33CC File Offset: 0x001B15CC
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

	// Token: 0x04003FFB RID: 16379
	public Texture[] UniformTextures;

	// Token: 0x04003FFC RID: 16380
	public Texture[] CasualTextures;

	// Token: 0x04003FFD RID: 16381
	public Texture[] SocksTextures;

	// Token: 0x04003FFE RID: 16382
	public Texture2D PurpleStockings;

	// Token: 0x04003FFF RID: 16383
	public Texture2D GreenStockings;

	// Token: 0x04004000 RID: 16384
	public Texture2D Base2D;

	// Token: 0x04004001 RID: 16385
	public Texture2D Overlay2D;
}
