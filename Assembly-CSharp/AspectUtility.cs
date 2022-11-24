// Decompiled with JetBrains decompiler
// Type: AspectUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AspectUtility : MonoBehaviour
{
  public float _wantedAspectRatio = 1.777778f;
  private static float wantedAspectRatio;
  private static Camera cam;
  private static Camera backgroundCam;

  private void Start()
  {
    AspectUtility.cam = this.GetComponent<Camera>();
    if (!(bool) (UnityEngine.Object) AspectUtility.cam)
      AspectUtility.cam = Camera.main;
    if (!(bool) (UnityEngine.Object) AspectUtility.cam)
    {
      Debug.LogError((object) "No camera available");
    }
    else
    {
      AspectUtility.wantedAspectRatio = this._wantedAspectRatio;
      AspectUtility.SetCamera();
    }
  }

  public static void SetCamera()
  {
    float num1 = (float) Screen.width / (float) Screen.height;
    if ((double) (int) ((double) num1 * 100.0) / 100.0 == (double) (int) ((double) AspectUtility.wantedAspectRatio * 100.0) / 100.0)
    {
      AspectUtility.cam.rect = new Rect(0.0f, 0.0f, 1f, 1f);
      if (!(bool) (UnityEngine.Object) AspectUtility.backgroundCam)
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) AspectUtility.backgroundCam.gameObject);
    }
    else
    {
      if ((double) num1 > (double) AspectUtility.wantedAspectRatio)
      {
        float num2 = (float) (1.0 - (double) AspectUtility.wantedAspectRatio / (double) num1);
        AspectUtility.cam.rect = new Rect(num2 / 2f, 0.0f, 1f - num2, 1f);
      }
      else
      {
        float num3 = (float) (1.0 - (double) num1 / (double) AspectUtility.wantedAspectRatio);
        AspectUtility.cam.rect = new Rect(0.0f, num3 / 2f, 1f, 1f - num3);
      }
      if ((bool) (UnityEngine.Object) AspectUtility.backgroundCam)
        return;
      AspectUtility.backgroundCam = new GameObject("BackgroundCam", new System.Type[1]
      {
        typeof (Camera)
      }).GetComponent<Camera>();
      AspectUtility.backgroundCam.depth = (float) int.MinValue;
      AspectUtility.backgroundCam.clearFlags = CameraClearFlags.Color;
      AspectUtility.backgroundCam.backgroundColor = Color.black;
      AspectUtility.backgroundCam.cullingMask = 0;
    }
  }

  public static int screenHeight => (int) ((double) Screen.height * (double) AspectUtility.cam.rect.height);

  public static int screenWidth => (int) ((double) Screen.width * (double) AspectUtility.cam.rect.width);

  public static int xOffset => (int) ((double) Screen.width * (double) AspectUtility.cam.rect.x);

  public static int yOffset => (int) ((double) Screen.height * (double) AspectUtility.cam.rect.y);

  public static Rect screenRect
  {
    get
    {
      Rect rect = AspectUtility.cam.rect;
      double x = (double) rect.x * (double) Screen.width;
      rect = AspectUtility.cam.rect;
      double y = (double) rect.y * (double) Screen.height;
      rect = AspectUtility.cam.rect;
      double width = (double) rect.width * (double) Screen.width;
      rect = AspectUtility.cam.rect;
      double height = (double) rect.height * (double) Screen.height;
      return new Rect((float) x, (float) y, (float) width, (float) height);
    }
  }

  public static Vector3 mousePosition
  {
    get
    {
      Vector3 mousePosition = Input.mousePosition;
      mousePosition.y -= (float) (int) ((double) AspectUtility.cam.rect.y * (double) Screen.height);
      mousePosition.x -= (float) (int) ((double) AspectUtility.cam.rect.x * (double) Screen.width);
      return mousePosition;
    }
  }

  public static Vector2 guiMousePosition
  {
    get
    {
      Vector2 mousePosition = Event.current.mousePosition;
      ref Vector2 local1 = ref mousePosition;
      double y = (double) mousePosition.y;
      Rect rect1 = AspectUtility.cam.rect;
      double min1 = (double) rect1.y * (double) Screen.height;
      rect1 = AspectUtility.cam.rect;
      double num1 = (double) rect1.y * (double) Screen.height;
      rect1 = AspectUtility.cam.rect;
      double num2 = (double) rect1.height * (double) Screen.height;
      double max1 = num1 + num2;
      double num3 = (double) Mathf.Clamp((float) y, (float) min1, (float) max1);
      local1.y = (float) num3;
      ref Vector2 local2 = ref mousePosition;
      double x = (double) mousePosition.x;
      Rect rect2 = AspectUtility.cam.rect;
      double min2 = (double) rect2.x * (double) Screen.width;
      rect2 = AspectUtility.cam.rect;
      double num4 = (double) rect2.x * (double) Screen.width;
      rect2 = AspectUtility.cam.rect;
      double num5 = (double) rect2.width * (double) Screen.width;
      double max2 = num4 + num5;
      double num6 = (double) Mathf.Clamp((float) x, (float) min2, (float) max2);
      local2.x = (float) num6;
      return mousePosition;
    }
  }
}
