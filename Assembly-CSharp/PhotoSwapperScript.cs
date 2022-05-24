using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001ACE RID: 6862 RVA: 0x00122B88 File Offset: 0x00120D88
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C9A RID: 11418
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C9B RID: 11419
	public Texture[] EightiesPhoto;
}
