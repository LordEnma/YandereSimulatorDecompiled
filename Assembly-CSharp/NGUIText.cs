using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

// Token: 0x02000077 RID: 119
public static class NGUIText
{
	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060003B3 RID: 947 RVA: 0x000247B3 File Offset: 0x000229B3
	public static bool isDynamic
	{
		get
		{
			return NGUIText.bitmapFont == null;
		}
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x000247BD File Offset: 0x000229BD
	public static void Update()
	{
		NGUIText.Update(true);
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x000247C8 File Offset: 0x000229C8
	public static void Update(bool request)
	{
		NGUIText.finalSize = Mathf.RoundToInt((float)NGUIText.fontSize / NGUIText.pixelDensity);
		NGUIText.finalSpacingX = NGUIText.spacingX * NGUIText.fontScale;
		NGUIText.finalLineHeight = ((float)NGUIText.fontSize + NGUIText.spacingY) * NGUIText.fontScale;
		NGUIText.useSymbols = ((NGUIText.dynamicFont != null || NGUIText.bitmapFont != null) && NGUIText.encoding && NGUIText.symbolStyle > NGUIText.SymbolStyle.None);
		Font font = NGUIText.dynamicFont;
		if (font != null && request)
		{
			font.RequestCharactersInTexture(")_-", NGUIText.finalSize, NGUIText.fontStyle);
			if (!font.GetCharacterInfo(')', out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle) || (float)NGUIText.mTempChar.maxY == 0f)
			{
				font.RequestCharactersInTexture("A", NGUIText.finalSize, NGUIText.fontStyle);
				if (!font.GetCharacterInfo('A', out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
				{
					NGUIText.baseline = 0f;
					return;
				}
			}
			float num = (float)NGUIText.mTempChar.maxY;
			float num2 = (float)NGUIText.mTempChar.minY;
			NGUIText.baseline = Mathf.Round(num + ((float)NGUIText.finalSize - num + num2) * 0.5f);
		}
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x000248FE File Offset: 0x00022AFE
	public static void Prepare(string text)
	{
		NGUIText.mColors.Clear();
		if (NGUIText.dynamicFont != null)
		{
			NGUIText.dynamicFont.RequestCharactersInTexture(text, NGUIText.finalSize, NGUIText.fontStyle);
		}
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0002492C File Offset: 0x00022B2C
	public static BMSymbol GetSymbol(string text, int index, int textLength)
	{
		if (NGUIText.bitmapFont != null)
		{
			return NGUIText.bitmapFont.MatchSymbol(text, index, textLength);
		}
		return null;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00024944 File Offset: 0x00022B44
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
			BMGlyph bmglyph = null;
			if (NGUIText.bitmapFont != null)
			{
				bmglyph = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
			}
			if (bmglyph != null)
			{
				int num = bmglyph.advance;
				if (flag)
				{
					num >>= 1;
				}
				return fontScale * (float)((prev != 0) ? (num + bmglyph.GetKerning(prev)) : bmglyph.advance);
			}
		}
		else if (NGUIText.dynamicFont != null && NGUIText.dynamicFont.GetCharacterInfo((char)ch, out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
		{
			return (float)NGUIText.mTempChar.advance * fontScale * NGUIText.pixelDensity;
		}
		return 0f;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x000249F0 File Offset: 0x00022BF0
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
			BMGlyph bmglyph = null;
			if (NGUIText.bitmapFont != null)
			{
				bmglyph = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
			}
			if (bmglyph != null)
			{
				int num = (prev != 0) ? bmglyph.GetKerning(prev) : 0;
				NGUIText.glyph.v0.x = (float)((prev != 0) ? (bmglyph.offsetX + num) : bmglyph.offsetX);
				NGUIText.glyph.v1.y = (float)(-(float)bmglyph.offsetY);
				NGUIText.glyph.v1.x = NGUIText.glyph.v0.x + (float)bmglyph.width;
				NGUIText.glyph.v0.y = NGUIText.glyph.v1.y - (float)bmglyph.height;
				NGUIText.glyph.u0.x = (float)bmglyph.x;
				NGUIText.glyph.u0.y = (float)(bmglyph.y + bmglyph.height);
				NGUIText.glyph.u2.x = (float)(bmglyph.x + bmglyph.width);
				NGUIText.glyph.u2.y = (float)bmglyph.y;
				NGUIText.glyph.u1.x = NGUIText.glyph.u0.x;
				NGUIText.glyph.u1.y = NGUIText.glyph.u2.y;
				NGUIText.glyph.u3.x = NGUIText.glyph.u2.x;
				NGUIText.glyph.u3.y = NGUIText.glyph.u0.y;
				int num2 = bmglyph.advance;
				if (flag)
				{
					num2 >>= 1;
				}
				NGUIText.glyph.advance = (float)(num2 + num);
				NGUIText.glyph.channel = bmglyph.channel;
				if (fontScale != 1f)
				{
					NGUIText.glyph.v0 *= fontScale;
					NGUIText.glyph.v1 *= fontScale;
					NGUIText.glyph.advance *= fontScale;
				}
				return NGUIText.glyph;
			}
		}
		else if (NGUIText.dynamicFont != null && NGUIText.dynamicFont.GetCharacterInfo((char)ch, out NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
		{
			NGUIText.glyph.v0.x = (float)NGUIText.mTempChar.minX;
			NGUIText.glyph.v1.x = (float)NGUIText.mTempChar.maxX;
			NGUIText.glyph.v0.y = (float)NGUIText.mTempChar.maxY - NGUIText.baseline;
			NGUIText.glyph.v1.y = (float)NGUIText.mTempChar.minY - NGUIText.baseline;
			NGUIText.glyph.u0 = NGUIText.mTempChar.uvTopLeft;
			NGUIText.glyph.u1 = NGUIText.mTempChar.uvBottomLeft;
			NGUIText.glyph.u2 = NGUIText.mTempChar.uvBottomRight;
			NGUIText.glyph.u3 = NGUIText.mTempChar.uvTopRight;
			NGUIText.glyph.advance = (float)NGUIText.mTempChar.advance;
			NGUIText.glyph.channel = 0;
			NGUIText.glyph.v0.x = Mathf.Round(NGUIText.glyph.v0.x);
			NGUIText.glyph.v0.y = Mathf.Round(NGUIText.glyph.v0.y);
			NGUIText.glyph.v1.x = Mathf.Round(NGUIText.glyph.v1.x);
			NGUIText.glyph.v1.y = Mathf.Round(NGUIText.glyph.v1.y);
			float num3 = fontScale * NGUIText.pixelDensity;
			if (num3 != 1f)
			{
				NGUIText.glyph.v0 *= num3;
				NGUIText.glyph.v1 *= num3;
				NGUIText.glyph.advance *= num3;
			}
			return NGUIText.glyph;
		}
		return null;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00024E1B File Offset: 0x0002301B
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static float ParseAlpha(string text, int index)
	{
		return Mathf.Clamp01((float)(NGUIMath.HexToDecimal(text[index + 1]) << 4 | NGUIMath.HexToDecimal(text[index + 2])) / 255f);
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00024E48 File Offset: 0x00023048
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor(string text, int offset = 0)
	{
		return NGUIText.ParseColor24(text, offset);
	}

	// Token: 0x060003BC RID: 956 RVA: 0x00024E54 File Offset: 0x00023054
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor24(string text, int offset = 0)
	{
		int num = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
		float num4 = 0.003921569f;
		return new Color(num4 * (float)num, num4 * (float)num2, num4 * (float)num3);
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00024ED8 File Offset: 0x000230D8
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor32(string text, int offset)
	{
		int num = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
		int num4 = NGUIMath.HexToDecimal(text[offset + 6]) << 4 | NGUIMath.HexToDecimal(text[offset + 7]);
		float num5 = 0.003921569f;
		return new Color(num5 * (float)num, num5 * (float)num2, num5 * (float)num3, num5 * (float)num4);
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00024F83 File Offset: 0x00023183
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor(Color c)
	{
		return NGUIText.EncodeColor24(c);
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00024F8B File Offset: 0x0002318B
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor(string text, Color c)
	{
		return string.Concat(new string[]
		{
			"[c][",
			NGUIText.EncodeColor24(c),
			"]",
			text,
			"[-][/c]"
		});
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00024FBD File Offset: 0x000231BD
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeAlpha(float a)
	{
		return NGUIMath.DecimalToHex8(Mathf.Clamp(Mathf.RoundToInt(a * 255f), 0, 255));
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00024FDB File Offset: 0x000231DB
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor24(Color c)
	{
		return NGUIMath.DecimalToHex24(16777215 & NGUIMath.ColorToInt(c) >> 8);
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00024FF0 File Offset: 0x000231F0
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor32(Color c)
	{
		return NGUIMath.DecimalToHex32(NGUIMath.ColorToInt(c));
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00025000 File Offset: 0x00023200
	public static bool ParseSymbol(string text, ref int index)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		return NGUIText.ParseSymbol(text, ref index, null, false, ref num, ref flag, ref flag2, ref flag3, ref flag4, ref flag5);
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00025030 File Offset: 0x00023230
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool IsHex(char ch)
	{
		return (ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'f') || (ch >= 'A' && ch <= 'F');
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x00025058 File Offset: 0x00023258
	public static bool ParseSymbol(string text, ref int index, BetterList<Color> colors, bool premultiply, ref int sub, ref bool bold, ref bool italic, ref bool underline, ref bool strike, ref bool ignoreColor)
	{
		int length = text.Length;
		if (index + 3 > length || text[index] != '[')
		{
			return false;
		}
		if (text[index + 2] == ']')
		{
			if (text[index + 1] == '-')
			{
				if (colors != null && colors.size > 1)
				{
					colors.RemoveAt(colors.size - 1);
				}
				index += 3;
				return true;
			}
			string text2 = text.Substring(index, 3);
			if (text2 != null)
			{
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text2);
				if (num <= 2063584546U)
				{
					if (num <= 1993767119U)
					{
						if (num != 1992236928U)
						{
							if (num != 1993767119U)
							{
								goto IL_1EF;
							}
							if (!(text2 == "[b]"))
							{
								goto IL_1EF;
							}
						}
						else
						{
							if (!(text2 == "[u]"))
							{
								goto IL_1EF;
							}
							goto IL_1CB;
						}
					}
					else if (num != 1998151356U)
					{
						if (num != 2061024690U)
						{
							if (num != 2063584546U)
							{
								goto IL_1EF;
							}
							if (!(text2 == "[S]"))
							{
								goto IL_1EF;
							}
							goto IL_1D7;
						}
						else
						{
							if (!(text2 == "[c]"))
							{
								goto IL_1EF;
							}
							goto IL_1E3;
						}
					}
					else
					{
						if (!(text2 == "[I]"))
						{
							goto IL_1EF;
						}
						goto IL_1BF;
					}
				}
				else if (num <= 3071227424U)
				{
					if (num != 3066696092U)
					{
						if (num != 3071227424U)
						{
							goto IL_1EF;
						}
						if (!(text2 == "[U]"))
						{
							goto IL_1EF;
						}
						goto IL_1CB;
					}
					else
					{
						if (!(text2 == "[i]"))
						{
							goto IL_1EF;
						}
						goto IL_1BF;
					}
				}
				else if (num != 3072654447U)
				{
					if (num != 3132129282U)
					{
						if (num != 3139912018U)
						{
							goto IL_1EF;
						}
						if (!(text2 == "[C]"))
						{
							goto IL_1EF;
						}
						goto IL_1E3;
					}
					else
					{
						if (!(text2 == "[s]"))
						{
							goto IL_1EF;
						}
						goto IL_1D7;
					}
				}
				else if (!(text2 == "[B]"))
				{
					goto IL_1EF;
				}
				bold = true;
				index += 3;
				return true;
				IL_1BF:
				italic = true;
				index += 3;
				return true;
				IL_1CB:
				underline = true;
				index += 3;
				return true;
				IL_1D7:
				strike = true;
				index += 3;
				return true;
				IL_1E3:
				ignoreColor = true;
				index += 3;
				return true;
			}
		}
		IL_1EF:
		if (index + 4 > length)
		{
			return false;
		}
		if (text[index + 3] == ']')
		{
			string text3 = text.Substring(index, 4);
			if (text3 != null)
			{
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
				if (num <= 629802537U)
				{
					if (num <= 560426395U)
					{
						if (num != 557763371U)
						{
							if (num != 560426395U)
							{
								goto IL_398;
							}
							if (!(text3 == "[/c]"))
							{
								goto IL_398;
							}
							goto IL_38C;
						}
						else
						{
							if (!(text3 == "[/S]"))
							{
								goto IL_398;
							}
							goto IL_380;
						}
					}
					else if (num != 626551133U)
					{
						if (num != 627683966U)
						{
							if (num != 629802537U)
							{
								goto IL_398;
							}
							if (!(text3 == "[/u]"))
							{
								goto IL_398;
							}
							goto IL_374;
						}
						else if (!(text3 == "[/b]"))
						{
							goto IL_398;
						}
					}
					else
					{
						if (!(text3 == "[/i]"))
						{
							goto IL_398;
						}
						goto IL_368;
					}
				}
				else if (num <= 1636753867U)
				{
					if (num != 1628971131U)
					{
						if (num != 1636753867U)
						{
							goto IL_398;
						}
						if (!(text3 == "[/s]"))
						{
							goto IL_398;
						}
						goto IL_380;
					}
					else
					{
						if (!(text3 == "[/C]"))
						{
							goto IL_398;
						}
						goto IL_38C;
					}
				}
				else if (num != 1695095869U)
				{
					if (num != 1696228702U)
					{
						if (num != 1698347273U)
						{
							goto IL_398;
						}
						if (!(text3 == "[/U]"))
						{
							goto IL_398;
						}
						goto IL_374;
					}
					else if (!(text3 == "[/B]"))
					{
						goto IL_398;
					}
				}
				else
				{
					if (!(text3 == "[/I]"))
					{
						goto IL_398;
					}
					goto IL_368;
				}
				bold = false;
				index += 4;
				return true;
				IL_368:
				italic = false;
				index += 4;
				return true;
				IL_374:
				underline = false;
				index += 4;
				return true;
				IL_380:
				strike = false;
				index += 4;
				return true;
				IL_38C:
				ignoreColor = false;
				index += 4;
				return true;
			}
			IL_398:
			char ch = text[index + 1];
			char ch2 = text[index + 2];
			if (NGUIText.IsHex(ch) && NGUIText.IsHex(ch2))
			{
				NGUIText.mAlpha = (float)(NGUIMath.HexToDecimal(ch) << 4 | NGUIMath.HexToDecimal(ch2)) / 255f;
				index += 4;
				return true;
			}
		}
		if (index + 5 > length)
		{
			return false;
		}
		if (text[index + 4] == ']')
		{
			string text4 = text.Substring(index, 5);
			if (text4 != null)
			{
				if (text4 == "[sub]" || text4 == "[SUB]")
				{
					sub = 1;
					index += 5;
					return true;
				}
				if (text4 == "[sup]" || text4 == "[SUP]")
				{
					sub = 2;
					index += 5;
					return true;
				}
			}
		}
		if (index + 6 > length)
		{
			return false;
		}
		if (text[index + 5] == ']')
		{
			string text5 = text.Substring(index, 6);
			if (text5 != null)
			{
				if (text5 == "[/sub]" || text5 == "[/SUB]")
				{
					sub = 0;
					index += 6;
					return true;
				}
				if (text5 == "[/sup]" || text5 == "[/SUP]")
				{
					sub = 0;
					index += 6;
					return true;
				}
				if (text5 == "[/url]" || text5 == "[/URL]")
				{
					index += 6;
					return true;
				}
			}
		}
		if (text[index + 1] == 'u' && text[index + 2] == 'r' && text[index + 3] == 'l' && text[index + 4] == '=')
		{
			int num2 = text.IndexOf(']', index + 4);
			if (num2 != -1)
			{
				index = num2 + 1;
				return true;
			}
			index = text.Length;
			return true;
		}
		else
		{
			if (index + 8 > length)
			{
				return false;
			}
			if (text[index + 7] == ']')
			{
				Color color = NGUIText.ParseColor24(text, index + 1);
				if (NGUIText.EncodeColor24(color) != text.Substring(index + 1, 6).ToUpper())
				{
					return false;
				}
				if (colors != null && colors.size > 0)
				{
					color.a = colors.buffer[colors.size - 1].a;
					if (premultiply && color.a != 1f)
					{
						color = Color.Lerp(NGUIText.mInvisible, color, color.a);
					}
					colors.Add(color);
				}
				index += 8;
				return true;
			}
			else
			{
				if (index + 10 > length)
				{
					return false;
				}
				if (text[index + 9] != ']')
				{
					return false;
				}
				Color color2 = NGUIText.ParseColor32(text, index + 1);
				if (NGUIText.EncodeColor32(color2) != text.Substring(index + 1, 8).ToUpper())
				{
					return false;
				}
				if (colors != null)
				{
					if (premultiply && color2.a != 1f)
					{
						color2 = Color.Lerp(NGUIText.mInvisible, color2, color2.a);
					}
					colors.Add(color2);
				}
				index += 10;
				return true;
			}
		}
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000256E8 File Offset: 0x000238E8
	public static string StripSymbols(string text)
	{
		if (text != null)
		{
			int i = 0;
			int length = text.Length;
			while (i < length)
			{
				if (text[i] == '[')
				{
					int num = 0;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					int num2 = i;
					if (NGUIText.ParseSymbol(text, ref num2, null, false, ref num, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
					{
						text = text.Remove(i, num2 - i);
						length = text.Length;
						continue;
					}
				}
				i++;
			}
		}
		return text;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x00025758 File Offset: 0x00023958
	public static void Align(List<Vector3> verts, int indexOffset, float printedWidth, int elements = 4)
	{
		switch (NGUIText.alignment)
		{
		case NGUIText.Alignment.Center:
		{
			float num = ((float)NGUIText.rectWidth - printedWidth) * 0.5f;
			if (num < 0f)
			{
				return;
			}
			int num2 = Mathf.RoundToInt((float)NGUIText.rectWidth - printedWidth);
			int num3 = Mathf.RoundToInt((float)NGUIText.rectWidth);
			bool flag = (num2 & 1) == 1;
			bool flag2 = (num3 & 1) == 1;
			if ((flag && !flag2) || (!flag && flag2))
			{
				num += 0.5f * NGUIText.fontScale;
			}
			int i = indexOffset;
			int count = verts.Count;
			while (i < count)
			{
				Vector3 value = verts[i];
				value.x += num;
				verts[i] = value;
				i++;
			}
			return;
		}
		case NGUIText.Alignment.Right:
		{
			float num4 = (float)NGUIText.rectWidth - printedWidth;
			if (num4 < 0f)
			{
				return;
			}
			int j = indexOffset;
			int count2 = verts.Count;
			while (j < count2)
			{
				Vector3 value2 = verts[j];
				value2.x += num4;
				verts[j] = value2;
				j++;
			}
			return;
		}
		case NGUIText.Alignment.Justified:
		{
			if (printedWidth < (float)NGUIText.rectWidth * 0.65f)
			{
				return;
			}
			if (((float)NGUIText.rectWidth - printedWidth) * 0.5f < 1f)
			{
				return;
			}
			int num5 = (verts.Count - indexOffset) / elements;
			if (num5 < 1)
			{
				return;
			}
			float num6 = 1f / (float)(num5 - 1);
			float num7 = (float)NGUIText.rectWidth / printedWidth;
			int k = indexOffset + elements;
			int num8 = 1;
			int count3 = verts.Count;
			while (k < count3)
			{
				float num9 = verts[k].x;
				float num10 = verts[k + elements / 2].x;
				float num11 = num10 - num9;
				float num12 = num9 * num7;
				float a = num12 + num11;
				float num13 = num10 * num7;
				float b = num13 - num11;
				float t = (float)num8 * num6;
				num10 = Mathf.Lerp(a, num13, t);
				num9 = Mathf.Lerp(num12, b, t);
				num9 = Mathf.Round(num9);
				num10 = Mathf.Round(num10);
				if (elements == 4)
				{
					Vector3 value3 = verts[k];
					value3.x = num9;
					verts[k++] = value3;
					value3 = verts[k];
					value3.x = num9;
					verts[k++] = value3;
					value3 = verts[k];
					value3.x = num10;
					verts[k++] = value3;
					value3 = verts[k];
					value3.x = num10;
					verts[k++] = value3;
				}
				else if (elements == 2)
				{
					Vector3 value3 = verts[k];
					value3.x = num9;
					verts[k++] = value3;
					value3 = verts[k];
					value3.x = num10;
					verts[k++] = value3;
				}
				else if (elements == 1)
				{
					Vector3 value3 = verts[k];
					value3.x = num9;
					verts[k++] = value3;
				}
				num8++;
			}
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x00025A4C File Offset: 0x00023C4C
	public static int GetExactCharacterIndex(List<Vector3> verts, List<int> indices, Vector2 pos)
	{
		int i = 0;
		int count = indices.Count;
		while (i < count)
		{
			int num = i << 1;
			int index = num + 1;
			float x = verts[num].x;
			if (pos.x >= x)
			{
				float x2 = verts[index].x;
				if (pos.x <= x2)
				{
					float y = verts[num].y;
					if (pos.y >= y)
					{
						float y2 = verts[index].y;
						if (pos.y <= y2)
						{
							return indices[i];
						}
					}
				}
			}
			i++;
		}
		return 0;
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00025AE0 File Offset: 0x00023CE0
	public static int GetApproximateCharacterIndex(List<Vector3> verts, List<int> indices, Vector2 pos)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		int index = 0;
		int i = 0;
		int count = verts.Count;
		while (i < count)
		{
			float num3 = Mathf.Abs(pos.y - verts[i].y);
			if (num3 <= num2)
			{
				float num4 = Mathf.Abs(pos.x - verts[i].x);
				if (num3 < num2)
				{
					num2 = num3;
					num = num4;
					index = i;
				}
				else if (num4 < num)
				{
					num = num4;
					index = i;
				}
			}
			i++;
		}
		return indices[index];
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00025B69 File Offset: 0x00023D69
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool IsSpace(int ch)
	{
		return ch == 32 || ch == 8202 || ch == 8203 || ch == 8201;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00025B8C File Offset: 0x00023D8C
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static void EndLine(ref StringBuilder s)
	{
		int num = s.Length - 1;
		if (num > 0 && NGUIText.IsSpace((int)s[num]))
		{
			s[num] = '\n';
			return;
		}
		s.Append('\n');
	}

	// Token: 0x060003CC RID: 972 RVA: 0x00025BCC File Offset: 0x00023DCC
	[DebuggerHidden]
	[DebuggerStepThrough]
	private static void ReplaceSpaceWithNewline(ref StringBuilder s)
	{
		int num = s.Length - 1;
		if (num > 0 && NGUIText.IsSpace((int)s[num]))
		{
			s[num] = '\n';
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00025C00 File Offset: 0x00023E00
	public static Vector2 CalculatePrintedSize(string text)
	{
		Vector2 zero = Vector2.zero;
		if (!string.IsNullOrEmpty(text))
		{
			NGUIText.Prepare(text);
			int prev = 0;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = (float)NGUIText.regionWidth + 0.01f;
			int length = text.Length;
			int num5 = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			for (int i = 0; i < length; i++)
			{
				int num6 = (int)text[i];
				if (num6 == 10)
				{
					if (num > num3)
					{
						num3 = num;
					}
					num = 0f;
					num2 += NGUIText.finalLineHeight;
					prev = 0;
				}
				else if (num6 < 32)
				{
					prev = num6;
				}
				else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num5, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
				{
					i--;
				}
				else
				{
					BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
					float num7 = (num5 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
					if (bmsymbol != null)
					{
						float num8 = (float)bmsymbol.advance * num7;
						float num9 = num + num8;
						if (num9 > num4)
						{
							if (num == 0f)
							{
								break;
							}
							if (num > num3)
							{
								num3 = num;
							}
							num = 0f;
							num2 += NGUIText.finalLineHeight;
						}
						else if (num9 > num3)
						{
							num3 = num9;
						}
						num += num8 + NGUIText.finalSpacingX;
						i += bmsymbol.length - 1;
						prev = 0;
					}
					else
					{
						NGUIText.GlyphInfo glyphInfo = NGUIText.GetGlyph(num6, prev, num7);
						if (glyphInfo != null)
						{
							prev = num6;
							float num10 = glyphInfo.advance;
							if (num5 != 0)
							{
								if (num5 == 1)
								{
									float num11 = NGUIText.fontScale * (float)NGUIText.fontSize * 0.4f;
									NGUIText.GlyphInfo glyphInfo2 = glyphInfo;
									glyphInfo2.v0.y = glyphInfo2.v0.y - num11;
									NGUIText.GlyphInfo glyphInfo3 = glyphInfo;
									glyphInfo3.v1.y = glyphInfo3.v1.y - num11;
								}
								else
								{
									float num12 = NGUIText.fontScale * (float)NGUIText.fontSize * 0.05f;
									NGUIText.GlyphInfo glyphInfo4 = glyphInfo;
									glyphInfo4.v0.y = glyphInfo4.v0.y + num12;
									NGUIText.GlyphInfo glyphInfo5 = glyphInfo;
									glyphInfo5.v1.y = glyphInfo5.v1.y + num12;
								}
							}
							num10 += NGUIText.finalSpacingX;
							float num13 = num + num10;
							if (num13 > num4)
							{
								if (num == 0f)
								{
									goto IL_263;
								}
								num2 += NGUIText.finalLineHeight;
							}
							else if (num13 > num3)
							{
								num3 = num13;
							}
							if (NGUIText.IsSpace(num6))
							{
								if (flag3)
								{
									num6 = 95;
								}
								else if (flag4)
								{
									num6 = 45;
								}
							}
							num = num13;
							if (num5 != 0)
							{
								num = Mathf.Round(num);
							}
							NGUIText.IsSpace(num6);
						}
					}
				}
				IL_263:;
			}
			zero.x = Mathf.Ceil((num > num3) ? (num - NGUIText.finalSpacingX) : num3);
			zero.y = Mathf.Ceil(num2 + NGUIText.finalLineHeight);
		}
		return zero;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00025EB0 File Offset: 0x000240B0
	public static int CalculateOffsetToFit(string text)
	{
		if (string.IsNullOrEmpty(text) || NGUIText.regionWidth < 1)
		{
			return 0;
		}
		NGUIText.Prepare(text);
		int length = text.Length;
		int prev = 0;
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		int i = 0;
		int length2 = text.Length;
		while (i < length2)
		{
			float num2 = (num == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
			BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
			if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
			{
				i--;
			}
			else if (bmsymbol == null)
			{
				char c = text[i];
				float glyphWidth = NGUIText.GetGlyphWidth((int)c, prev, num2);
				if (glyphWidth != 0f)
				{
					NGUIText.mSizes.Add(NGUIText.finalSpacingX + glyphWidth);
				}
				prev = (int)c;
			}
			else
			{
				NGUIText.mSizes.Add(NGUIText.finalSpacingX + (float)bmsymbol.advance * num2);
				int j = 0;
				int num3 = bmsymbol.sequence.Length - 1;
				while (j < num3)
				{
					NGUIText.mSizes.Add(0f);
					j++;
				}
				i += bmsymbol.sequence.Length - 1;
				prev = 0;
			}
			i++;
		}
		float num4 = (float)NGUIText.regionWidth;
		int num5 = NGUIText.mSizes.size;
		while (num5 > 0 && num4 > 0f)
		{
			num4 -= NGUIText.mSizes.buffer[--num5];
		}
		NGUIText.mSizes.Clear();
		if (num4 < 0f)
		{
			num5++;
		}
		return num5;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00026058 File Offset: 0x00024258
	public static string GetEndOfLineThatFits(string text)
	{
		int length = text.Length;
		int num = NGUIText.CalculateOffsetToFit(text);
		return text.Substring(num, length - num);
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0002607D File Offset: 0x0002427D
	public static bool WrapText(string text, out string finalText, bool wrapLineColors = false)
	{
		return NGUIText.WrapText(text, out finalText, false, wrapLineColors, false);
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0002608C File Offset: 0x0002428C
	public static bool WrapText(string text, out string finalText, bool keepCharCount, bool wrapLineColors, bool useEllipsis = false)
	{
		if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 1 || NGUIText.finalLineHeight < 1f)
		{
			finalText = "";
			return false;
		}
		float num = (NGUIText.maxLines > 0) ? Mathf.Min((float)NGUIText.regionHeight, NGUIText.finalLineHeight * (float)NGUIText.maxLines) : ((float)NGUIText.regionHeight);
		int num2 = (NGUIText.maxLines > 0) ? NGUIText.maxLines : 1000000;
		num2 = Mathf.FloorToInt(Mathf.Min((float)num2, num / NGUIText.finalLineHeight) + 0.01f);
		if (num2 == 0)
		{
			finalText = "";
			return false;
		}
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		int length = text.Length;
		NGUIText.Prepare(text);
		if (NGUIText.mSB == null)
		{
			NGUIText.mSB = new StringBuilder();
		}
		else
		{
			NGUIText.mSB.Length = 0;
		}
		float num3 = (float)NGUIText.regionWidth;
		float num4 = 0f;
		int num5 = 0;
		int i = 0;
		int num6 = 1;
		int prev = 0;
		bool flag = true;
		bool flag2 = true;
		bool flag3 = false;
		Color color = NGUIText.tint;
		int num7 = 0;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		float num8 = useEllipsis ? ((NGUIText.finalSpacingX + NGUIText.GetGlyphWidth(46, 46, NGUIText.fontScale)) * 3f) : NGUIText.finalSpacingX;
		int num9 = 0;
		NGUIText.mColors.Add(color);
		if (!NGUIText.useSymbols)
		{
			wrapLineColors = false;
		}
		if (wrapLineColors)
		{
			NGUIText.mSB.Append("[");
			NGUIText.mSB.Append(NGUIText.EncodeColor(color));
			NGUIText.mSB.Append("]");
		}
		while (i < length)
		{
			char c = text[i];
			bool flag9 = NGUIText.IsSpace((int)c);
			if (c > '⿿')
			{
				flag3 = true;
			}
			if (c == '\n')
			{
				if (num6 == num2)
				{
					break;
				}
				num4 = 0f;
				if (num5 < i)
				{
					NGUIText.mSB.Append(text.Substring(num5, i - num5 + 1));
				}
				else
				{
					NGUIText.mSB.Append(c);
				}
				if (wrapLineColors)
				{
					for (int j = 0; j < NGUIText.mColors.size; j++)
					{
						NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
					}
					for (int k = 0; k < NGUIText.mColors.size; k++)
					{
						NGUIText.mSB.Append("[");
						NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[k]));
						NGUIText.mSB.Append("]");
					}
				}
				flag = true;
				num6++;
				num5 = i + 1;
				prev = 0;
			}
			else
			{
				bool flag10 = flag || num6 == num2;
				int num10 = num7;
				if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num7, ref flag4, ref flag5, ref flag6, ref flag7, ref flag8))
				{
					if (num6 == num2 && useEllipsis && num5 < num9)
					{
						if (num9 > num5)
						{
							NGUIText.mSB.Append(text.Substring(num5, num9 - num5 + 1));
						}
						if (num10 != 0)
						{
							NGUIText.mSB.Append("[/sub]");
						}
						NGUIText.mSB.Append("...");
						num5 = i;
						break;
					}
					if (num9 + 1 > i)
					{
						NGUIText.mSB.Append(text.Substring(num5, i - num5));
						num5 = i;
					}
					if (wrapLineColors)
					{
						if (flag8)
						{
							color = NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
							color.a *= NGUIText.mAlpha * NGUIText.tint.a;
						}
						else
						{
							color = NGUIText.tint * NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
							color.a *= NGUIText.mAlpha;
						}
						int l = 0;
						int num11 = NGUIText.mColors.size - 2;
						while (l < num11)
						{
							color.a *= NGUIText.mColors.buffer[l].a;
							l++;
						}
					}
					if (num5 < i)
					{
						NGUIText.mSB.Append(text.Substring(num5, i - num5));
					}
					else
					{
						NGUIText.mSB.Append(c);
					}
					num5 = i--;
					num9 = num5;
				}
				else
				{
					BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
					float num12 = (num7 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
					float num13;
					if (bmsymbol == null)
					{
						float glyphWidth = NGUIText.GetGlyphWidth((int)c, prev, num12);
						if (glyphWidth == 0f && !flag9)
						{
							goto IL_860;
						}
						num13 = NGUIText.finalSpacingX + glyphWidth;
					}
					else
					{
						num13 = NGUIText.finalSpacingX + (float)bmsymbol.advance * num12;
					}
					if (num7 != 0)
					{
						num13 = Mathf.Round(num13);
					}
					num4 += num13;
					prev = (int)c;
					float num14 = (useEllipsis && flag10) ? (num3 - num8) : num3;
					if (flag9 && !flag3 && num5 < i)
					{
						int num15 = i - num5;
						if (num6 == num2 && num4 >= num14 && i < length)
						{
							char c2 = text[i];
							if (c2 < ' ' || NGUIText.IsSpace((int)c2))
							{
								num15--;
							}
						}
						if (flag10 && useEllipsis && num5 < num9 && num4 < num3 && num4 > num14)
						{
							if (num9 > num5)
							{
								NGUIText.mSB.Append(text.Substring(num5, num9 - num5 + 1));
							}
							if (num7 != 0)
							{
								NGUIText.mSB.Append("[/sub]");
							}
							NGUIText.mSB.Append("...");
							num5 = i;
							break;
						}
						NGUIText.mSB.Append(text.Substring(num5, num15 + 1));
						flag = false;
						num5 = i + 1;
					}
					if (useEllipsis && !flag9 && num4 < num14)
					{
						num9 = i;
					}
					if (num4 > num14)
					{
						if (flag10)
						{
							if (useEllipsis && i > 0)
							{
								if (num9 > num5)
								{
									NGUIText.mSB.Append(text.Substring(num5, num9 - num5 + 1));
								}
								if (num7 != 0)
								{
									NGUIText.mSB.Append("[/sub]");
								}
								NGUIText.mSB.Append("...");
								num5 = i;
								break;
							}
							NGUIText.mSB.Append(text.Substring(num5, Mathf.Max(0, i - num5)));
							if (!flag9 && !flag3)
							{
								flag2 = false;
							}
							if (wrapLineColors && NGUIText.mColors.size > 0)
							{
								NGUIText.mSB.Append("[-]");
							}
							if (num6++ == num2)
							{
								num5 = i;
								break;
							}
							if (keepCharCount)
							{
								NGUIText.ReplaceSpaceWithNewline(ref NGUIText.mSB);
							}
							else
							{
								NGUIText.EndLine(ref NGUIText.mSB);
							}
							if (wrapLineColors)
							{
								for (int m = 0; m < NGUIText.mColors.size; m++)
								{
									NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
								}
								for (int n = 0; n < NGUIText.mColors.size; n++)
								{
									NGUIText.mSB.Append("[");
									NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[n]));
									NGUIText.mSB.Append("]");
								}
							}
							flag = true;
							if (flag9)
							{
								num5 = i + 1;
								num4 = 0f;
							}
							else
							{
								num5 = i;
								num4 = num13;
							}
							num9 = i;
							prev = 0;
						}
						else
						{
							while (num5 < length && NGUIText.IsSpace((int)text[num5]))
							{
								num5++;
							}
							flag = true;
							num4 = 0f;
							i = num5 - 1;
							prev = 0;
							if (num6++ == num2)
							{
								break;
							}
							if (keepCharCount)
							{
								NGUIText.ReplaceSpaceWithNewline(ref NGUIText.mSB);
							}
							else
							{
								NGUIText.EndLine(ref NGUIText.mSB);
							}
							if (wrapLineColors)
							{
								for (int num16 = 0; num16 < NGUIText.mColors.size; num16++)
								{
									NGUIText.mSB.Insert(NGUIText.mSB.Length - 1, "[-]");
								}
								for (int num17 = 0; num17 < NGUIText.mColors.size; num17++)
								{
									NGUIText.mSB.Append("[");
									NGUIText.mSB.Append(NGUIText.EncodeColor(NGUIText.mColors.buffer[num17]));
									NGUIText.mSB.Append("]");
								}
								goto IL_860;
							}
							goto IL_860;
						}
					}
					if (bmsymbol != null)
					{
						i += bmsymbol.length - 1;
						prev = 0;
					}
				}
			}
			IL_860:
			i++;
		}
		if (num5 < i)
		{
			NGUIText.mSB.Append(text.Substring(num5, i - num5));
		}
		if (wrapLineColors && NGUIText.mColors.size > 0)
		{
			NGUIText.mSB.Append("[-]");
		}
		finalText = NGUIText.mSB.ToString();
		NGUIText.mColors.Clear();
		if (!flag2)
		{
			return false;
		}
		if (i == length)
		{
			return true;
		}
		if (NGUIText.maxLines == 0)
		{
			return num6 == 0;
		}
		return num6 == num2;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0002697C File Offset: 0x00024B7C
	public static void Print(string text, List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		int count = verts.Count;
		NGUIText.Prepare(text);
		NGUIText.mColors.Add(Color.white);
		NGUIText.mAlpha = 1f;
		int prev = 0;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = (float)NGUIText.finalSize;
		Color a = NGUIText.tint * NGUIText.gradientBottom;
		Color b = NGUIText.tint * NGUIText.gradientTop;
		Color color = NGUIText.tint;
		int length = text.Length;
		Rect rect = default(Rect);
		float num5 = 0f;
		float num6 = 0f;
		float num7 = num4 * NGUIText.pixelDensity;
		float num8 = (float)NGUIText.regionWidth + 0.01f;
		int num9 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		if (NGUIText.bitmapFont != null)
		{
			rect = NGUIText.bitmapFont.uvRect;
			num5 = rect.width / (float)NGUIText.bitmapFont.texWidth;
			num6 = rect.height / (float)NGUIText.bitmapFont.texHeight;
		}
		for (int i = 0; i < length; i++)
		{
			int num10 = (int)text[i];
			float num11 = num;
			if (num10 == 10)
			{
				if (num > num3)
				{
					num3 = num;
				}
				if (NGUIText.alignment != NGUIText.Alignment.Left)
				{
					NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 4);
					count = verts.Count;
				}
				num = 0f;
				num2 += NGUIText.finalLineHeight;
				prev = 0;
			}
			else if (num10 < 32)
			{
				prev = num10;
			}
			else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num9, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
			{
				if (flag5)
				{
					color = NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
					color.a *= NGUIText.mAlpha * NGUIText.tint.a;
				}
				else
				{
					color = NGUIText.tint * NGUIText.mColors.buffer[NGUIText.mColors.size - 1];
					color.a *= NGUIText.mAlpha;
				}
				int j = 0;
				int num12 = NGUIText.mColors.size - 2;
				while (j < num12)
				{
					color.a *= NGUIText.mColors.buffer[j].a;
					j++;
				}
				if (NGUIText.gradient)
				{
					a = NGUIText.gradientBottom * color;
					b = NGUIText.gradientTop * color;
				}
				i--;
			}
			else
			{
				BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
				float num13 = (num9 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
				if (bmsymbol != null)
				{
					float num14 = num + (float)bmsymbol.offsetX * NGUIText.fontScale;
					float num15 = num14 + (float)bmsymbol.width * NGUIText.fontScale;
					float num16 = -(num2 + (float)bmsymbol.offsetY * NGUIText.fontScale);
					float num17 = num16 - (float)bmsymbol.height * NGUIText.fontScale;
					float num18 = (float)bmsymbol.advance * num13;
					if (num + num18 > num8)
					{
						if (num == 0f)
						{
							return;
						}
						if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
						{
							NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 4);
							count = verts.Count;
						}
						num14 -= num;
						num15 -= num;
						num17 -= NGUIText.finalLineHeight;
						num16 -= NGUIText.finalLineHeight;
						num = 0f;
						num2 += NGUIText.finalLineHeight;
					}
					verts.Add(new Vector3(num14, num17));
					verts.Add(new Vector3(num14, num16));
					verts.Add(new Vector3(num15, num16));
					verts.Add(new Vector3(num15, num17));
					num += num18 + NGUIText.finalSpacingX;
					i += bmsymbol.length - 1;
					prev = 0;
					if (uvs != null)
					{
						Rect uvRect = bmsymbol.uvRect;
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
							for (int k = 0; k < 4; k++)
							{
								cols.Add(color);
							}
						}
						else
						{
							Color white = Color.white;
							if (NGUIText.symbolStyle == NGUIText.SymbolStyle.NoOutline)
							{
								white.r = -1f;
								white.a = 0f;
							}
							else
							{
								white.a = color.a;
							}
							for (int l = 0; l < 4; l++)
							{
								cols.Add(white);
							}
						}
					}
				}
				else
				{
					NGUIText.GlyphInfo glyphInfo = NGUIText.GetGlyph(num10, prev, num13);
					if (glyphInfo != null)
					{
						prev = num10;
						float num19 = glyphInfo.advance;
						if (num9 != 0)
						{
							if (num9 == 1)
							{
								float num20 = NGUIText.fontScale * (float)NGUIText.fontSize * 0.4f;
								NGUIText.GlyphInfo glyphInfo2 = glyphInfo;
								glyphInfo2.v0.y = glyphInfo2.v0.y - num20;
								NGUIText.GlyphInfo glyphInfo3 = glyphInfo;
								glyphInfo3.v1.y = glyphInfo3.v1.y - num20;
							}
							else
							{
								float num21 = NGUIText.fontScale * (float)NGUIText.fontSize * 0.05f;
								NGUIText.GlyphInfo glyphInfo4 = glyphInfo;
								glyphInfo4.v0.y = glyphInfo4.v0.y + num21;
								NGUIText.GlyphInfo glyphInfo5 = glyphInfo;
								glyphInfo5.v1.y = glyphInfo5.v1.y + num21;
							}
						}
						num19 += NGUIText.finalSpacingX;
						float num14 = glyphInfo.v0.x + num;
						float num17 = glyphInfo.v0.y - num2;
						float num15 = glyphInfo.v1.x + num;
						float num16 = glyphInfo.v1.y - num2;
						if (num + num19 > num8)
						{
							if (num == 0f)
							{
								return;
							}
							if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
							{
								NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 4);
								count = verts.Count;
							}
							num14 -= num;
							num15 -= num;
							num17 -= NGUIText.finalLineHeight;
							num16 -= NGUIText.finalLineHeight;
							num = 0f;
							num2 += NGUIText.finalLineHeight;
							num11 = 0f;
						}
						if (NGUIText.IsSpace(num10))
						{
							if (flag3)
							{
								num10 = 95;
							}
							else if (flag4)
							{
								num10 = 45;
							}
						}
						num += num19;
						if (num9 != 0)
						{
							num = Mathf.Round(num);
						}
						if (!NGUIText.IsSpace(num10))
						{
							if (uvs != null)
							{
								if (NGUIText.bitmapFont != null)
								{
									glyphInfo.u0.x = rect.xMin + num5 * glyphInfo.u0.x;
									glyphInfo.u2.x = rect.xMin + num5 * glyphInfo.u2.x;
									glyphInfo.u0.y = rect.yMax - num6 * glyphInfo.u0.y;
									glyphInfo.u2.y = rect.yMax - num6 * glyphInfo.u2.y;
									glyphInfo.u1.x = glyphInfo.u0.x;
									glyphInfo.u1.y = glyphInfo.u2.y;
									glyphInfo.u3.x = glyphInfo.u2.x;
									glyphInfo.u3.y = glyphInfo.u0.y;
								}
								int m = 0;
								int num22 = flag ? 4 : 1;
								while (m < num22)
								{
									uvs.Add(glyphInfo.u0);
									uvs.Add(glyphInfo.u1);
									uvs.Add(glyphInfo.u2);
									uvs.Add(glyphInfo.u3);
									m++;
								}
							}
							if (cols != null)
							{
								if (glyphInfo.channel == 0 || glyphInfo.channel == 15)
								{
									if (NGUIText.gradient)
									{
										float num23 = num7 + glyphInfo.v0.y / NGUIText.fontScale;
										float num24 = num7 + glyphInfo.v1.y / NGUIText.fontScale;
										num23 /= num7;
										num24 /= num7;
										NGUIText.s_c0 = Color.Lerp(a, b, num23);
										NGUIText.s_c1 = Color.Lerp(a, b, num24);
										int n = 0;
										int num25 = flag ? 4 : 1;
										while (n < num25)
										{
											cols.Add(NGUIText.s_c0);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c0);
											n++;
										}
									}
									else
									{
										int num26 = 0;
										int num27 = flag ? 16 : 4;
										while (num26 < num27)
										{
											cols.Add(color);
											num26++;
										}
									}
								}
								else
								{
									Color color2 = color;
									color2 *= 0.49f;
									int channel = glyphInfo.channel;
									switch (channel)
									{
									case 1:
										color2.b += 0.51f;
										break;
									case 2:
										color2.g += 0.51f;
										break;
									case 3:
										break;
									case 4:
										color2.r += 0.51f;
										break;
									default:
										if (channel == 8)
										{
											color2.a += 0.51f;
										}
										break;
									}
									int num28 = 0;
									int num29 = flag ? 16 : 4;
									while (num28 < num29)
									{
										cols.Add(color2);
										num28++;
									}
								}
							}
							if (!flag)
							{
								if (!flag2)
								{
									verts.Add(new Vector3(num14, num17));
									verts.Add(new Vector3(num14, num16));
									verts.Add(new Vector3(num15, num16));
									verts.Add(new Vector3(num15, num17));
								}
								else
								{
									float num30 = (float)NGUIText.fontSize * 0.1f * ((num16 - num17) / (float)NGUIText.fontSize);
									verts.Add(new Vector3(num14 - num30, num17));
									verts.Add(new Vector3(num14 + num30, num16));
									verts.Add(new Vector3(num15 + num30, num16));
									verts.Add(new Vector3(num15 - num30, num17));
								}
							}
							else
							{
								for (int num31 = 0; num31 < 4; num31++)
								{
									float num32 = NGUIText.mBoldOffset[num31 * 2];
									float num33 = NGUIText.mBoldOffset[num31 * 2 + 1];
									float num34 = flag2 ? ((float)NGUIText.fontSize * 0.1f * ((num16 - num17) / (float)NGUIText.fontSize)) : 0f;
									verts.Add(new Vector3(num14 + num32 - num34, num17 + num33));
									verts.Add(new Vector3(num14 + num32 + num34, num16 + num33));
									verts.Add(new Vector3(num15 + num32 + num34, num16 + num33));
									verts.Add(new Vector3(num15 + num32 - num34, num17 + num33));
								}
							}
							if (flag3 || flag4)
							{
								NGUIText.GlyphInfo glyphInfo6 = NGUIText.GetGlyph(flag4 ? 45 : 95, prev, num13);
								if (glyphInfo6 != null)
								{
									if (uvs != null)
									{
										if (NGUIText.bitmapFont != null)
										{
											glyphInfo6.u0.x = rect.xMin + num5 * glyphInfo6.u0.x;
											glyphInfo6.u2.x = rect.xMin + num5 * glyphInfo6.u2.x;
											glyphInfo6.u0.y = rect.yMax - num6 * glyphInfo6.u0.y;
											glyphInfo6.u2.y = rect.yMax - num6 * glyphInfo6.u2.y;
										}
										float x = (glyphInfo6.u0.x + glyphInfo6.u2.x) * 0.5f;
										int num35 = 0;
										int num36 = flag ? 4 : 1;
										while (num35 < num36)
										{
											uvs.Add(new Vector2(x, glyphInfo6.u0.y));
											uvs.Add(new Vector2(x, glyphInfo6.u2.y));
											uvs.Add(new Vector2(x, glyphInfo6.u2.y));
											uvs.Add(new Vector2(x, glyphInfo6.u0.y));
											num35++;
										}
									}
									num17 = -num2 + glyphInfo6.v0.y;
									num16 = -num2 + glyphInfo6.v1.y;
									if (flag)
									{
										for (int num37 = 0; num37 < 4; num37++)
										{
											float num38 = NGUIText.mBoldOffset[num37 * 2];
											float num39 = NGUIText.mBoldOffset[num37 * 2 + 1];
											verts.Add(new Vector3(num11 + num38, num17 + num39));
											verts.Add(new Vector3(num11 + num38, num16 + num39));
											verts.Add(new Vector3(num + num38, num16 + num39));
											verts.Add(new Vector3(num + num38, num17 + num39));
										}
									}
									else
									{
										verts.Add(new Vector3(num11, num17));
										verts.Add(new Vector3(num11, num16));
										verts.Add(new Vector3(num, num16));
										verts.Add(new Vector3(num, num17));
									}
									if (NGUIText.gradient)
									{
										float num40 = num7 + glyphInfo6.v0.y / num13;
										float num41 = num7 + glyphInfo6.v1.y / num13;
										num40 /= num7;
										num41 /= num7;
										NGUIText.s_c0 = Color.Lerp(a, b, num40);
										NGUIText.s_c1 = Color.Lerp(a, b, num41);
										int num42 = 0;
										int num43 = flag ? 4 : 1;
										while (num42 < num43)
										{
											cols.Add(NGUIText.s_c0);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c0);
											num42++;
										}
									}
									else
									{
										int num44 = 0;
										int num45 = flag ? 16 : 4;
										while (num44 < num45)
										{
											cols.Add(color);
											num44++;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
		{
			NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 4);
			count = verts.Count;
		}
		NGUIText.mColors.Clear();
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x00027760 File Offset: 0x00025960
	public static void PrintApproximateCharacterPositions(string text, List<Vector3> verts, List<int> indices)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		NGUIText.Prepare(text);
		float num = 0f;
		float num2 = 0f;
		float num3 = (float)NGUIText.regionWidth + 0.01f;
		int length = text.Length;
		int count = verts.Count;
		int prev = 0;
		int num4 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		for (int i = 0; i < length; i++)
		{
			int num5 = (int)text[i];
			float num6 = (num4 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
			float num7 = num6 * 0.5f;
			verts.Add(new Vector3(num, -num2 - num7));
			indices.Add(i);
			if (num5 == 10)
			{
				if (NGUIText.alignment != NGUIText.Alignment.Left)
				{
					NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 1);
					count = verts.Count;
				}
				num = 0f;
				num2 += NGUIText.finalLineHeight;
				prev = 0;
			}
			else if (num5 < 32)
			{
				prev = 0;
			}
			else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num4, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
			{
				i--;
			}
			else
			{
				BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
				if (bmsymbol == null)
				{
					float num8 = NGUIText.GetGlyphWidth(num5, prev, num6);
					if (num8 != 0f)
					{
						num8 += NGUIText.finalSpacingX;
						if (num + num8 > num3)
						{
							if (num == 0f)
							{
								return;
							}
							if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
							{
								NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 1);
								count = verts.Count;
							}
							num = num8;
							num2 += NGUIText.finalLineHeight;
						}
						else
						{
							num += num8;
						}
						verts.Add(new Vector3(num, -num2 - num7));
						indices.Add(i + 1);
						prev = num5;
					}
				}
				else
				{
					float num9 = (float)bmsymbol.advance * num6 + NGUIText.finalSpacingX;
					if (num + num9 > num3)
					{
						if (num == 0f)
						{
							return;
						}
						if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
						{
							NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 1);
							count = verts.Count;
						}
						num = num9;
						num2 += NGUIText.finalLineHeight;
					}
					else
					{
						num += num9;
					}
					verts.Add(new Vector3(num, -num2 - num7));
					indices.Add(i + 1);
					i += bmsymbol.sequence.Length - 1;
					prev = 0;
				}
			}
		}
		if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
		{
			NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 1);
		}
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000279FC File Offset: 0x00025BFC
	public static void PrintExactCharacterPositions(string text, List<Vector3> verts, List<int> indices)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		NGUIText.Prepare(text);
		float num = 0f;
		float num2 = 0f;
		float num3 = (float)NGUIText.regionWidth + 0.01f;
		float num4 = (float)NGUIText.fontSize * NGUIText.fontScale;
		int length = text.Length;
		int count = verts.Count;
		int prev = 0;
		int num5 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		for (int i = 0; i < length; i++)
		{
			int num6 = (int)text[i];
			float num7 = (num5 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
			if (num6 == 10)
			{
				if (NGUIText.alignment != NGUIText.Alignment.Left)
				{
					NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 2);
					count = verts.Count;
				}
				num = 0f;
				num2 += NGUIText.finalLineHeight;
				prev = 0;
			}
			else if (num6 < 32)
			{
				prev = 0;
			}
			else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num5, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
			{
				i--;
			}
			else
			{
				BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
				if (bmsymbol == null)
				{
					float glyphWidth = NGUIText.GetGlyphWidth(num6, prev, num7);
					if (glyphWidth != 0f)
					{
						float num8 = glyphWidth + NGUIText.finalSpacingX;
						if (num + num8 > num3)
						{
							if (num == 0f)
							{
								return;
							}
							if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
							{
								NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 2);
								count = verts.Count;
							}
							num = 0f;
							num2 += NGUIText.finalLineHeight;
							prev = 0;
							i--;
						}
						else
						{
							indices.Add(i);
							verts.Add(new Vector3(num, -num2 - num4));
							verts.Add(new Vector3(num + num8, -num2));
							prev = num6;
							num += num8;
						}
					}
				}
				else
				{
					float num9 = (float)bmsymbol.advance * num7 + NGUIText.finalSpacingX;
					if (num + num9 > num3)
					{
						if (num == 0f)
						{
							return;
						}
						if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
						{
							NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 2);
							count = verts.Count;
						}
						num = 0f;
						num2 += NGUIText.finalLineHeight;
						prev = 0;
						i--;
					}
					else
					{
						indices.Add(i);
						verts.Add(new Vector3(num, -num2 - num4));
						verts.Add(new Vector3(num + num9, -num2));
						i += bmsymbol.sequence.Length - 1;
						num += num9;
						prev = 0;
					}
				}
			}
		}
		if (NGUIText.alignment != NGUIText.Alignment.Left && count < verts.Count)
		{
			NGUIText.Align(verts, count, num - NGUIText.finalSpacingX, 2);
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x00027CBC File Offset: 0x00025EBC
	public static void PrintCaretAndSelection(string text, int start, int end, List<Vector3> caret, List<Vector3> highlight)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		NGUIText.Prepare(text);
		int num = end;
		if (start > end)
		{
			end = start;
			start = num;
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = (float)NGUIText.fontSize * NGUIText.fontScale;
		int indexOffset = (caret != null) ? caret.Count : 0;
		int num5 = (highlight != null) ? highlight.Count : 0;
		int length = text.Length;
		int i = 0;
		int prev = 0;
		bool flag = false;
		bool flag2 = false;
		int num6 = 0;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		Vector2 zero = Vector2.zero;
		Vector2 zero2 = Vector2.zero;
		while (i < length)
		{
			float num7 = (num6 == 0) ? NGUIText.fontScale : (NGUIText.fontScale * 0.75f);
			if (caret != null && !flag2 && num <= i)
			{
				flag2 = true;
				caret.Add(new Vector3(num2 - 1f, -num3 - num4));
				caret.Add(new Vector3(num2 - 1f, -num3));
				caret.Add(new Vector3(num2 + 1f, -num3));
				caret.Add(new Vector3(num2 + 1f, -num3 - num4));
			}
			int num8 = (int)text[i];
			if (num8 == 10)
			{
				if (caret != null && flag2)
				{
					if (NGUIText.alignment != NGUIText.Alignment.Left)
					{
						NGUIText.Align(caret, indexOffset, num2 - NGUIText.finalSpacingX, 4);
					}
					caret = null;
				}
				if (highlight != null)
				{
					if (flag)
					{
						flag = false;
						highlight.Add(zero2);
						highlight.Add(zero);
					}
					else if (start <= i && end > i)
					{
						highlight.Add(new Vector3(num2, -num3 - num4));
						highlight.Add(new Vector3(num2, -num3));
						highlight.Add(new Vector3(num2 + 2f, -num3));
						highlight.Add(new Vector3(num2 + 2f, -num3 - num4));
					}
					if (NGUIText.alignment != NGUIText.Alignment.Left && num5 < highlight.Count)
					{
						NGUIText.Align(highlight, num5, num2 - NGUIText.finalSpacingX, 4);
						num5 = highlight.Count;
					}
				}
				num2 = 0f;
				num3 += NGUIText.finalLineHeight;
				prev = 0;
			}
			else if (num8 < 32)
			{
				prev = 0;
			}
			else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num6, ref flag3, ref flag4, ref flag5, ref flag6, ref flag7))
			{
				i--;
			}
			else
			{
				BMSymbol bmsymbol = NGUIText.useSymbols ? NGUIText.GetSymbol(text, i, length) : null;
				float num9 = (bmsymbol != null) ? ((float)bmsymbol.advance * num7) : NGUIText.GetGlyphWidth(num8, prev, num7);
				if (num9 != 0f)
				{
					float num10 = num2;
					float num11 = num2 + num9;
					float num12 = -num3 - num4;
					float num13 = -num3;
					if (num11 + NGUIText.finalSpacingX > (float)NGUIText.regionWidth)
					{
						if (num2 == 0f)
						{
							return;
						}
						if (caret != null && flag2)
						{
							if (NGUIText.alignment != NGUIText.Alignment.Left)
							{
								NGUIText.Align(caret, indexOffset, num2 - NGUIText.finalSpacingX, 4);
							}
							caret = null;
						}
						if (highlight != null)
						{
							if (flag)
							{
								flag = false;
								highlight.Add(zero2);
								highlight.Add(zero);
							}
							else if (start <= i && end > i)
							{
								highlight.Add(new Vector3(num2, -num3 - num4));
								highlight.Add(new Vector3(num2, -num3));
								highlight.Add(new Vector3(num2 + 2f, -num3));
								highlight.Add(new Vector3(num2 + 2f, -num3 - num4));
							}
							if (NGUIText.alignment != NGUIText.Alignment.Left && num5 < highlight.Count)
							{
								NGUIText.Align(highlight, num5, num2 - NGUIText.finalSpacingX, 4);
								num5 = highlight.Count;
							}
						}
						num10 -= num2;
						num11 -= num2;
						num12 -= NGUIText.finalLineHeight;
						num13 -= NGUIText.finalLineHeight;
						num2 = 0f;
						num3 += NGUIText.finalLineHeight;
					}
					num2 += num9 + NGUIText.finalSpacingX;
					if (highlight != null)
					{
						if (start > i || end <= i)
						{
							if (flag)
							{
								flag = false;
								highlight.Add(zero2);
								highlight.Add(zero);
							}
						}
						else if (!flag)
						{
							flag = true;
							highlight.Add(new Vector3(num10, num12));
							highlight.Add(new Vector3(num10, num13));
						}
					}
					zero = new Vector2(num11, num12);
					zero2 = new Vector2(num11, num13);
					prev = num8;
				}
			}
			i++;
		}
		if (caret != null)
		{
			if (!flag2)
			{
				caret.Add(new Vector3(num2 - 1f, -num3 - num4));
				caret.Add(new Vector3(num2 - 1f, -num3));
				caret.Add(new Vector3(num2 + 1f, -num3));
				caret.Add(new Vector3(num2 + 1f, -num3 - num4));
			}
			if (NGUIText.alignment != NGUIText.Alignment.Left)
			{
				NGUIText.Align(caret, indexOffset, num2 - NGUIText.finalSpacingX, 4);
			}
		}
		if (highlight != null)
		{
			if (flag)
			{
				highlight.Add(zero2);
				highlight.Add(zero);
			}
			else if (start < i && end == i)
			{
				highlight.Add(new Vector3(num2, -num3 - num4));
				highlight.Add(new Vector3(num2, -num3));
				highlight.Add(new Vector3(num2 + 2f, -num3));
				highlight.Add(new Vector3(num2 + 2f, -num3 - num4));
			}
			if (NGUIText.alignment != NGUIText.Alignment.Left && num5 < highlight.Count)
			{
				NGUIText.Align(highlight, num5, num2 - NGUIText.finalSpacingX, 4);
			}
		}
		NGUIText.mColors.Clear();
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x00028234 File Offset: 0x00026434
	public static bool ReplaceLink(ref string text, ref int index, string type, string prefix = null, string suffix = null)
	{
		if (index == -1)
		{
			return false;
		}
		index = text.IndexOf(type, index);
		if (index == -1)
		{
			return false;
		}
		if (index > 5)
		{
			for (int i = index - 5; i >= 0; i--)
			{
				if (text[i] == '[')
				{
					if (text[i + 1] == 'u' && text[i + 2] == 'r' && text[i + 3] == 'l' && text[i + 4] == '=')
					{
						index += type.Length;
						return NGUIText.ReplaceLink(ref text, ref index, type, prefix, suffix);
					}
					if (text[i + 1] == '/' && text[i + 2] == 'u' && text[i + 3] == 'r' && text[i + 4] == 'l')
					{
						break;
					}
				}
			}
		}
		int num = index + type.Length;
		int num2 = text.IndexOfAny(new char[]
		{
			' ',
			'\n',
			'\u200a',
			'​',
			'\u2009'
		}, num);
		if (num2 == -1)
		{
			num2 = text.Length;
		}
		int num3 = text.IndexOfAny(new char[]
		{
			'/',
			' '
		}, num);
		if (num3 == -1 || num3 == num)
		{
			index += type.Length;
			return true;
		}
		string text2 = text.Substring(0, index);
		string text3 = text.Substring(index, num2 - index);
		string text4 = text.Substring(num2);
		string text5 = text.Substring(num, num3 - num);
		if (!string.IsNullOrEmpty(prefix))
		{
			text2 += prefix;
		}
		text = string.Concat(new string[]
		{
			text2,
			"[url=",
			text3,
			"][u]",
			text5,
			"[/u][/url]"
		});
		index = text.Length;
		if (string.IsNullOrEmpty(suffix))
		{
			text += text4;
		}
		else
		{
			text = text + suffix + text4;
		}
		return true;
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0002841C File Offset: 0x0002661C
	public static bool InsertHyperlink(ref string text, ref int index, string keyword, string link, string prefix = null, string suffix = null)
	{
		int num = text.IndexOf(keyword, index, StringComparison.CurrentCultureIgnoreCase);
		if (num == -1)
		{
			return false;
		}
		if (num > 5)
		{
			for (int i = num - 5; i >= 0; i--)
			{
				if (text[i] == '[')
				{
					if (text[i + 1] == 'u' && text[i + 2] == 'r' && text[i + 3] == 'l' && text[i + 4] == '=')
					{
						index = num + keyword.Length;
						return NGUIText.InsertHyperlink(ref text, ref index, keyword, link, prefix, suffix);
					}
					if (text[i + 1] == '/' && text[i + 2] == 'u' && text[i + 3] == 'r' && text[i + 4] == 'l')
					{
						break;
					}
				}
			}
		}
		string str = text.Substring(0, num);
		string str2 = "[url=" + link + "][u]";
		string text2 = text.Substring(num, keyword.Length);
		if (!string.IsNullOrEmpty(prefix))
		{
			text2 = prefix + text2;
		}
		if (!string.IsNullOrEmpty(suffix))
		{
			text2 += suffix;
		}
		string str3 = text.Substring(num + keyword.Length);
		text = str + str2 + text2 + "[/u][/url]";
		index = text.Length;
		text += str3;
		return true;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x00028580 File Offset: 0x00026780
	public static void ReplaceLinks(ref string text, string prefix = null, string suffix = null)
	{
		int num = 0;
		while (num < text.Length && NGUIText.ReplaceLink(ref text, ref num, "http://", prefix, suffix))
		{
		}
		int num2 = 0;
		while (num2 < text.Length && NGUIText.ReplaceLink(ref text, ref num2, "https://", prefix, suffix))
		{
		}
	}

	// Token: 0x040004C3 RID: 1219
	public static INGUIFont bitmapFont;

	// Token: 0x040004C4 RID: 1220
	public static Font dynamicFont;

	// Token: 0x040004C5 RID: 1221
	public static NGUIText.GlyphInfo glyph = new NGUIText.GlyphInfo();

	// Token: 0x040004C6 RID: 1222
	public static int fontSize = 16;

	// Token: 0x040004C7 RID: 1223
	public static float fontScale = 1f;

	// Token: 0x040004C8 RID: 1224
	public static float pixelDensity = 1f;

	// Token: 0x040004C9 RID: 1225
	public static FontStyle fontStyle = FontStyle.Normal;

	// Token: 0x040004CA RID: 1226
	public static NGUIText.Alignment alignment = NGUIText.Alignment.Left;

	// Token: 0x040004CB RID: 1227
	public static Color tint = Color.white;

	// Token: 0x040004CC RID: 1228
	public static int rectWidth = 1000000;

	// Token: 0x040004CD RID: 1229
	public static int rectHeight = 1000000;

	// Token: 0x040004CE RID: 1230
	public static int regionWidth = 1000000;

	// Token: 0x040004CF RID: 1231
	public static int regionHeight = 1000000;

	// Token: 0x040004D0 RID: 1232
	public static int maxLines = 0;

	// Token: 0x040004D1 RID: 1233
	public static bool gradient = false;

	// Token: 0x040004D2 RID: 1234
	public static Color gradientBottom = Color.white;

	// Token: 0x040004D3 RID: 1235
	public static Color gradientTop = Color.white;

	// Token: 0x040004D4 RID: 1236
	public static bool encoding = false;

	// Token: 0x040004D5 RID: 1237
	public static float spacingX = 0f;

	// Token: 0x040004D6 RID: 1238
	public static float spacingY = 0f;

	// Token: 0x040004D7 RID: 1239
	public static bool premultiply = false;

	// Token: 0x040004D8 RID: 1240
	public static NGUIText.SymbolStyle symbolStyle;

	// Token: 0x040004D9 RID: 1241
	public static int finalSize = 0;

	// Token: 0x040004DA RID: 1242
	public static float finalSpacingX = 0f;

	// Token: 0x040004DB RID: 1243
	public static float finalLineHeight = 0f;

	// Token: 0x040004DC RID: 1244
	public static float baseline = 0f;

	// Token: 0x040004DD RID: 1245
	public static bool useSymbols = false;

	// Token: 0x040004DE RID: 1246
	private static Color mInvisible = new Color(0f, 0f, 0f, 0f);

	// Token: 0x040004DF RID: 1247
	private static BetterList<Color> mColors = new BetterList<Color>();

	// Token: 0x040004E0 RID: 1248
	private static float mAlpha = 1f;

	// Token: 0x040004E1 RID: 1249
	private static CharacterInfo mTempChar;

	// Token: 0x040004E2 RID: 1250
	private static BetterList<float> mSizes = new BetterList<float>();

	// Token: 0x040004E3 RID: 1251
	[NonSerialized]
	private static StringBuilder mSB;

	// Token: 0x040004E4 RID: 1252
	private static Color s_c0;

	// Token: 0x040004E5 RID: 1253
	private static Color s_c1;

	// Token: 0x040004E6 RID: 1254
	private const float sizeShrinkage = 0.75f;

	// Token: 0x040004E7 RID: 1255
	private static float[] mBoldOffset = new float[]
	{
		-0.25f,
		0f,
		0.25f,
		0f,
		0f,
		-0.25f,
		0f,
		0.25f
	};

	// Token: 0x020005F3 RID: 1523
	[DoNotObfuscateNGUI]
	public enum Alignment
	{
		// Token: 0x04004E43 RID: 20035
		Automatic,
		// Token: 0x04004E44 RID: 20036
		Left,
		// Token: 0x04004E45 RID: 20037
		Center,
		// Token: 0x04004E46 RID: 20038
		Right,
		// Token: 0x04004E47 RID: 20039
		Justified
	}

	// Token: 0x020005F4 RID: 1524
	[DoNotObfuscateNGUI]
	public enum SymbolStyle
	{
		// Token: 0x04004E49 RID: 20041
		None,
		// Token: 0x04004E4A RID: 20042
		Normal,
		// Token: 0x04004E4B RID: 20043
		Colored,
		// Token: 0x04004E4C RID: 20044
		NoOutline
	}

	// Token: 0x020005F5 RID: 1525
	public class GlyphInfo
	{
		// Token: 0x04004E4D RID: 20045
		public Vector2 v0;

		// Token: 0x04004E4E RID: 20046
		public Vector2 v1;

		// Token: 0x04004E4F RID: 20047
		public Vector2 u0;

		// Token: 0x04004E50 RID: 20048
		public Vector2 u1;

		// Token: 0x04004E51 RID: 20049
		public Vector2 u2;

		// Token: 0x04004E52 RID: 20050
		public Vector2 u3;

		// Token: 0x04004E53 RID: 20051
		public float advance;

		// Token: 0x04004E54 RID: 20052
		public int channel;
	}
}
