using System;

// Token: 0x0200002C RID: 44
[Serializable]
public class InvStat
{
	// Token: 0x060000BE RID: 190 RVA: 0x00012187 File Offset: 0x00010387
	public static string GetName(InvStat.Identifier i)
	{
		return i.ToString();
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00012198 File Offset: 0x00010398
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

	// Token: 0x060000C0 RID: 192 RVA: 0x00012208 File Offset: 0x00010408
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

	// Token: 0x060000C1 RID: 193 RVA: 0x000122B8 File Offset: 0x000104B8
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

	// Token: 0x04000293 RID: 659
	public InvStat.Identifier id;

	// Token: 0x04000294 RID: 660
	public InvStat.Modifier modifier;

	// Token: 0x04000295 RID: 661
	public int amount;

	// Token: 0x020005C9 RID: 1481
	public enum Identifier
	{
		// Token: 0x04004DB4 RID: 19892
		Strength,
		// Token: 0x04004DB5 RID: 19893
		Constitution,
		// Token: 0x04004DB6 RID: 19894
		Agility,
		// Token: 0x04004DB7 RID: 19895
		Intelligence,
		// Token: 0x04004DB8 RID: 19896
		Damage,
		// Token: 0x04004DB9 RID: 19897
		Crit,
		// Token: 0x04004DBA RID: 19898
		Armor,
		// Token: 0x04004DBB RID: 19899
		Health,
		// Token: 0x04004DBC RID: 19900
		Mana,
		// Token: 0x04004DBD RID: 19901
		Other
	}

	// Token: 0x020005CA RID: 1482
	public enum Modifier
	{
		// Token: 0x04004DBF RID: 19903
		Added,
		// Token: 0x04004DC0 RID: 19904
		Percent
	}
}
