using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001237 RID: 4663 RVA: 0x0008BD18 File Offset: 0x00089F18
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

	// Token: 0x040016EC RID: 5868
	public Renderer MyRenderer;

	// Token: 0x040016ED RID: 5869
	public Texture[] Textures;

	// Token: 0x040016EE RID: 5870
	public int ID = 1;
}
