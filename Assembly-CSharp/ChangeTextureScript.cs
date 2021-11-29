using System;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class ChangeTextureScript : MonoBehaviour
{
	// Token: 0x06001233 RID: 4659 RVA: 0x0008B774 File Offset: 0x00089974
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

	// Token: 0x040016DB RID: 5851
	public Renderer MyRenderer;

	// Token: 0x040016DC RID: 5852
	public Texture[] Textures;

	// Token: 0x040016DD RID: 5853
	public int ID = 1;
}
