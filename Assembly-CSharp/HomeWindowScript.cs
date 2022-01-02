using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x0600189F RID: 6303 RVA: 0x000F1C28 File Offset: 0x000EFE28
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018A0 RID: 6304 RVA: 0x000F1C7C File Offset: 0x000EFE7C
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002573 RID: 9587
	public UISprite Sprite;

	// Token: 0x04002574 RID: 9588
	public bool Show;
}
