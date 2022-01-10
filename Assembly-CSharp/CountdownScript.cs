using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E7 RID: 4839 RVA: 0x000A5DAD File Offset: 0x000A3FAD
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AAE RID: 6830
	public UISprite Sprite;

	// Token: 0x04001AAF RID: 6831
	public float Speed = 0.05f;

	// Token: 0x04001AB0 RID: 6832
	public bool MaskedPhoto;
}
