// Decompiled with JetBrains decompiler
// Type: DuplicateFootprintDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DuplicateFootprintDetectorScript : MonoBehaviour
{
  public FootprintScript Footprint;
  public bool Right;
  public int Frame;

  private void Update()
  {
    ++this.Frame;
    if (this.Frame <= 1)
      return;
    this.enabled = false;
  }

  private void OnTriggerStay(Collider other)
  {
    if (!this.enabled || other.gameObject.layer != 14)
      return;
    if (this.Right)
      ++this.Footprint.Yandere.RightFootprintSpawner.Bloodiness;
    else
      ++this.Footprint.Yandere.LeftFootprintSpawner.Bloodiness;
    Object.Destroy((Object) this.gameObject);
  }
}
