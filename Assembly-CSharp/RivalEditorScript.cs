using System;
using UnityEngine;

// Token: 0x0200029D RID: 669
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x06001411 RID: 5137 RVA: 0x000BED19 File Offset: 0x000BCF19
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001412 RID: 5138 RVA: 0x000BED28 File Offset: 0x000BCF28
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001413 RID: 5139 RVA: 0x000BED85 File Offset: 0x000BCF85
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001414 RID: 5140 RVA: 0x000BEDB5 File Offset: 0x000BCFB5
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DF7 RID: 7671
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DF8 RID: 7672
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DF9 RID: 7673
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DFA RID: 7674
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DFB RID: 7675
	private InputManagerScript inputManager;
}
