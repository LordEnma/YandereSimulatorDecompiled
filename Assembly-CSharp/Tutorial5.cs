// Decompiled with JetBrains decompiler
// Type: Tutorial5
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
