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
	// (get) Token: 0x06000874 RID: 2164 RVA: 0x00045F2C File Offset: 0x0004412C
	public int frames
	{
		get
		{
			return this.mSpriteNames.Count;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000875 RID: 2165 RVA: 0x00045F39 File Offset: 0x00044139
	// (set) Token: 0x06000876 RID: 2166 RVA: 0x00045F41 File Offset: 0x00044141
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
	// (get) Token: 0x06000877 RID: 2167 RVA: 0x00045F4A File Offset: 0x0004414A
	// (set) Token: 0x06000878 RID: 2168 RVA: 0x00045F52 File Offset: 0x00044152
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
	// (get) Token: 0x06000879 RID: 2169 RVA: 0x00045F6F File Offset: 0x0004416F
	// (set) Token: 0x0600087A RID: 2170 RVA: 0x00045F77 File Offset: 0x00044177
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
	// (get) Token: 0x0600087B RID: 2171 RVA: 0x00045F80 File Offset: 0x00044180
	public bool isPlaying
	{
		get
		{
			return this.mActive;
		}
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00045F88 File Offset: 0x00044188
	protected virtual void Start()
	{
		this.RebuildSpriteList();
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00045F90 File Offset: 0x00044190
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

	// Token: 0x0600087E RID: 2174 RVA: 0x00046090 File Offset: 0x00044290
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

	// Token: 0x0600087F RID: 2175 RVA: 0x00046140 File Offset: 0x00044340
	public void Play()
	{
		this.mActive = true;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00046149 File Offset: 0x00044349
	public void Pause()
	{
		this.mActive = false;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00046154 File Offset: 0x00044354
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
