// Decompiled with JetBrains decompiler
// Type: StudentGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class StudentGlobals
{
  private const string Str_CustomSuitor = "CustomSuitor";
  private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";
  private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";
  private const string Str_CustomSuitorBlack = "CustomSuitorBlack";
  private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";
  private const string Str_CustomSuitorHair = "CustomSuitorHair";
  private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";
  private const string Str_CustomSuitorTan = "CustomSuitorTan";
  private const string Str_ExpelProgress = "ExpelProgress";
  private const string Str_FemaleUniform = "FemaleUniform";
  private const string Str_MaleUniform = "MaleUniform";
  private const string Str_StudentAccessory = "StudentAccessory_";
  private const string Str_StudentArrested = "StudentArrested_";
  private const string Str_StudentBroken = "StudentBroken_";
  private const string Str_StudentBustSize = "StudentBustSize_";
  private const string Str_StudentColor = "StudentColor_";
  private const string Str_StudentDead = "StudentDead_";
  private const string Str_StudentDying = "StudentDying_";
  private const string Str_StudentExpelled = "StudentExpelled_";
  private const string Str_StudentExposed = "StudentExposed_";
  private const string Str_StudentEyeColor = "StudentEyeColor_";
  private const string Str_StudentGrudge = "StudentGrudge_";
  private const string Str_StudentHairstyle = "StudentHairstyle_";
  private const string Str_StudentKidnapped = "StudentKidnapped_";
  private const string Str_StudentMissing = "StudentMissing_";
  private const string Str_StudentName = "StudentName_";
  private const string Str_StudentPhotographed = "StudentPhotographed_";
  private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";
  private const string Str_StudentReplaced = "StudentReplaced_";
  private const string Str_StudentReputation = "StudentReputation_";
  private const string Str_StudentSanity = "StudentSanity_";
  private const string Str_StudentSlave = "StudentSlave";
  private const string Str_FragileSlave = "FragileSlave";
  private const string Str_FragileTarget = "FragileTarget";
  private const string Str_ReputationTriangle = "ReputatonTriangle";
  private const string Str_StudentRansomed = "StudentRansomed_";
  private const string Str_MemorialStudents = "MemorialStudents";
  private const string Str_MemorialStudent1 = "MemorialStudent1";
  private const string Str_MemorialStudent2 = "MemorialStudent2";
  private const string Str_MemorialStudent3 = "MemorialStudent3";
  private const string Str_MemorialStudent4 = "MemorialStudent4";
  private const string Str_MemorialStudent5 = "MemorialStudent5";
  private const string Str_MemorialStudent6 = "MemorialStudent6";
  private const string Str_MemorialStudent7 = "MemorialStudent7";
  private const string Str_MemorialStudent8 = "MemorialStudent8";
  private const string Str_MemorialStudent9 = "MemorialStudent9";
  private const string Str_Prisoner1 = "Prisoner1";
  private const string Str_Prisoner2 = "Prisoner2";
  private const string Str_Prisoner3 = "Prisoner3";
  private const string Str_Prisoner4 = "Prisoner4";
  private const string Str_Prisoner5 = "Prisoner5";
  private const string Str_Prisoner6 = "Prisoner6";
  private const string Str_Prisoner7 = "Prisoner7";
  private const string Str_Prisoner8 = "Prisoner8";
  private const string Str_Prisoner9 = "Prisoner9";
  private const string Str_Prisoner10 = "Prisoner10";
  private const string Str_Prisoners = "Prisoners";
  private const string Str_PrisonerChosen = "PrisonerChosen";
  private const string Str_UpdateRivalReputation = "UpdateRivalReputation";

  public static bool CustomSuitor
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor", value);
  }

  public static int CustomSuitorAccessory
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory", value);
  }

  public static bool CustomSuitorBlonde
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde", value);
  }

  public static bool CustomSuitorBlack
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack", value);
  }

  public static int CustomSuitorEyewear
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear", value);
  }

  public static int CustomSuitorHair
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair", value);
  }

  public static int CustomSuitorJewelry
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry", value);
  }

  public static bool CustomSuitorTan
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan", value);
  }

  public static int ExpelProgress
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress", value);
  }

  public static int FemaleUniform
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform", value);
  }

  public static int MaleUniform
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform", value);
  }

  public static int MemorialStudents
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents", value);
  }

  public static int MemorialStudent1
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1", value);
  }

  public static int MemorialStudent2
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2", value);
  }

  public static int MemorialStudent3
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3", value);
  }

  public static int MemorialStudent4
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4", value);
  }

  public static int MemorialStudent5
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5", value);
  }

  public static int MemorialStudent6
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6", value);
  }

  public static int MemorialStudent7
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7", value);
  }

  public static int MemorialStudent8
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8", value);
  }

  public static int MemorialStudent9
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9", value);
  }

  public static int Prisoner1
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner1");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner1", value);
  }

  public static int Prisoner2
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner2");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner2", value);
  }

  public static int Prisoner3
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner3");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner3", value);
  }

  public static int Prisoner4
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner4");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner4", value);
  }

  public static int Prisoner5
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner5");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner5", value);
  }

  public static int Prisoner6
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner6");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner6", value);
  }

  public static int Prisoner7
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner7");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner7", value);
  }

  public static int Prisoner8
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner8");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner8", value);
  }

  public static int Prisoner9
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner9");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner9", value);
  }

  public static int Prisoner10
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner10");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner10", value);
  }

  public static int Prisoners
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoners");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Prisoners", value);
  }

  public static int PrisonerChosen
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PrisonerChosen");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PrisonerChosen", value);
  }

  public static string GetStudentAccessory(int studentID) => PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());

  public static void SetStudentAccessory(int studentID, string value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", id);
    PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + id, value);
  }

  public static int[] KeysOfStudentAccessory() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");

  public static bool GetStudentArrested(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());

  public static void SetStudentArrested(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + id, value);
  }

  public static int[] KeysOfStudentArrested() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");

  public static bool GetStudentBroken(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());

  public static void SetStudentBroken(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + id, value);
  }

  public static int[] KeysOfStudentBroken() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");

  public static float GetStudentBustSize(int studentID) => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());

  public static void SetStudentBustSize(int studentID, float value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", id);
    PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + id, value);
  }

  public static int[] KeysOfStudentBustSize() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");

  public static Color GetStudentColor(int studentID) => GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());

  public static void SetStudentColor(int studentID, Color value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", id);
    GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + id, value);
  }

  public static int[] KeysOfStudentColor() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");

  public static bool GetStudentDead(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());

  public static void SetStudentDead(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + id, value);
  }

  public static int[] KeysOfStudentDead() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");

  public static bool GetStudentDying(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());

  public static void SetStudentDying(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + id, value);
  }

  public static int[] KeysOfStudentDying() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");

  public static bool GetStudentExpelled(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());

  public static void SetStudentExpelled(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + id, value);
  }

  public static int[] KeysOfStudentExpelled() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");

  public static bool GetStudentExposed(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());

  public static void SetStudentExposed(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + id, value);
  }

  public static int[] KeysOfStudentExposed() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");

  public static Color GetStudentEyeColor(int studentID) => GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());

  public static void SetStudentEyeColor(int studentID, Color value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", id);
    GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + id, value);
  }

  public static int[] KeysOfStudentEyeColor() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");

  public static bool GetStudentGrudge(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());

  public static void SetStudentGrudge(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + id, value);
  }

  public static int[] KeysOfStudentGrudge() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");

  public static string GetStudentHairstyle(int studentID) => PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());

  public static void SetStudentHairstyle(int studentID, string value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", id);
    PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + id, value);
  }

  public static int[] KeysOfStudentHairstyle() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");

  public static bool GetStudentKidnapped(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());

  public static void SetStudentKidnapped(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + id, value);
  }

  public static int[] KeysOfStudentKidnapped() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");

  public static bool GetStudentMissing(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());

  public static void SetStudentMissing(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + id, value);
  }

  public static int[] KeysOfStudentMissing() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");

  public static string GetStudentName(int studentID) => PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());

  public static void SetStudentName(int studentID, string value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", id);
    PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + id, value);
  }

  public static int[] KeysOfStudentName() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");

  public static bool GetStudentPhotographed(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());

  public static void SetStudentPhotographed(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + id, value);
  }

  public static int[] KeysOfStudentPhotographed() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");

  public static bool GetStudentPhoneStolen(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());

  public static void SetStudentPhoneStolen(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + id, value);
  }

  public static int[] KeysOfStudentPhoneStolen() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");

  public static bool GetStudentReplaced(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());

  public static void SetStudentReplaced(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + id, value);
  }

  public static int[] KeysOfStudentReplaced() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");

  public static int GetStudentReputation(int studentID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());

  public static void SetStudentReputation(int studentID, int value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + id, value);
  }

  public static int[] KeysOfStudentReputation() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");

  public static float GetStudentSanity(int studentID) => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());

  public static void SetStudentSanity(int studentID, float value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", id);
    PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + id, value);
  }

  public static int[] KeysOfStudentSanity() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");

  public static int StudentSlave
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave", value);
  }

  public static int FragileSlave
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave", value);
  }

  public static int FragileTarget
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget", value);
  }

  public static Vector3 GetReputationTriangle(int studentID) => GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_Student_" + studentID.ToString() + "_ReputatonTriangle");

  public static void SetReputationTriangle(int studentID, Vector3 triangle) => GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_Student_" + studentID.ToString() + "_ReputatonTriangle", triangle);

  public static bool GetStudentRansomed(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());

  public static void SetStudentRansomed(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + id, value);
  }

  public static int[] KeysOfStudentRansomed() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");

  public static bool UpdateRivalReputation
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", StudentGlobals.KeysOfStudentArrested());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", StudentGlobals.KeysOfStudentBroken());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
    GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", StudentGlobals.KeysOfStudentColor());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", StudentGlobals.KeysOfStudentDead());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", StudentGlobals.KeysOfStudentDying());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", StudentGlobals.KeysOfStudentExposed());
    GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", StudentGlobals.KeysOfStudentMissing());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", StudentGlobals.KeysOfStudentName());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", StudentGlobals.KeysOfStudentPhoneStolen());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", StudentGlobals.KeysOfStudentReputation());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", StudentGlobals.KeysOfStudentSanity());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", StudentGlobals.KeysOfStudentRansomed());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner1");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner2");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner3");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner4");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner5");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner6");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner7");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner8");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner9");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoner10");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Prisoners");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PrisonerChosen");
  }
}
