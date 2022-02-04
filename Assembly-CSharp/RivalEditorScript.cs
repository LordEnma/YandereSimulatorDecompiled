using System;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F4 RID: 5108 RVA: 0x000BD419 File Offset: 0x000BB619
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000BD428 File Offset: 0x000BB628
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x000BD485 File Offset: 0x000BB685
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x000BD4B5 File Offset: 0x000BB6B5
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DB5 RID: 7605
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DB6 RID: 7606
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DB7 RID: 7607
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DB8 RID: 7608
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB9 RID: 7609
	private InputManagerScript inputManager;
}
