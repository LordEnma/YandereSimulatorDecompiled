using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class WeaponManagerScript : MonoBehaviour
{
	// Token: 0x06001FDA RID: 8154 RVA: 0x001C2330 File Offset: 0x001C0530
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

	// Token: 0x06001FDB RID: 8155 RVA: 0x001C2410 File Offset: 0x001C0610
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

	// Token: 0x06001FDC RID: 8156 RVA: 0x001C2448 File Offset: 0x001C0648
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

	// Token: 0x06001FDD RID: 8157 RVA: 0x001C2510 File Offset: 0x001C0710
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

	// Token: 0x06001FDE RID: 8158 RVA: 0x001C2554 File Offset: 0x001C0754
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

	// Token: 0x06001FDF RID: 8159 RVA: 0x001C2620 File Offset: 0x001C0820
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

	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C267C File Offset: 0x001C087C
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

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001C26C8 File Offset: 0x001C08C8
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

	// Token: 0x06001FE2 RID: 8162 RVA: 0x001C2700 File Offset: 0x001C0900
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

	// Token: 0x06001FE3 RID: 8163 RVA: 0x001C2738 File Offset: 0x001C0938
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

	// Token: 0x06001FE4 RID: 8164 RVA: 0x001C2770 File Offset: 0x001C0970
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

	// Token: 0x06001FE5 RID: 8165 RVA: 0x001C294C File Offset: 0x001C0B4C
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

	// Token: 0x06001FE6 RID: 8166 RVA: 0x001C29DC File Offset: 0x001C0BDC
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

	// Token: 0x06001FE7 RID: 8167 RVA: 0x001C2BF8 File Offset: 0x001C0DF8
	public void UpdateAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SuspicionCheck();
		}
	}

	// Token: 0x06001FE8 RID: 8168 RVA: 0x001C2C28 File Offset: 0x001C0E28
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

	// Token: 0x06001FE9 RID: 8169 RVA: 0x001C2C6C File Offset: 0x001C0E6C
	public void DisableAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x001C2CA0 File Offset: 0x001C0EA0
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

	// Token: 0x040042CD RID: 17101
	public WeaponScript[] DelinquentWeapons;

	// Token: 0x040042CE RID: 17102
	public WeaponScript[] BroughtWeapons;

	// Token: 0x040042CF RID: 17103
	public WeaponScript[] Weapons;

	// Token: 0x040042D0 RID: 17104
	public Transform[] Dumbbells;

	// Token: 0x040042D1 RID: 17105
	public YandereScript Yandere;

	// Token: 0x040042D2 RID: 17106
	public JsonScript JSON;

	// Token: 0x040042D3 RID: 17107
	public int[] Victims;

	// Token: 0x040042D4 RID: 17108
	public int MisplacedWeapons;

	// Token: 0x040042D5 RID: 17109
	public int MurderWeapons;

	// Token: 0x040042D6 RID: 17110
	public int Fingerprints;

	// Token: 0x040042D7 RID: 17111
	public int YandereWeapon1 = -1;

	// Token: 0x040042D8 RID: 17112
	public int YandereWeapon2 = -1;

	// Token: 0x040042D9 RID: 17113
	public int YandereWeapon3 = -1;

	// Token: 0x040042DA RID: 17114
	public int ReturnWeaponID = -1;

	// Token: 0x040042DB RID: 17115
	public int ReturnStudentID = -1;

	// Token: 0x040042DC RID: 17116
	public int OriginalEquipped = -1;

	// Token: 0x040042DD RID: 17117
	public int OriginalWeapon = -1;

	// Token: 0x040042DE RID: 17118
	public int WeaponsTouched;

	// Token: 0x040042DF RID: 17119
	public int Frame;

	// Token: 0x040042E0 RID: 17120
	public Texture Flower;

	// Token: 0x040042E1 RID: 17121
	public Texture Blood;

	// Token: 0x040042E2 RID: 17122
	public bool DumbbellNear;

	// Token: 0x040042E3 RID: 17123
	public Transform ChosenDumbbell;

	// Token: 0x040042E4 RID: 17124
	public bool YandereGuilty;

	// Token: 0x040042E5 RID: 17125
	public int BloodyWeapons;
}
