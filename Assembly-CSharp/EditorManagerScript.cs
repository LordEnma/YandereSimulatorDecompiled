using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029A RID: 666
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013FF RID: 5119 RVA: 0x000BE212 File Offset: 0x000BC412
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001400 RID: 5120 RVA: 0x000BE228 File Offset: 0x000BC428
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x000BE288 File Offset: 0x000BC488
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x000BE2E5 File Offset: 0x000BC4E5
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x000BE308 File Offset: 0x000BC508
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			SceneManager.LoadScene("NewTitleScene");
		}
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.buttonIndex = ((this.buttonIndex > 0) ? (this.buttonIndex - 1) : 2);
		}
		else if (tappedDown)
		{
			this.buttonIndex = ((this.buttonIndex < 2) ? (this.buttonIndex + 1) : 0);
		}
		if (tappedUp || tappedDown)
		{
			Transform transform = this.cursorLabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x, 100f - (float)this.buttonIndex * 100f, transform.localPosition.z);
		}
		if (Input.GetButtonDown("A"))
		{
			this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
			this.mainPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x000BE3F7 File Offset: 0x000BC5F7
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DDA RID: 7642
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DDB RID: 7643
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DDC RID: 7644
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DDD RID: 7645
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DDE RID: 7646
	private int buttonIndex;

	// Token: 0x04001DDF RID: 7647
	private const int ButtonCount = 3;

	// Token: 0x04001DE0 RID: 7648
	private InputManagerScript inputManager;
}
