// Decompiled with JetBrains decompiler
// Type: WeaponManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WeaponManagerScript : MonoBehaviour
{
  public WeaponScript[] DelinquentWeapons;
  public WeaponScript[] BroughtWeapons;
  public WeaponScript[] Weapons;
  public Transform[] Dumbbells;
  public YandereScript Yandere;
  public JsonScript JSON;
  public int[] Victims;
  public int MisplacedWeapons;
  public int MurderWeapons;
  public int Fingerprints;
  public int YandereWeapon1 = -1;
  public int YandereWeapon2 = -1;
  public int YandereWeapon3 = -1;
  public int ReturnWeaponID = -1;
  public int ReturnStudentID = -1;
  public int OriginalEquipped = -1;
  public int OriginalWeapon = -1;
  public int WeaponsTouched;
  public int Frame;
  public Texture Flower;
  public Texture Blood;
  public bool DumbbellNear;
  public Transform ChosenDumbbell;
  public bool YandereGuilty;
  public int BloodyWeapons;

  public void Start()
  {
    for (int weaponID = 0; weaponID < this.Weapons.Length; ++weaponID)
    {
      this.Weapons[weaponID].GlobalID = weaponID;
      if (WeaponGlobals.GetWeaponStatus(weaponID) == 1)
        this.Weapons[weaponID].gameObject.SetActive(false);
    }
    int bringingItem = PlayerGlobals.BringingItem;
    if (bringingItem > 0 && bringingItem < this.BroughtWeapons.Length)
      this.BroughtWeapons[bringingItem].gameObject.SetActive(true);
    this.ChangeBloodTexture();
    if (GameGlobals.Eighties)
      return;
    this.DelinquentWeapons[6].gameObject.SetActive(false);
    this.DelinquentWeapons[7].gameObject.SetActive(false);
    this.DelinquentWeapons[8].gameObject.SetActive(false);
    this.DelinquentWeapons[9].gameObject.SetActive(false);
    this.DelinquentWeapons[10].gameObject.SetActive(false);
  }

  public void UpdateLabels()
  {
    foreach (WeaponScript weapon in this.Weapons)
    {
      if ((Object) weapon != (Object) null)
        weapon.UpdateLabel();
    }
  }

  public void CheckWeapons()
  {
    this.MurderWeapons = 0;
    this.Fingerprints = 0;
    for (int index = 0; index < this.Victims.Length; ++index)
      this.Victims[index] = 0;
    foreach (WeaponScript weapon in this.Weapons)
    {
      if ((Object) weapon != (Object) null && weapon.Blood.enabled && !weapon.AlreadyExamined)
      {
        ++this.MurderWeapons;
        if (weapon.FingerprintID > 0)
        {
          ++this.Fingerprints;
          for (int index = 0; index < weapon.Victims.Length; ++index)
          {
            if (weapon.Victims[index])
              this.Victims[index] = weapon.FingerprintID;
          }
        }
      }
    }
  }

  public void CleanWeapons()
  {
    foreach (WeaponScript weapon in this.Weapons)
    {
      if ((Object) weapon != (Object) null)
      {
        weapon.Blood.enabled = false;
        weapon.FingerprintID = 0;
      }
    }
  }

  public void ChangeBloodTexture()
  {
    foreach (WeaponScript weapon in this.Weapons)
    {
      if ((Object) weapon != (Object) null)
      {
        if (!GameGlobals.CensorBlood)
        {
          weapon.Blood.material.mainTexture = this.Blood;
          weapon.Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
        }
        else
        {
          weapon.Blood.material.mainTexture = this.Flower;
          weapon.Blood.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
        }
      }
    }
  }

  private void Update()
  {
    if (this.OriginalWeapon <= -1)
      return;
    Debug.Log((object) "Re-equipping original weapon.");
    this.Yandere.WeaponMenu.Selected = this.OriginalEquipped;
    this.Yandere.WeaponMenu.Equip();
    this.OriginalWeapon = -1;
    ++this.Frame;
  }

  public void TrackDumpedWeapons()
  {
    for (int index = 0; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] == (Object) null)
        Debug.Log((object) ("Weapon #" + index.ToString() + " was destroyed! Setting status to 1!"));
    }
  }

  public void SetEquippedWeapon1(WeaponScript Weapon)
  {
    for (int index = 0; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] == (Object) Weapon)
        this.YandereWeapon1 = index;
    }
  }

  public void SetEquippedWeapon2(WeaponScript Weapon)
  {
    for (int index = 0; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] == (Object) Weapon)
        this.YandereWeapon2 = index;
    }
  }

  public void SetEquippedWeapon3(WeaponScript Weapon)
  {
    for (int index = 0; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] == (Object) Weapon)
        this.YandereWeapon3 = index;
    }
  }

  public void RestoreBlood()
  {
    for (int index = 0; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] != (Object) null && this.Weapons[index].Bloody)
      {
        this.Weapons[index].Blood.enabled = true;
        ++this.Yandere.Police.BloodyWeapons;
      }
    }
  }

  public void EquipWeaponsFromSave()
  {
    this.OriginalEquipped = this.Yandere.Equipped;
    if (this.Yandere.Equipped == 1)
      this.OriginalWeapon = this.YandereWeapon1;
    else if (this.Yandere.Equipped == 2)
      this.OriginalWeapon = this.YandereWeapon2;
    else if (this.Yandere.Equipped == 3)
      this.OriginalWeapon = this.YandereWeapon3;
    if (this.Yandere.Equipped > 0)
      this.Yandere.Unequip();
    if ((Object) this.Yandere.Weapon[1] != (Object) null)
      this.Yandere.Weapon[1].Drop();
    if ((Object) this.Yandere.Weapon[2] != (Object) null)
      this.Yandere.Weapon[2].Drop();
    if (this.YandereWeapon1 > -1)
    {
      this.Weapons[this.YandereWeapon1].Prompt.Circle[3].fillAmount = 0.0f;
      this.Weapons[this.YandereWeapon1].gameObject.SetActive(true);
      this.Weapons[this.YandereWeapon1].UnequipImmediately = true;
    }
    if (this.YandereWeapon2 > -1)
    {
      this.Weapons[this.YandereWeapon2].Prompt.Circle[3].fillAmount = 0.0f;
      this.Weapons[this.YandereWeapon2].gameObject.SetActive(true);
      this.Weapons[this.YandereWeapon2].UnequipImmediately = true;
    }
    if (this.YandereWeapon3 <= -1)
      return;
    this.Weapons[this.YandereWeapon3].Prompt.Circle[3].fillAmount = 0.0f;
    this.Weapons[this.YandereWeapon3].gameObject.SetActive(true);
    this.Weapons[this.YandereWeapon3].UnequipImmediately = true;
  }

  public void UpdateDelinquentWeapons()
  {
    for (int index = 1; index < this.DelinquentWeapons.Length; ++index)
    {
      if (this.DelinquentWeapons[index].DelinquentOwned)
      {
        this.DelinquentWeapons[index].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.DelinquentWeapons[index].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      }
      else
        this.DelinquentWeapons[index].transform.parent = (Transform) null;
    }
  }

  public void RestoreWeaponToStudent()
  {
    if (this.ReturnWeaponID <= -1)
      return;
    this.Yandere.StudentManager.Students[this.ReturnStudentID].BloodPool = this.Weapons[this.ReturnWeaponID].transform;
    this.Yandere.StudentManager.Students[this.ReturnStudentID].BloodPool = this.Weapons[this.ReturnWeaponID].transform;
    this.Yandere.StudentManager.Students[this.ReturnStudentID].BloodPool = this.Weapons[this.ReturnWeaponID].transform;
    this.Yandere.StudentManager.Students[this.ReturnStudentID].CurrentDestination = this.Weapons[this.ReturnWeaponID].Origin;
    this.Yandere.StudentManager.Students[this.ReturnStudentID].Pathfinding.target = this.Weapons[this.ReturnWeaponID].Origin;
    this.Weapons[this.ReturnWeaponID].Prompt.Hide();
    this.Weapons[this.ReturnWeaponID].Prompt.enabled = false;
    this.Weapons[this.ReturnWeaponID].enabled = false;
    this.Weapons[this.ReturnWeaponID].Returner = this.Yandere.StudentManager.Students[this.ReturnStudentID];
    this.Weapons[this.ReturnWeaponID].transform.parent = this.Yandere.StudentManager.Students[this.ReturnStudentID].RightHand;
    this.Weapons[this.ReturnWeaponID].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.Weapons[this.ReturnWeaponID].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.Yandere.StudentManager.Students[this.ReturnStudentID].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
  }

  public void UpdateAllWeapons()
  {
    for (int index = 1; index < this.Weapons.Length; ++index)
      this.Weapons[index].SuspicionCheck();
  }

  public void CountBloodyWeapons()
  {
    this.BloodyWeapons = 0;
    for (int index = 1; index < this.Weapons.Length; ++index)
    {
      if ((Object) this.Weapons[index] != (Object) null && this.Weapons[index].gameObject.activeInHierarchy && this.Weapons[index].Bloody)
        ++this.BloodyWeapons;
    }
  }

  public void DisableAllWeapons()
  {
    for (int index = 1; index < this.Weapons.Length; ++index)
      this.Weapons[index].gameObject.SetActive(false);
  }

  public void PutWeaponInBag()
  {
    Debug.Log((object) "Checking whether or not a weapon was in the weapon bag at the time of saving.");
    for (int index = 1; index < this.Weapons.Length; ++index)
    {
      if (this.Weapons[index].InBag)
      {
        Debug.Log((object) "A weapon belongs in a bag!");
        this.Yandere.StudentManager.WeaponBag.ConcealedWeapon = this.Weapons[index];
        this.Yandere.StudentManager.WeaponBag.PutWeaponInBag();
      }
    }
  }

  public void DumbbellCheck(int StudentID)
  {
    for (int index = 1; index < this.Dumbbells.Length; ++index)
    {
      if ((Object) this.Dumbbells[index] != (Object) null && (double) Vector3.Distance(this.Dumbbells[index].position, this.Yandere.StudentManager.Students[StudentID].transform.position) < 2.0)
      {
        this.DumbbellNear = true;
        this.ChosenDumbbell = this.Dumbbells[index];
      }
    }
  }
}
