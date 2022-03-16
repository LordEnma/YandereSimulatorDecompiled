using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EBD RID: 7869 RVA: 0x001B0CD0 File Offset: 0x001AEED0
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

	// Token: 0x06001EBE RID: 7870 RVA: 0x001B0D78 File Offset: 0x001AEF78
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

	// Token: 0x04003FAB RID: 16299
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FAC RID: 16300
	public PromptBarScript PromptBar;

	// Token: 0x04003FAD RID: 16301
	public GameObject ServicesMenu;

	// Token: 0x04003FAE RID: 16302
	public string[] Messages;

	// Token: 0x04003FAF RID: 16303
	private GameObject NewMessage;

	// Token: 0x04003FB0 RID: 16304
	public GameObject Message;

	// Token: 0x04003FB1 RID: 16305
	public int MessageHeight;

	// Token: 0x04003FB2 RID: 16306
	public string MessageText = string.Empty;
}
