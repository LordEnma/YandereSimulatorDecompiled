using System;
using UnityEngine;

// Token: 0x020004B4 RID: 1204
public class WeaponManagerScript : MonoBehaviour
{
	// Token: 0x06001F7F RID: 8063 RVA: 0x001BA1CC File Offset: 0x001B83CC
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

	// Token: 0x06001F80 RID: 8064 RVA: 0x001BA2AC File Offset: 0x001B84AC
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

	// Token: 0x06001F81 RID: 8065 RVA: 0x001BA2E4 File Offset: 0x001B84E4
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

	// Token: 0x06001F82 RID: 8066 RVA: 0x001BA3AC File Offset: 0x001B85AC
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

	// Token: 0x06001F83 RID: 8067 RVA: 0x001BA3F0 File Offset: 0x001B85F0
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

	// Token: 0x06001F84 RID: 8068 RVA: 0x001BA4BC File Offset: 0x001B86BC
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

	// Token: 0x06001F85 RID: 8069 RVA: 0x001BA518 File Offset: 0x001B8718
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

	// Token: 0x06001F86 RID: 8070 RVA: 0x001BA564 File Offset: 0x001B8764
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

	// Token: 0x06001F87 RID: 8071 RVA: 0x001BA59C File Offset: 0x001B879C
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

	// Token: 0x06001F88 RID: 8072 RVA: 0x001BA5D4 File Offset: 0x001B87D4
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

	// Token: 0x06001F89 RID: 8073 RVA: 0x001BA60C File Offset: 0x001B880C
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

	// Token: 0x06001F8A RID: 8074 RVA: 0x001BA7E8 File Offset: 0x001B89E8
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

	// Token: 0x06001F8B RID: 8075 RVA: 0x001BA878 File Offset: 0x001B8A78
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

	// Token: 0x06001F8C RID: 8076 RVA: 0x001BAA94 File Offset: 0x001B8C94
	public void UpdateAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SuspicionCheck();
		}
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x001BAAC4 File Offset: 0x001B8CC4
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

	// Token: 0x06001F8E RID: 8078 RVA: 0x001BAB08 File Offset: 0x001B8D08
	public void DisableAllWeapons()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x040041C8 RID: 16840
	public WeaponScript[] DelinquentWeapons;

	// Token: 0x040041C9 RID: 16841
	public WeaponScript[] BroughtWeapons;

	// Token: 0x040041CA RID: 16842
	public WeaponScript[] Weapons;

	// Token: 0x040041CB RID: 16843
	public YandereScript Yandere;

	// Token: 0x040041CC RID: 16844
	public JsonScript JSON;

	// Token: 0x040041CD RID: 16845
	public int[] Victims;

	// Token: 0x040041CE RID: 16846
	public int MisplacedWeapons;

	// Token: 0x040041CF RID: 16847
	public int MurderWeapons;

	// Token: 0x040041D0 RID: 16848
	public int Fingerprints;

	// Token: 0x040041D1 RID: 16849
	public int YandereWeapon1 = -1;

	// Token: 0x040041D2 RID: 16850
	public int YandereWeapon2 = -1;

	// Token: 0x040041D3 RID: 16851
	public int YandereWeapon3 = -1;

	// Token: 0x040041D4 RID: 16852
	public int ReturnWeaponID = -1;

	// Token: 0x040041D5 RID: 16853
	public int ReturnStudentID = -1;

	// Token: 0x040041D6 RID: 16854
	public int OriginalEquipped = -1;

	// Token: 0x040041D7 RID: 16855
	public int OriginalWeapon = -1;

	// Token: 0x040041D8 RID: 16856
	public int WeaponsTouched;

	// Token: 0x040041D9 RID: 16857
	public int Frame;

	// Token: 0x040041DA RID: 16858
	public Texture Flower;

	// Token: 0x040041DB RID: 16859
	public Texture Blood;

	// Token: 0x040041DC RID: 16860
	public bool YandereGuilty;

	// Token: 0x040041DD RID: 16861
	public int BloodyWeapons;
}
