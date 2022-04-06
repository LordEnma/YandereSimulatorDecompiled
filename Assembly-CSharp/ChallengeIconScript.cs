using System;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AAD RID: 2733 RVA: 0x00063AD8 File Offset: 0x00061CD8
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

	// Token: 0x06000AAE RID: 2734 RVA: 0x00063B30 File Offset: 0x00061D30
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

	// Token: 0x04000CF5 RID: 3317
	public UITexture LargeIcon;

	// Token: 0x04000CF6 RID: 3318
	public UISprite IconFrame;

	// Token: 0x04000CF7 RID: 3319
	public UISprite NameFrame;

	// Token: 0x04000CF8 RID: 3320
	public UITexture Icon;

	// Token: 0x04000CF9 RID: 3321
	public UILabel Name;

	// Token: 0x04000CFA RID: 3322
	public float Dark;

	// Token: 0x04000CFB RID: 3323
	private float R;

	// Token: 0x04000CFC RID: 3324
	private float G;

	// Token: 0x04000CFD RID: 3325
	private float B;
}
