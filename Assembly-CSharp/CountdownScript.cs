using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E9 RID: 4841 RVA: 0x000A5E75 File Offset: 0x000A4075
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AB7 RID: 6839
	public UISprite Sprite;

	// Token: 0x04001AB8 RID: 6840
	public float Speed = 0.05f;

	// Token: 0x04001AB9 RID: 6841
	public bool MaskedPhoto;
}
