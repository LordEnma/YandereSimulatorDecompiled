using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001236 RID: 4662 RVA: 0x0008B9F0 File Offset: 0x00089BF0
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

	// Token: 0x040016E2 RID: 5858
	public Renderer MyRenderer;

	// Token: 0x040016E3 RID: 5859
	public Texture[] Textures;

	// Token: 0x040016E4 RID: 5860
	public int ID = 1;
}
