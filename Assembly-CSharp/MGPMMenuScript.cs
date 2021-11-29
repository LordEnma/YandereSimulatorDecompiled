using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000010 RID: 16
public class MGPMMenuScript : MonoBehaviour
{
	// Token: 0x06000034 RID: 52 RVA: 0x000055EC File Offset: 0x000037EC
	private void Start()
	{
		this.Black.material.color = new Color(0f, 0f, 0f, 1f);
		Time.timeScale = 1f;
		if (GameGlobals.Eighties)
		{
			this.Eighties = true;
			GameObject[] array = this.ModernObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(false);
			}
			array = this.EightiesObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(true);
			}
			this.MenuLimit = 2;
			this.Jukebox.volume = 0f;
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00005690 File Offset: 0x00003890
	private void Update()
	{
		this.Rotation -= Time.deltaTime * 3f;
		this.Background.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		if (this.FadeIn)
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 0f, Time.deltaTime));
			if (this.Black.material.color.a == 0f)
			{
				this.Jukebox.Play();
				this.FadeIn = false;
			}
		}
		if (this.FadeOut)
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime);
			if (this.Black.material.color.a == 1f)
			{
				if (this.ID == 4)
				{
					SceneManager.LoadScene("HomeScene");
				}
				else
				{
					GameGlobals.HardMode = this.HardMode;
					SceneManager.LoadScene("MiyukiGameplayScene");
				}
			}
		}
		if (!this.FadeOut && !this.FadeIn)
		{
			if (!this.HardMode && Input.GetKeyDown("h"))
			{
				AudioSource.PlayClipAtPoint(this.HardModeClip, base.transform.position);
				this.Logo.material.mainTexture = this.BloodyLogo;
				this.HardMode = true;
				this.Vibrate = 0.1f;
			}
			if (this.HardMode)
			{
				this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0.1f, Time.deltaTime);
				this.BG.material.color = new Color(Mathf.MoveTowards(this.BG.material.color.r, 0.5f, Time.deltaTime * 0.5f), Mathf.MoveTowards(this.BG.material.color.g, 0f, Time.deltaTime), Mathf.MoveTowards(this.BG.material.color.b, 0f, Time.deltaTime), 1f);
				this.Logo.transform.localPosition = new Vector3(0f, 0.5f, 2f) + new Vector3(UnityEngine.Random.Range(this.Vibrate * -1f, this.Vibrate), UnityEngine.Random.Range(this.Vibrate * -1f, this.Vibrate), 0f);
				this.Vibrate = Mathf.MoveTowards(this.Vibrate, 0f, Time.deltaTime * 0.1f);
			}
			if (this.Jukebox.clip != this.BGM && !this.Jukebox.isPlaying)
			{
				this.Jukebox.loop = true;
				this.Jukebox.clip = this.BGM;
				this.Jukebox.Play();
			}
			if (!this.WindowDisplaying)
			{
				if (this.InputManager.TappedDown)
				{
					this.ID++;
					this.UpdateHighlight();
				}
				if (this.InputManager.TappedUp)
				{
					this.ID--;
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("A") || Input.GetKeyDown("z") || (Input.GetKeyDown("return") | Input.GetKeyDown("space")))
				{
					if (!this.MainMenu.activeInHierarchy)
					{
						if (this.ID == 2)
						{
							GameGlobals.EasyMode = false;
						}
						else
						{
							GameGlobals.EasyMode = true;
						}
						this.FadeOut = true;
						return;
					}
					if (this.ID == 1)
					{
						if (!this.Eighties)
						{
							this.DifficultySelect.SetActive(true);
							this.MainMenu.SetActive(false);
							this.ID = 2;
							this.UpdateHighlight();
							return;
						}
						this.FadeOut = true;
						return;
					}
					else if (this.ID == 2)
					{
						if (!this.Eighties)
						{
							this.Highlight.gameObject.SetActive(false);
							this.Controls.SetActive(true);
							this.WindowDisplaying = true;
							return;
						}
						this.ID = 4;
						this.FadeOut = true;
						return;
					}
					else
					{
						if (this.ID == 3)
						{
							this.Highlight.gameObject.SetActive(false);
							this.Credits.SetActive(true);
							this.WindowDisplaying = true;
							return;
						}
						if (this.ID == 4)
						{
							this.FadeOut = true;
							return;
						}
					}
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Highlight.gameObject.SetActive(true);
				this.Controls.SetActive(false);
				this.Credits.SetActive(false);
				this.WindowDisplaying = false;
			}
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00005BB4 File Offset: 0x00003DB4
	private void UpdateHighlight()
	{
		if (this.MainMenu.activeInHierarchy)
		{
			if (this.ID == 0)
			{
				this.ID = this.MenuLimit;
			}
			else if (this.ID == this.MenuLimit + 1)
			{
				this.ID = 1;
			}
		}
		else if (this.ID == 1)
		{
			this.ID = 3;
		}
		else if (this.ID == 4)
		{
			this.ID = 2;
		}
		this.Highlight.transform.position = new Vector3(0f, -0.2f * (float)this.ID, this.Highlight.transform.position.z);
	}

	// Token: 0x040000B6 RID: 182
	public InputManagerScript InputManager;

	// Token: 0x040000B7 RID: 183
	public AudioSource Jukebox;

	// Token: 0x040000B8 RID: 184
	public AudioClip HardModeClip;

	// Token: 0x040000B9 RID: 185
	public bool WindowDisplaying;

	// Token: 0x040000BA RID: 186
	public Transform Highlight;

	// Token: 0x040000BB RID: 187
	public Transform Background;

	// Token: 0x040000BC RID: 188
	public GameObject Controls;

	// Token: 0x040000BD RID: 189
	public GameObject Credits;

	// Token: 0x040000BE RID: 190
	public GameObject DifficultySelect;

	// Token: 0x040000BF RID: 191
	public GameObject MainMenu;

	// Token: 0x040000C0 RID: 192
	public GameObject[] EightiesObjects;

	// Token: 0x040000C1 RID: 193
	public GameObject[] ModernObjects;

	// Token: 0x040000C2 RID: 194
	public Renderer Black;

	// Token: 0x040000C3 RID: 195
	public Renderer Logo;

	// Token: 0x040000C4 RID: 196
	public Renderer BG;

	// Token: 0x040000C5 RID: 197
	public Texture BloodyLogo;

	// Token: 0x040000C6 RID: 198
	public AudioClip BGM;

	// Token: 0x040000C7 RID: 199
	public float Rotation;

	// Token: 0x040000C8 RID: 200
	public float Vibrate;

	// Token: 0x040000C9 RID: 201
	public bool Eighties;

	// Token: 0x040000CA RID: 202
	public bool HardMode;

	// Token: 0x040000CB RID: 203
	public bool FadeOut;

	// Token: 0x040000CC RID: 204
	public bool FadeIn;

	// Token: 0x040000CD RID: 205
	public int MenuLimit = 4;

	// Token: 0x040000CE RID: 206
	public int ID;
}
