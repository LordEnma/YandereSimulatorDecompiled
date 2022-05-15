using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PhotoSwapperScript : MonoBehaviour
{
	// Token: 0x06001ACD RID: 6861 RVA: 0x00122958 File Offset: 0x00120B58
	private void Start()
	{
		for (int i = 1; i < this.PhotoRenderer.Length; i++)
		{
			this.PhotoRenderer[i].material.mainTexture = this.EightiesPhoto[i];
		}
	}

	// Token: 0x04002C93 RID: 11411
	public Renderer[] PhotoRenderer;

	// Token: 0x04002C94 RID: 11412
	public Texture[] EightiesPhoto;
}
