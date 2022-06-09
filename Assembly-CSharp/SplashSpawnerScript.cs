// Decompiled with JetBrains decompiler
// Type: SplashSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SplashSpawnerScript : MonoBehaviour
{
  public GameObject BloodSplash;
  public Transform Yandere;
  public bool Bloody;
  public bool FootUp;
  public float DownThreshold;
  public float UpThreshold;
  public float Height;

  private void Update()
  {
    if (!this.FootUp)
    {
      if ((double) this.transform.position.y <= (double) this.Yandere.transform.position.y + (double) this.UpThreshold)
        return;
      this.FootUp = true;
    }
    else
    {
      if ((double) this.transform.position.y >= (double) this.Yandere.transform.position.y + (double) this.DownThreshold)
        return;
      this.FootUp = false;
      if (!this.Bloody)
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.BloodSplash, new Vector3(this.transform.position.x, this.Yandere.position.y, this.transform.position.z), Quaternion.identity);
      gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
      this.Bloody = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "BloodPool(Clone)"))
      return;
    this.Bloody = true;
  }
}
