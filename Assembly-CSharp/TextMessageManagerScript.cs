using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EA1 RID: 7841 RVA: 0x001AE360 File Offset: 0x001AC560
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

	// Token: 0x06001EA2 RID: 7842 RVA: 0x001AE408 File Offset: 0x001AC608
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

	// Token: 0x04003F3A RID: 16186
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F3B RID: 16187
	public PromptBarScript PromptBar;

	// Token: 0x04003F3C RID: 16188
	public GameObject ServicesMenu;

	// Token: 0x04003F3D RID: 16189
	public string[] Messages;

	// Token: 0x04003F3E RID: 16190
	private GameObject NewMessage;

	// Token: 0x04003F3F RID: 16191
	public GameObject Message;

	// Token: 0x04003F40 RID: 16192
	public int MessageHeight;

	// Token: 0x04003F41 RID: 16193
	public string MessageText = string.Empty;
}
