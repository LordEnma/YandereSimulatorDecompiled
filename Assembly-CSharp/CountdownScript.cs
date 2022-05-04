using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012F0 RID: 4848 RVA: 0x000A6C91 File Offset: 0x000A4E91
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AD3 RID: 6867
	public UISprite Sprite;

	// Token: 0x04001AD4 RID: 6868
	public float Speed = 0.05f;

	// Token: 0x04001AD5 RID: 6869
	public bool MaskedPhoto;
}
