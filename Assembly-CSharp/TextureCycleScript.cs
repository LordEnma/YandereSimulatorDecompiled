using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E95 RID: 7829 RVA: 0x001ACA3A File Offset: 0x001AAC3A
	private void Awake()
	{
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E96 RID: 7830 RVA: 0x001ACA3C File Offset: 0x001AAC3C
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E97 RID: 7831 RVA: 0x001ACA4C File Offset: 0x001AAC4C
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

	// Token: 0x04003F22 RID: 16162
	public UITexture Sprite;

	// Token: 0x04003F23 RID: 16163
	[SerializeField]
	private int Start;

	// Token: 0x04003F24 RID: 16164
	[SerializeField]
	private int Frame;

	// Token: 0x04003F25 RID: 16165
	[SerializeField]
	private int Limit;

	// Token: 0x04003F26 RID: 16166
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F27 RID: 16167
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F28 RID: 16168
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F29 RID: 16169
	public int ID;
}
