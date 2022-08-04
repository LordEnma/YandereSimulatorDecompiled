// Decompiled with JetBrains decompiler
// Type: UpthrustScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UpthrustScript : MonoBehaviour
{
  [SerializeField]
  private float amplitude = 0.1f;
  [SerializeField]
  private float frequency = 0.6f;
  [SerializeField]
  private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);
  private Vector3 startPosition;

  private void Start() => this.startPosition = this.transform.localPosition;

  private void Update()
  {
    float num = this.amplitude * Mathf.Sin(6.28318548f * this.frequency * Time.time);
    this.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
    this.transform.Rotate(this.rotationAmplitude * num);
  }

  private Vector3 evaluatePosition(float time) => new Vector3(0.0f, this.amplitude * Mathf.Sin(6.28318548f * this.frequency * time), 0.0f);
}
