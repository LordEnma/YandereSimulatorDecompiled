using System;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class UI2DSpriteAnimation : MonoBehaviour
{
	// Token: 0x17000115 RID: 277
	// (get) Token: 0x0600068F RID: 1679 RVA: 0x00037FA3 File Offset: 0x000361A3
	public bool isPlaying
	{
		get
		{
			return base.enabled;
		}
	}

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06000690 RID: 1680 RVA: 0x00037FAB File Offset: 0x000361AB
	// (set) Token: 0x06000691 RID: 1681 RVA: 0x00037FB3 File Offset: 0x000361B3
	public int framesPerSecond
	{
		get
		{
			return this.framerate;
		}
		set
		{
			this.framerate = value;
		}
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00037FBC File Offset: 0x000361BC
	public void Play()
	{
		if (this.frames != null && this.frames.Length != 0)
		{
			if (!base.enabled && !this.loop)
			{
				int num = (this.framerate > 0) ? (this.frameIndex + 1) : (this.frameIndex - 1);
				if (num < 0 || num >= this.frames.Length)
				{
					this.frameIndex = ((this.framerate < 0) ? (this.frames.Length - 1) : 0);
				}
			}
			base.enabled = true;
			this.UpdateSprite();
		}
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x0003803E File Offset: 0x0003623E
	public void Pause()
	{
		base.enabled = false;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00038047 File Offset: 0x00036247
	public void ResetToBeginning()
	{
		this.frameIndex = ((this.framerate < 0) ? (this.frames.Length - 1) : 0);
		this.UpdateSprite();
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0003806B File Offset: 0x0003626B
	private void Start()
	{
		this.Play();
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00038074 File Offset: 0x00036274
	private void Update()
	{
		if (this.frames == null || this.frames.Length == 0)
		{
			base.enabled = false;
			return;
		}
		if (this.framerate != 0)
		{
			float num = this.ignoreTimeScale ? RealTime.time : Time.time;
			if (this.mUpdate < num)
			{
				this.mUpdate = num;
				int num2 = (this.framerate > 0) ? (this.frameIndex + 1) : (this.frameIndex - 1);
				if (!this.loop && (num2 < 0 || num2 >= this.frames.Length))
				{
					base.enabled = false;
					return;
				}
				this.frameIndex = NGUIMath.RepeatIndex(num2, this.frames.Length);
				this.UpdateSprite();
			}
		}
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x0003811C File Offset: 0x0003631C
	private void UpdateSprite()
	{
		if (this.mUnitySprite == null && this.mNguiSprite == null)
		{
			this.mUnitySprite = base.GetComponent<SpriteRenderer>();
			this.mNguiSprite = base.GetComponent<UI2DSprite>();
			if (this.mUnitySprite == null && this.mNguiSprite == null)
			{
				base.enabled = false;
				return;
			}
		}
		float num = this.ignoreTimeScale ? RealTime.time : Time.time;
		if (this.framerate != 0)
		{
			this.mUpdate = num + Mathf.Abs(1f / (float)this.framerate);
		}
		if (this.mUnitySprite != null)
		{
			this.mUnitySprite.sprite = this.frames[this.frameIndex];
			return;
		}
		if (this.mNguiSprite != null)
		{
			this.mNguiSprite.nextSprite = this.frames[this.frameIndex];
		}
	}

	// Token: 0x04000617 RID: 1559
	public int frameIndex;

	// Token: 0x04000618 RID: 1560
	[SerializeField]
	protected int framerate = 20;

	// Token: 0x04000619 RID: 1561
	public bool ignoreTimeScale = true;

	// Token: 0x0400061A RID: 1562
	public bool loop = true;

	// Token: 0x0400061B RID: 1563
	public Sprite[] frames;

	// Token: 0x0400061C RID: 1564
	private SpriteRenderer mUnitySprite;

	// Token: 0x0400061D RID: 1565
	private UI2DSprite mNguiSprite;

	// Token: 0x0400061E RID: 1566
	private float mUpdate;
}
