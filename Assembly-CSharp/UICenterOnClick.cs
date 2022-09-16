// Decompiled with JetBrains decompiler
// Type: UICenterOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center Scroll View on Click")]
public class UICenterOnClick : MonoBehaviour
{
  private void OnClick()
  {
    UICenterOnChild inParents1 = NGUITools.FindInParents<UICenterOnChild>(this.gameObject);
    UIPanel inParents2 = NGUITools.FindInParents<UIPanel>(this.gameObject);
    if ((Object) inParents1 != (Object) null)
    {
      if (!inParents1.enabled)
        return;
      inParents1.CenterOn(this.transform);
    }
    else
    {
      if (!((Object) inParents2 != (Object) null) || inParents2.clipping == UIDrawCall.Clipping.None)
        return;
      UIScrollView component = inParents2.GetComponent<UIScrollView>();
      Vector3 pos = -inParents2.cachedTransform.InverseTransformPoint(this.transform.position);
      if (!component.canMoveHorizontally)
        pos.x = inParents2.cachedTransform.localPosition.x;
      if (!component.canMoveVertically)
        pos.y = inParents2.cachedTransform.localPosition.y;
      SpringPanel.Begin(inParents2.cachedGameObject, pos, 6f);
    }
  }
}
