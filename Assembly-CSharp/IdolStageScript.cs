// Decompiled with JetBrains decompiler
// Type: IdolStageScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IdolStageScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public AudioSource[] Music;
  public Transform[] Spot;
  public Transform Yandere;
  public bool RestoreVolume;

  private void Update()
  {
    for (int index = 1; index < 5; ++index)
    {
      if ((Object) this.StudentManager.Students[51 + index] != (Object) null)
        this.Music[index].volume = (double) Vector3.Distance(this.StudentManager.Students[51 + index].transform.position, this.Spot[index].position) >= 1.0 || !this.StudentManager.Students[51 + index].Routine || this.StudentManager.Students[51 + index].Alarmed ? Mathf.MoveTowards(this.Music[index].volume, 0.0f, Time.deltaTime) : Mathf.MoveTowards(this.Music[index].volume, 1f, Time.deltaTime);
    }
    if ((Object) this.StudentManager.Students[16] != (Object) null)
      this.Music[5].volume = (double) Vector3.Distance(this.StudentManager.Students[16].transform.position, this.Spot[5].position) >= 1.0 || !this.StudentManager.Students[16].Routine || this.StudentManager.Students[16].Alarmed ? Mathf.MoveTowards(this.Music[5].volume, 0.0f, Time.deltaTime) : Mathf.MoveTowards(this.Music[5].volume, 1f, Time.deltaTime);
    if ((double) Vector3.Distance(this.Yandere.position, this.transform.position) < 10.0)
    {
      this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 0.0f, Time.deltaTime);
      this.RestoreVolume = true;
    }
    else
    {
      if (!this.RestoreVolume)
        return;
      this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 1f, Time.deltaTime);
      if ((double) this.Jukebox.Dip != 0.0)
        return;
      this.RestoreVolume = false;
    }
  }
}
