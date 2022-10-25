// Decompiled with JetBrains decompiler
// Type: ElectrifiedPuddleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ElectrifiedPuddleScript : MonoBehaviour
{
  public PowerSwitchScript PowerSwitch;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == 9)
    {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if ((Object) component != (Object) null && !component.Electrified && (Object) component.Yandere.Pursuer != (Object) component)
      {
        component.Yandere.GazerEyes.ElectrocuteStudent(component);
        this.gameObject.SetActive(false);
        if ((Object) this.PowerSwitch != (Object) null)
          this.PowerSwitch.On = false;
      }
    }
    if (other.gameObject.layer != 13)
      return;
    YandereScript component1 = other.gameObject.GetComponent<YandereScript>();
    if (!((Object) component1 != (Object) null) || component1.WearingRaincoat)
      return;
    if (component1.TimeSkipping)
    {
      component1.StudentManager.Clock.EndTimeSkip();
      component1.CanMoveTimer = 0.0f;
    }
    component1.StudentManager.Headmaster.Taze();
    component1.StudentManager.Headmaster.Heartbroken.Headmaster = false;
  }
}
