using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EDE RID: 7902 RVA: 0x001B4494 File Offset: 0x001B2694
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

	// Token: 0x06001EDF RID: 7903 RVA: 0x001B453C File Offset: 0x001B273C
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

	// Token: 0x04004001 RID: 16385
	public PauseScreenScript PauseScreen;

	// Token: 0x04004002 RID: 16386
	public PromptBarScript PromptBar;

	// Token: 0x04004003 RID: 16387
	public GameObject ServicesMenu;

	// Token: 0x04004004 RID: 16388
	public string[] Messages;

	// Token: 0x04004005 RID: 16389
	private GameObject NewMessage;

	// Token: 0x04004006 RID: 16390
	public GameObject Message;

	// Token: 0x04004007 RID: 16391
	public int MessageHeight;

	// Token: 0x04004008 RID: 16392
	public string MessageText = string.Empty;
}
