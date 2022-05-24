using System;
using UnityEngine;

// Token: 0x0200023D RID: 573
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x0600123B RID: 4667 RVA: 0x0008C744 File Offset: 0x0008A944
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

	// Token: 0x040016FC RID: 5884
	public Renderer MyRenderer;

	// Token: 0x040016FD RID: 5885
	public Texture[] Textures;

	// Token: 0x040016FE RID: 5886
	public int ID = 1;
}
