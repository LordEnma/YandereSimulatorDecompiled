using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class AnimatedTextureScript : MonoBehaviour
{
	// Token: 0x060009BE RID: 2494 RVA: 0x000511C7 File Offset: 0x0004F3C7
	private void Awake()
	{
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060009BF RID: 2495 RVA: 0x000511C9 File Offset: 0x0004F3C9
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000511D8 File Offset: 0x0004F3D8
	private void Update()
	{
		this.CurrentSeconds += Time.unscaledDeltaTime;
		while (this.CurrentSeconds >= this.SecondsPerFrame)
		{
			this.CurrentSeconds -= this.SecondsPerFrame;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.MyRenderer.material.mainTexture = this.Image[this.Frame];
	}

	// Token: 0x04000A17 RID: 2583
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04000A18 RID: 2584
	[SerializeField]
	private int Start;

	// Token: 0x04000A19 RID: 2585
	[SerializeField]
	private int Frame;

	// Token: 0x04000A1A RID: 2586
	[SerializeField]
	private int Limit;

	// Token: 0x04000A1B RID: 2587
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A1C RID: 2588
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04000A1D RID: 2589
	public Texture[] Image;
}
