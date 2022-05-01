using System;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x0600140F RID: 5135 RVA: 0x000BEAD9 File Offset: 0x000BCCD9
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001410 RID: 5136 RVA: 0x000BEAE8 File Offset: 0x000BCCE8
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001411 RID: 5137 RVA: 0x000BEB45 File Offset: 0x000BCD45
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001412 RID: 5138 RVA: 0x000BEB75 File Offset: 0x000BCD75
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DF0 RID: 7664
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DF1 RID: 7665
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DF2 RID: 7666
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DF3 RID: 7667
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DF4 RID: 7668
	private InputManagerScript inputManager;
}
