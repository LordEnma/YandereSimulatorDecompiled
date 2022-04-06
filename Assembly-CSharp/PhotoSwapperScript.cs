using System;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001ABF RID: 6847 RVA: 0x00121760 File Offset: 0x0011F960
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C70 RID: 11376
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C71 RID: 11377
	public Texture[] EightiesPhoto;
}
