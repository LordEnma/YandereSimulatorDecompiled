using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BC RID: 1212
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FBD RID: 8125 RVA: 0x001BFE5C File Offset: 0x001BE05C
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

	// Token: 0x06001FBE RID: 8126 RVA: 0x001C0064 File Offset: 0x001BE264
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

	// Token: 0x04004286 RID: 17030
	public JsonScript JSON;

	// Token: 0x04004287 RID: 17031
	public GameObject WelcomePanel;

	// Token: 0x04004288 RID: 17032
	public UILabel[] FlashingLabels;

	// Token: 0x04004289 RID: 17033
	public UILabel AltBeginLabel;

	// Token: 0x0400428A RID: 17034
	public UILabel BeginLabel;

	// Token: 0x0400428B RID: 17035
	public UILabel[] Labels;

	// Token: 0x0400428C RID: 17036
	public UISprite Darkness;

	// Token: 0x0400428D RID: 17037
	public bool Continue;

	// Token: 0x0400428E RID: 17038
	public bool FlashRed;

	// Token: 0x0400428F RID: 17039
	public float VersionNumber;

	// Token: 0x04004290 RID: 17040
	public float Timer;

	// Token: 0x04004291 RID: 17041
	public float Speed = 1f;

	// Token: 0x04004292 RID: 17042
	public string Text;

	// Token: 0x04004293 RID: 17043
	public int CurrentLabel = 1;

	// Token: 0x04004294 RID: 17044
	public int ID;
}
