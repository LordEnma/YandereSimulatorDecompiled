using System;

// Token: 0x020003F0 RID: 1008
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BD9 RID: 7129 RVA: 0x00143410 File Offset: 0x00141610
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

	// Token: 0x06001BDA RID: 7130 RVA: 0x001434C8 File Offset: 0x001416C8
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

	// Token: 0x040030D6 RID: 12502
	public int biology;

	// Token: 0x040030D7 RID: 12503
	public int biologyBonus;

	// Token: 0x040030D8 RID: 12504
	public int biologyGrade;

	// Token: 0x040030D9 RID: 12505
	public int chemistry;

	// Token: 0x040030DA RID: 12506
	public int chemistryBonus;

	// Token: 0x040030DB RID: 12507
	public int chemistryGrade;

	// Token: 0x040030DC RID: 12508
	public int language;

	// Token: 0x040030DD RID: 12509
	public int languageBonus;

	// Token: 0x040030DE RID: 12510
	public int languageGrade;

	// Token: 0x040030DF RID: 12511
	public int physical;

	// Token: 0x040030E0 RID: 12512
	public int physicalBonus;

	// Token: 0x040030E1 RID: 12513
	public int physicalGrade;

	// Token: 0x040030E2 RID: 12514
	public int psychology;

	// Token: 0x040030E3 RID: 12515
	public int psychologyBonus;

	// Token: 0x040030E4 RID: 12516
	public int psychologyGrade;
}
