// Decompiled with JetBrains decompiler
// Type: UILabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Label")]
public class UILabel : UIWidget
{
  public UILabel.Crispness keepCrispWhenShrunk = UILabel.Crispness.OnDesktop;
  [HideInInspector]
  [SerializeField]
  private Font mTrueTypeFont;
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mFont;
  [Multiline(6)]
  [HideInInspector]
  [SerializeField]
  private string mText = "";
  [HideInInspector]
  [SerializeField]
  private int mFontSize = 16;
  [HideInInspector]
  [SerializeField]
  private FontStyle mFontStyle;
  [HideInInspector]
  [SerializeField]
  private NGUIText.Alignment mAlignment;
  [HideInInspector]
  [SerializeField]
  private bool mEncoding = true;
  [HideInInspector]
  [SerializeField]
  private int mMaxLineCount;
  [HideInInspector]
  [SerializeField]
  private UILabel.Effect mEffectStyle;
  [HideInInspector]
  [SerializeField]
  private Color mEffectColor = Color.black;
  [HideInInspector]
  [SerializeField]
  private NGUIText.SymbolStyle mSymbols = NGUIText.SymbolStyle.Normal;
  [HideInInspector]
  [SerializeField]
  private Vector2 mEffectDistance = Vector2.one;
  [HideInInspector]
  [SerializeField]
  private UILabel.Overflow mOverflow;
  [HideInInspector]
  [SerializeField]
  private bool mApplyGradient;
  [HideInInspector]
  [SerializeField]
  private Color mGradientTop = Color.white;
  [HideInInspector]
  [SerializeField]
  private Color mGradientBottom = new Color(0.7f, 0.7f, 0.7f);
  [HideInInspector]
  [SerializeField]
  private int mSpacingX;
  [HideInInspector]
  [SerializeField]
  private int mSpacingY;
  [HideInInspector]
  [SerializeField]
  private bool mUseFloatSpacing;
  [HideInInspector]
  [SerializeField]
  private float mFloatSpacingX;
  [HideInInspector]
  [SerializeField]
  private float mFloatSpacingY;
  [HideInInspector]
  [SerializeField]
  private bool mOverflowEllipsis;
  [HideInInspector]
  [SerializeField]
  private int mOverflowWidth;
  [HideInInspector]
  [SerializeField]
  private int mOverflowHeight;
  [HideInInspector]
  [SerializeField]
  private UILabel.Modifier mModifier;
  [HideInInspector]
  [SerializeField]
  private bool mShrinkToFit;
  [HideInInspector]
  [SerializeField]
  private int mMaxLineWidth;
  [HideInInspector]
  [SerializeField]
  private int mMaxLineHeight;
  [HideInInspector]
  [SerializeField]
  private float mLineWidth;
  [HideInInspector]
  [SerializeField]
  private bool mMultiline = true;
  [NonSerialized]
  private Font mActiveTTF;
  [NonSerialized]
  private float mDensity = 1f;
  [NonSerialized]
  private bool mShouldBeProcessed = true;
  [NonSerialized]
  private string mProcessedText;
  [NonSerialized]
  private bool mPremultiply;
  [NonSerialized]
  private Vector2 mCalculatedSize = Vector2.zero;
  [NonSerialized]
  private float mScale = 1f;
  [NonSerialized]
  private int mFinalFontSize;
  [NonSerialized]
  private int mLastWidth;
  [NonSerialized]
  private int mLastHeight;
  public UILabel.ModifierFunc customModifier;
  private static BetterList<UILabel> mList = new BetterList<UILabel>();
  private static Dictionary<Font, int> mFontUsage = new Dictionary<Font, int>();
  [NonSerialized]
  private static BetterList<UIDrawCall> mTempDrawcalls;
  private static bool mTexRebuildAdded = false;
  private static List<Vector3> mTempVerts = new List<Vector3>();
  private static List<int> mTempIndices = new List<int>();

  public int finalFontSize => (bool) (UnityEngine.Object) this.trueTypeFont ? Mathf.RoundToInt(this.mScale * (float) this.mFinalFontSize) : Mathf.RoundToInt((float) this.mFontSize * this.mScale);

  private bool shouldBeProcessed
  {
    get => this.mShouldBeProcessed;
    set
    {
      if (value)
      {
        this.mChanged = true;
        this.mShouldBeProcessed = true;
      }
      else
        this.mShouldBeProcessed = false;
    }
  }

  public override bool isAnchoredHorizontally => base.isAnchoredHorizontally || this.mOverflow == UILabel.Overflow.ResizeFreely;

  public override bool isAnchoredVertically => base.isAnchoredVertically || this.mOverflow == UILabel.Overflow.ResizeFreely || this.mOverflow == UILabel.Overflow.ResizeHeight;

  public override Material material
  {
    get
    {
      if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
        return this.mMat;
      INGUIFont bitmapFont = this.bitmapFont;
      if (bitmapFont != null)
        return bitmapFont.material;
      return (UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) null ? this.mTrueTypeFont.material : (Material) null;
    }
    set => base.material = value;
  }

  public override Texture mainTexture
  {
    get
    {
      INGUIFont bitmapFont = this.bitmapFont;
      if (bitmapFont != null)
        return (Texture) bitmapFont.texture;
      if ((UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) null)
      {
        Material material = this.mTrueTypeFont.material;
        if ((UnityEngine.Object) material != (UnityEngine.Object) null)
          return material.mainTexture;
      }
      return (Texture) null;
    }
    set => base.mainTexture = value;
  }

  [Obsolete("Use UILabel.bitmapFont instead")]
  public UnityEngine.Object font
  {
    get => this.bitmapFont as UnityEngine.Object;
    set => this.bitmapFont = value as INGUIFont;
  }

  public INGUIFont bitmapFont
  {
    get => this.mFont as INGUIFont;
    set
    {
      if (this.mFont as INGUIFont == value)
        return;
      this.RemoveFromPanel();
      this.mFont = value as UnityEngine.Object;
      this.mTrueTypeFont = (Font) null;
      this.MarkAsChanged();
    }
  }

  public INGUIAtlas atlas
  {
    get => this.bitmapFont?.atlas;
    set
    {
      INGUIFont bitmapFont = this.bitmapFont;
      if (bitmapFont == null)
        return;
      bitmapFont.atlas = value;
    }
  }

  public Font trueTypeFont
  {
    get
    {
      if ((UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) null)
        return this.mTrueTypeFont;
      return this.bitmapFont?.dynamicFont;
    }
    set
    {
      if (!((UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) value))
        return;
      this.SetActiveFont((Font) null);
      this.RemoveFromPanel();
      this.mTrueTypeFont = value;
      this.shouldBeProcessed = true;
      this.mFont = (UnityEngine.Object) null;
      this.SetActiveFont(value);
      this.ProcessAndRequest();
      if (!((UnityEngine.Object) this.mActiveTTF != (UnityEngine.Object) null))
        return;
      base.MarkAsChanged();
    }
  }

  public UnityEngine.Object ambigiousFont
  {
    get => !(this.mFont != (UnityEngine.Object) null) ? (UnityEngine.Object) this.mTrueTypeFont : this.mFont;
    set
    {
      if (value is INGUIFont nguiFont)
        this.bitmapFont = nguiFont;
      else
        this.trueTypeFont = value as Font;
    }
  }

  public string text
  {
    get => this.mText;
    set
    {
      if (this.mText == value)
        return;
      if (string.IsNullOrEmpty(value))
      {
        if (string.IsNullOrEmpty(this.mText))
          return;
        this.mText = "";
        this.MarkAsChanged();
        this.ProcessAndRequest();
        if (!this.autoResizeBoxCollider)
          return;
        this.ResizeCollider();
      }
      else
      {
        if (!(this.mText != value))
          return;
        this.mText = value;
        this.MarkAsChanged();
        this.ProcessAndRequest();
        if (!this.autoResizeBoxCollider)
          return;
        this.ResizeCollider();
      }
    }
  }

  public int defaultFontSize
  {
    get
    {
      if ((UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null)
        return this.mFontSize;
      INGUIFont bitmapFont = this.bitmapFont;
      return bitmapFont != null ? bitmapFont.defaultSize : 16;
    }
  }

  public int fontSize
  {
    get => this.mFontSize;
    set
    {
      value = Mathf.Clamp(value, 0, 256);
      if (this.mFontSize == value)
        return;
      this.mFontSize = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public FontStyle fontStyle
  {
    get => this.mFontStyle;
    set
    {
      if (this.mFontStyle == value)
        return;
      this.mFontStyle = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public NGUIText.Alignment alignment
  {
    get => this.mAlignment;
    set
    {
      if (this.mAlignment == value)
        return;
      this.mAlignment = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public bool applyGradient
  {
    get => this.mApplyGradient;
    set
    {
      if (this.mApplyGradient == value)
        return;
      this.mApplyGradient = value;
      this.MarkAsChanged();
    }
  }

  public Color gradientTop
  {
    get => this.mGradientTop;
    set
    {
      if (!(this.mGradientTop != value))
        return;
      this.mGradientTop = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public Color gradientBottom
  {
    get => this.mGradientBottom;
    set
    {
      if (!(this.mGradientBottom != value))
        return;
      this.mGradientBottom = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public int spacingX
  {
    get => this.mSpacingX;
    set
    {
      if (this.mSpacingX == value)
        return;
      this.mSpacingX = value;
      this.MarkAsChanged();
    }
  }

  public int spacingY
  {
    get => this.mSpacingY;
    set
    {
      if (this.mSpacingY == value)
        return;
      this.mSpacingY = value;
      this.MarkAsChanged();
    }
  }

  public bool useFloatSpacing
  {
    get => this.mUseFloatSpacing;
    set
    {
      if (this.mUseFloatSpacing == value)
        return;
      this.mUseFloatSpacing = value;
      this.shouldBeProcessed = true;
    }
  }

  public float floatSpacingX
  {
    get => this.mFloatSpacingX;
    set
    {
      if (Mathf.Approximately(this.mFloatSpacingX, value))
        return;
      this.mFloatSpacingX = value;
      this.MarkAsChanged();
    }
  }

  public float floatSpacingY
  {
    get => this.mFloatSpacingY;
    set
    {
      if (Mathf.Approximately(this.mFloatSpacingY, value))
        return;
      this.mFloatSpacingY = value;
      this.MarkAsChanged();
    }
  }

  public float effectiveSpacingY => !this.mUseFloatSpacing ? (float) this.mSpacingY : this.mFloatSpacingY;

  public float effectiveSpacingX => !this.mUseFloatSpacing ? (float) this.mSpacingX : this.mFloatSpacingX;

  public bool overflowEllipsis
  {
    get => this.mOverflowEllipsis;
    set
    {
      if (this.mOverflowEllipsis == value)
        return;
      this.mOverflowEllipsis = value;
      this.MarkAsChanged();
    }
  }

  public int overflowWidth
  {
    get => this.mOverflowWidth;
    set
    {
      if (value < 0)
        value = 0;
      if (this.mOverflowWidth == value)
        return;
      this.mOverflowWidth = value;
      this.MarkAsChanged();
    }
  }

  public int overflowHeight
  {
    get => this.mOverflowHeight;
    set
    {
      if (value < 0)
        value = 0;
      if (this.mOverflowHeight == value)
        return;
      this.mOverflowHeight = value;
      this.MarkAsChanged();
    }
  }

  private bool keepCrisp => (UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null && this.keepCrispWhenShrunk != UILabel.Crispness.Never;

  public bool supportEncoding
  {
    get => this.mEncoding;
    set
    {
      if (this.mEncoding == value)
        return;
      this.mEncoding = value;
      this.shouldBeProcessed = true;
    }
  }

  public NGUIText.SymbolStyle symbolStyle
  {
    get => this.mSymbols;
    set
    {
      if (this.mSymbols == value)
        return;
      this.mSymbols = value;
      this.shouldBeProcessed = true;
    }
  }

  public UILabel.Overflow overflowMethod
  {
    get => this.mOverflow;
    set
    {
      if (this.mOverflow == value)
        return;
      this.mOverflow = value;
      this.shouldBeProcessed = true;
    }
  }

  [Obsolete("Use 'width' instead")]
  public int lineWidth
  {
    get => this.width;
    set => this.width = value;
  }

  [Obsolete("Use 'height' instead")]
  public int lineHeight
  {
    get => this.height;
    set => this.height = value;
  }

  public bool multiLine
  {
    get => this.mMaxLineCount != 1;
    set
    {
      if (this.mMaxLineCount != 1 == value)
        return;
      this.mMaxLineCount = value ? 0 : 1;
      this.shouldBeProcessed = true;
    }
  }

  public override Vector3[] localCorners
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.localCorners;
    }
  }

  public override Vector3[] worldCorners
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.worldCorners;
    }
  }

  public override Vector4 drawingDimensions
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.drawingDimensions;
    }
  }

  public int maxLineCount
  {
    get => this.mMaxLineCount;
    set
    {
      if (this.mMaxLineCount == value)
        return;
      this.mMaxLineCount = Mathf.Max(value, 0);
      this.shouldBeProcessed = true;
      if (this.overflowMethod != UILabel.Overflow.ShrinkContent)
        return;
      this.MakePixelPerfect();
    }
  }

  public UILabel.Effect effectStyle
  {
    get => this.mEffectStyle;
    set
    {
      if (this.mEffectStyle == value)
        return;
      this.mEffectStyle = value;
      this.shouldBeProcessed = true;
    }
  }

  public Color effectColor
  {
    get => this.mEffectColor;
    set
    {
      if (!(this.mEffectColor != value))
        return;
      this.mEffectColor = value;
      if (this.mEffectStyle == UILabel.Effect.None)
        return;
      this.shouldBeProcessed = true;
    }
  }

  public Vector2 effectDistance
  {
    get => this.mEffectDistance;
    set
    {
      if (!(this.mEffectDistance != value))
        return;
      this.mEffectDistance = value;
      this.shouldBeProcessed = true;
    }
  }

  public int quadsPerCharacter
  {
    get
    {
      if (this.mEffectStyle == UILabel.Effect.Shadow)
        return 2;
      if (this.mEffectStyle == UILabel.Effect.Outline)
        return 5;
      return this.mEffectStyle == UILabel.Effect.Outline8 ? 9 : 1;
    }
  }

  [Obsolete("Use 'overflowMethod == UILabel.Overflow.ShrinkContent' instead")]
  public bool shrinkToFit
  {
    get => this.mOverflow == UILabel.Overflow.ShrinkContent;
    set
    {
      if (!value)
        return;
      this.overflowMethod = UILabel.Overflow.ShrinkContent;
    }
  }

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
        this.ProcessText();
      return this.mProcessedText;
    }
  }

  public Vector2 printedSize
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return this.mCalculatedSize;
    }
  }

  public override Vector2 localSize
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.localSize;
    }
  }

  private bool isValid => this.mFont != (UnityEngine.Object) null || (UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) null;

  public UILabel.Modifier modifier
  {
    get => this.mModifier;
    set
    {
      if (this.mModifier == value)
        return;
      this.mModifier = value;
      this.MarkAsChanged();
      this.ProcessAndRequest();
    }
  }

  protected override void OnInit()
  {
    base.OnInit();
    UILabel.mList.Add(this);
    this.SetActiveFont(this.trueTypeFont);
  }

  protected override void OnDisable()
  {
    this.SetActiveFont((Font) null);
    UILabel.mList.Remove(this);
    base.OnDisable();
  }

  protected void SetActiveFont(Font fnt)
  {
    if (!((UnityEngine.Object) this.mActiveTTF != (UnityEngine.Object) fnt))
      return;
    Font mActiveTtf = this.mActiveTTF;
    int num1;
    if ((UnityEngine.Object) mActiveTtf != (UnityEngine.Object) null && UILabel.mFontUsage.TryGetValue(mActiveTtf, out num1))
    {
      int num2;
      int num3 = Mathf.Max(0, num2 = num1 - 1);
      if (num3 == 0)
        UILabel.mFontUsage.Remove(mActiveTtf);
      else
        UILabel.mFontUsage[mActiveTtf] = num3;
    }
    this.mActiveTTF = fnt;
    Font key = fnt;
    if (!((UnityEngine.Object) key != (UnityEngine.Object) null))
      return;
    int num4 = 0;
    int num5;
    UILabel.mFontUsage[key] = num5 = num4 + 1;
  }

  public string printedText
  {
    get
    {
      if (!string.IsNullOrEmpty(this.mText) && this.mModifier != UILabel.Modifier.None)
      {
        if (this.mModifier == UILabel.Modifier.ToLowercase)
          return this.mText.ToLower();
        if (this.mModifier == UILabel.Modifier.ToUppercase)
          return this.mText.ToUpper();
        if (this.mModifier == UILabel.Modifier.Custom && this.customModifier != null)
          return this.customModifier(this.mText);
      }
      return this.mText;
    }
  }

  private static void OnFontChanged(Font font)
  {
    for (int index = 0; index < UILabel.mList.size; ++index)
    {
      UILabel uiLabel = UILabel.mList.buffer[index];
      if ((UnityEngine.Object) uiLabel != (UnityEngine.Object) null)
      {
        Font trueTypeFont = uiLabel.trueTypeFont;
        if ((UnityEngine.Object) trueTypeFont == (UnityEngine.Object) font)
        {
          trueTypeFont.RequestCharactersInTexture(uiLabel.mText, uiLabel.mFinalFontSize, uiLabel.mFontStyle);
          uiLabel.MarkAsChanged();
          if ((UnityEngine.Object) uiLabel.panel == (UnityEngine.Object) null)
            uiLabel.CreatePanel();
          if (UILabel.mTempDrawcalls == null)
            UILabel.mTempDrawcalls = new BetterList<UIDrawCall>();
          if ((UnityEngine.Object) uiLabel.drawCall != (UnityEngine.Object) null && !UILabel.mTempDrawcalls.Contains(uiLabel.drawCall))
            UILabel.mTempDrawcalls.Add(uiLabel.drawCall);
        }
      }
    }
    if (UILabel.mTempDrawcalls == null)
      return;
    int index1 = 0;
    for (int size = UILabel.mTempDrawcalls.size; index1 < size; ++index1)
    {
      UIDrawCall dc = UILabel.mTempDrawcalls.buffer[index1];
      if ((UnityEngine.Object) dc.panel != (UnityEngine.Object) null)
        dc.panel.FillDrawCall(dc);
    }
    UILabel.mTempDrawcalls.Clear();
  }

  public override Vector3[] GetSides(Transform relativeTo)
  {
    if (this.shouldBeProcessed)
      this.ProcessText();
    return base.GetSides(relativeTo);
  }

  protected override void UpgradeFrom265()
  {
    this.ProcessText(true);
    if (this.mShrinkToFit)
    {
      this.overflowMethod = UILabel.Overflow.ShrinkContent;
      this.mMaxLineCount = 0;
    }
    if (this.mMaxLineWidth != 0)
    {
      this.width = this.mMaxLineWidth;
      this.overflowMethod = this.mMaxLineCount > 0 ? UILabel.Overflow.ResizeHeight : UILabel.Overflow.ShrinkContent;
    }
    else
      this.overflowMethod = UILabel.Overflow.ResizeFreely;
    if (this.mMaxLineHeight != 0)
      this.height = this.mMaxLineHeight;
    if (this.mFont != (UnityEngine.Object) null)
    {
      int defaultFontSize = this.defaultFontSize;
      if (this.height < defaultFontSize)
        this.height = defaultFontSize;
      this.fontSize = defaultFontSize;
    }
    this.mMaxLineWidth = 0;
    this.mMaxLineHeight = 0;
    this.mShrinkToFit = false;
    NGUITools.UpdateWidgetCollider(this.gameObject, true);
  }

  protected override void OnAnchor()
  {
    if (this.mOverflow == UILabel.Overflow.ResizeFreely)
    {
      if (this.isFullyAnchored)
        this.mOverflow = UILabel.Overflow.ShrinkContent;
    }
    else if (this.mOverflow == UILabel.Overflow.ResizeHeight && (UnityEngine.Object) this.topAnchor.target != (UnityEngine.Object) null && (UnityEngine.Object) this.bottomAnchor.target != (UnityEngine.Object) null)
      this.mOverflow = UILabel.Overflow.ShrinkContent;
    base.OnAnchor();
  }

  private void ProcessAndRequest()
  {
    if (!(this.ambigiousFont != (UnityEngine.Object) null))
      return;
    this.ProcessText();
  }

  protected override void OnEnable()
  {
    base.OnEnable();
    if (UILabel.mTexRebuildAdded)
      return;
    UILabel.mTexRebuildAdded = true;
    Font.textureRebuilt += new System.Action<Font>(UILabel.OnFontChanged);
  }

  protected override void OnStart()
  {
    base.OnStart();
    if ((double) this.mLineWidth > 0.0)
    {
      this.mMaxLineWidth = Mathf.RoundToInt(this.mLineWidth);
      this.mLineWidth = 0.0f;
    }
    if (!this.mMultiline)
    {
      this.mMaxLineCount = 1;
      this.mMultiline = true;
    }
    this.mPremultiply = (UnityEngine.Object) this.material != (UnityEngine.Object) null && (UnityEngine.Object) this.material.shader != (UnityEngine.Object) null && this.material.shader.name.Contains("Premultiplied");
    this.ProcessAndRequest();
  }

  public override void MarkAsChanged()
  {
    this.shouldBeProcessed = true;
    base.MarkAsChanged();
  }

  public void ProcessText(bool legacyMode = false, bool full = true)
  {
    if (!this.isValid)
      return;
    this.mChanged = true;
    this.shouldBeProcessed = false;
    float num1 = this.mDrawRegion.z - this.mDrawRegion.x;
    float num2 = this.mDrawRegion.w - this.mDrawRegion.y;
    NGUIText.rectWidth = legacyMode ? (this.mMaxLineWidth != 0 ? this.mMaxLineWidth : 1000000) : this.width;
    NGUIText.rectHeight = legacyMode ? (this.mMaxLineHeight != 0 ? this.mMaxLineHeight : 1000000) : this.height;
    NGUIText.regionWidth = (double) num1 != 1.0 ? Mathf.RoundToInt((float) NGUIText.rectWidth * num1) : NGUIText.rectWidth;
    NGUIText.regionHeight = (double) num2 != 1.0 ? Mathf.RoundToInt((float) NGUIText.rectHeight * num2) : NGUIText.rectHeight;
    this.mFinalFontSize = Mathf.Abs(legacyMode ? Mathf.RoundToInt(this.cachedTransform.localScale.x) : this.defaultFontSize);
    this.mScale = 1f;
    if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 0)
    {
      this.mProcessedText = "";
    }
    else
    {
      if ((UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null && this.keepCrisp)
      {
        UIRoot root = this.root;
        if ((UnityEngine.Object) root != (UnityEngine.Object) null)
          this.mDensity = (UnityEngine.Object) root != (UnityEngine.Object) null ? root.pixelSizeAdjustment : 1f;
      }
      else
        this.mDensity = 1f;
      if (full)
        this.UpdateNGUIText();
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
        int num3;
        for (int index = this.mFinalFontSize; index > 0; index = num3 - 1)
        {
          if (keepCrisp)
          {
            this.mFinalFontSize = index;
            NGUIText.fontSize = this.mFinalFontSize;
          }
          else
          {
            this.mScale = (float) index / (float) this.mFinalFontSize;
            NGUIText.fontScale = this.bitmapFont == null ? this.mScale : (float) this.mFontSize / (float) this.defaultFontSize * this.mScale;
          }
          NGUIText.Update(false);
          bool flag = NGUIText.WrapText(this.printedText, out this.mProcessedText, false, false, this.mOverflow == UILabel.Overflow.ClampContent && this.mOverflowEllipsis);
          if (this.mOverflow == UILabel.Overflow.ShrinkContent && !flag)
          {
            if ((num3 = index - 1) <= 1)
              break;
          }
          else
          {
            if (this.mOverflow == UILabel.Overflow.ResizeFreely)
            {
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
              if (!flag && this.mOverflowWidth > 0)
              {
                if ((num3 = index - 1) <= 1)
                  break;
                continue;
              }
              int num4 = Mathf.Max(this.minWidth, Mathf.RoundToInt(this.mCalculatedSize.x));
              if ((double) num1 != 1.0)
                num4 = Mathf.RoundToInt((float) num4 / num1);
              int num5 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
              if ((double) num2 != 1.0)
                num5 = Mathf.RoundToInt((float) num5 / num2);
              if ((num4 & 1) == 1)
                ++num4;
              if ((num5 & 1) == 1)
                ++num5;
              if (this.mWidth != num4 || this.mHeight != num5)
              {
                this.mWidth = num4;
                this.mHeight = num5;
                if (this.onChange != null)
                  this.onChange();
              }
            }
            else if (this.mOverflow == UILabel.Overflow.ResizeHeight)
            {
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
              int num6 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
              if ((double) num2 != 1.0)
                num6 = Mathf.RoundToInt((float) num6 / num2);
              if ((num6 & 1) == 1)
                ++num6;
              if (this.mHeight != num6)
              {
                this.mHeight = num6;
                if (this.onChange != null)
                  this.onChange();
              }
            }
            else
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
            if (legacyMode)
            {
              this.width = Mathf.RoundToInt(this.mCalculatedSize.x);
              this.height = Mathf.RoundToInt(this.mCalculatedSize.y);
              this.cachedTransform.localScale = Vector3.one;
              break;
            }
            break;
          }
        }
      }
      else
      {
        this.cachedTransform.localScale = Vector3.one;
        this.mProcessedText = "";
        this.mScale = 1f;
      }
      if (!full)
        return;
      NGUIText.bitmapFont = (INGUIFont) null;
      NGUIText.dynamicFont = (Font) null;
    }
  }

  public override void MakePixelPerfect()
  {
    if (this.ambigiousFont != (UnityEngine.Object) null)
    {
      Vector3 localPosition = this.cachedTransform.localPosition;
      localPosition.x = (float) Mathf.RoundToInt(localPosition.x);
      localPosition.y = (float) Mathf.RoundToInt(localPosition.y);
      localPosition.z = (float) Mathf.RoundToInt(localPosition.z);
      this.cachedTransform.localPosition = localPosition;
      this.cachedTransform.localScale = Vector3.one;
      if (this.mOverflow == UILabel.Overflow.ResizeFreely)
      {
        this.AssumeNaturalSize();
      }
      else
      {
        int width = this.width;
        int height = this.height;
        UILabel.Overflow mOverflow = this.mOverflow;
        if (mOverflow != UILabel.Overflow.ResizeHeight)
          this.mWidth = 100000;
        this.mHeight = 100000;
        this.mOverflow = UILabel.Overflow.ShrinkContent;
        this.ProcessText();
        this.mOverflow = mOverflow;
        int a1 = Mathf.RoundToInt(this.mCalculatedSize.x);
        int a2 = Mathf.RoundToInt(this.mCalculatedSize.y);
        int b1 = Mathf.Max(a1, this.minWidth);
        int b2 = Mathf.Max(a2, this.minHeight);
        if ((b1 & 1) == 1)
          ++b1;
        if ((b2 & 1) == 1)
          ++b2;
        this.mWidth = Mathf.Max(width, b1);
        this.mHeight = Mathf.Max(height, b2);
        this.MarkAsChanged();
      }
    }
    else
      base.MakePixelPerfect();
  }

  public void AssumeNaturalSize()
  {
    if (!(this.ambigiousFont != (UnityEngine.Object) null))
      return;
    this.mWidth = 100000;
    this.mHeight = 100000;
    this.ProcessText();
    this.mWidth = Mathf.RoundToInt(this.mCalculatedSize.x);
    this.mHeight = Mathf.RoundToInt(this.mCalculatedSize.y);
    if ((this.mWidth & 1) == 1)
      ++this.mWidth;
    if ((this.mHeight & 1) == 1)
      ++this.mHeight;
    this.MarkAsChanged();
  }

  [Obsolete("Use UILabel.GetCharacterAtPosition instead")]
  public int GetCharacterIndex(Vector3 worldPos) => this.GetCharacterIndexAtPosition(worldPos, false);

  [Obsolete("Use UILabel.GetCharacterAtPosition instead")]
  public int GetCharacterIndex(Vector2 localPos) => this.GetCharacterIndexAtPosition(localPos, false);

  public int GetCharacterIndexAtPosition(Vector3 worldPos, bool precise) => this.GetCharacterIndexAtPosition((Vector2) this.cachedTransform.InverseTransformPoint(worldPos), precise);

  public int GetCharacterIndexAtPosition(Vector2 localPos, bool precise)
  {
    if (this.isValid)
    {
      string processedText = this.processedText;
      if (string.IsNullOrEmpty(processedText))
        return 0;
      this.UpdateNGUIText();
      if (precise)
        NGUIText.PrintExactCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
      else
        NGUIText.PrintApproximateCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
      if (UILabel.mTempVerts.Count > 0)
      {
        this.ApplyOffset(UILabel.mTempVerts, 0);
        int characterIndexAtPosition = precise ? NGUIText.GetExactCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, localPos) : NGUIText.GetApproximateCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, localPos);
        UILabel.mTempVerts.Clear();
        UILabel.mTempIndices.Clear();
        NGUIText.bitmapFont = (INGUIFont) null;
        NGUIText.dynamicFont = (Font) null;
        return characterIndexAtPosition;
      }
      NGUIText.bitmapFont = (INGUIFont) null;
      NGUIText.dynamicFont = (Font) null;
    }
    return 0;
  }

  public string GetWordAtPosition(Vector3 worldPos) => this.GetWordAtCharacterIndex(this.GetCharacterIndexAtPosition(worldPos, true));

  public string GetWordAtPosition(Vector2 localPos) => this.GetWordAtCharacterIndex(this.GetCharacterIndexAtPosition(localPos, true));

  public string GetWordAtCharacterIndex(int characterIndex)
  {
    string printedText = this.printedText;
    if (characterIndex != -1 && characterIndex < printedText.Length)
    {
      int startIndex = printedText.LastIndexOfAny(new char[2]
      {
        ' ',
        '\n'
      }, characterIndex) + 1;
      int num = printedText.IndexOfAny(new char[4]
      {
        ' ',
        '\n',
        ',',
        '.'
      }, characterIndex);
      if (num == -1)
        num = printedText.Length;
      if (startIndex != num)
      {
        int length = num - startIndex;
        if (length > 0)
          return NGUIText.StripSymbols(printedText.Substring(startIndex, length));
      }
    }
    return (string) null;
  }

  public string GetUrlAtPosition(Vector3 worldPos) => this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(worldPos, true));

  public string GetUrlAtPosition(Vector2 localPos) => this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(localPos, true));

  public string GetUrlAtCharacterIndex(int characterIndex)
  {
    string printedText = this.printedText;
    if (characterIndex != -1 && characterIndex < printedText.Length - 6)
    {
      int num1 = printedText[characterIndex] != '[' || printedText[characterIndex + 1] != 'u' || printedText[characterIndex + 2] != 'r' || printedText[characterIndex + 3] != 'l' || printedText[characterIndex + 4] != '=' ? printedText.LastIndexOf("[url=", characterIndex) : characterIndex;
      if (num1 == -1)
        return (string) null;
      int startIndex1 = num1 + 5;
      int startIndex2 = printedText.IndexOf("]", startIndex1);
      if (startIndex2 == -1)
        return (string) null;
      int num2 = printedText.IndexOf("[/url]", startIndex2);
      if (num2 == -1 || characterIndex <= num2)
        return printedText.Substring(startIndex1, startIndex2 - startIndex1);
    }
    return (string) null;
  }

  public int GetCharacterIndex(int currentIndex, KeyCode key)
  {
    if (this.isValid)
    {
      string processedText = this.processedText;
      if (string.IsNullOrEmpty(processedText))
        return 0;
      int defaultFontSize = this.defaultFontSize;
      this.UpdateNGUIText();
      NGUIText.PrintApproximateCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
      if (UILabel.mTempVerts.Count > 0)
      {
        this.ApplyOffset(UILabel.mTempVerts, 0);
        int index = 0;
        for (int count = UILabel.mTempIndices.Count; index < count; ++index)
        {
          if (UILabel.mTempIndices[index] == currentIndex)
          {
            Vector2 mTempVert = (Vector2) UILabel.mTempVerts[index];
            switch (key)
            {
              case KeyCode.UpArrow:
                mTempVert.y += (float) defaultFontSize + this.effectiveSpacingY;
                break;
              case KeyCode.DownArrow:
                mTempVert.y -= (float) defaultFontSize + this.effectiveSpacingY;
                break;
              case KeyCode.Home:
                mTempVert.x -= 1000f;
                break;
              case KeyCode.End:
                mTempVert.x += 1000f;
                break;
            }
            int approximateCharacterIndex = NGUIText.GetApproximateCharacterIndex(UILabel.mTempVerts, UILabel.mTempIndices, mTempVert);
            if (approximateCharacterIndex != currentIndex)
            {
              UILabel.mTempVerts.Clear();
              UILabel.mTempIndices.Clear();
              return approximateCharacterIndex;
            }
            break;
          }
        }
        UILabel.mTempVerts.Clear();
        UILabel.mTempIndices.Clear();
      }
      NGUIText.bitmapFont = (INGUIFont) null;
      NGUIText.dynamicFont = (Font) null;
      switch (key)
      {
        case KeyCode.UpArrow:
        case KeyCode.Home:
          return 0;
        case KeyCode.DownArrow:
        case KeyCode.End:
          return processedText.Length;
      }
    }
    return currentIndex;
  }

  public void PrintOverlay(
    int start,
    int end,
    UIGeometry caret,
    UIGeometry highlight,
    Color caretColor,
    Color highlightColor)
  {
    caret?.Clear();
    highlight?.Clear();
    if (!this.isValid)
      return;
    string processedText = this.processedText;
    this.UpdateNGUIText();
    int count1 = caret.verts.Count;
    Vector2 vector2 = new Vector2(0.5f, 0.5f);
    float finalAlpha = this.finalAlpha;
    if (highlight != null && start != end)
    {
      int count2 = highlight.verts.Count;
      NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, highlight.verts);
      if (highlight.verts.Count > count2)
      {
        this.ApplyOffset(highlight.verts, count2);
        Color color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, highlightColor.a * finalAlpha);
        int num = count2;
        for (int count3 = highlight.verts.Count; num < count3; ++num)
        {
          highlight.uvs.Add(vector2);
          highlight.cols.Add(color);
        }
      }
    }
    else
      NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, (List<Vector3>) null);
    this.ApplyOffset(caret.verts, count1);
    Color color1 = new Color(caretColor.r, caretColor.g, caretColor.b, caretColor.a * finalAlpha);
    int num1 = count1;
    for (int count4 = caret.verts.Count; num1 < count4; ++num1)
    {
      caret.uvs.Add(vector2);
      caret.cols.Add(color1);
    }
    NGUIText.bitmapFont = (INGUIFont) null;
    NGUIText.dynamicFont = (Font) null;
  }

  private bool premultipliedAlphaShader
  {
    get
    {
      INGUIFont bitmapFont = this.bitmapFont;
      return bitmapFont != null && bitmapFont.premultipliedAlphaShader;
    }
  }

  private bool packedFontShader
  {
    get
    {
      INGUIFont bitmapFont = this.bitmapFont;
      return bitmapFont != null && bitmapFont.packedFontShader;
    }
  }

  public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    if (!this.isValid)
      return;
    int num = verts.Count;
    Color c = this.color with { a = this.finalAlpha };
    if (this.premultipliedAlphaShader)
      c = NGUITools.ApplyPMA(c);
    string processedText = this.processedText;
    int count1 = verts.Count;
    this.UpdateNGUIText();
    NGUIText.tint = c;
    List<Vector3> verts1 = verts;
    List<Vector2> uvs1 = uvs;
    List<Color> cols1 = cols;
    NGUIText.Print(processedText, verts1, uvs1, cols1);
    NGUIText.bitmapFont = (INGUIFont) null;
    NGUIText.dynamicFont = (Font) null;
    Vector2 vector2 = this.ApplyOffset(verts, count1);
    if (this.packedFontShader)
      return;
    if (this.effectStyle != UILabel.Effect.None)
    {
      int count2 = verts.Count;
      vector2.x = this.mEffectDistance.x;
      vector2.y = this.mEffectDistance.y;
      this.ApplyShadow(verts, uvs, cols, num, count2, vector2.x, -vector2.y);
      if (this.effectStyle == UILabel.Effect.Outline || this.effectStyle == UILabel.Effect.Outline8)
      {
        int start1 = count2;
        int count3 = verts.Count;
        this.ApplyShadow(verts, uvs, cols, start1, count3, -vector2.x, vector2.y);
        int start2 = count3;
        int count4 = verts.Count;
        this.ApplyShadow(verts, uvs, cols, start2, count4, vector2.x, vector2.y);
        num = count4;
        int count5 = verts.Count;
        this.ApplyShadow(verts, uvs, cols, num, count5, -vector2.x, -vector2.y);
        if (this.effectStyle == UILabel.Effect.Outline8)
        {
          int start3 = count5;
          int count6 = verts.Count;
          this.ApplyShadow(verts, uvs, cols, start3, count6, -vector2.x, 0.0f);
          int start4 = count6;
          int count7 = verts.Count;
          this.ApplyShadow(verts, uvs, cols, start4, count7, vector2.x, 0.0f);
          int start5 = count7;
          int count8 = verts.Count;
          this.ApplyShadow(verts, uvs, cols, start5, count8, 0.0f, vector2.y);
          num = count8;
          int count9 = verts.Count;
          this.ApplyShadow(verts, uvs, cols, num, count9, 0.0f, -vector2.y);
        }
      }
    }
    if (NGUIText.symbolStyle == NGUIText.SymbolStyle.NoOutline)
    {
      int index = 0;
      for (int count10 = cols.Count; index < count10; ++index)
      {
        if ((double) cols[index].r == -1.0)
          cols[index] = Color.white;
      }
    }
    if (this.onPostFill == null)
      return;
    this.onPostFill((UIWidget) this, num, verts, uvs, cols);
  }

  public Vector2 ApplyOffset(List<Vector3> verts, int start)
  {
    Vector2 pivotOffset = this.pivotOffset;
    float f1 = Mathf.Lerp(0.0f, (float) -this.mWidth, pivotOffset.x);
    float f2 = Mathf.Lerp((float) this.mHeight, 0.0f, pivotOffset.y) + Mathf.Lerp(this.mCalculatedSize.y - (float) this.mHeight, 0.0f, pivotOffset.y);
    float x = Mathf.Round(f1);
    float y = Mathf.Round(f2);
    int index = start;
    for (int count = verts.Count; index < count; ++index)
    {
      Vector3 vert = verts[index];
      vert.x += x;
      vert.y += y;
      verts[index] = vert;
    }
    return new Vector2(x, y);
  }

  public void ApplyShadow(
    List<Vector3> verts,
    List<Vector2> uvs,
    List<Color> cols,
    int start,
    int end,
    float x,
    float y)
  {
    Color c = this.mEffectColor;
    c.a *= this.finalAlpha;
    if (this.premultipliedAlphaShader)
      c = NGUITools.ApplyPMA(c);
    Color color1 = c;
    for (int index = start; index < end; ++index)
    {
      verts.Add(verts[index]);
      uvs.Add(uvs[index]);
      cols.Add(cols[index]);
      Vector3 vert = verts[index];
      vert.x += x;
      vert.y += y;
      verts[index] = vert;
      Color col = cols[index];
      if ((double) col.a == 1.0)
      {
        cols[index] = color1;
      }
      else
      {
        Color color2 = c with { a = col.a * c.a };
        cols[index] = color2;
      }
    }
  }

  public int CalculateOffsetToFit(string text)
  {
    this.UpdateNGUIText();
    NGUIText.encoding = false;
    NGUIText.symbolStyle = NGUIText.SymbolStyle.None;
    int offsetToFit = NGUIText.CalculateOffsetToFit(text);
    NGUIText.bitmapFont = (INGUIFont) null;
    NGUIText.dynamicFont = (Font) null;
    return offsetToFit;
  }

  public void SetCurrentProgress()
  {
    if (!((UnityEngine.Object) UIProgressBar.current != (UnityEngine.Object) null))
      return;
    this.text = UIProgressBar.current.value.ToString("F");
  }

  public void SetCurrentPercent()
  {
    if (!((UnityEngine.Object) UIProgressBar.current != (UnityEngine.Object) null))
      return;
    this.text = Mathf.RoundToInt(UIProgressBar.current.value * 100f).ToString() + "%";
  }

  public void SetCurrentSelection()
  {
    if (!((UnityEngine.Object) UIPopupList.current != (UnityEngine.Object) null))
      return;
    this.text = UIPopupList.current.isLocalized ? Localization.Get(UIPopupList.current.value) : UIPopupList.current.value;
  }

  public bool Wrap(string text, out string final) => this.Wrap(text, out final, 1000000);

  public bool Wrap(string text, out string final, int height)
  {
    this.UpdateNGUIText();
    NGUIText.rectHeight = height;
    NGUIText.regionHeight = height;
    int num = NGUIText.WrapText(text, out final) ? 1 : 0;
    NGUIText.bitmapFont = (INGUIFont) null;
    NGUIText.dynamicFont = (Font) null;
    return num != 0;
  }

  public void UpdateNGUIText()
  {
    Font trueTypeFont = this.trueTypeFont;
    int num = (UnityEngine.Object) trueTypeFont != (UnityEngine.Object) null ? 1 : 0;
    NGUIText.fontSize = this.mFinalFontSize;
    NGUIText.fontStyle = this.mFontStyle;
    NGUIText.rectWidth = this.mWidth;
    NGUIText.rectHeight = this.mHeight;
    NGUIText.regionWidth = Mathf.RoundToInt((float) this.mWidth * (this.mDrawRegion.z - this.mDrawRegion.x));
    NGUIText.regionHeight = Mathf.RoundToInt((float) this.mHeight * (this.mDrawRegion.w - this.mDrawRegion.y));
    NGUIText.gradient = this.mApplyGradient && !this.packedFontShader;
    NGUIText.gradientTop = this.mGradientTop;
    NGUIText.gradientBottom = this.mGradientBottom;
    NGUIText.encoding = this.mEncoding;
    NGUIText.premultiply = this.mPremultiply;
    NGUIText.symbolStyle = this.mSymbols;
    NGUIText.maxLines = this.mMaxLineCount;
    NGUIText.spacingX = this.effectiveSpacingX;
    NGUIText.spacingY = this.effectiveSpacingY;
    INGUIFont nguiFont = this.bitmapFont;
    if (num != 0)
      NGUIText.fontScale = this.mScale;
    else if (nguiFont != null)
    {
      nguiFont = nguiFont.finalFont;
      NGUIText.fontScale = (float) this.mFontSize / (float) nguiFont.defaultSize * this.mScale;
    }
    else
      NGUIText.fontScale = this.mScale;
    if (nguiFont != null)
    {
      if ((UnityEngine.Object) trueTypeFont != (UnityEngine.Object) null)
      {
        NGUIText.dynamicFont = trueTypeFont;
        NGUIText.bitmapFont = (INGUIFont) null;
      }
      else
      {
        NGUIText.dynamicFont = (Font) null;
        NGUIText.bitmapFont = nguiFont;
      }
    }
    else
    {
      NGUIText.dynamicFont = trueTypeFont;
      NGUIText.bitmapFont = (INGUIFont) null;
    }
    if (num != 0 && this.keepCrisp)
    {
      UIRoot root = this.root;
      if ((UnityEngine.Object) root != (UnityEngine.Object) null)
        NGUIText.pixelDensity = (UnityEngine.Object) root != (UnityEngine.Object) null ? root.pixelSizeAdjustment : 1f;
    }
    else
      NGUIText.pixelDensity = 1f;
    if ((double) this.mDensity != (double) NGUIText.pixelDensity)
    {
      this.ProcessText(full: false);
      NGUIText.rectWidth = this.mWidth;
      NGUIText.rectHeight = this.mHeight;
      NGUIText.regionWidth = Mathf.RoundToInt((float) this.mWidth * (this.mDrawRegion.z - this.mDrawRegion.x));
      NGUIText.regionHeight = Mathf.RoundToInt((float) this.mHeight * (this.mDrawRegion.w - this.mDrawRegion.y));
    }
    if (this.alignment == NGUIText.Alignment.Automatic)
    {
      switch (this.pivot)
      {
        case UIWidget.Pivot.TopLeft:
        case UIWidget.Pivot.Left:
        case UIWidget.Pivot.BottomLeft:
          NGUIText.alignment = NGUIText.Alignment.Left;
          break;
        case UIWidget.Pivot.TopRight:
        case UIWidget.Pivot.Right:
        case UIWidget.Pivot.BottomRight:
          NGUIText.alignment = NGUIText.Alignment.Right;
          break;
        default:
          NGUIText.alignment = NGUIText.Alignment.Center;
          break;
      }
    }
    else
      NGUIText.alignment = this.alignment;
    NGUIText.Update();
  }

  private void OnApplicationPause(bool paused)
  {
    if (paused || !((UnityEngine.Object) this.mTrueTypeFont != (UnityEngine.Object) null))
      return;
    this.Invalidate(false);
  }

  [DoNotObfuscateNGUI]
  public enum Effect
  {
    None,
    Shadow,
    Outline,
    Outline8,
  }

  [DoNotObfuscateNGUI]
  public enum Overflow
  {
    ShrinkContent,
    ClampContent,
    ResizeFreely,
    ResizeHeight,
  }

  [DoNotObfuscateNGUI]
  public enum Crispness
  {
    Never,
    OnDesktop,
    Always,
  }

  [DoNotObfuscateNGUI]
  public enum Modifier
  {
    None = 0,
    ToUppercase = 1,
    ToLowercase = 2,
    Custom = 255, // 0x000000FF
  }

  public delegate string ModifierFunc(string s);
}
