// Decompiled with JetBrains decompiler
// Type: MusicRatingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicRatingScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public AudioSource SFX;
  public float Speed;
  public float Timer;

  private void Start()
  {
    if (!((Object) this.SFX != (Object) null))
      return;
    this.SFX.pitch = Random.Range(0.9f, 1.1f);
  }

  private void Update()
  {
    this.transform.localPosition += new Vector3(0.0f, this.Speed * Time.deltaTime, 0.0f);
    this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(0.2f, 0.1f, 0.1f), Time.deltaTime);
    this.Timer += Time.deltaTime * 5f;
    if ((double) this.Timer <= 1.0)
      return;
    this.MyRenderer.material.color = new Color(1f, 1f, 1f, 2f - this.Timer);
    if ((double) this.MyRenderer.material.color.a > 0.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
