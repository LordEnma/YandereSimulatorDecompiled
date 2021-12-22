using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x0600189D RID: 6301 RVA: 0x000F1974 File Offset: 0x000EFB74
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x000F19C8 File Offset: 0x000EFBC8
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0400256F RID: 9583
	public UISprite Sprite;

	// Token: 0x04002570 RID: 9584
	public bool Show;
}
