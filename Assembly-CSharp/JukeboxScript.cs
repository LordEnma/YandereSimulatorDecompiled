using System;
using UnityEngine;

// Token: 0x02000344 RID: 836
public class JukeboxScript : MonoBehaviour
{
	// Token: 0x0600191E RID: 6430 RVA: 0x000FA104 File Offset: 0x000F8304
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

	// Token: 0x0600191F RID: 6431 RVA: 0x000FA50C File Offset: 0x000F870C
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

	// Token: 0x06001920 RID: 6432 RVA: 0x000FB118 File Offset: 0x000F9318
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

	// Token: 0x06001921 RID: 6433 RVA: 0x000FB1BD File Offset: 0x000F93BD
	public void Shipgirl()
	{
		this.Egg = true;
		this.KillVolume();
		this.AzurLane.enabled = true;
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x000FB1D8 File Offset: 0x000F93D8
	public void MiyukiMusic()
	{
		this.Egg = true;
		this.KillVolume();
		this.Miyuki.enabled = true;
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x000FB1F3 File Offset: 0x000F93F3
	public void KillVolume()
	{
		this.FullSanity.volume = 0f;
		this.HalfSanity.volume = 0f;
		this.NoSanity.volume = 0f;
		this.Volume = 0.5f;
	}

	// Token: 0x06001924 RID: 6436 RVA: 0x000FB230 File Offset: 0x000F9430
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

	// Token: 0x06001925 RID: 6437 RVA: 0x000FB39D File Offset: 0x000F959D
	public void PlayJojo()
	{
		this.Egg = true;
		this.KillVolume();
		this.Jojo.enabled = true;
	}

	// Token: 0x06001926 RID: 6438 RVA: 0x000FB3B8 File Offset: 0x000F95B8
	public void PlayCustom()
	{
		this.Egg = true;
		this.KillVolume();
		this.Custom.enabled = true;
		this.Custom.Play();
	}

	// Token: 0x04002713 RID: 10003
	public YandereScript Yandere;

	// Token: 0x04002714 RID: 10004
	public AudioSource SFX;

	// Token: 0x04002715 RID: 10005
	public AudioSource AttackOnTitan;

	// Token: 0x04002716 RID: 10006
	public AudioSource Megalovania;

	// Token: 0x04002717 RID: 10007
	public AudioSource MissionMode;

	// Token: 0x04002718 RID: 10008
	public AudioSource Skeletons;

	// Token: 0x04002719 RID: 10009
	public AudioSource Vaporwave;

	// Token: 0x0400271A RID: 10010
	public AudioSource AzurLane;

	// Token: 0x0400271B RID: 10011
	public AudioSource LifeNote;

	// Token: 0x0400271C RID: 10012
	public AudioSource Berserk;

	// Token: 0x0400271D RID: 10013
	public AudioSource Metroid;

	// Token: 0x0400271E RID: 10014
	public AudioSource Nuclear;

	// Token: 0x0400271F RID: 10015
	public AudioSource Slender;

	// Token: 0x04002720 RID: 10016
	public AudioSource Sukeban;

	// Token: 0x04002721 RID: 10017
	public AudioSource Custom;

	// Token: 0x04002722 RID: 10018
	public AudioSource Hatred;

	// Token: 0x04002723 RID: 10019
	public AudioSource Hitman;

	// Token: 0x04002724 RID: 10020
	public AudioSource Horror;

	// Token: 0x04002725 RID: 10021
	public AudioSource Touhou;

	// Token: 0x04002726 RID: 10022
	public AudioSource Falcon;

	// Token: 0x04002727 RID: 10023
	public AudioSource Miyuki;

	// Token: 0x04002728 RID: 10024
	public AudioSource Ebola;

	// Token: 0x04002729 RID: 10025
	public AudioSource Demon;

	// Token: 0x0400272A RID: 10026
	public AudioSource Ninja;

	// Token: 0x0400272B RID: 10027
	public AudioSource Punch;

	// Token: 0x0400272C RID: 10028
	public AudioSource Galo;

	// Token: 0x0400272D RID: 10029
	public AudioSource Jojo;

	// Token: 0x0400272E RID: 10030
	public AudioSource Lied;

	// Token: 0x0400272F RID: 10031
	public AudioSource Nier;

	// Token: 0x04002730 RID: 10032
	public AudioSource Sith;

	// Token: 0x04002731 RID: 10033
	public AudioSource DK;

	// Token: 0x04002732 RID: 10034
	public AudioSource Confession;

	// Token: 0x04002733 RID: 10035
	public AudioSource FullSanity;

	// Token: 0x04002734 RID: 10036
	public AudioSource HalfSanity;

	// Token: 0x04002735 RID: 10037
	public AudioSource NoSanity;

	// Token: 0x04002736 RID: 10038
	public AudioSource Chase;

	// Token: 0x04002737 RID: 10039
	public float LastVolume;

	// Token: 0x04002738 RID: 10040
	public float FadeSpeed;

	// Token: 0x04002739 RID: 10041
	public float ClubDip;

	// Token: 0x0400273A RID: 10042
	public float Volume;

	// Token: 0x0400273B RID: 10043
	public float Dip = 1f;

	// Token: 0x0400273C RID: 10044
	public int BGMLimit = 12;

	// Token: 0x0400273D RID: 10045
	public int Track;

	// Token: 0x0400273E RID: 10046
	public int BGM;

	// Token: 0x0400273F RID: 10047
	public bool Initialized;

	// Token: 0x04002740 RID: 10048
	public bool StartMusic;

	// Token: 0x04002741 RID: 10049
	public bool Egg;

	// Token: 0x04002742 RID: 10050
	public AudioClip[] FullSanities;

	// Token: 0x04002743 RID: 10051
	public AudioClip[] HalfSanities;

	// Token: 0x04002744 RID: 10052
	public AudioClip[] NoSanities;

	// Token: 0x04002745 RID: 10053
	public AudioClip[] OriginalFull;

	// Token: 0x04002746 RID: 10054
	public AudioClip[] OriginalHalf;

	// Token: 0x04002747 RID: 10055
	public AudioClip[] OriginalNo;

	// Token: 0x04002748 RID: 10056
	public AudioClip[] AlternateFull;

	// Token: 0x04002749 RID: 10057
	public AudioClip[] AlternateHalf;

	// Token: 0x0400274A RID: 10058
	public AudioClip[] AlternateNo;

	// Token: 0x0400274B RID: 10059
	public AudioClip[] ThirdFull;

	// Token: 0x0400274C RID: 10060
	public AudioClip[] ThirdHalf;

	// Token: 0x0400274D RID: 10061
	public AudioClip[] ThirdNo;

	// Token: 0x0400274E RID: 10062
	public AudioClip[] FourthFull;

	// Token: 0x0400274F RID: 10063
	public AudioClip[] FourthHalf;

	// Token: 0x04002750 RID: 10064
	public AudioClip[] FourthNo;

	// Token: 0x04002751 RID: 10065
	public AudioClip[] FifthFull;

	// Token: 0x04002752 RID: 10066
	public AudioClip[] FifthHalf;

	// Token: 0x04002753 RID: 10067
	public AudioClip[] FifthNo;

	// Token: 0x04002754 RID: 10068
	public AudioClip[] SixthFull;

	// Token: 0x04002755 RID: 10069
	public AudioClip[] SixthHalf;

	// Token: 0x04002756 RID: 10070
	public AudioClip[] SixthNo;

	// Token: 0x04002757 RID: 10071
	public AudioClip[] SeventhFull;

	// Token: 0x04002758 RID: 10072
	public AudioClip[] SeventhHalf;

	// Token: 0x04002759 RID: 10073
	public AudioClip[] SeventhNo;

	// Token: 0x0400275A RID: 10074
	public AudioClip[] EighthFull;

	// Token: 0x0400275B RID: 10075
	public AudioClip[] EighthHalf;

	// Token: 0x0400275C RID: 10076
	public AudioClip[] EighthNo;

	// Token: 0x0400275D RID: 10077
	public AudioClip[] NinthFull;

	// Token: 0x0400275E RID: 10078
	public AudioClip[] NinthHalf;

	// Token: 0x0400275F RID: 10079
	public AudioClip[] NinthNo;

	// Token: 0x04002760 RID: 10080
	public AudioClip[] TenthFull;

	// Token: 0x04002761 RID: 10081
	public AudioClip[] TenthHalf;

	// Token: 0x04002762 RID: 10082
	public AudioClip[] TenthNo;

	// Token: 0x04002763 RID: 10083
	public AudioClip[] EleventhFull;

	// Token: 0x04002764 RID: 10084
	public AudioClip[] EleventhHalf;

	// Token: 0x04002765 RID: 10085
	public AudioClip[] EleventhNo;

	// Token: 0x04002766 RID: 10086
	public AudioClip[] TwelfthFull;

	// Token: 0x04002767 RID: 10087
	public AudioClip[] TwelfthHalf;

	// Token: 0x04002768 RID: 10088
	public AudioClip[] TwelfthNo;

	// Token: 0x04002769 RID: 10089
	public AudioClip[] EightiesOneFull;

	// Token: 0x0400276A RID: 10090
	public AudioClip[] EightiesOneHalf;

	// Token: 0x0400276B RID: 10091
	public AudioClip[] EightiesOneNo;

	// Token: 0x0400276C RID: 10092
	public AudioClip[] EightiesTwoFull;

	// Token: 0x0400276D RID: 10093
	public AudioClip[] EightiesTwoHalf;

	// Token: 0x0400276E RID: 10094
	public AudioClip[] EightiesTwoNo;

	// Token: 0x0400276F RID: 10095
	public AudioClip[] EightiesThreeFull;

	// Token: 0x04002770 RID: 10096
	public AudioClip[] EightiesThreeHalf;

	// Token: 0x04002771 RID: 10097
	public AudioClip[] EightiesThreeNo;

	// Token: 0x04002772 RID: 10098
	public AudioClip[] EightiesFourFull;

	// Token: 0x04002773 RID: 10099
	public AudioClip[] EightiesFourHalf;

	// Token: 0x04002774 RID: 10100
	public AudioClip[] EightiesFourNo;

	// Token: 0x04002775 RID: 10101
	public AudioClip[] EightiesFiveFull;

	// Token: 0x04002776 RID: 10102
	public AudioClip[] EightiesFiveHalf;

	// Token: 0x04002777 RID: 10103
	public AudioClip[] EightiesFiveNo;

	// Token: 0x04002778 RID: 10104
	public AudioClip[] EightiesSixFull;

	// Token: 0x04002779 RID: 10105
	public AudioClip[] EightiesSixHalf;

	// Token: 0x0400277A RID: 10106
	public AudioClip[] EightiesSixNo;
}
