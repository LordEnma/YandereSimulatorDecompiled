using System;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AAB RID: 2731 RVA: 0x0006365C File Offset: 0x0006185C
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

	// Token: 0x06000AAC RID: 2732 RVA: 0x000636B4 File Offset: 0x000618B4
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

	// Token: 0x04000CEE RID: 3310
	public UITexture LargeIcon;

	// Token: 0x04000CEF RID: 3311
	public UISprite IconFrame;

	// Token: 0x04000CF0 RID: 3312
	public UISprite NameFrame;

	// Token: 0x04000CF1 RID: 3313
	public UITexture Icon;

	// Token: 0x04000CF2 RID: 3314
	public UILabel Name;

	// Token: 0x04000CF3 RID: 3315
	public float Dark;

	// Token: 0x04000CF4 RID: 3316
	private float R;

	// Token: 0x04000CF5 RID: 3317
	private float G;

	// Token: 0x04000CF6 RID: 3318
	private float B;
}
