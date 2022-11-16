// Decompiled with JetBrains decompiler
// Type: FallCheckerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FallCheckerScript : MonoBehaviour
{
  public DumpsterLidScript Dumpster;
  public RagdollScript Ragdoll;
  public Collider MyCollider;

  private void OnTriggerEnter(Collider other)
  {
    if (!((Object) this.Ragdoll == (Object) null) || other.gameObject.layer != 11)
      return;
    this.Ragdoll = other.transform.root.gameObject.GetComponent<RagdollScript>();
    this.Ragdoll.Prompt.Hide();
    this.Ragdoll.Prompt.enabled = false;
    this.Ragdoll.Prompt.MyCollider.enabled = false;
    this.Ragdoll.BloodPoolSpawner.enabled = false;
    this.Ragdoll.HideCollider = this.MyCollider;
    if (!this.Ragdoll.Concealed)
      ++this.Ragdoll.Police.HiddenCorpses;
    this.Ragdoll.Hidden = true;
    this.Dumpster.Corpse = this.Ragdoll.gameObject;
    this.Dumpster.Victim = this.Ragdoll.Student;
  }

  private void Update()
  {
    if (!((Object) this.Ragdoll != (Object) null))
      return;
    if ((double) this.Ragdoll.Prompt.transform.localPosition.y > -10.5)
    {
      this.Ragdoll.Prompt.transform.localEulerAngles = new Vector3(-90f, 90f, 0.0f);
      this.Ragdoll.AllColliders[2].transform.localEulerAngles = Vector3.zero;
      this.Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3(0.0f, 0.0f, -80f);
      this.Ragdoll.Prompt.transform.position = new Vector3(this.Dumpster.transform.position.x, this.Ragdoll.Prompt.transform.position.y, this.Dumpster.transform.position.z);
    }
    else
    {
      Debug.Log((object) "A student who was shoved from the school rooftop just landed in a dumpster.");
      Object.Instantiate<GameObject>(this.Ragdoll.Student.AlarmDisc, this.Dumpster.SlideLocation.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
      this.GetComponent<AudioSource>().Play();
      this.Dumpster.Slide = true;
      this.Ragdoll = (RagdollScript) null;
    }
  }
}
