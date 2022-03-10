using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013FC RID: 5116 RVA: 0x000BDDDB File Offset: 0x000BBFDB
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x000BDDE8 File Offset: 0x000BBFE8
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FE RID: 5118 RVA: 0x000BDE45 File Offset: 0x000BC045
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013FF RID: 5119 RVA: 0x000BDE75 File Offset: 0x000BC075
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DCD RID: 7629
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DCE RID: 7630
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DCF RID: 7631
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DD0 RID: 7632
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DD1 RID: 7633
	private InputManagerScript inputManager;
}
