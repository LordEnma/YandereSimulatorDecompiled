using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001237 RID: 4663 RVA: 0x0008BBD0 File Offset: 0x00089DD0
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

	// Token: 0x040016E3 RID: 5859
	public Renderer MyRenderer;

	// Token: 0x040016E4 RID: 5860
	public Texture[] Textures;

	// Token: 0x040016E5 RID: 5861
	public int ID = 1;
}
