using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A88 RID: 6792 RVA: 0x0011D01C File Offset: 0x0011B21C
	private void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.SetActive(false);
		}
		if (this.Right && EventGlobals.OsanaConversation)
		{
			base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
			this.Label.color = new Color(1f, 1f, 1f);
		}
	}

	// Token: 0x06001A89 RID: 6793 RVA: 0x0011D09D File Offset: 0x0011B29D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C0C RID: 11276
	public UILabel Label;

	// Token: 0x04002C0D RID: 11277
	public GameObject Image;

	// Token: 0x04002C0E RID: 11278
	public bool Attachment;

	// Token: 0x04002C0F RID: 11279
	public bool Right;
}
