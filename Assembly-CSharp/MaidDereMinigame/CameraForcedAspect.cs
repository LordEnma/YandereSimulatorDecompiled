// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.CameraForcedAspect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (Camera))]
  public class CameraForcedAspect : MonoBehaviour
  {
    public Vector2 targetAspect = new Vector2(16f, 9f);
    private Camera cam;

    private void Awake() => this.cam = this.GetComponent<Camera>();

    private void Start()
    {
      float num1 = (float) Screen.width / (float) Screen.height / (this.targetAspect.x / this.targetAspect.y);
      if ((double) num1 < 1.0)
      {
        this.cam.rect = this.cam.rect with
        {
          width = 1f,
          height = num1,
          x = 0.0f,
          y = (float) ((1.0 - (double) num1) / 2.0)
        };
      }
      else
      {
        Rect rect = this.cam.rect;
        float num2 = 1f / num1;
        rect.width = num2;
        rect.height = 1f;
        rect.x = (float) ((1.0 - (double) num2) / 2.0);
        rect.y = 0.0f;
        this.cam.rect = rect;
      }
    }
  }
}
