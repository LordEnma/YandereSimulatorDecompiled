// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SFXController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
  public class SFXController : MonoBehaviour
  {
    private static SFXController instance;
    [Reorderable]
    public SoundEmitters emitters;

    public static SFXController Instance
    {
      get
      {
        if ((Object) SFXController.instance == (Object) null)
          SFXController.instance = Object.FindObjectOfType<SFXController>();
        return SFXController.instance;
      }
    }

    private void Awake()
    {
      if ((Object) SFXController.Instance != (Object) this)
        Object.Destroy((Object) this.gameObject);
      else
        Object.DontDestroyOnLoad((Object) this.gameObject);
    }

    public static void PlaySound(SFXController.Sounds sound)
    {
      SoundEmitter emitter = SFXController.Instance.GetEmitter(sound);
      AudioSource source = emitter.GetSource();
      if (source.isPlaying && !emitter.interupt)
        return;
      source.clip = SFXController.Instance.GetRandomClip(emitter);
      source.Play();
    }

    private SoundEmitter GetEmitter(SFXController.Sounds sound)
    {
      foreach (SoundEmitter emitter in (ReorderableArray<SoundEmitter>) this.emitters)
      {
        if (emitter.sound == sound)
          return emitter;
      }
      Debug.Log((object) string.Format("There is no sound emitter created for {0}", (object) sound), (Object) this);
      return (SoundEmitter) null;
    }

    private AudioClip GetRandomClip(SoundEmitter emitter)
    {
      int index = Random.Range(0, emitter.clips.Count);
      return emitter.clips[index];
    }

    public enum Sounds
    {
      Countdown,
      MenuBack,
      MenuConfirm,
      ClockTick,
      DoorBell,
      GameFail,
      GameSuccess,
      Plate,
      PageTurn,
      MenuSelect,
      MaleCustomerGreet,
      MaleCustomerThank,
      MaleCustomerLeave,
      FemaleCustomerGreet,
      FemaleCustomerThank,
      FemaleCustomerLeave,
      MenuOpen,
    }
  }
}
