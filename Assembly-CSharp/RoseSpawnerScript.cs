// Decompiled with JetBrains decompiler
// Type: RoseSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RoseSpawnerScript : MonoBehaviour
{
  public Transform DramaGirl;
  public Transform Target;
  public GameObject Rose;
  public float Timer;
  public float ForwardForce;
  public float UpwardForce;

  private void Start() => this.SpawnRose();

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 0.100000001490116)
      return;
    this.SpawnRose();
  }

  private void SpawnRose()
  {
    GameObject gameObject = Object.Instantiate<GameObject>(this.Rose, this.transform.position, Quaternion.identity);
    gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.ForwardForce);
    gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * this.UpwardForce);
    gameObject.transform.localEulerAngles = new Vector3(Random.Range(0.0f, 360f), Random.Range(0.0f, 360f), Random.Range(0.0f, 360f));
    this.transform.localPosition = new Vector3(Random.Range(-5f, 5f), this.transform.localPosition.y, this.transform.localPosition.z);
    this.transform.LookAt(this.DramaGirl);
    this.Timer = 0.0f;
  }
}
