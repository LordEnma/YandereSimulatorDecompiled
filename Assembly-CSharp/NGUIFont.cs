using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NGUIFont : ScriptableObject, INGUIFont
{
	[HideInInspector]
	[SerializeField]
	private Material mMat;

	[HideInInspector]
	[SerializeField]
	private Rect mUVRect = new Rect(0f, 0f, 1f, 1f);

	[HideInInspector]
	[SerializeField]
	private BMFont mFont = new BMFont();

	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mReplacement;

	[HideInInspector]
	[SerializeField]
	private List<BMSymbol> mSymbols = new List<BMSymbol>();

	[HideInInspector]
	[SerializeField]
	private Font mDynamicFont;

	[HideInInspector]
	[SerializeField]
	private int mDynamicFontSize = 16;

	[HideInInspector]
	[SerializeField]
	private FontStyle mDynamicFontStyle;

	[NonSerialized]
	private UISpriteData mSprite;

	[NonSerialized]
	private int mPMA = -1;

	[NonSerialized]
	private int mPacked = -1;

	public BMFont bmFont
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mFont;
			}
			return iNGUIFont.bmFont;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.bmFont = value;
			}
			else
			{
				mFont = value;
			}
		}
	}

	public int texWidth
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				if (mFont == null)
				{
					return 1;
				}
				return mFont.texWidth;
			}
			return iNGUIFont.texWidth;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.texWidth = value;
			}
			else if (mFont != null)
			{
				mFont.texWidth = value;
			}
		}
	}

	public int texHeight
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				if (mFont == null)
				{
					return 1;
				}
				return mFont.texHeight;
			}
			return iNGUIFont.texHeight;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.texHeight = value;
			}
			else if (mFont != null)
			{
				mFont.texHeight = value;
			}
		}
	}

	public bool hasSymbols
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				if (mSymbols != null)
				{
					return mSymbols.Count != 0;
				}
				return false;
			}
			return iNGUIFont.hasSymbols;
		}
	}

	public List<BMSymbol> symbols
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mSymbols;
			}
			return iNGUIFont.symbols;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.symbols = value;
			}
			else
			{
				mSymbols = value;
			}
		}
	}

	public INGUIAtlas atlas
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.atlas;
			}
			return mAtlas as INGUIAtlas;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.atlas = value;
			}
			else
			{
				if (mAtlas as INGUIAtlas == value)
				{
					return;
				}
				mPMA = -1;
				mAtlas = value as UnityEngine.Object;
				if (value != null)
				{
					mMat = value.spriteMaterial;
					if (sprite != null)
					{
						mUVRect = uvRect;
					}
				}
				else
				{
					mAtlas = null;
					mMat = null;
				}
				MarkAsChanged();
			}
		}
	}

	public Material material
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.material;
			}
			INGUIAtlas iNGUIAtlas = mAtlas as INGUIAtlas;
			if (iNGUIAtlas != null)
			{
				return iNGUIAtlas.spriteMaterial;
			}
			if (mMat != null)
			{
				if (mDynamicFont != null && mMat != mDynamicFont.material)
				{
					mMat.mainTexture = mDynamicFont.material.mainTexture;
				}
				return mMat;
			}
			if (mDynamicFont != null)
			{
				return mDynamicFont.material;
			}
			return null;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.material = value;
			}
			else if (mMat != value)
			{
				mPMA = -1;
				mMat = value;
				MarkAsChanged();
			}
		}
	}

	[Obsolete("Use premultipliedAlphaShader instead")]
	public bool premultipliedAlpha
	{
		get
		{
			return premultipliedAlphaShader;
		}
	}

	public bool premultipliedAlphaShader
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.premultipliedAlphaShader;
			}
			INGUIAtlas iNGUIAtlas = mAtlas as INGUIAtlas;
			if (iNGUIAtlas != null)
			{
				return iNGUIAtlas.premultipliedAlpha;
			}
			if (mPMA == -1)
			{
				Material material = this.material;
				mPMA = ((material != null && material.shader != null && material.shader.name.Contains("Premultiplied")) ? 1 : 0);
			}
			return mPMA == 1;
		}
	}

	public bool packedFontShader
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.packedFontShader;
			}
			if (mAtlas != null)
			{
				return false;
			}
			if (mPacked == -1)
			{
				Material material = this.material;
				mPacked = ((material != null && material.shader != null && material.shader.name.Contains("Packed")) ? 1 : 0);
			}
			return mPacked == 1;
		}
	}

	public Texture2D texture
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.texture;
			}
			Material material = this.material;
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture as Texture2D;
		}
	}

	public Rect uvRect
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.uvRect;
			}
			if (!(mAtlas != null) || sprite == null)
			{
				return new Rect(0f, 0f, 1f, 1f);
			}
			return mUVRect;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.uvRect = value;
			}
			else if (sprite == null && mUVRect != value)
			{
				mUVRect = value;
				MarkAsChanged();
			}
		}
	}

	public string spriteName
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mFont.spriteName;
			}
			return iNGUIFont.spriteName;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.spriteName = value;
			}
			else if (mFont.spriteName != value)
			{
				mFont.spriteName = value;
				MarkAsChanged();
			}
		}
	}

	public bool isValid
	{
		get
		{
			if (!(mDynamicFont != null))
			{
				return mFont.isValid;
			}
			return true;
		}
	}

	[Obsolete("Use defaultSize instead")]
	public int size
	{
		get
		{
			return defaultSize;
		}
		set
		{
			defaultSize = value;
		}
	}

	public int defaultSize
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.defaultSize;
			}
			if (isDynamic || mFont == null)
			{
				return mDynamicFontSize;
			}
			return mFont.charSize;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.defaultSize = value;
			}
			else
			{
				mDynamicFontSize = value;
			}
		}
	}

	public UISpriteData sprite
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				return iNGUIFont.sprite;
			}
			INGUIAtlas iNGUIAtlas = mAtlas as INGUIAtlas;
			if (mSprite == null && iNGUIAtlas != null && mFont != null && !string.IsNullOrEmpty(mFont.spriteName))
			{
				mSprite = iNGUIAtlas.GetSprite(mFont.spriteName);
				if (mSprite == null)
				{
					mSprite = iNGUIAtlas.GetSprite(base.name);
				}
				if (mSprite == null)
				{
					mFont.spriteName = null;
				}
				else
				{
					UpdateUVRect();
				}
				int i = 0;
				for (int count = mSymbols.Count; i < count; i++)
				{
					symbols[i].MarkAsChanged();
				}
			}
			return mSprite;
		}
	}

	public INGUIFont replacement
	{
		get
		{
			if (mReplacement == null)
			{
				return null;
			}
			return mReplacement as INGUIFont;
		}
		set
		{
			INGUIFont iNGUIFont = value;
			if (iNGUIFont == this)
			{
				iNGUIFont = null;
			}
			if (mReplacement as INGUIFont != iNGUIFont)
			{
				if (iNGUIFont != null && iNGUIFont.replacement == this)
				{
					iNGUIFont.replacement = null;
				}
				if (mReplacement != null)
				{
					MarkAsChanged();
				}
				mReplacement = iNGUIFont as UnityEngine.Object;
				if (iNGUIFont != null)
				{
					mPMA = -1;
					mMat = null;
					mFont = null;
					mDynamicFont = null;
				}
				MarkAsChanged();
			}
		}
	}

	public INGUIFont finalFont
	{
		get
		{
			INGUIFont iNGUIFont = this;
			for (int i = 0; i < 10; i++)
			{
				INGUIFont iNGUIFont2 = iNGUIFont.replacement;
				if (iNGUIFont2 != null)
				{
					iNGUIFont = iNGUIFont2;
				}
			}
			return iNGUIFont;
		}
	}

	public bool isDynamic
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mDynamicFont != null;
			}
			return iNGUIFont.isDynamic;
		}
	}

	public Font dynamicFont
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mDynamicFont;
			}
			return iNGUIFont.dynamicFont;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.dynamicFont = value;
			}
			else if (mDynamicFont != value)
			{
				if (mDynamicFont != null)
				{
					material = null;
				}
				mDynamicFont = value;
				MarkAsChanged();
			}
		}
	}

	public FontStyle dynamicFontStyle
	{
		get
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont == null)
			{
				return mDynamicFontStyle;
			}
			return iNGUIFont.dynamicFontStyle;
		}
		set
		{
			INGUIFont iNGUIFont = replacement;
			if (iNGUIFont != null)
			{
				iNGUIFont.dynamicFontStyle = value;
			}
			else if (mDynamicFontStyle != value)
			{
				mDynamicFontStyle = value;
				MarkAsChanged();
			}
		}
	}

	public UISpriteData GetSprite(string spriteName)
	{
		INGUIAtlas iNGUIAtlas = atlas;
		if (iNGUIAtlas != null)
		{
			return iNGUIAtlas.GetSprite(spriteName);
		}
		return null;
	}

	private void Trim()
	{
		Texture texture = null;
		INGUIAtlas iNGUIAtlas = mAtlas as INGUIAtlas;
		if (iNGUIAtlas != null)
		{
			texture = iNGUIAtlas.texture;
		}
		if (texture != null && mSprite != null)
		{
			Rect rect = NGUIMath.ConvertToPixels(mUVRect, this.texture.width, this.texture.height, true);
			Rect rect2 = new Rect(mSprite.x, mSprite.y, mSprite.width, mSprite.height);
			int xMin = Mathf.RoundToInt(rect2.xMin - rect.xMin);
			int yMin = Mathf.RoundToInt(rect2.yMin - rect.yMin);
			int xMax = Mathf.RoundToInt(rect2.xMax - rect.xMin);
			int yMax = Mathf.RoundToInt(rect2.yMax - rect.yMin);
			mFont.Trim(xMin, yMin, xMax, yMax);
		}
	}

	public bool References(INGUIFont font)
	{
		if (font == null)
		{
			return false;
		}
		if (font == this)
		{
			return true;
		}
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont == null)
		{
			return false;
		}
		return iNGUIFont.References(font);
	}

	public void MarkAsChanged()
	{
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont != null)
		{
			iNGUIFont.MarkAsChanged();
		}
		mSprite = null;
		UILabel[] array = NGUITools.FindActive<UILabel>();
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			UILabel uILabel = array[i];
			if (uILabel.enabled && NGUITools.GetActive(uILabel.gameObject) && NGUITools.CheckIfRelated(this, uILabel.bitmapFont))
			{
				INGUIFont bitmapFont = uILabel.bitmapFont;
				uILabel.bitmapFont = null;
				uILabel.bitmapFont = bitmapFont;
			}
		}
		int j = 0;
		for (int count = symbols.Count; j < count; j++)
		{
			symbols[j].MarkAsChanged();
		}
	}

	public void UpdateUVRect()
	{
		if (mAtlas == null)
		{
			return;
		}
		Texture texture = null;
		INGUIAtlas iNGUIAtlas = mAtlas as INGUIAtlas;
		if (iNGUIAtlas != null)
		{
			texture = iNGUIAtlas.texture;
		}
		if (texture != null)
		{
			mUVRect = new Rect(mSprite.x - mSprite.paddingLeft, mSprite.y - mSprite.paddingTop, mSprite.width + mSprite.paddingLeft + mSprite.paddingRight, mSprite.height + mSprite.paddingTop + mSprite.paddingBottom);
			mUVRect = NGUIMath.ConvertToTexCoords(mUVRect, texture.width, texture.height);
			if (mSprite.hasPadding)
			{
				Trim();
			}
		}
	}

	private BMSymbol GetSymbol(string sequence, bool createIfMissing)
	{
		List<BMSymbol> list = symbols;
		int i = 0;
		for (int count = list.Count; i < count; i++)
		{
			BMSymbol bMSymbol = list[i];
			if (bMSymbol.sequence == sequence)
			{
				return bMSymbol;
			}
		}
		if (createIfMissing)
		{
			BMSymbol bMSymbol2 = new BMSymbol();
			bMSymbol2.sequence = sequence;
			list.Add(bMSymbol2);
			return bMSymbol2;
		}
		return null;
	}

	public BMSymbol MatchSymbol(string text, int offset, int textLength)
	{
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont != null)
		{
			return iNGUIFont.MatchSymbol(text, offset, textLength);
		}
		int count = mSymbols.Count;
		if (count == 0)
		{
			return null;
		}
		textLength -= offset;
		for (int i = 0; i < count; i++)
		{
			BMSymbol bMSymbol = mSymbols[i];
			int length = bMSymbol.length;
			if (length == 0 || textLength < length)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < length; j++)
			{
				if (text[offset + j] != bMSymbol.sequence[j])
				{
					flag = false;
					break;
				}
			}
			if (flag && bMSymbol.Validate(atlas))
			{
				return bMSymbol;
			}
		}
		return null;
	}

	public void AddSymbol(string sequence, string spriteName)
	{
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont != null)
		{
			iNGUIFont.AddSymbol(sequence, spriteName);
			return;
		}
		GetSymbol(sequence, true).spriteName = spriteName;
		MarkAsChanged();
	}

	public void RemoveSymbol(string sequence)
	{
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont != null)
		{
			iNGUIFont.RemoveSymbol(sequence);
			return;
		}
		BMSymbol symbol = GetSymbol(sequence, false);
		if (symbol != null)
		{
			symbols.Remove(symbol);
		}
		MarkAsChanged();
	}

	public void RenameSymbol(string before, string after)
	{
		INGUIFont iNGUIFont = replacement;
		if (iNGUIFont != null)
		{
			iNGUIFont.RenameSymbol(before, after);
			return;
		}
		BMSymbol symbol = GetSymbol(before, false);
		if (symbol != null)
		{
			symbol.sequence = after;
		}
		MarkAsChanged();
	}

	public bool UsesSprite(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			if (s.Equals(spriteName))
			{
				return true;
			}
			List<BMSymbol> list = symbols;
			int i = 0;
			for (int count = list.Count; i < count; i++)
			{
				BMSymbol bMSymbol = list[i];
				if (s.Equals(bMSymbol.spriteName))
				{
					return true;
				}
			}
		}
		return false;
	}
}
