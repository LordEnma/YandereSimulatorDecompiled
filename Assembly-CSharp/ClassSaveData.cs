using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C26 RID: 7206 RVA: 0x00149FEC File Offset: 0x001481EC
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

	// Token: 0x06001C27 RID: 7207 RVA: 0x0014A0A4 File Offset: 0x001482A4
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

	// Token: 0x0400319E RID: 12702
	public int biology;

	// Token: 0x0400319F RID: 12703
	public int biologyBonus;

	// Token: 0x040031A0 RID: 12704
	public int biologyGrade;

	// Token: 0x040031A1 RID: 12705
	public int chemistry;

	// Token: 0x040031A2 RID: 12706
	public int chemistryBonus;

	// Token: 0x040031A3 RID: 12707
	public int chemistryGrade;

	// Token: 0x040031A4 RID: 12708
	public int language;

	// Token: 0x040031A5 RID: 12709
	public int languageBonus;

	// Token: 0x040031A6 RID: 12710
	public int languageGrade;

	// Token: 0x040031A7 RID: 12711
	public int physical;

	// Token: 0x040031A8 RID: 12712
	public int physicalBonus;

	// Token: 0x040031A9 RID: 12713
	public int physicalGrade;

	// Token: 0x040031AA RID: 12714
	public int psychology;

	// Token: 0x040031AB RID: 12715
	public int psychologyBonus;

	// Token: 0x040031AC RID: 12716
	public int psychologyGrade;
}
