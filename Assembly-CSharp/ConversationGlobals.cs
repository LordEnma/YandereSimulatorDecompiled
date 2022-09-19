// Decompiled with JetBrains decompiler
// Type: ConversationGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public static class ConversationGlobals
{
  private const string Str_TopicDiscovered = "TopicDiscovered_";
  private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";

  public static bool GetTopicDiscovered(int topicID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + topicID.ToString());

  public static void SetTopicDiscovered(int topicID, bool value)
  {
    string id = topicID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + id, value);
  }

  public static int[] KeysOfTopicDiscovered() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_");

  public static bool GetTopicLearnedByStudent(int topicID, int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_" + topicID.ToString() + "_" + studentID.ToString());

  public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
  {
    string str1 = topicID.ToString();
    string str2 = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_", str1 + "^" + str2);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_" + str1 + "_" + str2, value);
  }

  public static IntAndIntPair[] KeysOfTopicLearnedByStudent()
  {
    KeyValuePair<int, int>[] keys = KeysHelper.GetKeys<int, int>("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_");
    IntAndIntPair[] intAndIntPairArray = new IntAndIntPair[keys.Length];
    for (int index = 0; index < keys.Length; ++index)
    {
      KeyValuePair<int, int> keyValuePair = keys[index];
      intAndIntPairArray[index] = new IntAndIntPair(keyValuePair.Key, keyValuePair.Value);
    }
    return intAndIntPairArray;
  }

  public static void DeleteAll()
  {
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", ConversationGlobals.KeysOfTopicDiscovered());
    foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent())
      Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_" + intAndIntPair.first.ToString() + "_" + intAndIntPair.second.ToString());
    KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_");
  }
}
