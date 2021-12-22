using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002D4 RID: 724
public class FunScript : MonoBehaviour
{
	// Token: 0x060014B3 RID: 5299 RVA: 0x000CB0A0 File Offset: 0x000C92A0
	private void Start()
	{
		if (PlayerPrefs.GetInt("DebugNumber") > 0)
		{
			if (PlayerPrefs.GetInt("DebugNumber") > 10)
			{
				PlayerPrefs.SetInt("DebugNumber", 0);
			}
			this.DebugNumber = PlayerPrefs.GetInt("DebugNumber");
		}
		if (this.VeryFun)
		{
			if (this.DebugNumber != -1)
			{
				this.Text = (this.DebugNumber.ToString() ?? "");
			}
			else
			{
				this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
			}
			if (this.Text == "0")
			{
				this.ID = 0;
			}
			else if (this.Text == "1")
			{
				this.ID = 1;
			}
			else if (this.Text == "2")
			{
				this.ID = 2;
			}
			else if (this.Text == "3")
			{
				this.ID = 3;
			}
			else if (this.Text == "4")
			{
				this.ID = 4;
			}
			else if (this.Text == "5")
			{
				this.ID = 5;
			}
			else if (this.Text == "6")
			{
				this.ID = 6;
			}
			else if (this.Text == "7")
			{
				this.ID = 7;
			}
			else if (this.Text == "8")
			{
				this.ID = 8;
			}
			else if (this.Text == "9")
			{
				this.ID = 9;
			}
			else if (this.Text == "10")
			{
				this.ID = 10;
			}
			else if (this.Text == "69")
			{
				this.Label.text = "( ͡° ͜ʖ ͡°) ";
				this.ID = 8;
			}
			else if (this.Text == "666")
			{
				this.Label.text = "Sometimes, I lie. It's just too fun. You eat up everything I say. I wonder what else I can trick you into believing? ";
				this.Girl.color = new Color(1f, 0f, 0f, 0f);
				this.Label.color = new Color(1f, 0f, 0f, 1f);
				this.ID = 5;
			}
			else
			{
				Debug.Log("Booting the player back to the WelcomeScene.");
				Application.LoadLevel("WelcomeScene");
			}
		}
		if (this.Text != "666" && this.Text != "69")
		{
			this.Label.text = this.Lines[this.ID];
		}
		if (SceneManager.GetActiveScene().name == "VeryFunScene" || this.Text == "666")
		{
			this.G = 0f;
			this.B = 0f;
			this.Label.color = new Color(this.R, this.G, this.B, 1f);
			this.Skip.SetActive(false);
		}
		this.Skip.SetActive(false);
		this.Controls.SetActive(false);
		this.Label.gameObject.SetActive(false);
		this.Girl.color = new Color(this.R, this.G, this.B, 0f);
	}

	// Token: 0x060014B4 RID: 5300 RVA: 0x000CB430 File Offset: 0x000C9630
	private void Update()
	{
		if (Input.GetKeyDown(",") && PlayerPrefs.GetInt("DebugNumber") > 0)
		{
			PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") - 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown(".") && PlayerPrefs.GetInt("DebugNumber") < 10)
		{
			PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") + 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 3f)
		{
			if (!this.Typewriter.mActive)
			{
				this.Controls.SetActive(true);
			}
		}
		else if (this.Timer > 2f)
		{
			this.Girl.mainTexture = this.Portraits[this.ID];
			this.Label.gameObject.SetActive(true);
		}
		else if (this.Timer > 1f)
		{
			this.Girl.color = new Color(this.R, this.G, this.B, Mathf.MoveTowards(this.Girl.color.a, 1f, Time.deltaTime));
		}
		if (this.Controls.activeInHierarchy)
		{
			if (Input.GetButtonDown("B"))
			{
				if (this.Skip.activeInHierarchy)
				{
					this.ID = 19;
					this.Skip.SetActive(false);
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mFullText = this.Lines[this.ID];
					return;
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ID < this.Lines.Length - 1 && !this.VeryFun)
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
						return;
					}
					this.ID++;
					if (this.ID == 19)
					{
						this.Skip.SetActive(false);
					}
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mFullText = this.Lines[this.ID];
					return;
				}
				else
				{
					Application.Quit();
				}
			}
		}
	}

	// Token: 0x04002074 RID: 8308
	public TypewriterEffect Typewriter;

	// Token: 0x04002075 RID: 8309
	public GameObject Controls;

	// Token: 0x04002076 RID: 8310
	public GameObject Skip;

	// Token: 0x04002077 RID: 8311
	public Texture[] Portraits;

	// Token: 0x04002078 RID: 8312
	public string[] Lines;

	// Token: 0x04002079 RID: 8313
	public UITexture Girl;

	// Token: 0x0400207A RID: 8314
	public UILabel Label;

	// Token: 0x0400207B RID: 8315
	public float OutroTimer;

	// Token: 0x0400207C RID: 8316
	public float Timer;

	// Token: 0x0400207D RID: 8317
	public int DebugNumber;

	// Token: 0x0400207E RID: 8318
	public int ID;

	// Token: 0x0400207F RID: 8319
	public bool VeryFun;

	// Token: 0x04002080 RID: 8320
	public float R = 1f;

	// Token: 0x04002081 RID: 8321
	public float G = 1f;

	// Token: 0x04002082 RID: 8322
	public float B = 1f;

	// Token: 0x04002083 RID: 8323
	public string Text;
}
