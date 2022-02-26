using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A76 RID: 6774 RVA: 0x0011BAD4 File Offset: 0x00119CD4
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

	// Token: 0x06001A77 RID: 6775 RVA: 0x0011BB55 File Offset: 0x00119D55
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002BB8 RID: 11192
	public UILabel Label;

	// Token: 0x04002BB9 RID: 11193
	public GameObject Image;

	// Token: 0x04002BBA RID: 11194
	public bool Attachment;

	// Token: 0x04002BBB RID: 11195
	public bool Right;
}
