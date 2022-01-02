using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class LocationScript : MonoBehaviour
{
	// Token: 0x0600195C RID: 6492 RVA: 0x001003B0 File Offset: 0x000FE5B0
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
	}

	// Token: 0x0600195D RID: 6493 RVA: 0x00100448 File Offset: 0x000FE648
	private void Update()
	{
		if (this.Show)
		{
			this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a + Time.deltaTime * 10f);
			if (this.BG.color.a > 1f)
			{
				this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 1f);
			}
			this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
			return;
		}
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a - Time.deltaTime * 10f);
		if (this.BG.color.a < 0f)
		{
			this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
		}
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
	}

	// Token: 0x04002852 RID: 10322
	public UILabel Label;

	// Token: 0x04002853 RID: 10323
	public UISprite BG;

	// Token: 0x04002854 RID: 10324
	public bool Show;
}
