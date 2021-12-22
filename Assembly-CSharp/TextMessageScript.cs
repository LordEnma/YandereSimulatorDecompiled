using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A5A RID: 6746 RVA: 0x00119FB8 File Offset: 0x001181B8
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

	// Token: 0x06001A5B RID: 6747 RVA: 0x0011A039 File Offset: 0x00118239
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002B8B RID: 11147
	public UILabel Label;

	// Token: 0x04002B8C RID: 11148
	public GameObject Image;

	// Token: 0x04002B8D RID: 11149
	public bool Attachment;

	// Token: 0x04002B8E RID: 11150
	public bool Right;
}
