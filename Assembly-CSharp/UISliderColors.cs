using System;
using UnityEngine;

// Token: 0x0200003D RID: 61
[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
	// Token: 0x060000F4 RID: 244 RVA: 0x00012F9B File Offset: 0x0001119B
	private void Start()
	{
		this.mBar = base.GetComponent<UIProgressBar>();
		this.mSprite = base.GetComponent<UIBasicSprite>();
		this.Update();
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00012FBC File Offset: 0x000111BC
	private void Update()
	{
		if (this.sprite == null || this.colors.Length == 0)
		{
			return;
		}
		float num = (this.mBar != null) ? this.mBar.value : this.mSprite.fillAmount;
		num *= (float)(this.colors.Length - 1);
		int num2 = Mathf.FloorToInt(num);
		Color color = this.colors[0];
		if (num2 >= 0)
		{
			if (num2 + 1 < this.colors.Length)
			{
				float t = num - (float)num2;
				color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], t);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			else
			{
				color = this.colors[this.colors.Length - 1];
			}
		}
		color.a = this.sprite.color.a;
		this.sprite.color = color;
	}

	// Token: 0x040002C1 RID: 705
	public UISprite sprite;

	// Token: 0x040002C2 RID: 706
	public Color[] colors = new Color[]
	{
		Color.red,
		Color.yellow,
		Color.green
	};

	// Token: 0x040002C3 RID: 707
	private UIProgressBar mBar;

	// Token: 0x040002C4 RID: 708
	private UIBasicSprite mSprite;
}
