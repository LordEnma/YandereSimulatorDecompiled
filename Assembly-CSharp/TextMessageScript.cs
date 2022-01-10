using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A63 RID: 6755 RVA: 0x0011A5DC File Offset: 0x001187DC
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

	// Token: 0x06001A64 RID: 6756 RVA: 0x0011A65D File Offset: 0x0011885D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002B95 RID: 11157
	public UILabel Label;

	// Token: 0x04002B96 RID: 11158
	public GameObject Image;

	// Token: 0x04002B97 RID: 11159
	public bool Attachment;

	// Token: 0x04002B98 RID: 11160
	public bool Right;
}
