using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x06001406 RID: 5126 RVA: 0x000BE58B File Offset: 0x000BC78B
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BE598 File Offset: 0x000BC798
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000BE5F5 File Offset: 0x000BC7F5
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x000BE625 File Offset: 0x000BC825
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE2 RID: 7650
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE3 RID: 7651
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DE4 RID: 7652
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DE5 RID: 7653
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE6 RID: 7654
	private InputManagerScript inputManager;
}
