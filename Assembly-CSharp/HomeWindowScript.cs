using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018BB RID: 6331 RVA: 0x000F3894 File Offset: 0x000F1A94
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x000F38E8 File Offset: 0x000F1AE8
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025BD RID: 9661
	public UISprite Sprite;

	// Token: 0x040025BE RID: 9662
	public bool Show;
}
