using System;
using UnityEngine;

// Token: 0x02000239 RID: 569
public class CautionScript : MonoBehaviour
{
	// Token: 0x0600122F RID: 4655 RVA: 0x0008B5B4 File Offset: 0x000897B4
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
		if (GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001230 RID: 4656 RVA: 0x0008B61C File Offset: 0x0008981C
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

	// Token: 0x040016D7 RID: 5847
	public YandereScript Yandere;

	// Token: 0x040016D8 RID: 5848
	public UISprite Sprite;
}
