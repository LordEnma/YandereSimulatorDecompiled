using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B3124 File Offset: 0x001B1324
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

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B31CC File Offset: 0x001B13CC
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

	// Token: 0x04003FEB RID: 16363
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FEC RID: 16364
	public PromptBarScript PromptBar;

	// Token: 0x04003FED RID: 16365
	public GameObject ServicesMenu;

	// Token: 0x04003FEE RID: 16366
	public string[] Messages;

	// Token: 0x04003FEF RID: 16367
	private GameObject NewMessage;

	// Token: 0x04003FF0 RID: 16368
	public GameObject Message;

	// Token: 0x04003FF1 RID: 16369
	public int MessageHeight;

	// Token: 0x04003FF2 RID: 16370
	public string MessageText = string.Empty;
}
