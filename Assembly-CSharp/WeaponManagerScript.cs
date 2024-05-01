using System;
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

	public Shader OverlayShader;

	public void Start()
	{
		bool flag = false;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			flag = true;
		}
		for (int i = 0; i < Weapons.Length; i++)
		{
			Weapons[i].GlobalID = i;
			if (WeaponGlobals.GetWeaponStatus(i) == 1)
			{
				if (Weapons[i].ClubProperty && flag)
				{
					Debug.Log("Weapon #" + i + " was destroyed by the player, but it has been replaced.");
					GameGlobals.SetItemRemoved(i, 0);
				}
				else
				{
					Debug.Log("Weapon #" + i + " was destroyed! Disabling it!");
					Weapons[i].gameObject.SetActive(value: false);
				}
			}
		}
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0 && bringingItem < BroughtWeapons.Length)
		{
			BroughtWeapons[bringingItem].gameObject.SetActive(value: true);
		}
		UpdateWeaponMaterials();
		ChangeBloodTexture();
		if (!GameGlobals.Eighties)
		{
			DelinquentWeapons[6].gameObject.SetActive(value: false);
			DelinquentWeapons[7].gameObject.SetActive(value: false);
			DelinquentWeapons[8].gameObject.SetActive(value: false);
			DelinquentWeapons[9].gameObject.SetActive(value: false);
			DelinquentWeapons[10].gameObject.SetActive(value: false);
		}
	}

	public void UpdateLabels()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.UpdateLabel();
			}
		}
	}

	public void CheckWeapons()
	{
		MurderWeapons = 0;
		Fingerprints = 0;
		for (int i = 0; i < Victims.Length; i++)
		{
			Victims[i] = 0;
		}
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (!(weaponScript != null) || !weaponScript.gameObject.activeInHierarchy || weaponScript.Disposed || !weaponScript.Blood.enabled)
			{
				continue;
			}
			Debug.Log(weaponScript.name + " had blood on it. Name is: " + weaponScript.Name);
			if (weaponScript.AlreadyExamined)
			{
				continue;
			}
			MurderWeapons++;
			if (weaponScript.FingerprintID <= 0)
			{
				continue;
			}
			Fingerprints++;
			for (int k = 0; k < weaponScript.Victims.Length; k++)
			{
				if (weaponScript.Victims[k])
				{
					Victims[k] = weaponScript.FingerprintID;
				}
			}
		}
	}

	public void CleanWeapons()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.Blood.enabled = false;
				weaponScript.FingerprintID = 0;
				weaponScript.RemoveBlood();
			}
		}
	}

	public void ChangeBloodTexture()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (!(weaponScript != null) || !(weaponScript != Weapons[2]))
			{
				continue;
			}
			if (!GameGlobals.CensorBlood)
			{
				weaponScript.Blood.material.mainTexture = null;
				weaponScript.Blood.material.SetColor("_TintColor", new Color(1f, 1f, 1f, 0f));
				if (weaponScript.MyRenderer != null)
				{
					Material[] materials = weaponScript.MyRenderer.materials;
					for (int j = 0; j < materials.Length; j++)
					{
						materials[j].SetTexture("_OverlayTex", Blood);
					}
				}
				continue;
			}
			weaponScript.Blood.material.mainTexture = null;
			weaponScript.Blood.material.SetColor("_TintColor", new Color(1f, 1f, 1f, 0f));
			if (weaponScript.MyRenderer != null)
			{
				Material[] materials = weaponScript.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetTexture("_OverlayTex", Flower);
				}
			}
		}
	}

	private void Update()
	{
		if (OriginalWeapon > -1)
		{
			Debug.Log("Re-equipping original weapon.");
			Yandere.WeaponMenu.Selected = OriginalEquipped;
			Yandere.WeaponMenu.Equip();
			OriginalWeapon = -1;
			Frame++;
		}
	}

	public void SetEquippedWeapon1(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon1 = i;
			}
		}
	}

	public void SetEquippedWeapon2(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon2 = i;
			}
		}
	}

	public void SetEquippedWeapon3(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon3 = i;
			}
		}
	}

	public void RestoreBlood()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] != null && !Weapons[i].Disposed && Weapons[i].Bloody)
			{
				Weapons[i].Blood.enabled = true;
				Weapons[i].StainWithBlood();
				Yandere.Police.BloodyWeapons++;
			}
			if (Weapons[i].InBox)
			{
				Weapons[i].GetStuckInBox();
			}
		}
	}

	public void IncinerateWeapons()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] != null && Weapons[i].InsideIncinerator)
			{
				Debug.Log(Weapons[i]?.ToString() + " has been incinerated and marked as ''disposed''.");
				Weapons[i].Disposed = true;
			}
		}
	}

	public void EquipWeaponsFromSave()
	{
		OriginalEquipped = Yandere.Equipped;
		if (Yandere.Equipped == 1)
		{
			OriginalWeapon = YandereWeapon1;
		}
		else if (Yandere.Equipped == 2)
		{
			OriginalWeapon = YandereWeapon2;
		}
		else if (Yandere.Equipped == 3)
		{
			OriginalWeapon = YandereWeapon3;
		}
		if (Yandere.Equipped > 0)
		{
			Yandere.Unequip();
		}
		if (Yandere.Weapon[1] != null)
		{
			Yandere.Weapon[1].Drop();
		}
		if (Yandere.Weapon[2] != null)
		{
			Yandere.Weapon[2].Drop();
		}
		if (YandereWeapon1 > -1)
		{
			Debug.Log("Looks like the player had a " + Weapons[YandereWeapon1].gameObject.name + " in their possession when they saved.");
			Weapons[YandereWeapon1].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon1].gameObject.SetActive(value: true);
			Weapons[YandereWeapon1].UnequipImmediately = true;
		}
		if (YandereWeapon2 > -1)
		{
			Debug.Log("Looks like the player had a " + Weapons[YandereWeapon2].gameObject.name + " in their possession when they saved.");
			Weapons[YandereWeapon2].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon2].gameObject.SetActive(value: true);
			Weapons[YandereWeapon2].UnequipImmediately = true;
		}
		if (YandereWeapon3 > -1)
		{
			Debug.Log("Looks like the player had a " + Weapons[YandereWeapon3].gameObject.name + " equipped when they saved.");
			Weapons[YandereWeapon3].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon3].gameObject.SetActive(value: true);
			Weapons[YandereWeapon3].UnequipImmediately = true;
		}
	}

	public void UpdateDelinquentWeapons()
	{
		for (int i = 1; i < DelinquentWeapons.Length; i++)
		{
			if (DelinquentWeapons[i].DelinquentOwned)
			{
				DelinquentWeapons[i].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				DelinquentWeapons[i].transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			else
			{
				DelinquentWeapons[i].transform.parent = null;
			}
		}
	}

	public void RestoreWeaponToStudent()
	{
		if (ReturnWeaponID > -1)
		{
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].CurrentDestination = Weapons[ReturnWeaponID].Origin;
			Yandere.StudentManager.Students[ReturnStudentID].Pathfinding.target = Weapons[ReturnWeaponID].Origin;
			Weapons[ReturnWeaponID].Prompt.Hide();
			Weapons[ReturnWeaponID].Prompt.enabled = false;
			Weapons[ReturnWeaponID].enabled = false;
			Weapons[ReturnWeaponID].Returner = Yandere.StudentManager.Students[ReturnStudentID];
			Weapons[ReturnWeaponID].transform.parent = Yandere.StudentManager.Students[ReturnStudentID].RightHand;
			Weapons[ReturnWeaponID].transform.localPosition = new Vector3(0f, 0f, 0f);
			Weapons[ReturnWeaponID].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Yandere.StudentManager.Students[ReturnStudentID].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		}
	}

	public void UpdateAllWeapons()
	{
		for (int i = 1; i < Weapons.Length; i++)
		{
			Weapons[i].SuspicionCheck();
		}
	}

	public void CountBloodyWeapons()
	{
		BloodyWeapons = 0;
		for (int i = 1; i < Weapons.Length; i++)
		{
			if (Weapons[i] != null && Weapons[i].gameObject.activeInHierarchy && Weapons[i].Bloody)
			{
				BloodyWeapons++;
			}
		}
	}

	public void CountBloodyWeaponsForPolice()
	{
		BloodyWeapons = 0;
		for (int i = 1; i < Weapons.Length; i++)
		{
			if (Weapons[i] != null && Weapons[i].Bloody && !Weapons[i].Disposed)
			{
				BloodyWeapons++;
			}
		}
	}

	public void DisableAllWeapons()
	{
		for (int i = 1; i < Weapons.Length; i++)
		{
			Weapons[i].gameObject.SetActive(value: false);
		}
	}

	public void PutWeaponInBag()
	{
		Debug.Log("Checking whether or not a weapon was in the weapon bag at the time of saving.");
		for (int i = 1; i < Weapons.Length; i++)
		{
			if (Weapons[i].InBag)
			{
				Debug.Log("A weapon belongs in a bag! It's the " + Weapons[i].gameObject.name + ".");
				TrashCanScript obj = Yandere.StudentManager.TrashCans[Weapons[i].BagID];
				obj.ConcealedWeapon = Weapons[i];
				obj.PutWeaponInBag();
			}
		}
	}

	public void DumbbellCheck(int StudentID)
	{
		for (int i = 1; i < Dumbbells.Length; i++)
		{
			if (Dumbbells[i] != null && Vector3.Distance(Dumbbells[i].position, Yandere.StudentManager.Students[StudentID].transform.position) < 2f)
			{
				DumbbellNear = true;
				ChosenDumbbell = Dumbbells[i];
			}
		}
	}

	public void TrackDumpedWeapons()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i].Dumped && (Weapons[i].OneOfAKind || Weapons[i].ClubProperty))
			{
				Debug.Log("The one-of-a-kind " + Weapons[i].Name + " was destroyed! Setting status to 1!");
				WeaponGlobals.SetWeaponStatus(i, 1);
			}
		}
	}

	public void UpdateWeaponMaterials()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (i != 2 && Weapons[i].MyRenderer != null)
			{
				Material[] materials = Weapons[i].MyRenderer.materials;
				foreach (Material obj in materials)
				{
					obj.shader = OverlayShader;
					obj.SetTexture("_OverlayTex", Blood);
					obj.SetFloat("_BlendAmount", 0f);
					obj.SetColor("_TintColor", new Color(1f, 1f, 1f, 0f));
				}
			}
		}
	}
}
