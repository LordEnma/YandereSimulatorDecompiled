using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class MusicRippleScript : MonoBehaviour
{
	// Token: 0x0600005A RID: 90 RVA: 0x000097EC File Offset: 0x000079EC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame == this.Sprite.Length)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
		}
	}

	// Token: 0x04000161 RID: 353
	public Renderer MyRenderer;

	// Token: 0x04000162 RID: 354
	public Texture[] Sprite;

	// Token: 0x04000163 RID: 355
	public float Timer;

	// Token: 0x04000164 RID: 356
	public float FPS;

	// Token: 0x04000165 RID: 357
	public int Frame;
}
