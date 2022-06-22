// Decompiled with JetBrains decompiler
// Type: WaterBob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
  [SerializeField]
  private float height = 0.1f;
  [SerializeField]
  private float period = 1f;
  private Vector3 initialPosition;
  private float offset;

  private void Awake()
  {
    this.initialPosition = this.transform.position;
    this.offset = (float) (1.0 - (double) Random.value * 2.0);
  }

  private void Update() => this.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
}
