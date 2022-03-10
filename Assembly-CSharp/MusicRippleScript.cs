using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class MusicRippleScript : MonoBehaviour
{
	// Token: 0x0600005A RID: 90 RVA: 0x000098E4 File Offset: 0x00007AE4
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

	// Token: 0x0400016A RID: 362
	public Renderer MyRenderer;

	// Token: 0x0400016B RID: 363
	public Texture[] Sprite;

	// Token: 0x0400016C RID: 364
	public float Timer;

	// Token: 0x0400016D RID: 365
	public float FPS;

	// Token: 0x0400016E RID: 366
	public int Frame;
}
