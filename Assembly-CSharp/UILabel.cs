using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A4 RID: 164
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Label")]
public class UILabel : UIWidget
{
	// Token: 0x17000158 RID: 344
	// (get) Token: 0x0600076B RID: 1899 RVA: 0x0003FFFF File Offset: 0x0003E1FF
	public int finalFontSize
	{
		get
		{
			if (this.trueTypeFont)
			{
				return Mathf.RoundToInt(this.mScale * (float)this.mFinalFontSize);
			}
			return Mathf.RoundToInt((float)this.mFontSize * this.mScale);
		}
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x0600076C RID: 1900 RVA: 0x00040035 File Offset: 0x0003E235
	// (set) Token: 0x0600076D RID: 1901 RVA: 0x0004003D File Offset: 0x0003E23D
	private bool shouldBeProcessed
	{
		get
		{
			return this.mShouldBeProcessed;
		}
		set
		{
			if (value)
			{
				this.mChanged = true;
				this.mShouldBeProcessed = true;
				return;
			}
			this.mShouldBeProcessed = false;
		}
	}

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x0600076E RID: 1902 RVA: 0x00040058 File Offset: 0x0003E258
	public override bool isAnchoredHorizontally
	{
		get
		{
			return base.isAnchoredHorizontally || this.mOverflow == UILabel.Overflow.ResizeFreely;
		}
	}

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x0600076F RID: 1903 RVA: 0x0004006D File Offset: 0x0003E26D
	public override bool isAnchoredVertically
	{
		get
		{
			return base.isAnchoredVertically || this.mOverflow == UILabel.Overflow.ResizeFreely || this.mOverflow == UILabel.Overflow.ResizeHeight;
		}
	}

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06000770 RID: 1904 RVA: 0x0004008C File Offset: 0x0003E28C
	// (set) Token: 0x06000771 RID: 1905 RVA: 0x000400DA File Offset: 0x0003E2DA
	public override Material material
	{
		get
		{
			if (this.mMat != null)
			{
				return this.mMat;
			}
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				return bitmapFont.material;
			}
			if (this.mTrueTypeFont != null)
			{
				return this.mTrueTypeFont.material;
			}
			return null;
		}
		set
		{
			base.material = value;
		}
	}

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06000772 RID: 1906 RVA: 0x000400E4 File Offset: 0x0003E2E4
	// (set) Token: 0x06000773 RID: 1907 RVA: 0x0004012D File Offset: 0x0003E32D
	public override Texture mainTexture
	{
		get
		{
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				return bitmapFont.texture;
			}
			if (this.mTrueTypeFont != null)
			{
				Material material = this.mTrueTypeFont.material;
				if (material != null)
				{
					return material.mainTexture;
				}
			}
			return null;
		}
		set
		{
			base.mainTexture = value;
		}
	}

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06000774 RID: 1908 RVA: 0x00040136 File Offset: 0x0003E336
	// (set) Token: 0x06000775 RID: 1909 RVA: 0x00040143 File Offset: 0x0003E343
	[Obsolete("Use UILabel.bitmapFont instead")]
	public UnityEngine.Object font
	{
		get
		{
			return this.bitmapFont as UnityEngine.Object;
		}
		set
		{
			this.bitmapFont = (value as INGUIFont);
		}
	}

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x06000776 RID: 1910 RVA: 0x00040151 File Offset: 0x0003E351
	// (set) Token: 0x06000777 RID: 1911 RVA: 0x0004015E File Offset: 0x0003E35E
	public INGUIFont bitmapFont
	{
		get
		{
			return this.mFont as INGUIFont;
		}
		set
		{
			if (this.mFont as INGUIFont != value)
			{
				base.RemoveFromPanel();
				this.mFont = (value as UnityEngine.Object);
				this.mTrueTypeFont = null;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x06000778 RID: 1912 RVA: 0x00040190 File Offset: 0x0003E390
	// (set) Token: 0x06000779 RID: 1913 RVA: 0x000401B0 File Offset: 0x0003E3B0
	public INGUIAtlas atlas
	{
		get
		{
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				return bitmapFont.atlas;
			}
			return null;
		}
		set
		{
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				bitmapFont.atlas = value;
			}
		}
	}

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x0600077A RID: 1914 RVA: 0x000401D0 File Offset: 0x0003E3D0
	// (set) Token: 0x0600077B RID: 1915 RVA: 0x00040204 File Offset: 0x0003E404
	public Font trueTypeFont
	{
		get
		{
			if (this.mTrueTypeFont != null)
			{
				return this.mTrueTypeFont;
			}
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				return bitmapFont.dynamicFont;
			}
			return null;
		}
		set
		{
			if (this.mTrueTypeFont != value)
			{
				this.SetActiveFont(null);
				base.RemoveFromPanel();
				this.mTrueTypeFont = value;
				this.shouldBeProcessed = true;
				this.mFont = null;
				this.SetActiveFont(value);
				this.ProcessAndRequest();
				if (this.mActiveTTF != null)
				{
					base.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x0600077C RID: 1916 RVA: 0x00040262 File Offset: 0x0003E462
	// (set) Token: 0x0600077D RID: 1917 RVA: 0x00040280 File Offset: 0x0003E480
	public UnityEngine.Object ambigiousFont
	{
		get
		{
			if (!(this.mFont != null))
			{
				return this.mTrueTypeFont;
			}
			return this.mFont;
		}
		set
		{
			INGUIFont inguifont = value as INGUIFont;
			if (inguifont != null)
			{
				this.bitmapFont = inguifont;
				return;
			}
			this.trueTypeFont = (value as Font);
		}
	}

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x0600077E RID: 1918 RVA: 0x000402AB File Offset: 0x0003E4AB
	// (set) Token: 0x0600077F RID: 1919 RVA: 0x000402B4 File Offset: 0x0003E4B4
	public string text
	{
		get
		{
			return this.mText;
		}
		set
		{
			if (this.mText == value)
			{
				return;
			}
			if (string.IsNullOrEmpty(value))
			{
				if (!string.IsNullOrEmpty(this.mText))
				{
					this.mText = "";
					this.MarkAsChanged();
					this.ProcessAndRequest();
					if (this.autoResizeBoxCollider)
					{
						base.ResizeCollider();
						return;
					}
				}
			}
			else if (this.mText != value)
			{
				this.mText = value;
				this.MarkAsChanged();
				this.ProcessAndRequest();
				if (this.autoResizeBoxCollider)
				{
					base.ResizeCollider();
				}
			}
		}
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x06000780 RID: 1920 RVA: 0x0004033C File Offset: 0x0003E53C
	public int defaultFontSize
	{
		get
		{
			if (this.trueTypeFont != null)
			{
				return this.mFontSize;
			}
			INGUIFont bitmapFont = this.bitmapFont;
			if (bitmapFont != null)
			{
				return bitmapFont.defaultSize;
			}
			return 16;
		}
	}

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x06000781 RID: 1921 RVA: 0x00040371 File Offset: 0x0003E571
	// (set) Token: 0x06000782 RID: 1922 RVA: 0x00040379 File Offset: 0x0003E579
	public int fontSize
	{
		get
		{
			return this.mFontSize;
		}
		set
		{
			value = Mathf.Clamp(value, 0, 256);
			if (this.mFontSize != value)
			{
				this.mFontSize = value;
				this.shouldBeProcessed = true;
				this.ProcessAndRequest();
			}
		}
	}

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06000783 RID: 1923 RVA: 0x000403A6 File Offset: 0x0003E5A6
	// (set) Token: 0x06000784 RID: 1924 RVA: 0x000403AE File Offset: 0x0003E5AE
	public FontStyle fontStyle
	{
		get
		{
			return this.mFontStyle;
		}
		set
		{
			if (this.mFontStyle != value)
			{
				this.mFontStyle = value;
				this.shouldBeProcessed = true;
				this.ProcessAndRequest();
			}
		}
	}

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x06000785 RID: 1925 RVA: 0x000403CD File Offset: 0x0003E5CD
	// (set) Token: 0x06000786 RID: 1926 RVA: 0x000403D5 File Offset: 0x0003E5D5
	public NGUIText.Alignment alignment
	{
		get
		{
			return this.mAlignment;
		}
		set
		{
			if (this.mAlignment != value)
			{
				this.mAlignment = value;
				this.shouldBeProcessed = true;
				this.ProcessAndRequest();
			}
		}
	}

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x06000787 RID: 1927 RVA: 0x000403F4 File Offset: 0x0003E5F4
	// (set) Token: 0x06000788 RID: 1928 RVA: 0x000403FC File Offset: 0x0003E5FC
	public bool applyGradient
	{
		get
		{
			return this.mApplyGradient;
		}
		set
		{
			if (this.mApplyGradient != value)
			{
				this.mApplyGradient = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x06000789 RID: 1929 RVA: 0x00040414 File Offset: 0x0003E614
	// (set) Token: 0x0600078A RID: 1930 RVA: 0x0004041C File Offset: 0x0003E61C
	public Color gradientTop
	{
		get
		{
			return this.mGradientTop;
		}
		set
		{
			if (this.mGradientTop != value)
			{
				this.mGradientTop = value;
				if (this.mApplyGradient)
				{
					this.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x0600078B RID: 1931 RVA: 0x00040441 File Offset: 0x0003E641
	// (set) Token: 0x0600078C RID: 1932 RVA: 0x00040449 File Offset: 0x0003E649
	public Color gradientBottom
	{
		get
		{
			return this.mGradientBottom;
		}
		set
		{
			if (this.mGradientBottom != value)
			{
				this.mGradientBottom = value;
				if (this.mApplyGradient)
				{
					this.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x0600078D RID: 1933 RVA: 0x0004046E File Offset: 0x0003E66E
	// (set) Token: 0x0600078E RID: 1934 RVA: 0x00040476 File Offset: 0x0003E676
	public int spacingX
	{
		get
		{
			return this.mSpacingX;
		}
		set
		{
			if (this.mSpacingX != value)
			{
				this.mSpacingX = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x0600078F RID: 1935 RVA: 0x0004048E File Offset: 0x0003E68E
	// (set) Token: 0x06000790 RID: 1936 RVA: 0x00040496 File Offset: 0x0003E696
	public int spacingY
	{
		get
		{
			return this.mSpacingY;
		}
		set
		{
			if (this.mSpacingY != value)
			{
				this.mSpacingY = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06000791 RID: 1937 RVA: 0x000404AE File Offset: 0x0003E6AE
	// (set) Token: 0x06000792 RID: 1938 RVA: 0x000404B6 File Offset: 0x0003E6B6
	public bool useFloatSpacing
	{
		get
		{
			return this.mUseFloatSpacing;
		}
		set
		{
			if (this.mUseFloatSpacing != value)
			{
				this.mUseFloatSpacing = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06000793 RID: 1939 RVA: 0x000404CF File Offset: 0x0003E6CF
	// (set) Token: 0x06000794 RID: 1940 RVA: 0x000404D7 File Offset: 0x0003E6D7
	public float floatSpacingX
	{
		get
		{
			return this.mFloatSpacingX;
		}
		set
		{
			if (!Mathf.Approximately(this.mFloatSpacingX, value))
			{
				this.mFloatSpacingX = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x06000795 RID: 1941 RVA: 0x000404F4 File Offset: 0x0003E6F4
	// (set) Token: 0x06000796 RID: 1942 RVA: 0x000404FC File Offset: 0x0003E6FC
	public float floatSpacingY
	{
		get
		{
			return this.mFloatSpacingY;
		}
		set
		{
			if (!Mathf.Approximately(this.mFloatSpacingY, value))
			{
				this.mFloatSpacingY = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x06000797 RID: 1943 RVA: 0x00040519 File Offset: 0x0003E719
	public float effectiveSpacingY
	{
		get
		{
			if (!this.mUseFloatSpacing)
			{
				return (float)this.mSpacingY;
			}
			return this.mFloatSpacingY;
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x06000798 RID: 1944 RVA: 0x00040531 File Offset: 0x0003E731
	public float effectiveSpacingX
	{
		get
		{
			if (!this.mUseFloatSpacing)
			{
				return (float)this.mSpacingX;
			}
			return this.mFloatSpacingX;
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06000799 RID: 1945 RVA: 0x00040549 File Offset: 0x0003E749
	// (set) Token: 0x0600079A RID: 1946 RVA: 0x00040551 File Offset: 0x0003E751
	public bool overflowEllipsis
	{
		get
		{
			return this.mOverflowEllipsis;
		}
		set
		{
			if (this.mOverflowEllipsis != value)
			{
				this.mOverflowEllipsis = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x0600079B RID: 1947 RVA: 0x00040569 File Offset: 0x0003E769
	// (set) Token: 0x0600079C RID: 1948 RVA: 0x00040571 File Offset: 0x0003E771
	public int overflowWidth
	{
		get
		{
			return this.mOverflowWidth;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (this.mOverflowWidth != value)
			{
				this.mOverflowWidth = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x0600079D RID: 1949 RVA: 0x00040590 File Offset: 0x0003E790
	// (set) Token: 0x0600079E RID: 1950 RVA: 0x00040598 File Offset: 0x0003E798
	public int overflowHeight
	{
		get
		{
			return this.mOverflowHeight;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (this.mOverflowHeight != value)
			{
				this.mOverflowHeight = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x0600079F RID: 1951 RVA: 0x000405B7 File Offset: 0x0003E7B7
	private bool keepCrisp
	{
		get
		{
			return this.trueTypeFont != null && this.keepCrispWhenShrunk != UILabel.Crispness.Never;
		}
	}

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060007A0 RID: 1952 RVA: 0x000405D2 File Offset: 0x0003E7D2
	// (set) Token: 0x060007A1 RID: 1953 RVA: 0x000405DA File Offset: 0x0003E7DA
	public bool supportEncoding
	{
		get
		{
			return this.mEncoding;
		}
		set
		{
			if (this.mEncoding != value)
			{
				this.mEncoding = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060007A2 RID: 1954 RVA: 0x000405F3 File Offset: 0x0003E7F3
	// (set) Token: 0x060007A3 RID: 1955 RVA: 0x000405FB File Offset: 0x0003E7FB
	public NGUIText.SymbolStyle symbolStyle
	{
		get
		{
			return this.mSymbols;
		}
		set
		{
			if (this.mSymbols != value)
			{
				this.mSymbols = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060007A4 RID: 1956 RVA: 0x00040614 File Offset: 0x0003E814
	// (set) Token: 0x060007A5 RID: 1957 RVA: 0x0004061C File Offset: 0x0003E81C
	public UILabel.Overflow overflowMethod
	{
		get
		{
			return this.mOverflow;
		}
		set
		{
			if (this.mOverflow != value)
			{
				this.mOverflow = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060007A6 RID: 1958 RVA: 0x00040635 File Offset: 0x0003E835
	// (set) Token: 0x060007A7 RID: 1959 RVA: 0x0004063D File Offset: 0x0003E83D
	[Obsolete("Use 'width' instead")]
	public int lineWidth
	{
		get
		{
			return base.width;
		}
		set
		{
			base.width = value;
		}
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060007A8 RID: 1960 RVA: 0x00040646 File Offset: 0x0003E846
	// (set) Token: 0x060007A9 RID: 1961 RVA: 0x0004064E File Offset: 0x0003E84E
	[Obsolete("Use 'height' instead")]
	public int lineHeight
	{
		get
		{
			return base.height;
		}
		set
		{
			base.height = value;
		}
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060007AA RID: 1962 RVA: 0x00040657 File Offset: 0x0003E857
	// (set) Token: 0x060007AB RID: 1963 RVA: 0x00040665 File Offset: 0x0003E865
	public bool multiLine
	{
		get
		{
			return this.mMaxLineCount != 1;
		}
		set
		{
			if (this.mMaxLineCount != 1 != value)
			{
				this.mMaxLineCount = (value ? 0 : 1);
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060007AC RID: 1964 RVA: 0x0004068A File Offset: 0x0003E88A
	public override Vector3[] localCorners
	{
		get
		{
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return base.localCorners;
		}
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x060007AD RID: 1965 RVA: 0x000406A2 File Offset: 0x0003E8A2
	public override Vector3[] worldCorners
	{
		get
		{
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return base.worldCorners;
		}
	}

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x060007AE RID: 1966 RVA: 0x000406BA File Offset: 0x0003E8BA
	public override Vector4 drawingDimensions
	{
		get
		{
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return base.drawingDimensions;
		}
	}

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x060007AF RID: 1967 RVA: 0x000406D2 File Offset: 0x0003E8D2
	// (set) Token: 0x060007B0 RID: 1968 RVA: 0x000406DA File Offset: 0x0003E8DA
	public int maxLineCount
	{
		get
		{
			return this.mMaxLineCount;
		}
		set
		{
			if (this.mMaxLineCount != value)
			{
				this.mMaxLineCount = Mathf.Max(value, 0);
				this.shouldBeProcessed = true;
				if (this.overflowMethod == UILabel.Overflow.ShrinkContent)
				{
					this.MakePixelPerfect();
				}
			}
		}
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00040707 File Offset: 0x0003E907
	// (set) Token: 0x060007B2 RID: 1970 RVA: 0x0004070F File Offset: 0x0003E90F
	public UILabel.Effect effectStyle
	{
		get
		{
			return this.mEffectStyle;
		}
		set
		{
			if (this.mEffectStyle != value)
			{
				this.mEffectStyle = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00040728 File Offset: 0x0003E928
	// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00040730 File Offset: 0x0003E930
	public Color effectColor
	{
		get
		{
			return this.mEffectColor;
		}
		set
		{
			if (this.mEffectColor != value)
			{
				this.mEffectColor = value;
				if (this.mEffectStyle != UILabel.Effect.None)
				{
					this.shouldBeProcessed = true;
				}
			}
		}
	}

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00040756 File Offset: 0x0003E956
	// (set) Token: 0x060007B6 RID: 1974 RVA: 0x0004075E File Offset: 0x0003E95E
	public Vector2 effectDistance
	{
		get
		{
			return this.mEffectDistance;
		}
		set
		{
			if (this.mEffectDistance != value)
			{
				this.mEffectDistance = value;
				this.shouldBeProcessed = true;
			}
		}
	}

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0004077C File Offset: 0x0003E97C
	public int quadsPerCharacter
	{
		get
		{
			if (this.mEffectStyle == UILabel.Effect.Shadow)
			{
				return 2;
			}
			if (this.mEffectStyle == UILabel.Effect.Outline)
			{
				return 5;
			}
			if (this.mEffectStyle == UILabel.Effect.Outline8)
			{
				return 9;
			}
			return 1;
		}
	}

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x060007B8 RID: 1976 RVA: 0x000407A1 File Offset: 0x0003E9A1
	// (set) Token: 0x060007B9 RID: 1977 RVA: 0x000407AC File Offset: 0x0003E9AC
	[Obsolete("Use 'overflowMethod == UILabel.Overflow.ShrinkContent' instead")]
	public bool shrinkToFit
	{
		get
		{
			return this.mOverflow == UILabel.Overflow.ShrinkContent;
		}
		set
		{
			if (value)
			{
				this.overflowMethod = UILabel.Overflow.ShrinkContent;
			}
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x060007BA RID: 1978 RVA: 0x000407B8 File Offset: 0x0003E9B8
	public string processedText
	{
		get
		{
			if (this.mLastWidth != this.mWidth || this.mLastHeight != this.mHeight)
			{
				this.mLastWidth = this.mWidth;
				this.mLastHeight = this.mHeight;
				this.mShouldBeProcessed = true;
			}
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return this.mProcessedText;
		}
	}

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x060007BB RID: 1979 RVA: 0x00040816 File Offset: 0x0003EA16
	public Vector2 printedSize
	{
		get
		{
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return this.mCalculatedSize;
		}
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x060007BC RID: 1980 RVA: 0x0004082E File Offset: 0x0003EA2E
	public override Vector2 localSize
	{
		get
		{
			if (this.shouldBeProcessed)
			{
				this.ProcessText(false, true);
			}
			return base.localSize;
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x060007BD RID: 1981 RVA: 0x00040846 File Offset: 0x0003EA46
	private bool isValid
	{
		get
		{
			return this.mFont != null || this.mTrueTypeFont != null;
		}
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x060007BE RID: 1982 RVA: 0x00040864 File Offset: 0x0003EA64
	// (set) Token: 0x060007BF RID: 1983 RVA: 0x0004086C File Offset: 0x0003EA6C
	public UILabel.Modifier modifier
	{
		get
		{
			return this.mModifier;
		}
		set
		{
			if (this.mModifier != value)
			{
				this.mModifier = value;
				this.MarkAsChanged();
				this.ProcessAndRequest();
			}
		}
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x0004088A File Offset: 0x0003EA8A
	protected override void OnInit()
	{
		base.OnInit();
		UILabel.mList.Add(this);
		this.SetActiveFont(this.trueTypeFont);
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000408A9 File Offset: 0x0003EAA9
	protected override void OnDisable()
	{
		this.SetActiveFont(null);
		UILabel.mList.Remove(this);
		base.OnDisable();
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000408C4 File Offset: 0x0003EAC4
	protected void SetActiveFont(Font fnt)
	{
		if (this.mActiveTTF != fnt)
		{
			Font font = this.mActiveTTF;
			int num;
			if (font != null && UILabel.mFontUsage.TryGetValue(font, out num))
			{
				num = Mathf.Max(0, --num);
				if (num == 0)
				{
					UILabel.mFontUsage.Remove(font);
				}
				else
				{
					UILabel.mFontUsage[font] = num;
				}
			}
			this.mActiveTTF = fnt;
			if (fnt != null)
			{
				int num2 = 0;
				UILabel.mFontUsage[fnt] = num2 + 1;
			}
		}
	}

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0004094C File Offset: 0x0003EB4C
	public string printedText
	{
		get
		{
			if (!string.IsNullOrEmpty(this.mText))
			{
				if (this.mModifier == UILabel.Modifier.None)
				{
					return this.mText;
				}
				if (this.mModifier == UILabel.Modifier.ToLowercase)
				{
					return this.mText.ToLower();
				}
				if (this.mModifier == UILabel.Modifier.ToUppercase)
				{
					return this.mText.ToUpper();
				}
				if (this.mModifier == UILabel.Modifier.Custom && this.customModifier != null)
				{
					return this.customModifier(this.mText);
				}
			}
			return this.mText;
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000409CC File Offset: 0x0003EBCC
	private static void OnFontChanged(Font font)
	{
		for (int i = 0; i < UILabel.mList.size; i++)
		{
			UILabel uilabel = UILabel.mList.buffer[i];
			if (uilabel != null)
			{
				Font trueTypeFont = uilabel.trueTypeFont;
				if (trueTypeFont == font)
				{
					trueTypeFont.RequestCharactersInTexture(uilabel.mText, uilabel.mFinalFontSize, uilabel.mFontStyle);
					uilabel.MarkAsChanged();
					if (uilabel.panel == null)
					{
						uilabel.CreatePanel();
					}
					if (UILabel.mTempDrawcalls == null)
					{
						UILabel.mTempDrawcalls = new BetterList<UIDrawCall>();
					}
					if (uilabel.drawCall != null && !UILabel.mTempDrawcalls.Contains(uilabel.drawCall))
					{
						UILabel.mTempDrawcalls.Add(uilabel.drawCall);
					}
				}
			}
		}
		if (UILabel.mTempDrawcalls != null)
		{
			int j = 0;
			int size = UILabel.mTempDrawcalls.size;
			while (j < size)
			{
				UIDrawCall uidrawCall = UILabel.mTempDrawcalls.buffer[j];
				if (uidrawCall.panel != null)
				{
					uidrawCall.panel.FillDrawCall(uidrawCall);
				}
				j++;
			}
			UILabel.mTempDrawcalls.Clear();
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00040AE7 File Offset: 0x0003ECE7
	public override Vector3[] GetSides(Transform relativeTo)
	{
		if (this.shouldBeProcessed)
		{
			this.ProcessText(false, true);
		}
		return base.GetSides(relativeTo);
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00040B00 File Offset: 0x0003ED00
	protected override void UpgradeFrom265()
	{
		this.ProcessText(true, true);
		if (this.mShrinkToFit)
		{
			this.overflowMethod = UILabel.Overflow.ShrinkContent;
			this.mMaxLineCount = 0;
		}
		if (this.mMaxLineWidth != 0)
		{
			base.width = this.mMaxLineWidth;
			this.overflowMethod = ((this.mMaxLineCount > 0) ? UILabel.Overflow.ResizeHeight : UILabel.Overflow.ShrinkContent);
		}
		else
		{
			this.overflowMethod = UILabel.Overflow.ResizeFreely;
		}
		if (this.mMaxLineHeight != 0)
		{
			base.height = this.mMaxLineHeight;
		}
		if (this.mFont != null)
		{
			int defaultFontSize = this.defaultFontSize;
			if (base.height < defaultFontSize)
			{
				base.height = defaultFontSize;
			}
			this.fontSize = defaultFontSize;
		}
		this.mMaxLineWidth = 0;
		this.mMaxLineHeight = 0;
		this.mShrinkToFit = false;
		NGUITools.UpdateWidgetCollider(base.gameObject, true);
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x00040BBC File Offset: 0x0003EDBC
	protected override void OnAnchor()
	{
		if (this.mOverflow == UILabel.Overflow.ResizeFreely)
		{
			if (base.isFullyAnchored)
			{
				this.mOverflow = UILabel.Overflow.ShrinkContent;
			}
		}
		else if (this.mOverflow == UILabel.Overflow.ResizeHeight && this.topAnchor.target != null && this.bottomAnchor.target != null)
		{
			this.mOverflow = UILabel.Overflow.ShrinkContent;
		}
		base.OnAnchor();
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x00040C1F File Offset: 0x0003EE1F
	private void ProcessAndRequest()
	{
		if (this.ambigiousFont != null)
		{
			this.ProcessText(false, true);
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x00040C37 File Offset: 0x0003EE37
	protected override void OnEnable()
	{
		base.OnEnable();
		if (!UILabel.mTexRebuildAdded)
		{
			UILabel.mTexRebuildAdded = true;
			Font.textureRebuilt += UILabel.OnFontChanged;
		}
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x00040C60 File Offset: 0x0003EE60
	protected override void OnStart()
	{
		base.OnStart();
		if (this.mLineWidth > 0f)
		{
			this.mMaxLineWidth = Mathf.RoundToInt(this.mLineWidth);
			this.mLineWidth = 0f;
		}
		if (!this.mMultiline)
		{
			this.mMaxLineCount = 1;
			this.mMultiline = true;
		}
		this.mPremultiply = (this.material != null && this.material.shader != null && this.material.shader.name.Contains("Premultiplied"));
		this.ProcessAndRequest();
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x00040CFC File Offset: 0x0003EEFC
	public override void MarkAsChanged()
	{
		this.shouldBeProcessed = true;
		base.MarkAsChanged();
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x00040D0C File Offset: 0x0003EF0C
	public void ProcessText(bool legacyMode = false, bool full = true)
	{
		if (!this.isValid)
		{
			return;
		}
		this.mChanged = true;
		this.shouldBeProcessed = false;
		float num = this.mDrawRegion.z - this.mDrawRegion.x;
		float num2 = this.mDrawRegion.w - this.mDrawRegion.y;
		NGUIText.rectWidth = (legacyMode ? ((this.mMaxLineWidth != 0) ? this.mMaxLineWidth : 1000000) : base.width);
		NGUIText.rectHeight = (legacyMode ? ((this.mMaxLineHeight != 0) ? this.mMaxLineHeight : 1000000) : base.height);
		NGUIText.regionWidth = ((num != 1f) ? Mathf.RoundToInt((float)NGUIText.rectWidth * num) : NGUIText.rectWidth);
		NGUIText.regionHeight = ((num2 != 1f) ? Mathf.RoundToInt((float)NGUIText.rectHeight * num2) : NGUIText.rectHeight);
		this.mFinalFontSize = Mathf.Abs(legacyMode ? Mathf.RoundToInt(base.cachedTransform.localScale.x) : this.defaultFontSize);
		this.mScale = 1f;
		if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 0)
		{
			this.mProcessedText = "";
			return;
		}
		if (this.trueTypeFont != null && this.keepCrisp)
		{
			UIRoot root = base.root;
			if (root != null)
			{
				this.mDensity = ((root != null) ? root.pixelSizeAdjustment : 1f);
			}
		}
		else
		{
			this.mDensity = 1f;
		}
		if (full)
		{
			this.UpdateNGUIText();
		}
		if (this.mOverflow == UILabel.Overflow.ResizeFreely)
		{
			if (this.mOverflowWidth > 0)
			{
				NGUIText.rectWidth = this.mOverflowWidth;
				NGUIText.regionWidth = this.mOverflowWidth;
			}
			else
			{
				NGUIText.rectWidth = 1000000;
				NGUIText.regionWidth = 1000000;
			}
			if (this.mOverflowHeight > 0)
			{
				NGUIText.rectHeight = this.mOverflowHeight;
				NGUIText.regionHeight = this.mOverflowHeight;
			}
			else
			{
				NGUIText.rectHeight = 1000000;
				NGUIText.regionHeight = 1000000;
			}
		}
		else if (this.mOverflow == UILabel.Overflow.ResizeFreely || this.mOverflow == UILabel.Overflow.ResizeHeight)
		{
			NGUIText.rectHeight = 1000000;
			NGUIText.regionHeight = 1000000;
		}
		if (this.mFinalFontSize > 0)
		{
			bool keepCrisp = this.keepCrisp;
			for (int i = this.mFinalFontSize; i > 0; i--)
			{
				if (keepCrisp)
				{
					this.mFinalFontSize = i;
					NGUIText.fontSize = this.mFinalFontSize;
				}
				else
				{
					this.mScale = (float)i / (float)this.mFinalFontSize;
					if (this.bitmapFont != null)
					{
						NGUIText.fontScale = (float)this.mFontSize / (float)this.defaultFontSize * this.mScale;
					}
					else
					{
						NGUIText.fontScale = this.mScale;
					}
				}
				NGUIText.Update(false);
				bool flag = NGUIText.WrapText(this.printedText, out this.mProcessedText, false, false, this.mOverflow == UILabel.Overflow.ClampContent && this.mOverflowEllipsis);
				if (this.mOverflow == UILabel.Overflow.ShrinkContent && !flag)
				{
					if (--i <= 1)
					{
						break;
					}
				}
				else
				{
					if (this.mOverflow == UILabel.Overflow.ResizeFreely)
					{
						this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
						if (!flag && this.mOverflowWidth > 0)
						{
							if (--i > 1)
							{
								goto IL_4A7;
							}
							break;
						}
						else
						{
							int num3 = Mathf.Max(this.minWidth, Mathf.RoundToInt(this.mCalculatedSize.x));
							if (num != 1f)
							{
								num3 = Mathf.RoundToInt((float)num3 / num);
							}
							int num4 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
							if (num2 != 1f)
							{
								num4 = Mathf.RoundToInt((float)num4 / num2);
							}
							if ((num3 & 1) == 1)
							{
								num3++;
							}
							if ((num4 & 1) == 1)
							{
								num4++;
							}
							if (this.mWidth != num3 || this.mHeight != num4)
							{
								this.mWidth = num3;
								this.mHeight = num4;
								if (this.onChange != null)
								{
									this.onChange();
								}
							}
						}
					}
					else if (this.mOverflow == UILabel.Overflow.ResizeHeight)
					{
						this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
						int num5 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
						if (num2 != 1f)
						{
							num5 = Mathf.RoundToInt((float)num5 / num2);
						}
						if ((num5 & 1) == 1)
						{
							num5++;
						}
						if (this.mHeight != num5)
						{
							this.mHeight = num5;
							if (this.onChange != null)
							{
								this.onChange();
							}
						}
					}
					else
					{
						this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
					}
					if (legacyMode)
					{
						base.width = Mathf.RoundToInt(this.mCalculatedSize.x);
						base.height = Mathf.RoundToInt(this.mCalculatedSize.y);
						base.cachedTransform.localScale = Vector3.one;
						break;
					}
					break;
				}
				IL_4A7:;
			}
		}
		else
		{
			base.cachedTransform.localScale = Vector3.one;
			this.mProcessedText = "";
			this.mScale = 1f;
		}
		if (full)
		{
			NGUIText.bitmapFont = null;
			NGUIText.dynamicFont = null;
		}
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x00041208 File Offset: 0x0003F408
	public override void MakePixelPerfect()
	{
		if (!(this.ambigiousFont != null))
		{
			base.MakePixelPerfect();
			return;
		}
		Vector3 localPosition = base.cachedTransform.localPosition;
		localPosition.x = (float)Mathf.RoundToInt(localPosition.x);
		localPosition.y = (float)Mathf.RoundToInt(localPosition.y);
		localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
		base.cachedTransform.localPosition = localPosition;
		base.cachedTransform.localScale = Vector3.one;
		if (this.mOverflow == UILabel.Overflow.ResizeFreely)
		{
			this.AssumeNaturalSize();
			return;
		}
		int width = base.width;
		int height = base.height;
		UILabel.Overflow overflow = this.mOverflow;
		if (overflow != UILabel.Overflow.ResizeHeight)
		{
			this.mWidth = 100000;
		}
		this.mHeight = 100000;
		this.mOverflow = UILabel.Overflow.ShrinkContent;
		this.ProcessText(false, true);
		this.mOverflow = overflow;
		int num = Mathf.RoundToInt(this.mCalculatedSize.x);
		int num2 = Mathf.RoundToInt(this.mCalculatedSize.y);
		num = Mathf.Max(num, base.minWidth);
		num2 = Mathf.Max(num2, base.minHeight);
		if ((num & 1) == 1)
		{
			num++;
		}
		if ((num2 & 1) == 1)
		{
			num2++;
		}
		this.mWidth = Mathf.Max(width, num);
		this.mHeight = Mathf.Max(height, num2);
		this.MarkAsChanged();
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x00041364 File Offset: 0x0003F564
	public void AssumeNaturalSize()
	{
		if (this.ambigiousFont != null)
		{
			this.mWidth = 100000;
			this.mHeight = 100000;
			this.ProcessText(false, true);
			this.mWidth = Mathf.RoundToInt(this.mCalculatedSize.x);
			this.mHeight = Mathf.RoundToInt(this.mCalculatedSize.y);
			if ((this.mWidth & 1) == 1)
			{
				this.mWidth++;
			}
			if ((this.mHeight & 1) == 1)
			{
				this.mHeight++;
			}
			this.MarkAsChanged();
		}
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x00041404 File Offset: 0x0003F604
	[Obsolete("Use UILabel.GetCharacterAtPosition instead")]
	public int GetCharacterIndex(Vector3 worldPos)
	{
		return this.GetCharacterIndexAtPosition(worldPos, false);
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x0004140E File Offset: 0x0003F60E
	[Obsolete("Use UILabel.GetCharacterAtPosition instead")]
	public int GetCharacterIndex(Vector2 localPos)
	{
		return this.GetCharacterIndexAtPosition(localPos, false);
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x00041418 File Offset: 0x0003F618
	public int GetCharacterIndexAtPosition(Vector3 worldPos, bool precise)
	{
		Vector2 localPos = base.cachedTransform.InverseTransformPoint(worldPos);
		return this.GetCharacterIndexAtPosition(localPos, precise);
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x00041440 File Offset: 0x0003F640
	public int GetCharacterIndexAtPosition(Vector2 localPos, bool precise)
	{
		if (this.isValid)
		{
			string processedText = this.processedText;
			if (string.IsNullOrEmpty(processedText))
			{
				return 0;
			}
			this.UpdateNGUIText();
			if (precise)
			{
				NGUIText.PrintExactCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
			}
			else
			{
				NGUIText.PrintApproximateCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
			}
			if (UILabel.mTempVerts.Count > 0)
			{
				this.ApplyOffset(UILabel.mTempVerts, 0);
				int result = precise ? NGUIText.GetExactCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, localPos) : NGUIText.GetApproximateCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, localPos);
				UILabel.mTempVerts.Clear();
				UILabel.mTempIndices.Clear();
				NGUIText.bitmapFont = null;
				NGUIText.dynamicFont = null;
				return result;
			}
			NGUIText.bitmapFont = null;
			NGUIText.dynamicFont = null;
		}
		return 0;
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00041504 File Offset: 0x0003F704
	public string GetWordAtPosition(Vector3 worldPos)
	{
		int characterIndexAtPosition = this.GetCharacterIndexAtPosition(worldPos, true);
		return this.GetWordAtCharacterIndex(characterIndexAtPosition);
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x00041524 File Offset: 0x0003F724
	public string GetWordAtPosition(Vector2 localPos)
	{
		int characterIndexAtPosition = this.GetCharacterIndexAtPosition(localPos, true);
		return this.GetWordAtCharacterIndex(characterIndexAtPosition);
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x00041544 File Offset: 0x0003F744
	public string GetWordAtCharacterIndex(int characterIndex)
	{
		string printedText = this.printedText;
		if (characterIndex != -1 && characterIndex < printedText.Length)
		{
			int num = printedText.LastIndexOfAny(new char[]
			{
				' ',
				'\n'
			}, characterIndex) + 1;
			int num2 = printedText.IndexOfAny(new char[]
			{
				' ',
				'\n',
				',',
				'.'
			}, characterIndex);
			if (num2 == -1)
			{
				num2 = printedText.Length;
			}
			if (num != num2)
			{
				int num3 = num2 - num;
				if (num3 > 0)
				{
					return NGUIText.StripSymbols(printedText.Substring(num, num3));
				}
			}
		}
		return null;
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000415BE File Offset: 0x0003F7BE
	public string GetUrlAtPosition(Vector3 worldPos)
	{
		return this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(worldPos, true));
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000415CE File Offset: 0x0003F7CE
	public string GetUrlAtPosition(Vector2 localPos)
	{
		return this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(localPos, true));
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000415E0 File Offset: 0x0003F7E0
	public string GetUrlAtCharacterIndex(int characterIndex)
	{
		string printedText = this.printedText;
		if (characterIndex != -1 && characterIndex < printedText.Length - 6)
		{
			int num;
			if (printedText[characterIndex] == '[' && printedText[characterIndex + 1] == 'u' && printedText[characterIndex + 2] == 'r' && printedText[characterIndex + 3] == 'l' && printedText[characterIndex + 4] == '=')
			{
				num = characterIndex;
			}
			else
			{
				num = printedText.LastIndexOf("[url=", characterIndex);
			}
			if (num == -1)
			{
				return null;
			}
			num += 5;
			int num2 = printedText.IndexOf("]", num);
			if (num2 == -1)
			{
				return null;
			}
			int num3 = printedText.IndexOf("[/url]", num2);
			if (num3 == -1 || characterIndex <= num3)
			{
				return printedText.Substring(num, num2 - num);
			}
		}
		return null;
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x00041698 File Offset: 0x0003F898
	public int GetCharacterIndex(int currentIndex, KeyCode key)
	{
		if (this.isValid)
		{
			string processedText = this.processedText;
			if (string.IsNullOrEmpty(processedText))
			{
				return 0;
			}
			int defaultFontSize = this.defaultFontSize;
			this.UpdateNGUIText();
			NGUIText.PrintApproximateCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
			if (UILabel.mTempVerts.Count > 0)
			{
				this.ApplyOffset(UILabel.mTempVerts, 0);
				int i = 0;
				int count = UILabel.mTempIndices.Count;
				while (i < count)
				{
					if (UILabel.mTempIndices[i] == currentIndex)
					{
						Vector2 pos = UILabel.mTempVerts[i];
						if (key == KeyCode.UpArrow)
						{
							pos.y += (float)defaultFontSize + this.effectiveSpacingY;
						}
						else if (key == KeyCode.DownArrow)
						{
							pos.y -= (float)defaultFontSize + this.effectiveSpacingY;
						}
						else if (key == KeyCode.Home)
						{
							pos.x -= 1000f;
						}
						else if (key == KeyCode.End)
						{
							pos.x += 1000f;
						}
						int approximateCharacterIndex = NGUIText.GetApproximateCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, pos);
						if (approximateCharacterIndex != currentIndex)
						{
							UILabel.mTempVerts.Clear();
							UILabel.mTempIndices.Clear();
							return approximateCharacterIndex;
						}
						break;
					}
					else
					{
						i++;
					}
				}
				UILabel.mTempVerts.Clear();
				UILabel.mTempIndices.Clear();
			}
			NGUIText.bitmapFont = null;
			NGUIText.dynamicFont = null;
			if (key == KeyCode.UpArrow || key == KeyCode.Home)
			{
				return 0;
			}
			if (key == KeyCode.DownArrow || key == KeyCode.End)
			{
				return processedText.Length;
			}
		}
		return currentIndex;
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x00041824 File Offset: 0x0003FA24
	public void PrintOverlay(int start, int end, UIGeometry caret, UIGeometry highlight, Color caretColor, Color highlightColor)
	{
		if (caret != null)
		{
			caret.Clear();
		}
		if (highlight != null)
		{
			highlight.Clear();
		}
		if (!this.isValid)
		{
			return;
		}
		string processedText = this.processedText;
		this.UpdateNGUIText();
		int count = caret.verts.Count;
		Vector2 item = new Vector2(0.5f, 0.5f);
		float finalAlpha = this.finalAlpha;
		if (highlight != null && start != end)
		{
			int count2 = highlight.verts.Count;
			NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, highlight.verts);
			if (highlight.verts.Count > count2)
			{
				this.ApplyOffset(highlight.verts, count2);
				Color item2 = new Color(highlightColor.r, highlightColor.g, highlightColor.b, highlightColor.a * finalAlpha);
				int i = count2;
				int count3 = highlight.verts.Count;
				while (i < count3)
				{
					highlight.uvs.Add(item);
					highlight.cols.Add(item2);
					i++;
				}
			}
		}
		else
		{
			NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, null);
		}
		this.ApplyOffset(caret.verts, count);
		Color item3 = new Color(caretColor.r, caretColor.g, caretColor.b, caretColor.a * finalAlpha);
		int j = count;
		int count4 = caret.verts.Count;
		while (j < count4)
		{
			caret.uvs.Add(item);
			caret.cols.Add(item3);
			j++;
		}
		NGUIText.bitmapFont = null;
		NGUIText.dynamicFont = null;
	}

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x060007DB RID: 2011 RVA: 0x000419BC File Offset: 0x0003FBBC
	private bool premultipliedAlphaShader
	{
		get
		{
			INGUIFont bitmapFont = this.bitmapFont;
			return bitmapFont != null && bitmapFont.premultipliedAlphaShader;
		}
	}

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x060007DC RID: 2012 RVA: 0x000419DC File Offset: 0x0003FBDC
	private bool packedFontShader
	{
		get
		{
			INGUIFont bitmapFont = this.bitmapFont;
			return bitmapFont != null && bitmapFont.packedFontShader;
		}
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000419FC File Offset: 0x0003FBFC
	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		if (!this.isValid)
		{
			return;
		}
		int num = verts.Count;
		Color color = base.color;
		color.a = this.finalAlpha;
		if (this.premultipliedAlphaShader)
		{
			color = NGUITools.ApplyPMA(color);
		}
		string processedText = this.processedText;
		int count = verts.Count;
		this.UpdateNGUIText();
		NGUIText.tint = color;
		NGUIText.Print(processedText, verts, uvs, cols);
		NGUIText.bitmapFont = null;
		NGUIText.dynamicFont = null;
		Vector2 vector = this.ApplyOffset(verts, count);
		if (this.packedFontShader)
		{
			return;
		}
		if (this.effectStyle != UILabel.Effect.None)
		{
			int count2 = verts.Count;
			vector.x = this.mEffectDistance.x;
			vector.y = this.mEffectDistance.y;
			this.ApplyShadow(verts, uvs, cols, num, count2, vector.x, -vector.y);
			if (this.effectStyle == UILabel.Effect.Outline || this.effectStyle == UILabel.Effect.Outline8)
			{
				num = count2;
				count2 = verts.Count;
				this.ApplyShadow(verts, uvs, cols, num, count2, -vector.x, vector.y);
				num = count2;
				count2 = verts.Count;
				this.ApplyShadow(verts, uvs, cols, num, count2, vector.x, vector.y);
				num = count2;
				count2 = verts.Count;
				this.ApplyShadow(verts, uvs, cols, num, count2, -vector.x, -vector.y);
				if (this.effectStyle == UILabel.Effect.Outline8)
				{
					num = count2;
					count2 = verts.Count;
					this.ApplyShadow(verts, uvs, cols, num, count2, -vector.x, 0f);
					num = count2;
					count2 = verts.Count;
					this.ApplyShadow(verts, uvs, cols, num, count2, vector.x, 0f);
					num = count2;
					count2 = verts.Count;
					this.ApplyShadow(verts, uvs, cols, num, count2, 0f, vector.y);
					num = count2;
					count2 = verts.Count;
					this.ApplyShadow(verts, uvs, cols, num, count2, 0f, -vector.y);
				}
			}
		}
		if (NGUIText.symbolStyle == NGUIText.SymbolStyle.NoOutline)
		{
			int i = 0;
			int count3 = cols.Count;
			while (i < count3)
			{
				if (cols[i].r == -1f)
				{
					cols[i] = Color.white;
				}
				i++;
			}
		}
		if (this.onPostFill != null)
		{
			this.onPostFill(this, num, verts, uvs, cols);
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x00041C3C File Offset: 0x0003FE3C
	public Vector2 ApplyOffset(List<Vector3> verts, int start)
	{
		Vector2 pivotOffset = base.pivotOffset;
		float num = Mathf.Lerp(0f, (float)(-(float)this.mWidth), pivotOffset.x);
		float num2 = Mathf.Lerp((float)this.mHeight, 0f, pivotOffset.y) + Mathf.Lerp(this.mCalculatedSize.y - (float)this.mHeight, 0f, pivotOffset.y);
		num = Mathf.Round(num);
		num2 = Mathf.Round(num2);
		int i = start;
		int count = verts.Count;
		while (i < count)
		{
			Vector3 value = verts[i];
			value.x += num;
			value.y += num2;
			verts[i] = value;
			i++;
		}
		return new Vector2(num, num2);
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x00041D00 File Offset: 0x0003FF00
	public void ApplyShadow(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, int start, int end, float x, float y)
	{
		Color color = this.mEffectColor;
		color.a *= this.finalAlpha;
		if (this.premultipliedAlphaShader)
		{
			color = NGUITools.ApplyPMA(color);
		}
		Color value = color;
		for (int i = start; i < end; i++)
		{
			verts.Add(verts[i]);
			uvs.Add(uvs[i]);
			cols.Add(cols[i]);
			Vector3 value2 = verts[i];
			value2.x += x;
			value2.y += y;
			verts[i] = value2;
			Color color2 = cols[i];
			if (color2.a == 1f)
			{
				cols[i] = value;
			}
			else
			{
				Color value3 = color;
				value3.a = color2.a * color.a;
				cols[i] = value3;
			}
		}
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x00041DDD File Offset: 0x0003FFDD
	public int CalculateOffsetToFit(string text)
	{
		this.UpdateNGUIText();
		NGUIText.encoding = false;
		NGUIText.symbolStyle = NGUIText.SymbolStyle.None;
		int result = NGUIText.CalculateOffsetToFit(text);
		NGUIText.bitmapFont = null;
		NGUIText.dynamicFont = null;
		return result;
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00041E04 File Offset: 0x00040004
	public void SetCurrentProgress()
	{
		if (UIProgressBar.current != null)
		{
			this.text = UIProgressBar.current.value.ToString("F");
		}
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x00041E3C File Offset: 0x0004003C
	public void SetCurrentPercent()
	{
		if (UIProgressBar.current != null)
		{
			this.text = Mathf.RoundToInt(UIProgressBar.current.value * 100f).ToString() + "%";
		}
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x00041E83 File Offset: 0x00040083
	public void SetCurrentSelection()
	{
		if (UIPopupList.current != null)
		{
			this.text = (UIPopupList.current.isLocalized ? Localization.Get(UIPopupList.current.value, true) : UIPopupList.current.value);
		}
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00041EC0 File Offset: 0x000400C0
	public bool Wrap(string text, out string final)
	{
		return this.Wrap(text, out final, 1000000);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00041ECF File Offset: 0x000400CF
	public bool Wrap(string text, out string final, int height)
	{
		this.UpdateNGUIText();
		NGUIText.rectHeight = height;
		NGUIText.regionHeight = height;
		bool result = NGUIText.WrapText(text, out final, false);
		NGUIText.bitmapFont = null;
		NGUIText.dynamicFont = null;
		return result;
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00041EF8 File Offset: 0x000400F8
	public void UpdateNGUIText()
	{
		Font trueTypeFont = this.trueTypeFont;
		bool flag = trueTypeFont != null;
		NGUIText.fontSize = this.mFinalFontSize;
		NGUIText.fontStyle = this.mFontStyle;
		NGUIText.rectWidth = this.mWidth;
		NGUIText.rectHeight = this.mHeight;
		NGUIText.regionWidth = Mathf.RoundToInt((float)this.mWidth * (this.mDrawRegion.z - this.mDrawRegion.x));
		NGUIText.regionHeight = Mathf.RoundToInt((float)this.mHeight * (this.mDrawRegion.w - this.mDrawRegion.y));
		NGUIText.gradient = (this.mApplyGradient && !this.packedFontShader);
		NGUIText.gradientTop = this.mGradientTop;
		NGUIText.gradientBottom = this.mGradientBottom;
		NGUIText.encoding = this.mEncoding;
		NGUIText.premultiply = this.mPremultiply;
		NGUIText.symbolStyle = this.mSymbols;
		NGUIText.maxLines = this.mMaxLineCount;
		NGUIText.spacingX = this.effectiveSpacingX;
		NGUIText.spacingY = this.effectiveSpacingY;
		INGUIFont inguifont = this.bitmapFont;
		if (flag)
		{
			NGUIText.fontScale = this.mScale;
		}
		else if (inguifont != null)
		{
			inguifont = inguifont.finalFont;
			NGUIText.fontScale = (float)this.mFontSize / (float)inguifont.defaultSize * this.mScale;
		}
		else
		{
			NGUIText.fontScale = this.mScale;
		}
		if (inguifont != null)
		{
			if (trueTypeFont != null)
			{
				NGUIText.dynamicFont = trueTypeFont;
				NGUIText.bitmapFont = null;
			}
			else
			{
				NGUIText.dynamicFont = null;
				NGUIText.bitmapFont = inguifont;
			}
		}
		else
		{
			NGUIText.dynamicFont = trueTypeFont;
			NGUIText.bitmapFont = null;
		}
		if (flag && this.keepCrisp)
		{
			UIRoot root = base.root;
			if (root != null)
			{
				NGUIText.pixelDensity = ((root != null) ? root.pixelSizeAdjustment : 1f);
			}
		}
		else
		{
			NGUIText.pixelDensity = 1f;
		}
		if (this.mDensity != NGUIText.pixelDensity)
		{
			this.ProcessText(false, false);
			NGUIText.rectWidth = this.mWidth;
			NGUIText.rectHeight = this.mHeight;
			NGUIText.regionWidth = Mathf.RoundToInt((float)this.mWidth * (this.mDrawRegion.z - this.mDrawRegion.x));
			NGUIText.regionHeight = Mathf.RoundToInt((float)this.mHeight * (this.mDrawRegion.w - this.mDrawRegion.y));
		}
		if (this.alignment == NGUIText.Alignment.Automatic)
		{
			UIWidget.Pivot pivot = base.pivot;
			if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.BottomLeft)
			{
				NGUIText.alignment = NGUIText.Alignment.Left;
			}
			else if (pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.BottomRight)
			{
				NGUIText.alignment = NGUIText.Alignment.Right;
			}
			else
			{
				NGUIText.alignment = NGUIText.Alignment.Center;
			}
		}
		else
		{
			NGUIText.alignment = this.alignment;
		}
		NGUIText.Update();
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x0004218B File Offset: 0x0004038B
	private void OnApplicationPause(bool paused)
	{
		if (!paused && this.mTrueTypeFont != null)
		{
			this.Invalidate(false);
		}
	}

	// Token: 0x040006EE RID: 1774
	public UILabel.Crispness keepCrispWhenShrunk = UILabel.Crispness.OnDesktop;

	// Token: 0x040006EF RID: 1775
	[HideInInspector]
	[SerializeField]
	private Font mTrueTypeFont;

	// Token: 0x040006F0 RID: 1776
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mFont;

	// Token: 0x040006F1 RID: 1777
	[Multiline(6)]
	[HideInInspector]
	[SerializeField]
	private string mText = "";

	// Token: 0x040006F2 RID: 1778
	[HideInInspector]
	[SerializeField]
	private int mFontSize = 16;

	// Token: 0x040006F3 RID: 1779
	[HideInInspector]
	[SerializeField]
	private FontStyle mFontStyle;

	// Token: 0x040006F4 RID: 1780
	[HideInInspector]
	[SerializeField]
	private NGUIText.Alignment mAlignment;

	// Token: 0x040006F5 RID: 1781
	[HideInInspector]
	[SerializeField]
	private bool mEncoding = true;

	// Token: 0x040006F6 RID: 1782
	[HideInInspector]
	[SerializeField]
	private int mMaxLineCount;

	// Token: 0x040006F7 RID: 1783
	[HideInInspector]
	[SerializeField]
	private UILabel.Effect mEffectStyle;

	// Token: 0x040006F8 RID: 1784
	[HideInInspector]
	[SerializeField]
	private Color mEffectColor = Color.black;

	// Token: 0x040006F9 RID: 1785
	[HideInInspector]
	[SerializeField]
	private NGUIText.SymbolStyle mSymbols = NGUIText.SymbolStyle.Normal;

	// Token: 0x040006FA RID: 1786
	[HideInInspector]
	[SerializeField]
	private Vector2 mEffectDistance = Vector2.one;

	// Token: 0x040006FB RID: 1787
	[HideInInspector]
	[SerializeField]
	private UILabel.Overflow mOverflow;

	// Token: 0x040006FC RID: 1788
	[HideInInspector]
	[SerializeField]
	private bool mApplyGradient;

	// Token: 0x040006FD RID: 1789
	[HideInInspector]
	[SerializeField]
	private Color mGradientTop = Color.white;

	// Token: 0x040006FE RID: 1790
	[HideInInspector]
	[SerializeField]
	private Color mGradientBottom = new Color(0.7f, 0.7f, 0.7f);

	// Token: 0x040006FF RID: 1791
	[HideInInspector]
	[SerializeField]
	private int mSpacingX;

	// Token: 0x04000700 RID: 1792
	[HideInInspector]
	[SerializeField]
	private int mSpacingY;

	// Token: 0x04000701 RID: 1793
	[HideInInspector]
	[SerializeField]
	private bool mUseFloatSpacing;

	// Token: 0x04000702 RID: 1794
	[HideInInspector]
	[SerializeField]
	private float mFloatSpacingX;

	// Token: 0x04000703 RID: 1795
	[HideInInspector]
	[SerializeField]
	private float mFloatSpacingY;

	// Token: 0x04000704 RID: 1796
	[HideInInspector]
	[SerializeField]
	private bool mOverflowEllipsis;

	// Token: 0x04000705 RID: 1797
	[HideInInspector]
	[SerializeField]
	private int mOverflowWidth;

	// Token: 0x04000706 RID: 1798
	[HideInInspector]
	[SerializeField]
	private int mOverflowHeight;

	// Token: 0x04000707 RID: 1799
	[HideInInspector]
	[SerializeField]
	private UILabel.Modifier mModifier;

	// Token: 0x04000708 RID: 1800
	[HideInInspector]
	[SerializeField]
	private bool mShrinkToFit;

	// Token: 0x04000709 RID: 1801
	[HideInInspector]
	[SerializeField]
	private int mMaxLineWidth;

	// Token: 0x0400070A RID: 1802
	[HideInInspector]
	[SerializeField]
	private int mMaxLineHeight;

	// Token: 0x0400070B RID: 1803
	[HideInInspector]
	[SerializeField]
	private float mLineWidth;

	// Token: 0x0400070C RID: 1804
	[HideInInspector]
	[SerializeField]
	private bool mMultiline = true;

	// Token: 0x0400070D RID: 1805
	[NonSerialized]
	private Font mActiveTTF;

	// Token: 0x0400070E RID: 1806
	[NonSerialized]
	private float mDensity = 1f;

	// Token: 0x0400070F RID: 1807
	[NonSerialized]
	private bool mShouldBeProcessed = true;

	// Token: 0x04000710 RID: 1808
	[NonSerialized]
	private string mProcessedText;

	// Token: 0x04000711 RID: 1809
	[NonSerialized]
	private bool mPremultiply;

	// Token: 0x04000712 RID: 1810
	[NonSerialized]
	private Vector2 mCalculatedSize = Vector2.zero;

	// Token: 0x04000713 RID: 1811
	[NonSerialized]
	private float mScale = 1f;

	// Token: 0x04000714 RID: 1812
	[NonSerialized]
	private int mFinalFontSize;

	// Token: 0x04000715 RID: 1813
	[NonSerialized]
	private int mLastWidth;

	// Token: 0x04000716 RID: 1814
	[NonSerialized]
	private int mLastHeight;

	// Token: 0x04000717 RID: 1815
	public UILabel.ModifierFunc customModifier;

	// Token: 0x04000718 RID: 1816
	private static BetterList<UILabel> mList = new BetterList<UILabel>();

	// Token: 0x04000719 RID: 1817
	private static Dictionary<Font, int> mFontUsage = new Dictionary<Font, int>();

	// Token: 0x0400071A RID: 1818
	[NonSerialized]
	private static BetterList<UIDrawCall> mTempDrawcalls;

	// Token: 0x0400071B RID: 1819
	private static bool mTexRebuildAdded = false;

	// Token: 0x0400071C RID: 1820
	private static List<Vector3> mTempVerts = new List<Vector3>();

	// Token: 0x0400071D RID: 1821
	private static List<int> mTempIndices = new List<int>();

	// Token: 0x0200063B RID: 1595
	[DoNotObfuscateNGUI]
	public enum Effect
	{
		// Token: 0x04004F11 RID: 20241
		None,
		// Token: 0x04004F12 RID: 20242
		Shadow,
		// Token: 0x04004F13 RID: 20243
		Outline,
		// Token: 0x04004F14 RID: 20244
		Outline8
	}

	// Token: 0x0200063C RID: 1596
	[DoNotObfuscateNGUI]
	public enum Overflow
	{
		// Token: 0x04004F16 RID: 20246
		ShrinkContent,
		// Token: 0x04004F17 RID: 20247
		ClampContent,
		// Token: 0x04004F18 RID: 20248
		ResizeFreely,
		// Token: 0x04004F19 RID: 20249
		ResizeHeight
	}

	// Token: 0x0200063D RID: 1597
	[DoNotObfuscateNGUI]
	public enum Crispness
	{
		// Token: 0x04004F1B RID: 20251
		Never,
		// Token: 0x04004F1C RID: 20252
		OnDesktop,
		// Token: 0x04004F1D RID: 20253
		Always
	}

	// Token: 0x0200063E RID: 1598
	[DoNotObfuscateNGUI]
	public enum Modifier
	{
		// Token: 0x04004F1F RID: 20255
		None,
		// Token: 0x04004F20 RID: 20256
		ToUppercase,
		// Token: 0x04004F21 RID: 20257
		ToLowercase,
		// Token: 0x04004F22 RID: 20258
		Custom = 255
	}

	// Token: 0x0200063F RID: 1599
	// (Invoke) Token: 0x06002629 RID: 9769
	public delegate string ModifierFunc(string s);
}
