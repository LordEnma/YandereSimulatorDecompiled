using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class AnimatedTextureScript : MonoBehaviour
{
	// Token: 0x060009BE RID: 2494 RVA: 0x000510BB File Offset: 0x0004F2BB
	private void Awake()
	{
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060009BF RID: 2495 RVA: 0x000510BD File Offset: 0x0004F2BD
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000510CC File Offset: 0x0004F2CC
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

	// Token: 0x04000A15 RID: 2581
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04000A16 RID: 2582
	[SerializeField]
	private int Start;

	// Token: 0x04000A17 RID: 2583
	[SerializeField]
	private int Frame;

	// Token: 0x04000A18 RID: 2584
	[SerializeField]
	private int Limit;

	// Token: 0x04000A19 RID: 2585
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A1A RID: 2586
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04000A1B RID: 2587
	public Texture[] Image;
}
