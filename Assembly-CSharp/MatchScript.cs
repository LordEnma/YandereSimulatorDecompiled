// Decompiled with JetBrains decompiler
// Type: MatchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MatchScript : MonoBehaviour
{
  public GameObject Distraction;
  public GameObject GiggleDisc;
  public GameObject GasCloud;
  public GameObject Flash;
  public AudioClip Bang;
  public bool StinkBomb;
  public bool Pebble;

  private void Update() => this.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.layer != 0 && collision.gameObject.layer != 8)
      return;
    if (this.StinkBomb)
      Object.Instantiate<GameObject>(this.GasCloud, this.transform.position, Quaternion.identity);
    else if (this.Pebble)
    {
      Object.Instantiate<GameObject>(this.Distraction, this.transform.position, Quaternion.identity);
      AudioSource.PlayClipAtPoint(this.Bang, this.transform.position);
    }
    else
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.GiggleDisc, this.transform.position, Quaternion.identity);
      gameObject.GetComponent<BoxCollider>().size = new Vector3(0.02f, 1f, 0.02f);
      gameObject.GetComponent<GiggleScript>().BangSnap = true;
      AudioSource.PlayClipAtPoint(this.Bang, this.transform.position);
    }
    Object.Instantiate<GameObject>(this.Flash, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
