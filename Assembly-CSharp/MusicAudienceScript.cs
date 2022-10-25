// Decompiled with JetBrains decompiler
// Type: MusicAudienceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicAudienceScript : MonoBehaviour
{
  public MusicMinigameScript MusicMinigame;
  public float JumpStrength;
  public float Threshold;
  public float Minimum;
  public float Jump;

  private void Start() => this.JumpStrength += Random.Range(-0.0001f, 0.0001f);

  private void Update()
  {
    this.Minimum = (double) this.MusicMinigame.Health < (double) this.Threshold ? Mathf.MoveTowards(this.Minimum, 0.0f, Time.deltaTime * 0.1f) : Mathf.MoveTowards(this.Minimum, 0.2f, Time.deltaTime * 0.1f);
    this.transform.localPosition += new Vector3(0.0f, this.Jump, 0.0f);
    this.Jump -= Time.deltaTime * 0.01f;
    if ((double) this.transform.localPosition.y >= (double) this.Minimum)
      return;
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.Minimum, 0.0f);
    this.Jump = this.JumpStrength;
  }
}
