using System;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AAA RID: 2730 RVA: 0x00063260 File Offset: 0x00061460
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

	// Token: 0x06000AAB RID: 2731 RVA: 0x000632B8 File Offset: 0x000614B8
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

	// Token: 0x04000CDF RID: 3295
	public UITexture LargeIcon;

	// Token: 0x04000CE0 RID: 3296
	public UISprite IconFrame;

	// Token: 0x04000CE1 RID: 3297
	public UISprite NameFrame;

	// Token: 0x04000CE2 RID: 3298
	public UITexture Icon;

	// Token: 0x04000CE3 RID: 3299
	public UILabel Name;

	// Token: 0x04000CE4 RID: 3300
	public float Dark;

	// Token: 0x04000CE5 RID: 3301
	private float R;

	// Token: 0x04000CE6 RID: 3302
	private float G;

	// Token: 0x04000CE7 RID: 3303
	private float B;
}
