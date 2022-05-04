using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class ClassSaveData
{
	// Token: 0x06001C1F RID: 7199 RVA: 0x0014907C File Offset: 0x0014727C
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

	// Token: 0x06001C20 RID: 7200 RVA: 0x00149134 File Offset: 0x00147334
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

	// Token: 0x04003181 RID: 12673
	public int biology;

	// Token: 0x04003182 RID: 12674
	public int biologyBonus;

	// Token: 0x04003183 RID: 12675
	public int biologyGrade;

	// Token: 0x04003184 RID: 12676
	public int chemistry;

	// Token: 0x04003185 RID: 12677
	public int chemistryBonus;

	// Token: 0x04003186 RID: 12678
	public int chemistryGrade;

	// Token: 0x04003187 RID: 12679
	public int language;

	// Token: 0x04003188 RID: 12680
	public int languageBonus;

	// Token: 0x04003189 RID: 12681
	public int languageGrade;

	// Token: 0x0400318A RID: 12682
	public int physical;

	// Token: 0x0400318B RID: 12683
	public int physicalBonus;

	// Token: 0x0400318C RID: 12684
	public int physicalGrade;

	// Token: 0x0400318D RID: 12685
	public int psychology;

	// Token: 0x0400318E RID: 12686
	public int psychologyBonus;

	// Token: 0x0400318F RID: 12687
	public int psychologyGrade;
}
