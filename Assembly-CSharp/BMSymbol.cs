using System;
using UnityEngine;

[Serializable]
public class BMSymbol
{
	public string sequence;

	public string spriteName;

	private UISpriteData mSprite;

	private bool mIsValid;

	private int mLength;

	private int mOffsetX;

	private int mOffsetY;

	private int mWidth;

	private int mHeight;

	private int mAdvance;

	private Rect mUV;

	public int length
	{
		get
		{
			if (mLength == 0)
			{
				mLength = sequence.Length;
			}
			return mLength;
		}
	}

	public int offsetX => mOffsetX;

	public int offsetY => mOffsetY;

	public int width => mWidth;

	public int height => mHeight;

	public int advance => mAdvance;

	public Rect uvRect => mUV;

	public void MarkAsChanged()
	{
		mIsValid = false;
	}

	public bool Validate(INGUIAtlas atlas)
	{
		if (atlas == null)
		{
			return false;
		}
		if (!mIsValid)
		{
			if (string.IsNullOrEmpty(spriteName))
			{
				return false;
			}
			Texture texture = null;
			mSprite = atlas.GetSprite(spriteName);
			texture = atlas.texture;
			if (mSprite != null)
			{
				if (texture == null)
				{
					mSprite = null;
				}
				else
				{
					mUV = new Rect(mSprite.x, mSprite.y, mSprite.width, mSprite.height);
					mUV = NGUIMath.ConvertToTexCoords(mUV, texture.width, texture.height);
					mOffsetX = mSprite.paddingLeft;
					mOffsetY = mSprite.paddingTop;
					mWidth = mSprite.width;
					mHeight = mSprite.height;
					mAdvance = mSprite.width + (mSprite.paddingLeft + mSprite.paddingRight);
					mIsValid = true;
				}
			}
		}
		return mSprite != null;
	}
}
