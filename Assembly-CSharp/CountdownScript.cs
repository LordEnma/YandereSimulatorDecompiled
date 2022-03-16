using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012EB RID: 4843 RVA: 0x000A6605 File Offset: 0x000A4805
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AC7 RID: 6855
	public UISprite Sprite;

	// Token: 0x04001AC8 RID: 6856
	public float Speed = 0.05f;

	// Token: 0x04001AC9 RID: 6857
	public bool MaskedPhoto;
}
