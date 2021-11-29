using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class MGPMWaterScript : MonoBehaviour
{
	// Token: 0x0600004A RID: 74 RVA: 0x00007418 File Offset: 0x00005618
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame == this.Sprite.Length)
			{
				this.Frame = 0;
			}
			this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
		}
		base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y - this.Speed * Time.deltaTime, 3f);
		if (base.transform.localPosition.y < -640f)
		{
			base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y + 1280f, 3f);
		}
	}

	// Token: 0x04000109 RID: 265
	public Renderer MyRenderer;

	// Token: 0x0400010A RID: 266
	public Texture[] Sprite;

	// Token: 0x0400010B RID: 267
	public float Speed;

	// Token: 0x0400010C RID: 268
	public float Timer;

	// Token: 0x0400010D RID: 269
	public float FPS;

	// Token: 0x0400010E RID: 270
	public int Frame;
}
