// Decompiled with JetBrains decompiler
// Type: LanguageSelection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
  private UIPopupList mList;
  private bool mStarted;

  private void Awake() => this.mList = this.GetComponent<UIPopupList>();

  private void Start()
  {
    this.mStarted = true;
    this.Refresh();
    EventDelegate.Add(this.mList.onChange, (EventDelegate.Callback) (() => Localization.language = UIPopupList.current.value));
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.Refresh();
  }

  public void Refresh()
  {
    if (!((Object) this.mList != (Object) null) || Localization.knownLanguages == null)
      return;
    this.mList.Clear();
    int index = 0;
    for (int length = Localization.knownLanguages.Length; index < length; ++index)
      this.mList.items.Add(Localization.knownLanguages[index]);
    this.mList.value = Localization.language;
  }

  private void OnLocalize() => this.Refresh();
}
