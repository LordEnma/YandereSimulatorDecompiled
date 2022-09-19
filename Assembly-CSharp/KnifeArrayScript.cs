// Decompiled with JetBrains decompiler
// Type: KnifeArrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class KnifeArrayScript : MonoBehaviour
{
  public GlobalKnifeArrayScript GlobalKnifeArray;
  public Transform KnifeTarget;
  public float[] SpawnTimes;
  public GameObject Knife;
  public float Timer;
  public int ID;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (this.ID < 10)
    {
      if ((double) this.Timer <= (double) this.SpawnTimes[this.ID] || this.GlobalKnifeArray.ID >= 1000)
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.Knife, this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.transform;
      gameObject.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f), Random.Range(-0.75f, -1.75f));
      gameObject.transform.parent = (Transform) null;
      gameObject.transform.LookAt(this.KnifeTarget);
      this.GlobalKnifeArray.Knives[this.GlobalKnifeArray.ID] = gameObject.GetComponent<TimeStopKnifeScript>();
      ++this.GlobalKnifeArray.ID;
      ++this.ID;
    }
    else
      Object.Destroy((Object) this.gameObject);
  }
}
