using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000C5 RID: 197
public class AlphabetScript : MonoBehaviour
{
	// Token: 0x060009AD RID: 2477 RVA: 0x0004F8E8 File Offset: 0x0004DAE8
	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			this.TargetLabel.transform.parent.gameObject.SetActive(true);
			this.StudentManager.Yandere.NoDebug = true;
			this.BodyHidingLockers.SetActive(true);
			this.AlphabetTools.SetActive(true);
			this.Jukebox.SetActive(false);
			this.MyRenderer.enabled = true;
			this.Class.PhysicalGrade = 5;
			this.CurrentTrack = 1;
			this.Limit = 79;
			if (GameGlobals.Eighties)
			{
				this.IDs = this.EightiesIDs;
				this.Limit = 79;
			}
			this.UpdateText();
			this.UpdateDifficultyLabel();
			return;
		}
		this.TargetLabel.transform.parent.gameObject.SetActive(false);
		this.BombLabel.transform.parent.gameObject.SetActive(false);
		this.AlphabetTools.SetActive(false);
		base.gameObject.SetActive(false);
		base.enabled = false;
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x0004F9F4 File Offset: 0x0004DBF4
	private void Update()
	{
		if (!this.Began && this.StudentManager.Yandere.CanMove)
		{
			this.MusicPlayer.Play();
			this.Began = true;
		}
		if (this.CurrentTarget < this.IDs.Length)
		{
			if (Input.GetKeyDown("m"))
			{
				if (this.MusicPlayer.isPlaying)
				{
					this.MusicPlayer.Stop();
					this.StopMusic = true;
					this.MusicPlayer.time = 0f;
					this.LastTime = 0f;
				}
				else
				{
					this.MusicPlayer.clip = this.MusicTracks[this.CurrentTrack];
					this.MusicPlayer.Play();
					this.StopMusic = false;
				}
			}
			if (this.MusicPlayer.time < 600f && this.MusicPlayer.time > this.LastTime)
			{
				this.LastTime = this.MusicPlayer.time;
			}
			if (this.Began && !this.MusicPlayer.isPlaying && !this.StopMusic)
			{
				this.MusicPlayer.Play();
				this.MusicPlayer.time = this.LastTime;
			}
			if (this.StudentManager.Yandere.CanMove && (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)))
			{
				if (this.StudentManager.Yandere.Inventory.SmokeBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.SmokeBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = (this.RemainingBombs.ToString() ?? "");
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.SmokeBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.StinkBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.StinkBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = (this.RemainingBombs.ToString() ?? "");
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.StinkBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.AmnesiaBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.AmnesiaBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = (this.RemainingBombs.ToString() ?? "");
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.AmnesiaBomb = false;
					}
				}
			}
			this.LocalArrow.LookAt(this.StudentManager.Students[this.IDs[this.CurrentTarget]].transform.position);
			base.transform.eulerAngles = this.LocalArrow.eulerAngles - new Vector3(0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0f);
			if ((this.StudentManager.Yandere.Attacking && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || (this.StudentManager.Yandere.Struggling && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || this.StudentManager.Police.Show || this.StudentManager.Yandere.Noticed)
			{
				this.ChallengeFailed.enabled = true;
			}
			for (int i = this.CurrentTarget + 1; i < this.IDs.Length; i++)
			{
				if (!this.StudentManager.Students[this.IDs[i]].gameObject.activeInHierarchy)
				{
					this.ChallengeFailed.enabled = true;
				}
			}
			if (!this.StudentManager.Students[this.IDs[this.CurrentTarget]].Alive)
			{
				this.CurrentTarget++;
				if (this.CurrentTarget > this.Limit)
				{
					this.TargetLabel.text = "Challenge Complete!";
					SceneManager.LoadScene("OsanaJokeScene");
				}
				else
				{
					this.UpdateText();
				}
			}
			if (this.ChallengeFailed.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x0004FEC0 File Offset: 0x0004E0C0
	public void UpdateText()
	{
		this.TargetLabel.text = string.Concat(new string[]
		{
			"(",
			this.CurrentTarget.ToString(),
			"/",
			this.Limit.ToString(),
			") Current Target: ",
			this.StudentManager.JSON.Students[this.IDs[this.CurrentTarget]].Name
		});
		if (this.RemainingBombs > 0)
		{
			this.BombLabel.transform.parent.gameObject.SetActive(true);
			if (this.BombTexture.color.a < 1f)
			{
				if (this.Inventory.StinkBomb)
				{
					this.BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
					return;
				}
				if (this.Inventory.AmnesiaBomb)
				{
					this.BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
					return;
				}
				this.BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x00050006 File Offset: 0x0004E206
	public void UpdateDifficultyLabel()
	{
		this.DifficultyLabel.text = "Difficulty: " + this.DifficultyText[this.Cheats];
	}

	// Token: 0x040008A9 RID: 2217
	public StudentManagerScript StudentManager;

	// Token: 0x040008AA RID: 2218
	public InventoryScript Inventory;

	// Token: 0x040008AB RID: 2219
	public ClassScript Class;

	// Token: 0x040008AC RID: 2220
	public GameObject BodyHidingLockers;

	// Token: 0x040008AD RID: 2221
	public GameObject AlphabetTools;

	// Token: 0x040008AE RID: 2222
	public GameObject Jukebox;

	// Token: 0x040008AF RID: 2223
	public GameObject AmnesiaBomb;

	// Token: 0x040008B0 RID: 2224
	public GameObject SmokeBomb;

	// Token: 0x040008B1 RID: 2225
	public GameObject StinkBomb;

	// Token: 0x040008B2 RID: 2226
	public UILabel ChallengeFailed;

	// Token: 0x040008B3 RID: 2227
	public UILabel DifficultyLabel;

	// Token: 0x040008B4 RID: 2228
	public UILabel TargetLabel;

	// Token: 0x040008B5 RID: 2229
	public UILabel BombLabel;

	// Token: 0x040008B6 RID: 2230
	public AudioSource MusicPlayer;

	// Token: 0x040008B7 RID: 2231
	public UITexture BombTexture;

	// Token: 0x040008B8 RID: 2232
	public Transform LocalArrow;

	// Token: 0x040008B9 RID: 2233
	public Renderer MyRenderer;

	// Token: 0x040008BA RID: 2234
	public Transform Yandere;

	// Token: 0x040008BB RID: 2235
	public bool AlternateMusic;

	// Token: 0x040008BC RID: 2236
	public bool StopMusic;

	// Token: 0x040008BD RID: 2237
	public bool Began;

	// Token: 0x040008BE RID: 2238
	public int RemainingBombs;

	// Token: 0x040008BF RID: 2239
	public int CurrentTarget;

	// Token: 0x040008C0 RID: 2240
	public int CurrentTrack;

	// Token: 0x040008C1 RID: 2241
	public int Cheats;

	// Token: 0x040008C2 RID: 2242
	public int Limit;

	// Token: 0x040008C3 RID: 2243
	public float LastTime;

	// Token: 0x040008C4 RID: 2244
	public float Timer;

	// Token: 0x040008C5 RID: 2245
	public AudioClip[] MusicTracks;

	// Token: 0x040008C6 RID: 2246
	public string[] DifficultyText;

	// Token: 0x040008C7 RID: 2247
	public int[] EightiesIDs;

	// Token: 0x040008C8 RID: 2248
	public int[] IDs;
}
