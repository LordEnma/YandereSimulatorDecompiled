using UnityEngine;

[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
	public UISprite sprite;

	public Color[] colors = new Color[3]
	{
		Color.red,
		Color.yellow,
		Color.green
	};

	private UIProgressBar mBar;

	private UIBasicSprite mSprite;

	private void Start()
	{
		mBar = GetComponent<UIProgressBar>();
		mSprite = GetComponent<UIBasicSprite>();
		Update();
	}

	private void Update()
	{
		if (sprite == null || colors.Length == 0)
		{
			return;
		}
		float num = ((mBar != null) ? mBar.value : mSprite.fillAmount);
		num *= (float)(colors.Length - 1);
		int num2 = Mathf.FloorToInt(num);
		Color color = colors[0];
		if (num2 >= 0)
		{
			if (num2 + 1 >= colors.Length)
			{
				color = ((num2 >= colors.Length) ? colors[colors.Length - 1] : colors[num2]);
			}
			else
			{
				float t = num - (float)num2;
				color = Color.Lerp(colors[num2], colors[num2 + 1], t);
			}
		}
		color.a = sprite.color.a;
		sprite.color = color;
	}
}
