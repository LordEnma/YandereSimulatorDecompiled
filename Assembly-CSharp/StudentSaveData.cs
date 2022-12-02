using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StudentSaveData
{
	public bool customSuitor;

	public int customSuitorAccessory;

	public bool customSuitorBlonde;

	public int customSuitorEyewear;

	public int customSuitorHair;

	public int customSuitorJewelry;

	public bool customSuitorTan;

	public int expelProgress;

	public int femaleUniform;

	public int maleUniform;

	public IntAndStringDictionary studentAccessory = new IntAndStringDictionary();

	public IntHashSet studentArrested = new IntHashSet();

	public IntHashSet studentBroken = new IntHashSet();

	public IntAndFloatDictionary studentBustSize = new IntAndFloatDictionary();

	public IntAndColorDictionary studentColor = new IntAndColorDictionary();

	public IntHashSet studentDead = new IntHashSet();

	public IntHashSet studentDying = new IntHashSet();

	public IntHashSet studentExpelled = new IntHashSet();

	public IntHashSet studentExposed = new IntHashSet();

	public IntAndColorDictionary studentEyeColor = new IntAndColorDictionary();

	public IntHashSet studentGrudge = new IntHashSet();

	public IntAndStringDictionary studentHairstyle = new IntAndStringDictionary();

	public IntHashSet studentKidnapped = new IntHashSet();

	public IntHashSet studentMissing = new IntHashSet();

	public IntAndStringDictionary studentName = new IntAndStringDictionary();

	public IntHashSet studentPhotographed = new IntHashSet();

	public IntHashSet studentReplaced = new IntHashSet();

	public IntAndIntDictionary studentReputation = new IntAndIntDictionary();

	public IntAndFloatDictionary studentSanity = new IntAndFloatDictionary();

	public IntHashSet studentSlave = new IntHashSet();

	public static StudentSaveData ReadFromGlobals()
	{
		StudentSaveData studentSaveData = new StudentSaveData();
		studentSaveData.customSuitor = StudentGlobals.CustomSuitor;
		studentSaveData.customSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
		studentSaveData.customSuitorBlonde = StudentGlobals.CustomSuitorBlonde;
		studentSaveData.customSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
		studentSaveData.customSuitorHair = StudentGlobals.CustomSuitorHair;
		studentSaveData.customSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
		studentSaveData.customSuitorTan = StudentGlobals.CustomSuitorTan;
		studentSaveData.expelProgress = StudentGlobals.ExpelProgress;
		studentSaveData.femaleUniform = StudentGlobals.FemaleUniform;
		studentSaveData.maleUniform = StudentGlobals.MaleUniform;
		int[] array = StudentGlobals.KeysOfStudentAccessory();
		foreach (int num in array)
		{
			studentSaveData.studentAccessory.Add(num, StudentGlobals.GetStudentAccessory(num));
		}
		array = StudentGlobals.KeysOfStudentArrested();
		foreach (int num2 in array)
		{
			if (StudentGlobals.GetStudentArrested(num2))
			{
				studentSaveData.studentArrested.Add(num2);
			}
		}
		array = StudentGlobals.KeysOfStudentBroken();
		foreach (int num3 in array)
		{
			if (StudentGlobals.GetStudentBroken(num3))
			{
				studentSaveData.studentBroken.Add(num3);
			}
		}
		array = StudentGlobals.KeysOfStudentBustSize();
		foreach (int num4 in array)
		{
			studentSaveData.studentBustSize.Add(num4, StudentGlobals.GetStudentBustSize(num4));
		}
		array = StudentGlobals.KeysOfStudentColor();
		foreach (int num5 in array)
		{
			studentSaveData.studentColor.Add(num5, StudentGlobals.GetStudentColor(num5));
		}
		array = StudentGlobals.KeysOfStudentDead();
		foreach (int num6 in array)
		{
			if (StudentGlobals.GetStudentDead(num6))
			{
				studentSaveData.studentDead.Add(num6);
			}
		}
		array = StudentGlobals.KeysOfStudentDying();
		foreach (int num7 in array)
		{
			if (StudentGlobals.GetStudentDying(num7))
			{
				studentSaveData.studentDying.Add(num7);
			}
		}
		array = StudentGlobals.KeysOfStudentExpelled();
		foreach (int num8 in array)
		{
			if (StudentGlobals.GetStudentExpelled(num8))
			{
				studentSaveData.studentExpelled.Add(num8);
			}
		}
		array = StudentGlobals.KeysOfStudentExposed();
		foreach (int num9 in array)
		{
			if (StudentGlobals.GetStudentExposed(num9))
			{
				studentSaveData.studentExposed.Add(num9);
			}
		}
		array = StudentGlobals.KeysOfStudentEyeColor();
		foreach (int num10 in array)
		{
			studentSaveData.studentEyeColor.Add(num10, StudentGlobals.GetStudentEyeColor(num10));
		}
		array = StudentGlobals.KeysOfStudentGrudge();
		foreach (int num11 in array)
		{
			if (StudentGlobals.GetStudentGrudge(num11))
			{
				studentSaveData.studentGrudge.Add(num11);
			}
		}
		array = StudentGlobals.KeysOfStudentHairstyle();
		foreach (int num12 in array)
		{
			studentSaveData.studentHairstyle.Add(num12, StudentGlobals.GetStudentHairstyle(num12));
		}
		array = StudentGlobals.KeysOfStudentKidnapped();
		foreach (int num13 in array)
		{
			if (StudentGlobals.GetStudentKidnapped(num13))
			{
				studentSaveData.studentKidnapped.Add(num13);
			}
		}
		array = StudentGlobals.KeysOfStudentMissing();
		foreach (int num14 in array)
		{
			if (StudentGlobals.GetStudentMissing(num14))
			{
				studentSaveData.studentMissing.Add(num14);
			}
		}
		array = StudentGlobals.KeysOfStudentName();
		foreach (int num15 in array)
		{
			studentSaveData.studentName.Add(num15, StudentGlobals.GetStudentName(num15));
		}
		array = StudentGlobals.KeysOfStudentPhotographed();
		foreach (int num16 in array)
		{
			if (StudentGlobals.GetStudentPhotographed(num16))
			{
				studentSaveData.studentPhotographed.Add(num16);
			}
		}
		array = StudentGlobals.KeysOfStudentReplaced();
		foreach (int num17 in array)
		{
			if (StudentGlobals.GetStudentReplaced(num17))
			{
				studentSaveData.studentReplaced.Add(num17);
			}
		}
		array = StudentGlobals.KeysOfStudentReputation();
		foreach (int num18 in array)
		{
			studentSaveData.studentReputation.Add(num18, StudentGlobals.GetStudentReputation(num18));
		}
		array = StudentGlobals.KeysOfStudentSanity();
		foreach (int num19 in array)
		{
			studentSaveData.studentSanity.Add(num19, StudentGlobals.GetStudentSanity(num19));
		}
		return studentSaveData;
	}

	public static void WriteToGlobals(StudentSaveData data)
	{
		StudentGlobals.CustomSuitor = data.customSuitor;
		StudentGlobals.CustomSuitorAccessory = data.customSuitorAccessory;
		StudentGlobals.CustomSuitorBlonde = data.customSuitorBlonde;
		StudentGlobals.CustomSuitorEyewear = data.customSuitorEyewear;
		StudentGlobals.CustomSuitorHair = data.customSuitorHair;
		StudentGlobals.CustomSuitorJewelry = data.customSuitorJewelry;
		StudentGlobals.CustomSuitorTan = data.customSuitorTan;
		StudentGlobals.ExpelProgress = data.expelProgress;
		StudentGlobals.FemaleUniform = data.femaleUniform;
		StudentGlobals.MaleUniform = data.maleUniform;
		foreach (KeyValuePair<int, string> item in data.studentAccessory)
		{
			StudentGlobals.SetStudentAccessory(item.Key, item.Value);
		}
		foreach (int item2 in data.studentArrested)
		{
			StudentGlobals.SetStudentArrested(item2, true);
		}
		foreach (int item3 in data.studentBroken)
		{
			StudentGlobals.SetStudentBroken(item3, true);
		}
		foreach (KeyValuePair<int, float> item4 in data.studentBustSize)
		{
			StudentGlobals.SetStudentBustSize(item4.Key, item4.Value);
		}
		foreach (KeyValuePair<int, Color> item5 in data.studentColor)
		{
			StudentGlobals.SetStudentColor(item5.Key, item5.Value);
		}
		foreach (int item6 in data.studentDead)
		{
			StudentGlobals.SetStudentDead(item6, true);
		}
		foreach (int item7 in data.studentDying)
		{
			StudentGlobals.SetStudentDying(item7, true);
		}
		foreach (int item8 in data.studentExpelled)
		{
			StudentGlobals.SetStudentExpelled(item8, true);
		}
		foreach (int item9 in data.studentExposed)
		{
			StudentGlobals.SetStudentExposed(item9, true);
		}
		foreach (KeyValuePair<int, Color> item10 in data.studentEyeColor)
		{
			StudentGlobals.SetStudentEyeColor(item10.Key, item10.Value);
		}
		foreach (int item11 in data.studentGrudge)
		{
			StudentGlobals.SetStudentGrudge(item11, true);
		}
		foreach (KeyValuePair<int, string> item12 in data.studentHairstyle)
		{
			StudentGlobals.SetStudentHairstyle(item12.Key, item12.Value);
		}
		foreach (int item13 in data.studentKidnapped)
		{
			StudentGlobals.SetStudentKidnapped(item13, true);
		}
		foreach (int item14 in data.studentMissing)
		{
			StudentGlobals.SetStudentMissing(item14, true);
		}
		foreach (KeyValuePair<int, string> item15 in data.studentName)
		{
			StudentGlobals.SetStudentName(item15.Key, item15.Value);
		}
		foreach (int item16 in data.studentPhotographed)
		{
			StudentGlobals.SetStudentPhotographed(item16, true);
		}
		foreach (int item17 in data.studentReplaced)
		{
			StudentGlobals.SetStudentReplaced(item17, true);
		}
		foreach (KeyValuePair<int, int> item18 in data.studentReputation)
		{
			StudentGlobals.SetStudentReputation(item18.Key, item18.Value);
		}
	}
}
