using System;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AAA RID: 2730 RVA: 0x000632B0 File Offset: 0x000614B0
	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			this.R = 1f;
			this.G = 0f;
			this.B = 0f;
			return;
		}
		this.R = 1f;
		this.G = 1f;
		this.B = 1f;
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x00063308 File Offset: 0x00061508
	private void Update()
	{
		if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f)
		{
			if (this.Icon != null)
			{
				this.LargeIcon.mainTexture = this.Icon.mainTexture;
			}
			this.Dark -= Time.deltaTime * 10f;
			if (this.Dark < 0f)
			{
				this.Dark = 0f;
			}
		}
		else
		{
			this.Dark += Time.deltaTime * 10f;
			if (this.Dark > 1f)
			{
				this.Dark = 1f;
			}
		}
		this.IconFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
		this.NameFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
		this.Name.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
		if (GameGlobals.LoveSick)
		{
			if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f)
			{
				this.IconFrame.color = Color.white;
				this.NameFrame.color = Color.white;
				this.Name.color = Color.white;
				return;
			}
			this.IconFrame.color = new Color(this.R, this.G, this.B, 1f);
			this.NameFrame.color = new Color(this.R, this.G, this.B, 1f);
			this.Name.color = new Color(this.R, this.G, this.B, 1f);
		}
	}

	// Token: 0x04000CE2 RID: 3298
	public UITexture LargeIcon;

	// Token: 0x04000CE3 RID: 3299
	public UISprite IconFrame;

	// Token: 0x04000CE4 RID: 3300
	public UISprite NameFrame;

	// Token: 0x04000CE5 RID: 3301
	public UITexture Icon;

	// Token: 0x04000CE6 RID: 3302
	public UILabel Name;

	// Token: 0x04000CE7 RID: 3303
	public float Dark;

	// Token: 0x04000CE8 RID: 3304
	private float R;

	// Token: 0x04000CE9 RID: 3305
	private float G;

	// Token: 0x04000CEA RID: 3306
	private float B;
}
