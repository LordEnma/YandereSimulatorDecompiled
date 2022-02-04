using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018A4 RID: 6308 RVA: 0x000F2528 File Offset: 0x000F0728
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018A5 RID: 6309 RVA: 0x000F257C File Offset: 0x000F077C
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002580 RID: 9600
	public UISprite Sprite;

	// Token: 0x04002581 RID: 9601
	public bool Show;
}
