// Decompiled with JetBrains decompiler
// Type: DeathColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DeathColliderScript : MonoBehaviour
{
  public GenericPromptScript GenericPrompt;
  public AudioSource MyAudio;
  public float Force;

  private void OnTriggerEnter(Collider other)
  {
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if ((Object) component != (Object) null)
    {
      Debug.Log((object) "Crushing a student.");
      if (component.ReturningMisplacedWeapon)
        component.DropMisplacedWeapon();
      component.DeathType = DeathType.Weight;
      component.BecomeRagdoll();
      component.Ragdoll.DisableRigidbodies();
      component.CharacterAnimation.enabled = true;
      component.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      if (!component.Male)
        component.CharacterAnimation.Play("f02_crushed_00");
      else
        component.CharacterAnimation.Play("crushed_00");
      component.transform.position = new Vector3(-28.78f, 100f, 10.386f);
      component.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      component.MapMarker.gameObject.SetActive(false);
      this.GenericPrompt.CrushedStudent = component;
    }
    else
    {
      if (other.gameObject.layer != 15 || !(other.gameObject.name == "Radio"))
        return;
      other.gameObject.GetComponent<RadioScript>().TurnOff();
    }
  }
}
