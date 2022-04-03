using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class JukeboxScript : MonoBehaviour
{
	// Token: 0x0600194B RID: 6475 RVA: 0x000FD2EC File Offset: 0x000FB4EC
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

	// Token: 0x0600194C RID: 6476 RVA: 0x000FD700 File Offset: 0x000FB900
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

	// Token: 0x0600194D RID: 6477 RVA: 0x000FE30C File Offset: 0x000FC50C
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

	// Token: 0x0600194E RID: 6478 RVA: 0x000FE3B1 File Offset: 0x000FC5B1
	public void Shipgirl()
	{
		this.Egg = true;
		this.KillVolume();
		this.AzurLane.enabled = true;
	}

	// Token: 0x0600194F RID: 6479 RVA: 0x000FE3CC File Offset: 0x000FC5CC
	public void MiyukiMusic()
	{
		this.Egg = true;
		this.KillVolume();
		this.Miyuki.enabled = true;
	}

	// Token: 0x06001950 RID: 6480 RVA: 0x000FE3E7 File Offset: 0x000FC5E7
	public void KillVolume()
	{
		this.FullSanity.volume = 0f;
		this.HalfSanity.volume = 0f;
		this.NoSanity.volume = 0f;
		this.Volume = 0.5f;
	}

	// Token: 0x06001951 RID: 6481 RVA: 0x000FE424 File Offset: 0x000FC624
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

	// Token: 0x06001952 RID: 6482 RVA: 0x000FE591 File Offset: 0x000FC791
	public void PlayJojo()
	{
		this.Egg = true;
		this.KillVolume();
		this.Jojo.enabled = true;
	}

	// Token: 0x06001953 RID: 6483 RVA: 0x000FE5AC File Offset: 0x000FC7AC
	public void PlayCustom()
	{
		this.Egg = true;
		this.KillVolume();
		this.Custom.enabled = true;
		this.Custom.Play();
	}

	// Token: 0x040027A8 RID: 10152
	public YandereScript Yandere;

	// Token: 0x040027A9 RID: 10153
	public AudioSource SFX;

	// Token: 0x040027AA RID: 10154
	public AudioSource AttackOnTitan;

	// Token: 0x040027AB RID: 10155
	public AudioSource Megalovania;

	// Token: 0x040027AC RID: 10156
	public AudioSource MissionMode;

	// Token: 0x040027AD RID: 10157
	public AudioSource Skeletons;

	// Token: 0x040027AE RID: 10158
	public AudioSource Vaporwave;

	// Token: 0x040027AF RID: 10159
	public AudioSource AzurLane;

	// Token: 0x040027B0 RID: 10160
	public AudioSource LifeNote;

	// Token: 0x040027B1 RID: 10161
	public AudioSource Berserk;

	// Token: 0x040027B2 RID: 10162
	public AudioSource Metroid;

	// Token: 0x040027B3 RID: 10163
	public AudioSource Nuclear;

	// Token: 0x040027B4 RID: 10164
	public AudioSource Slender;

	// Token: 0x040027B5 RID: 10165
	public AudioSource Sukeban;

	// Token: 0x040027B6 RID: 10166
	public AudioSource Custom;

	// Token: 0x040027B7 RID: 10167
	public AudioSource Hatred;

	// Token: 0x040027B8 RID: 10168
	public AudioSource Hitman;

	// Token: 0x040027B9 RID: 10169
	public AudioSource Horror;

	// Token: 0x040027BA RID: 10170
	public AudioSource Touhou;

	// Token: 0x040027BB RID: 10171
	public AudioSource Falcon;

	// Token: 0x040027BC RID: 10172
	public AudioSource Miyuki;

	// Token: 0x040027BD RID: 10173
	public AudioSource Ebola;

	// Token: 0x040027BE RID: 10174
	public AudioSource Demon;

	// Token: 0x040027BF RID: 10175
	public AudioSource Ninja;

	// Token: 0x040027C0 RID: 10176
	public AudioSource Punch;

	// Token: 0x040027C1 RID: 10177
	public AudioSource Galo;

	// Token: 0x040027C2 RID: 10178
	public AudioSource Jojo;

	// Token: 0x040027C3 RID: 10179
	public AudioSource Lied;

	// Token: 0x040027C4 RID: 10180
	public AudioSource Nier;

	// Token: 0x040027C5 RID: 10181
	public AudioSource Sith;

	// Token: 0x040027C6 RID: 10182
	public AudioSource DK;

	// Token: 0x040027C7 RID: 10183
	public AudioSource Confession;

	// Token: 0x040027C8 RID: 10184
	public AudioSource FullSanity;

	// Token: 0x040027C9 RID: 10185
	public AudioSource HalfSanity;

	// Token: 0x040027CA RID: 10186
	public AudioSource NoSanity;

	// Token: 0x040027CB RID: 10187
	public AudioSource Chase;

	// Token: 0x040027CC RID: 10188
	public float LastVolume;

	// Token: 0x040027CD RID: 10189
	public float FadeSpeed;

	// Token: 0x040027CE RID: 10190
	public float ClubDip;

	// Token: 0x040027CF RID: 10191
	public float Volume;

	// Token: 0x040027D0 RID: 10192
	public float Dip = 1f;

	// Token: 0x040027D1 RID: 10193
	public int BGMLimit = 12;

	// Token: 0x040027D2 RID: 10194
	public int Track;

	// Token: 0x040027D3 RID: 10195
	public int BGM;

	// Token: 0x040027D4 RID: 10196
	public bool Initialized;

	// Token: 0x040027D5 RID: 10197
	public bool StartMusic;

	// Token: 0x040027D6 RID: 10198
	public bool Egg;

	// Token: 0x040027D7 RID: 10199
	public AudioClip[] FullSanities;

	// Token: 0x040027D8 RID: 10200
	public AudioClip[] HalfSanities;

	// Token: 0x040027D9 RID: 10201
	public AudioClip[] NoSanities;

	// Token: 0x040027DA RID: 10202
	public AudioClip[] OriginalFull;

	// Token: 0x040027DB RID: 10203
	public AudioClip[] OriginalHalf;

	// Token: 0x040027DC RID: 10204
	public AudioClip[] OriginalNo;

	// Token: 0x040027DD RID: 10205
	public AudioClip[] AlternateFull;

	// Token: 0x040027DE RID: 10206
	public AudioClip[] AlternateHalf;

	// Token: 0x040027DF RID: 10207
	public AudioClip[] AlternateNo;

	// Token: 0x040027E0 RID: 10208
	public AudioClip[] ThirdFull;

	// Token: 0x040027E1 RID: 10209
	public AudioClip[] ThirdHalf;

	// Token: 0x040027E2 RID: 10210
	public AudioClip[] ThirdNo;

	// Token: 0x040027E3 RID: 10211
	public AudioClip[] FourthFull;

	// Token: 0x040027E4 RID: 10212
	public AudioClip[] FourthHalf;

	// Token: 0x040027E5 RID: 10213
	public AudioClip[] FourthNo;

	// Token: 0x040027E6 RID: 10214
	public AudioClip[] FifthFull;

	// Token: 0x040027E7 RID: 10215
	public AudioClip[] FifthHalf;

	// Token: 0x040027E8 RID: 10216
	public AudioClip[] FifthNo;

	// Token: 0x040027E9 RID: 10217
	public AudioClip[] SixthFull;

	// Token: 0x040027EA RID: 10218
	public AudioClip[] SixthHalf;

	// Token: 0x040027EB RID: 10219
	public AudioClip[] SixthNo;

	// Token: 0x040027EC RID: 10220
	public AudioClip[] SeventhFull;

	// Token: 0x040027ED RID: 10221
	public AudioClip[] SeventhHalf;

	// Token: 0x040027EE RID: 10222
	public AudioClip[] SeventhNo;

	// Token: 0x040027EF RID: 10223
	public AudioClip[] EighthFull;

	// Token: 0x040027F0 RID: 10224
	public AudioClip[] EighthHalf;

	// Token: 0x040027F1 RID: 10225
	public AudioClip[] EighthNo;

	// Token: 0x040027F2 RID: 10226
	public AudioClip[] NinthFull;

	// Token: 0x040027F3 RID: 10227
	public AudioClip[] NinthHalf;

	// Token: 0x040027F4 RID: 10228
	public AudioClip[] NinthNo;

	// Token: 0x040027F5 RID: 10229
	public AudioClip[] TenthFull;

	// Token: 0x040027F6 RID: 10230
	public AudioClip[] TenthHalf;

	// Token: 0x040027F7 RID: 10231
	public AudioClip[] TenthNo;

	// Token: 0x040027F8 RID: 10232
	public AudioClip[] EleventhFull;

	// Token: 0x040027F9 RID: 10233
	public AudioClip[] EleventhHalf;

	// Token: 0x040027FA RID: 10234
	public AudioClip[] EleventhNo;

	// Token: 0x040027FB RID: 10235
	public AudioClip[] TwelfthFull;

	// Token: 0x040027FC RID: 10236
	public AudioClip[] TwelfthHalf;

	// Token: 0x040027FD RID: 10237
	public AudioClip[] TwelfthNo;

	// Token: 0x040027FE RID: 10238
	public AudioClip[] EightiesOneFull;

	// Token: 0x040027FF RID: 10239
	public AudioClip[] EightiesOneHalf;

	// Token: 0x04002800 RID: 10240
	public AudioClip[] EightiesOneNo;

	// Token: 0x04002801 RID: 10241
	public AudioClip[] EightiesTwoFull;

	// Token: 0x04002802 RID: 10242
	public AudioClip[] EightiesTwoHalf;

	// Token: 0x04002803 RID: 10243
	public AudioClip[] EightiesTwoNo;

	// Token: 0x04002804 RID: 10244
	public AudioClip[] EightiesThreeFull;

	// Token: 0x04002805 RID: 10245
	public AudioClip[] EightiesThreeHalf;

	// Token: 0x04002806 RID: 10246
	public AudioClip[] EightiesThreeNo;

	// Token: 0x04002807 RID: 10247
	public AudioClip[] EightiesFourFull;

	// Token: 0x04002808 RID: 10248
	public AudioClip[] EightiesFourHalf;

	// Token: 0x04002809 RID: 10249
	public AudioClip[] EightiesFourNo;

	// Token: 0x0400280A RID: 10250
	public AudioClip[] EightiesFiveFull;

	// Token: 0x0400280B RID: 10251
	public AudioClip[] EightiesFiveHalf;

	// Token: 0x0400280C RID: 10252
	public AudioClip[] EightiesFiveNo;

	// Token: 0x0400280D RID: 10253
	public AudioClip[] EightiesSixFull;

	// Token: 0x0400280E RID: 10254
	public AudioClip[] EightiesSixHalf;

	// Token: 0x0400280F RID: 10255
	public AudioClip[] EightiesSixNo;
}
