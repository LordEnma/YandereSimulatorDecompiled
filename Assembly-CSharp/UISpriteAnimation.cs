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
	// (get) Token: 0x06000874 RID: 2164 RVA: 0x00045E74 File Offset: 0x00044074
	public int frames
	{
		get
		{
			return this.mSpriteNames.Count;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000875 RID: 2165 RVA: 0x00045E81 File Offset: 0x00044081
	// (set) Token: 0x06000876 RID: 2166 RVA: 0x00045E89 File Offset: 0x00044089
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
	// (get) Token: 0x06000877 RID: 2167 RVA: 0x00045E92 File Offset: 0x00044092
	// (set) Token: 0x06000878 RID: 2168 RVA: 0x00045E9A File Offset: 0x0004409A
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
	// (get) Token: 0x06000879 RID: 2169 RVA: 0x00045EB7 File Offset: 0x000440B7
	// (set) Token: 0x0600087A RID: 2170 RVA: 0x00045EBF File Offset: 0x000440BF
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
	// (get) Token: 0x0600087B RID: 2171 RVA: 0x00045EC8 File Offset: 0x000440C8
	public bool isPlaying
	{
		get
		{
			return this.mActive;
		}
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00045ED0 File Offset: 0x000440D0
	protected virtual void Start()
	{
		this.RebuildSpriteList();
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00045ED8 File Offset: 0x000440D8
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

	// Token: 0x0600087E RID: 2174 RVA: 0x00045FD8 File Offset: 0x000441D8
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

	// Token: 0x0600087F RID: 2175 RVA: 0x00046088 File Offset: 0x00044288
	public void Play()
	{
		this.mActive = true;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00046091 File Offset: 0x00044291
	public void Pause()
	{
		this.mActive = false;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x0004609C File Offset: 0x0004429C
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

	// Token: 0x04000761 RID: 1889
	public int frameIndex;

	// Token: 0x04000762 RID: 1890
	[HideInInspector]
	[SerializeField]
	protected int mFPS = 30;

	// Token: 0x04000763 RID: 1891
	[HideInInspector]
	[SerializeField]
	protected string mPrefix = "";

	// Token: 0x04000764 RID: 1892
	[HideInInspector]
	[SerializeField]
	protected bool mLoop = true;

	// Token: 0x04000765 RID: 1893
	[HideInInspector]
	[SerializeField]
	protected bool mSnap = true;

	// Token: 0x04000766 RID: 1894
	protected UISprite mSprite;

	// Token: 0x04000767 RID: 1895
	protected float mDelta;

	// Token: 0x04000768 RID: 1896
	protected bool mActive = true;

	// Token: 0x04000769 RID: 1897
	protected List<string> mSpriteNames = new List<string>();
}
