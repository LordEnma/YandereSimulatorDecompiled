using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C18 RID: 7192 RVA: 0x00148874 File Offset: 0x00146A74
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

	// Token: 0x06001C19 RID: 7193 RVA: 0x0014892C File Offset: 0x00146B2C
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

	// Token: 0x04003172 RID: 12658
	public int biology;

	// Token: 0x04003173 RID: 12659
	public int biologyBonus;

	// Token: 0x04003174 RID: 12660
	public int biologyGrade;

	// Token: 0x04003175 RID: 12661
	public int chemistry;

	// Token: 0x04003176 RID: 12662
	public int chemistryBonus;

	// Token: 0x04003177 RID: 12663
	public int chemistryGrade;

	// Token: 0x04003178 RID: 12664
	public int language;

	// Token: 0x04003179 RID: 12665
	public int languageBonus;

	// Token: 0x0400317A RID: 12666
	public int languageGrade;

	// Token: 0x0400317B RID: 12667
	public int physical;

	// Token: 0x0400317C RID: 12668
	public int physicalBonus;

	// Token: 0x0400317D RID: 12669
	public int physicalGrade;

	// Token: 0x0400317E RID: 12670
	public int psychology;

	// Token: 0x0400317F RID: 12671
	public int psychologyBonus;

	// Token: 0x04003180 RID: 12672
	public int psychologyGrade;
}
