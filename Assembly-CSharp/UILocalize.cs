// Decompiled with JetBrains decompiler
// Type: UILocalize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UIWidget))]
[AddComponentMenu("NGUI/UI/Localize")]
public class UILocalize : MonoBehaviour
{
  public string key;
  private bool mStarted;

  public string value
  {
    set
    {
      if (string.IsNullOrEmpty(value))
        return;
      UIWidget component = this.GetComponent<UIWidget>();
      UILabel uiLabel = component as UILabel;
      UISprite uiSprite = component as UISprite;
      if ((Object) uiLabel != (Object) null)
      {
        UIInput inParents = NGUITools.FindInParents<UIInput>(uiLabel.gameObject);
        if ((Object) inParents != (Object) null && (Object) inParents.label == (Object) uiLabel)
          inParents.defaultText = value;
        else
          uiLabel.text = value;
      }
      else
      {
        if (!((Object) uiSprite != (Object) null))
          return;
        UIButton inParents = NGUITools.FindInParents<UIButton>(uiSprite.gameObject);
        if ((Object) inParents != (Object) null && (Object) inParents.tweenTarget == (Object) uiSprite.gameObject)
          inParents.normalSprite = value;
        uiSprite.spriteName = value;
        uiSprite.MakePixelPerfect();
      }
    }
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnLocalize();
  }

  private void Start()
  {
    this.mStarted = true;
    this.OnLocalize();
  }

  private void OnLocalize()
  {
    if (string.IsNullOrEmpty(this.key))
    {
      UILabel component = this.GetComponent<UILabel>();
      if ((Object) component != (Object) null)
        this.key = component.text;
    }
    if (string.IsNullOrEmpty(this.key))
      return;
    this.value = Localization.Get(this.key);
  }
}
