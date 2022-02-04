using System;
using UnityEngine;

// Token: 0x020004B7 RID: 1207
public class WeaponManagerScript : MonoBehaviour
{
	// Token: 0x06001F93 RID: 8083 RVA: 0x001BC528 File Offset: 0x001BA728
	public void Start()
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].GlobalID = i;
			if (WeaponGlobals.GetWeaponStatus(i) == 1)
			{
				this.Weapons[i].gameObject.SetActive(false);
			}
		}
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0 && bringingItem < this.BroughtWeapons.Length)
		{
			this.BroughtWeapons[bringingItem].gameObject.SetActive(true);
		}
		this.ChangeBloodTexture();
		if (!GameGlobals.Eighties)
		{
			this.DelinquentWeapons[6].gameObject.SetActive(false);
			this.DelinquentWeapons[7].gameObject.SetActive(false);
			this.DelinquentWeapons[8].gameObject.SetActive(false);
			this.DelinquentWeapons[9].gameObject.SetActive(false);
			this.DelinquentWeapons[10].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001F94 RID: 8084 RVA: 0x001BC608 File Offset: 0x001BA808
	public void UpdateLabels()
	{
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.UpdateLabel();
			}
		}
	}

	// Token: 0x06001F95 RID: 8085 RVA: 0x001BC640 File Offset: 0x001BA840
	public void CheckWeapons()
	{
		this.MurderWeapons = 0;
		this.Fingerprints = 0;
		for (int i = 0; i < this.Victims.Length; i++)
		{
			this.Victims[i] = 0;
		}
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null && weaponScript.Blood.enabled && !weaponScript.AlreadyExamined)
			{
				this.MurderWeapons++;
				if (weaponScript.FingerprintID > 0)
				{
					this.Fingerprints++;
					for (int k = 0; k < weaponScript.Victims.Length; k++)
					{
						if (weaponScript.Victims[k])
						{
							this.Victims[k] = weaponScript.FingerprintID;
						}
					}
				}
			}
		}
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x001BC708 File Offset: 0x001BA908
	public void CleanWeapons()
	{
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.Blood.enabled = false;
				weaponScript.FingerprintID = 0;
			}
		}
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x001BC74C File Offset: 0x001BA94C
	public void ChangeBloodTexture()
	{
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null)
			{
				if (!GameGlobals.CensorBlood)
				{
					weaponScript.Blood.material.mainTexture = this.Blood;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				}
				else
				{
					weaponScript.Blood.material.mainTexture = this.Flower;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				}
			}
		}
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x001BC818 File Offset: 0x001BAA18
	private void Update()
	{
		if (this.OriginalWeapon > -1)
		{
			Debug.Log("Re-equipping original weapon.");
			this.Yandere.WeaponMenu.Selected = this.OriginalEquipped;
			this.Yandere.WeaponMenu.Equip();
			this.OriginalWeapon = -1;
			this.Frame++;
		}
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x001BC874 File Offset: 0x001BAA74
	public void TrackDumpedWeapons()
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == null)
			{
				Debug.Log("Weapon #" + i.ToString() + " was destroyed! Setting status to 1!");
			}
		}
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x001BC8C0 File Offset: 0x001BAAC0
	public void SetEquippedWeapon1(WeaponScript Weapon)
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == Weapon)
			{
				this.YandereWeapon1 = i;
			}
		}
	}

	// Token: 0x06001F9B RID: 8091 RVA: 0x001BC8F8 File Offset: 0x001BAAF8
	public void SetEquippedWeapon2(WeaponScript Weapon)
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == Weapon)
			{
				this.YandereWeapon2 = i;
			}
		}
	}

	// Token: 0x06001F9C RID: 8092 RVA: 0x001BC930 File Offset: 0x001BAB30
	public void SetEquippedWeapon3(WeaponScript Weapon)
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == Weapon)
			{
				this.YandereWeapon3 = i;
			}
		}
	}

	// Token: 0x06001F9D RID: 8093 RVA: 0x001BC968 File Offset: 0x001BAB68
	public void EquipWeaponsFromSave()
	{
		this.OriginalEquipped = this.Yandere.Equipped;
		if (this.Yandere.Equipped == 1)
		{
			this.OriginalWeapon = this.YandereWeapon1;
		}
		else if (this.Yandere.Equipped == 2)
		{
			this.OriginalWeapon = this.YandereWeapon2;
		}
		else if (this.Yandere.Equipped == 3)
		{
			this.OriginalWeapon = this.YandereWeapon3;
		}
		if (this.Yandere.Equipped > 0)
		{
			this.Yandere.Unequip();
		}
		if (this.Yandere.Weapon[1] != null)
		{
			this.Yandere.Weapon[1].Drop();
		}
		if (this.Yandere.Weapon[2] != null)
		{
			this.Yandere.Weapon[2].Drop();
		}
		if (this.YandereWeapon1 > -1)
		{
			this.Weapons[this.YandereWeapon1].Prompt.Circle[3].fillAmount = 0f;
			this.Weapons[this.YandereWeapon1].gameObject.SetActive(true);
			this.Weapons[this.YandereWeapon1].UnequipImmediately = true;
		}
		if (this.YandereWeapon2 > -1)
		{
			this.Weapons[this.YandereWeapon2].Prompt.Circle[3].fillAmount = 0f;
			this.Weapons[this.YandereWeapon2].gameObject.SetActive(true);
			this.Weapons[this.YandereWeapon2].UnequipImmediately = true;
		}
		if (this.YandereWeapon3 > -1)
		{
			this.Weapons[this.YandereWeapon3].Prompt.Circle[3].fillAmount = 0f;
			this.Weapons[this.YandereWeapon3].gameObject.SetActive(true);
			this.Weapons[this.YandereWeapon3].UnequipImmediately = true;
		}
	}

	// Token: 0x06001F9E RID: 8094 RVA: 0x001BCB44 File Offset: 0x001BAD44
	public void UpdateDelinquentWeapons()
	{
		for (int i = 1; i < this.DelinquentWeapons.Length; i++)
		{
			if (this.DelinquentWeapons[i].DelinquentOwned)
			{
				this.DelinquentWeapons[i].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.DelinquentWeapons[i].transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			else
			{
				this.DelinquentWeapons[i].transform.parent = null;
			}
		}
	}

	// Token: 0x06001F9F RID: 8095 RVA: 0x001BCBD4 File Offset: 0x001BADD4
	public void RestoreWeaponToStudent()
	{
		if (this.ReturnWeaponID > -1)
		{
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
			this.Weapons[this.ReturnWeaponID].transform.localPosition = new Vector3(0f, 0f, 0f);
			this.Weapons[this.ReturnWeaponID].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Yandere.StudentManager.Students[this.ReturnStudentID].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		}
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x001BCDF0 File Offset: 0x001BAFF0
	public void UpdateAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SuspicionCheck();
		}
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BCE20 File Offset: 0x001BB020
	public void CountBloodyWeapons()
	{
		this.BloodyWeapons = 0;
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i].Bloody)
			{
				this.BloodyWeapons++;
			}
		}
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x001BCE64 File Offset: 0x001BB064
	public void DisableAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x040041F8 RID: 16888
	public WeaponScript[] DelinquentWeapons;

	// Token: 0x040041F9 RID: 16889
	public WeaponScript[] BroughtWeapons;

	// Token: 0x040041FA RID: 16890
	public WeaponScript[] Weapons;

	// Token: 0x040041FB RID: 16891
	public YandereScript Yandere;

	// Token: 0x040041FC RID: 16892
	public JsonScript JSON;

	// Token: 0x040041FD RID: 16893
	public int[] Victims;

	// Token: 0x040041FE RID: 16894
	public int MisplacedWeapons;

	// Token: 0x040041FF RID: 16895
	public int MurderWeapons;

	// Token: 0x04004200 RID: 16896
	public int Fingerprints;

	// Token: 0x04004201 RID: 16897
	public int YandereWeapon1 = -1;

	// Token: 0x04004202 RID: 16898
	public int YandereWeapon2 = -1;

	// Token: 0x04004203 RID: 16899
	public int YandereWeapon3 = -1;

	// Token: 0x04004204 RID: 16900
	public int ReturnWeaponID = -1;

	// Token: 0x04004205 RID: 16901
	public int ReturnStudentID = -1;

	// Token: 0x04004206 RID: 16902
	public int OriginalEquipped = -1;

	// Token: 0x04004207 RID: 16903
	public int OriginalWeapon = -1;

	// Token: 0x04004208 RID: 16904
	public int WeaponsTouched;

	// Token: 0x04004209 RID: 16905
	public int Frame;

	// Token: 0x0400420A RID: 16906
	public Texture Flower;

	// Token: 0x0400420B RID: 16907
	public Texture Blood;

	// Token: 0x0400420C RID: 16908
	public bool YandereGuilty;

	// Token: 0x0400420D RID: 16909
	public int BloodyWeapons;
}
