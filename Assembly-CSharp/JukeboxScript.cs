// Decompiled with JetBrains decompiler
// Type: JukeboxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class JukeboxScript : MonoBehaviour
{
  public YandereScript Yandere;
  public AudioSource ClubTheme;
  public AudioSource SFX;
  public AudioSource AttackOnTitan;
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
      this.ClubThemes[5] = this.EightiesMusicClubTheme;
    }
    if (!this.Initialized)
    {
      this.BGM = Random.Range(1, this.BGMLimit + 1);
      this.Initialized = true;
    }
    else
    {
      ++this.BGM;
      if (this.BGM > this.BGMLimit)
        this.BGM = 1;
      else if (this.BGM == 0)
        this.BGM = this.BGMLimit;
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
    int index;
    switch (SchoolAtmosphere.Type)
    {
      case SchoolAtmosphereType.High:
        index = 3;
        break;
      case SchoolAtmosphereType.Medium:
        index = 2;
        break;
      default:
        index = 1;
        break;
    }
    if ((double) SchoolGlobals.SchoolAtmosphere <= 0.800000011920929)
      this.ClubThemes[7] = this.LowPhotographyClubTheme;
    this.FullSanity.clip = this.FullSanities[index];
    this.HalfSanity.clip = this.HalfSanities[index];
    this.NoSanity.clip = this.NoSanities[index];
    this.Volume = 0.25f;
    this.FullSanity.volume = 0.0f;
    this.Hitman.time = 26f;
  }

  private void Update()
  {
    if (!this.Yandere.PauseScreen.Show && !this.Yandere.EasterEggMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.M))
      this.StartStopMusic();
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
        if (!this.ClubTheme.isPlaying)
        {
          if ((double) this.Yandere.Sanity >= 66.666664123535156)
          {
            this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.0166666675f * this.FadeSpeed);
            this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
            this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
          }
          else if ((double) this.Yandere.Sanity >= 33.333332061767578)
          {
            this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
            this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.0166666675f * this.FadeSpeed);
            this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
          }
          else
          {
            this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
            this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
            this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, this.Volume * this.Dip - this.ClubDip, 0.0166666675f * this.FadeSpeed);
          }
        }
        else
        {
          this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
          this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
          this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0.0f, 0.0166666675f * this.FadeSpeed);
        }
      }
    }
    else
    {
      this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, 0.166666672f);
      this.Megalovania.volume = Mathf.MoveTowards(this.Megalovania.volume, this.Volume * this.Dip, 0.166666672f);
      this.MissionMode.volume = Mathf.MoveTowards(this.MissionMode.volume, this.Volume * this.Dip, 0.166666672f);
      this.Skeletons.volume = Mathf.MoveTowards(this.Skeletons.volume, this.Volume * this.Dip, 0.166666672f);
      this.Vaporwave.volume = Mathf.MoveTowards(this.Vaporwave.volume, this.Volume * this.Dip, 0.166666672f);
      this.AzurLane.volume = Mathf.MoveTowards(this.AzurLane.volume, this.Volume * this.Dip, 0.166666672f);
      this.LifeNote.volume = Mathf.MoveTowards(this.LifeNote.volume, this.Volume * this.Dip, 0.166666672f);
      this.Berserk.volume = Mathf.MoveTowards(this.Berserk.volume, this.Volume * this.Dip, 0.166666672f);
      this.Metroid.volume = Mathf.MoveTowards(this.Metroid.volume, this.Volume * this.Dip, 0.166666672f);
      this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, 0.166666672f);
      this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, 0.166666672f);
      this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, 0.166666672f);
      this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, 0.166666672f);
      this.Hitman.volume = Mathf.MoveTowards(this.Hitman.volume, this.Volume * this.Dip, 0.166666672f);
      this.Touhou.volume = Mathf.MoveTowards(this.Touhou.volume, this.Volume * this.Dip, 0.166666672f);
      this.Falcon.volume = Mathf.MoveTowards(this.Falcon.volume, this.Volume * this.Dip, 0.166666672f);
      this.Miyuki.volume = Mathf.MoveTowards(this.Miyuki.volume, this.Volume * this.Dip, 0.166666672f);
      this.Demon.volume = Mathf.MoveTowards(this.Demon.volume, this.Volume * this.Dip, 0.166666672f);
      this.Ebola.volume = Mathf.MoveTowards(this.Ebola.volume, this.Volume * this.Dip, 0.166666672f);
      this.Ninja.volume = Mathf.MoveTowards(this.Ninja.volume, this.Volume * this.Dip, 0.166666672f);
      this.Punch.volume = Mathf.MoveTowards(this.Punch.volume, this.Volume * this.Dip, 0.166666672f);
      this.Galo.volume = Mathf.MoveTowards(this.Galo.volume, this.Volume * this.Dip, 0.166666672f);
      this.Jojo.volume = Mathf.MoveTowards(this.Jojo.volume, this.Volume * this.Dip, 0.166666672f);
      this.Lied.volume = Mathf.MoveTowards(this.Lied.volume, this.Volume * this.Dip, 0.166666672f);
      this.Nier.volume = Mathf.MoveTowards(this.Nier.volume, this.Volume * this.Dip, 0.166666672f);
      this.Sith.volume = Mathf.MoveTowards(this.Sith.volume, this.Volume * this.Dip, 0.166666672f);
      this.DK.volume = Mathf.MoveTowards(this.DK.volume, this.Volume * this.Dip, 0.166666672f);
      this.Horror.volume = Mathf.MoveTowards(this.Horror.volume, this.Volume * this.Dip, 0.166666672f);
      if (this.Custom.enabled)
        this.Custom.volume = Mathf.MoveTowards(this.Custom.volume, this.Volume * this.Dip - this.ClubDip, 0.0166666675f * this.FadeSpeed);
    }
    if (this.Yandere.PauseScreen.Show || this.Yandere.Noticed || !this.Yandere.CanMove || !this.Yandere.EasterEggMenu.activeInHierarchy || this.Egg)
      return;
    if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Alpha4))
    {
      this.Egg = true;
      this.KillVolume();
      this.AttackOnTitan.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.P))
    {
      this.Egg = true;
      this.KillVolume();
      this.Nuclear.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.H))
    {
      this.Egg = true;
      this.KillVolume();
      this.Hatred.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.B))
    {
      this.Egg = true;
      this.KillVolume();
      this.Sukeban.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
    {
      this.Egg = true;
      this.KillVolume();
      this.Slender.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.G))
    {
      this.Egg = true;
      this.KillVolume();
      this.Galo.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.L))
    {
      this.Egg = true;
      this.KillVolume();
      this.Hitman.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
      this.Egg = true;
      this.KillVolume();
      this.Skeletons.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.K))
    {
      this.Egg = true;
      this.KillVolume();
      this.DK.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.C))
    {
      this.Egg = true;
      this.KillVolume();
      this.Touhou.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F))
    {
      this.Egg = true;
      this.KillVolume();
      this.Falcon.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.O))
    {
      this.Egg = true;
      this.KillVolume();
      this.Punch.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.U))
    {
      this.Egg = true;
      this.KillVolume();
      this.Megalovania.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.Q))
    {
      this.Egg = true;
      this.KillVolume();
      this.Metroid.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.Y))
    {
      this.Egg = true;
      this.KillVolume();
      this.Ninja.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.W))
    {
      this.Egg = true;
      this.KillVolume();
      this.Ebola.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha6))
    {
      this.Egg = true;
      this.KillVolume();
      this.Demon.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
    {
      if (Input.GetKeyDown(KeyCode.A))
        this.Sith.pitch = 0.1f;
      this.Egg = true;
      this.KillVolume();
      this.Sith.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F2))
    {
      this.Egg = true;
      this.KillVolume();
      this.Horror.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F3))
    {
      this.Egg = true;
      this.KillVolume();
      this.LifeNote.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F6) || Input.GetKeyDown(KeyCode.F9) || Input.GetKeyDown(KeyCode.F12))
    {
      this.Egg = true;
      this.KillVolume();
      this.Lied.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F7))
    {
      this.Egg = true;
      this.KillVolume();
      this.Berserk.enabled = true;
    }
    else if (Input.GetKeyDown(KeyCode.F8))
    {
      this.Egg = true;
      this.KillVolume();
      this.Nier.enabled = true;
    }
    else
    {
      if (!Input.GetKeyDown(KeyCode.V))
        return;
      this.Egg = true;
      this.KillVolume();
      this.Vaporwave.enabled = true;
    }
  }

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
    }
    else if ((double) this.Volume == 0.0)
    {
      this.FadeSpeed = 1f;
      this.StartMusic = false;
      this.Volume = this.LastVolume;
      this.Start();
    }
    else
    {
      this.LastVolume = this.Volume;
      this.FadeSpeed = 10f;
      this.Volume = 0.0f;
    }
  }

  public void Shipgirl()
  {
    this.Egg = true;
    this.KillVolume();
    this.AzurLane.enabled = true;
  }

  public void MiyukiMusic()
  {
    this.Egg = true;
    this.KillVolume();
    this.Miyuki.enabled = true;
  }

  public void KillVolume()
  {
    this.FullSanity.volume = 0.0f;
    this.HalfSanity.volume = 0.0f;
    this.NoSanity.volume = 0.0f;
    this.Volume = 0.5f;
  }

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

  public void PlayJojo()
  {
    this.Egg = true;
    this.KillVolume();
    this.Jojo.enabled = true;
  }

  public void PlayCustom()
  {
    this.Egg = true;
    this.KillVolume();
    this.Custom.enabled = true;
    this.Custom.Play();
  }
}
