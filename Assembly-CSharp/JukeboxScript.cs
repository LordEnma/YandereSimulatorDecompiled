using UnityEngine;

public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource ClubTheme;

	public AudioSource SFX;

	public AudioSource AttackOnTitan;

	public AudioSource LunarScythe;

	public AudioSource Megalovania;

	public AudioSource MissionMode;

	public AudioSource Skeletons;

	public AudioSource Vaporwave;

	public AudioSource AzurLane;

	public AudioSource LifeNote;

	public AudioSource Berserk;

	public AudioSource Metroid;

	public AudioSource Nuclear;

	public AudioSource Slender;

	public AudioSource Sukeban;

	public AudioSource Custom;

	public AudioSource Hatred;

	public AudioSource Hitman;

	public AudioSource Horror;

	public AudioSource Touhou;

	public AudioSource Falcon;

	public AudioSource Miyuki;

	public AudioSource Ebola;

	public AudioSource Demon;

	public AudioSource Ninja;

	public AudioSource Punch;

	public AudioSource Galo;

	public AudioSource Jojo;

	public AudioSource Lied;

	public AudioSource Nier;

	public AudioSource Sith;

	public AudioSource DK;

	public AudioSource Confession;

	public AudioSource FullSanity;

	public AudioSource HalfSanity;

	public AudioSource NoSanity;

	public AudioSource Chase;

	public float LastVolume;

	public float FadeSpeed;

	public float ClubDip;

	public float Volume;

	public float Dip = 1f;

	public int BGMLimit = 12;

	public int Track;

	public int BGM;

	public bool Initialized;

	public bool StartMusic;

	public bool Egg;

	public AudioClip[] FullSanities;

	public AudioClip[] HalfSanities;

	public AudioClip[] NoSanities;

	public AudioClip[] OriginalFull;

	public AudioClip[] OriginalHalf;

	public AudioClip[] OriginalNo;

	public AudioClip[] AlternateFull;

	public AudioClip[] AlternateHalf;

	public AudioClip[] AlternateNo;

	public AudioClip[] ThirdFull;

	public AudioClip[] ThirdHalf;

	public AudioClip[] ThirdNo;

	public AudioClip[] FourthFull;

	public AudioClip[] FourthHalf;

	public AudioClip[] FourthNo;

	public AudioClip[] FifthFull;

	public AudioClip[] FifthHalf;

	public AudioClip[] FifthNo;

	public AudioClip[] SixthFull;

	public AudioClip[] SixthHalf;

	public AudioClip[] SixthNo;

	public AudioClip[] SeventhFull;

	public AudioClip[] SeventhHalf;

	public AudioClip[] SeventhNo;

	public AudioClip[] EighthFull;

	public AudioClip[] EighthHalf;

	public AudioClip[] EighthNo;

	public AudioClip[] NinthFull;

	public AudioClip[] NinthHalf;

	public AudioClip[] NinthNo;

	public AudioClip[] TenthFull;

	public AudioClip[] TenthHalf;

	public AudioClip[] TenthNo;

	public AudioClip[] EleventhFull;

	public AudioClip[] EleventhHalf;

	public AudioClip[] EleventhNo;

	public AudioClip[] TwelfthFull;

	public AudioClip[] TwelfthHalf;

	public AudioClip[] TwelfthNo;

	public AudioClip[] EightiesOneFull;

	public AudioClip[] EightiesOneHalf;

	public AudioClip[] EightiesOneNo;

	public AudioClip[] EightiesTwoFull;

	public AudioClip[] EightiesTwoHalf;

	public AudioClip[] EightiesTwoNo;

	public AudioClip[] EightiesThreeFull;

	public AudioClip[] EightiesThreeHalf;

	public AudioClip[] EightiesThreeNo;

	public AudioClip[] EightiesFourFull;

	public AudioClip[] EightiesFourHalf;

	public AudioClip[] EightiesFourNo;

	public AudioClip[] EightiesFiveFull;

	public AudioClip[] EightiesFiveHalf;

	public AudioClip[] EightiesFiveNo;

	public AudioClip[] EightiesSixFull;

	public AudioClip[] EightiesSixHalf;

	public AudioClip[] EightiesSixNo;

	public AudioClip[] ClubThemes;

	public AudioClip LowPhotographyClubTheme;

	public AudioClip EightiesMusicClubTheme;

	public GameObject YakuzaMusic;

	public void Start()
	{
		if (GameGlobals.Eighties)
		{
			BGMLimit = 6;
			OriginalFull = EightiesOneFull;
			OriginalHalf = EightiesOneHalf;
			OriginalNo = EightiesOneNo;
			AlternateFull = EightiesTwoFull;
			AlternateHalf = EightiesTwoHalf;
			AlternateNo = EightiesTwoNo;
			ThirdFull = EightiesThreeFull;
			ThirdHalf = EightiesThreeHalf;
			ThirdNo = EightiesThreeNo;
			FourthFull = EightiesFourFull;
			FourthHalf = EightiesFourHalf;
			FourthNo = EightiesFourNo;
			FifthFull = EightiesFiveFull;
			FifthHalf = EightiesFiveHalf;
			FifthNo = EightiesFiveNo;
			SixthFull = EightiesSixFull;
			SixthHalf = EightiesSixHalf;
			SixthNo = EightiesSixNo;
			ClubThemes[5] = EightiesMusicClubTheme;
		}
		if (!Initialized)
		{
			BGM = Random.Range(1, BGMLimit + 1);
			Initialized = true;
		}
		else
		{
			BGM++;
			if (BGM > BGMLimit)
			{
				BGM = 1;
			}
			else if (BGM == 0)
			{
				BGM = BGMLimit;
			}
		}
		if (BGM == 1)
		{
			FullSanities = OriginalFull;
			HalfSanities = OriginalHalf;
			NoSanities = OriginalNo;
		}
		else if (BGM == 2)
		{
			FullSanities = AlternateFull;
			HalfSanities = AlternateHalf;
			NoSanities = AlternateNo;
		}
		else if (BGM == 3)
		{
			FullSanities = ThirdFull;
			HalfSanities = ThirdHalf;
			NoSanities = ThirdNo;
		}
		else if (BGM == 4)
		{
			FullSanities = FourthFull;
			HalfSanities = FourthHalf;
			NoSanities = FourthNo;
		}
		else if (BGM == 5)
		{
			FullSanities = FifthFull;
			HalfSanities = FifthHalf;
			NoSanities = FifthNo;
		}
		else if (BGM == 6)
		{
			FullSanities = SixthFull;
			HalfSanities = SixthHalf;
			NoSanities = SixthNo;
		}
		else if (BGM == 7)
		{
			FullSanities = SeventhFull;
			HalfSanities = SeventhHalf;
			NoSanities = SeventhNo;
		}
		else if (BGM == 8)
		{
			FullSanities = EighthFull;
			HalfSanities = EighthHalf;
			NoSanities = EighthNo;
		}
		else if (BGM == 9)
		{
			FullSanities = NinthFull;
			HalfSanities = NinthHalf;
			NoSanities = NinthNo;
		}
		else if (BGM == 10)
		{
			FullSanities = TenthFull;
			HalfSanities = TenthHalf;
			NoSanities = TenthNo;
		}
		else if (BGM == 11)
		{
			FullSanities = TwelfthFull;
			HalfSanities = TwelfthHalf;
			NoSanities = TwelfthNo;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		int num = 0;
		num = ((SchoolAtmosphere.Type == SchoolAtmosphereType.High) ? 3 : ((SchoolAtmosphere.Type != SchoolAtmosphereType.Medium) ? 1 : 2));
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			ClubThemes[7] = LowPhotographyClubTheme;
		}
		FullSanity.clip = FullSanities[num];
		HalfSanity.clip = HalfSanities[num];
		NoSanity.clip = NoSanities[num];
		Volume = 0.25f;
		FullSanity.volume = 0f;
		Hitman.time = 26f;
	}

	private void Update()
	{
		if (!Yandere.PauseScreen.Show && !Yandere.EasterEggMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.M))
		{
			StartStopMusic();
		}
		if (!Egg)
		{
			if (!Yandere.Police.Clock.SchoolBell.isPlaying && !Yandere.StudentManager.MemorialScene.enabled)
			{
				if (!StartMusic)
				{
					FullSanity.Play();
					HalfSanity.Play();
					NoSanity.Play();
					StartMusic = true;
				}
				if (Yandere.Sanity >= 66.666664f)
				{
					FullSanity.volume = Mathf.MoveTowards(FullSanity.volume, Volume * Dip - ClubDip, 1f / 60f * FadeSpeed);
					HalfSanity.volume = Mathf.MoveTowards(HalfSanity.volume, 0f, 1f / 60f * FadeSpeed);
					NoSanity.volume = Mathf.MoveTowards(NoSanity.volume, 0f, 1f / 60f * FadeSpeed);
				}
				else if (Yandere.Sanity >= 33.333332f)
				{
					FullSanity.volume = Mathf.MoveTowards(FullSanity.volume, 0f, 1f / 60f * FadeSpeed);
					HalfSanity.volume = Mathf.MoveTowards(HalfSanity.volume, Volume * Dip - ClubDip, 1f / 60f * FadeSpeed);
					NoSanity.volume = Mathf.MoveTowards(NoSanity.volume, 0f, 1f / 60f * FadeSpeed);
				}
				else
				{
					FullSanity.volume = Mathf.MoveTowards(FullSanity.volume, 0f, 1f / 60f * FadeSpeed);
					HalfSanity.volume = Mathf.MoveTowards(HalfSanity.volume, 0f, 1f / 60f * FadeSpeed);
					NoSanity.volume = Mathf.MoveTowards(NoSanity.volume, Volume * Dip - ClubDip, 1f / 60f * FadeSpeed);
				}
			}
		}
		else
		{
			AttackOnTitan.volume = Mathf.MoveTowards(AttackOnTitan.volume, Volume * Dip, 1f / 6f);
			LunarScythe.volume = Mathf.MoveTowards(LunarScythe.volume, Volume * Dip, 1f / 6f);
			Megalovania.volume = Mathf.MoveTowards(Megalovania.volume, Volume * Dip, 1f / 6f);
			MissionMode.volume = Mathf.MoveTowards(MissionMode.volume, Volume * Dip, 1f / 6f);
			Skeletons.volume = Mathf.MoveTowards(Skeletons.volume, Volume * Dip, 1f / 6f);
			Vaporwave.volume = Mathf.MoveTowards(Vaporwave.volume, Volume * Dip, 1f / 6f);
			AzurLane.volume = Mathf.MoveTowards(AzurLane.volume, Volume * Dip, 1f / 6f);
			LifeNote.volume = Mathf.MoveTowards(LifeNote.volume, Volume * Dip, 1f / 6f);
			Berserk.volume = Mathf.MoveTowards(Berserk.volume, Volume * Dip, 1f / 6f);
			Metroid.volume = Mathf.MoveTowards(Metroid.volume, Volume * Dip, 1f / 6f);
			Nuclear.volume = Mathf.MoveTowards(Nuclear.volume, Volume * Dip, 1f / 6f);
			Slender.volume = Mathf.MoveTowards(Slender.volume, Volume * Dip, 1f / 6f);
			Sukeban.volume = Mathf.MoveTowards(Sukeban.volume, Volume * Dip, 1f / 6f);
			Hatred.volume = Mathf.MoveTowards(Hatred.volume, Volume * Dip, 1f / 6f);
			Hitman.volume = Mathf.MoveTowards(Hitman.volume, Volume * Dip, 1f / 6f);
			Touhou.volume = Mathf.MoveTowards(Touhou.volume, Volume * Dip, 1f / 6f);
			Falcon.volume = Mathf.MoveTowards(Falcon.volume, Volume * Dip, 1f / 6f);
			Miyuki.volume = Mathf.MoveTowards(Miyuki.volume, Volume * Dip, 1f / 6f);
			Demon.volume = Mathf.MoveTowards(Demon.volume, Volume * Dip, 1f / 6f);
			Ebola.volume = Mathf.MoveTowards(Ebola.volume, Volume * Dip, 1f / 6f);
			Ninja.volume = Mathf.MoveTowards(Ninja.volume, Volume * Dip, 1f / 6f);
			Punch.volume = Mathf.MoveTowards(Punch.volume, Volume * Dip, 1f / 6f);
			Galo.volume = Mathf.MoveTowards(Galo.volume, Volume * Dip, 1f / 6f);
			Jojo.volume = Mathf.MoveTowards(Jojo.volume, Volume * Dip, 1f / 6f);
			Lied.volume = Mathf.MoveTowards(Lied.volume, Volume * Dip, 1f / 6f);
			Nier.volume = Mathf.MoveTowards(Nier.volume, Volume * Dip, 1f / 6f);
			Sith.volume = Mathf.MoveTowards(Sith.volume, Volume * Dip, 1f / 6f);
			DK.volume = Mathf.MoveTowards(DK.volume, Volume * Dip, 1f / 6f);
			Horror.volume = Mathf.MoveTowards(Horror.volume, Volume * Dip, 1f / 6f);
			if (Custom.enabled)
			{
				Custom.volume = Mathf.MoveTowards(Custom.volume, Volume * Dip - ClubDip, 1f / 60f * FadeSpeed);
			}
		}
		if (Yandere.PauseScreen.Show || Yandere.Noticed || !Yandere.CanMove || !Yandere.EasterEggMenu.activeInHierarchy || Egg)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Alpha4))
		{
			Egg = true;
			KillVolume();
			AttackOnTitan.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.P))
		{
			Egg = true;
			KillVolume();
			Nuclear.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			Egg = true;
			KillVolume();
			Hatred.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			Egg = true;
			KillVolume();
			Sukeban.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
		{
			Egg = true;
			KillVolume();
			Slender.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			Egg = true;
			KillVolume();
			Galo.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			Egg = true;
			KillVolume();
			Hitman.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			Egg = true;
			KillVolume();
			Skeletons.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			Egg = true;
			KillVolume();
			DK.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			Egg = true;
			KillVolume();
			Touhou.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F))
		{
			Egg = true;
			KillVolume();
			Falcon.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			Egg = true;
			KillVolume();
			Punch.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.U))
		{
			Egg = true;
			KillVolume();
			Megalovania.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			Egg = true;
			KillVolume();
			Metroid.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.Y))
		{
			Egg = true;
			KillVolume();
			Ninja.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.W))
		{
			Egg = true;
			KillVolume();
			Ebola.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			Egg = true;
			KillVolume();
			Demon.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				Sith.pitch = 0.1f;
			}
			Egg = true;
			KillVolume();
			Sith.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			Egg = true;
			KillVolume();
			Horror.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F3))
		{
			Egg = true;
			KillVolume();
			LifeNote.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F6) || Input.GetKeyDown(KeyCode.F9) || Input.GetKeyDown(KeyCode.F12))
		{
			Egg = true;
			KillVolume();
			Lied.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F7))
		{
			Egg = true;
			KillVolume();
			Berserk.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F8))
		{
			Egg = true;
			KillVolume();
			Nier.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.V))
		{
			Egg = true;
			KillVolume();
			Vaporwave.enabled = true;
		}
	}

	public void StartStopMusic()
	{
		if (Custom.isPlaying)
		{
			Egg = false;
			Custom.Stop();
			FadeSpeed = 1f;
			StartMusic = false;
			Volume = LastVolume;
			Start();
		}
		else if (Volume == 0f)
		{
			FadeSpeed = 1f;
			StartMusic = false;
			Volume = LastVolume;
			Start();
		}
		else
		{
			LastVolume = Volume;
			FadeSpeed = 10f;
			Volume = 0f;
		}
	}

	public void Shipgirl()
	{
		Egg = true;
		KillVolume();
		AzurLane.enabled = true;
	}

	public void MiyukiMusic()
	{
		Egg = true;
		KillVolume();
		Miyuki.enabled = true;
	}

	public void LunarScytheMusic()
	{
		Egg = true;
		KillVolume();
		LunarScythe.enabled = true;
	}

	public void KillVolume()
	{
		FullSanity.volume = 0f;
		HalfSanity.volume = 0f;
		NoSanity.volume = 0f;
		Volume = 0.5f;
	}

	public void GameOver()
	{
		AttackOnTitan.Stop();
		LunarScythe.Stop();
		Megalovania.Stop();
		MissionMode.Stop();
		Skeletons.Stop();
		Vaporwave.Stop();
		AzurLane.Stop();
		LifeNote.Stop();
		Berserk.Stop();
		Metroid.Stop();
		Nuclear.Stop();
		Sukeban.Stop();
		Custom.Stop();
		Slender.Stop();
		Hatred.Stop();
		Hitman.Stop();
		Horror.Stop();
		Touhou.Stop();
		Falcon.Stop();
		Miyuki.Stop();
		Ebola.Stop();
		Punch.Stop();
		Ninja.Stop();
		Jojo.Stop();
		Galo.Stop();
		Lied.Stop();
		Nier.Stop();
		Sith.Stop();
		DK.Stop();
		Confession.Stop();
		FullSanity.Stop();
		HalfSanity.Stop();
		NoSanity.Stop();
	}

	public void PlayJojo()
	{
		Egg = true;
		KillVolume();
		Jojo.enabled = true;
	}

	public void PlayCustom()
	{
		Egg = true;
		KillVolume();
		Custom.enabled = true;
		Custom.Play();
	}
}
