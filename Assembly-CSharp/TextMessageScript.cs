using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A8E RID: 6798 RVA: 0x0011D1C8 File Offset: 0x0011B3C8
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

	// Token: 0x06001A8F RID: 6799 RVA: 0x0011D249 File Offset: 0x0011B449
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C0F RID: 11279
	public UILabel Label;

	// Token: 0x04002C10 RID: 11280
	public GameObject Image;

	// Token: 0x04002C11 RID: 11281
	public bool Attachment;

	// Token: 0x04002C12 RID: 11282
	public bool Right;
}
