using System;
using UnityEngine;

// Token: 0x02000298 RID: 664
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F0 RID: 5104 RVA: 0x000BCEB1 File Offset: 0x000BB0B1
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BCEC0 File Offset: 0x000BB0C0
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x000BCF1D File Offset: 0x000BB11D
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F3 RID: 5107 RVA: 0x000BCF4D File Offset: 0x000BB14D
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAA RID: 7594
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAB RID: 7595
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DAC RID: 7596
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DAD RID: 7597
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DAE RID: 7598
	private InputManagerScript inputManager;
}
