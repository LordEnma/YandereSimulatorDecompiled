// Decompiled with JetBrains decompiler
// Type: RainbowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RainbowScript : MonoBehaviour
{
  [SerializeField]
  private Renderer MyRenderer;
  [SerializeField]
  private float cyclesPerSecond;
  [SerializeField]
  private float percent;

  private void Start()
  {
    this.MyRenderer.material.color = Color.red;
    this.cyclesPerSecond = 0.25f;
  }

  private void Update()
  {
    this.percent = (float) (((double) this.percent + (double) Time.deltaTime * (double) this.cyclesPerSecond) % 1.0);
    this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
  }
}
