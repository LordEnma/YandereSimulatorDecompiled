// Decompiled with JetBrains decompiler
// Type: EnvelopContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UIWidget))]
[AddComponentMenu("NGUI/Interaction/Envelop Content")]
public class EnvelopContent : MonoBehaviour
{
  public Transform targetRoot;
  public int padLeft;
  public int padRight;
  public int padBottom;
  public int padTop;
  public bool ignoreDisabled = true;
  private bool mStarted;

  private void Start()
  {
    this.mStarted = true;
    this.Execute();
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.Execute();
  }

  [ContextMenu("Execute")]
  public void Execute()
  {
    if ((Object) this.targetRoot == (Object) this.transform)
      Debug.LogError((object) "Target Root object cannot be the same object that has Envelop Content. Make it a sibling instead.", (Object) this);
    else if (NGUITools.IsChild(this.targetRoot, this.transform))
    {
      Debug.LogError((object) "Target Root object should not be a parent of Envelop Content. Make it a sibling instead.", (Object) this);
    }
    else
    {
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(this.transform.parent, this.targetRoot, !this.ignoreDisabled);
      float x = relativeWidgetBounds.min.x + (float) this.padLeft;
      float y = relativeWidgetBounds.min.y + (float) this.padBottom;
      float num1 = relativeWidgetBounds.max.x + (float) this.padRight;
      float num2 = relativeWidgetBounds.max.y + (float) this.padTop;
      this.GetComponent<UIWidget>().SetRect(x, y, num1 - x, num2 - y);
      this.BroadcastMessage("UpdateAnchors", SendMessageOptions.DontRequireReceiver);
      NGUITools.UpdateWidgetCollider(this.gameObject);
    }
  }
}
