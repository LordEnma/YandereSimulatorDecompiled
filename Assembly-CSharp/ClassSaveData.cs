using System;

// Token: 0x020003EF RID: 1007
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BCF RID: 7119 RVA: 0x00142754 File Offset: 0x00140954
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

	// Token: 0x06001BD0 RID: 7120 RVA: 0x0014280C File Offset: 0x00140A0C
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

	// Token: 0x040030A5 RID: 12453
	public int biology;

	// Token: 0x040030A6 RID: 12454
	public int biologyBonus;

	// Token: 0x040030A7 RID: 12455
	public int biologyGrade;

	// Token: 0x040030A8 RID: 12456
	public int chemistry;

	// Token: 0x040030A9 RID: 12457
	public int chemistryBonus;

	// Token: 0x040030AA RID: 12458
	public int chemistryGrade;

	// Token: 0x040030AB RID: 12459
	public int language;

	// Token: 0x040030AC RID: 12460
	public int languageBonus;

	// Token: 0x040030AD RID: 12461
	public int languageGrade;

	// Token: 0x040030AE RID: 12462
	public int physical;

	// Token: 0x040030AF RID: 12463
	public int physicalBonus;

	// Token: 0x040030B0 RID: 12464
	public int physicalGrade;

	// Token: 0x040030B1 RID: 12465
	public int psychology;

	// Token: 0x040030B2 RID: 12466
	public int psychologyBonus;

	// Token: 0x040030B3 RID: 12467
	public int psychologyGrade;
}
