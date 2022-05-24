using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B5B98 File Offset: 0x001B3D98
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			UnityEngine.Object.Destroy(this.NewMessage);
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.Sideways = true;
			this.ServicesMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B5C40 File Offset: 0x001B3E40
	public void SpawnMessage(int ServiceID)
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[1].text = "Exit";
		this.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.ServicesMenu.SetActive(false);
		base.gameObject.SetActive(true);
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
		this.NewMessage.transform.parent = base.transform;
		this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		this.NewMessage.transform.localEulerAngles = Vector3.zero;
		this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		this.MessageText = this.Messages[ServiceID];
		if (ServiceID == 7 || ServiceID == 4)
		{
			this.MessageHeight = 11;
		}
		else if (ServiceID == 9)
		{
			this.MessageHeight = 6;
		}
		else
		{
			this.MessageHeight = 5;
		}
		this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * this.MessageHeight;
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.MessageText;
	}

	// Token: 0x04004028 RID: 16424
	public PauseScreenScript PauseScreen;

	// Token: 0x04004029 RID: 16425
	public PromptBarScript PromptBar;

	// Token: 0x0400402A RID: 16426
	public GameObject ServicesMenu;

	// Token: 0x0400402B RID: 16427
	public string[] Messages;

	// Token: 0x0400402C RID: 16428
	private GameObject NewMessage;

	// Token: 0x0400402D RID: 16429
	public GameObject Message;

	// Token: 0x0400402E RID: 16430
	public int MessageHeight;

	// Token: 0x0400402F RID: 16431
	public string MessageText = string.Empty;
}
