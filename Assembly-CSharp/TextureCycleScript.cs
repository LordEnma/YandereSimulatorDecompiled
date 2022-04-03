using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001ECA RID: 7882 RVA: 0x001B2466 File Offset: 0x001B0666
	private void Awake()
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001ECB RID: 7883 RVA: 0x001B2468 File Offset: 0x001B0668
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001ECC RID: 7884 RVA: 0x001B2478 File Offset: 0x001B0678
	private void Update()
	{
		this.ID++;
		if (this.ID > 1)
		{
			this.ID = 0;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.Sprite.mainTexture = this.Textures[this.Frame];
	}

	// Token: 0x04003FE0 RID: 16352
	public UITexture Sprite;

	// Token: 0x04003FE1 RID: 16353
	[SerializeField]
	private int Start;

	// Token: 0x04003FE2 RID: 16354
	[SerializeField]
	private int Frame;

	// Token: 0x04003FE3 RID: 16355
	[SerializeField]
	private int Limit;

	// Token: 0x04003FE4 RID: 16356
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003FE5 RID: 16357
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003FE6 RID: 16358
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003FE7 RID: 16359
	public int ID;
}
