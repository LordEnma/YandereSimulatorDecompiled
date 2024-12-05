using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
	public delegate void ColorEvent(Color c);

	private sealed class HSV
	{
		public double H;

		public double S = 1.0;

		public double V = 1.0;

		public byte A = byte.MaxValue;

		public HSV()
		{
		}

		public HSV(double h, double s, double v)
		{
			H = h;
			S = s;
			V = v;
		}

		public HSV(Color color)
		{
			float num = Mathf.Max(color.r, Mathf.Max(color.g, color.b));
			float num2 = Mathf.Min(color.r, Mathf.Min(color.g, color.b));
			float num3 = (float)H;
			if (num2 != num)
			{
				num3 = ((num == color.r) ? ((color.g - color.b) / (num - num2)) : ((num != color.g) ? (4f + (color.r - color.g) / (num - num2)) : (2f + (color.b - color.r) / (num - num2)))) * 60f;
				if (num3 < 0f)
				{
					num3 += 360f;
				}
			}
			H = num3;
			S = ((num == 0f) ? 0.0 : (1.0 - (double)num2 / (double)num));
			V = num;
			A = (byte)(color.a * 255f);
		}

		public Color32 ToColor()
		{
			int num = Convert.ToInt32(Math.Floor(H / 60.0)) % 6;
			double num2 = H / 60.0 - Math.Floor(H / 60.0);
			double num3 = V * 255.0;
			byte b = (byte)Convert.ToInt32(num3);
			byte b2 = (byte)Convert.ToInt32(num3 * (1.0 - S));
			byte b3 = (byte)Convert.ToInt32(num3 * (1.0 - num2 * S));
			byte b4 = (byte)Convert.ToInt32(num3 * (1.0 - (1.0 - num2) * S));
			return num switch
			{
				0 => new Color32(b, b4, b2, A), 
				1 => new Color32(b3, b, b2, A), 
				2 => new Color32(b2, b, b4, A), 
				3 => new Color32(b2, b3, b, A), 
				4 => new Color32(b4, b2, b, A), 
				5 => new Color32(b, b2, b3, A), 
				_ => default(Color32), 
			};
		}
	}

	private static ColorPicker instance;

	public static bool done = true;

	private static ColorEvent onCC;

	private static ColorEvent onCS;

	private static Color32 originalColor;

	private static Color32 modifiedColor;

	private static HSV modifiedHsv;

	public Color newColor;

	private static bool useA;

	private bool interact;

	public RectTransform positionIndicator;

	public Slider mainComponent;

	public Slider rComponent;

	public Slider gComponent;

	public Slider bComponent;

	public Slider aComponent;

	public InputField hexaComponent;

	public RawImage colorComponent;

	public CustomModeScript CustomMode;

	public Renderer[] r;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(value: false);
		Create(r[0].sharedMaterial.color, "", SetColor, ColorFinished, useAlpha: true);
		Create(r[1].sharedMaterial.color, "", SetColor, ColorFinished, useAlpha: true);
		base.gameObject.SetActive(value: true);
	}

	public static bool Create(Color original, string message, ColorEvent onColorChanged, ColorEvent onColorSelected, bool useAlpha = false)
	{
		if ((object)instance == null)
		{
			Debug.LogError("No Colorpicker prefab active on 'Start' in scene");
			return false;
		}
		if (done)
		{
			done = false;
			originalColor = original;
			modifiedColor = original;
			onCC = onColorChanged;
			onCS = onColorSelected;
			useA = useAlpha;
			instance.gameObject.SetActive(value: true);
			instance.transform.GetChild(0).GetChild(0).GetComponent<Text>()
				.text = message;
			instance.aComponent.gameObject.SetActive(useAlpha);
			instance.RecalculateMenu(recalculateHSV: true);
			instance.hexaComponent.placeholder.GetComponent<Text>().text = "RRGGBB" + (useAlpha ? "AA" : "");
			return true;
		}
		Done();
		return false;
	}

	private void RecalculateMenu(bool recalculateHSV)
	{
		interact = false;
		if (recalculateHSV)
		{
			modifiedHsv = new HSV(modifiedColor);
		}
		else
		{
			modifiedColor = modifiedHsv.ToColor();
		}
		rComponent.value = (int)modifiedColor.r;
		rComponent.transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.r.ToString();
		gComponent.value = (int)modifiedColor.g;
		gComponent.transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.g.ToString();
		bComponent.value = (int)modifiedColor.b;
		bComponent.transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.b.ToString();
		if (useA)
		{
			aComponent.value = (int)modifiedColor.a;
			aComponent.transform.GetChild(3).GetComponent<InputField>().text = modifiedColor.a.ToString();
		}
		mainComponent.value = (float)modifiedHsv.H;
		rComponent.transform.GetChild(0).GetComponent<RawImage>().color = new Color32(byte.MaxValue, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		rComponent.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
			.color = new Color32(0, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		gComponent.transform.GetChild(0).GetComponent<RawImage>().color = new Color32(modifiedColor.r, byte.MaxValue, modifiedColor.b, byte.MaxValue);
		gComponent.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
			.color = new Color32(modifiedColor.r, 0, modifiedColor.b, byte.MaxValue);
		bComponent.transform.GetChild(0).GetComponent<RawImage>().color = new Color32(modifiedColor.r, modifiedColor.g, byte.MaxValue, byte.MaxValue);
		bComponent.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
			.color = new Color32(modifiedColor.r, modifiedColor.g, 0, byte.MaxValue);
		if (useA)
		{
			aComponent.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
				.color = new Color32(modifiedColor.r, modifiedColor.g, modifiedColor.b, byte.MaxValue);
		}
		positionIndicator.parent.GetChild(0).GetComponent<RawImage>().color = new HSV(modifiedHsv.H, 1.0, 1.0).ToColor();
		positionIndicator.anchorMin = new Vector2((float)modifiedHsv.S, (float)modifiedHsv.V);
		positionIndicator.anchorMax = positionIndicator.anchorMin;
		hexaComponent.text = (useA ? ColorUtility.ToHtmlStringRGBA(modifiedColor) : ColorUtility.ToHtmlStringRGB(modifiedColor));
		colorComponent.color = modifiedColor;
		onCC?.Invoke(modifiedColor);
		interact = true;
		newColor = modifiedColor;
	}

	public void SetChooser()
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(positionIndicator.parent as RectTransform, Input.mousePosition, GetComponentInParent<Canvas>().worldCamera, out var localPoint);
		localPoint = Rect.PointToNormalized((positionIndicator.parent as RectTransform).rect, localPoint);
		if (positionIndicator.anchorMin != localPoint)
		{
			positionIndicator.anchorMin = localPoint;
			positionIndicator.anchorMax = localPoint;
			modifiedHsv.S = localPoint.x;
			modifiedHsv.V = localPoint.y;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	public void SetMain(float value)
	{
		if (interact)
		{
			modifiedHsv.H = value;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	public void SetR(float value)
	{
		if (interact)
		{
			modifiedColor.r = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetR(string value)
	{
		if (interact)
		{
			modifiedColor.r = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetG(float value)
	{
		if (interact)
		{
			modifiedColor.g = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetG(string value)
	{
		if (interact)
		{
			modifiedColor.g = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetB(float value)
	{
		if (interact)
		{
			modifiedColor.b = (byte)value;
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetB(string value)
	{
		if (interact)
		{
			modifiedColor.b = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: true);
		}
	}

	public void SetA(float value)
	{
		if (interact)
		{
			modifiedHsv.A = (byte)value;
			RecalculateMenu(recalculateHSV: false);
		}
	}

	public void SetA(string value)
	{
		if (interact)
		{
			modifiedHsv.A = (byte)Mathf.Clamp(int.Parse(value), 0, 255);
			RecalculateMenu(recalculateHSV: false);
		}
	}

	public void SetHexa(string value)
	{
		if (!interact)
		{
			return;
		}
		if (ColorUtility.TryParseHtmlString("#" + value, out var color))
		{
			if (!useA)
			{
				color.a = 1f;
			}
			modifiedColor = color;
			RecalculateMenu(recalculateHSV: true);
		}
		else
		{
			hexaComponent.text = (useA ? ColorUtility.ToHtmlStringRGBA(modifiedColor) : ColorUtility.ToHtmlStringRGB(modifiedColor));
		}
	}

	public void CCancel()
	{
		Cancel();
	}

	public static void Cancel()
	{
		modifiedColor = originalColor;
		Done();
	}

	public void CDone()
	{
		Done();
		SaveColor();
		base.gameObject.SetActive(value: false);
	}

	public static void Done()
	{
		done = true;
		onCC?.Invoke(modifiedColor);
		onCS?.Invoke(modifiedColor);
		instance.transform.gameObject.SetActive(value: false);
	}

	private void SetColor(Color currentColor)
	{
		r[0].sharedMaterial.color = currentColor;
		r[1].sharedMaterial.color = currentColor;
		SaveColor();
	}

	private void ColorFinished(Color finishedColor)
	{
		Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
	}

	private void SaveColor()
	{
		if (CustomMode.CosmeticSelected == 1)
		{
			CustomMode.CustomHairColor[CustomMode.Selected] = newColor;
			CustomMode.JSON.Students[CustomMode.Selected].HairR = Mathf.RoundToInt(newColor.r * 255f);
			CustomMode.JSON.Students[CustomMode.Selected].HairG = Mathf.RoundToInt(newColor.g * 255f);
			CustomMode.JSON.Students[CustomMode.Selected].HairB = Mathf.RoundToInt(newColor.b * 255f);
		}
		else
		{
			CustomMode.CustomEyeColor[CustomMode.Selected] = newColor;
			CustomMode.JSON.Students[CustomMode.Selected].EyeR = Mathf.RoundToInt(newColor.r * 255f);
			CustomMode.JSON.Students[CustomMode.Selected].EyeG = Mathf.RoundToInt(newColor.g * 255f);
			CustomMode.JSON.Students[CustomMode.Selected].EyeB = Mathf.RoundToInt(newColor.b * 255f);
		}
	}
}
