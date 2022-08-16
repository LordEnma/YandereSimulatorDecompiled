// Decompiled with JetBrains decompiler
// Type: StudentSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    foreach (int num in StudentGlobals.KeysOfStudentAccessory())
      studentSaveData.studentAccessory.Add(num, StudentGlobals.GetStudentAccessory(num));
    foreach (int studentID in StudentGlobals.KeysOfStudentArrested())
    {
      if (StudentGlobals.GetStudentArrested(studentID))
        studentSaveData.studentArrested.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentBroken())
    {
      if (StudentGlobals.GetStudentBroken(studentID))
        studentSaveData.studentBroken.Add(studentID);
    }
    foreach (int num in StudentGlobals.KeysOfStudentBustSize())
      studentSaveData.studentBustSize.Add(num, StudentGlobals.GetStudentBustSize(num));
    foreach (int num in StudentGlobals.KeysOfStudentColor())
      studentSaveData.studentColor.Add(num, StudentGlobals.GetStudentColor(num));
    foreach (int studentID in StudentGlobals.KeysOfStudentDead())
    {
      if (StudentGlobals.GetStudentDead(studentID))
        studentSaveData.studentDead.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentDying())
    {
      if (StudentGlobals.GetStudentDying(studentID))
        studentSaveData.studentDying.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentExpelled())
    {
      if (StudentGlobals.GetStudentExpelled(studentID))
        studentSaveData.studentExpelled.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentExposed())
    {
      if (StudentGlobals.GetStudentExposed(studentID))
        studentSaveData.studentExposed.Add(studentID);
    }
    foreach (int num in StudentGlobals.KeysOfStudentEyeColor())
      studentSaveData.studentEyeColor.Add(num, StudentGlobals.GetStudentEyeColor(num));
    foreach (int studentID in StudentGlobals.KeysOfStudentGrudge())
    {
      if (StudentGlobals.GetStudentGrudge(studentID))
        studentSaveData.studentGrudge.Add(studentID);
    }
    foreach (int num in StudentGlobals.KeysOfStudentHairstyle())
      studentSaveData.studentHairstyle.Add(num, StudentGlobals.GetStudentHairstyle(num));
    foreach (int studentID in StudentGlobals.KeysOfStudentKidnapped())
    {
      if (StudentGlobals.GetStudentKidnapped(studentID))
        studentSaveData.studentKidnapped.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentMissing())
    {
      if (StudentGlobals.GetStudentMissing(studentID))
        studentSaveData.studentMissing.Add(studentID);
    }
    foreach (int num in StudentGlobals.KeysOfStudentName())
      studentSaveData.studentName.Add(num, StudentGlobals.GetStudentName(num));
    foreach (int studentID in StudentGlobals.KeysOfStudentPhotographed())
    {
      if (StudentGlobals.GetStudentPhotographed(studentID))
        studentSaveData.studentPhotographed.Add(studentID);
    }
    foreach (int studentID in StudentGlobals.KeysOfStudentReplaced())
    {
      if (StudentGlobals.GetStudentReplaced(studentID))
        studentSaveData.studentReplaced.Add(studentID);
    }
    foreach (int num in StudentGlobals.KeysOfStudentReputation())
      studentSaveData.studentReputation.Add(num, StudentGlobals.GetStudentReputation(num));
    foreach (int num in StudentGlobals.KeysOfStudentSanity())
      studentSaveData.studentSanity.Add(num, (float) StudentGlobals.GetStudentSanity(num));
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
    foreach (KeyValuePair<int, string> keyValuePair in (Dictionary<int, string>) data.studentAccessory)
      StudentGlobals.SetStudentAccessory(keyValuePair.Key, keyValuePair.Value);
    foreach (int studentID in (HashSet<int>) data.studentArrested)
      StudentGlobals.SetStudentArrested(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentBroken)
      StudentGlobals.SetStudentBroken(studentID, true);
    foreach (KeyValuePair<int, float> keyValuePair in (Dictionary<int, float>) data.studentBustSize)
      StudentGlobals.SetStudentBustSize(keyValuePair.Key, keyValuePair.Value);
    foreach (KeyValuePair<int, Color> keyValuePair in (Dictionary<int, Color>) data.studentColor)
      StudentGlobals.SetStudentColor(keyValuePair.Key, keyValuePair.Value);
    foreach (int studentID in (HashSet<int>) data.studentDead)
      StudentGlobals.SetStudentDead(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentDying)
      StudentGlobals.SetStudentDying(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentExpelled)
      StudentGlobals.SetStudentExpelled(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentExposed)
      StudentGlobals.SetStudentExposed(studentID, true);
    foreach (KeyValuePair<int, Color> keyValuePair in (Dictionary<int, Color>) data.studentEyeColor)
      StudentGlobals.SetStudentEyeColor(keyValuePair.Key, keyValuePair.Value);
    foreach (int studentID in (HashSet<int>) data.studentGrudge)
      StudentGlobals.SetStudentGrudge(studentID, true);
    foreach (KeyValuePair<int, string> keyValuePair in (Dictionary<int, string>) data.studentHairstyle)
      StudentGlobals.SetStudentHairstyle(keyValuePair.Key, keyValuePair.Value);
    foreach (int studentID in (HashSet<int>) data.studentKidnapped)
      StudentGlobals.SetStudentKidnapped(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentMissing)
      StudentGlobals.SetStudentMissing(studentID, true);
    foreach (KeyValuePair<int, string> keyValuePair in (Dictionary<int, string>) data.studentName)
      StudentGlobals.SetStudentName(keyValuePair.Key, keyValuePair.Value);
    foreach (int studentID in (HashSet<int>) data.studentPhotographed)
      StudentGlobals.SetStudentPhotographed(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentReplaced)
      StudentGlobals.SetStudentReplaced(studentID, true);
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.studentReputation)
      StudentGlobals.SetStudentReputation(keyValuePair.Key, keyValuePair.Value);
  }
}
