using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018A3 RID: 6307 RVA: 0x000F205C File Offset: 0x000F025C
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F20B0 File Offset: 0x000F02B0
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0400257A RID: 9594
	public UISprite Sprite;

	// Token: 0x0400257B RID: 9595
	public bool Show;
}
