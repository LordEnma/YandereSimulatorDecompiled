using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200009A RID: 154
[ExecuteInEditMode]
public class NGUIFont : ScriptableObject, INGUIFont
{
	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x0600064E RID: 1614 RVA: 0x000368C8 File Offset: 0x00034AC8
	// (set) Token: 0x0600064F RID: 1615 RVA: 0x000368EC File Offset: 0x00034AEC
	public BMFont bmFont
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mFont;
			}
			return replacement.bmFont;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.bmFont = value;
				return;
			}
			this.mFont = value;
		}
	}

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x06000650 RID: 1616 RVA: 0x00036914 File Offset: 0x00034B14
	// (set) Token: 0x06000651 RID: 1617 RVA: 0x00036948 File Offset: 0x00034B48
	public int texWidth
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.texWidth;
			}
			if (this.mFont == null)
			{
				return 1;
			}
			return this.mFont.texWidth;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.texWidth = value;
				return;
			}
			if (this.mFont != null)
			{
				this.mFont.texWidth = value;
			}
		}
	}

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x06000652 RID: 1618 RVA: 0x0003697C File Offset: 0x00034B7C
	// (set) Token: 0x06000653 RID: 1619 RVA: 0x000369B0 File Offset: 0x00034BB0
	public int texHeight
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.texHeight;
			}
			if (this.mFont == null)
			{
				return 1;
			}
			return this.mFont.texHeight;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.texHeight = value;
				return;
			}
			if (this.mFont != null)
			{
				this.mFont.texHeight = value;
			}
		}
	}

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x06000654 RID: 1620 RVA: 0x000369E4 File Offset: 0x00034BE4
	public bool hasSymbols
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mSymbols != null && this.mSymbols.Count != 0;
			}
			return replacement.hasSymbols;
		}
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06000655 RID: 1621 RVA: 0x00036A1C File Offset: 0x00034C1C
	// (set) Token: 0x06000656 RID: 1622 RVA: 0x00036A40 File Offset: 0x00034C40
	public List<BMSymbol> symbols
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mSymbols;
			}
			return replacement.symbols;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.symbols = value;
				return;
			}
			this.mSymbols = value;
		}
	}

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x06000657 RID: 1623 RVA: 0x00036A68 File Offset: 0x00034C68
	// (set) Token: 0x06000658 RID: 1624 RVA: 0x00036A94 File Offset: 0x00034C94
	public INGUIAtlas atlas
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.atlas;
			}
			return this.mAtlas as INGUIAtlas;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.atlas = value;
				return;
			}
			if (this.mAtlas as INGUIAtlas != value)
			{
				this.mPMA = -1;
				this.mAtlas = (value as UnityEngine.Object);
				if (value != null)
				{
					this.mMat = value.spriteMaterial;
					if (this.sprite != null)
					{
						this.mUVRect = this.uvRect;
					}
				}
				else
				{
					this.mAtlas = null;
					this.mMat = null;
				}
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x00036B10 File Offset: 0x00034D10
	public UISpriteData GetSprite(string spriteName)
	{
		INGUIAtlas atlas = this.atlas;
		if (atlas != null)
		{
			return atlas.GetSprite(spriteName);
		}
		return null;
	}

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x0600065A RID: 1626 RVA: 0x00036B30 File Offset: 0x00034D30
	// (set) Token: 0x0600065B RID: 1627 RVA: 0x00036BD8 File Offset: 0x00034DD8
	public Material material
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.material;
			}
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				return inguiatlas.spriteMaterial;
			}
			if (this.mMat != null)
			{
				if (this.mDynamicFont != null && this.mMat != this.mDynamicFont.material)
				{
					this.mMat.mainTexture = this.mDynamicFont.material.mainTexture;
				}
				return this.mMat;
			}
			if (this.mDynamicFont != null)
			{
				return this.mDynamicFont.material;
			}
			return null;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.material = value;
				return;
			}
			if (this.mMat != value)
			{
				this.mPMA = -1;
				this.mMat = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x0600065C RID: 1628 RVA: 0x00036C19 File Offset: 0x00034E19
	[Obsolete("Use premultipliedAlphaShader instead")]
	public bool premultipliedAlpha
	{
		get
		{
			return this.premultipliedAlphaShader;
		}
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x0600065D RID: 1629 RVA: 0x00036C24 File Offset: 0x00034E24
	public bool premultipliedAlphaShader
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.premultipliedAlphaShader;
			}
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				return inguiatlas.premultipliedAlpha;
			}
			if (this.mPMA == -1)
			{
				Material material = this.material;
				this.mPMA = ((material != null && material.shader != null && material.shader.name.Contains("Premultiplied")) ? 1 : 0);
			}
			return this.mPMA == 1;
		}
	}

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x0600065E RID: 1630 RVA: 0x00036CAC File Offset: 0x00034EAC
	public bool packedFontShader
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.packedFontShader;
			}
			if (this.mAtlas != null)
			{
				return false;
			}
			if (this.mPacked == -1)
			{
				Material material = this.material;
				this.mPacked = ((material != null && material.shader != null && material.shader.name.Contains("Packed")) ? 1 : 0);
			}
			return this.mPacked == 1;
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x0600065F RID: 1631 RVA: 0x00036D2C File Offset: 0x00034F2C
	public Texture2D texture
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.texture;
			}
			Material material = this.material;
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture as Texture2D;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x06000660 RID: 1632 RVA: 0x00036D68 File Offset: 0x00034F68
	// (set) Token: 0x06000661 RID: 1633 RVA: 0x00036DBC File Offset: 0x00034FBC
	public Rect uvRect
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.uvRect;
			}
			if (!(this.mAtlas != null) || this.sprite == null)
			{
				return new Rect(0f, 0f, 1f, 1f);
			}
			return this.mUVRect;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.uvRect = value;
				return;
			}
			if (this.sprite == null && this.mUVRect != value)
			{
				this.mUVRect = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x06000662 RID: 1634 RVA: 0x00036E00 File Offset: 0x00035000
	// (set) Token: 0x06000663 RID: 1635 RVA: 0x00036E2C File Offset: 0x0003502C
	public string spriteName
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mFont.spriteName;
			}
			return replacement.spriteName;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.spriteName = value;
				return;
			}
			if (this.mFont.spriteName != value)
			{
				this.mFont.spriteName = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x06000664 RID: 1636 RVA: 0x00036E70 File Offset: 0x00035070
	public bool isValid
	{
		get
		{
			return this.mDynamicFont != null || this.mFont.isValid;
		}
	}

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x06000665 RID: 1637 RVA: 0x00036E8D File Offset: 0x0003508D
	// (set) Token: 0x06000666 RID: 1638 RVA: 0x00036E95 File Offset: 0x00035095
	[Obsolete("Use defaultSize instead")]
	public int size
	{
		get
		{
			return this.defaultSize;
		}
		set
		{
			this.defaultSize = value;
		}
	}

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x06000667 RID: 1639 RVA: 0x00036EA0 File Offset: 0x000350A0
	// (set) Token: 0x06000668 RID: 1640 RVA: 0x00036EE0 File Offset: 0x000350E0
	public int defaultSize
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.defaultSize;
			}
			if (this.isDynamic || this.mFont == null)
			{
				return this.mDynamicFontSize;
			}
			return this.mFont.charSize;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.defaultSize = value;
				return;
			}
			this.mDynamicFontSize = value;
		}
	}

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x06000669 RID: 1641 RVA: 0x00036F08 File Offset: 0x00035108
	public UISpriteData sprite
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				return replacement.sprite;
			}
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (this.mSprite == null && inguiatlas != null && this.mFont != null && !string.IsNullOrEmpty(this.mFont.spriteName))
			{
				this.mSprite = inguiatlas.GetSprite(this.mFont.spriteName);
				if (this.mSprite == null)
				{
					this.mSprite = inguiatlas.GetSprite(base.name);
				}
				if (this.mSprite == null)
				{
					this.mFont.spriteName = null;
				}
				else
				{
					this.UpdateUVRect();
				}
				int i = 0;
				int count = this.mSymbols.Count;
				while (i < count)
				{
					this.symbols[i].MarkAsChanged();
					i++;
				}
			}
			return this.mSprite;
		}
	}

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x0600066A RID: 1642 RVA: 0x00036FDC File Offset: 0x000351DC
	// (set) Token: 0x0600066B RID: 1643 RVA: 0x00036FFC File Offset: 0x000351FC
	public INGUIFont replacement
	{
		get
		{
			if (this.mReplacement == null)
			{
				return null;
			}
			return this.mReplacement as INGUIFont;
		}
		set
		{
			INGUIFont inguifont = value;
			if (inguifont == this)
			{
				inguifont = null;
			}
			if (this.mReplacement as INGUIFont != inguifont)
			{
				if (inguifont != null && inguifont.replacement == this)
				{
					inguifont.replacement = null;
				}
				if (this.mReplacement != null)
				{
					this.MarkAsChanged();
				}
				this.mReplacement = (inguifont as UnityEngine.Object);
				if (inguifont != null)
				{
					this.mPMA = -1;
					this.mMat = null;
					this.mFont = null;
					this.mDynamicFont = null;
				}
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x0600066C RID: 1644 RVA: 0x00037078 File Offset: 0x00035278
	public INGUIFont finalFont
	{
		get
		{
			INGUIFont inguifont = this;
			for (int i = 0; i < 10; i++)
			{
				INGUIFont replacement = inguifont.replacement;
				if (replacement != null)
				{
					inguifont = replacement;
				}
			}
			return inguifont;
		}
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x0600066D RID: 1645 RVA: 0x000370A4 File Offset: 0x000352A4
	public bool isDynamic
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mDynamicFont != null;
			}
			return replacement.isDynamic;
		}
	}

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x0600066E RID: 1646 RVA: 0x000370D0 File Offset: 0x000352D0
	// (set) Token: 0x0600066F RID: 1647 RVA: 0x000370F4 File Offset: 0x000352F4
	public Font dynamicFont
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mDynamicFont;
			}
			return replacement.dynamicFont;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.dynamicFont = value;
				return;
			}
			if (this.mDynamicFont != value)
			{
				if (this.mDynamicFont != null)
				{
					this.material = null;
				}
				this.mDynamicFont = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x06000670 RID: 1648 RVA: 0x00037144 File Offset: 0x00035344
	// (set) Token: 0x06000671 RID: 1649 RVA: 0x00037168 File Offset: 0x00035368
	public FontStyle dynamicFontStyle
	{
		get
		{
			INGUIFont replacement = this.replacement;
			if (replacement == null)
			{
				return this.mDynamicFontStyle;
			}
			return replacement.dynamicFontStyle;
		}
		set
		{
			INGUIFont replacement = this.replacement;
			if (replacement != null)
			{
				replacement.dynamicFontStyle = value;
				return;
			}
			if (this.mDynamicFontStyle != value)
			{
				this.mDynamicFontStyle = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x000371A0 File Offset: 0x000353A0
	private void Trim()
	{
		Texture x = null;
		INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
		if (inguiatlas != null)
		{
			x = inguiatlas.texture;
		}
		if (x != null && this.mSprite != null)
		{
			Rect rect = NGUIMath.ConvertToPixels(this.mUVRect, this.texture.width, this.texture.height, true);
			Rect rect2 = new Rect((float)this.mSprite.x, (float)this.mSprite.y, (float)this.mSprite.width, (float)this.mSprite.height);
			int xMin = Mathf.RoundToInt(rect2.xMin - rect.xMin);
			int yMin = Mathf.RoundToInt(rect2.yMin - rect.yMin);
			int xMax = Mathf.RoundToInt(rect2.xMax - rect.xMin);
			int yMax = Mathf.RoundToInt(rect2.yMax - rect.yMin);
			this.mFont.Trim(xMin, yMin, xMax, yMax);
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x000372A4 File Offset: 0x000354A4
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
		INGUIFont replacement = this.replacement;
		return replacement != null && replacement.References(font);
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x000372D0 File Offset: 0x000354D0
	public void MarkAsChanged()
	{
		INGUIFont replacement = this.replacement;
		if (replacement != null)
		{
			replacement.MarkAsChanged();
		}
		this.mSprite = null;
		UILabel[] array = NGUITools.FindActive<UILabel>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			UILabel uilabel = array[i];
			if (uilabel.enabled && NGUITools.GetActive(uilabel.gameObject) && NGUITools.CheckIfRelated(this, uilabel.bitmapFont))
			{
				INGUIFont bitmapFont = uilabel.bitmapFont;
				uilabel.bitmapFont = null;
				uilabel.bitmapFont = bitmapFont;
			}
			i++;
		}
		int j = 0;
		int count = this.symbols.Count;
		while (j < count)
		{
			this.symbols[j].MarkAsChanged();
			j++;
		}
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00037380 File Offset: 0x00035580
	public void UpdateUVRect()
	{
		if (this.mAtlas == null)
		{
			return;
		}
		Texture texture = null;
		INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
		if (inguiatlas != null)
		{
			texture = inguiatlas.texture;
		}
		if (texture != null)
		{
			this.mUVRect = new Rect((float)(this.mSprite.x - this.mSprite.paddingLeft), (float)(this.mSprite.y - this.mSprite.paddingTop), (float)(this.mSprite.width + this.mSprite.paddingLeft + this.mSprite.paddingRight), (float)(this.mSprite.height + this.mSprite.paddingTop + this.mSprite.paddingBottom));
			this.mUVRect = NGUIMath.ConvertToTexCoords(this.mUVRect, texture.width, texture.height);
			if (this.mSprite.hasPadding)
			{
				this.Trim();
			}
		}
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00037474 File Offset: 0x00035674
	private BMSymbol GetSymbol(string sequence, bool createIfMissing)
	{
		List<BMSymbol> symbols = this.symbols;
		int i = 0;
		int count = symbols.Count;
		while (i < count)
		{
			BMSymbol bmsymbol = symbols[i];
			if (bmsymbol.sequence == sequence)
			{
				return bmsymbol;
			}
			i++;
		}
		if (createIfMissing)
		{
			BMSymbol bmsymbol2 = new BMSymbol();
			bmsymbol2.sequence = sequence;
			symbols.Add(bmsymbol2);
			return bmsymbol2;
		}
		return null;
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x000374D4 File Offset: 0x000356D4
	public BMSymbol MatchSymbol(string text, int offset, int textLength)
	{
		INGUIFont replacement = this.replacement;
		if (replacement != null)
		{
			return replacement.MatchSymbol(text, offset, textLength);
		}
		int count = this.mSymbols.Count;
		if (count == 0)
		{
			return null;
		}
		textLength -= offset;
		for (int i = 0; i < count; i++)
		{
			BMSymbol bmsymbol = this.mSymbols[i];
			int length = bmsymbol.length;
			if (length != 0 && textLength >= length)
			{
				bool flag = true;
				for (int j = 0; j < length; j++)
				{
					if (text[offset + j] != bmsymbol.sequence[j])
					{
						flag = false;
						break;
					}
				}
				if (flag && bmsymbol.Validate(this.atlas))
				{
					return bmsymbol;
				}
			}
		}
		return null;
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x0003757C File Offset: 0x0003577C
	public void AddSymbol(string sequence, string spriteName)
	{
		INGUIFont replacement = this.replacement;
		if (replacement != null)
		{
			replacement.AddSymbol(sequence, spriteName);
			return;
		}
		this.GetSymbol(sequence, true).spriteName = spriteName;
		this.MarkAsChanged();
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x000375B0 File Offset: 0x000357B0
	public void RemoveSymbol(string sequence)
	{
		INGUIFont replacement = this.replacement;
		if (replacement != null)
		{
			replacement.RemoveSymbol(sequence);
			return;
		}
		BMSymbol symbol = this.GetSymbol(sequence, false);
		if (symbol != null)
		{
			this.symbols.Remove(symbol);
		}
		this.MarkAsChanged();
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x000375F0 File Offset: 0x000357F0
	public void RenameSymbol(string before, string after)
	{
		INGUIFont replacement = this.replacement;
		if (replacement != null)
		{
			replacement.RenameSymbol(before, after);
			return;
		}
		BMSymbol symbol = this.GetSymbol(before, false);
		if (symbol != null)
		{
			symbol.sequence = after;
		}
		this.MarkAsChanged();
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x0003762C File Offset: 0x0003582C
	public bool UsesSprite(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			if (s.Equals(this.spriteName))
			{
				return true;
			}
			List<BMSymbol> symbols = this.symbols;
			int i = 0;
			int count = symbols.Count;
			while (i < count)
			{
				BMSymbol bmsymbol = symbols[i];
				if (s.Equals(bmsymbol.spriteName))
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x04000603 RID: 1539
	[HideInInspector]
	[SerializeField]
	private Material mMat;

	// Token: 0x04000604 RID: 1540
	[HideInInspector]
	[SerializeField]
	private Rect mUVRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x04000605 RID: 1541
	[HideInInspector]
	[SerializeField]
	private BMFont mFont = new BMFont();

	// Token: 0x04000606 RID: 1542
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	// Token: 0x04000607 RID: 1543
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mReplacement;

	// Token: 0x04000608 RID: 1544
	[HideInInspector]
	[SerializeField]
	private List<BMSymbol> mSymbols = new List<BMSymbol>();

	// Token: 0x04000609 RID: 1545
	[HideInInspector]
	[SerializeField]
	private Font mDynamicFont;

	// Token: 0x0400060A RID: 1546
	[HideInInspector]
	[SerializeField]
	private int mDynamicFontSize = 16;

	// Token: 0x0400060B RID: 1547
	[HideInInspector]
	[SerializeField]
	private FontStyle mDynamicFontStyle;

	// Token: 0x0400060C RID: 1548
	[NonSerialized]
	private UISpriteData mSprite;

	// Token: 0x0400060D RID: 1549
	[NonSerialized]
	private int mPMA = -1;

	// Token: 0x0400060E RID: 1550
	[NonSerialized]
	private int mPacked = -1;
}
