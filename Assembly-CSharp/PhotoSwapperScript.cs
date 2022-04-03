using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001AB9 RID: 6841 RVA: 0x001215B4 File Offset: 0x0011F7B4
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C6D RID: 11373
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C6E RID: 11374
	public Texture[] EightiesPhoto;
}
