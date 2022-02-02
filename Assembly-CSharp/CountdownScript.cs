using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E8 RID: 4840 RVA: 0x000A5F3D File Offset: 0x000A413D
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AB3 RID: 6835
	public UISprite Sprite;

	// Token: 0x04001AB4 RID: 6836
	public float Speed = 0.05f;

	// Token: 0x04001AB5 RID: 6837
	public bool MaskedPhoto;
}
