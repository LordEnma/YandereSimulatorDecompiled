using System;
using UnityEngine;

// Token: 0x02000239 RID: 569
public class CautionScript : MonoBehaviour
{
	// Token: 0x0600122F RID: 4655 RVA: 0x0008B4E0 File Offset: 0x000896E0
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
		if (GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001230 RID: 4656 RVA: 0x0008B548 File Offset: 0x00089748
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

	// Token: 0x040016D4 RID: 5844
	public YandereScript Yandere;

	// Token: 0x040016D5 RID: 5845
	public UISprite Sprite;
}
