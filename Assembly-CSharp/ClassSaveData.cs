using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BEC RID: 7148 RVA: 0x0014586C File Offset: 0x00143A6C
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

	// Token: 0x06001BED RID: 7149 RVA: 0x00145924 File Offset: 0x00143B24
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

	// Token: 0x040030F1 RID: 12529
	public int biology;

	// Token: 0x040030F2 RID: 12530
	public int biologyBonus;

	// Token: 0x040030F3 RID: 12531
	public int biologyGrade;

	// Token: 0x040030F4 RID: 12532
	public int chemistry;

	// Token: 0x040030F5 RID: 12533
	public int chemistryBonus;

	// Token: 0x040030F6 RID: 12534
	public int chemistryGrade;

	// Token: 0x040030F7 RID: 12535
	public int language;

	// Token: 0x040030F8 RID: 12536
	public int languageBonus;

	// Token: 0x040030F9 RID: 12537
	public int languageGrade;

	// Token: 0x040030FA RID: 12538
	public int physical;

	// Token: 0x040030FB RID: 12539
	public int physicalBonus;

	// Token: 0x040030FC RID: 12540
	public int physicalGrade;

	// Token: 0x040030FD RID: 12541
	public int psychology;

	// Token: 0x040030FE RID: 12542
	public int psychologyBonus;

	// Token: 0x040030FF RID: 12543
	public int psychologyGrade;
}
