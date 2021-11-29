using System;
using UnityEngine;

// Token: 0x02000398 RID: 920
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A52 RID: 6738 RVA: 0x00119778 File Offset: 0x00117978
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

	// Token: 0x06001A53 RID: 6739 RVA: 0x001197F9 File Offset: 0x001179F9
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002B61 RID: 11105
	public UILabel Label;

	// Token: 0x04002B62 RID: 11106
	public GameObject Image;

	// Token: 0x04002B63 RID: 11107
	public bool Attachment;

	// Token: 0x04002B64 RID: 11108
	public bool Right;
}
