using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EC0 RID: 7872 RVA: 0x001B0EF2 File Offset: 0x001AF0F2
	private void Awake()
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001EC1 RID: 7873 RVA: 0x001B0EF4 File Offset: 0x001AF0F4
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EC2 RID: 7874 RVA: 0x001B0F04 File Offset: 0x001AF104
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

	// Token: 0x04003FB3 RID: 16307
	public UITexture Sprite;

	// Token: 0x04003FB4 RID: 16308
	[SerializeField]
	private int Start;

	// Token: 0x04003FB5 RID: 16309
	[SerializeField]
	private int Frame;

	// Token: 0x04003FB6 RID: 16310
	[SerializeField]
	private int Limit;

	// Token: 0x04003FB7 RID: 16311
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003FB8 RID: 16312
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003FB9 RID: 16313
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003FBA RID: 16314
	public int ID;
}
