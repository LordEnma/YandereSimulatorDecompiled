// Decompiled with JetBrains decompiler
// Type: InvStat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class InvStat
{
  public InvStat.Identifier id;
  public InvStat.Modifier modifier;
  public int amount;

  public static string GetName(InvStat.Identifier i) => i.ToString();

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
        return (string) null;
    }
  }

  public static int CompareArmor(InvStat a, InvStat b)
  {
    int id1 = (int) a.id;
    int id2 = (int) b.id;
    if (a.id == InvStat.Identifier.Armor)
      id1 -= 10000;
    else if (a.id == InvStat.Identifier.Damage)
      id1 -= 5000;
    if (b.id == InvStat.Identifier.Armor)
      id2 -= 10000;
    else if (b.id == InvStat.Identifier.Damage)
      id2 -= 5000;
    if (a.amount < 0)
      id1 += 1000;
    if (b.amount < 0)
      id2 += 1000;
    if (a.modifier == InvStat.Modifier.Percent)
      id1 += 100;
    if (b.modifier == InvStat.Modifier.Percent)
      id2 += 100;
    if (id1 < id2)
      return -1;
    return id1 > id2 ? 1 : 0;
  }

  public static int CompareWeapon(InvStat a, InvStat b)
  {
    int id1 = (int) a.id;
    int id2 = (int) b.id;
    if (a.id == InvStat.Identifier.Damage)
      id1 -= 10000;
    else if (a.id == InvStat.Identifier.Armor)
      id1 -= 5000;
    if (b.id == InvStat.Identifier.Damage)
      id2 -= 10000;
    else if (b.id == InvStat.Identifier.Armor)
      id2 -= 5000;
    if (a.amount < 0)
      id1 += 1000;
    if (b.amount < 0)
      id2 += 1000;
    if (a.modifier == InvStat.Modifier.Percent)
      id1 += 100;
    if (b.modifier == InvStat.Modifier.Percent)
      id2 += 100;
    if (id1 < id2)
      return -1;
    return id1 > id2 ? 1 : 0;
  }

  public enum Identifier
  {
    Strength,
    Constitution,
    Agility,
    Intelligence,
    Damage,
    Crit,
    Armor,
    Health,
    Mana,
    Other,
  }

  public enum Modifier
  {
    Added,
    Percent,
  }
}
