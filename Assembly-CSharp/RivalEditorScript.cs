using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x06001404 RID: 5124 RVA: 0x000BE29D File Offset: 0x000BC49D
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x000BE2AC File Offset: 0x000BC4AC
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x000BE309 File Offset: 0x000BC509
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BE339 File Offset: 0x000BC539
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE1 RID: 7649
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE2 RID: 7650
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DE3 RID: 7651
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DE4 RID: 7652
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE5 RID: 7653
	private InputManagerScript inputManager;
}
