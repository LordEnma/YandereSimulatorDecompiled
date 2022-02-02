using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000297 RID: 663
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013E8 RID: 5096 RVA: 0x000BD166 File Offset: 0x000BB366
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x000BD17C File Offset: 0x000BB37C
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x000BD1DC File Offset: 0x000BB3DC
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x000BD239 File Offset: 0x000BB439
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x000BD25C File Offset: 0x000BB45C
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

	// Token: 0x060013ED RID: 5101 RVA: 0x000BD34B File Offset: 0x000BB54B
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DA8 RID: 7592
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DA9 RID: 7593
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DAA RID: 7594
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DAB RID: 7595
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DAC RID: 7596
	private int buttonIndex;

	// Token: 0x04001DAD RID: 7597
	private const int ButtonCount = 3;

	// Token: 0x04001DAE RID: 7598
	private InputManagerScript inputManager;
}
