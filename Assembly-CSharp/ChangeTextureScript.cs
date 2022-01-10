using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001236 RID: 4662 RVA: 0x0008B91C File Offset: 0x00089B1C
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

	// Token: 0x040016DD RID: 5853
	public Renderer MyRenderer;

	// Token: 0x040016DE RID: 5854
	public Texture[] Textures;

	// Token: 0x040016DF RID: 5855
	public int ID = 1;
}
