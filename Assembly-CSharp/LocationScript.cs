using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LocationScript : MonoBehaviour
{
	// Token: 0x06001960 RID: 6496 RVA: 0x00100878 File Offset: 0x000FEA78
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x00100910 File Offset: 0x000FEB10
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

	// Token: 0x04002859 RID: 10329
	public UILabel Label;

	// Token: 0x0400285A RID: 10330
	public UISprite BG;

	// Token: 0x0400285B RID: 10331
	public bool Show;
}
