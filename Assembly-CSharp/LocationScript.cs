using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
public class LocationScript : MonoBehaviour
{
	// Token: 0x0600198F RID: 6543 RVA: 0x00103544 File Offset: 0x00101744
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
	}

	// Token: 0x06001990 RID: 6544 RVA: 0x001035DC File Offset: 0x001017DC
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

	// Token: 0x040028D7 RID: 10455
	public UILabel Label;

	// Token: 0x040028D8 RID: 10456
	public UISprite BG;

	// Token: 0x040028D9 RID: 10457
	public bool Show;
}
