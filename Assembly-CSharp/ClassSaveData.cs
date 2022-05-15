using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C25 RID: 7205 RVA: 0x00149D30 File Offset: 0x00147F30
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

	// Token: 0x06001C26 RID: 7206 RVA: 0x00149DE8 File Offset: 0x00147FE8
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

	// Token: 0x04003196 RID: 12694
	public int biology;

	// Token: 0x04003197 RID: 12695
	public int biologyBonus;

	// Token: 0x04003198 RID: 12696
	public int biologyGrade;

	// Token: 0x04003199 RID: 12697
	public int chemistry;

	// Token: 0x0400319A RID: 12698
	public int chemistryBonus;

	// Token: 0x0400319B RID: 12699
	public int chemistryGrade;

	// Token: 0x0400319C RID: 12700
	public int language;

	// Token: 0x0400319D RID: 12701
	public int languageBonus;

	// Token: 0x0400319E RID: 12702
	public int languageGrade;

	// Token: 0x0400319F RID: 12703
	public int physical;

	// Token: 0x040031A0 RID: 12704
	public int physicalBonus;

	// Token: 0x040031A1 RID: 12705
	public int physicalGrade;

	// Token: 0x040031A2 RID: 12706
	public int psychology;

	// Token: 0x040031A3 RID: 12707
	public int psychologyBonus;

	// Token: 0x040031A4 RID: 12708
	public int psychologyGrade;
}
