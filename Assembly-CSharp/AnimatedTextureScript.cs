using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class AnimatedTextureScript : MonoBehaviour
{
	// Token: 0x060009BE RID: 2494 RVA: 0x000514B7 File Offset: 0x0004F6B7
	private void Awake()
	{
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060009BF RID: 2495 RVA: 0x000514B9 File Offset: 0x0004F6B9
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000514C8 File Offset: 0x0004F6C8
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

	// Token: 0x04000A23 RID: 2595
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04000A24 RID: 2596
	[SerializeField]
	private int Start;

	// Token: 0x04000A25 RID: 2597
	[SerializeField]
	private int Frame;

	// Token: 0x04000A26 RID: 2598
	[SerializeField]
	private int Limit;

	// Token: 0x04000A27 RID: 2599
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A28 RID: 2600
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04000A29 RID: 2601
	public Texture[] Image;
}
