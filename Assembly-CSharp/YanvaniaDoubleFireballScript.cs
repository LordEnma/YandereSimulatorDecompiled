// Decompiled with JetBrains decompiler
// Type: YanvaniaDoubleFireballScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaDoubleFireballScript : MonoBehaviour
{
  public GameObject Lavaball;
  public GameObject FirstLavaball;
  public GameObject SecondLavaball;
  public GameObject LightningEffect;
  public Transform Dracula;
  public bool SpawnedFirst;
  public bool SpawnedSecond;
  public float FirstPosition;
  public float SecondPosition;
  public int Direction;
  public float Timer;
  public float Speed;

  private void Start()
  {
    Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(this.transform.position.x, 8f, 0.0f), Quaternion.identity);
    this.Direction = (double) this.Dracula.position.x > (double) this.transform.position.x ? -1 : 1;
  }

  private void Update()
  {
    if ((double) this.Timer > 1.0 && !this.SpawnedFirst)
    {
      Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(this.transform.position.x, 7f, 0.0f), Quaternion.identity);
      this.FirstLavaball = Object.Instantiate<GameObject>(this.Lavaball, new Vector3(this.transform.position.x, 8f, 0.0f), Quaternion.identity);
      this.FirstLavaball.transform.localScale = Vector3.zero;
      this.SpawnedFirst = true;
    }
    if ((Object) this.FirstLavaball != (Object) null)
    {
      this.FirstLavaball.transform.localScale = Vector3.Lerp(this.FirstLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.FirstPosition += (double) this.FirstPosition == 0.0 ? Time.deltaTime : this.FirstPosition * this.Speed;
      this.FirstLavaball.transform.position = new Vector3(this.FirstLavaball.transform.position.x + this.FirstPosition * (float) this.Direction, this.FirstLavaball.transform.position.y, this.FirstLavaball.transform.position.z);
      this.FirstLavaball.transform.eulerAngles = new Vector3(this.FirstLavaball.transform.eulerAngles.x, this.FirstLavaball.transform.eulerAngles.y, this.FirstLavaball.transform.eulerAngles.z - (float) ((double) this.FirstPosition * (double) this.Direction * 36.0));
    }
    if ((double) this.Timer > 2.0 && !this.SpawnedSecond)
    {
      this.SecondLavaball = Object.Instantiate<GameObject>(this.Lavaball, new Vector3(this.transform.position.x, 7f, 0.0f), Quaternion.identity);
      this.SecondLavaball.transform.localScale = Vector3.zero;
      this.SpawnedSecond = true;
    }
    if ((Object) this.SecondLavaball != (Object) null)
    {
      this.SecondLavaball.transform.localScale = Vector3.Lerp(this.SecondLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if ((double) this.SecondPosition == 0.0)
        this.SecondPosition += Time.deltaTime;
      else
        this.SecondPosition += this.SecondPosition * this.Speed;
      this.SecondLavaball.transform.position = new Vector3(this.SecondLavaball.transform.position.x + this.SecondPosition * (float) this.Direction, this.SecondLavaball.transform.position.y, this.SecondLavaball.transform.position.z);
      this.SecondLavaball.transform.eulerAngles = new Vector3(this.SecondLavaball.transform.eulerAngles.x, this.SecondLavaball.transform.eulerAngles.y, this.SecondLavaball.transform.eulerAngles.z - (float) ((double) this.SecondPosition * (double) this.Direction * 36.0));
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 10.0)
      return;
    if ((Object) this.FirstLavaball != (Object) null)
      Object.Destroy((Object) this.FirstLavaball);
    if ((Object) this.SecondLavaball != (Object) null)
      Object.Destroy((Object) this.SecondLavaball);
    Object.Destroy((Object) this.gameObject);
  }
}
