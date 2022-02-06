using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AA RID: 170
[ExecuteInEditMode]
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000874 RID: 2164 RVA: 0x00045D7C File Offset: 0x00043F7C
	public int frames
	{
		get
		{
			return this.mSpriteNames.Count;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000875 RID: 2165 RVA: 0x00045D89 File Offset: 0x00043F89
	// (set) Token: 0x06000876 RID: 2166 RVA: 0x00045D91 File Offset: 0x00043F91
	public int framesPerSecond
	{
		get
		{
			return this.mFPS;
		}
		set
		{
			this.mFPS = value;
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000877 RID: 2167 RVA: 0x00045D9A File Offset: 0x00043F9A
	// (set) Token: 0x06000878 RID: 2168 RVA: 0x00045DA2 File Offset: 0x00043FA2
	public string namePrefix
	{
		get
		{
			return this.mPrefix;
		}
		set
		{
			if (this.mPrefix != value)
			{
				this.mPrefix = value;
				this.RebuildSpriteList();
			}
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06000879 RID: 2169 RVA: 0x00045DBF File Offset: 0x00043FBF
	// (set) Token: 0x0600087A RID: 2170 RVA: 0x00045DC7 File Offset: 0x00043FC7
	public bool loop
	{
		get
		{
			return this.mLoop;
		}
		set
		{
			this.mLoop = value;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x0600087B RID: 2171 RVA: 0x00045DD0 File Offset: 0x00043FD0
	public bool isPlaying
	{
		get
		{
			return this.mActive;
		}
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00045DD8 File Offset: 0x00043FD8
	protected virtual void Start()
	{
		this.RebuildSpriteList();
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00045DE0 File Offset: 0x00043FE0
	protected virtual void Update()
	{
		if (this.mActive && this.mSpriteNames.Count > 1 && Application.isPlaying && this.mFPS > 0)
		{
			this.mDelta += Mathf.Min(1f, RealTime.deltaTime);
			float num = 1f / (float)this.mFPS;
			while (num < this.mDelta)
			{
				this.mDelta = ((num > 0f) ? (this.mDelta - num) : 0f);
				int num2 = this.frameIndex + 1;
				this.frameIndex = num2;
				if (num2 >= this.mSpriteNames.Count)
				{
					this.frameIndex = 0;
					this.mActive = this.mLoop;
				}
				if (this.mActive)
				{
					this.mSprite.spriteName = this.mSpriteNames[this.frameIndex];
					if (this.mSnap)
					{
						this.mSprite.MakePixelPerfect();
					}
				}
			}
		}
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x00045EE0 File Offset: 0x000440E0
	public void RebuildSpriteList()
	{
		if (this.mSprite == null)
		{
			this.mSprite = base.GetComponent<UISprite>();
		}
		this.mSpriteNames.Clear();
		if (this.mSprite != null)
		{
			INGUIAtlas atlas = this.mSprite.atlas;
			if (atlas != null)
			{
				List<UISpriteData> spriteList = atlas.spriteList;
				int i = 0;
				int count = spriteList.Count;
				while (i < count)
				{
					UISpriteData uispriteData = spriteList[i];
					if (string.IsNullOrEmpty(this.mPrefix) || uispriteData.name.StartsWith(this.mPrefix))
					{
						this.mSpriteNames.Add(uispriteData.name);
					}
					i++;
				}
				this.mSpriteNames.Sort();
			}
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x00045F90 File Offset: 0x00044190
	public void Play()
	{
		this.mActive = true;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00045F99 File Offset: 0x00044199
	public void Pause()
	{
		this.mActive = false;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00045FA4 File Offset: 0x000441A4
	public void ResetToBeginning()
	{
		this.mActive = true;
		this.frameIndex = 0;
		if (this.mSprite != null && this.mSpriteNames.Count > 0)
		{
			this.mSprite.spriteName = this.mSpriteNames[this.frameIndex];
			if (this.mSnap)
			{
				this.mSprite.MakePixelPerfect();
			}
		}
	}

	// Token: 0x04000758 RID: 1880
	public int frameIndex;

	// Token: 0x04000759 RID: 1881
	[HideInInspector]
	[SerializeField]
	protected int mFPS = 30;

	// Token: 0x0400075A RID: 1882
	[HideInInspector]
	[SerializeField]
	protected string mPrefix = "";

	// Token: 0x0400075B RID: 1883
	[HideInInspector]
	[SerializeField]
	protected bool mLoop = true;

	// Token: 0x0400075C RID: 1884
	[HideInInspector]
	[SerializeField]
	protected bool mSnap = true;

	// Token: 0x0400075D RID: 1885
	protected UISprite mSprite;

	// Token: 0x0400075E RID: 1886
	protected float mDelta;

	// Token: 0x0400075F RID: 1887
	protected bool mActive = true;

	// Token: 0x04000760 RID: 1888
	protected List<string> mSpriteNames = new List<string>();
}
