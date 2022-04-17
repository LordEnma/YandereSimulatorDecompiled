using System;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001AC3 RID: 6851 RVA: 0x00121A8C File Offset: 0x0011FC8C
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C78 RID: 11384
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C79 RID: 11385
	public Texture[] EightiesPhoto;
}
