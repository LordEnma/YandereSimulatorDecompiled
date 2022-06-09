// Decompiled with JetBrains decompiler
// Type: GardenHoleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GardenHoleScript : MonoBehaviour
{
  public YandereScript Yandere;
  public RagdollScript Corpse;
  public PromptScript Prompt;
  public Collider MyCollider;
  public MeshFilter MyMesh;
  public GameObject Carrots;
  public GameObject Pile;
  public Mesh MoundMesh;
  public Mesh HoleMesh;
  public bool Bury;
  public bool Dug;
  public int VictimID;
  public int ID;

  private void Start()
  {
    if (!SchoolGlobals.GetGardenGraveOccupied(this.ID))
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Prompt.DistanceSqr < 10.0)
    {
      if (this.Yandere.Armed)
      {
        if (this.Yandere.EquippedWeapon.WeaponID == 10)
          this.Prompt.HideButton[0] = false;
        else if (this.Prompt.enabled)
          this.Prompt.HideButton[0] = true;
      }
      else if (this.Prompt.enabled)
        this.Prompt.HideButton[0] = true;
    }
    else if (this.Prompt.enabled)
      this.Prompt.HideButton[0] = true;
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Yandere.Chased || this.Yandere.Chasers != 0)
      return;
    foreach (string armedAnim in this.Yandere.ArmedAnims)
      this.Yandere.CharacterAnimation[armedAnim].weight = 0.0f;
    this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z) - this.Yandere.transform.position);
    this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
    this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
    this.Yandere.EquippedWeapon.gameObject.SetActive(false);
    this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = 0.0f;
    this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = 0.0f;
    this.Yandere.FloatingShovel.SetActive(true);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.CanMove = false;
    this.Yandere.DigPhase = 1;
    this.Carrots.SetActive(false);
    this.Prompt.Circle[0].fillAmount = 1f;
    if (!this.Dug)
    {
      this.Yandere.FloatingShovel.GetComponent<Animation>()["Dig"].time = 0.0f;
      this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Dig");
      this.Yandere.Character.GetComponent<Animation>().Play("f02_shovelDig_00");
      this.Yandere.Digging = true;
      this.Prompt.Label[0].text = "     Fill";
      this.MyCollider.isTrigger = true;
      this.MyMesh.mesh = this.HoleMesh;
      this.Pile.SetActive(true);
      this.Dug = true;
    }
    else
    {
      this.Yandere.FloatingShovel.GetComponent<Animation>()["Bury"].time = 0.0f;
      this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Bury");
      this.Yandere.CharacterAnimation.Play("f02_shovelBury_00");
      this.Yandere.Burying = true;
      this.Prompt.Label[0].text = "     Dig";
      this.MyCollider.isTrigger = false;
      this.MyMesh.mesh = this.MoundMesh;
      this.Pile.SetActive(false);
      this.Dug = false;
    }
    if (!this.Bury)
      return;
    --this.Yandere.Police.Corpses;
    if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
      this.Yandere.Police.MurderScene = false;
    if (this.Yandere.Police.Corpses == 0)
      this.Yandere.Police.MurderScene = false;
    this.VictimID = this.Corpse.StudentID;
    this.Corpse.Remove();
    if (this.Corpse.StudentID == this.Yandere.StudentManager.RivalID)
    {
      Debug.Log((object) "Just buried Osana's corpse.");
      this.Yandere.Police.EndOfDay.RivalBuried = true;
    }
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
    this.Prompt.Yandere.StudentManager.UpdateStudents();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Dug || other.gameObject.layer != 11)
      return;
    this.Prompt.Label[0].text = "     Bury";
    this.Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
    this.Bury = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!this.Dug || other.gameObject.layer != 11)
      return;
    this.Prompt.Label[0].text = "     Fill";
    this.Corpse = (RagdollScript) null;
    this.Bury = false;
  }

  public void EndOfDayCheck()
  {
    if (this.VictimID <= 0)
      return;
    StudentGlobals.SetStudentMissing(this.VictimID, true);
    SchoolGlobals.SetGardenGraveOccupied(this.ID, true);
  }
}
