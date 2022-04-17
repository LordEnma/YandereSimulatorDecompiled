using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002D9 RID: 729
public class FunScript : MonoBehaviour
{
	// Token: 0x060014D4 RID: 5332 RVA: 0x000CD104 File Offset: 0x000CB304
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

	// Token: 0x060014D5 RID: 5333 RVA: 0x000CD494 File Offset: 0x000CB694
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

	// Token: 0x040020BD RID: 8381
	public TypewriterEffect Typewriter;

	// Token: 0x040020BE RID: 8382
	public GameObject Controls;

	// Token: 0x040020BF RID: 8383
	public GameObject Skip;

	// Token: 0x040020C0 RID: 8384
	public Texture[] Portraits;

	// Token: 0x040020C1 RID: 8385
	public string[] Lines;

	// Token: 0x040020C2 RID: 8386
	public UITexture Girl;

	// Token: 0x040020C3 RID: 8387
	public UILabel Label;

	// Token: 0x040020C4 RID: 8388
	public float OutroTimer;

	// Token: 0x040020C5 RID: 8389
	public float Timer;

	// Token: 0x040020C6 RID: 8390
	public int DebugNumber;

	// Token: 0x040020C7 RID: 8391
	public int ID;

	// Token: 0x040020C8 RID: 8392
	public bool VeryFun;

	// Token: 0x040020C9 RID: 8393
	public float R = 1f;

	// Token: 0x040020CA RID: 8394
	public float G = 1f;

	// Token: 0x040020CB RID: 8395
	public float B = 1f;

	// Token: 0x040020CC RID: 8396
	public string Text;
}
