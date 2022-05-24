using System;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012F2 RID: 4850 RVA: 0x000A6FA5 File Offset: 0x000A51A5
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001ADA RID: 6874
	public UISprite Sprite;

	// Token: 0x04001ADB RID: 6875
	public float Speed = 0.05f;

	// Token: 0x04001ADC RID: 6876
	public bool MaskedPhoto;
}
