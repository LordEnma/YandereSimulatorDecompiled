using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E8 RID: 4840 RVA: 0x000A5FE1 File Offset: 0x000A41E1
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AB6 RID: 6838
	public UISprite Sprite;

	// Token: 0x04001AB7 RID: 6839
	public float Speed = 0.05f;

	// Token: 0x04001AB8 RID: 6840
	public bool MaskedPhoto;
}
