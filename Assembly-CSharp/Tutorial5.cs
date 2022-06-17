// Decompiled with JetBrains decompiler
// Type: Tutorial5
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
