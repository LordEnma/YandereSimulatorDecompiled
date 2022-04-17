using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B3346 File Offset: 0x001B1546
	private void Awake()
	{
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001ED9 RID: 7897 RVA: 0x001B3348 File Offset: 0x001B1548
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B3358 File Offset: 0x001B1558
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

	// Token: 0x04003FF3 RID: 16371
	public UITexture Sprite;

	// Token: 0x04003FF4 RID: 16372
	[SerializeField]
	private int Start;

	// Token: 0x04003FF5 RID: 16373
	[SerializeField]
	private int Frame;

	// Token: 0x04003FF6 RID: 16374
	[SerializeField]
	private int Limit;

	// Token: 0x04003FF7 RID: 16375
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003FF8 RID: 16376
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003FF9 RID: 16377
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003FFA RID: 16378
	public int ID;
}
