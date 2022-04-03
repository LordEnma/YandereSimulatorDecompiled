using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x06001400 RID: 5120 RVA: 0x000BE2FF File Offset: 0x000BC4FF
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x000BE30C File Offset: 0x000BC50C
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x000BE369 File Offset: 0x000BC569
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x000BE399 File Offset: 0x000BC599
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DDF RID: 7647
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE0 RID: 7648
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DE1 RID: 7649
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DE2 RID: 7650
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE3 RID: 7651
	private InputManagerScript inputManager;
}
