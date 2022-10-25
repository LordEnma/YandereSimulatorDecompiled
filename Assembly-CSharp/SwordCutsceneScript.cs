// Decompiled with JetBrains decompiler
// Type: SwordCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SwordCutsceneScript : MonoBehaviour
{
  public Animation YandereAnimation;
  public Animation SwordAnimation;
  public Transform SecondAngle;
  public Transform HeartSegment;
  public Transform[] Segments;
  public float Intensity;

  private void Start()
  {
    this.Segments = this.HeartSegment.gameObject.GetComponentsInChildren<Transform>();
    this.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
    this.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
  }

  private void Update()
  {
    Debug.Log((object) this.YandereAnimation["f02_swordPull_00"].time);
    if (Input.GetKeyDown("space"))
    {
      this.YandereAnimation["f02_swordPull_00"].time = 15f;
      this.SwordAnimation["Sword_Pull"].time = 15f;
    }
    if ((double) this.YandereAnimation["f02_swordPull_00"].time > 33.0)
    {
      if ((double) this.transform.position.x != 0.0)
      {
        this.transform.position = new Vector3(0.0f, 1f, 0.0f);
        this.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
      }
      else
        this.transform.position += new Vector3(0.0f, 0.0f, Time.deltaTime * 0.1f);
    }
    else if ((double) this.YandereAnimation["f02_swordPull_00"].time > 15.5)
    {
      this.transform.position = new Vector3(0.66666f, 1.25f, -1.75f);
      this.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
    }
    else
    {
      if ((double) this.YandereAnimation["f02_swordPull_00"].time <= 10.5)
        return;
      this.transform.position = this.SecondAngle.position;
      this.transform.eulerAngles = this.SecondAngle.eulerAngles;
    }
  }

  private void LateUpdate()
  {
    if ((double) this.YandereAnimation["f02_swordPull_00"].time <= 16.5 || (double) this.YandereAnimation["f02_swordPull_00"].time >= 22.5)
      return;
    this.Intensity += Time.deltaTime;
    foreach (Component segment in this.Segments)
      segment.transform.position += new Vector3(Random.Range(-1f / 1000f * this.Intensity, 1f / 1000f * this.Intensity), Random.Range(-1f / 1000f * this.Intensity, 1f / 1000f * this.Intensity), Random.Range(-1f / 1000f * this.Intensity, 1f / 1000f * this.Intensity));
  }
}
