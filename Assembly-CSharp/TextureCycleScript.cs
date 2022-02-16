using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AE582 File Offset: 0x001AC782
	private void Awake()
	{
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001EA5 RID: 7845 RVA: 0x001AE584 File Offset: 0x001AC784
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AE594 File Offset: 0x001AC794
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

	// Token: 0x04003F42 RID: 16194
	public UITexture Sprite;

	// Token: 0x04003F43 RID: 16195
	[SerializeField]
	private int Start;

	// Token: 0x04003F44 RID: 16196
	[SerializeField]
	private int Frame;

	// Token: 0x04003F45 RID: 16197
	[SerializeField]
	private int Limit;

	// Token: 0x04003F46 RID: 16198
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F47 RID: 16199
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F48 RID: 16200
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F49 RID: 16201
	public int ID;
}
