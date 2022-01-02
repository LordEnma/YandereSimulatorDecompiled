using System;
using UnityEngine;

// Token: 0x02000298 RID: 664
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F0 RID: 5104 RVA: 0x000BD0F9 File Offset: 0x000BB2F9
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BD108 File Offset: 0x000BB308
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x000BD165 File Offset: 0x000BB365
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F3 RID: 5107 RVA: 0x000BD195 File Offset: 0x000BB395
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAD RID: 7597
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAE RID: 7598
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DAF RID: 7599
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DB0 RID: 7600
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB1 RID: 7601
	private InputManagerScript inputManager;
}
