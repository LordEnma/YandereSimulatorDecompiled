using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001239 RID: 4665 RVA: 0x0008C194 File Offset: 0x0008A394
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			this.ID++;
			if (this.ID == this.Textures.Length)
			{
				this.ID = 1;
			}
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
	}

	// Token: 0x040016F3 RID: 5875
	public Renderer MyRenderer;

	// Token: 0x040016F4 RID: 5876
	public Texture[] Textures;

	// Token: 0x040016F5 RID: 5877
	public int ID = 1;
}
