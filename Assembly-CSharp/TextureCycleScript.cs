using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E9A RID: 7834 RVA: 0x001ADEAA File Offset: 0x001AC0AA
	private void Awake()
	{
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E9B RID: 7835 RVA: 0x001ADEAC File Offset: 0x001AC0AC
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E9C RID: 7836 RVA: 0x001ADEBC File Offset: 0x001AC0BC
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

	// Token: 0x04003F36 RID: 16182
	public UITexture Sprite;

	// Token: 0x04003F37 RID: 16183
	[SerializeField]
	private int Start;

	// Token: 0x04003F38 RID: 16184
	[SerializeField]
	private int Frame;

	// Token: 0x04003F39 RID: 16185
	[SerializeField]
	private int Limit;

	// Token: 0x04003F3A RID: 16186
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F3B RID: 16187
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F3C RID: 16188
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F3D RID: 16189
	public int ID;
}
