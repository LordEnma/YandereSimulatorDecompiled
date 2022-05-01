using System;
using UnityEngine;

// Token: 0x02000239 RID: 569
public class CautionScript : MonoBehaviour
{
	// Token: 0x06001232 RID: 4658 RVA: 0x0008C034 File Offset: 0x0008A234
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
		if (GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x0008C09C File Offset: 0x0008A29C
	private void Update()
	{
		if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.333332f || this.Yandere.NearBodies > 0)
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime);
			if (this.Sprite.color.a > 1f)
			{
				this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
				return;
			}
		}
		else
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
			if (this.Sprite.color.a < 0f)
			{
				this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
			}
		}
	}

	// Token: 0x040016ED RID: 5869
	public YandereScript Yandere;

	// Token: 0x040016EE RID: 5870
	public UISprite Sprite;
}
