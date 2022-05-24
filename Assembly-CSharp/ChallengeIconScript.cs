using System;
using UnityEngine;

// Token: 0x02000107 RID: 263
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AAF RID: 2735 RVA: 0x00064088 File Offset: 0x00062288
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

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000640E0 File Offset: 0x000622E0
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

	// Token: 0x04000CFE RID: 3326
	public UITexture LargeIcon;

	// Token: 0x04000CFF RID: 3327
	public UISprite IconFrame;

	// Token: 0x04000D00 RID: 3328
	public UISprite NameFrame;

	// Token: 0x04000D01 RID: 3329
	public UITexture Icon;

	// Token: 0x04000D02 RID: 3330
	public UILabel Name;

	// Token: 0x04000D03 RID: 3331
	public float Dark;

	// Token: 0x04000D04 RID: 3332
	private float R;

	// Token: 0x04000D05 RID: 3333
	private float G;

	// Token: 0x04000D06 RID: 3334
	private float B;
}
