using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x06001401 RID: 5121 RVA: 0x000BDE85 File Offset: 0x000BC085
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x000BDE94 File Offset: 0x000BC094
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x000BDEF1 File Offset: 0x000BC0F1
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x000BDF21 File Offset: 0x000BC121
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DD2 RID: 7634
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DD3 RID: 7635
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DD4 RID: 7636
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DD5 RID: 7637
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DD6 RID: 7638
	private InputManagerScript inputManager;
}
