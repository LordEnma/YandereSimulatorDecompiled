using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BF RID: 1215
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FD6 RID: 8150 RVA: 0x001C25A4 File Offset: 0x001C07A4
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

	// Token: 0x06001FD7 RID: 8151 RVA: 0x001C27AC File Offset: 0x001C09AC
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

	// Token: 0x040042B7 RID: 17079
	public JsonScript JSON;

	// Token: 0x040042B8 RID: 17080
	public GameObject WelcomePanel;

	// Token: 0x040042B9 RID: 17081
	public UILabel[] FlashingLabels;

	// Token: 0x040042BA RID: 17082
	public UILabel AltBeginLabel;

	// Token: 0x040042BB RID: 17083
	public UILabel BeginLabel;

	// Token: 0x040042BC RID: 17084
	public UILabel[] Labels;

	// Token: 0x040042BD RID: 17085
	public UISprite Darkness;

	// Token: 0x040042BE RID: 17086
	public bool Continue;

	// Token: 0x040042BF RID: 17087
	public bool FlashRed;

	// Token: 0x040042C0 RID: 17088
	public float VersionNumber;

	// Token: 0x040042C1 RID: 17089
	public float Timer;

	// Token: 0x040042C2 RID: 17090
	public float Speed = 1f;

	// Token: 0x040042C3 RID: 17091
	public string Text;

	// Token: 0x040042C4 RID: 17092
	public int CurrentLabel = 1;

	// Token: 0x040042C5 RID: 17093
	public int ID;
}
