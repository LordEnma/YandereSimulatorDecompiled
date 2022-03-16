using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C4 RID: 1220
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FF2 RID: 8178 RVA: 0x001C4BEC File Offset: 0x001C2DEC
	private void Start()
	{
		Time.timeScale = 1f;
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			this.Labels[this.ID].color = new Color(this.Labels[this.ID].color.r, this.Labels[this.ID].color.g, this.Labels[this.ID].color.b, 0f);
			this.ID++;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (ApplicationGlobals.VersionNumber != this.VersionNumber)
		{
			ApplicationGlobals.VersionNumber = this.VersionNumber;
		}
		if (!Application.CanStreamedLevelBeLoaded("FunScene"))
		{
			Application.Quit();
		}
		if (File.Exists(Application.streamingAssetsPath + "/Fun.txt"))
		{
			this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
		}
		if (this.Text == "0" || this.Text == "1" || this.Text == "2" || this.Text == "3" || this.Text == "4" || this.Text == "5" || this.Text == "6" || this.Text == "7" || this.Text == "8" || this.Text == "9" || this.Text == "10" || this.Text == "69" || this.Text == "666")
		{
			SceneManager.LoadScene("VeryFunScene");
		}
	}

	// Token: 0x06001FF3 RID: 8179 RVA: 0x001C4DF4 File Offset: 0x001C2FF4
	private void Update()
	{
		Input.GetKeyDown(KeyCode.S);
		Input.GetKeyDown(KeyCode.Y);
		if (!this.Continue)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a <= 0f)
			{
				Input.GetKeyDown(KeyCode.W);
				if (Input.anyKeyDown)
				{
					this.Speed += 1f;
				}
				if (this.CurrentLabel < this.Labels.Length)
				{
					this.Labels[this.CurrentLabel].color = new Color(this.Labels[this.CurrentLabel].color.r, this.Labels[this.CurrentLabel].color.g, this.Labels[this.CurrentLabel].color.b, this.Labels[this.CurrentLabel].color.a + Time.deltaTime * this.Speed);
					if (this.Labels[this.CurrentLabel].color.a >= 1f)
					{
						this.CurrentLabel++;
						return;
					}
				}
				else if (Input.anyKeyDown)
				{
					this.Darkness.color = new Color(1f, 1f, 1f, 0f);
					this.Continue = true;
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
	}

	// Token: 0x0400432E RID: 17198
	public JsonScript JSON;

	// Token: 0x0400432F RID: 17199
	public GameObject WelcomePanel;

	// Token: 0x04004330 RID: 17200
	public UILabel[] FlashingLabels;

	// Token: 0x04004331 RID: 17201
	public UILabel AltBeginLabel;

	// Token: 0x04004332 RID: 17202
	public UILabel BeginLabel;

	// Token: 0x04004333 RID: 17203
	public UILabel[] Labels;

	// Token: 0x04004334 RID: 17204
	public UISprite Darkness;

	// Token: 0x04004335 RID: 17205
	public bool Continue;

	// Token: 0x04004336 RID: 17206
	public bool FlashRed;

	// Token: 0x04004337 RID: 17207
	public float VersionNumber;

	// Token: 0x04004338 RID: 17208
	public float Timer;

	// Token: 0x04004339 RID: 17209
	public float Speed = 1f;

	// Token: 0x0400433A RID: 17210
	public string Text;

	// Token: 0x0400433B RID: 17211
	public int CurrentLabel = 1;

	// Token: 0x0400433C RID: 17212
	public int ID;
}
