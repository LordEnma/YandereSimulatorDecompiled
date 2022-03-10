using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A77 RID: 6775 RVA: 0x0011BEAC File Offset: 0x0011A0AC
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

	// Token: 0x06001A78 RID: 6776 RVA: 0x0011BF2D File Offset: 0x0011A12D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002BCE RID: 11214
	public UILabel Label;

	// Token: 0x04002BCF RID: 11215
	public GameObject Image;

	// Token: 0x04002BD0 RID: 11216
	public bool Attachment;

	// Token: 0x04002BD1 RID: 11217
	public bool Right;
}
