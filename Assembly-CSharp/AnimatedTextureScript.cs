using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class AnimatedTextureScript : MonoBehaviour
{
	// Token: 0x060009BE RID: 2494 RVA: 0x000512BF File Offset: 0x0004F4BF
	private void Awake()
	{
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060009BF RID: 2495 RVA: 0x000512C1 File Offset: 0x0004F4C1
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000512D0 File Offset: 0x0004F4D0
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

	// Token: 0x04000A21 RID: 2593
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04000A22 RID: 2594
	[SerializeField]
	private int Start;

	// Token: 0x04000A23 RID: 2595
	[SerializeField]
	private int Frame;

	// Token: 0x04000A24 RID: 2596
	[SerializeField]
	private int Limit;

	// Token: 0x04000A25 RID: 2597
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A26 RID: 2598
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04000A27 RID: 2599
	public Texture[] Image;
}
