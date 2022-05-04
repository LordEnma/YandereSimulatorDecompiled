using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004CA RID: 1226
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06002017 RID: 8215 RVA: 0x001C8728 File Offset: 0x001C6928
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

	// Token: 0x06002018 RID: 8216 RVA: 0x001C8930 File Offset: 0x001C6B30
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

	// Token: 0x04004389 RID: 17289
	public JsonScript JSON;

	// Token: 0x0400438A RID: 17290
	public GameObject WelcomePanel;

	// Token: 0x0400438B RID: 17291
	public UILabel[] FlashingLabels;

	// Token: 0x0400438C RID: 17292
	public UILabel AltBeginLabel;

	// Token: 0x0400438D RID: 17293
	public UILabel BeginLabel;

	// Token: 0x0400438E RID: 17294
	public UILabel[] Labels;

	// Token: 0x0400438F RID: 17295
	public UISprite Darkness;

	// Token: 0x04004390 RID: 17296
	public bool Continue;

	// Token: 0x04004391 RID: 17297
	public bool FlashRed;

	// Token: 0x04004392 RID: 17298
	public float VersionNumber;

	// Token: 0x04004393 RID: 17299
	public float Timer;

	// Token: 0x04004394 RID: 17300
	public float Speed = 1f;

	// Token: 0x04004395 RID: 17301
	public string Text;

	// Token: 0x04004396 RID: 17302
	public int CurrentLabel = 1;

	// Token: 0x04004397 RID: 17303
	public int ID;
}
