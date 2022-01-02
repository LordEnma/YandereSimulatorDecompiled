using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E8A RID: 7818 RVA: 0x001AC0BA File Offset: 0x001AA2BA
	private void Awake()
	{
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E8B RID: 7819 RVA: 0x001AC0BC File Offset: 0x001AA2BC
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x001AC0CC File Offset: 0x001AA2CC
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

	// Token: 0x04003F0E RID: 16142
	public UITexture Sprite;

	// Token: 0x04003F0F RID: 16143
	[SerializeField]
	private int Start;

	// Token: 0x04003F10 RID: 16144
	[SerializeField]
	private int Frame;

	// Token: 0x04003F11 RID: 16145
	[SerializeField]
	private int Limit;

	// Token: 0x04003F12 RID: 16146
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F13 RID: 16147
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F14 RID: 16148
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F15 RID: 16149
	public int ID;
}
