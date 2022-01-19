using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E7 RID: 4839 RVA: 0x000A5DED File Offset: 0x000A3FED
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AB0 RID: 6832
	public UISprite Sprite;

	// Token: 0x04001AB1 RID: 6833
	public float Speed = 0.05f;

	// Token: 0x04001AB2 RID: 6834
	public bool MaskedPhoto;
}
