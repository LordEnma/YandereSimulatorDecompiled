using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A92 RID: 6802 RVA: 0x0011D4D0 File Offset: 0x0011B6D0
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

	// Token: 0x06001A93 RID: 6803 RVA: 0x0011D551 File Offset: 0x0011B751
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C17 RID: 11287
	public UILabel Label;

	// Token: 0x04002C18 RID: 11288
	public GameObject Image;

	// Token: 0x04002C19 RID: 11289
	public bool Attachment;

	// Token: 0x04002C1A RID: 11290
	public bool Right;
}
