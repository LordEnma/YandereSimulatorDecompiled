using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000295 RID: 661
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013DD RID: 5085 RVA: 0x000BC676 File Offset: 0x000BA876
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013DE RID: 5086 RVA: 0x000BC68C File Offset: 0x000BA88C
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013DF RID: 5087 RVA: 0x000BC6EC File Offset: 0x000BA8EC
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013E0 RID: 5088 RVA: 0x000BC749 File Offset: 0x000BA949
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013E1 RID: 5089 RVA: 0x000BC76C File Offset: 0x000BA96C
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

	// Token: 0x060013E2 RID: 5090 RVA: 0x000BC85B File Offset: 0x000BAA5B
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001D7E RID: 7550
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001D7F RID: 7551
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001D80 RID: 7552
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001D81 RID: 7553
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001D82 RID: 7554
	private int buttonIndex;

	// Token: 0x04001D83 RID: 7555
	private const int ButtonCount = 3;

	// Token: 0x04001D84 RID: 7556
	private InputManagerScript inputManager;
}
