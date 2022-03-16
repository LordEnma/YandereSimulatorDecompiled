using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x001476C4 File Offset: 0x001458C4
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

	// Token: 0x06001C05 RID: 7173 RVA: 0x0014777C File Offset: 0x0014597C
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

	// Token: 0x0400314B RID: 12619
	public int biology;

	// Token: 0x0400314C RID: 12620
	public int biologyBonus;

	// Token: 0x0400314D RID: 12621
	public int biologyGrade;

	// Token: 0x0400314E RID: 12622
	public int chemistry;

	// Token: 0x0400314F RID: 12623
	public int chemistryBonus;

	// Token: 0x04003150 RID: 12624
	public int chemistryGrade;

	// Token: 0x04003151 RID: 12625
	public int language;

	// Token: 0x04003152 RID: 12626
	public int languageBonus;

	// Token: 0x04003153 RID: 12627
	public int languageGrade;

	// Token: 0x04003154 RID: 12628
	public int physical;

	// Token: 0x04003155 RID: 12629
	public int physicalBonus;

	// Token: 0x04003156 RID: 12630
	public int physicalGrade;

	// Token: 0x04003157 RID: 12631
	public int psychology;

	// Token: 0x04003158 RID: 12632
	public int psychologyBonus;

	// Token: 0x04003159 RID: 12633
	public int psychologyGrade;
}
