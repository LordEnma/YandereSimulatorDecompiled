// Decompiled with JetBrains decompiler
// Type: EnterGuardStateColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EnterGuardStateColliderScript : MonoBehaviour
{
  public int Frame;

  private void Update()
  {
    ++this.Frame;
    if (this.Frame <= 1)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || !component.Teacher)
      return;
    component.CharacterAnimation.CrossFade(component.GuardAnim);
    component.IgnoringPettyActions = true;
    component.Pathfinding.canSearch = false;
    component.Pathfinding.canMove = false;
    component.ReportPhase = 6;
    component.Guarding = true;
    component.Routine = false;
  }
}
