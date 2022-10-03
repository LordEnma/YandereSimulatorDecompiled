// Decompiled with JetBrains decompiler
// Type: CubeFlickerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CubeFlickerScript : MonoBehaviour
{
  public Transform[] Cube;

  private void Update()
  {
    this.Cube[0].localScale = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
    this.Cube[1].localScale = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
    this.Cube[2].localScale = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
    this.Cube[3].localScale = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
    this.Cube[4].localScale = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
    this.Cube[0].position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
    this.Cube[1].position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
    this.Cube[2].position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
    this.Cube[3].position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
    this.Cube[4].position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
  }
}
