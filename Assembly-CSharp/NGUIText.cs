// Decompiled with JetBrains decompiler
// Type: NGUIText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public static class NGUIText
{
  public static INGUIFont bitmapFont;
  public static Font dynamicFont;
  public static NGUIText.GlyphInfo glyph = new NGUIText.GlyphInfo();
  public static int fontSize = 16;
  public static float fontScale = 1f;
  public static float pixelDensity = 1f;
  public static FontStyle fontStyle = FontStyle.Normal;
  public static NGUIText.Alignment alignment = NGUIText.Alignment.Left;
  public static Color tint = Color.white;
  public static int rectWidth = 1000000;
  public static int rectHeight = 1000000;
  public static int regionWidth = 1000000;
  public static int regionHeight = 1000000;
  public static int maxLines = 0;
  public static bool gradient = false;
  public static Color gradientBottom = Color.white;
  public static Color gradientTop = Color.white;
  public static bool encoding = false;
  public static float spacingX = 0.0f;
  public static float spacingY = 0.0f;
  public static bool premultiply = false;
  public static NGUIText.SymbolStyle symbolStyle;
  public static int finalSize = 0;
  public static float finalSpacingX = 0.0f;
  public static float finalLineHeight = 0.0f;
  public static float baseline = 0.0f;
  public static bool useSymbols = false;
  private static Color mInvisible = new Color(0.0f, 0.0f, 0.0f, 0.0f);
  private static BetterList<Color> mColors = new BetterList<Color>();
  private static float mAlpha = 1f;
  private static CharacterInfo mTempChar;
  private static BetterList<float> mSizes = new BetterList<float>();
  [NonSerialized]
  private static StringBuilder mSB;
  private static Color s_c0;
  private static Color s_c1;
  private const float sizeShrinkage = 0.75f;
  private static float[] mBoldOffset = new float[8]
  {
    -0.25f,
    0.0f,
    0.25f,
    0.0f,
    0.0f,
    -0.25f,
    0.0f,
    0.25f
  };

  public static bool isDynamic => NGUIText.bitmapFont == null;

  public static void Update() => NGUIText.Update(true);

  public static void Update(bool request)
  {
    NGUIText.finalSize = Mathf.RoundToInt((float) NGUIText.fontSize / NGUIText.pixelDensity);
    NGUIText.finalSpacingX = NGUIText.spacingX * NGUIText.fontScale;
    NGUIText.finalLineHeight = ((float) NGUIText.fontSize + NGUIText.spacingY) * NGUIText.fontScale;
    NGUIText.useSymbols = ((UnityEngine.Object) NGUIText.dynamicFont != (UnityEngine.Object) null || NGUIText.bitmapFont != null) && NGUIText.encoding && NGUIText.symbolStyle != 0;
    Font dynamicFont = NGUIText.dynamicFont;
    if (!((UnityEngine.Object) dynamicFont != (UnityEngine.Object) null & request))
      return;
    dynamicFont.RequestCharactersInTexture(")_-", NGUIText.finalSize, NGUIText.fontStyle);
    if (!dynamicFont.GetCharacterInfo(')', out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle) || (double) NGUIText.mTempChar.maxY == 0.0)
    {
      dynamicFont.RequestCharactersInTexture("A", NGUIText.finalSize, NGUIText.fontStyle);
      if (!dynamicFont.GetCharacterInfo('A', out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
      {
        NGUIText.baseline = 0.0f;
        return;
      }
    }
    float maxY = (float) NGUIText.mTempChar.maxY;
    float minY = (float) NGUIText.mTempChar.minY;
    NGUIText.baseline = Mathf.Round(maxY + (float) (((double) NGUIText.finalSize - (double) maxY + (double) minY) * 0.5));
  }

  public static void Prepare(string text)
  {
    NGUIText.mColors.Clear();
    if (!((UnityEngine.Object) NGUIText.dynamicFont != (UnityEngine.Object) null))
      return;
    NGUIText.dynamicFont.RequestCharactersInTexture(text, NGUIText.finalSize, NGUIText.fontStyle);
  }

  public static BMSymbol GetSymbol(string text, int index, int textLength) => NGUIText.bitmapFont != null ? NGUIText.bitmapFont.MatchSymbol(text, index, textLength) : (BMSymbol) null;

  public static float GetGlyphWidth(int ch, int prev, float fontScale)
  {
    if (NGUIText.bitmapFont != null)
    {
      bool flag = false;
      if (ch == 8201)
      {
        flag = true;
        ch = 32;
      }
      BMGlyph bmGlyph = (BMGlyph) null;
      if (NGUIText.bitmapFont != null)
        bmGlyph = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
      if (bmGlyph != null)
      {
        int advance = bmGlyph.advance;
        if (flag)
          advance >>= 1;
        return fontScale * (prev != 0 ? (float) (advance + bmGlyph.GetKerning(prev)) : (float) bmGlyph.advance);
      }
    }
    else if ((UnityEngine.Object) NGUIText.dynamicFont != (UnityEngine.Object) null && NGUIText.dynamicFont.GetCharacterInfo((char) ch, out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
      return (float) NGUIText.mTempChar.advance * fontScale * NGUIText.pixelDensity;
    return 0.0f;
  }

  public static NGUIText.GlyphInfo GetGlyph(int ch, int prev, float fontScale = 1f)
  {
    if (NGUIText.bitmapFont != null)
    {
      bool flag = false;
      if (ch == 8201)
      {
        flag = true;
        ch = 32;
      }
      BMGlyph bmGlyph = (BMGlyph) null;
      if (NGUIText.bitmapFont != null)
        bmGlyph = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
      if (bmGlyph != null)
      {
        int num = prev != 0 ? bmGlyph.GetKerning(prev) : 0;
        NGUIText.glyph.v0.x = prev != 0 ? (float) (bmGlyph.offsetX + num) : (float) bmGlyph.offsetX;
        NGUIText.glyph.v1.y = (float) -bmGlyph.offsetY;
        NGUIText.glyph.v1.x = NGUIText.glyph.v0.x + (float) bmGlyph.width;
        NGUIText.glyph.v0.y = NGUIText.glyph.v1.y - (float) bmGlyph.height;
        NGUIText.glyph.u0.x = (float) bmGlyph.x;
        NGUIText.glyph.u0.y = (float) (bmGlyph.y + bmGlyph.height);
        NGUIText.glyph.u2.x = (float) (bmGlyph.x + bmGlyph.width);
        NGUIText.glyph.u2.y = (float) bmGlyph.y;
        NGUIText.glyph.u1.x = NGUIText.glyph.u0.x;
        NGUIText.glyph.u1.y = NGUIText.glyph.u2.y;
        NGUIText.glyph.u3.x = NGUIText.glyph.u2.x;
        NGUIText.glyph.u3.y = NGUIText.glyph.u0.y;
        int advance = bmGlyph.advance;
        if (flag)
          advance >>= 1;
        NGUIText.glyph.advance = (float) (advance + num);
        NGUIText.glyph.channel = bmGlyph.channel;
        if ((double) fontScale != 1.0)
        {
          NGUIText.glyph.v0 *= fontScale;
          NGUIText.glyph.v1 *= fontScale;
          NGUIText.glyph.advance *= fontScale;
        }
        return NGUIText.glyph;
      }
    }
    else if ((UnityEngine.Object) NGUIText.dynamicFont != (UnityEngine.Object) null && NGUIText.dynamicFont.GetCharacterInfo((char) ch, out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
    {
      NGUIText.glyph.v0.x = (float) NGUIText.mTempChar.minX;
      NGUIText.glyph.v1.x = (float) NGUIText.mTempChar.maxX;
      NGUIText.glyph.v0.y = (float) NGUIText.mTempChar.maxY - NGUIText.baseline;
      NGUIText.glyph.v1.y = (float) NGUIText.mTempChar.minY - NGUIText.baseline;
      NGUIText.glyph.u0 = NGUIText.mTempChar.uvTopLeft;
      NGUIText.glyph.u1 = NGUIText.mTempChar.uvBottomLeft;
      NGUIText.glyph.u2 = NGUIText.mTempChar.uvBottomRight;
      NGUIText.glyph.u3 = NGUIText.mTempChar.uvTopRight;
      NGUIText.glyph.advance = (float) NGUIText.mTempChar.advance;
      NGUIText.glyph.channel = 0;
      NGUIText.glyph.v0.x = Mathf.Round(NGUIText.glyph.v0.x);
      NGUIText.glyph.v0.y = Mathf.Round(NGUIText.glyph.v0.y);
      NGUIText.glyph.v1.x = Mathf.Round(NGUIText.glyph.v1.x);
      NGUIText.glyph.v1.y = Mathf.Round(NGUIText.glyph.v1.y);
      float num = fontScale * NGUIText.pixelDensity;
      if ((double) num != 1.0)
      {
        NGUIText.glyph.v0 *= num;
        NGUIText.glyph.v1 *= num;
        NGUIText.glyph.advance *= num;
      }
      return NGUIText.glyph;
    }
    return (NGUIText.GlyphInfo) null;
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static float ParseAlpha(string text, int index) => Mathf.Clamp01((float) (NGUIMath.HexToDecimal(text[index + 1]) << 4 | NGUIMath.HexToDecimal(text[index + 2])) / (float) byte.MaxValue);

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static Color ParseColor(string text, int offset = 0) => NGUIText.ParseColor24(text, offset);

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static Color ParseColor24(string text, int offset = 0)
  {
    int num1 = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
    int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
    int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
    float num4 = 0.003921569f;
    return new Color(num4 * (float) num1, num4 * (float) num2, num4 * (float) num3);
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static Color ParseColor32(string text, int offset)
  {
    int num1 = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
    int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
    int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
    int num4 = NGUIMath.HexToDecimal(text[offset + 6]) << 4 | NGUIMath.HexToDecimal(text[offset + 7]);
    float num5 = 0.003921569f;
    return new Color(num5 * (float) num1, num5 * (float) num2, num5 * (float) num3, num5 * (float) num4);
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static string EncodeColor(Color c) => NGUIText.EncodeColor24(c);

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static string EncodeColor(string text, Color c) => "[c][" + NGUIText.EncodeColor24(c) + "]" + text + "[-][/c]";

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static string EncodeAlpha(float a) => NGUIMath.DecimalToHex8(Mathf.Clamp(Mathf.RoundToInt(a * (float) byte.MaxValue), 0, (int) byte.MaxValue));

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static string EncodeColor24(Color c) => NGUIMath.DecimalToHex24(16777215 & NGUIMath.ColorToInt(c) >> 8);

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static string EncodeColor32(Color c) => NGUIMath.DecimalToHex32(NGUIMath.ColorToInt(c));

  public static bool ParseSymbol(string text, ref int index)
  {
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    return NGUIText.ParseSymbol(text, ref index, (BetterList<Color>) null, false, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor);
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static bool IsHex(char ch)
  {
    if (ch >= '0' && ch <= '9' || ch >= 'a' && ch <= 'f')
      return true;
    return ch >= 'A' && ch <= 'F';
  }

  public static bool ParseSymbol(
    string text,
    ref int index,
    BetterList<Color> colors,
    bool premultiply,
    ref int sub,
    ref bool bold,
    ref bool italic,
    ref bool underline,
    ref bool strike,
    ref bool ignoreColor)
  {
    int length = text.Length;
    if (index + 3 > length || text[index] != '[')
      return false;
    if (text[index + 2] == ']')
    {
      if (text[index + 1] == '-')
      {
        if (colors != null && colors.size > 1)
          colors.RemoveAt(colors.size - 1);
        index += 3;
        return true;
      }
      switch (text.Substring(index, 3))
      {
        case "[B]":
        case "[b]":
          bold = true;
          index += 3;
          return true;
        case "[C]":
        case "[c]":
          ignoreColor = true;
          index += 3;
          return true;
        case "[I]":
        case "[i]":
          italic = true;
          index += 3;
          return true;
        case "[S]":
        case "[s]":
          strike = true;
          index += 3;
          return true;
        case "[U]":
        case "[u]":
          underline = true;
          index += 3;
          return true;
      }
    }
    if (index + 4 > length)
      return false;
    if (text[index + 3] == ']')
    {
      switch (text.Substring(index, 4))
      {
        case "[/B]":
        case "[/b]":
          bold = false;
          index += 4;
          return true;
        case "[/C]":
        case "[/c]":
          ignoreColor = false;
          index += 4;
          return true;
        case "[/I]":
        case "[/i]":
          italic = false;
          index += 4;
          return true;
        case "[/S]":
        case "[/s]":
          strike = false;
          index += 4;
          return true;
        case "[/U]":
        case "[/u]":
          underline = false;
          index += 4;
          return true;
        default:
          char ch1 = text[index + 1];
          char ch2 = text[index + 2];
          if (NGUIText.IsHex(ch1) && NGUIText.IsHex(ch2))
          {
            NGUIText.mAlpha = (float) (NGUIMath.HexToDecimal(ch1) << 4 | NGUIMath.HexToDecimal(ch2)) / (float) byte.MaxValue;
            index += 4;
            return true;
          }
          break;
      }
    }
    if (index + 5 > length)
      return false;
    if (text[index + 4] == ']')
    {
      switch (text.Substring(index, 5))
      {
        case "[sub]":
        case "[SUB]":
          sub = 1;
          index += 5;
          return true;
        case "[sup]":
        case "[SUP]":
          sub = 2;
          index += 5;
          return true;
      }
    }
    if (index + 6 > length)
      return false;
    if (text[index + 5] == ']')
    {
      switch (text.Substring(index, 6))
      {
        case "[/sub]":
        case "[/SUB]":
          sub = 0;
          index += 6;
          return true;
        case "[/sup]":
        case "[/SUP]":
          sub = 0;
          index += 6;
          return true;
        case "[/url]":
        case "[/URL]":
          index += 6;
          return true;
      }
    }
    if (text[index + 1] == 'u' && text[index + 2] == 'r' && text[index + 3] == 'l' && text[index + 4] == '=')
    {
      int num = text.IndexOf(']', index + 4);
      if (num != -1)
      {
        index = num + 1;
        return true;
      }
      index = text.Length;
      return true;
    }
    if (index + 8 > length)
      return false;
    if (text[index + 7] == ']')
    {
      Color color = NGUIText.ParseColor24(text, index + 1);
      if (NGUIText.EncodeColor24(color) != text.Substring(index + 1, 6).ToUpper())
        return false;
      if (colors != null && colors.size > 0)
      {
        color.a = colors.buffer[colors.size - 1].a;
        if (premultiply && (double) color.a != 1.0)
          color = Color.Lerp(NGUIText.mInvisible, color, color.a);
        colors.Add(color);
      }
      index += 8;
      return true;
    }
    if (index + 10 > length || text[index + 9] != ']')
      return false;
    Color color1 = NGUIText.ParseColor32(text, index + 1);
    if (NGUIText.EncodeColor32(color1) != text.Substring(index + 1, 8).ToUpper())
      return false;
    if (colors != null)
    {
      if (premultiply && (double) color1.a != 1.0)
        color1 = Color.Lerp(NGUIText.mInvisible, color1, color1.a);
      colors.Add(color1);
    }
    index += 10;
    return true;
  }

  public static string StripSymbols(string text)
  {
    if (text != null)
    {
      int num = 0;
      int length = text.Length;
      while (num < length)
      {
        if (text[num] == '[')
        {
          int sub = 0;
          bool bold = false;
          bool italic = false;
          bool underline = false;
          bool strike = false;
          bool ignoreColor = false;
          int index = num;
          if (NGUIText.ParseSymbol(text, ref index, (BetterList<Color>) null, false, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
          {
            text = text.Remove(num, index - num);
            length = text.Length;
            continue;
          }
        }
        ++num;
      }
    }
    return text;
  }

  public static void Align(List<Vector3> verts, int indexOffset, float printedWidth, int elements = 4)
  {
    switch (NGUIText.alignment)
    {
      case NGUIText.Alignment.Center:
        float num1 = (float) (((double) NGUIText.rectWidth - (double) printedWidth) * 0.5);
        if ((double) num1 < 0.0)
          break;
        int num2 = Mathf.RoundToInt((float) NGUIText.rectWidth - printedWidth);
        int num3 = Mathf.RoundToInt((float) NGUIText.rectWidth);
        bool flag1 = (num2 & 1) == 1;
        bool flag2 = (num3 & 1) == 1;
        if (flag1 && !flag2 || !flag1 & flag2)
          num1 += 0.5f * NGUIText.fontScale;
        int index1 = indexOffset;
        for (int count = verts.Count; index1 < count; ++index1)
        {
          Vector3 vert = verts[index1];
          vert.x += num1;
          verts[index1] = vert;
        }
        break;
      case NGUIText.Alignment.Right:
        float num4 = (float) NGUIText.rectWidth - printedWidth;
        if ((double) num4 < 0.0)
          break;
        int index2 = indexOffset;
        for (int count = verts.Count; index2 < count; ++index2)
        {
          Vector3 vert = verts[index2];
          vert.x += num4;
          verts[index2] = vert;
        }
        break;
      case NGUIText.Alignment.Justified:
        if ((double) printedWidth < (double) NGUIText.rectWidth * 0.64999997615814209 || ((double) NGUIText.rectWidth - (double) printedWidth) * 0.5 < 1.0)
          break;
        int num5 = (verts.Count - indexOffset) / elements;
        if (num5 < 1)
          break;
        float num6 = 1f / (float) (num5 - 1);
        float num7 = (float) NGUIText.rectWidth / printedWidth;
        int index3 = indexOffset + elements;
        int num8 = 1;
        int count1 = verts.Count;
        while (index3 < count1)
        {
          float x1 = verts[index3].x;
          float x2 = verts[index3 + elements / 2].x;
          float num9 = x2 - x1;
          double a1 = (double) x1 * (double) num7;
          double a2 = a1 + (double) num9;
          float num10 = x2 * num7;
          float b1 = num10 - num9;
          float t1 = (float) num8 * num6;
          double b2 = (double) num10;
          double t2 = (double) t1;
          float f = Mathf.Lerp((float) a2, (float) b2, (float) t2);
          float num11 = Mathf.Round(Mathf.Lerp((float) a1, b1, t1));
          float num12 = Mathf.Round(f);
          switch (elements)
          {
            case 1:
              Vector3 vert1 = verts[index3] with
              {
                x = num11
              };
              verts[index3++] = vert1;
              break;
            case 2:
              Vector3 vert2 = verts[index3] with
              {
                x = num11
              };
              List<Vector3> vector3List1 = verts;
              int index4 = index3;
              int index5 = index4 + 1;
              Vector3 vector3_1 = vert2;
              vector3List1[index4] = vector3_1;
              Vector3 vert3 = verts[index5] with
              {
                x = num12
              };
              List<Vector3> vector3List2 = verts;
              int index6 = index5;
              index3 = index6 + 1;
              Vector3 vector3_2 = vert3;
              vector3List2[index6] = vector3_2;
              break;
            case 4:
              Vector3 vert4 = verts[index3] with
              {
                x = num11
              };
              List<Vector3> vector3List3 = verts;
              int index7 = index3;
              int index8 = index7 + 1;
              Vector3 vector3_3 = vert4;
              vector3List3[index7] = vector3_3;
              Vector3 vert5 = verts[index8] with
              {
                x = num11
              };
              List<Vector3> vector3List4 = verts;
              int index9 = index8;
              int index10 = index9 + 1;
              Vector3 vector3_4 = vert5;
              vector3List4[index9] = vector3_4;
              Vector3 vert6 = verts[index10] with
              {
                x = num12
              };
              List<Vector3> vector3List5 = verts;
              int index11 = index10;
              int index12 = index11 + 1;
              Vector3 vector3_5 = vert6;
              vector3List5[index11] = vector3_5;
              Vector3 vert7 = verts[index12] with
              {
                x = num12
              };
              List<Vector3> vector3List6 = verts;
              int index13 = index12;
              index3 = index13 + 1;
              Vector3 vector3_6 = vert7;
              vector3List6[index13] = vector3_6;
              break;
          }
          ++num8;
        }
        break;
    }
  }

  public static int GetExactCharacterIndex(List<Vector3> verts, List<int> indices, Vector2 pos)
  {
    int index1 = 0;
    for (int count = indices.Count; index1 < count; ++index1)
    {
      int index2 = index1 << 1;
      int index3 = index2 + 1;
      float x1 = verts[index2].x;
      if ((double) pos.x >= (double) x1)
      {
        float x2 = verts[index3].x;
        if ((double) pos.x <= (double) x2)
        {
          float y1 = verts[index2].y;
          if ((double) pos.y >= (double) y1)
          {
            float y2 = verts[index3].y;
            if ((double) pos.y <= (double) y2)
              return indices[index1];
          }
        }
      }
    }
    return 0;
  }

  public static int GetApproximateCharacterIndex(
    List<Vector3> verts,
    List<int> indices,
    Vector2 pos)
  {
    float num1 = float.MaxValue;
    float num2 = float.MaxValue;
    int index1 = 0;
    int index2 = 0;
    for (int count = verts.Count; index2 < count; ++index2)
    {
      float num3 = Mathf.Abs(pos.y - verts[index2].y);
      if ((double) num3 <= (double) num2)
      {
        float num4 = Mathf.Abs(pos.x - verts[index2].x);
        if ((double) num3 < (double) num2)
        {
          num2 = num3;
          num1 = num4;
          index1 = index2;
        }
        else if ((double) num4 < (double) num1)
        {
          num1 = num4;
          index1 = index2;
        }
      }
    }
    return indices[index1];
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static bool IsSpace(int ch) => ch == 32 || ch == 8202 || ch == 8203 || ch == 8201;

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static void EndLine(ref StringBuilder s)
  {
    int index = s.Length - 1;
    if (index > 0 && NGUIText.IsSpace((int) s[index]))
      s[index] = '\n';
    else
      s.Append('\n');
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  private static void ReplaceSpaceWithNewline(ref StringBuilder s)
  {
    int index = s.Length - 1;
    if (index <= 0 || !NGUIText.IsSpace((int) s[index]))
      return;
    s[index] = '\n';
  }

  public static Vector2 CalculatePrintedSize(string text)
  {
    Vector2 zero = Vector2.zero;
    if (!string.IsNullOrEmpty(text))
    {
      NGUIText.Prepare(text);
      int prev = 0;
      float f = 0.0f;
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = (float) NGUIText.regionWidth + 0.01f;
      int length = text.Length;
      int sub = 0;
      bool bold = false;
      bool italic = false;
      bool underline = false;
      bool strike = false;
      bool ignoreColor = false;
      for (int index = 0; index < length; ++index)
      {
        int ch = (int) text[index];
        if (ch == 10)
        {
          if ((double) f > (double) num2)
            num2 = f;
          f = 0.0f;
          num1 += NGUIText.finalLineHeight;
          prev = 0;
        }
        else if (ch < 32)
          prev = ch;
        else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
        {
          --index;
        }
        else
        {
          BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index, length) : (BMSymbol) null;
          float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
          if (bmSymbol != null)
          {
            float num4 = (float) bmSymbol.advance * fontScale;
            float num5 = f + num4;
            if ((double) num5 > (double) num3)
            {
              if ((double) f != 0.0)
              {
                if ((double) f > (double) num2)
                  num2 = f;
                f = 0.0f;
                num1 += NGUIText.finalLineHeight;
              }
              else
                break;
            }
            else if ((double) num5 > (double) num2)
              num2 = num5;
            f += num4 + NGUIText.finalSpacingX;
            index += bmSymbol.length - 1;
            prev = 0;
          }
          else
          {
            NGUIText.GlyphInfo glyph = NGUIText.GetGlyph(ch, prev, fontScale);
            if (glyph != null)
            {
              prev = ch;
              float advance = glyph.advance;
              switch (sub)
              {
                case 0:
                  float num6 = advance + NGUIText.finalSpacingX;
                  float num7 = f + num6;
                  if ((double) num7 > (double) num3)
                  {
                    if ((double) f != 0.0)
                      num1 += NGUIText.finalLineHeight;
                    else
                      continue;
                  }
                  else if ((double) num7 > (double) num2)
                    num2 = num7;
                  if (NGUIText.IsSpace(ch))
                  {
                    if (underline)
                      ch = 95;
                    else if (strike)
                      ch = 45;
                  }
                  f = num7;
                  if (sub != 0)
                    f = Mathf.Round(f);
                  NGUIText.IsSpace(ch);
                  continue;
                case 1:
                  float num8 = (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.40000000596046448);
                  glyph.v0.y -= num8;
                  glyph.v1.y -= num8;
                  goto case 0;
                default:
                  float num9 = (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.05000000074505806);
                  glyph.v0.y += num9;
                  glyph.v1.y += num9;
                  goto case 0;
              }
            }
          }
        }
      }
      zero.x = Mathf.Ceil((double) f > (double) num2 ? f - NGUIText.finalSpacingX : num2);
      zero.y = Mathf.Ceil(num1 + NGUIText.finalLineHeight);
    }
    return zero;
  }

  public static int CalculateOffsetToFit(string text)
  {
    if (string.IsNullOrEmpty(text) || NGUIText.regionWidth < 1)
      return 0;
    NGUIText.Prepare(text);
    int length1 = text.Length;
    int prev = 0;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    int index1 = 0;
    for (int length2 = text.Length; index1 < length2; ++index1)
    {
      float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
      BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index1, length1) : (BMSymbol) null;
      if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index1, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
        --index1;
      else if (bmSymbol == null)
      {
        int ch = (int) text[index1];
        float glyphWidth = NGUIText.GetGlyphWidth(ch, prev, fontScale);
        if ((double) glyphWidth != 0.0)
          NGUIText.mSizes.Add(NGUIText.finalSpacingX + glyphWidth);
        prev = ch;
      }
      else
      {
        NGUIText.mSizes.Add(NGUIText.finalSpacingX + (float) bmSymbol.advance * fontScale);
        int num = 0;
        for (int index2 = bmSymbol.sequence.Length - 1; num < index2; ++num)
          NGUIText.mSizes.Add(0.0f);
        index1 += bmSymbol.sequence.Length - 1;
        prev = 0;
      }
    }
    float regionWidth = (float) NGUIText.regionWidth;
    int size = NGUIText.mSizes.size;
    while (size > 0 && (double) regionWidth > 0.0)
      regionWidth -= NGUIText.mSizes.buffer[--size];
    NGUIText.mSizes.Clear();
    if ((double) regionWidth < 0.0)
      ++size;
    return size;
  }

  public static string GetEndOfLineThatFits(string text)
  {
    int length = text.Length;
    int offsetToFit = NGUIText.CalculateOffsetToFit(text);
    return text.Substring(offsetToFit, length - offsetToFit);
  }

  public static bool WrapText(string text, out string finalText, bool wrapLineColors = false) => NGUIText.WrapText(text, out finalText, false, wrapLineColors);

  public static bool WrapText(
    string text,
    out string finalText,
    bool keepCharCount,
    bool wrapLineColors,
    bool useEllipsis = false)
  {
    if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 1 || (double) NGUIText.finalLineHeight < 1.0)
    {
      finalText = "";
      return false;
    }
    float num1 = NGUIText.maxLines > 0 ? Mathf.Min((float) NGUIText.regionHeight, NGUIText.finalLineHeight * (float) NGUIText.maxLines) : (float) NGUIText.regionHeight;
    int num2 = Mathf.FloorToInt(Mathf.Min(NGUIText.maxLines > 0 ? (float) NGUIText.maxLines : 1000000f, num1 / NGUIText.finalLineHeight) + 0.01f);
    if (num2 == 0)
    {
      finalText = "";
      return false;
    }
    if (string.IsNullOrEmpty(text))
      text = " ";
    int length = text.Length;
    NGUIText.Prepare(text);
    if (NGUIText.mSB == null)
      NGUIText.mSB = new StringBuilder();
    else
      NGUIText.mSB.Length = 0;
    float regionWidth = (float) NGUIText.regionWidth;
    float num3 = 0.0f;
    int num4 = 0;
    int index1 = 0;
    int num5 = 1;
    int prev = 0;
    bool flag1 = true;
    bool flag2 = true;
    bool flag3 = false;
    Color tint = NGUIText.tint;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    float num6 = useEllipsis ? (float) (((double) NGUIText.finalSpacingX + (double) NGUIText.GetGlyphWidth(46, 46, NGUIText.fontScale)) * 3.0) : NGUIText.finalSpacingX;
    int num7 = 0;
    NGUIText.mColors.Add(tint);
    if (!NGUIText.useSymbols)
      wrapLineColors = false;
    if (wrapLineColors)
    {
      NGUIText.mSB.Append("[");
      NGUIText.mSB.Append(NGUIText.EncodeColor(tint));
      NGUIText.mSB.Append("]");
    }
    for (; index1 < length; ++index1)
    {
      char ch1 = text[index1];
      bool flag4 = NGUIText.IsSpace((int) ch1);
      if (ch1 > '\u2FFF')
        flag3 = true;
      if (ch1 == '\n')
      {
        if (num5 != num2)
        {
          num3 = 0.0f;
          if (num4 < index1)
            NGUIText.mSB.Append(text.Substring(num4, index1 - num4 + 1));
          else
            NGUIText.mSB.Append(ch1);
          if (wrapLineColors)
          {
            for (int index2 = 0; index2 < NGUIText.mColors.size; ++index2)
              NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
            for (int index3 = 0; index3 < NGUIText.mColors.size; ++index3)
            {
              NGUIText.mSB.Append("[");
              NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[index3]));
              NGUIText.mSB.Append("]");
            }
          }
          flag1 = true;
          ++num5;
          num4 = index1 + 1;
          prev = 0;
        }
        else
          break;
      }
      else
      {
        bool flag5 = flag1 || num5 == num2;
        int num8 = sub;
        if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index1, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
        {
          if (num5 == num2 & useEllipsis && num4 < num7)
          {
            if (num7 > num4)
              NGUIText.mSB.Append(text.Substring(num4, num7 - num4 + 1));
            if (num8 != 0)
              NGUIText.mSB.Append("[/sub]");
            NGUIText.mSB.Append("...");
            num4 = index1;
            break;
          }
          if (num7 + 1 > index1)
          {
            NGUIText.mSB.Append(text.Substring(num4, index1 - num4));
            num4 = index1;
          }
          if (wrapLineColors)
          {
            Color color;
            if (ignoreColor)
            {
              color = NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
              color.a *= NGUIText.mAlpha * NGUIText.tint.a;
            }
            else
            {
              color = NGUIText.tint * NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
              color.a *= NGUIText.mAlpha;
            }
            int index4 = 0;
            for (int index5 = NGUIText.mColors.size - 2; index4 < index5; ++index4)
              color.a *= NGUIText.mColors.buffer[index4].a;
          }
          if (num4 < index1)
            NGUIText.mSB.Append(text.Substring(num4, index1 - num4));
          else
            NGUIText.mSB.Append(ch1);
          num4 = index1--;
          num7 = num4;
        }
        else
        {
          BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index1, length) : (BMSymbol) null;
          float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
          float f;
          if (bmSymbol == null)
          {
            float glyphWidth = NGUIText.GetGlyphWidth((int) ch1, prev, fontScale);
            if ((double) glyphWidth != 0.0 || flag4)
              f = NGUIText.finalSpacingX + glyphWidth;
            else
              continue;
          }
          else
            f = NGUIText.finalSpacingX + (float) bmSymbol.advance * fontScale;
          if (sub != 0)
            f = Mathf.Round(f);
          num3 += f;
          prev = (int) ch1;
          float num9 = useEllipsis & flag5 ? regionWidth - num6 : regionWidth;
          if (flag4 && !flag3 && num4 < index1)
          {
            int num10 = index1 - num4;
            if (num5 == num2 && (double) num3 >= (double) num9 && index1 < length)
            {
              char ch2 = text[index1];
              if (ch2 < ' ' || NGUIText.IsSpace((int) ch2))
                --num10;
            }
            if (flag5 & useEllipsis && num4 < num7 && (double) num3 < (double) regionWidth && (double) num3 > (double) num9)
            {
              if (num7 > num4)
                NGUIText.mSB.Append(text.Substring(num4, num7 - num4 + 1));
              if (sub != 0)
                NGUIText.mSB.Append("[/sub]");
              NGUIText.mSB.Append("...");
              num4 = index1;
              break;
            }
            NGUIText.mSB.Append(text.Substring(num4, num10 + 1));
            flag1 = false;
            num4 = index1 + 1;
          }
          if (useEllipsis && !flag4 && (double) num3 < (double) num9)
            num7 = index1;
          if ((double) num3 > (double) num9)
          {
            if (flag5)
            {
              if (useEllipsis && index1 > 0)
              {
                if (num7 > num4)
                  NGUIText.mSB.Append(text.Substring(num4, num7 - num4 + 1));
                if (sub != 0)
                  NGUIText.mSB.Append("[/sub]");
                NGUIText.mSB.Append("...");
                num4 = index1;
                break;
              }
              NGUIText.mSB.Append(text.Substring(num4, Mathf.Max(0, index1 - num4)));
              if (!flag4 && !flag3)
                flag2 = false;
              if (wrapLineColors && NGUIText.mColors.size > 0)
                NGUIText.mSB.Append("[-]");
              if (num5++ == num2)
              {
                num4 = index1;
                break;
              }
              if (keepCharCount)
                NGUIText.ReplaceSpaceWithNewline(ref NGUIText.mSB);
              else
                NGUIText.EndLine(ref NGUIText.mSB);
              if (wrapLineColors)
              {
                for (int index6 = 0; index6 < NGUIText.mColors.size; ++index6)
                  NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
                for (int index7 = 0; index7 < NGUIText.mColors.size; ++index7)
                {
                  NGUIText.mSB.Append("[");
                  NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[index7]));
                  NGUIText.mSB.Append("]");
                }
              }
              flag1 = true;
              if (flag4)
              {
                num4 = index1 + 1;
                num3 = 0.0f;
              }
              else
              {
                num4 = index1;
                num3 = f;
              }
              num7 = index1;
              prev = 0;
            }
            else
            {
              while (num4 < length && NGUIText.IsSpace((int) text[num4]))
                ++num4;
              flag1 = true;
              num3 = 0.0f;
              index1 = num4 - 1;
              prev = 0;
              if (num5++ != num2)
              {
                if (keepCharCount)
                  NGUIText.ReplaceSpaceWithNewline(ref NGUIText.mSB);
                else
                  NGUIText.EndLine(ref NGUIText.mSB);
                if (wrapLineColors)
                {
                  for (int index8 = 0; index8 < NGUIText.mColors.size; ++index8)
                    NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
                  for (int index9 = 0; index9 < NGUIText.mColors.size; ++index9)
                  {
                    NGUIText.mSB.Append("[");
                    NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[index9]));
                    NGUIText.mSB.Append("]");
                  }
                  continue;
                }
                continue;
              }
              break;
            }
          }
          if (bmSymbol != null)
          {
            index1 += bmSymbol.length - 1;
            prev = 0;
          }
        }
      }
    }
    if (num4 < index1)
      NGUIText.mSB.Append(text.Substring(num4, index1 - num4));
    if (wrapLineColors && NGUIText.mColors.size > 0)
      NGUIText.mSB.Append("[-]");
    finalText = NGUIText.mSB.ToString();
    NGUIText.mColors.Clear();
    if (!flag2)
      return false;
    if (index1 == length)
      return true;
    return NGUIText.maxLines == 0 ? num5 == 0 : num5 == num2;
  }

  public static void Print(string text, List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    if (string.IsNullOrEmpty(text))
      return;
    int count1 = verts.Count;
    NGUIText.Prepare(text);
    NGUIText.mColors.Add(Color.white);
    NGUIText.mAlpha = 1f;
    int prev = 0;
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    double finalSize = (double) NGUIText.finalSize;
    Color a = NGUIText.tint * NGUIText.gradientBottom;
    Color b = NGUIText.tint * NGUIText.gradientTop;
    Color color1 = NGUIText.tint;
    int length = text.Length;
    Rect rect = new Rect();
    float num4 = 0.0f;
    float num5 = 0.0f;
    double pixelDensity = (double) NGUIText.pixelDensity;
    float num6 = (float) (finalSize * pixelDensity);
    float num7 = 0.0f;
    float num8 = (float) NGUIText.regionWidth + 0.01f;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    if (NGUIText.bitmapFont != null)
    {
      rect = NGUIText.bitmapFont.uvRect;
      num4 = rect.width / (float) NGUIText.bitmapFont.texWidth;
      num5 = rect.height / (float) NGUIText.bitmapFont.texHeight;
    }
    for (int index1 = 0; index1 < length; ++index1)
    {
      int ch = (int) text[index1];
      float x1 = num1;
      if (ch == 10)
      {
        if ((double) num1 > (double) num3)
          num3 = num1;
        if (NGUIText.alignment != NGUIText.Alignment.Left)
        {
          NGUIText.Align(verts, count1, num1 - NGUIText.finalSpacingX);
          count1 = verts.Count;
        }
        num1 = 0.0f;
        num2 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = ch;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index1, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
      {
        if (ignoreColor)
        {
          color1 = NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
          color1.a *= NGUIText.mAlpha * NGUIText.tint.a;
        }
        else
        {
          color1 = NGUIText.tint * NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
          color1.a *= NGUIText.mAlpha;
        }
        int index2 = 0;
        for (int index3 = NGUIText.mColors.size - 2; index2 < index3; ++index2)
          color1.a *= NGUIText.mColors.buffer[index2].a;
        if (NGUIText.gradient)
        {
          a = NGUIText.gradientBottom * color1;
          b = NGUIText.gradientTop * color1;
        }
        --index1;
      }
      else
      {
        BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index1, length) : (BMSymbol) null;
        float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
        if (bmSymbol != null)
        {
          float x2 = num1 + (float) bmSymbol.offsetX * NGUIText.fontScale;
          float x3 = x2 + (float) bmSymbol.width * NGUIText.fontScale;
          float y1 = (float) -((double) num2 + (double) bmSymbol.offsetY * (double) NGUIText.fontScale);
          float y2 = y1 - (float) bmSymbol.height * NGUIText.fontScale;
          float num9 = (float) bmSymbol.advance * fontScale;
          if ((double) num1 + (double) num9 > (double) num8)
          {
            if ((double) num1 == 0.0)
              return;
            if (NGUIText.alignment != NGUIText.Alignment.Left && count1 < verts.Count)
            {
              NGUIText.Align(verts, count1, num1 - NGUIText.finalSpacingX);
              count1 = verts.Count;
            }
            x2 -= num1;
            x3 -= num1;
            y2 -= NGUIText.finalLineHeight;
            y1 -= NGUIText.finalLineHeight;
            num1 = 0.0f;
            num2 += NGUIText.finalLineHeight;
            num7 = 0.0f;
          }
          verts.Add(new Vector3(x2, y2));
          verts.Add(new Vector3(x2, y1));
          verts.Add(new Vector3(x3, y1));
          verts.Add(new Vector3(x3, y2));
          num1 += num9 + NGUIText.finalSpacingX;
          index1 += bmSymbol.length - 1;
          prev = 0;
          if (uvs != null)
          {
            Rect uvRect = bmSymbol.uvRect;
            float xMin = uvRect.xMin;
            float yMin = uvRect.yMin;
            float xMax = uvRect.xMax;
            float yMax = uvRect.yMax;
            uvs.Add(new Vector2(xMin, yMin));
            uvs.Add(new Vector2(xMin, yMax));
            uvs.Add(new Vector2(xMax, yMax));
            uvs.Add(new Vector2(xMax, yMin));
          }
          if (cols != null)
          {
            if (NGUIText.symbolStyle == NGUIText.SymbolStyle.Colored)
            {
              for (int index4 = 0; index4 < 4; ++index4)
                cols.Add(color1);
            }
            else
            {
              Color white = Color.white;
              if (NGUIText.symbolStyle == NGUIText.SymbolStyle.NoOutline)
              {
                white.r = -1f;
                white.a = 0.0f;
              }
              else
                white.a = color1.a;
              for (int index5 = 0; index5 < 4; ++index5)
                cols.Add(white);
            }
          }
        }
        else
        {
          NGUIText.GlyphInfo glyph1 = NGUIText.GetGlyph(ch, prev, fontScale);
          if (glyph1 != null)
          {
            prev = ch;
            float advance = glyph1.advance;
            switch (sub)
            {
              case 0:
                float num10 = advance + NGUIText.finalSpacingX;
                float x4 = glyph1.v0.x + num1;
                float y3 = glyph1.v0.y - num2;
                float x5 = glyph1.v1.x + num1;
                float y4 = glyph1.v1.y - num2;
                if ((double) num1 + (double) num10 > (double) num8)
                {
                  if ((double) num1 == 0.0)
                    return;
                  if (NGUIText.alignment != NGUIText.Alignment.Left && count1 < verts.Count)
                  {
                    NGUIText.Align(verts, count1, num1 - NGUIText.finalSpacingX);
                    count1 = verts.Count;
                  }
                  x4 -= num1;
                  x5 -= num1;
                  y3 -= NGUIText.finalLineHeight;
                  y4 -= NGUIText.finalLineHeight;
                  num1 = 0.0f;
                  num2 += NGUIText.finalLineHeight;
                  x1 = 0.0f;
                }
                if (NGUIText.IsSpace(ch))
                {
                  if (underline)
                    ch = 95;
                  else if (strike)
                    ch = 45;
                }
                num1 += num10;
                if (sub != 0)
                  num1 = Mathf.Round(num1);
                if (!NGUIText.IsSpace(ch))
                {
                  if (uvs != null)
                  {
                    if (NGUIText.bitmapFont != null)
                    {
                      glyph1.u0.x = rect.xMin + num4 * glyph1.u0.x;
                      glyph1.u2.x = rect.xMin + num4 * glyph1.u2.x;
                      glyph1.u0.y = rect.yMax - num5 * glyph1.u0.y;
                      glyph1.u2.y = rect.yMax - num5 * glyph1.u2.y;
                      glyph1.u1.x = glyph1.u0.x;
                      glyph1.u1.y = glyph1.u2.y;
                      glyph1.u3.x = glyph1.u2.x;
                      glyph1.u3.y = glyph1.u0.y;
                    }
                    int num11 = 0;
                    for (int index6 = bold ? 4 : 1; num11 < index6; ++num11)
                    {
                      uvs.Add(glyph1.u0);
                      uvs.Add(glyph1.u1);
                      uvs.Add(glyph1.u2);
                      uvs.Add(glyph1.u3);
                    }
                  }
                  if (cols != null)
                  {
                    if (glyph1.channel == 0 || glyph1.channel == 15)
                    {
                      if (NGUIText.gradient)
                      {
                        float num12 = num6 + glyph1.v0.y / NGUIText.fontScale;
                        float num13 = num6 + glyph1.v1.y / NGUIText.fontScale;
                        float t1 = num12 / num6;
                        float t2 = num13 / num6;
                        NGUIText.s_c0 = Color.Lerp(a, b, t1);
                        NGUIText.s_c1 = Color.Lerp(a, b, t2);
                        int num14 = 0;
                        for (int index7 = bold ? 4 : 1; num14 < index7; ++num14)
                        {
                          cols.Add(NGUIText.s_c0);
                          cols.Add(NGUIText.s_c1);
                          cols.Add(NGUIText.s_c1);
                          cols.Add(NGUIText.s_c0);
                        }
                      }
                      else
                      {
                        int num15 = 0;
                        for (int index8 = bold ? 16 : 4; num15 < index8; ++num15)
                          cols.Add(color1);
                      }
                    }
                    else
                    {
                      Color color2 = color1 * 0.49f;
                      switch (glyph1.channel)
                      {
                        case 1:
                          color2.b += 0.51f;
                          break;
                        case 2:
                          color2.g += 0.51f;
                          break;
                        case 4:
                          color2.r += 0.51f;
                          break;
                        case 8:
                          color2.a += 0.51f;
                          break;
                      }
                      int num16 = 0;
                      for (int index9 = bold ? 16 : 4; num16 < index9; ++num16)
                        cols.Add(color2);
                    }
                  }
                  if (!bold)
                  {
                    if (!italic)
                    {
                      verts.Add(new Vector3(x4, y3));
                      verts.Add(new Vector3(x4, y4));
                      verts.Add(new Vector3(x5, y4));
                      verts.Add(new Vector3(x5, y3));
                    }
                    else
                    {
                      float num17 = (float) ((double) NGUIText.fontSize * 0.10000000149011612 * (((double) y4 - (double) y3) / (double) NGUIText.fontSize));
                      verts.Add(new Vector3(x4 - num17, y3));
                      verts.Add(new Vector3(x4 + num17, y4));
                      verts.Add(new Vector3(x5 + num17, y4));
                      verts.Add(new Vector3(x5 - num17, y3));
                    }
                  }
                  else
                  {
                    for (int index10 = 0; index10 < 4; ++index10)
                    {
                      float num18 = NGUIText.mBoldOffset[index10 * 2];
                      float num19 = NGUIText.mBoldOffset[index10 * 2 + 1];
                      float num20 = italic ? (float) ((double) NGUIText.fontSize * 0.10000000149011612 * (((double) y4 - (double) y3) / (double) NGUIText.fontSize)) : 0.0f;
                      verts.Add(new Vector3(x4 + num18 - num20, y3 + num19));
                      verts.Add(new Vector3(x4 + num18 + num20, y4 + num19));
                      verts.Add(new Vector3(x5 + num18 + num20, y4 + num19));
                      verts.Add(new Vector3(x5 + num18 - num20, y3 + num19));
                    }
                  }
                  if (underline | strike)
                  {
                    NGUIText.GlyphInfo glyph2 = NGUIText.GetGlyph(strike ? 45 : 95, prev, fontScale);
                    if (glyph2 != null)
                    {
                      if (uvs != null)
                      {
                        if (NGUIText.bitmapFont != null)
                        {
                          glyph2.u0.x = rect.xMin + num4 * glyph2.u0.x;
                          glyph2.u2.x = rect.xMin + num4 * glyph2.u2.x;
                          glyph2.u0.y = rect.yMax - num5 * glyph2.u0.y;
                          glyph2.u2.y = rect.yMax - num5 * glyph2.u2.y;
                        }
                        float x6 = (float) (((double) glyph2.u0.x + (double) glyph2.u2.x) * 0.5);
                        int num21 = 0;
                        for (int index11 = bold ? 4 : 1; num21 < index11; ++num21)
                        {
                          uvs.Add(new Vector2(x6, glyph2.u0.y));
                          uvs.Add(new Vector2(x6, glyph2.u2.y));
                          uvs.Add(new Vector2(x6, glyph2.u2.y));
                          uvs.Add(new Vector2(x6, glyph2.u0.y));
                        }
                      }
                      float y5 = -num2 + glyph2.v0.y;
                      float y6 = -num2 + glyph2.v1.y;
                      if (bold)
                      {
                        for (int index12 = 0; index12 < 4; ++index12)
                        {
                          float num22 = NGUIText.mBoldOffset[index12 * 2];
                          float num23 = NGUIText.mBoldOffset[index12 * 2 + 1];
                          verts.Add(new Vector3(x1 + num22, y5 + num23));
                          verts.Add(new Vector3(x1 + num22, y6 + num23));
                          verts.Add(new Vector3(num1 + num22, y6 + num23));
                          verts.Add(new Vector3(num1 + num22, y5 + num23));
                        }
                      }
                      else
                      {
                        verts.Add(new Vector3(x1, y5));
                        verts.Add(new Vector3(x1, y6));
                        verts.Add(new Vector3(num1, y6));
                        verts.Add(new Vector3(num1, y5));
                      }
                      if (NGUIText.gradient)
                      {
                        float num24 = num6 + glyph2.v0.y / fontScale;
                        float num25 = num6 + glyph2.v1.y / fontScale;
                        float t3 = num24 / num6;
                        float t4 = num25 / num6;
                        NGUIText.s_c0 = Color.Lerp(a, b, t3);
                        NGUIText.s_c1 = Color.Lerp(a, b, t4);
                        int num26 = 0;
                        for (int index13 = bold ? 4 : 1; num26 < index13; ++num26)
                        {
                          cols.Add(NGUIText.s_c0);
                          cols.Add(NGUIText.s_c1);
                          cols.Add(NGUIText.s_c1);
                          cols.Add(NGUIText.s_c0);
                        }
                        continue;
                      }
                      int num27 = 0;
                      for (int index14 = bold ? 16 : 4; num27 < index14; ++num27)
                        cols.Add(color1);
                      continue;
                    }
                    continue;
                  }
                  continue;
                }
                continue;
              case 1:
                float num28 = (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.40000000596046448);
                glyph1.v0.y -= num28;
                glyph1.v1.y -= num28;
                goto case 0;
              default:
                float num29 = (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.05000000074505806);
                glyph1.v0.y += num29;
                glyph1.v1.y += num29;
                goto case 0;
            }
          }
        }
      }
    }
    if (NGUIText.alignment != NGUIText.Alignment.Left && count1 < verts.Count)
    {
      NGUIText.Align(verts, count1, num1 - NGUIText.finalSpacingX);
      int count2 = verts.Count;
    }
    NGUIText.mColors.Clear();
  }

  public static void PrintApproximateCharacterPositions(
    string text,
    List<Vector3> verts,
    List<int> indices)
  {
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    float x = 0.0f;
    float num1 = 0.0f;
    float num2 = (float) NGUIText.regionWidth + 0.01f;
    int length = text.Length;
    int count = verts.Count;
    int prev = 0;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    for (int index = 0; index < length; ++index)
    {
      int ch = (int) text[index];
      float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
      float num3 = fontScale * 0.5f;
      verts.Add(new Vector3(x, -num1 - num3));
      indices.Add(index);
      if (ch == 10)
      {
        if (NGUIText.alignment != NGUIText.Alignment.Left)
        {
          NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 1);
          count = verts.Count;
        }
        x = 0.0f;
        num1 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = 0;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
      {
        --index;
      }
      else
      {
        BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index, length) : (BMSymbol) null;
        if (bmSymbol == null)
        {
          float glyphWidth = NGUIText.GetGlyphWidth(ch, prev, fontScale);
          if ((double) glyphWidth != 0.0)
          {
            float num4 = glyphWidth + NGUIText.finalSpacingX;
            if ((double) x + (double) num4 > (double) num2)
            {
              if ((double) x == 0.0)
                return;
              if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
              {
                NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 1);
                count = verts.Count;
              }
              x = num4;
              num1 += NGUIText.finalLineHeight;
            }
            else
              x += num4;
            verts.Add(new Vector3(x, -num1 - num3));
            indices.Add(index + 1);
            prev = ch;
          }
        }
        else
        {
          float num5 = (float) bmSymbol.advance * fontScale + NGUIText.finalSpacingX;
          if ((double) x + (double) num5 > (double) num2)
          {
            if ((double) x == 0.0)
              return;
            if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
            {
              NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 1);
              count = verts.Count;
            }
            x = num5;
            num1 += NGUIText.finalLineHeight;
          }
          else
            x += num5;
          verts.Add(new Vector3(x, -num1 - num3));
          indices.Add(index + 1);
          index += bmSymbol.sequence.Length - 1;
          prev = 0;
        }
      }
    }
    if (NGUIText.alignment == NGUIText.Alignment.Left || count >= verts.Count)
      return;
    NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 1);
  }

  public static void PrintExactCharacterPositions(
    string text,
    List<Vector3> verts,
    List<int> indices)
  {
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    float x = 0.0f;
    float num1 = 0.0f;
    float num2 = (float) NGUIText.regionWidth + 0.01f;
    float num3 = (float) NGUIText.fontSize * NGUIText.fontScale;
    int length = text.Length;
    int count = verts.Count;
    int prev = 0;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    for (int index = 0; index < length; ++index)
    {
      int ch = (int) text[index];
      float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
      if (ch == 10)
      {
        if (NGUIText.alignment != NGUIText.Alignment.Left)
        {
          NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 2);
          count = verts.Count;
        }
        x = 0.0f;
        num1 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = 0;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
      {
        --index;
      }
      else
      {
        BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index, length) : (BMSymbol) null;
        if (bmSymbol == null)
        {
          float glyphWidth = NGUIText.GetGlyphWidth(ch, prev, fontScale);
          if ((double) glyphWidth != 0.0)
          {
            float num4 = glyphWidth + NGUIText.finalSpacingX;
            if ((double) x + (double) num4 > (double) num2)
            {
              if ((double) x == 0.0)
                return;
              if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
              {
                NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 2);
                count = verts.Count;
              }
              x = 0.0f;
              num1 += NGUIText.finalLineHeight;
              prev = 0;
              --index;
            }
            else
            {
              indices.Add(index);
              verts.Add(new Vector3(x, -num1 - num3));
              verts.Add(new Vector3(x + num4, -num1));
              prev = ch;
              x += num4;
            }
          }
        }
        else
        {
          float num5 = (float) bmSymbol.advance * fontScale + NGUIText.finalSpacingX;
          if ((double) x + (double) num5 > (double) num2)
          {
            if ((double) x == 0.0)
              return;
            if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
            {
              NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 2);
              count = verts.Count;
            }
            x = 0.0f;
            num1 += NGUIText.finalLineHeight;
            prev = 0;
            --index;
          }
          else
          {
            indices.Add(index);
            verts.Add(new Vector3(x, -num1 - num3));
            verts.Add(new Vector3(x + num5, -num1));
            index += bmSymbol.sequence.Length - 1;
            x += num5;
            prev = 0;
          }
        }
      }
    }
    if (NGUIText.alignment == NGUIText.Alignment.Left || count >= verts.Count)
      return;
    NGUIText.Align(verts, count, x - NGUIText.finalSpacingX, 2);
  }

  public static void PrintCaretAndSelection(
    string text,
    int start,
    int end,
    List<Vector3> caret,
    List<Vector3> highlight)
  {
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    int num1 = end;
    if (start > end)
    {
      end = start;
      start = num1;
    }
    float x1 = 0.0f;
    float num2 = 0.0f;
    float num3 = (float) NGUIText.fontSize * NGUIText.fontScale;
    int indexOffset1 = caret != null ? caret.Count : 0;
    int indexOffset2 = highlight != null ? highlight.Count : 0;
    int length = text.Length;
    int index = 0;
    int prev = 0;
    bool flag1 = false;
    bool flag2 = false;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    bool ignoreColor = false;
    Vector2 vector2_1 = Vector2.zero;
    Vector2 vector2_2 = Vector2.zero;
    for (; index < length; ++index)
    {
      float fontScale = sub == 0 ? NGUIText.fontScale : NGUIText.fontScale * 0.75f;
      if (caret != null && !flag2 && num1 <= index)
      {
        flag2 = true;
        caret.Add(new Vector3(x1 - 1f, -num2 - num3));
        caret.Add(new Vector3(x1 - 1f, -num2));
        caret.Add(new Vector3(x1 + 1f, -num2));
        caret.Add(new Vector3(x1 + 1f, -num2 - num3));
      }
      int ch = (int) text[index];
      if (ch == 10)
      {
        if (caret != null & flag2)
        {
          if (NGUIText.alignment != NGUIText.Alignment.Left)
            NGUIText.Align(caret, indexOffset1, x1 - NGUIText.finalSpacingX);
          caret = (List<Vector3>) null;
        }
        if (highlight != null)
        {
          if (flag1)
          {
            flag1 = false;
            highlight.Add((Vector3) vector2_2);
            highlight.Add((Vector3) vector2_1);
          }
          else if (start <= index && end > index)
          {
            highlight.Add(new Vector3(x1, -num2 - num3));
            highlight.Add(new Vector3(x1, -num2));
            highlight.Add(new Vector3(x1 + 2f, -num2));
            highlight.Add(new Vector3(x1 + 2f, -num2 - num3));
          }
          if (NGUIText.alignment != NGUIText.Alignment.Left && indexOffset2 < highlight.Count)
          {
            NGUIText.Align(highlight, indexOffset2, x1 - NGUIText.finalSpacingX);
            indexOffset2 = highlight.Count;
          }
        }
        x1 = 0.0f;
        num2 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = 0;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
      {
        --index;
      }
      else
      {
        BMSymbol bmSymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, index, length) : (BMSymbol) null;
        float num4 = bmSymbol != null ? (float) bmSymbol.advance * fontScale : NGUIText.GetGlyphWidth(ch, prev, fontScale);
        if ((double) num4 != 0.0)
        {
          float x2 = x1;
          float x3 = x1 + num4;
          float y1 = -num2 - num3;
          float y2 = -num2;
          if ((double) x3 + (double) NGUIText.finalSpacingX > (double) NGUIText.regionWidth)
          {
            if ((double) x1 == 0.0)
              return;
            if (caret != null & flag2)
            {
              if (NGUIText.alignment != NGUIText.Alignment.Left)
                NGUIText.Align(caret, indexOffset1, x1 - NGUIText.finalSpacingX);
              caret = (List<Vector3>) null;
            }
            if (highlight != null)
            {
              if (flag1)
              {
                flag1 = false;
                highlight.Add((Vector3) vector2_2);
                highlight.Add((Vector3) vector2_1);
              }
              else if (start <= index && end > index)
              {
                highlight.Add(new Vector3(x1, -num2 - num3));
                highlight.Add(new Vector3(x1, -num2));
                highlight.Add(new Vector3(x1 + 2f, -num2));
                highlight.Add(new Vector3(x1 + 2f, -num2 - num3));
              }
              if (NGUIText.alignment != NGUIText.Alignment.Left && indexOffset2 < highlight.Count)
              {
                NGUIText.Align(highlight, indexOffset2, x1 - NGUIText.finalSpacingX);
                indexOffset2 = highlight.Count;
              }
            }
            x2 -= x1;
            x3 -= x1;
            y1 -= NGUIText.finalLineHeight;
            y2 -= NGUIText.finalLineHeight;
            x1 = 0.0f;
            num2 += NGUIText.finalLineHeight;
          }
          x1 += num4 + NGUIText.finalSpacingX;
          if (highlight != null)
          {
            if (start > index || end <= index)
            {
              if (flag1)
              {
                flag1 = false;
                highlight.Add((Vector3) vector2_2);
                highlight.Add((Vector3) vector2_1);
              }
            }
            else if (!flag1)
            {
              flag1 = true;
              highlight.Add(new Vector3(x2, y1));
              highlight.Add(new Vector3(x2, y2));
            }
          }
          vector2_1 = new Vector2(x3, y1);
          vector2_2 = new Vector2(x3, y2);
          prev = ch;
        }
      }
    }
    if (caret != null)
    {
      if (!flag2)
      {
        caret.Add(new Vector3(x1 - 1f, -num2 - num3));
        caret.Add(new Vector3(x1 - 1f, -num2));
        caret.Add(new Vector3(x1 + 1f, -num2));
        caret.Add(new Vector3(x1 + 1f, -num2 - num3));
      }
      if (NGUIText.alignment != NGUIText.Alignment.Left)
        NGUIText.Align(caret, indexOffset1, x1 - NGUIText.finalSpacingX);
    }
    if (highlight != null)
    {
      if (flag1)
      {
        highlight.Add((Vector3) vector2_2);
        highlight.Add((Vector3) vector2_1);
      }
      else if (start < index && end == index)
      {
        highlight.Add(new Vector3(x1, -num2 - num3));
        highlight.Add(new Vector3(x1, -num2));
        highlight.Add(new Vector3(x1 + 2f, -num2));
        highlight.Add(new Vector3(x1 + 2f, -num2 - num3));
      }
      if (NGUIText.alignment != NGUIText.Alignment.Left && indexOffset2 < highlight.Count)
        NGUIText.Align(highlight, indexOffset2, x1 - NGUIText.finalSpacingX);
    }
    NGUIText.mColors.Clear();
  }

  public static bool ReplaceLink(
    ref string text,
    ref int index,
    string type,
    string prefix = null,
    string suffix = null)
  {
    if (index == -1)
      return false;
    index = text.IndexOf(type, index);
    if (index == -1)
      return false;
    if (index > 5)
    {
      for (int index1 = index - 5; index1 >= 0; --index1)
      {
        if (text[index1] == '[')
        {
          if (text[index1 + 1] == 'u' && text[index1 + 2] == 'r' && text[index1 + 3] == 'l' && text[index1 + 4] == '=')
          {
            index += type.Length;
            return NGUIText.ReplaceLink(ref text, ref index, type, prefix, suffix);
          }
          if (text[index1 + 1] == '/' && text[index1 + 2] == 'u' && text[index1 + 3] == 'r' && text[index1 + 4] == 'l')
            break;
        }
      }
    }
    int startIndex1 = index + type.Length;
    int startIndex2 = text.IndexOfAny(new char[5]
    {
      ' ',
      '\n',
      ' ',
      '\u200B',
      ' '
    }, startIndex1);
    if (startIndex2 == -1)
      startIndex2 = text.Length;
    int num = text.IndexOfAny(new char[2]{ '/', ' ' }, startIndex1);
    if (num == -1 || num == startIndex1)
    {
      index += type.Length;
      return true;
    }
    string str1 = text.Substring(0, index);
    string str2 = text.Substring(index, startIndex2 - index);
    string str3 = text.Substring(startIndex2);
    string str4 = text.Substring(startIndex1, num - startIndex1);
    if (!string.IsNullOrEmpty(prefix))
      str1 += prefix;
    text = str1 + "[url=" + str2 + "][u]" + str4 + "[/u][/url]";
    index = text.Length;
    text = !string.IsNullOrEmpty(suffix) ? text + suffix + str3 : text + str3;
    return true;
  }

  public static bool InsertHyperlink(
    ref string text,
    ref int index,
    string keyword,
    string link,
    string prefix = null,
    string suffix = null)
  {
    int num = text.IndexOf(keyword, index, StringComparison.CurrentCultureIgnoreCase);
    if (num == -1)
      return false;
    if (num > 5)
    {
      for (int index1 = num - 5; index1 >= 0; --index1)
      {
        if (text[index1] == '[')
        {
          if (text[index1 + 1] == 'u' && text[index1 + 2] == 'r' && text[index1 + 3] == 'l' && text[index1 + 4] == '=')
          {
            index = num + keyword.Length;
            return NGUIText.InsertHyperlink(ref text, ref index, keyword, link, prefix, suffix);
          }
          if (text[index1 + 1] == '/' && text[index1 + 2] == 'u' && text[index1 + 3] == 'r' && text[index1 + 4] == 'l')
            break;
        }
      }
    }
    string str1 = text.Substring(0, num);
    string str2 = "[url=" + link + "][u]";
    string str3 = text.Substring(num, keyword.Length);
    if (!string.IsNullOrEmpty(prefix))
      str3 = prefix + str3;
    if (!string.IsNullOrEmpty(suffix))
      str3 += suffix;
    string str4 = text.Substring(num + keyword.Length);
    text = str1 + str2 + str3 + "[/u][/url]";
    index = text.Length;
    text += str4;
    return true;
  }

  public static void ReplaceLinks(ref string text, string prefix = null, string suffix = null)
  {
    int index1 = 0;
    do
      ;
    while (index1 < text.Length && NGUIText.ReplaceLink(ref text, ref index1, "http://", prefix, suffix));
    int index2 = 0;
    do
      ;
    while (index2 < text.Length && NGUIText.ReplaceLink(ref text, ref index2, "https://", prefix, suffix));
  }

  [DoNotObfuscateNGUI]
  public enum Alignment
  {
    Automatic,
    Left,
    Center,
    Right,
    Justified,
  }

  [DoNotObfuscateNGUI]
  public enum SymbolStyle
  {
    None,
    Normal,
    Colored,
    NoOutline,
  }

  public class GlyphInfo
  {
    public Vector2 v0;
    public Vector2 v1;
    public Vector2 u0;
    public Vector2 u1;
    public Vector2 u2;
    public Vector2 u3;
    public float advance;
    public int channel;
  }
}
