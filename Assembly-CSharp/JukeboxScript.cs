using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class JukeboxScript : MonoBehaviour
{
	// Token: 0x06001945 RID: 6469 RVA: 0x000FCC60 File Offset: 0x000FAE60
	public void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.BGMLimit = 6;
			this.OriginalFull = this.EightiesOneFull;
			this.OriginalHalf = this.EightiesOneHalf;
			this.OriginalNo = this.EightiesOneNo;
			this.AlternateFull = this.EightiesTwoFull;
			this.AlternateHalf = this.EightiesTwoHalf;
			this.AlternateNo = this.EightiesTwoNo;
			this.ThirdFull = this.EightiesThreeFull;
			this.ThirdHalf = this.EightiesThreeHalf;
			this.ThirdNo = this.EightiesThreeNo;
			this.FourthFull = this.EightiesFourFull;
			this.FourthHalf = this.EightiesFourHalf;
			this.FourthNo = this.EightiesFourNo;
			this.FifthFull = this.EightiesFiveFull;
			this.FifthHalf = this.EightiesFiveHalf;
			this.FifthNo = this.EightiesFiveNo;
			this.SixthFull = this.EightiesSixFull;
			this.SixthHalf = this.EightiesSixHalf;
			this.SixthNo = this.EightiesSixNo;
		}
		if (!this.Initialized)
		{
			this.BGM = UnityEngine.Random.Range(1, this.BGMLimit + 1);
			this.Initialized = true;
		}
		else
		{
			this.BGM++;
			if (this.BGM > this.BGMLimit)
			{
				this.BGM = 1;
			}
			else if (this.BGM == 0)
			{
				this.BGM = this.BGMLimit;
			}
		}
		if (this.BGM == 1)
		{
			this.FullSanities = this.OriginalFull;
			this.HalfSanities = this.OriginalHalf;
			this.NoSanities = this.OriginalNo;
		}
		else if (this.BGM == 2)
		{
			this.FullSanities = this.AlternateFull;
			this.HalfSanities = this.AlternateHalf;
			this.NoSanities = this.AlternateNo;
		}
		else if (this.BGM == 3)
		{
			this.FullSanities = this.ThirdFull;
			this.HalfSanities = this.ThirdHalf;
			this.NoSanities = this.ThirdNo;
		}
		else if (this.BGM == 4)
		{
			this.FullSanities = this.FourthFull;
			this.HalfSanities = this.FourthHalf;
			this.NoSanities = this.FourthNo;
		}
		else if (this.BGM == 5)
		{
			this.FullSanities = this.FifthFull;
			this.HalfSanities = this.FifthHalf;
			this.NoSanities = this.FifthNo;
		}
		else if (this.BGM == 6)
		{
			this.FullSanities = this.SixthFull;
			this.HalfSanities = this.SixthHalf;
			this.NoSanities = this.SixthNo;
		}
		else if (this.BGM == 7)
		{
			this.FullSanities = this.SeventhFull;
			this.HalfSanities = this.SeventhHalf;
			this.NoSanities = this.SeventhNo;
		}
		else if (this.BGM == 8)
		{
			this.FullSanities = this.EighthFull;
			this.HalfSanities = this.EighthHalf;
			this.NoSanities = this.EighthNo;
		}
		else if (this.BGM == 9)
		{
			this.FullSanities = this.NinthFull;
			this.HalfSanities = this.NinthHalf;
			this.NoSanities = this.NinthNo;
		}
		else if (this.BGM == 10)
		{
			this.FullSanities = this.TenthFull;
			this.HalfSanities = this.TenthHalf;
			this.NoSanities = this.TenthNo;
		}
		else if (this.BGM == 11)
		{
			this.FullSanities = this.TwelfthFull;
			this.HalfSanities = this.TwelfthHalf;
			this.NoSanities = this.TwelfthNo;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		int num;
		if (SchoolAtmosphere.Type == SchoolAtmosphereType.High)
		{
			num = 3;
		}
		else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium)
		{
			num = 2;
		}
		else
		{
			num = 1;
		}
		this.FullSanity.clip = this.FullSanities[num];
		this.HalfSanity.clip = this.HalfSanities[num];
		this.NoSanity.clip = this.NoSanities[num];
		this.Volume = 0.25f;
		this.FullSanity.volume = 0f;
		this.Hitman.time = 26f;
	}

	// Token: 0x06001946 RID: 6470 RVA: 0x000FD074 File Offset: 0x000FB274
	private void Update()
	{
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.EasterEggMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.M))
		{
			this.StartStopMusic();
		}
		if (!this.Egg)
		{
			if (!this.Yandere.Police.Clock.SchoolBell.isPlaying && !this.Yandere.StudentManager.MemorialScene.enabled)
			{
				if (!this.StartMusic)
				{
					this.FullSanity.Play();
					this.HalfSanity.Play();
					this.NoSanity.Play();
					this.StartMusic = true;
				}
				if (this.Yandere.Sanity >= 66.666664f)
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.016666668f * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
				}
				else if (this.Yandere.Sanity >= 33.333332f)
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.016666668f * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
				}
				else
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, 0.016666668f * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.016666668f * this.FadeSpeed);
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, 0.16666667f);
			this.Megalovania.volume = Mathf.MoveTowards(this.Megalovania.volume, this.Volume * this.Dip, 0.16666667f);
			this.MissionMode.volume = Mathf.MoveTowards(this.MissionMode.volume, this.Volume * this.Dip, 0.16666667f);
			this.Skeletons.volume = Mathf.MoveTowards(this.Skeletons.volume, this.Volume * this.Dip, 0.16666667f);
			this.Vaporwave.volume = Mathf.MoveTowards(this.Vaporwave.volume, this.Volume * this.Dip, 0.16666667f);
			this.AzurLane.volume = Mathf.MoveTowards(this.AzurLane.volume, this.Volume * this.Dip, 0.16666667f);
			this.LifeNote.volume = Mathf.MoveTowards(this.LifeNote.volume, this.Volume * this.Dip, 0.16666667f);
			this.Berserk.volume = Mathf.MoveTowards(this.Berserk.volume, this.Volume * this.Dip, 0.16666667f);
			this.Metroid.volume = Mathf.MoveTowards(this.Metroid.volume, this.Volume * this.Dip, 0.16666667f);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, 0.16666667f);
			this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, 0.16666667f);
			this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, 0.16666667f);
			this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, 0.16666667f);
			this.Hitman.volume = Mathf.MoveTowards(this.Hitman.volume, this.Volume * this.Dip, 0.16666667f);
			this.Touhou.volume = Mathf.MoveTowards(this.Touhou.volume, this.Volume * this.Dip, 0.16666667f);
			this.Falcon.volume = Mathf.MoveTowards(this.Falcon.volume, this.Volume * this.Dip, 0.16666667f);
			this.Miyuki.volume = Mathf.MoveTowards(this.Miyuki.volume, this.Volume * this.Dip, 0.16666667f);
			this.Demon.volume = Mathf.MoveTowards(this.Demon.volume, this.Volume * this.Dip, 0.16666667f);
			this.Ebola.volume = Mathf.MoveTowards(this.Ebola.volume, this.Volume * this.Dip, 0.16666667f);
			this.Ninja.volume = Mathf.MoveTowards(this.Ninja.volume, this.Volume * this.Dip, 0.16666667f);
			this.Punch.volume = Mathf.MoveTowards(this.Punch.volume, this.Volume * this.Dip, 0.16666667f);
			this.Galo.volume = Mathf.MoveTowards(this.Galo.volume, this.Volume * this.Dip, 0.16666667f);
			this.Jojo.volume = Mathf.MoveTowards(this.Jojo.volume, this.Volume * this.Dip, 0.16666667f);
			this.Lied.volume = Mathf.MoveTowards(this.Lied.volume, this.Volume * this.Dip, 0.16666667f);
			this.Nier.volume = Mathf.MoveTowards(this.Nier.volume, this.Volume * this.Dip, 0.16666667f);
			this.Sith.volume = Mathf.MoveTowards(this.Sith.volume, this.Volume * this.Dip, 0.16666667f);
			this.DK.volume = Mathf.MoveTowards(this.DK.volume, this.Volume * this.Dip, 0.16666667f);
			this.Horror.volume = Mathf.MoveTowards(this.Horror.volume, this.Volume * this.Dip, 0.16666667f);
			if (this.Custom.enabled)
			{
				this.Custom.volume = Mathf.MoveTowards(this.Custom.volume, this.Volume * this.Dip - this.ClubDip, 0.016666668f * this.FadeSpeed);
			}
		}
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed && this.Yandere.CanMove && this.Yandere.EasterEggMenu.activeInHierarchy && !this.Egg)
		{
			if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Alpha4))
			{
				this.Egg = true;
				this.KillVolume();
				this.AttackOnTitan.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				this.Egg = true;
				this.KillVolume();
				this.Nuclear.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				this.Egg = true;
				this.KillVolume();
				this.Hatred.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.B))
			{
				this.Egg = true;
				this.KillVolume();
				this.Sukeban.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
			{
				this.Egg = true;
				this.KillVolume();
				this.Slender.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				this.Egg = true;
				this.KillVolume();
				this.Galo.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.L))
			{
				this.Egg = true;
				this.KillVolume();
				this.Hitman.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				this.Egg = true;
				this.KillVolume();
				this.Skeletons.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.K))
			{
				this.Egg = true;
				this.KillVolume();
				this.DK.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.C))
			{
				this.Egg = true;
				this.KillVolume();
				this.Touhou.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F))
			{
				this.Egg = true;
				this.KillVolume();
				this.Falcon.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.O))
			{
				this.Egg = true;
				this.KillVolume();
				this.Punch.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.U))
			{
				this.Egg = true;
				this.KillVolume();
				this.Megalovania.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.Q))
			{
				this.Egg = true;
				this.KillVolume();
				this.Metroid.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.Y))
			{
				this.Egg = true;
				this.KillVolume();
				this.Ninja.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.W))
			{
				this.Egg = true;
				this.KillVolume();
				this.Ebola.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				this.Egg = true;
				this.KillVolume();
				this.Demon.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
			{
				if (Input.GetKeyDown(KeyCode.A))
				{
					this.Sith.pitch = 0.1f;
				}
				this.Egg = true;
				this.KillVolume();
				this.Sith.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F2))
			{
				this.Egg = true;
				this.KillVolume();
				this.Horror.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F3))
			{
				this.Egg = true;
				this.KillVolume();
				this.LifeNote.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F6) || Input.GetKeyDown(KeyCode.F9) || Input.GetKeyDown(KeyCode.F12))
			{
				this.Egg = true;
				this.KillVolume();
				this.Lied.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F7))
			{
				this.Egg = true;
				this.KillVolume();
				this.Berserk.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.F8))
			{
				this.Egg = true;
				this.KillVolume();
				this.Nier.enabled = true;
				return;
			}
			if (Input.GetKeyDown(KeyCode.V))
			{
				this.Egg = true;
				this.KillVolume();
				this.Vaporwave.enabled = true;
			}
		}
	}

	// Token: 0x06001947 RID: 6471 RVA: 0x000FDC80 File Offset: 0x000FBE80
	public void StartStopMusic()
	{
		if (this.Custom.isPlaying)
		{
			this.Egg = false;
			this.Custom.Stop();
			this.FadeSpeed = 1f;
			this.StartMusic = false;
			this.Volume = this.LastVolume;
			this.Start();
			return;
		}
		if (this.Volume == 0f)
		{
			this.FadeSpeed = 1f;
			this.StartMusic = false;
			this.Volume = this.LastVolume;
			this.Start();
			return;
		}
		this.LastVolume = this.Volume;
		this.FadeSpeed = 10f;
		this.Volume = 0f;
	}

	// Token: 0x06001948 RID: 6472 RVA: 0x000FDD25 File Offset: 0x000FBF25
	public void Shipgirl()
	{
		this.Egg = true;
		this.KillVolume();
		this.AzurLane.enabled = true;
	}

	// Token: 0x06001949 RID: 6473 RVA: 0x000FDD40 File Offset: 0x000FBF40
	public void MiyukiMusic()
	{
		this.Egg = true;
		this.KillVolume();
		this.Miyuki.enabled = true;
	}

	// Token: 0x0600194A RID: 6474 RVA: 0x000FDD5B File Offset: 0x000FBF5B
	public void KillVolume()
	{
		this.FullSanity.volume = 0f;
		this.HalfSanity.volume = 0f;
		this.NoSanity.volume = 0f;
		this.Volume = 0.5f;
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x000FDD98 File Offset: 0x000FBF98
	public void GameOver()
	{
		this.AttackOnTitan.Stop();
		this.Megalovania.Stop();
		this.MissionMode.Stop();
		this.Skeletons.Stop();
		this.Vaporwave.Stop();
		this.AzurLane.Stop();
		this.LifeNote.Stop();
		this.Berserk.Stop();
		this.Metroid.Stop();
		this.Nuclear.Stop();
		this.Sukeban.Stop();
		this.Custom.Stop();
		this.Slender.Stop();
		this.Hatred.Stop();
		this.Hitman.Stop();
		this.Horror.Stop();
		this.Touhou.Stop();
		this.Falcon.Stop();
		this.Miyuki.Stop();
		this.Ebola.Stop();
		this.Punch.Stop();
		this.Ninja.Stop();
		this.Jojo.Stop();
		this.Galo.Stop();
		this.Lied.Stop();
		this.Nier.Stop();
		this.Sith.Stop();
		this.DK.Stop();
		this.Confession.Stop();
		this.FullSanity.Stop();
		this.HalfSanity.Stop();
		this.NoSanity.Stop();
	}

	// Token: 0x0600194C RID: 6476 RVA: 0x000FDF05 File Offset: 0x000FC105
	public void PlayJojo()
	{
		this.Egg = true;
		this.KillVolume();
		this.Jojo.enabled = true;
	}

	// Token: 0x0600194D RID: 6477 RVA: 0x000FDF20 File Offset: 0x000FC120
	public void PlayCustom()
	{
		this.Egg = true;
		this.KillVolume();
		this.Custom.enabled = true;
		this.Custom.Play();
	}

	// Token: 0x04002795 RID: 10133
	public YandereScript Yandere;

	// Token: 0x04002796 RID: 10134
	public AudioSource SFX;

	// Token: 0x04002797 RID: 10135
	public AudioSource AttackOnTitan;

	// Token: 0x04002798 RID: 10136
	public AudioSource Megalovania;

	// Token: 0x04002799 RID: 10137
	public AudioSource MissionMode;

	// Token: 0x0400279A RID: 10138
	public AudioSource Skeletons;

	// Token: 0x0400279B RID: 10139
	public AudioSource Vaporwave;

	// Token: 0x0400279C RID: 10140
	public AudioSource AzurLane;

	// Token: 0x0400279D RID: 10141
	public AudioSource LifeNote;

	// Token: 0x0400279E RID: 10142
	public AudioSource Berserk;

	// Token: 0x0400279F RID: 10143
	public AudioSource Metroid;

	// Token: 0x040027A0 RID: 10144
	public AudioSource Nuclear;

	// Token: 0x040027A1 RID: 10145
	public AudioSource Slender;

	// Token: 0x040027A2 RID: 10146
	public AudioSource Sukeban;

	// Token: 0x040027A3 RID: 10147
	public AudioSource Custom;

	// Token: 0x040027A4 RID: 10148
	public AudioSource Hatred;

	// Token: 0x040027A5 RID: 10149
	public AudioSource Hitman;

	// Token: 0x040027A6 RID: 10150
	public AudioSource Horror;

	// Token: 0x040027A7 RID: 10151
	public AudioSource Touhou;

	// Token: 0x040027A8 RID: 10152
	public AudioSource Falcon;

	// Token: 0x040027A9 RID: 10153
	public AudioSource Miyuki;

	// Token: 0x040027AA RID: 10154
	public AudioSource Ebola;

	// Token: 0x040027AB RID: 10155
	public AudioSource Demon;

	// Token: 0x040027AC RID: 10156
	public AudioSource Ninja;

	// Token: 0x040027AD RID: 10157
	public AudioSource Punch;

	// Token: 0x040027AE RID: 10158
	public AudioSource Galo;

	// Token: 0x040027AF RID: 10159
	public AudioSource Jojo;

	// Token: 0x040027B0 RID: 10160
	public AudioSource Lied;

	// Token: 0x040027B1 RID: 10161
	public AudioSource Nier;

	// Token: 0x040027B2 RID: 10162
	public AudioSource Sith;

	// Token: 0x040027B3 RID: 10163
	public AudioSource DK;

	// Token: 0x040027B4 RID: 10164
	public AudioSource Confession;

	// Token: 0x040027B5 RID: 10165
	public AudioSource FullSanity;

	// Token: 0x040027B6 RID: 10166
	public AudioSource HalfSanity;

	// Token: 0x040027B7 RID: 10167
	public AudioSource NoSanity;

	// Token: 0x040027B8 RID: 10168
	public AudioSource Chase;

	// Token: 0x040027B9 RID: 10169
	public float LastVolume;

	// Token: 0x040027BA RID: 10170
	public float FadeSpeed;

	// Token: 0x040027BB RID: 10171
	public float ClubDip;

	// Token: 0x040027BC RID: 10172
	public float Volume;

	// Token: 0x040027BD RID: 10173
	public float Dip = 1f;

	// Token: 0x040027BE RID: 10174
	public int BGMLimit = 12;

	// Token: 0x040027BF RID: 10175
	public int Track;

	// Token: 0x040027C0 RID: 10176
	public int BGM;

	// Token: 0x040027C1 RID: 10177
	public bool Initialized;

	// Token: 0x040027C2 RID: 10178
	public bool StartMusic;

	// Token: 0x040027C3 RID: 10179
	public bool Egg;

	// Token: 0x040027C4 RID: 10180
	public AudioClip[] FullSanities;

	// Token: 0x040027C5 RID: 10181
	public AudioClip[] HalfSanities;

	// Token: 0x040027C6 RID: 10182
	public AudioClip[] NoSanities;

	// Token: 0x040027C7 RID: 10183
	public AudioClip[] OriginalFull;

	// Token: 0x040027C8 RID: 10184
	public AudioClip[] OriginalHalf;

	// Token: 0x040027C9 RID: 10185
	public AudioClip[] OriginalNo;

	// Token: 0x040027CA RID: 10186
	public AudioClip[] AlternateFull;

	// Token: 0x040027CB RID: 10187
	public AudioClip[] AlternateHalf;

	// Token: 0x040027CC RID: 10188
	public AudioClip[] AlternateNo;

	// Token: 0x040027CD RID: 10189
	public AudioClip[] ThirdFull;

	// Token: 0x040027CE RID: 10190
	public AudioClip[] ThirdHalf;

	// Token: 0x040027CF RID: 10191
	public AudioClip[] ThirdNo;

	// Token: 0x040027D0 RID: 10192
	public AudioClip[] FourthFull;

	// Token: 0x040027D1 RID: 10193
	public AudioClip[] FourthHalf;

	// Token: 0x040027D2 RID: 10194
	public AudioClip[] FourthNo;

	// Token: 0x040027D3 RID: 10195
	public AudioClip[] FifthFull;

	// Token: 0x040027D4 RID: 10196
	public AudioClip[] FifthHalf;

	// Token: 0x040027D5 RID: 10197
	public AudioClip[] FifthNo;

	// Token: 0x040027D6 RID: 10198
	public AudioClip[] SixthFull;

	// Token: 0x040027D7 RID: 10199
	public AudioClip[] SixthHalf;

	// Token: 0x040027D8 RID: 10200
	public AudioClip[] SixthNo;

	// Token: 0x040027D9 RID: 10201
	public AudioClip[] SeventhFull;

	// Token: 0x040027DA RID: 10202
	public AudioClip[] SeventhHalf;

	// Token: 0x040027DB RID: 10203
	public AudioClip[] SeventhNo;

	// Token: 0x040027DC RID: 10204
	public AudioClip[] EighthFull;

	// Token: 0x040027DD RID: 10205
	public AudioClip[] EighthHalf;

	// Token: 0x040027DE RID: 10206
	public AudioClip[] EighthNo;

	// Token: 0x040027DF RID: 10207
	public AudioClip[] NinthFull;

	// Token: 0x040027E0 RID: 10208
	public AudioClip[] NinthHalf;

	// Token: 0x040027E1 RID: 10209
	public AudioClip[] NinthNo;

	// Token: 0x040027E2 RID: 10210
	public AudioClip[] TenthFull;

	// Token: 0x040027E3 RID: 10211
	public AudioClip[] TenthHalf;

	// Token: 0x040027E4 RID: 10212
	public AudioClip[] TenthNo;

	// Token: 0x040027E5 RID: 10213
	public AudioClip[] EleventhFull;

	// Token: 0x040027E6 RID: 10214
	public AudioClip[] EleventhHalf;

	// Token: 0x040027E7 RID: 10215
	public AudioClip[] EleventhNo;

	// Token: 0x040027E8 RID: 10216
	public AudioClip[] TwelfthFull;

	// Token: 0x040027E9 RID: 10217
	public AudioClip[] TwelfthHalf;

	// Token: 0x040027EA RID: 10218
	public AudioClip[] TwelfthNo;

	// Token: 0x040027EB RID: 10219
	public AudioClip[] EightiesOneFull;

	// Token: 0x040027EC RID: 10220
	public AudioClip[] EightiesOneHalf;

	// Token: 0x040027ED RID: 10221
	public AudioClip[] EightiesOneNo;

	// Token: 0x040027EE RID: 10222
	public AudioClip[] EightiesTwoFull;

	// Token: 0x040027EF RID: 10223
	public AudioClip[] EightiesTwoHalf;

	// Token: 0x040027F0 RID: 10224
	public AudioClip[] EightiesTwoNo;

	// Token: 0x040027F1 RID: 10225
	public AudioClip[] EightiesThreeFull;

	// Token: 0x040027F2 RID: 10226
	public AudioClip[] EightiesThreeHalf;

	// Token: 0x040027F3 RID: 10227
	public AudioClip[] EightiesThreeNo;

	// Token: 0x040027F4 RID: 10228
	public AudioClip[] EightiesFourFull;

	// Token: 0x040027F5 RID: 10229
	public AudioClip[] EightiesFourHalf;

	// Token: 0x040027F6 RID: 10230
	public AudioClip[] EightiesFourNo;

	// Token: 0x040027F7 RID: 10231
	public AudioClip[] EightiesFiveFull;

	// Token: 0x040027F8 RID: 10232
	public AudioClip[] EightiesFiveHalf;

	// Token: 0x040027F9 RID: 10233
	public AudioClip[] EightiesFiveNo;

	// Token: 0x040027FA RID: 10234
	public AudioClip[] EightiesSixFull;

	// Token: 0x040027FB RID: 10235
	public AudioClip[] EightiesSixHalf;

	// Token: 0x040027FC RID: 10236
	public AudioClip[] EightiesSixNo;
}
