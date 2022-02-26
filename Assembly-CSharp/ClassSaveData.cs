using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x001462E4 File Offset: 0x001444E4
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

	// Token: 0x06001BF6 RID: 7158 RVA: 0x0014639C File Offset: 0x0014459C
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

	// Token: 0x04003101 RID: 12545
	public int biology;

	// Token: 0x04003102 RID: 12546
	public int biologyBonus;

	// Token: 0x04003103 RID: 12547
	public int biologyGrade;

	// Token: 0x04003104 RID: 12548
	public int chemistry;

	// Token: 0x04003105 RID: 12549
	public int chemistryBonus;

	// Token: 0x04003106 RID: 12550
	public int chemistryGrade;

	// Token: 0x04003107 RID: 12551
	public int language;

	// Token: 0x04003108 RID: 12552
	public int languageBonus;

	// Token: 0x04003109 RID: 12553
	public int languageGrade;

	// Token: 0x0400310A RID: 12554
	public int physical;

	// Token: 0x0400310B RID: 12555
	public int physicalBonus;

	// Token: 0x0400310C RID: 12556
	public int physicalGrade;

	// Token: 0x0400310D RID: 12557
	public int psychology;

	// Token: 0x0400310E RID: 12558
	public int psychologyBonus;

	// Token: 0x0400310F RID: 12559
	public int psychologyGrade;
}
