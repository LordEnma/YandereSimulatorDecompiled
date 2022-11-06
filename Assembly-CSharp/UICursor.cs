// Decompiled with JetBrains decompiler
// Type: UICursor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UISprite))]
[AddComponentMenu("NGUI/Examples/UI Cursor")]
public class UICursor : MonoBehaviour
{
  public static UICursor instance;
  public Camera uiCamera;
  private Transform mTrans;
  private UISprite mSprite;
  private INGUIAtlas mAtlas;
  private string mSpriteName;

  private void Awake() => UICursor.instance = this;

  private void OnDestroy() => UICursor.instance = (UICursor) null;

  private void Start()
  {
    this.mTrans = this.transform;
    this.mSprite = this.GetComponentInChildren<UISprite>();
    if ((Object) this.uiCamera == (Object) null)
      this.uiCamera = NGUITools.FindCameraForLayer(this.gameObject.layer);
    if (!((Object) this.mSprite != (Object) null))
      return;
    this.mAtlas = this.mSprite.atlas;
    this.mSpriteName = this.mSprite.spriteName;
    if (this.mSprite.depth >= 100)
      return;
    this.mSprite.depth = 100;
  }

  private void Update()
  {
    Vector3 mousePosition = Input.mousePosition;
    if ((Object) this.uiCamera != (Object) null)
    {
      mousePosition.x = Mathf.Clamp01(mousePosition.x / (float) Screen.width);
      mousePosition.y = Mathf.Clamp01(mousePosition.y / (float) Screen.height);
      this.mTrans.position = this.uiCamera.ViewportToWorldPoint(mousePosition);
      if (!this.uiCamera.orthographic)
        return;
      Vector3 localPosition = this.mTrans.localPosition;
      localPosition.x = Mathf.Round(localPosition.x);
      localPosition.y = Mathf.Round(localPosition.y);
      this.mTrans.localPosition = localPosition;
    }
    else
    {
      mousePosition.x -= (float) Screen.width * 0.5f;
      mousePosition.y -= (float) Screen.height * 0.5f;
      mousePosition.x = Mathf.Round(mousePosition.x);
      mousePosition.y = Mathf.Round(mousePosition.y);
      this.mTrans.localPosition = mousePosition;
    }
  }

  public static void Clear()
  {
    if (!((Object) UICursor.instance != (Object) null) || !((Object) UICursor.instance.mSprite != (Object) null))
      return;
    UICursor.Set(UICursor.instance.mAtlas, UICursor.instance.mSpriteName);
  }

  public static void Set(INGUIAtlas atlas, string sprite)
  {
    if (!((Object) UICursor.instance != (Object) null) || !(bool) (Object) UICursor.instance.mSprite)
      return;
    UICursor.instance.mSprite.atlas = atlas;
    UICursor.instance.mSprite.spriteName = sprite;
    UICursor.instance.mSprite.MakePixelPerfect();
    UICursor.instance.Update();
  }
}
