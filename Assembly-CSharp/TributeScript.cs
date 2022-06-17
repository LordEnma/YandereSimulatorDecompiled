// Decompiled with JetBrains decompiler
// Type: TributeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TributeScript : MonoBehaviour
{
  public RiggedAccessoryAttacher RiggedAttacher;
  public StudentManagerScript StudentManager;
  public HenshinScript Henshin;
  public YandereScript Yandere;
  public GameObject Rainey;
  public string[] MedibangLetters;
  public string[] MiyukiLetters;
  public string[] NurseLetters;
  public string[] AzurLane;
  public string[] Letter;
  public int MedibangID;
  public int MiyukiID;
  public int NurseID;
  public int AzurID;
  public int ID;
  public Mesh ThiccMesh;
  public bool TransformNurse;

  private void Start()
  {
    if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
      this.enabled = false;
    int num = GameGlobals.Eighties ? 1 : 0;
    this.Rainey.SetActive(false);
  }

  private void Update()
  {
    if (this.RiggedAttacher.gameObject.activeInHierarchy)
    {
      this.RiggedAttacher.newRenderer.SetBlendShapeWeight(0, 100f);
      this.RiggedAttacher.newRenderer.SetBlendShapeWeight(1, 100f);
      this.enabled = false;
    }
    else
    {
      if (this.Yandere.PauseScreen.Show || !this.Yandere.CanMove || this.Yandere.NoDebug)
        return;
      if (Input.GetKeyDown(this.Letter[this.ID]))
      {
        ++this.ID;
        if (this.ID == this.Letter.Length)
        {
          this.Rainey.SetActive(true);
          this.enabled = false;
        }
      }
      if (Input.GetKeyDown(this.AzurLane[this.AzurID]))
      {
        ++this.AzurID;
        if (this.AzurID == this.AzurLane.Length)
        {
          this.Yandere.AzurLane();
          this.enabled = false;
        }
      }
      if (Input.GetKeyDown(this.NurseLetters[this.NurseID]) || this.TransformNurse)
      {
        ++this.NurseID;
        if (this.NurseID == this.NurseLetters.Length)
        {
          this.RiggedAttacher.root = this.StudentManager.Students[90].Hips.parent.gameObject;
          this.RiggedAttacher.Student = this.StudentManager.Students[90];
          this.RiggedAttacher.gameObject.SetActive(true);
          this.StudentManager.Students[90].MyRenderer.enabled = false;
        }
      }
      if (Input.GetKeyDown(this.MedibangLetters[this.MedibangID]))
      {
        ++this.MedibangID;
        if (this.MedibangID == this.MedibangLetters.Length)
        {
          this.Yandere.Medibang();
          this.enabled = false;
        }
      }
      if (!this.Yandere.Armed || this.Yandere.EquippedWeapon.WeaponID != 14 || !Input.GetKeyDown(this.MiyukiLetters[this.MiyukiID]))
        return;
      ++this.MiyukiID;
      if (this.MiyukiID != this.MiyukiLetters.Length)
        return;
      this.Henshin.TransformYandere();
      this.Yandere.CanMove = false;
      this.enabled = false;
    }
  }
}
