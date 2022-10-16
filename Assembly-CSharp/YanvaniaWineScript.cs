// Decompiled with JetBrains decompiler
// Type: YanvaniaWineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaWineScript : MonoBehaviour
{
  public GameObject Shards;
  public float Rotation;

  private void Update()
  {
    if (!((Object) this.transform.parent == (Object) null))
      return;
    this.Rotation += Time.deltaTime * 360f;
    this.transform.localEulerAngles = new Vector3(this.Rotation, this.Rotation, this.Rotation);
    if ((double) this.transform.position.y >= 6.75)
      return;
    Object.Instantiate<GameObject>(this.Shards, new Vector3(this.transform.position.x, 6.75f, this.transform.position.z), Quaternion.identity).transform.localEulerAngles = new Vector3(-90f, 0.0f, 0.0f);
    AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, this.transform.position);
    Object.Destroy((Object) this.gameObject);
  }
}
