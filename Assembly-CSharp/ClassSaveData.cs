using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C0E RID: 7182 RVA: 0x00148180 File Offset: 0x00146380
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

	// Token: 0x06001C0F RID: 7183 RVA: 0x00148238 File Offset: 0x00146438
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

	// Token: 0x04003164 RID: 12644
	public int biology;

	// Token: 0x04003165 RID: 12645
	public int biologyBonus;

	// Token: 0x04003166 RID: 12646
	public int biologyGrade;

	// Token: 0x04003167 RID: 12647
	public int chemistry;

	// Token: 0x04003168 RID: 12648
	public int chemistryBonus;

	// Token: 0x04003169 RID: 12649
	public int chemistryGrade;

	// Token: 0x0400316A RID: 12650
	public int language;

	// Token: 0x0400316B RID: 12651
	public int languageBonus;

	// Token: 0x0400316C RID: 12652
	public int languageGrade;

	// Token: 0x0400316D RID: 12653
	public int physical;

	// Token: 0x0400316E RID: 12654
	public int physicalBonus;

	// Token: 0x0400316F RID: 12655
	public int physicalGrade;

	// Token: 0x04003170 RID: 12656
	public int psychology;

	// Token: 0x04003171 RID: 12657
	public int psychologyBonus;

	// Token: 0x04003172 RID: 12658
	public int psychologyGrade;
}
