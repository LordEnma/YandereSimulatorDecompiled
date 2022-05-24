using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029B RID: 667
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x06001405 RID: 5125 RVA: 0x000BEB12 File Offset: 0x000BCD12
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x000BEB28 File Offset: 0x000BCD28
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BEB88 File Offset: 0x000BCD88
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000BEBE5 File Offset: 0x000BCDE5
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x000BEC08 File Offset: 0x000BCE08
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

	// Token: 0x0600140A RID: 5130 RVA: 0x000BECF7 File Offset: 0x000BCEF7
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DEB RID: 7659
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DEC RID: 7660
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DED RID: 7661
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DEE RID: 7662
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DEF RID: 7663
	private int buttonIndex;

	// Token: 0x04001DF0 RID: 7664
	private const int ButtonCount = 3;

	// Token: 0x04001DF1 RID: 7665
	private InputManagerScript inputManager;
}
