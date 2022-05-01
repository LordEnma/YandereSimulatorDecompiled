using System;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001AC7 RID: 6855 RVA: 0x00122028 File Offset: 0x00120228
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C81 RID: 11393
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C82 RID: 11394
	public Texture[] EightiesPhoto;
}
