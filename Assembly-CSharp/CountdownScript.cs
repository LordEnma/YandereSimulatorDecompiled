using System;
using UnityEngine;

// Token: 0x02000260 RID: 608
public class CountdownScript : MonoBehaviour
{
	// Token: 0x060012E0 RID: 4832 RVA: 0x000A56E9 File Offset: 0x000A38E9
	private void Update()
	{
		this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0f, Time.deltaTime * this.Speed);
	}

	// Token: 0x04001A93 RID: 6803
	public UISprite Sprite;

	// Token: 0x04001A94 RID: 6804
	public float Speed = 0.05f;

	// Token: 0x04001A95 RID: 6805
	public bool MaskedPhoto;
}
