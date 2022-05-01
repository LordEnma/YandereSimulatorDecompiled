using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018CF RID: 6351 RVA: 0x000F4788 File Offset: 0x000F2988
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018D0 RID: 6352 RVA: 0x000F47DC File Offset: 0x000F29DC
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x040025E4 RID: 9700
	public UISprite Sprite;

	// Token: 0x040025E5 RID: 9701
	public bool Show;
}
