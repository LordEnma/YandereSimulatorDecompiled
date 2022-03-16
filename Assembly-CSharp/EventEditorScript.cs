using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013FF RID: 5119 RVA: 0x000BE1F3 File Offset: 0x000BC3F3
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001400 RID: 5120 RVA: 0x000BE200 File Offset: 0x000BC400
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x000BE25D File Offset: 0x000BC45D
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x000BE28D File Offset: 0x000BC48D
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DDC RID: 7644
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DDD RID: 7645
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DDE RID: 7646
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DDF RID: 7647
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE0 RID: 7648
	private InputManagerScript inputManager;
}
