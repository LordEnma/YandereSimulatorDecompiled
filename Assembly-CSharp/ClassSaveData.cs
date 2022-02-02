using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001BE3 RID: 7139 RVA: 0x001452D0 File Offset: 0x001434D0
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

	// Token: 0x06001BE4 RID: 7140 RVA: 0x00145388 File Offset: 0x00143588
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

	// Token: 0x040030E7 RID: 12519
	public int biology;

	// Token: 0x040030E8 RID: 12520
	public int biologyBonus;

	// Token: 0x040030E9 RID: 12521
	public int biologyGrade;

	// Token: 0x040030EA RID: 12522
	public int chemistry;

	// Token: 0x040030EB RID: 12523
	public int chemistryBonus;

	// Token: 0x040030EC RID: 12524
	public int chemistryGrade;

	// Token: 0x040030ED RID: 12525
	public int language;

	// Token: 0x040030EE RID: 12526
	public int languageBonus;

	// Token: 0x040030EF RID: 12527
	public int languageGrade;

	// Token: 0x040030F0 RID: 12528
	public int physical;

	// Token: 0x040030F1 RID: 12529
	public int physicalBonus;

	// Token: 0x040030F2 RID: 12530
	public int physicalGrade;

	// Token: 0x040030F3 RID: 12531
	public int psychology;

	// Token: 0x040030F4 RID: 12532
	public int psychologyBonus;

	// Token: 0x040030F5 RID: 12533
	public int psychologyGrade;
}
