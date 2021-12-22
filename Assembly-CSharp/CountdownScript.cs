using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E7 RID: 4839 RVA: 0x000A5B8D File Offset: 0x000A3D8D
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AAC RID: 6828
	public UISprite Sprite;

	// Token: 0x04001AAD RID: 6829
	public float Speed = 0.05f;

	// Token: 0x04001AAE RID: 6830
	public bool MaskedPhoto;
}
