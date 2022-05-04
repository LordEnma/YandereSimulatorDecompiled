using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029A RID: 666
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x06001403 RID: 5123 RVA: 0x000BE806 File Offset: 0x000BCA06
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x000BE81C File Offset: 0x000BCA1C
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x000BE87C File Offset: 0x000BCA7C
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x000BE8D9 File Offset: 0x000BCAD9
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BE8FC File Offset: 0x000BCAFC
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

	// Token: 0x06001408 RID: 5128 RVA: 0x000BE9EB File Offset: 0x000BCBEB
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE4 RID: 7652
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE5 RID: 7653
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DE6 RID: 7654
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DE7 RID: 7655
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DE8 RID: 7656
	private int buttonIndex;

	// Token: 0x04001DE9 RID: 7657
	private const int ButtonCount = 3;

	// Token: 0x04001DEA RID: 7658
	private InputManagerScript inputManager;
}
