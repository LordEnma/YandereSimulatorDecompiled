// Decompiled with JetBrains decompiler
// Type: Tutorial5
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Tutorial5 : MonoBehaviour
{
  public void SetDurationToCurrentProgress()
  {
    foreach (UITweener componentsInChild in this.GetComponentsInChildren<UITweener>())
      componentsInChild.duration = Mathf.Lerp(2f, 0.5f, UIProgressBar.current.value);
  }
}
