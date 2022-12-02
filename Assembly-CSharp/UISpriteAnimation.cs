using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
	public int frameIndex;

	[HideInInspector]
	[SerializeField]
	protected int mFPS = 30;

	[HideInInspector]
	[SerializeField]
	protected string mPrefix = "";

	[HideInInspector]
	[SerializeField]
	protected bool mLoop = true;

	[HideInInspector]
	[SerializeField]
	protected bool mSnap = true;

	protected UISprite mSprite;

	protected float mDelta;

	protected bool mActive = true;

	protected List<string> mSpriteNames = new List<string>();

	public int frames
	{
		get
		{
			return mSpriteNames.Count;
		}
	}

	public int framesPerSecond
	{
		get
		{
			return mFPS;
		}
		set
		{
			mFPS = value;
		}
	}

	public string namePrefix
	{
		get
		{
			return mPrefix;
		}
		set
		{
			if (mPrefix != value)
			{
				mPrefix = value;
				RebuildSpriteList();
			}
		}
	}

	public bool loop
	{
		get
		{
			return mLoop;
		}
		set
		{
			mLoop = value;
		}
	}

	public bool isPlaying
	{
		get
		{
			return mActive;
		}
	}

	protected virtual void Start()
	{
		RebuildSpriteList();
	}

	protected virtual void Update()
	{
		if (!mActive || mSpriteNames.Count <= 1 || !Application.isPlaying || mFPS <= 0)
		{
			return;
		}
		mDelta += Mathf.Min(1f, RealTime.deltaTime);
		float num = 1f / (float)mFPS;
		while (num < mDelta)
		{
			mDelta = ((num > 0f) ? (mDelta - num) : 0f);
			if (++frameIndex >= mSpriteNames.Count)
			{
				frameIndex = 0;
				mActive = mLoop;
			}
			if (mActive)
			{
				mSprite.spriteName = mSpriteNames[frameIndex];
				if (mSnap)
				{
					mSprite.MakePixelPerfect();
				}
			}
		}
	}

	public void RebuildSpriteList()
	{
		if (mSprite == null)
		{
			mSprite = GetComponent<UISprite>();
		}
		mSpriteNames.Clear();
		if (!(mSprite != null))
		{
			return;
		}
		INGUIAtlas atlas = mSprite.atlas;
		if (atlas == null)
		{
			return;
		}
		List<UISpriteData> spriteList = atlas.spriteList;
		int i = 0;
		for (int count = spriteList.Count; i < count; i++)
		{
			UISpriteData uISpriteData = spriteList[i];
			if (string.IsNullOrEmpty(mPrefix) || uISpriteData.name.StartsWith(mPrefix))
			{
				mSpriteNames.Add(uISpriteData.name);
			}
		}
		mSpriteNames.Sort();
	}

	public void Play()
	{
		mActive = true;
	}

	public void Pause()
	{
		mActive = false;
	}

	public void ResetToBeginning()
	{
		mActive = true;
		frameIndex = 0;
		if (mSprite != null && mSpriteNames.Count > 0)
		{
			mSprite.spriteName = mSpriteNames[frameIndex];
			if (mSnap)
			{
				mSprite.MakePixelPerfect();
			}
		}
	}
}
