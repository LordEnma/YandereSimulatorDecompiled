using System;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000AA7 RID: 2727 RVA: 0x000630B8 File Offset: 0x000612B8
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

	// Token: 0x06000AA8 RID: 2728 RVA: 0x00063110 File Offset: 0x00061310
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

	// Token: 0x04000CDD RID: 3293
	public UITexture LargeIcon;

	// Token: 0x04000CDE RID: 3294
	public UISprite IconFrame;

	// Token: 0x04000CDF RID: 3295
	public UISprite NameFrame;

	// Token: 0x04000CE0 RID: 3296
	public UITexture Icon;

	// Token: 0x04000CE1 RID: 3297
	public UILabel Name;

	// Token: 0x04000CE2 RID: 3298
	public float Dark;

	// Token: 0x04000CE3 RID: 3299
	private float R;

	// Token: 0x04000CE4 RID: 3300
	private float G;

	// Token: 0x04000CE5 RID: 3301
	private float B;
}
