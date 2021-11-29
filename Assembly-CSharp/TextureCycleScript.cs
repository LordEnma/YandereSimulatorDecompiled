using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E7E RID: 7806 RVA: 0x001AAE7A File Offset: 0x001A907A
	private void Awake()
	{
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06001E7F RID: 7807 RVA: 0x001AAE7C File Offset: 0x001A907C
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x001AAE8C File Offset: 0x001A908C
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

	// Token: 0x04003ED7 RID: 16087
	public UITexture Sprite;

	// Token: 0x04003ED8 RID: 16088
	[SerializeField]
	private int Start;

	// Token: 0x04003ED9 RID: 16089
	[SerializeField]
	private int Frame;

	// Token: 0x04003EDA RID: 16090
	[SerializeField]
	private int Limit;

	// Token: 0x04003EDB RID: 16091
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003EDC RID: 16092
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003EDD RID: 16093
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003EDE RID: 16094
	public int ID;
}
