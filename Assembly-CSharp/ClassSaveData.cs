using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x00146820 File Offset: 0x00144A20
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

	// Token: 0x06001BF8 RID: 7160 RVA: 0x001468D8 File Offset: 0x00144AD8
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

	// Token: 0x04003117 RID: 12567
	public int biology;

	// Token: 0x04003118 RID: 12568
	public int biologyBonus;

	// Token: 0x04003119 RID: 12569
	public int biologyGrade;

	// Token: 0x0400311A RID: 12570
	public int chemistry;

	// Token: 0x0400311B RID: 12571
	public int chemistryBonus;

	// Token: 0x0400311C RID: 12572
	public int chemistryGrade;

	// Token: 0x0400311D RID: 12573
	public int language;

	// Token: 0x0400311E RID: 12574
	public int languageBonus;

	// Token: 0x0400311F RID: 12575
	public int languageGrade;

	// Token: 0x04003120 RID: 12576
	public int physical;

	// Token: 0x04003121 RID: 12577
	public int physicalBonus;

	// Token: 0x04003122 RID: 12578
	public int physicalGrade;

	// Token: 0x04003123 RID: 12579
	public int psychology;

	// Token: 0x04003124 RID: 12580
	public int psychologyBonus;

	// Token: 0x04003125 RID: 12581
	public int psychologyGrade;
}
