using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class MGPMExplosionScript : MonoBehaviour
{
	// Token: 0x0600002C RID: 44 RVA: 0x00004A08 File Offset: 0x00002C08
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

	// Token: 0x04000085 RID: 133
	public Renderer MyRenderer;

	// Token: 0x04000086 RID: 134
	public Texture[] Sprite;

	// Token: 0x04000087 RID: 135
	public float Timer;

	// Token: 0x04000088 RID: 136
	public float FPS;

	// Token: 0x04000089 RID: 137
	public int Frame;
}
