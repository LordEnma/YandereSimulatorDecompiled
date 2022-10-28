// Decompiled with JetBrains decompiler
// Type: FootstepScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FootstepScript : MonoBehaviour
{
  public StudentScript Student;
  public AudioSource MyAudio;
  public AudioClip[] WalkFootsteps;
  public AudioClip[] RunFootsteps;
  public float DownThreshold = 0.02f;
  public float UpThreshold = 0.025f;
  public bool FootUp;

  private void Start()
  {
    if (this.Student.Nemesis)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (!this.FootUp)
    {
      if ((double) this.transform.position.y <= (double) this.Student.transform.position.y + (double) this.UpThreshold)
        return;
      this.FootUp = true;
    }
    else
    {
      if ((double) this.transform.position.y >= (double) this.Student.transform.position.y + (double) this.DownThreshold)
        return;
      if (this.FootUp)
      {
        if ((double) this.Student.Pathfinding.speed > 1.0)
        {
          this.MyAudio.clip = this.RunFootsteps[Random.Range(0, this.RunFootsteps.Length)];
          this.MyAudio.volume = 0.2f;
        }
        else
        {
          this.MyAudio.clip = this.WalkFootsteps[Random.Range(0, this.WalkFootsteps.Length)];
          this.MyAudio.volume = 0.1f;
        }
        this.MyAudio.Play();
      }
      this.FootUp = false;
    }
  }
}
