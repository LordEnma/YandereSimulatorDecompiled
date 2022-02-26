using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x06001401 RID: 5121 RVA: 0x000BDD1D File Offset: 0x000BBF1D
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x000BDD2C File Offset: 0x000BBF2C
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x000BDD89 File Offset: 0x000BBF89
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x000BDDB9 File Offset: 0x000BBFB9
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DC9 RID: 7625
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DCA RID: 7626
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DCB RID: 7627
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DCC RID: 7628
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DCD RID: 7629
	private InputManagerScript inputManager;
}
