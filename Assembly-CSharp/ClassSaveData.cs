using System;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x00143784 File Offset: 0x00141984
	public static ClassSaveData ReadFromGlobals()
	{
		return new ClassSaveData
		{
			biology = ClassGlobals.Biology,
			biologyBonus = ClassGlobals.BiologyBonus,
			biologyGrade = ClassGlobals.BiologyGrade,
			chemistry = ClassGlobals.Chemistry,
			chemistryBonus = ClassGlobals.ChemistryBonus,
			chemistryGrade = ClassGlobals.ChemistryGrade,
			language = ClassGlobals.Language,
			languageBonus = ClassGlobals.LanguageBonus,
			languageGrade = ClassGlobals.LanguageGrade,
			physical = ClassGlobals.Physical,
			physicalBonus = ClassGlobals.PhysicalBonus,
			physicalGrade = ClassGlobals.PhysicalGrade,
			psychology = ClassGlobals.Psychology,
			psychologyBonus = ClassGlobals.PsychologyBonus,
			psychologyGrade = ClassGlobals.PsychologyGrade
		};
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x0014383C File Offset: 0x00141A3C
	public static void WriteToGlobals(ClassSaveData data)
	{
		ClassGlobals.Biology = data.biology;
		ClassGlobals.BiologyBonus = data.biologyBonus;
		ClassGlobals.BiologyGrade = data.biologyGrade;
		ClassGlobals.Chemistry = data.chemistry;
		ClassGlobals.ChemistryBonus = data.chemistryBonus;
		ClassGlobals.ChemistryGrade = data.chemistryGrade;
		ClassGlobals.Language = data.language;
		ClassGlobals.LanguageBonus = data.languageBonus;
		ClassGlobals.LanguageGrade = data.languageGrade;
		ClassGlobals.Physical = data.physical;
		ClassGlobals.PhysicalBonus = data.physicalBonus;
		ClassGlobals.PhysicalGrade = data.physicalGrade;
		ClassGlobals.Psychology = data.psychology;
		ClassGlobals.PsychologyBonus = data.psychologyBonus;
		ClassGlobals.PsychologyGrade = data.psychologyGrade;
	}

	// Token: 0x040030DC RID: 12508
	public int biology;

	// Token: 0x040030DD RID: 12509
	public int biologyBonus;

	// Token: 0x040030DE RID: 12510
	public int biologyGrade;

	// Token: 0x040030DF RID: 12511
	public int chemistry;

	// Token: 0x040030E0 RID: 12512
	public int chemistryBonus;

	// Token: 0x040030E1 RID: 12513
	public int chemistryGrade;

	// Token: 0x040030E2 RID: 12514
	public int language;

	// Token: 0x040030E3 RID: 12515
	public int languageBonus;

	// Token: 0x040030E4 RID: 12516
	public int languageGrade;

	// Token: 0x040030E5 RID: 12517
	public int physical;

	// Token: 0x040030E6 RID: 12518
	public int physicalBonus;

	// Token: 0x040030E7 RID: 12519
	public int physicalGrade;

	// Token: 0x040030E8 RID: 12520
	public int psychology;

	// Token: 0x040030E9 RID: 12521
	public int psychologyBonus;

	// Token: 0x040030EA RID: 12522
	public int psychologyGrade;
}
