// Decompiled with JetBrains decompiler
// Type: Letterboxing
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
public class Letterboxing : MonoBehaviour
{
  private const float KEEP_ASPECT = 1.777778f;

  private void Start()
  {
    float num = (float) (1.0 - (double) ((float) Screen.width / (float) Screen.height) / 1.77777779102325);
    this.GetComponent<Camera>().rect = new Rect(0.0f, num / 2f, 1f, 1f - num);
  }
}
