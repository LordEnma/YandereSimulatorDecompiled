using System;

[Serializable]
public class InvStat
{
	public enum Identifier
	{
		Strength = 0,
		Constitution = 1,
		Agility = 2,
		Intelligence = 3,
		Damage = 4,
		Crit = 5,
		Armor = 6,
		Health = 7,
		Mana = 8,
		Other = 9
	}

	public enum Modifier
	{
		Added = 0,
		Percent = 1
	}

	public Identifier id;

	public Modifier modifier;

	public int amount;

	public static string GetName(Identifier i)
	{
		return i.ToString();
	}

	public static string GetDescription(Identifier i)
	{
		return i switch
		{
			Identifier.Strength => "Strength increases melee damage", 
			Identifier.Constitution => "Constitution increases health", 
			Identifier.Agility => "Agility increases armor", 
			Identifier.Intelligence => "Intelligence increases mana", 
			Identifier.Damage => "Damage adds to the amount of damage done in combat", 
			Identifier.Crit => "Crit increases the chance of landing a critical strike", 
			Identifier.Armor => "Armor protects from damage", 
			Identifier.Health => "Health prolongs life", 
			Identifier.Mana => "Mana increases the number of spells that can be cast", 
			_ => null, 
		};
	}

	public static int CompareArmor(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == Identifier.Armor)
		{
			num -= 10000;
		}
		else if (a.id == Identifier.Damage)
		{
			num -= 5000;
		}
		if (b.id == Identifier.Armor)
		{
			num2 -= 10000;
		}
		else if (b.id == Identifier.Damage)
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
		if (a.modifier == Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == Modifier.Percent)
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

	public static int CompareWeapon(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == Identifier.Damage)
		{
			num -= 10000;
		}
		else if (a.id == Identifier.Armor)
		{
			num -= 5000;
		}
		if (b.id == Identifier.Damage)
		{
			num2 -= 10000;
		}
		else if (b.id == Identifier.Armor)
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
		if (a.modifier == Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == Modifier.Percent)
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
}
