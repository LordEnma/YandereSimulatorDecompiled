using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GradientPicker : MonoBehaviour
{
	public delegate void GradientEvent(Gradient g);

	private static GradientPicker instance;

	public static bool done = true;

	private static GradientEvent onGC;

	private static GradientEvent onGS;

	private static Gradient originalGradient;

	private static Gradient modifiedGradient;

	private GameObject key;

	private static bool interact;

	private InputField positionComponent;

	private Image colorComponent;

	private Transform alphaComponent;

	private List<Slider> colorKeyObjects;

	private List<GradientColorKey> colorKeys;

	private int selectedColorKey;

	private List<Slider> alphaKeyObjects;

	private List<GradientAlphaKey> alphaKeys;

	private int selectedAlphaKey;

	private void Awake()
	{
		instance = this;
		key = base.transform.GetChild(2).gameObject;
		positionComponent = base.transform.parent.GetChild(3).GetComponent<InputField>();
		colorComponent = base.transform.parent.GetChild(4).GetComponent<Image>();
		alphaComponent = base.transform.parent.GetChild(5);
		base.transform.parent.gameObject.SetActive(value: false);
	}

	public static bool Create(Gradient original, string message, GradientEvent onGradientChanged, GradientEvent onGradientSelected)
	{
		if ((object)instance == null)
		{
			Debug.LogError("No Gradientpicker prefab active on 'Start' in scene");
			return false;
		}
		if (done)
		{
			done = false;
			originalGradient = new Gradient();
			originalGradient.SetKeys(original.colorKeys, original.alphaKeys);
			modifiedGradient = new Gradient();
			modifiedGradient.SetKeys(original.colorKeys, original.alphaKeys);
			onGC = onGradientChanged;
			onGS = onGradientSelected;
			instance.transform.parent.gameObject.SetActive(value: true);
			instance.transform.parent.GetChild(0).GetChild(0).GetComponent<Text>()
				.text = message;
			instance.Setup();
			return true;
		}
		Done();
		return false;
	}

	private void Setup()
	{
		interact = false;
		colorKeyObjects = new List<Slider>();
		colorKeys = new List<GradientColorKey>();
		alphaKeyObjects = new List<Slider>();
		alphaKeys = new List<GradientAlphaKey>();
		GradientColorKey[] array = originalGradient.colorKeys;
		foreach (GradientColorKey k in array)
		{
			CreateColorKey(k);
		}
		GradientAlphaKey[] array2 = originalGradient.alphaKeys;
		foreach (GradientAlphaKey k2 in array2)
		{
			CreateAlphaKey(k2);
		}
		CalculateTexture();
		interact = true;
	}

	private void CreateColorKey(GradientColorKey k)
	{
		if (colorKeys.Count < 8)
		{
			Slider component = Object.Instantiate(key, base.transform.position, default(Quaternion), base.transform).GetComponent<Slider>();
			((RectTransform)component.transform).anchoredPosition = new Vector2(0f, -29f);
			component.name = "ColorKey";
			component.gameObject.SetActive(value: true);
			component.value = k.time;
			component.transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<Image>()
				.color = k.color;
			colorKeyObjects.Add(component);
			colorKeys.Add(k);
			ChangeSelectedColorKey(colorKeys.Count - 1);
		}
	}

	public void CreateNewColorKey(float time)
	{
		if (Input.GetMouseButtonDown(0))
		{
			interact = false;
			CreateColorKey(new GradientColorKey(modifiedGradient.Evaluate(time), time));
			interact = true;
		}
	}

	private void CreateAlphaKey(GradientAlphaKey k)
	{
		if (alphaKeys.Count < 8)
		{
			Slider component = Object.Instantiate(key, base.transform.position, default(Quaternion), base.transform).GetComponent<Slider>();
			((RectTransform)component.transform).anchoredPosition = new Vector2(0f, 25f);
			component.transform.GetChild(0).GetChild(0).rotation = default(Quaternion);
			component.name = "AlphaKey";
			component.gameObject.SetActive(value: true);
			component.value = k.time;
			component.transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<Image>()
				.color = new Color(k.alpha, k.alpha, k.alpha, 1f);
			alphaKeyObjects.Add(component);
			alphaKeys.Add(k);
			ChangeSelectedAlphaKey(alphaKeys.Count - 1);
		}
	}

	public void CreateNewAlphaKey(float time)
	{
		if (Input.GetMouseButtonDown(0))
		{
			interact = false;
			CreateAlphaKey(new GradientAlphaKey(modifiedGradient.Evaluate(time).a, time));
			interact = true;
		}
	}

	private void CalculateTexture()
	{
		Color[] array = new Color[325];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = modifiedGradient.Evaluate((float)i / (float)array.Length);
		}
		Texture2D texture2D = new Texture2D(array.Length, 1)
		{
			wrapMode = TextureWrapMode.Clamp,
			filterMode = FilterMode.Bilinear
		};
		texture2D.SetPixels(array);
		texture2D.Apply();
		GetComponent<RawImage>().texture = texture2D;
		onGC?.Invoke(modifiedGradient);
	}

	public void SetAlpha(float value)
	{
		if (interact)
		{
			alphaKeys[selectedAlphaKey] = new GradientAlphaKey(value, alphaKeys[selectedAlphaKey].time);
			modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
			CalculateTexture();
			alphaComponent.GetChild(4).GetComponent<InputField>().text = Mathf.RoundToInt(value * 255f).ToString();
			alphaKeyObjects[selectedAlphaKey].transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<Image>()
				.color = new Color(value, value, value, 1f);
		}
	}

	public void SetAlpha(string value)
	{
		alphaComponent.GetComponent<Slider>().value = (float)Mathf.Clamp(int.Parse(value), 0, 255) / 255f;
		CalculateTexture();
	}

	private void ChangeSelectedColorKey(int value)
	{
		if (colorKeyObjects.Count() > selectedColorKey)
		{
			colorKeyObjects[selectedColorKey].transform.GetChild(0).GetChild(0).GetComponent<Image>()
				.color = Color.gray;
		}
		if (alphaKeyObjects.Count() > 0)
		{
			alphaKeyObjects[selectedAlphaKey].transform.GetChild(0).GetChild(0).GetComponent<Image>()
				.color = Color.gray;
		}
		colorKeyObjects[value].transform.GetChild(0).GetChild(0).GetComponent<Image>()
			.color = Color.green;
		if (selectedColorKey != value && !ColorPicker.done)
		{
			ColorPicker.Done();
		}
		selectedColorKey = value;
		colorKeyObjects[value].Select();
	}

	private void ChangeSelectedAlphaKey(int value)
	{
		if (alphaKeyObjects.Count > selectedAlphaKey)
		{
			alphaKeyObjects[selectedAlphaKey].transform.GetChild(0).GetChild(0).GetComponent<Image>()
				.color = Color.gray;
		}
		if (colorKeyObjects.Count > 0)
		{
			colorKeyObjects[selectedColorKey].transform.GetChild(0).GetChild(0).GetComponent<Image>()
				.color = Color.gray;
		}
		alphaKeyObjects[value].transform.GetChild(0).GetChild(0).GetComponent<Image>()
			.color = Color.green;
		selectedAlphaKey = value;
		alphaKeyObjects[value].Select();
	}

	public void CheckDeleteKey(Slider s)
	{
		if (!Input.GetMouseButtonDown(1))
		{
			return;
		}
		if (s.name == "ColorKey" && colorKeys.Count > 2)
		{
			if (!ColorPicker.done)
			{
				ColorPicker.Done();
				return;
			}
			int num = colorKeyObjects.IndexOf(s);
			Object.Destroy(colorKeyObjects[num].gameObject);
			colorKeyObjects.RemoveAt(num);
			colorKeys.RemoveAt(num);
			if (num <= selectedColorKey)
			{
				ChangeSelectedColorKey(selectedColorKey - 1);
			}
			modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
			CalculateTexture();
		}
		if (s.name == "AlphaKey" && alphaKeys.Count > 2)
		{
			int num2 = alphaKeyObjects.IndexOf(s);
			Object.Destroy(alphaKeyObjects[num2].gameObject);
			alphaKeyObjects.RemoveAt(num2);
			alphaKeys.RemoveAt(num2);
			if (num2 <= selectedAlphaKey)
			{
				ChangeSelectedAlphaKey(selectedAlphaKey - 1);
			}
			modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
			CalculateTexture();
		}
	}

	public void Select()
	{
		Slider component = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
		component.transform.SetAsLastSibling();
		if (component.name == "ColorKey")
		{
			ChangeSelectedColorKey(colorKeyObjects.IndexOf(component));
			alphaComponent.gameObject.SetActive(value: false);
			colorComponent.gameObject.SetActive(value: true);
			positionComponent.text = Mathf.RoundToInt(colorKeys[selectedColorKey].time * 100f).ToString();
			colorComponent.GetComponent<Image>().color = colorKeys[selectedColorKey].color;
		}
		else
		{
			ChangeSelectedAlphaKey(alphaKeyObjects.IndexOf(component));
			colorComponent.gameObject.SetActive(value: false);
			alphaComponent.gameObject.SetActive(value: true);
			positionComponent.text = Mathf.RoundToInt(alphaKeys[selectedAlphaKey].time * 100f).ToString();
			alphaComponent.GetComponent<Slider>().value = alphaKeys[selectedAlphaKey].alpha;
			alphaComponent.GetChild(4).GetComponent<InputField>().text = Mathf.RoundToInt(alphaKeys[selectedAlphaKey].alpha * 255f).ToString();
		}
	}

	public void SetTime(float time)
	{
		if (interact)
		{
			Slider component = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
			if (component.name == "ColorKey")
			{
				int index = colorKeyObjects.IndexOf(component);
				colorKeys[index] = new GradientColorKey(colorKeys[index].color, time);
			}
			else
			{
				int index2 = alphaKeyObjects.IndexOf(component);
				alphaKeys[index2] = new GradientAlphaKey(alphaKeys[index2].alpha, time);
			}
			modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
			CalculateTexture();
			positionComponent.text = Mathf.RoundToInt(time * 100f).ToString();
		}
	}

	public void SetTime(string time)
	{
		interact = false;
		float num = (float)Mathf.Clamp(int.Parse(time), 0, 100) * 0.01f;
		if (colorComponent.gameObject.activeSelf)
		{
			colorKeyObjects[selectedColorKey].value = num;
			colorKeys[selectedColorKey] = new GradientColorKey(colorKeys[selectedColorKey].color, num);
		}
		else
		{
			alphaKeyObjects[selectedAlphaKey].value = num;
			alphaKeys[selectedAlphaKey] = new GradientAlphaKey(alphaKeys[selectedAlphaKey].alpha, num);
		}
		modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
		CalculateTexture();
		interact = true;
	}

	public void ChooseColor()
	{
		ColorPicker.Create(colorKeys[selectedColorKey].color, "Gradient Color Key", delegate(Color c)
		{
			UpdateColor(selectedColorKey, c);
		}, null);
	}

	private void UpdateColor(int index, Color c)
	{
		interact = false;
		colorKeys[index] = new GradientColorKey(c, colorKeys[index].time);
		colorKeyObjects[index].transform.GetChild(0).GetChild(0).GetChild(0)
			.GetComponent<Image>()
			.color = c;
		colorComponent.color = c;
		modifiedGradient.SetKeys(colorKeys.ToArray(), alphaKeys.ToArray());
		CalculateTexture();
		interact = true;
	}

	public void CCancel()
	{
		Cancel();
	}

	public static void Cancel()
	{
		modifiedGradient = originalGradient;
		Done();
	}

	public void CDone()
	{
		Done();
	}

	public static void Done()
	{
		if (!ColorPicker.done)
		{
			ColorPicker.Done();
		}
		foreach (Slider colorKeyObject in instance.colorKeyObjects)
		{
			Object.Destroy(colorKeyObject.gameObject);
		}
		foreach (Slider alphaKeyObject in instance.alphaKeyObjects)
		{
			Object.Destroy(alphaKeyObject.gameObject);
		}
		instance.colorKeyObjects = null;
		instance.colorKeys = null;
		instance.alphaKeyObjects = null;
		instance.alphaKeys = null;
		done = true;
		onGC?.Invoke(modifiedGradient);
		onGS?.Invoke(modifiedGradient);
		instance.transform.parent.gameObject.SetActive(value: false);
	}
}
