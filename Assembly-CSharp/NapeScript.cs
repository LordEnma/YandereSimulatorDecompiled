// Decompiled with JetBrains decompiler
// Type: NapeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NapeScript : MonoBehaviour
{
  public StudentScript MyStudent;
  public GameObject BloodEffect;
  public string Prefix;
  public Collider Nape;

  private void Start()
  {
    this.Nape.enabled = true;
    Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody>();
    rigidbody.useGravity = false;
    rigidbody.isKinematic = true;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "0"))
      return;
    this.MyStudent.CharacterAnimation[this.Prefix + "down_22"].speed = 0.1f;
    this.MyStudent.CharacterAnimation.CrossFade(this.Prefix + "down_22", 1f);
    this.MyStudent.Pathfinding.canSearch = false;
    this.MyStudent.Pathfinding.canMove = false;
    this.MyStudent.Routine = false;
    this.MyStudent.DeathType = DeathType.Weapon;
    this.MyStudent.Yandere.Bloodiness += 20f;
    this.BloodEffect.SetActive(true);
    this.Nape.enabled = false;
    this.enabled = false;
  }
}
