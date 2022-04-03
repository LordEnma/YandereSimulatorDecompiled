using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012EC RID: 4844 RVA: 0x000A66B5 File Offset: 0x000A48B5
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001ACA RID: 6858
	public UISprite Sprite;

	// Token: 0x04001ACB RID: 6859
	public float Speed = 0.05f;

	// Token: 0x04001ACC RID: 6860
	public bool MaskedPhoto;
}
