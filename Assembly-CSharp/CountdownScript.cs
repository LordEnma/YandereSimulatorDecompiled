using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E9 RID: 4841 RVA: 0x000A61F9 File Offset: 0x000A43F9
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001AC1 RID: 6849
	public UISprite Sprite;

	// Token: 0x04001AC2 RID: 6850
	public float Speed = 0.05f;

	// Token: 0x04001AC3 RID: 6851
	public bool MaskedPhoto;
}
