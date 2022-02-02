using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E98 RID: 7832 RVA: 0x001ADB9E File Offset: 0x001ABD9E
	private void Awake()
	{
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E99 RID: 7833 RVA: 0x001ADBA0 File Offset: 0x001ABDA0
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E9A RID: 7834 RVA: 0x001ADBB0 File Offset: 0x001ABDB0
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

	// Token: 0x04003F30 RID: 16176
	public UITexture Sprite;

	// Token: 0x04003F31 RID: 16177
	[SerializeField]
	private int Start;

	// Token: 0x04003F32 RID: 16178
	[SerializeField]
	private int Frame;

	// Token: 0x04003F33 RID: 16179
	[SerializeField]
	private int Limit;

	// Token: 0x04003F34 RID: 16180
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F35 RID: 16181
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F36 RID: 16182
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F37 RID: 16183
	public int ID;
}
