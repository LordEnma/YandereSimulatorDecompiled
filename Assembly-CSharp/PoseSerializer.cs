// Decompiled with JetBrains decompiler
// Type: PoseSerializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PoseSerializer
{
  public const string SavePath = "{0}/Poses/{1}";

  public static void SerializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
  {
    StudentCosmeticSheet studentCosmeticSheet = cosmeticScript.CosmeticSheet();
    SerializedPose serializedPose;
    serializedPose.CosmeticData = JsonUtility.ToJson((object) studentCosmeticSheet);
    serializedPose.BoneData = PoseSerializer.getBoneData(root);
    string json = JsonUtility.ToJson((object) serializedPose);
    string str = string.Format("{0}/Poses/{1}", (object) Application.streamingAssetsPath, (object) (poseName + ".txt"));
    new FileInfo(str).Directory.Create();
    File.WriteAllText(str, json);
  }

  private static BoneData[] getBoneData(Transform root)
  {
    List<BoneData> boneDataList = new List<BoneData>();
    foreach (Transform componentsInChild in root.GetComponentsInChildren<Transform>())
      boneDataList.Add(new BoneData()
      {
        BoneName = (Object) componentsInChild == (Object) root ? "StudentRoot" : componentsInChild.name,
        LocalPosition = componentsInChild.localPosition,
        LocalRotation = componentsInChild.localRotation,
        LocalScale = componentsInChild.localScale
      });
    return boneDataList.ToArray();
  }

  public static void DeserializePose(
    CosmeticScript cosmeticScript,
    Transform root,
    string poseName)
  {
    string path = string.Format("{0}/Poses/{1}", (object) Application.streamingAssetsPath, (object) (poseName + ".txt"));
    if (!File.Exists(path))
      return;
    SerializedPose serializedPose = JsonUtility.FromJson<SerializedPose>(File.ReadAllText(path));
    StudentCosmeticSheet mySheet = JsonUtility.FromJson<StudentCosmeticSheet>(serializedPose.CosmeticData);
    cosmeticScript.LoadCosmeticSheet(mySheet);
    cosmeticScript.CharacterAnimation.Stop();
    bool flag = cosmeticScript.Male == mySheet.Male;
    Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
    foreach (BoneData boneData in serializedPose.BoneData)
    {
      foreach (Transform transform in componentsInChildren)
      {
        if (transform.name == boneData.BoneName && (Object) transform != (Object) cosmeticScript.LeftEyeRenderer.transform && (Object) transform != (Object) cosmeticScript.RightEyeRenderer.transform)
        {
          transform.localRotation = boneData.LocalRotation;
          if (flag)
          {
            transform.localPosition = boneData.LocalPosition;
            transform.localScale = boneData.LocalScale;
          }
        }
        else if (boneData.BoneName == "StudentRoot" && (Object) transform == (Object) root)
        {
          transform.localPosition = boneData.LocalPosition;
          transform.localRotation = boneData.LocalRotation;
          transform.localScale = boneData.LocalScale;
        }
      }
    }
  }

  public static string[] GetSavedPoses()
  {
    string[] files = Directory.GetFiles(string.Format("{0}/Poses/{1}", (object) Application.streamingAssetsPath, (object) ""));
    List<string> stringList = new List<string>();
    foreach (string str in files)
    {
      if (str.EndsWith(".txt"))
        stringList.Add(str);
    }
    return stringList.ToArray();
  }
}
