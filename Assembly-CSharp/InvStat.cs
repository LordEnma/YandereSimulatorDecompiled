using System;

// Token: 0x0200002C RID: 44
[Serializable]
public class InvStat
{
	// Token: 0x060000BE RID: 190 RVA: 0x0001208F File Offset: 0x0001028F
	public static string GetName(InvStat.Identifier i)
	{
		return i.ToString();
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000120A0 File Offset: 0x000102A0
	public static string GetDescription(InvStat.Identifier i)
	{
		switch (i)
		{
		case InvStat.Identifier.Strength:
			return "Strength increases melee damage";
		case InvStat.Identifier.Constitution:
			return "Constitution increases health";
		case InvStat.Identifier.Agility:
			return "Agility increases armor";
		case InvStat.Identifier.Intelligence:
			return "Intelligence increases mana";
		case InvStat.Identifier.Damage:
			return "Damage adds to the amount of damage done in combat";
		case InvStat.Identifier.Crit:
			return "Crit increases the chance of landing a critical strike";
		case InvStat.Identifier.Armor:
			return "Armor protects from damage";
		case InvStat.Identifier.Health:
			return "Health prolongs life";
		case InvStat.Identifier.Mana:
			return "Mana increases the number of spells that can be cast";
		default:
			return null;
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00012110 File Offset: 0x00010310
	public static int CompareArmor(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == InvStat.Identifier.Armor)
		{
			num -= 10000;
		}
		else if (a.id == InvStat.Identifier.Damage)
		{
			num -= 5000;
		}
		if (b.id == InvStat.Identifier.Armor)
		{
			num2 -= 10000;
		}
		else if (b.id == InvStat.Identifier.Damage)
		{
			num2 -= 5000;
		}
		if (a.amount < 0)
		{
			num += 1000;
		}
		if (b.amount < 0)
		{
			num2 += 1000;
		}
		if (a.modifier == InvStat.Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == InvStat.Modifier.Percent)
		{
			num2 += 100;
		}
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x000121C0 File Offset: 0x000103C0
	public static int CompareWeapon(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == InvStat.Identifier.Damage)
		{
			num -= 10000;
		}
		else if (a.id == InvStat.Identifier.Armor)
		{
			num -= 5000;
		}
		if (b.id == InvStat.Identifier.Damage)
		{
			num2 -= 10000;
		}
		else if (b.id == InvStat.Identifier.Armor)
		{
			num2 -= 5000;
		}
		if (a.amount < 0)
		{
			num += 1000;
		}
		if (b.amount < 0)
		{
			num2 += 1000;
		}
		if (a.modifier == InvStat.Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == InvStat.Modifier.Percent)
		{
			num2 += 100;
		}
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0400028A RID: 650
	public InvStat.Identifier id;

	// Token: 0x0400028B RID: 651
	public InvStat.Modifier modifier;

	// Token: 0x0400028C RID: 652
	public int amount;

	// Token: 0x020005BD RID: 1469
	public enum Identifier
	{
		// Token: 0x04004CED RID: 19693
		Strength,
		// Token: 0x04004CEE RID: 19694
		Constitution,
		// Token: 0x04004CEF RID: 19695
		Agility,
		// Token: 0x04004CF0 RID: 19696
		Intelligence,
		// Token: 0x04004CF1 RID: 19697
		Damage,
		// Token: 0x04004CF2 RID: 19698
		Crit,
		// Token: 0x04004CF3 RID: 19699
		Armor,
		// Token: 0x04004CF4 RID: 19700
		Health,
		// Token: 0x04004CF5 RID: 19701
		Mana,
		// Token: 0x04004CF6 RID: 19702
		Other
	}

	// Token: 0x020005BE RID: 1470
	public enum Modifier
	{
		// Token: 0x04004CF8 RID: 19704
		Added,
		// Token: 0x04004CF9 RID: 19705
		Percent
	}
}
