using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C9 RID: 1225
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x0600200D RID: 8205 RVA: 0x001C7270 File Offset: 0x001C5470
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

	// Token: 0x0600200E RID: 8206 RVA: 0x001C7478 File Offset: 0x001C5678
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

	// Token: 0x04004373 RID: 17267
	public JsonScript JSON;

	// Token: 0x04004374 RID: 17268
	public GameObject WelcomePanel;

	// Token: 0x04004375 RID: 17269
	public UILabel[] FlashingLabels;

	// Token: 0x04004376 RID: 17270
	public UILabel AltBeginLabel;

	// Token: 0x04004377 RID: 17271
	public UILabel BeginLabel;

	// Token: 0x04004378 RID: 17272
	public UILabel[] Labels;

	// Token: 0x04004379 RID: 17273
	public UISprite Darkness;

	// Token: 0x0400437A RID: 17274
	public bool Continue;

	// Token: 0x0400437B RID: 17275
	public bool FlashRed;

	// Token: 0x0400437C RID: 17276
	public float VersionNumber;

	// Token: 0x0400437D RID: 17277
	public float Timer;

	// Token: 0x0400437E RID: 17278
	public float Speed = 1f;

	// Token: 0x0400437F RID: 17279
	public string Text;

	// Token: 0x04004380 RID: 17280
	public int CurrentLabel = 1;

	// Token: 0x04004381 RID: 17281
	public int ID;
}
