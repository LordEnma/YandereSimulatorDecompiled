using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public static class NGUIText
{
	[DoNotObfuscateNGUI]
	public enum Alignment
	{
		Automatic = 0,
		Left = 1,
		Center = 2,
		Right = 3,
		Justified = 4
	}

	[DoNotObfuscateNGUI]
	public enum SymbolStyle
	{
		None = 0,
		Normal = 1,
		Colored = 2,
		NoOutline = 3
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

	public static INGUIFont bitmapFont;

	public static Font dynamicFont;

	public static GlyphInfo glyph = new GlyphInfo();

	public static int fontSize = 16;

	public static float fontScale = 1f;

	public static float pixelDensity = 1f;

	public static FontStyle fontStyle = FontStyle.Normal;

	public static Alignment alignment = Alignment.Left;

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

	public static float spacingX = 0f;

	public static float spacingY = 0f;

	public static bool premultiply = false;

	public static SymbolStyle symbolStyle;

	public static int finalSize = 0;

	public static float finalSpacingX = 0f;

	public static float finalLineHeight = 0f;

	public static float baseline = 0f;

	public static bool useSymbols = false;

	private static Color mInvisible = new Color(0f, 0f, 0f, 0f);

	private static BetterList<Color> mColors = new BetterList<Color>();

	private static float mAlpha = 1f;

	private static CharacterInfo mTempChar;

	private static BetterList<float> mSizes = new BetterList<float>();

	[NonSerialized]
	private static StringBuilder mSB;

	private static Color s_c0;

	private static Color s_c1;

	private const float sizeShrinkage = 0.75f;

	private static float[] mBoldOffset = new float[8] { -0.25f, 0f, 0.25f, 0f, 0f, -0.25f, 0f, 0.25f };

	public static bool isDynamic
	{
		get
		{
			return bitmapFont == null;
		}
	}

	public static void Update()
	{
		Update(true);
	}

	public static void Update(bool request)
	{
		finalSize = Mathf.RoundToInt((float)fontSize / pixelDensity);
		finalSpacingX = spacingX * fontScale;
		finalLineHeight = ((float)fontSize + spacingY) * fontScale;
		useSymbols = (dynamicFont != null || bitmapFont != null) && encoding && symbolStyle != SymbolStyle.None;
		Font font = dynamicFont;
		if (!(font != null && request))
		{
			return;
		}
		font.RequestCharactersInTexture(")_-", finalSize, fontStyle);
		if (!font.GetCharacterInfo(')', out mTempChar, finalSize, fontStyle) || (float)mTempChar.maxY == 0f)
		{
			font.RequestCharactersInTexture("A", finalSize, fontStyle);
			if (!font.GetCharacterInfo('A', out mTempChar, finalSize, fontStyle))
			{
				baseline = 0f;
				return;
			}
		}
		float num = mTempChar.maxY;
		float num2 = mTempChar.minY;
		baseline = Mathf.Round(num + ((float)finalSize - num + num2) * 0.5f);
	}

	public static void Prepare(string text)
	{
		mColors.Clear();
		if (dynamicFont != null)
		{
			dynamicFont.RequestCharactersInTexture(text, finalSize, fontStyle);
		}
	}

	public static BMSymbol GetSymbol(string text, int index, int textLength)
	{
		if (bitmapFont != null)
		{
			return bitmapFont.MatchSymbol(text, index, textLength);
		}
		return null;
	}

	public static float GetGlyphWidth(int ch, int prev, float fontScale)
	{
		if (bitmapFont != null)
		{
			bool flag = false;
			if (ch == 8201)
			{
				flag = true;
				ch = 32;
			}
			BMGlyph bMGlyph = null;
			if (bitmapFont != null)
			{
				bMGlyph = bitmapFont.bmFont.GetGlyph(ch);
			}
			if (bMGlyph != null)
			{
				int num = bMGlyph.advance;
				if (flag)
				{
					num >>= 1;
				}
				return fontScale * (float)((prev != 0) ? (num + bMGlyph.GetKerning(prev)) : bMGlyph.advance);
			}
		}
		else if (dynamicFont != null && dynamicFont.GetCharacterInfo((char)ch, out mTempChar, finalSize, fontStyle))
		{
			return (float)mTempChar.advance * fontScale * pixelDensity;
		}
		return 0f;
	}

	public static GlyphInfo GetGlyph(int ch, int prev, float fontScale = 1f)
	{
		if (bitmapFont != null)
		{
			bool flag = false;
			if (ch == 8201)
			{
				flag = true;
				ch = 32;
			}
			BMGlyph bMGlyph = null;
			if (bitmapFont != null)
			{
				bMGlyph = bitmapFont.bmFont.GetGlyph(ch);
			}
			if (bMGlyph != null)
			{
				int num = ((prev != 0) ? bMGlyph.GetKerning(prev) : 0);
				glyph.v0.x = ((prev != 0) ? (bMGlyph.offsetX + num) : bMGlyph.offsetX);
				glyph.v1.y = -bMGlyph.offsetY;
				glyph.v1.x = glyph.v0.x + (float)bMGlyph.width;
				glyph.v0.y = glyph.v1.y - (float)bMGlyph.height;
				glyph.u0.x = bMGlyph.x;
				glyph.u0.y = bMGlyph.y + bMGlyph.height;
				glyph.u2.x = bMGlyph.x + bMGlyph.width;
				glyph.u2.y = bMGlyph.y;
				glyph.u1.x = glyph.u0.x;
				glyph.u1.y = glyph.u2.y;
				glyph.u3.x = glyph.u2.x;
				glyph.u3.y = glyph.u0.y;
				int num2 = bMGlyph.advance;
				if (flag)
				{
					num2 >>= 1;
				}
				glyph.advance = num2 + num;
				glyph.channel = bMGlyph.channel;
				if (fontScale != 1f)
				{
					glyph.v0 *= fontScale;
					glyph.v1 *= fontScale;
					glyph.advance *= fontScale;
				}
				return glyph;
			}
		}
		else if (dynamicFont != null && dynamicFont.GetCharacterInfo((char)ch, out mTempChar, finalSize, fontStyle))
		{
			glyph.v0.x = mTempChar.minX;
			glyph.v1.x = mTempChar.maxX;
			glyph.v0.y = (float)mTempChar.maxY - baseline;
			glyph.v1.y = (float)mTempChar.minY - baseline;
			glyph.u0 = mTempChar.uvTopLeft;
			glyph.u1 = mTempChar.uvBottomLeft;
			glyph.u2 = mTempChar.uvBottomRight;
			glyph.u3 = mTempChar.uvTopRight;
			glyph.advance = mTempChar.advance;
			glyph.channel = 0;
			glyph.v0.x = Mathf.Round(glyph.v0.x);
			glyph.v0.y = Mathf.Round(glyph.v0.y);
			glyph.v1.x = Mathf.Round(glyph.v1.x);
			glyph.v1.y = Mathf.Round(glyph.v1.y);
			float num3 = fontScale * pixelDensity;
			if (num3 != 1f)
			{
				glyph.v0 *= num3;
				glyph.v1 *= num3;
				glyph.advance *= num3;
			}
			return glyph;
		}
		return null;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static float ParseAlpha(string text, int index)
	{
		return Mathf.Clamp01((float)((NGUIMath.HexToDecimal(text[index + 1]) << 4) | NGUIMath.HexToDecimal(text[index + 2])) / 255f);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor(string text, int offset = 0)
	{
		return ParseColor24(text, offset);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor24(string text, int offset = 0)
	{
		int num = (NGUIMath.HexToDecimal(text[offset]) << 4) | NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = (NGUIMath.HexToDecimal(text[offset + 2]) << 4) | NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = (NGUIMath.HexToDecimal(text[offset + 4]) << 4) | NGUIMath.HexToDecimal(text[offset + 5]);
		float num4 = 0.003921569f;
		return new Color(num4 * (float)num, num4 * (float)num2, num4 * (float)num3);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color ParseColor32(string text, int offset)
	{
		int num = (NGUIMath.HexToDecimal(text[offset]) << 4) | NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = (NGUIMath.HexToDecimal(text[offset + 2]) << 4) | NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = (NGUIMath.HexToDecimal(text[offset + 4]) << 4) | NGUIMath.HexToDecimal(text[offset + 5]);
		int num4 = (NGUIMath.HexToDecimal(text[offset + 6]) << 4) | NGUIMath.HexToDecimal(text[offset + 7]);
		float num5 = 0.003921569f;
		return new Color(num5 * (float)num, num5 * (float)num2, num5 * (float)num3, num5 * (float)num4);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor(Color c)
	{
		return EncodeColor24(c);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor(string text, Color c)
	{
		return "[c][" + EncodeColor24(c) + "]" + text + "[-][/c]";
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeAlpha(float a)
	{
		return NGUIMath.DecimalToHex8(Mathf.Clamp(Mathf.RoundToInt(a * 255f), 0, 255));
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor24(Color c)
	{
		return NGUIMath.DecimalToHex24(0xFFFFFF & (NGUIMath.ColorToInt(c) >> 8));
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string EncodeColor32(Color c)
	{
		return NGUIMath.DecimalToHex32(NGUIMath.ColorToInt(c));
	}

	public static bool ParseSymbol(string text, ref int index)
	{
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		return ParseSymbol(text, ref index, null, false, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool IsHex(char ch)
	{
		if ((ch < '0' || ch > '9') && (ch < 'a' || ch > 'f'))
		{
			if (ch >= 'A')
			{
				return ch <= 'F';
			}
			return false;
		}
		return true;
	}

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
			switch (text.Substring(index, 3))
			{
			case "[b]":
			case "[B]":
				bold = true;
				index += 3;
				return true;
			case "[i]":
			case "[I]":
				italic = true;
				index += 3;
				return true;
			case "[u]":
			case "[U]":
				underline = true;
				index += 3;
				return true;
			case "[s]":
			case "[S]":
				strike = true;
				index += 3;
				return true;
			case "[c]":
			case "[C]":
				ignoreColor = true;
				index += 3;
				return true;
			}
		}
		if (index + 4 > length)
		{
			return false;
		}
		if (text[index + 3] == ']')
		{
			switch (text.Substring(index, 4))
			{
			case "[/b]":
			case "[/B]":
				bold = false;
				index += 4;
				return true;
			case "[/i]":
			case "[/I]":
				italic = false;
				index += 4;
				return true;
			case "[/u]":
			case "[/U]":
				underline = false;
				index += 4;
				return true;
			case "[/s]":
			case "[/S]":
				strike = false;
				index += 4;
				return true;
			case "[/c]":
			case "[/C]":
				ignoreColor = false;
				index += 4;
				return true;
			}
			char ch = text[index + 1];
			char ch2 = text[index + 2];
			if (IsHex(ch) && IsHex(ch2))
			{
				mAlpha = (float)((NGUIMath.HexToDecimal(ch) << 4) | NGUIMath.HexToDecimal(ch2)) / 255f;
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
		{
			return false;
		}
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
		{
			return false;
		}
		if (text[index + 7] == ']')
		{
			Color color = ParseColor24(text, index + 1);
			if (EncodeColor24(color) != text.Substring(index + 1, 6).ToUpper())
			{
				return false;
			}
			if (colors != null && colors.size > 0)
			{
				color.a = colors.buffer[colors.size - 1].a;
				if (premultiply && color.a != 1f)
				{
					color = Color.Lerp(mInvisible, color, color.a);
				}
				colors.Add(color);
			}
			index += 8;
			return true;
		}
		if (index + 10 > length)
		{
			return false;
		}
		if (text[index + 9] == ']')
		{
			Color color2 = ParseColor32(text, index + 1);
			if (EncodeColor32(color2) != text.Substring(index + 1, 8).ToUpper())
			{
				return false;
			}
			if (colors != null)
			{
				if (premultiply && color2.a != 1f)
				{
					color2 = Color.Lerp(mInvisible, color2, color2.a);
				}
				colors.Add(color2);
			}
			index += 10;
			return true;
		}
		return false;
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
					if (ParseSymbol(text, ref index, null, false, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
					{
						text = text.Remove(num, index - num);
						length = text.Length;
						continue;
					}
				}
				num++;
			}
		}
		return text;
	}

	public static void Align(List<Vector3> verts, int indexOffset, float printedWidth, int elements = 4)
	{
		switch (alignment)
		{
		case Alignment.Right:
		{
			float num12 = (float)rectWidth - printedWidth;
			if (!(num12 < 0f))
			{
				int j = indexOffset;
				for (int count3 = verts.Count; j < count3; j++)
				{
					Vector3 value3 = verts[j];
					value3.x += num12;
					verts[j] = value3;
				}
			}
			break;
		}
		case Alignment.Center:
		{
			float num9 = ((float)rectWidth - printedWidth) * 0.5f;
			if (!(num9 < 0f))
			{
				int num10 = Mathf.RoundToInt((float)rectWidth - printedWidth);
				int num11 = Mathf.RoundToInt(rectWidth);
				bool flag = (num10 & 1) == 1;
				bool flag2 = (num11 & 1) == 1;
				if ((flag && !flag2) || (!flag && flag2))
				{
					num9 += 0.5f * fontScale;
				}
				int i = indexOffset;
				for (int count2 = verts.Count; i < count2; i++)
				{
					Vector3 value2 = verts[i];
					value2.x += num9;
					verts[i] = value2;
				}
			}
			break;
		}
		case Alignment.Justified:
		{
			if (printedWidth < (float)rectWidth * 0.65f || ((float)rectWidth - printedWidth) * 0.5f < 1f)
			{
				break;
			}
			int num = (verts.Count - indexOffset) / elements;
			if (num < 1)
			{
				break;
			}
			float num2 = 1f / (float)(num - 1);
			float num3 = (float)rectWidth / printedWidth;
			int num4 = indexOffset + elements;
			int num5 = 1;
			int count = verts.Count;
			while (num4 < count)
			{
				float x = verts[num4].x;
				float x2 = verts[num4 + elements / 2].x;
				float num6 = x2 - x;
				float num7 = x * num3;
				float a = num7 + num6;
				float num8 = x2 * num3;
				float b = num8 - num6;
				float t = (float)num5 * num2;
				x2 = Mathf.Lerp(a, num8, t);
				x = Mathf.Lerp(num7, b, t);
				x = Mathf.Round(x);
				x2 = Mathf.Round(x2);
				switch (elements)
				{
				case 4:
				{
					Vector3 value = verts[num4];
					value.x = x;
					verts[num4++] = value;
					value = verts[num4];
					value.x = x;
					verts[num4++] = value;
					value = verts[num4];
					value.x = x2;
					verts[num4++] = value;
					value = verts[num4];
					value.x = x2;
					verts[num4++] = value;
					break;
				}
				case 2:
				{
					Vector3 value = verts[num4];
					value.x = x;
					verts[num4++] = value;
					value = verts[num4];
					value.x = x2;
					verts[num4++] = value;
					break;
				}
				case 1:
				{
					Vector3 value = verts[num4];
					value.x = x;
					verts[num4++] = value;
					break;
				}
				}
				num5++;
			}
			break;
		}
		}
	}

	public static int GetExactCharacterIndex(List<Vector3> verts, List<int> indices, Vector2 pos)
	{
		int i = 0;
		for (int count = indices.Count; i < count; i++)
		{
			int num = i << 1;
			int index = num + 1;
			float x = verts[num].x;
			if (pos.x < x)
			{
				continue;
			}
			float x2 = verts[index].x;
			if (pos.x > x2)
			{
				continue;
			}
			float y = verts[num].y;
			if (!(pos.y < y))
			{
				float y2 = verts[index].y;
				if (!(pos.y > y2))
				{
					return indices[i];
				}
			}
		}
		return 0;
	}

	public static int GetApproximateCharacterIndex(List<Vector3> verts, List<int> indices, Vector2 pos)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		int index = 0;
		int i = 0;
		for (int count = verts.Count; i < count; i++)
		{
			float num3 = Mathf.Abs(pos.y - verts[i].y);
			if (!(num3 > num2))
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
		}
		return indices[index];
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool IsSpace(int ch)
	{
		if (ch != 32 && ch != 8202 && ch != 8203)
		{
			return ch == 8201;
		}
		return true;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static void EndLine(ref StringBuilder s)
	{
		int num = s.Length - 1;
		if (num > 0 && IsSpace(s[num]))
		{
			s[num] = '\n';
		}
		else
		{
			s.Append('\n');
		}
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	private static void ReplaceSpaceWithNewline(ref StringBuilder s)
	{
		int num = s.Length - 1;
		if (num > 0 && IsSpace(s[num]))
		{
			s[num] = '\n';
		}
	}

	public static Vector2 CalculatePrintedSize(string text)
	{
		Vector2 zero = Vector2.zero;
		if (!string.IsNullOrEmpty(text))
		{
			Prepare(text);
			int num = 0;
			int prev = 0;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = (float)regionWidth + 0.01f;
			int length = text.Length;
			int sub = 0;
			bool bold = false;
			bool italic = false;
			bool underline = false;
			bool strike = false;
			bool ignoreColor = false;
			for (int i = 0; i < length; i++)
			{
				num = text[i];
				if (num == 10)
				{
					if (num2 > num4)
					{
						num4 = num2;
					}
					num2 = 0f;
					num3 += finalLineHeight;
					prev = 0;
					continue;
				}
				if (num < 32)
				{
					prev = num;
					continue;
				}
				if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
				{
					i--;
					continue;
				}
				BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
				float num6 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
				if (bMSymbol != null)
				{
					float num7 = (float)bMSymbol.advance * num6;
					float num8 = num2 + num7;
					if (num8 > num5)
					{
						if (num2 == 0f)
						{
							break;
						}
						if (num2 > num4)
						{
							num4 = num2;
						}
						num2 = 0f;
						num3 += finalLineHeight;
					}
					else if (num8 > num4)
					{
						num4 = num8;
					}
					num2 += num7 + finalSpacingX;
					i += bMSymbol.length - 1;
					prev = 0;
					continue;
				}
				GlyphInfo glyphInfo = GetGlyph(num, prev, num6);
				if (glyphInfo == null)
				{
					continue;
				}
				prev = num;
				float advance = glyphInfo.advance;
				switch (sub)
				{
				case 1:
				{
					float num10 = fontScale * (float)fontSize * 0.4f;
					glyphInfo.v0.y -= num10;
					glyphInfo.v1.y -= num10;
					break;
				}
				default:
				{
					float num9 = fontScale * (float)fontSize * 0.05f;
					glyphInfo.v0.y += num9;
					glyphInfo.v1.y += num9;
					break;
				}
				case 0:
					break;
				}
				advance += finalSpacingX;
				float num11 = num2 + advance;
				if (num11 > num5)
				{
					if (num2 == 0f)
					{
						continue;
					}
					num2 = 0f;
					num3 += finalLineHeight;
				}
				else if (num11 > num4)
				{
					num4 = num11;
				}
				if (IsSpace(num))
				{
					if (underline)
					{
						num = 95;
					}
					else if (strike)
					{
						num = 45;
					}
				}
				num2 = num11;
				if (sub != 0)
				{
					num2 = Mathf.Round(num2);
				}
				IsSpace(num);
			}
			zero.x = Mathf.Ceil((num2 > num4) ? (num2 - finalSpacingX) : num4);
			zero.y = Mathf.Ceil(num3 + finalLineHeight);
		}
		return zero;
	}

	public static int CalculateOffsetToFit(string text)
	{
		if (string.IsNullOrEmpty(text) || regionWidth < 1)
		{
			return 0;
		}
		Prepare(text);
		int length = text.Length;
		int prev = 0;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		int i = 0;
		for (int length2 = text.Length; i < length2; i++)
		{
			float num = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
			if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				i--;
				continue;
			}
			if (bMSymbol == null)
			{
				char num2 = text[i];
				float glyphWidth = GetGlyphWidth(num2, prev, num);
				if (glyphWidth != 0f)
				{
					mSizes.Add(finalSpacingX + glyphWidth);
				}
				prev = num2;
				continue;
			}
			mSizes.Add(finalSpacingX + (float)bMSymbol.advance * num);
			int j = 0;
			for (int num3 = bMSymbol.sequence.Length - 1; j < num3; j++)
			{
				mSizes.Add(0f);
			}
			i += bMSymbol.sequence.Length - 1;
			prev = 0;
		}
		float num4 = regionWidth;
		int num5 = mSizes.size;
		while (num5 > 0 && num4 > 0f)
		{
			num4 -= mSizes.buffer[--num5];
		}
		mSizes.Clear();
		if (num4 < 0f)
		{
			num5++;
		}
		return num5;
	}

	public static string GetEndOfLineThatFits(string text)
	{
		int length = text.Length;
		int num = CalculateOffsetToFit(text);
		return text.Substring(num, length - num);
	}

	public static bool WrapText(string text, out string finalText, bool wrapLineColors = false)
	{
		return WrapText(text, out finalText, false, wrapLineColors);
	}

	public static bool WrapText(string text, out string finalText, bool keepCharCount, bool wrapLineColors, bool useEllipsis = false)
	{
		if (regionWidth < 1 || regionHeight < 1 || finalLineHeight < 1f)
		{
			finalText = "";
			return false;
		}
		float num = ((maxLines > 0) ? Mathf.Min(regionHeight, finalLineHeight * (float)maxLines) : ((float)regionHeight));
		int num2 = ((maxLines > 0) ? maxLines : 1000000);
		num2 = Mathf.FloorToInt(Mathf.Min(num2, num / finalLineHeight) + 0.01f);
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
		Prepare(text);
		if (mSB == null)
		{
			mSB = new StringBuilder();
		}
		else
		{
			mSB.Length = 0;
		}
		float num3 = regionWidth;
		float num4 = 0f;
		int i = 0;
		int j = 0;
		int num5 = 1;
		int prev = 0;
		bool flag = true;
		bool flag2 = true;
		bool flag3 = false;
		Color color = tint;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		float num6 = (useEllipsis ? ((finalSpacingX + GetGlyphWidth(46, 46, fontScale)) * 3f) : finalSpacingX);
		int num7 = 0;
		mColors.Add(color);
		if (!useSymbols)
		{
			wrapLineColors = false;
		}
		if (wrapLineColors)
		{
			mSB.Append("[");
			mSB.Append(EncodeColor(color));
			mSB.Append("]");
		}
		for (; j < length; j++)
		{
			char c = text[j];
			bool flag4 = IsSpace(c);
			if (c > '\u2fff')
			{
				flag3 = true;
			}
			if (c == '\n')
			{
				if (num5 == num2)
				{
					break;
				}
				num4 = 0f;
				if (i < j)
				{
					mSB.Append(text.Substring(i, j - i + 1));
				}
				else
				{
					mSB.Append(c);
				}
				if (wrapLineColors)
				{
					for (int k = 0; k < mColors.size; k++)
					{
						mSB.Insert(mSB.Length - 1, "[-]");
					}
					for (int l = 0; l < mColors.size; l++)
					{
						mSB.Append("[");
						mSB.Append(EncodeColor(mColors.buffer[l]));
						mSB.Append("]");
					}
				}
				flag = true;
				num5++;
				i = j + 1;
				prev = 0;
				continue;
			}
			bool flag5 = flag || num5 == num2;
			int num8 = sub;
			if (encoding && ParseSymbol(text, ref j, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				if (num5 == num2 && useEllipsis && i < num7)
				{
					flag = false;
					if (num7 > i)
					{
						mSB.Append(text.Substring(i, num7 - i + 1));
					}
					if (num8 != 0)
					{
						mSB.Append("[/sub]");
					}
					mSB.Append("...");
					i = j;
					break;
				}
				if (num7 + 1 > j)
				{
					mSB.Append(text.Substring(i, j - i));
					i = j;
					num7 = j;
				}
				if (wrapLineColors)
				{
					if (ignoreColor)
					{
						color = mColors.buffer[mColors.size - 1];
						color.a *= mAlpha * tint.a;
					}
					else
					{
						color = tint * mColors.buffer[mColors.size - 1];
						color.a *= mAlpha;
					}
					int m = 0;
					for (int num9 = mColors.size - 2; m < num9; m++)
					{
						color.a *= mColors.buffer[m].a;
					}
				}
				if (i < j)
				{
					mSB.Append(text.Substring(i, j - i));
				}
				else
				{
					mSB.Append(c);
				}
				i = j--;
				num7 = i;
				continue;
			}
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, j, length) : null);
			float num10 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			float num11;
			if (bMSymbol == null)
			{
				float glyphWidth = GetGlyphWidth(c, prev, num10);
				if (glyphWidth == 0f && !flag4)
				{
					continue;
				}
				num11 = finalSpacingX + glyphWidth;
			}
			else
			{
				num11 = finalSpacingX + (float)bMSymbol.advance * num10;
			}
			if (sub != 0)
			{
				num11 = Mathf.Round(num11);
			}
			num4 += num11;
			prev = c;
			float num12 = ((useEllipsis && flag5) ? (num3 - num6) : num3);
			if (flag4 && !flag3 && i < j)
			{
				int num13 = j - i;
				if (num5 == num2 && num4 >= num12 && j < length)
				{
					char c2 = text[j];
					if (c2 < ' ' || IsSpace(c2))
					{
						num13--;
					}
				}
				if (flag5 && useEllipsis && i < num7 && num4 < num3 && num4 > num12)
				{
					if (num7 > i)
					{
						mSB.Append(text.Substring(i, num7 - i + 1));
					}
					if (sub != 0)
					{
						mSB.Append("[/sub]");
					}
					mSB.Append("...");
					i = j;
					break;
				}
				mSB.Append(text.Substring(i, num13 + 1));
				flag = false;
				i = j + 1;
			}
			if (useEllipsis && !flag4 && num4 < num12)
			{
				num7 = j;
			}
			if (num4 > num12)
			{
				if (!flag5)
				{
					for (; i < length && IsSpace(text[i]); i++)
					{
					}
					flag = true;
					num4 = 0f;
					j = i - 1;
					prev = 0;
					if (num5++ == num2)
					{
						break;
					}
					if (keepCharCount)
					{
						ReplaceSpaceWithNewline(ref mSB);
					}
					else
					{
						EndLine(ref mSB);
					}
					if (wrapLineColors)
					{
						for (int n = 0; n < mColors.size; n++)
						{
							mSB.Insert(mSB.Length - 1, "[-]");
						}
						for (int num14 = 0; num14 < mColors.size; num14++)
						{
							mSB.Append("[");
							mSB.Append(EncodeColor(mColors.buffer[num14]));
							mSB.Append("]");
						}
					}
					continue;
				}
				if (useEllipsis && j > 0)
				{
					if (num7 > i)
					{
						mSB.Append(text.Substring(i, num7 - i + 1));
					}
					if (sub != 0)
					{
						mSB.Append("[/sub]");
					}
					mSB.Append("...");
					i = j;
					break;
				}
				mSB.Append(text.Substring(i, Mathf.Max(0, j - i)));
				if (!flag4 && !flag3)
				{
					flag2 = false;
				}
				if (wrapLineColors && mColors.size > 0)
				{
					mSB.Append("[-]");
				}
				if (num5++ == num2)
				{
					i = j;
					break;
				}
				if (keepCharCount)
				{
					ReplaceSpaceWithNewline(ref mSB);
				}
				else
				{
					EndLine(ref mSB);
				}
				if (wrapLineColors)
				{
					for (int num15 = 0; num15 < mColors.size; num15++)
					{
						mSB.Insert(mSB.Length - 1, "[-]");
					}
					for (int num16 = 0; num16 < mColors.size; num16++)
					{
						mSB.Append("[");
						mSB.Append(EncodeColor(mColors.buffer[num16]));
						mSB.Append("]");
					}
				}
				flag = true;
				if (flag4)
				{
					i = j + 1;
					num4 = 0f;
				}
				else
				{
					i = j;
					num4 = num11;
				}
				num7 = j;
				prev = 0;
			}
			if (bMSymbol != null)
			{
				j += bMSymbol.length - 1;
				prev = 0;
			}
		}
		if (i < j)
		{
			mSB.Append(text.Substring(i, j - i));
		}
		if (wrapLineColors && mColors.size > 0)
		{
			mSB.Append("[-]");
		}
		finalText = mSB.ToString();
		mColors.Clear();
		if (flag2)
		{
			if (j != length)
			{
				if (maxLines == 0)
				{
					return num5 == 0;
				}
				return num5 == num2;
			}
			return true;
		}
		return false;
	}

	public static void Print(string text, List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		int count = verts.Count;
		Prepare(text);
		mColors.Add(Color.white);
		mAlpha = 1f;
		int num = 0;
		int prev = 0;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = finalSize;
		Color a = tint * gradientBottom;
		Color b = tint * gradientTop;
		Color color = tint;
		int length = text.Length;
		Rect rect = default(Rect);
		float num6 = 0f;
		float num7 = 0f;
		float num8 = num5 * pixelDensity;
		float num9 = 0f;
		float num10 = (float)regionWidth + 0.01f;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		if (bitmapFont != null)
		{
			rect = bitmapFont.uvRect;
			num6 = rect.width / (float)bitmapFont.texWidth;
			num7 = rect.height / (float)bitmapFont.texHeight;
		}
		for (int i = 0; i < length; i++)
		{
			num = text[i];
			num9 = num2;
			if (num == 10)
			{
				if (num2 > num4)
				{
					num4 = num2;
				}
				if (alignment != Alignment.Left)
				{
					Align(verts, count, num2 - finalSpacingX);
					count = verts.Count;
				}
				num2 = 0f;
				num3 += finalLineHeight;
				prev = 0;
				continue;
			}
			if (num < 32)
			{
				prev = num;
				continue;
			}
			if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				if (ignoreColor)
				{
					color = mColors.buffer[mColors.size - 1];
					color.a *= mAlpha * tint.a;
				}
				else
				{
					color = tint * mColors.buffer[mColors.size - 1];
					color.a *= mAlpha;
				}
				int j = 0;
				for (int num11 = mColors.size - 2; j < num11; j++)
				{
					color.a *= mColors.buffer[j].a;
				}
				if (gradient)
				{
					a = gradientBottom * color;
					b = gradientTop * color;
				}
				i--;
				continue;
			}
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
			float num12 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			float num13;
			float num14;
			float num16;
			float num15;
			if (bMSymbol != null)
			{
				num13 = num2 + (float)bMSymbol.offsetX * fontScale;
				num14 = num13 + (float)bMSymbol.width * fontScale;
				num15 = 0f - (num3 + (float)bMSymbol.offsetY * fontScale);
				num16 = num15 - (float)bMSymbol.height * fontScale;
				float num17 = (float)bMSymbol.advance * num12;
				if (num2 + num17 > num10)
				{
					if (num2 == 0f)
					{
						return;
					}
					if (alignment != Alignment.Left && count < verts.Count)
					{
						Align(verts, count, num2 - finalSpacingX);
						count = verts.Count;
					}
					num13 -= num2;
					num14 -= num2;
					num16 -= finalLineHeight;
					num15 -= finalLineHeight;
					num2 = 0f;
					num3 += finalLineHeight;
					num9 = 0f;
				}
				verts.Add(new Vector3(num13, num16));
				verts.Add(new Vector3(num13, num15));
				verts.Add(new Vector3(num14, num15));
				verts.Add(new Vector3(num14, num16));
				num2 += num17 + finalSpacingX;
				i += bMSymbol.length - 1;
				prev = 0;
				if (uvs != null)
				{
					Rect uvRect = bMSymbol.uvRect;
					float xMin = uvRect.xMin;
					float yMin = uvRect.yMin;
					float xMax = uvRect.xMax;
					float yMax = uvRect.yMax;
					uvs.Add(new Vector2(xMin, yMin));
					uvs.Add(new Vector2(xMin, yMax));
					uvs.Add(new Vector2(xMax, yMax));
					uvs.Add(new Vector2(xMax, yMin));
				}
				if (cols == null)
				{
					continue;
				}
				if (symbolStyle == SymbolStyle.Colored)
				{
					for (int k = 0; k < 4; k++)
					{
						cols.Add(color);
					}
					continue;
				}
				Color white = Color.white;
				if (symbolStyle == SymbolStyle.NoOutline)
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
				continue;
			}
			GlyphInfo glyphInfo = GetGlyph(num, prev, num12);
			if (glyphInfo == null)
			{
				continue;
			}
			prev = num;
			float advance = glyphInfo.advance;
			switch (sub)
			{
			case 1:
			{
				float num19 = fontScale * (float)fontSize * 0.4f;
				glyphInfo.v0.y -= num19;
				glyphInfo.v1.y -= num19;
				break;
			}
			default:
			{
				float num18 = fontScale * (float)fontSize * 0.05f;
				glyphInfo.v0.y += num18;
				glyphInfo.v1.y += num18;
				break;
			}
			case 0:
				break;
			}
			advance += finalSpacingX;
			num13 = glyphInfo.v0.x + num2;
			num16 = glyphInfo.v0.y - num3;
			num14 = glyphInfo.v1.x + num2;
			num15 = glyphInfo.v1.y - num3;
			if (num2 + advance > num10)
			{
				if (num2 == 0f)
				{
					return;
				}
				if (alignment != Alignment.Left && count < verts.Count)
				{
					Align(verts, count, num2 - finalSpacingX);
					count = verts.Count;
				}
				num13 -= num2;
				num14 -= num2;
				num16 -= finalLineHeight;
				num15 -= finalLineHeight;
				num2 = 0f;
				num3 += finalLineHeight;
				num9 = 0f;
			}
			if (IsSpace(num))
			{
				if (underline)
				{
					num = 95;
				}
				else if (strike)
				{
					num = 45;
				}
			}
			num2 += advance;
			if (sub != 0)
			{
				num2 = Mathf.Round(num2);
			}
			if (IsSpace(num))
			{
				continue;
			}
			if (uvs != null)
			{
				if (bitmapFont != null)
				{
					glyphInfo.u0.x = rect.xMin + num6 * glyphInfo.u0.x;
					glyphInfo.u2.x = rect.xMin + num6 * glyphInfo.u2.x;
					glyphInfo.u0.y = rect.yMax - num7 * glyphInfo.u0.y;
					glyphInfo.u2.y = rect.yMax - num7 * glyphInfo.u2.y;
					glyphInfo.u1.x = glyphInfo.u0.x;
					glyphInfo.u1.y = glyphInfo.u2.y;
					glyphInfo.u3.x = glyphInfo.u2.x;
					glyphInfo.u3.y = glyphInfo.u0.y;
				}
				int m = 0;
				for (int num20 = ((!bold) ? 1 : 4); m < num20; m++)
				{
					uvs.Add(glyphInfo.u0);
					uvs.Add(glyphInfo.u1);
					uvs.Add(glyphInfo.u2);
					uvs.Add(glyphInfo.u3);
				}
			}
			if (cols != null)
			{
				if (glyphInfo.channel == 0 || glyphInfo.channel == 15)
				{
					if (gradient)
					{
						float num21 = num8 + glyphInfo.v0.y / fontScale;
						float num22 = num8 + glyphInfo.v1.y / fontScale;
						num21 /= num8;
						num22 /= num8;
						s_c0 = Color.Lerp(a, b, num21);
						s_c1 = Color.Lerp(a, b, num22);
						int n = 0;
						for (int num23 = ((!bold) ? 1 : 4); n < num23; n++)
						{
							cols.Add(s_c0);
							cols.Add(s_c1);
							cols.Add(s_c1);
							cols.Add(s_c0);
						}
					}
					else
					{
						int num24 = 0;
						for (int num25 = (bold ? 16 : 4); num24 < num25; num24++)
						{
							cols.Add(color);
						}
					}
				}
				else
				{
					Color item = color;
					item *= 0.49f;
					switch (glyphInfo.channel)
					{
					case 1:
						item.b += 0.51f;
						break;
					case 2:
						item.g += 0.51f;
						break;
					case 4:
						item.r += 0.51f;
						break;
					case 8:
						item.a += 0.51f;
						break;
					}
					int num26 = 0;
					for (int num27 = (bold ? 16 : 4); num26 < num27; num26++)
					{
						cols.Add(item);
					}
				}
			}
			if (!bold)
			{
				if (!italic)
				{
					verts.Add(new Vector3(num13, num16));
					verts.Add(new Vector3(num13, num15));
					verts.Add(new Vector3(num14, num15));
					verts.Add(new Vector3(num14, num16));
				}
				else
				{
					float num28 = (float)fontSize * 0.1f * ((num15 - num16) / (float)fontSize);
					verts.Add(new Vector3(num13 - num28, num16));
					verts.Add(new Vector3(num13 + num28, num15));
					verts.Add(new Vector3(num14 + num28, num15));
					verts.Add(new Vector3(num14 - num28, num16));
				}
			}
			else
			{
				for (int num29 = 0; num29 < 4; num29++)
				{
					float num30 = mBoldOffset[num29 * 2];
					float num31 = mBoldOffset[num29 * 2 + 1];
					float num32 = (italic ? ((float)fontSize * 0.1f * ((num15 - num16) / (float)fontSize)) : 0f);
					verts.Add(new Vector3(num13 + num30 - num32, num16 + num31));
					verts.Add(new Vector3(num13 + num30 + num32, num15 + num31));
					verts.Add(new Vector3(num14 + num30 + num32, num15 + num31));
					verts.Add(new Vector3(num14 + num30 - num32, num16 + num31));
				}
			}
			if (!(underline || strike))
			{
				continue;
			}
			GlyphInfo glyphInfo2 = GetGlyph(strike ? 45 : 95, prev, num12);
			if (glyphInfo2 == null)
			{
				continue;
			}
			if (uvs != null)
			{
				if (bitmapFont != null)
				{
					glyphInfo2.u0.x = rect.xMin + num6 * glyphInfo2.u0.x;
					glyphInfo2.u2.x = rect.xMin + num6 * glyphInfo2.u2.x;
					glyphInfo2.u0.y = rect.yMax - num7 * glyphInfo2.u0.y;
					glyphInfo2.u2.y = rect.yMax - num7 * glyphInfo2.u2.y;
				}
				float x = (glyphInfo2.u0.x + glyphInfo2.u2.x) * 0.5f;
				int num33 = 0;
				for (int num34 = ((!bold) ? 1 : 4); num33 < num34; num33++)
				{
					uvs.Add(new Vector2(x, glyphInfo2.u0.y));
					uvs.Add(new Vector2(x, glyphInfo2.u2.y));
					uvs.Add(new Vector2(x, glyphInfo2.u2.y));
					uvs.Add(new Vector2(x, glyphInfo2.u0.y));
				}
			}
			num16 = 0f - num3 + glyphInfo2.v0.y;
			num15 = 0f - num3 + glyphInfo2.v1.y;
			if (bold)
			{
				for (int num35 = 0; num35 < 4; num35++)
				{
					float num36 = mBoldOffset[num35 * 2];
					float num37 = mBoldOffset[num35 * 2 + 1];
					verts.Add(new Vector3(num9 + num36, num16 + num37));
					verts.Add(new Vector3(num9 + num36, num15 + num37));
					verts.Add(new Vector3(num2 + num36, num15 + num37));
					verts.Add(new Vector3(num2 + num36, num16 + num37));
				}
			}
			else
			{
				verts.Add(new Vector3(num9, num16));
				verts.Add(new Vector3(num9, num15));
				verts.Add(new Vector3(num2, num15));
				verts.Add(new Vector3(num2, num16));
			}
			if (gradient)
			{
				float num38 = num8 + glyphInfo2.v0.y / num12;
				float num39 = num8 + glyphInfo2.v1.y / num12;
				num38 /= num8;
				num39 /= num8;
				s_c0 = Color.Lerp(a, b, num38);
				s_c1 = Color.Lerp(a, b, num39);
				int num40 = 0;
				for (int num41 = ((!bold) ? 1 : 4); num40 < num41; num40++)
				{
					cols.Add(s_c0);
					cols.Add(s_c1);
					cols.Add(s_c1);
					cols.Add(s_c0);
				}
			}
			else
			{
				int num42 = 0;
				for (int num43 = (bold ? 16 : 4); num42 < num43; num42++)
				{
					cols.Add(color);
				}
			}
		}
		if (alignment != Alignment.Left && count < verts.Count)
		{
			Align(verts, count, num2 - finalSpacingX);
			count = verts.Count;
		}
		mColors.Clear();
	}

	public static void PrintApproximateCharacterPositions(string text, List<Vector3> verts, List<int> indices)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		Prepare(text);
		float num = 0f;
		float num2 = 0f;
		float num3 = (float)regionWidth + 0.01f;
		int length = text.Length;
		int count = verts.Count;
		int num4 = 0;
		int prev = 0;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		for (int i = 0; i < length; i++)
		{
			num4 = text[i];
			float num5 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			float num6 = num5 * 0.5f;
			verts.Add(new Vector3(num, 0f - num2 - num6));
			indices.Add(i);
			if (num4 == 10)
			{
				if (alignment != Alignment.Left)
				{
					Align(verts, count, num - finalSpacingX, 1);
					count = verts.Count;
				}
				num = 0f;
				num2 += finalLineHeight;
				prev = 0;
				continue;
			}
			if (num4 < 32)
			{
				prev = 0;
				continue;
			}
			if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				i--;
				continue;
			}
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
			if (bMSymbol == null)
			{
				float glyphWidth = GetGlyphWidth(num4, prev, num5);
				if (glyphWidth == 0f)
				{
					continue;
				}
				glyphWidth += finalSpacingX;
				if (num + glyphWidth > num3)
				{
					if (num == 0f)
					{
						return;
					}
					if (alignment != Alignment.Left && count < verts.Count)
					{
						Align(verts, count, num - finalSpacingX, 1);
						count = verts.Count;
					}
					num = glyphWidth;
					num2 += finalLineHeight;
				}
				else
				{
					num += glyphWidth;
				}
				verts.Add(new Vector3(num, 0f - num2 - num6));
				indices.Add(i + 1);
				prev = num4;
				continue;
			}
			float num7 = (float)bMSymbol.advance * num5 + finalSpacingX;
			if (num + num7 > num3)
			{
				if (num == 0f)
				{
					return;
				}
				if (alignment != Alignment.Left && count < verts.Count)
				{
					Align(verts, count, num - finalSpacingX, 1);
					count = verts.Count;
				}
				num = num7;
				num2 += finalLineHeight;
			}
			else
			{
				num += num7;
			}
			verts.Add(new Vector3(num, 0f - num2 - num6));
			indices.Add(i + 1);
			i += bMSymbol.sequence.Length - 1;
			prev = 0;
		}
		if (alignment != Alignment.Left && count < verts.Count)
		{
			Align(verts, count, num - finalSpacingX, 1);
		}
	}

	public static void PrintExactCharacterPositions(string text, List<Vector3> verts, List<int> indices)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		Prepare(text);
		float num = 0f;
		float num2 = 0f;
		float num3 = (float)regionWidth + 0.01f;
		float num4 = (float)fontSize * fontScale;
		int length = text.Length;
		int count = verts.Count;
		int num5 = 0;
		int prev = 0;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		for (int i = 0; i < length; i++)
		{
			num5 = text[i];
			float num6 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			if (num5 == 10)
			{
				if (alignment != Alignment.Left)
				{
					Align(verts, count, num - finalSpacingX, 2);
					count = verts.Count;
				}
				num = 0f;
				num2 += finalLineHeight;
				prev = 0;
				continue;
			}
			if (num5 < 32)
			{
				prev = 0;
				continue;
			}
			if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				i--;
				continue;
			}
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
			if (bMSymbol == null)
			{
				float glyphWidth = GetGlyphWidth(num5, prev, num6);
				if (glyphWidth == 0f)
				{
					continue;
				}
				float num7 = glyphWidth + finalSpacingX;
				if (num + num7 > num3)
				{
					if (num == 0f)
					{
						return;
					}
					if (alignment != Alignment.Left && count < verts.Count)
					{
						Align(verts, count, num - finalSpacingX, 2);
						count = verts.Count;
					}
					num = 0f;
					num2 += finalLineHeight;
					prev = 0;
					i--;
				}
				else
				{
					indices.Add(i);
					verts.Add(new Vector3(num, 0f - num2 - num4));
					verts.Add(new Vector3(num + num7, 0f - num2));
					prev = num5;
					num += num7;
				}
				continue;
			}
			float num8 = (float)bMSymbol.advance * num6 + finalSpacingX;
			if (num + num8 > num3)
			{
				if (num == 0f)
				{
					return;
				}
				if (alignment != Alignment.Left && count < verts.Count)
				{
					Align(verts, count, num - finalSpacingX, 2);
					count = verts.Count;
				}
				num = 0f;
				num2 += finalLineHeight;
				prev = 0;
				i--;
			}
			else
			{
				indices.Add(i);
				verts.Add(new Vector3(num, 0f - num2 - num4));
				verts.Add(new Vector3(num + num8, 0f - num2));
				i += bMSymbol.sequence.Length - 1;
				num += num8;
				prev = 0;
			}
		}
		if (alignment != Alignment.Left && count < verts.Count)
		{
			Align(verts, count, num - finalSpacingX, 2);
		}
	}

	public static void PrintCaretAndSelection(string text, int start, int end, List<Vector3> caret, List<Vector3> highlight)
	{
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		Prepare(text);
		int num = end;
		if (start > end)
		{
			end = start;
			start = num;
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = (float)fontSize * fontScale;
		int indexOffset = ((caret != null) ? caret.Count : 0);
		int num5 = ((highlight != null) ? highlight.Count : 0);
		int length = text.Length;
		int i = 0;
		int num6 = 0;
		int prev = 0;
		bool flag = false;
		bool flag2 = false;
		int sub = 0;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		bool strike = false;
		bool ignoreColor = false;
		Vector2 vector = Vector2.zero;
		Vector2 vector2 = Vector2.zero;
		for (; i < length; i++)
		{
			float num7 = ((sub == 0) ? fontScale : (fontScale * 0.75f));
			if (caret != null && !flag2 && num <= i)
			{
				flag2 = true;
				caret.Add(new Vector3(num2 - 1f, 0f - num3 - num4));
				caret.Add(new Vector3(num2 - 1f, 0f - num3));
				caret.Add(new Vector3(num2 + 1f, 0f - num3));
				caret.Add(new Vector3(num2 + 1f, 0f - num3 - num4));
			}
			num6 = text[i];
			if (num6 == 10)
			{
				if (caret != null && flag2)
				{
					if (alignment != Alignment.Left)
					{
						Align(caret, indexOffset, num2 - finalSpacingX);
					}
					caret = null;
				}
				if (highlight != null)
				{
					if (flag)
					{
						flag = false;
						highlight.Add(vector2);
						highlight.Add(vector);
					}
					else if (start <= i && end > i)
					{
						highlight.Add(new Vector3(num2, 0f - num3 - num4));
						highlight.Add(new Vector3(num2, 0f - num3));
						highlight.Add(new Vector3(num2 + 2f, 0f - num3));
						highlight.Add(new Vector3(num2 + 2f, 0f - num3 - num4));
					}
					if (alignment != Alignment.Left && num5 < highlight.Count)
					{
						Align(highlight, num5, num2 - finalSpacingX);
						num5 = highlight.Count;
					}
				}
				num2 = 0f;
				num3 += finalLineHeight;
				prev = 0;
				continue;
			}
			if (num6 < 32)
			{
				prev = 0;
				continue;
			}
			if (encoding && ParseSymbol(text, ref i, mColors, premultiply, ref sub, ref bold, ref italic, ref underline, ref strike, ref ignoreColor))
			{
				i--;
				continue;
			}
			BMSymbol bMSymbol = (useSymbols ? GetSymbol(text, i, length) : null);
			float num8 = ((bMSymbol != null) ? ((float)bMSymbol.advance * num7) : GetGlyphWidth(num6, prev, num7));
			if (num8 == 0f)
			{
				continue;
			}
			float num9 = num2;
			float num10 = num2 + num8;
			float num11 = 0f - num3 - num4;
			float num12 = 0f - num3;
			if (num10 + finalSpacingX > (float)regionWidth)
			{
				if (num2 == 0f)
				{
					return;
				}
				if (caret != null && flag2)
				{
					if (alignment != Alignment.Left)
					{
						Align(caret, indexOffset, num2 - finalSpacingX);
					}
					caret = null;
				}
				if (highlight != null)
				{
					if (flag)
					{
						flag = false;
						highlight.Add(vector2);
						highlight.Add(vector);
					}
					else if (start <= i && end > i)
					{
						highlight.Add(new Vector3(num2, 0f - num3 - num4));
						highlight.Add(new Vector3(num2, 0f - num3));
						highlight.Add(new Vector3(num2 + 2f, 0f - num3));
						highlight.Add(new Vector3(num2 + 2f, 0f - num3 - num4));
					}
					if (alignment != Alignment.Left && num5 < highlight.Count)
					{
						Align(highlight, num5, num2 - finalSpacingX);
						num5 = highlight.Count;
					}
				}
				num9 -= num2;
				num10 -= num2;
				num11 -= finalLineHeight;
				num12 -= finalLineHeight;
				num2 = 0f;
				num3 += finalLineHeight;
			}
			num2 += num8 + finalSpacingX;
			if (highlight != null)
			{
				if (start > i || end <= i)
				{
					if (flag)
					{
						flag = false;
						highlight.Add(vector2);
						highlight.Add(vector);
					}
				}
				else if (!flag)
				{
					flag = true;
					highlight.Add(new Vector3(num9, num11));
					highlight.Add(new Vector3(num9, num12));
				}
			}
			vector = new Vector2(num10, num11);
			vector2 = new Vector2(num10, num12);
			prev = num6;
		}
		if (caret != null)
		{
			if (!flag2)
			{
				caret.Add(new Vector3(num2 - 1f, 0f - num3 - num4));
				caret.Add(new Vector3(num2 - 1f, 0f - num3));
				caret.Add(new Vector3(num2 + 1f, 0f - num3));
				caret.Add(new Vector3(num2 + 1f, 0f - num3 - num4));
			}
			if (alignment != Alignment.Left)
			{
				Align(caret, indexOffset, num2 - finalSpacingX);
			}
		}
		if (highlight != null)
		{
			if (flag)
			{
				highlight.Add(vector2);
				highlight.Add(vector);
			}
			else if (start < i && end == i)
			{
				highlight.Add(new Vector3(num2, 0f - num3 - num4));
				highlight.Add(new Vector3(num2, 0f - num3));
				highlight.Add(new Vector3(num2 + 2f, 0f - num3));
				highlight.Add(new Vector3(num2 + 2f, 0f - num3 - num4));
			}
			if (alignment != Alignment.Left && num5 < highlight.Count)
			{
				Align(highlight, num5, num2 - finalSpacingX);
			}
		}
		mColors.Clear();
	}

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
			for (int num = index - 5; num >= 0; num--)
			{
				if (text[num] == '[')
				{
					if (text[num + 1] == 'u' && text[num + 2] == 'r' && text[num + 3] == 'l' && text[num + 4] == '=')
					{
						index += type.Length;
						return ReplaceLink(ref text, ref index, type, prefix, suffix);
					}
					if (text[num + 1] == '/' && text[num + 2] == 'u' && text[num + 3] == 'r' && text[num + 4] == 'l')
					{
						break;
					}
				}
			}
		}
		int num2 = index + type.Length;
		int num3 = text.IndexOfAny(new char[5] { ' ', '\n', '\u200a', '\u200b', '\u2009' }, num2);
		if (num3 == -1)
		{
			num3 = text.Length;
		}
		int num4 = text.IndexOfAny(new char[2] { '/', ' ' }, num2);
		if (num4 == -1 || num4 == num2)
		{
			index += type.Length;
			return true;
		}
		string text2 = text.Substring(0, index);
		string text3 = text.Substring(index, num3 - index);
		string text4 = text.Substring(num3);
		string text5 = text.Substring(num2, num4 - num2);
		if (!string.IsNullOrEmpty(prefix))
		{
			text2 += prefix;
		}
		text = text2 + "[url=" + text3 + "][u]" + text5 + "[/u][/url]";
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

	public static bool InsertHyperlink(ref string text, ref int index, string keyword, string link, string prefix = null, string suffix = null)
	{
		int num = text.IndexOf(keyword, index, StringComparison.CurrentCultureIgnoreCase);
		if (num == -1)
		{
			return false;
		}
		if (num > 5)
		{
			for (int num2 = num - 5; num2 >= 0; num2--)
			{
				if (text[num2] == '[')
				{
					if (text[num2 + 1] == 'u' && text[num2 + 2] == 'r' && text[num2 + 3] == 'l' && text[num2 + 4] == '=')
					{
						index = num + keyword.Length;
						return InsertHyperlink(ref text, ref index, keyword, link, prefix, suffix);
					}
					if (text[num2 + 1] == '/' && text[num2 + 2] == 'u' && text[num2 + 3] == 'r' && text[num2 + 4] == 'l')
					{
						break;
					}
				}
			}
		}
		string text2 = text.Substring(0, num);
		string text3 = "[url=" + link + "][u]";
		string text4 = text.Substring(num, keyword.Length);
		if (!string.IsNullOrEmpty(prefix))
		{
			text4 = prefix + text4;
		}
		if (!string.IsNullOrEmpty(suffix))
		{
			text4 += suffix;
		}
		string text5 = text.Substring(num + keyword.Length);
		text = text2 + text3 + text4 + "[/u][/url]";
		index = text.Length;
		text += text5;
		return true;
	}

	public static void ReplaceLinks(ref string text, string prefix = null, string suffix = null)
	{
		int index = 0;
		while (index < text.Length && ReplaceLink(ref text, ref index, "http://", prefix, suffix))
		{
		}
		int index2 = 0;
		while (index2 < text.Length && ReplaceLink(ref text, ref index2, "https://", prefix, suffix))
		{
		}
	}
}
