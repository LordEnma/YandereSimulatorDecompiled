using System;
using UnityEngine;

// Token: 0x020004C4 RID: 1220
public class WeaponManagerScript : MonoBehaviour
{
	// Token: 0x06001FED RID: 8173 RVA: 0x001C4980 File Offset: 0x001C2B80
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

	// Token: 0x06001FEE RID: 8174 RVA: 0x001C4A60 File Offset: 0x001C2C60
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

	// Token: 0x06001FEF RID: 8175 RVA: 0x001C4A98 File Offset: 0x001C2C98
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

	// Token: 0x06001FF0 RID: 8176 RVA: 0x001C4B60 File Offset: 0x001C2D60
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

	// Token: 0x06001FF1 RID: 8177 RVA: 0x001C4BA4 File Offset: 0x001C2DA4
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

	// Token: 0x06001FF2 RID: 8178 RVA: 0x001C4C70 File Offset: 0x001C2E70
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

	// Token: 0x06001FF3 RID: 8179 RVA: 0x001C4CCC File Offset: 0x001C2ECC
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

	// Token: 0x06001FF4 RID: 8180 RVA: 0x001C4D18 File Offset: 0x001C2F18
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

	// Token: 0x06001FF5 RID: 8181 RVA: 0x001C4D50 File Offset: 0x001C2F50
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

	// Token: 0x06001FF6 RID: 8182 RVA: 0x001C4D88 File Offset: 0x001C2F88
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

	// Token: 0x06001FF7 RID: 8183 RVA: 0x001C4DC0 File Offset: 0x001C2FC0
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

	// Token: 0x06001FF8 RID: 8184 RVA: 0x001C4F9C File Offset: 0x001C319C
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

	// Token: 0x06001FF9 RID: 8185 RVA: 0x001C502C File Offset: 0x001C322C
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

	// Token: 0x06001FFA RID: 8186 RVA: 0x001C5248 File Offset: 0x001C3448
	public void UpdateAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SuspicionCheck();
		}
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x001C5278 File Offset: 0x001C3478
	public void CountBloodyWeapons()
	{
		this.BloodyWeapons = 0;
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] != null && this.Weapons[i].gameObject.activeInHierarchy && this.Weapons[i].Bloody)
			{
				this.BloodyWeapons++;
			}
		}
	}

	// Token: 0x06001FFC RID: 8188 RVA: 0x001C52E0 File Offset: 0x001C34E0
	public void DisableAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001FFD RID: 8189 RVA: 0x001C5314 File Offset: 0x001C3514
	public void DumbbellCheck(int StudentID)
	{
		for (int i = 1; i < this.Dumbbells.Length; i++)
		{
			if (this.Dumbbells[i] != null && Vector3.Distance(this.Dumbbells[i].position, this.Yandere.StudentManager.Students[StudentID].transform.position) < 2f)
			{
				this.DumbbellNear = true;
				this.ChosenDumbbell = this.Dumbbells[i];
			}
		}
	}

	// Token: 0x04004301 RID: 17153
	public WeaponScript[] DelinquentWeapons;

	// Token: 0x04004302 RID: 17154
	public WeaponScript[] BroughtWeapons;

	// Token: 0x04004303 RID: 17155
	public WeaponScript[] Weapons;

	// Token: 0x04004304 RID: 17156
	public Transform[] Dumbbells;

	// Token: 0x04004305 RID: 17157
	public YandereScript Yandere;

	// Token: 0x04004306 RID: 17158
	public JsonScript JSON;

	// Token: 0x04004307 RID: 17159
	public int[] Victims;

	// Token: 0x04004308 RID: 17160
	public int MisplacedWeapons;

	// Token: 0x04004309 RID: 17161
	public int MurderWeapons;

	// Token: 0x0400430A RID: 17162
	public int Fingerprints;

	// Token: 0x0400430B RID: 17163
	public int YandereWeapon1 = -1;

	// Token: 0x0400430C RID: 17164
	public int YandereWeapon2 = -1;

	// Token: 0x0400430D RID: 17165
	public int YandereWeapon3 = -1;

	// Token: 0x0400430E RID: 17166
	public int ReturnWeaponID = -1;

	// Token: 0x0400430F RID: 17167
	public int ReturnStudentID = -1;

	// Token: 0x04004310 RID: 17168
	public int OriginalEquipped = -1;

	// Token: 0x04004311 RID: 17169
	public int OriginalWeapon = -1;

	// Token: 0x04004312 RID: 17170
	public int WeaponsTouched;

	// Token: 0x04004313 RID: 17171
	public int Frame;

	// Token: 0x04004314 RID: 17172
	public Texture Flower;

	// Token: 0x04004315 RID: 17173
	public Texture Blood;

	// Token: 0x04004316 RID: 17174
	public bool DumbbellNear;

	// Token: 0x04004317 RID: 17175
	public Transform ChosenDumbbell;

	// Token: 0x04004318 RID: 17176
	public bool YandereGuilty;

	// Token: 0x04004319 RID: 17177
	public int BloodyWeapons;
}
