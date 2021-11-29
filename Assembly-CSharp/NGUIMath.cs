using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000076 RID: 118
public static class NGUIMath
{
	// Token: 0x0600037F RID: 895 RVA: 0x00022B46 File Offset: 0x00020D46
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static float Lerp(float from, float to, float factor)
	{
		return from * (1f - factor) + to * factor;
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00022B55 File Offset: 0x00020D55
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int ClampIndex(int val, int max)
	{
		if (val < 0)
		{
			return 0;
		}
		if (val >= max)
		{
			return max - 1;
		}
		return val;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00022B66 File Offset: 0x00020D66
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int RepeatIndex(int val, int max)
	{
		if (max < 1)
		{
			return 0;
		}
		while (val < 0)
		{
			val += max;
		}
		while (val >= max)
		{
			val -= max;
		}
		return val;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00022B83 File Offset: 0x00020D83
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static float WrapAngle(float angle)
	{
		while (angle > 180f)
		{
			angle -= 360f;
		}
		while (angle < -180f)
		{
			angle += 360f;
		}
		return angle;
	}

	// Token: 0x06000383 RID: 899 RVA: 0x00022BAC File Offset: 0x00020DAC
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static float Wrap01(float val)
	{
		return val - (float)Mathf.FloorToInt(val);
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00022BB8 File Offset: 0x00020DB8
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int HexToDecimal(char ch)
	{
		switch (ch)
		{
		case '0':
			return 0;
		case '1':
			return 1;
		case '2':
			return 2;
		case '3':
			return 3;
		case '4':
			return 4;
		case '5':
			return 5;
		case '6':
			return 6;
		case '7':
			return 7;
		case '8':
			return 8;
		case '9':
			return 9;
		case ':':
		case ';':
		case '<':
		case '=':
		case '>':
		case '?':
		case '@':
			return 15;
		case 'A':
			break;
		case 'B':
			return 11;
		case 'C':
			return 12;
		case 'D':
			return 13;
		case 'E':
			return 14;
		case 'F':
			return 15;
		default:
			switch (ch)
			{
			case 'a':
				break;
			case 'b':
				return 11;
			case 'c':
				return 12;
			case 'd':
				return 13;
			case 'e':
				return 14;
			case 'f':
				return 15;
			default:
				return 15;
			}
			break;
		}
		return 10;
	}

	// Token: 0x06000385 RID: 901 RVA: 0x00022C76 File Offset: 0x00020E76
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static char DecimalToHexChar(int num)
	{
		if (num > 15)
		{
			return 'F';
		}
		if (num < 10)
		{
			return (char)(48 + num);
		}
		return (char)(65 + num - 10);
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00022C93 File Offset: 0x00020E93
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string DecimalToHex8(int num)
	{
		num &= 255;
		return num.ToString("X2");
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00022CAA File Offset: 0x00020EAA
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string DecimalToHex24(int num)
	{
		num &= 16777215;
		return num.ToString("X6");
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00022CC1 File Offset: 0x00020EC1
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string DecimalToHex32(int num)
	{
		return num.ToString("X8");
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00022CD0 File Offset: 0x00020ED0
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int ColorToInt(Color c)
	{
		return 0 | Mathf.RoundToInt(c.r * 255f) << 24 | Mathf.RoundToInt(c.g * 255f) << 16 | Mathf.RoundToInt(c.b * 255f) << 8 | Mathf.RoundToInt(c.a * 255f);
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00022D30 File Offset: 0x00020F30
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color IntToColor(int val)
	{
		float num = 0.003921569f;
		Color black = Color.black;
		black.r = num * (float)(val >> 24 & 255);
		black.g = num * (float)(val >> 16 & 255);
		black.b = num * (float)(val >> 8 & 255);
		black.a = num * (float)(val & 255);
		return black;
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00022D98 File Offset: 0x00020F98
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static string IntToBinary(int val, int bits)
	{
		string text = "";
		int i = bits;
		while (i > 0)
		{
			if (i == 8 || i == 16 || i == 24)
			{
				text += " ";
			}
			text += (((val & 1 << --i) != 0) ? '1' : '0').ToString();
		}
		return text;
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00022DF1 File Offset: 0x00020FF1
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static Color HexToColor(uint val)
	{
		return NGUIMath.IntToColor((int)val);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00022DFC File Offset: 0x00020FFC
	public static Rect ConvertToTexCoords(Rect rect, int width, int height)
	{
		Rect result = rect;
		if ((float)width != 0f && (float)height != 0f)
		{
			result.xMin = rect.xMin / (float)width;
			result.xMax = rect.xMax / (float)width;
			result.yMin = 1f - rect.yMax / (float)height;
			result.yMax = 1f - rect.yMin / (float)height;
		}
		return result;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00022E70 File Offset: 0x00021070
	public static Rect ConvertToPixels(Rect rect, int width, int height, bool round)
	{
		Rect result = rect;
		if (round)
		{
			result.xMin = (float)Mathf.RoundToInt(rect.xMin * (float)width);
			result.xMax = (float)Mathf.RoundToInt(rect.xMax * (float)width);
			result.yMin = (float)Mathf.RoundToInt((1f - rect.yMax) * (float)height);
			result.yMax = (float)Mathf.RoundToInt((1f - rect.yMin) * (float)height);
		}
		else
		{
			result.xMin = rect.xMin * (float)width;
			result.xMax = rect.xMax * (float)width;
			result.yMin = (1f - rect.yMax) * (float)height;
			result.yMax = (1f - rect.yMin) * (float)height;
		}
		return result;
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00022F40 File Offset: 0x00021140
	public static Rect MakePixelPerfect(Rect rect)
	{
		rect.xMin = (float)Mathf.RoundToInt(rect.xMin);
		rect.yMin = (float)Mathf.RoundToInt(rect.yMin);
		rect.xMax = (float)Mathf.RoundToInt(rect.xMax);
		rect.yMax = (float)Mathf.RoundToInt(rect.yMax);
		return rect;
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00022FA0 File Offset: 0x000211A0
	public static Rect MakePixelPerfect(Rect rect, int width, int height)
	{
		rect = NGUIMath.ConvertToPixels(rect, width, height, true);
		rect.xMin = (float)Mathf.RoundToInt(rect.xMin);
		rect.yMin = (float)Mathf.RoundToInt(rect.yMin);
		rect.xMax = (float)Mathf.RoundToInt(rect.xMax);
		rect.yMax = (float)Mathf.RoundToInt(rect.yMax);
		return NGUIMath.ConvertToTexCoords(rect, width, height);
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00023010 File Offset: 0x00021210
	public static Vector2 ConstrainRect(Vector2 minRect, Vector2 maxRect, Vector2 minArea, Vector2 maxArea)
	{
		Vector2 zero = Vector2.zero;
		float num = maxRect.x - minRect.x;
		float num2 = maxRect.y - minRect.y;
		float num3 = maxArea.x - minArea.x;
		float num4 = maxArea.y - minArea.y;
		if (num > num3)
		{
			float num5 = num - num3;
			minArea.x -= num5;
			maxArea.x += num5;
		}
		if (num2 > num4)
		{
			float num6 = num2 - num4;
			minArea.y -= num6;
			maxArea.y += num6;
		}
		if (minRect.x < minArea.x)
		{
			zero.x += minArea.x - minRect.x;
		}
		if (maxRect.x > maxArea.x)
		{
			zero.x -= maxRect.x - maxArea.x;
		}
		if (minRect.y < minArea.y)
		{
			zero.y += minArea.y - minRect.y;
		}
		if (maxRect.y > maxArea.y)
		{
			zero.y -= maxRect.y - maxArea.y;
		}
		return zero;
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00023140 File Offset: 0x00021340
	public static Bounds CalculateAbsoluteWidgetBounds(Transform trans)
	{
		if (!(trans != null))
		{
			return new Bounds(Vector3.zero, Vector3.zero);
		}
		UIWidget[] componentsInChildren = trans.GetComponentsInChildren<UIWidget>();
		if (componentsInChildren.Length == 0)
		{
			return new Bounds(trans.position, Vector3.zero);
		}
		Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			UIWidget uiwidget = componentsInChildren[i];
			if (uiwidget.enabled)
			{
				Vector3[] worldCorners = uiwidget.worldCorners;
				for (int j = 0; j < 4; j++)
				{
					Vector3 vector3 = worldCorners[j];
					if (vector3.x > vector2.x)
					{
						vector2.x = vector3.x;
					}
					if (vector3.y > vector2.y)
					{
						vector2.y = vector3.y;
					}
					if (vector3.z > vector2.z)
					{
						vector2.z = vector3.z;
					}
					if (vector3.x < vector.x)
					{
						vector.x = vector3.x;
					}
					if (vector3.y < vector.y)
					{
						vector.y = vector3.y;
					}
					if (vector3.z < vector.z)
					{
						vector.z = vector3.z;
					}
				}
			}
			i++;
		}
		Bounds result = new Bounds(vector, Vector3.zero);
		result.Encapsulate(vector2);
		return result;
	}

	// Token: 0x06000393 RID: 915 RVA: 0x000232C1 File Offset: 0x000214C1
	public static Bounds CalculateRelativeWidgetBounds(Transform trans)
	{
		return NGUIMath.CalculateRelativeWidgetBounds(trans, trans, !trans.gameObject.activeSelf, true);
	}

	// Token: 0x06000394 RID: 916 RVA: 0x000232D9 File Offset: 0x000214D9
	public static Bounds CalculateRelativeWidgetBounds(Transform trans, bool considerInactive)
	{
		return NGUIMath.CalculateRelativeWidgetBounds(trans, trans, considerInactive, true);
	}

	// Token: 0x06000395 RID: 917 RVA: 0x000232E4 File Offset: 0x000214E4
	public static Bounds CalculateRelativeWidgetBounds(Transform relativeTo, Transform content)
	{
		return NGUIMath.CalculateRelativeWidgetBounds(relativeTo, content, !content.gameObject.activeSelf, true);
	}

	// Token: 0x06000396 RID: 918 RVA: 0x000232FC File Offset: 0x000214FC
	public static Bounds CalculateRelativeWidgetBounds(Transform relativeTo, Transform content, bool considerInactive, bool considerChildren = true)
	{
		if (content != null && relativeTo != null)
		{
			bool flag = false;
			Matrix4x4 worldToLocalMatrix = relativeTo.worldToLocalMatrix;
			Vector3 center = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 point = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			NGUIMath.CalculateRelativeWidgetBounds(content, considerInactive, true, ref worldToLocalMatrix, ref center, ref point, ref flag, considerChildren);
			if (flag)
			{
				Bounds result = new Bounds(center, Vector3.zero);
				result.Encapsulate(point);
				return result;
			}
		}
		return new Bounds(Vector3.zero, Vector3.zero);
	}

	// Token: 0x06000397 RID: 919 RVA: 0x0002338C File Offset: 0x0002158C
	[DebuggerHidden]
	[DebuggerStepThrough]
	private static void CalculateRelativeWidgetBounds(Transform content, bool considerInactive, bool isRoot, ref Matrix4x4 toLocal, ref Vector3 vMin, ref Vector3 vMax, ref bool isSet, bool considerChildren)
	{
		if (content == null)
		{
			return;
		}
		if (!considerInactive && !NGUITools.GetActive(content.gameObject))
		{
			return;
		}
		UIPanel uipanel = isRoot ? null : content.GetComponent<UIPanel>();
		if (uipanel != null && !uipanel.enabled)
		{
			return;
		}
		if (uipanel != null && uipanel.clipping != UIDrawCall.Clipping.None)
		{
			Vector3[] worldCorners = uipanel.worldCorners;
			for (int i = 0; i < 4; i++)
			{
				Vector3 vector = toLocal.MultiplyPoint3x4(worldCorners[i]);
				if (vector.x > vMax.x)
				{
					vMax.x = vector.x;
				}
				if (vector.y > vMax.y)
				{
					vMax.y = vector.y;
				}
				if (vector.z > vMax.z)
				{
					vMax.z = vector.z;
				}
				if (vector.x < vMin.x)
				{
					vMin.x = vector.x;
				}
				if (vector.y < vMin.y)
				{
					vMin.y = vector.y;
				}
				if (vector.z < vMin.z)
				{
					vMin.z = vector.z;
				}
				isSet = true;
			}
			return;
		}
		UIWidget component = content.GetComponent<UIWidget>();
		if (component != null && component.enabled)
		{
			Vector3[] worldCorners2 = component.worldCorners;
			for (int j = 0; j < 4; j++)
			{
				Vector3 vector2 = toLocal.MultiplyPoint3x4(worldCorners2[j]);
				if (vector2.x > vMax.x)
				{
					vMax.x = vector2.x;
				}
				if (vector2.y > vMax.y)
				{
					vMax.y = vector2.y;
				}
				if (vector2.z > vMax.z)
				{
					vMax.z = vector2.z;
				}
				if (vector2.x < vMin.x)
				{
					vMin.x = vector2.x;
				}
				if (vector2.y < vMin.y)
				{
					vMin.y = vector2.y;
				}
				if (vector2.z < vMin.z)
				{
					vMin.z = vector2.z;
				}
				isSet = true;
			}
			if (!considerChildren)
			{
				return;
			}
		}
		int k = 0;
		int childCount = content.childCount;
		while (k < childCount)
		{
			NGUIMath.CalculateRelativeWidgetBounds(content.GetChild(k), considerInactive, false, ref toLocal, ref vMin, ref vMax, ref isSet, true);
			k++;
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x000235FC File Offset: 0x000217FC
	public static Vector3 SpringDampen(ref Vector3 velocity, float strength, float deltaTime)
	{
		if (deltaTime > 1f)
		{
			deltaTime = 1f;
		}
		float f = 1f - strength * 0.001f;
		int num = Mathf.RoundToInt(deltaTime * 1000f);
		float num2 = Mathf.Pow(f, (float)num);
		Vector3 a = velocity * ((num2 - 1f) / Mathf.Log(f));
		velocity *= num2;
		return a * 0.06f;
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00023674 File Offset: 0x00021874
	public static Vector2 SpringDampen(ref Vector2 velocity, float strength, float deltaTime)
	{
		if (deltaTime > 1f)
		{
			deltaTime = 1f;
		}
		float f = 1f - strength * 0.001f;
		int num = Mathf.RoundToInt(deltaTime * 1000f);
		float num2 = Mathf.Pow(f, (float)num);
		Vector2 a = velocity * ((num2 - 1f) / Mathf.Log(f));
		velocity *= num2;
		return a * 0.06f;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x000236EC File Offset: 0x000218EC
	public static float SpringLerp(float strength, float deltaTime)
	{
		if (deltaTime > 1f)
		{
			deltaTime = 1f;
		}
		int num = Mathf.RoundToInt(deltaTime * 1000f);
		deltaTime = 0.001f * strength;
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			num2 = Mathf.Lerp(num2, 1f, deltaTime);
		}
		return num2;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00023740 File Offset: 0x00021940
	public static float SpringLerp(float from, float to, float strength, float deltaTime)
	{
		if (deltaTime > 1f)
		{
			deltaTime = 1f;
		}
		int num = Mathf.RoundToInt(deltaTime * 1000f);
		deltaTime = 0.001f * strength;
		for (int i = 0; i < num; i++)
		{
			from = Mathf.Lerp(from, to, deltaTime);
		}
		return from;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00023789 File Offset: 0x00021989
	public static Vector2 SpringLerp(Vector2 from, Vector2 to, float strength, float deltaTime)
	{
		return Vector2.Lerp(from, to, NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00023799 File Offset: 0x00021999
	public static Vector3 SpringLerp(Vector3 from, Vector3 to, float strength, float deltaTime)
	{
		return Vector3.Lerp(from, to, NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x0600039E RID: 926 RVA: 0x000237A9 File Offset: 0x000219A9
	public static Quaternion SpringLerp(Quaternion from, Quaternion to, float strength, float deltaTime)
	{
		return Quaternion.Slerp(from, to, NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x0600039F RID: 927 RVA: 0x000237BC File Offset: 0x000219BC
	public static float RotateTowards(float from, float to, float maxAngle)
	{
		float num = NGUIMath.WrapAngle(to - from);
		if (Mathf.Abs(num) > maxAngle)
		{
			num = maxAngle * Mathf.Sign(num);
		}
		return from + num;
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x000237E8 File Offset: 0x000219E8
	private static float DistancePointToLineSegment(Vector2 point, Vector2 a, Vector2 b)
	{
		float sqrMagnitude = (b - a).sqrMagnitude;
		if (sqrMagnitude == 0f)
		{
			return (point - a).magnitude;
		}
		float num = Vector2.Dot(point - a, b - a) / sqrMagnitude;
		if (num < 0f)
		{
			return (point - a).magnitude;
		}
		if (num > 1f)
		{
			return (point - b).magnitude;
		}
		Vector2 b2 = a + num * (b - a);
		return (point - b2).magnitude;
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00023888 File Offset: 0x00021A88
	public static float DistanceToRectangle(Vector2[] screenPoints, Vector2 mousePos)
	{
		bool flag = false;
		int val = 4;
		for (int i = 0; i < 5; i++)
		{
			Vector3 vector = screenPoints[NGUIMath.RepeatIndex(i, 4)];
			Vector3 vector2 = screenPoints[NGUIMath.RepeatIndex(val, 4)];
			if (vector.y > mousePos.y != vector2.y > mousePos.y && mousePos.x < (vector2.x - vector.x) * (mousePos.y - vector.y) / (vector2.y - vector.y) + vector.x)
			{
				flag = !flag;
			}
			val = i;
		}
		if (!flag)
		{
			float num = -1f;
			for (int j = 0; j < 4; j++)
			{
				Vector3 v = screenPoints[j];
				Vector3 v2 = screenPoints[NGUIMath.RepeatIndex(j + 1, 4)];
				float num2 = NGUIMath.DistancePointToLineSegment(mousePos, v, v2);
				if (num2 < num || num < 0f)
				{
					num = num2;
				}
			}
			return num;
		}
		return 0f;
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x000239A4 File Offset: 0x00021BA4
	public static float DistanceToRectangle(Vector3[] worldPoints, Vector2 mousePos, Camera cam)
	{
		Vector2[] array = new Vector2[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = cam.WorldToScreenPoint(worldPoints[i]);
		}
		return NGUIMath.DistanceToRectangle(array, mousePos);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x000239E4 File Offset: 0x00021BE4
	public static Vector2 GetPivotOffset(UIWidget.Pivot pv)
	{
		Vector2 zero = Vector2.zero;
		if (pv == UIWidget.Pivot.Top || pv == UIWidget.Pivot.Center || pv == UIWidget.Pivot.Bottom)
		{
			zero.x = 0.5f;
		}
		else if (pv == UIWidget.Pivot.TopRight || pv == UIWidget.Pivot.Right || pv == UIWidget.Pivot.BottomRight)
		{
			zero.x = 1f;
		}
		else
		{
			zero.x = 0f;
		}
		if (pv == UIWidget.Pivot.Left || pv == UIWidget.Pivot.Center || pv == UIWidget.Pivot.Right)
		{
			zero.y = 0.5f;
		}
		else if (pv == UIWidget.Pivot.TopLeft || pv == UIWidget.Pivot.Top || pv == UIWidget.Pivot.TopRight)
		{
			zero.y = 1f;
		}
		else
		{
			zero.y = 0f;
		}
		return zero;
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00023A78 File Offset: 0x00021C78
	public static UIWidget.Pivot GetPivot(Vector2 offset)
	{
		if (offset.x == 0f)
		{
			if (offset.y == 0f)
			{
				return UIWidget.Pivot.BottomLeft;
			}
			if (offset.y == 1f)
			{
				return UIWidget.Pivot.TopLeft;
			}
			return UIWidget.Pivot.Left;
		}
		else if (offset.x == 1f)
		{
			if (offset.y == 0f)
			{
				return UIWidget.Pivot.BottomRight;
			}
			if (offset.y == 1f)
			{
				return UIWidget.Pivot.TopRight;
			}
			return UIWidget.Pivot.Right;
		}
		else
		{
			if (offset.y == 0f)
			{
				return UIWidget.Pivot.Bottom;
			}
			if (offset.y == 1f)
			{
				return UIWidget.Pivot.Top;
			}
			return UIWidget.Pivot.Center;
		}
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00023AFE File Offset: 0x00021CFE
	public static void MoveWidget(UIRect w, float x, float y)
	{
		NGUIMath.MoveRect(w, x, y);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00023B08 File Offset: 0x00021D08
	public static void MoveRect(UIRect rect, float x, float y)
	{
		int num = Mathf.FloorToInt(x + 0.5f);
		int num2 = Mathf.FloorToInt(y + 0.5f);
		rect.cachedTransform.localPosition += new Vector3((float)num, (float)num2);
		int num3 = 0;
		if (rect.leftAnchor.target)
		{
			num3++;
			rect.leftAnchor.absolute += num;
		}
		if (rect.rightAnchor.target)
		{
			num3++;
			rect.rightAnchor.absolute += num;
		}
		if (rect.bottomAnchor.target)
		{
			num3++;
			rect.bottomAnchor.absolute += num2;
		}
		if (rect.topAnchor.target)
		{
			num3++;
			rect.topAnchor.absolute += num2;
		}
		if (num3 != 0)
		{
			rect.UpdateAnchors();
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00023BFD File Offset: 0x00021DFD
	public static void ResizeWidget(UIWidget w, UIWidget.Pivot pivot, float x, float y, int minWidth, int minHeight)
	{
		NGUIMath.ResizeWidget(w, pivot, x, y, 2, 2, 100000, 100000);
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00023C14 File Offset: 0x00021E14
	public static void ResizeWidget(UIWidget w, UIWidget.Pivot pivot, float x, float y, int minWidth, int minHeight, int maxWidth, int maxHeight)
	{
		if (pivot == UIWidget.Pivot.Center)
		{
			int num = Mathf.RoundToInt(x - (float)w.width);
			int num2 = Mathf.RoundToInt(y - (float)w.height);
			num -= (num & 1);
			num2 -= (num2 & 1);
			if ((num | num2) != 0)
			{
				num >>= 1;
				num2 >>= 1;
				NGUIMath.AdjustWidget(w, (float)(-(float)num), (float)(-(float)num2), (float)num, (float)num2, minWidth, minHeight);
			}
			return;
		}
		Vector3 vector = new Vector3(x, y);
		vector = Quaternion.Inverse(w.cachedTransform.localRotation) * vector;
		switch (pivot)
		{
		case UIWidget.Pivot.TopLeft:
			NGUIMath.AdjustWidget(w, vector.x, 0f, 0f, vector.y, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.Top:
			NGUIMath.AdjustWidget(w, 0f, 0f, 0f, vector.y, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.TopRight:
			NGUIMath.AdjustWidget(w, 0f, 0f, vector.x, vector.y, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.Left:
			NGUIMath.AdjustWidget(w, vector.x, 0f, 0f, 0f, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.Center:
			break;
		case UIWidget.Pivot.Right:
			NGUIMath.AdjustWidget(w, 0f, 0f, vector.x, 0f, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.BottomLeft:
			NGUIMath.AdjustWidget(w, vector.x, vector.y, 0f, 0f, minWidth, minHeight, maxWidth, maxHeight);
			return;
		case UIWidget.Pivot.Bottom:
			NGUIMath.AdjustWidget(w, 0f, vector.y, 0f, 0f, minWidth, minHeight, maxWidth, maxHeight);
			break;
		case UIWidget.Pivot.BottomRight:
			NGUIMath.AdjustWidget(w, 0f, vector.y, vector.x, 0f, minWidth, minHeight, maxWidth, maxHeight);
			return;
		default:
			return;
		}
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00023DE0 File Offset: 0x00021FE0
	public static void AdjustWidget(UIWidget w, float left, float bottom, float right, float top)
	{
		NGUIMath.AdjustWidget(w, left, bottom, right, top, 2, 2, 100000, 100000);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00023E04 File Offset: 0x00022004
	public static void AdjustWidget(UIWidget w, float left, float bottom, float right, float top, int minWidth, int minHeight)
	{
		NGUIMath.AdjustWidget(w, left, bottom, right, top, minWidth, minHeight, 100000, 100000);
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00023E2C File Offset: 0x0002202C
	public static void AdjustWidget(UIWidget w, float left, float bottom, float right, float top, int minWidth, int minHeight, int maxWidth, int maxHeight)
	{
		Vector2 pivotOffset = w.pivotOffset;
		Transform transform = w.cachedTransform;
		Quaternion localRotation = transform.localRotation;
		int num = Mathf.FloorToInt(left + 0.5f);
		int num2 = Mathf.FloorToInt(bottom + 0.5f);
		int num3 = Mathf.FloorToInt(right + 0.5f);
		int num4 = Mathf.FloorToInt(top + 0.5f);
		if (pivotOffset.x == 0.5f && (num == 0 || num3 == 0))
		{
			num = num >> 1 << 1;
			num3 = num3 >> 1 << 1;
		}
		if (pivotOffset.y == 0.5f && (num2 == 0 || num4 == 0))
		{
			num2 = num2 >> 1 << 1;
			num4 = num4 >> 1 << 1;
		}
		Vector3 vector = localRotation * new Vector3((float)num, (float)num4);
		Vector3 vector2 = localRotation * new Vector3((float)num3, (float)num4);
		Vector3 vector3 = localRotation * new Vector3((float)num, (float)num2);
		Vector3 vector4 = localRotation * new Vector3((float)num3, (float)num2);
		Vector3 vector5 = localRotation * new Vector3((float)num, 0f);
		Vector3 vector6 = localRotation * new Vector3((float)num3, 0f);
		Vector3 vector7 = localRotation * new Vector3(0f, (float)num4);
		Vector3 vector8 = localRotation * new Vector3(0f, (float)num2);
		Vector3 zero = Vector3.zero;
		if (pivotOffset.x == 0f && pivotOffset.y == 1f)
		{
			zero.x = vector.x;
			zero.y = vector.y;
		}
		else if (pivotOffset.x == 1f && pivotOffset.y == 0f)
		{
			zero.x = vector4.x;
			zero.y = vector4.y;
		}
		else if (pivotOffset.x == 0f && pivotOffset.y == 0f)
		{
			zero.x = vector3.x;
			zero.y = vector3.y;
		}
		else if (pivotOffset.x == 1f && pivotOffset.y == 1f)
		{
			zero.x = vector2.x;
			zero.y = vector2.y;
		}
		else if (pivotOffset.x == 0f && pivotOffset.y == 0.5f)
		{
			zero.x = vector5.x + (vector7.x + vector8.x) * 0.5f;
			zero.y = vector5.y + (vector7.y + vector8.y) * 0.5f;
		}
		else if (pivotOffset.x == 1f && pivotOffset.y == 0.5f)
		{
			zero.x = vector6.x + (vector7.x + vector8.x) * 0.5f;
			zero.y = vector6.y + (vector7.y + vector8.y) * 0.5f;
		}
		else if (pivotOffset.x == 0.5f && pivotOffset.y == 1f)
		{
			zero.x = vector7.x + (vector5.x + vector6.x) * 0.5f;
			zero.y = vector7.y + (vector5.y + vector6.y) * 0.5f;
		}
		else if (pivotOffset.x == 0.5f && pivotOffset.y == 0f)
		{
			zero.x = vector8.x + (vector5.x + vector6.x) * 0.5f;
			zero.y = vector8.y + (vector5.y + vector6.y) * 0.5f;
		}
		else if (pivotOffset.x == 0.5f && pivotOffset.y == 0.5f)
		{
			zero.x = (vector5.x + vector6.x + vector7.x + vector8.x) * 0.5f;
			zero.y = (vector7.y + vector8.y + vector5.y + vector6.y) * 0.5f;
		}
		minWidth = Mathf.Max(minWidth, w.minWidth);
		minHeight = Mathf.Max(minHeight, w.minHeight);
		int num5 = w.width + num3 - num;
		int num6 = w.height + num4 - num2;
		Vector3 zero2 = Vector3.zero;
		int num7 = num5;
		if (num5 < minWidth)
		{
			num7 = minWidth;
		}
		else if (num5 > maxWidth)
		{
			num7 = maxWidth;
		}
		if (num5 != num7)
		{
			if (num != 0)
			{
				zero2.x -= Mathf.Lerp((float)(num7 - num5), 0f, pivotOffset.x);
			}
			else
			{
				zero2.x += Mathf.Lerp(0f, (float)(num7 - num5), pivotOffset.x);
			}
			num5 = num7;
		}
		int num8 = num6;
		if (num6 < minHeight)
		{
			num8 = minHeight;
		}
		else if (num6 > maxHeight)
		{
			num8 = maxHeight;
		}
		if (num6 != num8)
		{
			if (num2 != 0)
			{
				zero2.y -= Mathf.Lerp((float)(num8 - num6), 0f, pivotOffset.y);
			}
			else
			{
				zero2.y += Mathf.Lerp(0f, (float)(num8 - num6), pivotOffset.y);
			}
			num6 = num8;
		}
		if (pivotOffset.x == 0.5f)
		{
			num5 = num5 >> 1 << 1;
		}
		if (pivotOffset.y == 0.5f)
		{
			num6 = num6 >> 1 << 1;
		}
		Vector3 vector9 = transform.localPosition + zero + localRotation * zero2;
		transform.localPosition = vector9;
		w.SetDimensions(num5, num6);
		if (w.isAnchored)
		{
			transform = transform.parent;
			float num9 = vector9.x - pivotOffset.x * (float)num5;
			float num10 = vector9.y - pivotOffset.y * (float)num6;
			if (w.leftAnchor.target)
			{
				w.leftAnchor.SetHorizontal(transform, num9);
			}
			if (w.rightAnchor.target)
			{
				w.rightAnchor.SetHorizontal(transform, num9 + (float)num5);
			}
			if (w.bottomAnchor.target)
			{
				w.bottomAnchor.SetVertical(transform, num10);
			}
			if (w.topAnchor.target)
			{
				w.topAnchor.SetVertical(transform, num10 + (float)num6);
			}
		}
	}

	// Token: 0x060003AC RID: 940 RVA: 0x0002449C File Offset: 0x0002269C
	public static int AdjustByDPI(float height)
	{
		float num = Screen.dpi;
		RuntimePlatform platform = Application.platform;
		if (num == 0f)
		{
			num = ((platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) ? 160f : 96f);
		}
		int num2 = Mathf.RoundToInt(height * (96f / num));
		if ((num2 & 1) == 1)
		{
			num2++;
		}
		return num2;
	}

	// Token: 0x060003AD RID: 941 RVA: 0x000244F0 File Offset: 0x000226F0
	public static Vector2 ScreenToPixels(Vector2 pos, Transform relativeTo)
	{
		int layer = relativeTo.gameObject.layer;
		Camera camera = NGUITools.FindCameraForLayer(layer);
		if (camera == null)
		{
			UnityEngine.Debug.LogWarning("No camera found for layer " + layer.ToString());
			return pos;
		}
		Vector3 position = camera.ScreenToWorldPoint(pos);
		return relativeTo.InverseTransformPoint(position);
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0002454C File Offset: 0x0002274C
	public static Vector2 ScreenToParentPixels(Vector2 pos, Transform relativeTo)
	{
		int layer = relativeTo.gameObject.layer;
		if (relativeTo.parent != null)
		{
			relativeTo = relativeTo.parent;
		}
		Camera camera = NGUITools.FindCameraForLayer(layer);
		if (camera == null)
		{
			UnityEngine.Debug.LogWarning("No camera found for layer " + layer.ToString());
			return pos;
		}
		Vector3 vector = camera.ScreenToWorldPoint(pos);
		return (relativeTo != null) ? relativeTo.InverseTransformPoint(vector) : vector;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x000245C8 File Offset: 0x000227C8
	public static Vector3 WorldToLocalPoint(Vector3 worldPos, Camera worldCam, Camera uiCam, Transform relativeTo)
	{
		worldPos = worldCam.WorldToViewportPoint(worldPos);
		worldPos = uiCam.ViewportToWorldPoint(worldPos);
		if (relativeTo == null)
		{
			return worldPos;
		}
		relativeTo = relativeTo.parent;
		if (relativeTo == null)
		{
			return worldPos;
		}
		return relativeTo.InverseTransformPoint(worldPos);
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x00024604 File Offset: 0x00022804
	public static void OverlayPosition(this Transform trans, Vector3 worldPos, Camera worldCam, Camera myCam)
	{
		worldPos = worldCam.WorldToViewportPoint(worldPos);
		worldPos = myCam.ViewportToWorldPoint(worldPos);
		Transform parent = trans.parent;
		trans.localPosition = ((parent != null) ? parent.InverseTransformPoint(worldPos) : worldPos);
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00024644 File Offset: 0x00022844
	public static void OverlayPosition(this Transform trans, Vector3 worldPos, Camera worldCam)
	{
		Camera camera = NGUITools.FindCameraForLayer(trans.gameObject.layer);
		if (camera != null)
		{
			trans.OverlayPosition(worldPos, worldCam, camera);
		}
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00024674 File Offset: 0x00022874
	public static void OverlayPosition(this Transform trans, Transform target)
	{
		Camera camera = NGUITools.FindCameraForLayer(trans.gameObject.layer);
		Camera camera2 = NGUITools.FindCameraForLayer(target.gameObject.layer);
		if (camera != null && camera2 != null)
		{
			trans.OverlayPosition(target.position, camera2, camera);
		}
	}
}
