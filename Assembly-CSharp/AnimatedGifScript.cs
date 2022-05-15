using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class AnimatedGifScript : MonoBehaviour
{
	// Token: 0x060009BA RID: 2490 RVA: 0x000514E2 File Offset: 0x0004F6E2
	private void Awake()
	{
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060009BB RID: 2491 RVA: 0x000514E4 File Offset: 0x0004F6E4
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x000514F4 File Offset: 0x0004F6F4
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
		this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
	}

	// Token: 0x04000A1C RID: 2588
	[SerializeField]
	private UISprite Sprite;

	// Token: 0x04000A1D RID: 2589
	[SerializeField]
	private string SpriteName;

	// Token: 0x04000A1E RID: 2590
	[SerializeField]
	private int Start;

	// Token: 0x04000A1F RID: 2591
	[SerializeField]
	private int Frame;

	// Token: 0x04000A20 RID: 2592
	[SerializeField]
	private int Limit;

	// Token: 0x04000A21 RID: 2593
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A22 RID: 2594
	[SerializeField]
	private float CurrentSeconds;
}
