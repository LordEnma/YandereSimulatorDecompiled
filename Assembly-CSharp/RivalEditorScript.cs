using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x06001405 RID: 5125 RVA: 0x000BE3A9 File Offset: 0x000BC5A9
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x000BE3B8 File Offset: 0x000BC5B8
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BE415 File Offset: 0x000BC615
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000BE445 File Offset: 0x000BC645
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE4 RID: 7652
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE5 RID: 7653
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DE6 RID: 7654
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DE7 RID: 7655
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE8 RID: 7656
	private InputManagerScript inputManager;
}
