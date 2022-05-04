using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class WeaponManagerScript : MonoBehaviour
{
	// Token: 0x06001FE4 RID: 8164 RVA: 0x001C37E8 File Offset: 0x001C19E8
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

	// Token: 0x06001FE5 RID: 8165 RVA: 0x001C38C8 File Offset: 0x001C1AC8
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

	// Token: 0x06001FE6 RID: 8166 RVA: 0x001C3900 File Offset: 0x001C1B00
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

	// Token: 0x06001FE7 RID: 8167 RVA: 0x001C39C8 File Offset: 0x001C1BC8
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

	// Token: 0x06001FE8 RID: 8168 RVA: 0x001C3A0C File Offset: 0x001C1C0C
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

	// Token: 0x06001FE9 RID: 8169 RVA: 0x001C3AD8 File Offset: 0x001C1CD8
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

	// Token: 0x06001FEA RID: 8170 RVA: 0x001C3B34 File Offset: 0x001C1D34
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

	// Token: 0x06001FEB RID: 8171 RVA: 0x001C3B80 File Offset: 0x001C1D80
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

	// Token: 0x06001FEC RID: 8172 RVA: 0x001C3BB8 File Offset: 0x001C1DB8
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

	// Token: 0x06001FED RID: 8173 RVA: 0x001C3BF0 File Offset: 0x001C1DF0
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

	// Token: 0x06001FEE RID: 8174 RVA: 0x001C3C28 File Offset: 0x001C1E28
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

	// Token: 0x06001FEF RID: 8175 RVA: 0x001C3E04 File Offset: 0x001C2004
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

	// Token: 0x06001FF0 RID: 8176 RVA: 0x001C3E94 File Offset: 0x001C2094
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

	// Token: 0x06001FF1 RID: 8177 RVA: 0x001C40B0 File Offset: 0x001C22B0
	public void UpdateAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SuspicionCheck();
		}
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x001C40E0 File Offset: 0x001C22E0
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

	// Token: 0x06001FF3 RID: 8179 RVA: 0x001C4124 File Offset: 0x001C2324
	public void DisableAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001FF4 RID: 8180 RVA: 0x001C4158 File Offset: 0x001C2358
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

	// Token: 0x040042E3 RID: 17123
	public WeaponScript[] DelinquentWeapons;

	// Token: 0x040042E4 RID: 17124
	public WeaponScript[] BroughtWeapons;

	// Token: 0x040042E5 RID: 17125
	public WeaponScript[] Weapons;

	// Token: 0x040042E6 RID: 17126
	public Transform[] Dumbbells;

	// Token: 0x040042E7 RID: 17127
	public YandereScript Yandere;

	// Token: 0x040042E8 RID: 17128
	public JsonScript JSON;

	// Token: 0x040042E9 RID: 17129
	public int[] Victims;

	// Token: 0x040042EA RID: 17130
	public int MisplacedWeapons;

	// Token: 0x040042EB RID: 17131
	public int MurderWeapons;

	// Token: 0x040042EC RID: 17132
	public int Fingerprints;

	// Token: 0x040042ED RID: 17133
	public int YandereWeapon1 = -1;

	// Token: 0x040042EE RID: 17134
	public int YandereWeapon2 = -1;

	// Token: 0x040042EF RID: 17135
	public int YandereWeapon3 = -1;

	// Token: 0x040042F0 RID: 17136
	public int ReturnWeaponID = -1;

	// Token: 0x040042F1 RID: 17137
	public int ReturnStudentID = -1;

	// Token: 0x040042F2 RID: 17138
	public int OriginalEquipped = -1;

	// Token: 0x040042F3 RID: 17139
	public int OriginalWeapon = -1;

	// Token: 0x040042F4 RID: 17140
	public int WeaponsTouched;

	// Token: 0x040042F5 RID: 17141
	public int Frame;

	// Token: 0x040042F6 RID: 17142
	public Texture Flower;

	// Token: 0x040042F7 RID: 17143
	public Texture Blood;

	// Token: 0x040042F8 RID: 17144
	public bool DumbbellNear;

	// Token: 0x040042F9 RID: 17145
	public Transform ChosenDumbbell;

	// Token: 0x040042FA RID: 17146
	public bool YandereGuilty;

	// Token: 0x040042FB RID: 17147
	public int BloodyWeapons;
}
