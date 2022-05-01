using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001239 RID: 4665 RVA: 0x0008C3EC File Offset: 0x0008A5EC
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

	// Token: 0x040016F6 RID: 5878
	public Renderer MyRenderer;

	// Token: 0x040016F7 RID: 5879
	public Texture[] Textures;

	// Token: 0x040016F8 RID: 5880
	public int ID = 1;
}
