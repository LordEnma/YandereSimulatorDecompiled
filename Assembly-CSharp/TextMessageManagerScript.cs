using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001AF5C4 File Offset: 0x001AD7C4
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

	// Token: 0x06001EAE RID: 7854 RVA: 0x001AF66C File Offset: 0x001AD86C
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

	// Token: 0x04003F61 RID: 16225
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F62 RID: 16226
	public PromptBarScript PromptBar;

	// Token: 0x04003F63 RID: 16227
	public GameObject ServicesMenu;

	// Token: 0x04003F64 RID: 16228
	public string[] Messages;

	// Token: 0x04003F65 RID: 16229
	private GameObject NewMessage;

	// Token: 0x04003F66 RID: 16230
	public GameObject Message;

	// Token: 0x04003F67 RID: 16231
	public int MessageHeight;

	// Token: 0x04003F68 RID: 16232
	public string MessageText = string.Empty;
}
