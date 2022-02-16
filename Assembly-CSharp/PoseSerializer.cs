using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020003B4 RID: 948
public static class PoseSerializer
{
	// Token: 0x06001AE7 RID: 6887 RVA: 0x001295C8 File Offset: 0x001277C8
	public static void SerializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		StudentCosmeticSheet studentCosmeticSheet = cosmeticScript.CosmeticSheet();
		SerializedPose serializedPose;
		serializedPose.CosmeticData = JsonUtility.ToJson(studentCosmeticSheet);
		serializedPose.BoneData = PoseSerializer.getBoneData(root);
		string contents = JsonUtility.ToJson(serializedPose);
		string text = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		new FileInfo(text).Directory.Create();
		File.WriteAllText(text, contents);
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x00129638 File Offset: 0x00127838
	private static BoneData[] getBoneData(Transform root)
	{
		List<BoneData> list = new List<BoneData>();
		foreach (Transform transform in root.GetComponentsInChildren<Transform>())
		{
			list.Add(new BoneData
			{
				BoneName = ((transform == root) ? "StudentRoot" : transform.name),
				LocalPosition = transform.localPosition,
				LocalRotation = transform.localRotation,
				LocalScale = transform.localScale
			});
		}
		return list.ToArray();
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x001296C0 File Offset: 0x001278C0
	public static void DeserializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		string path = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		if (File.Exists(path))
		{
			SerializedPose serializedPose = JsonUtility.FromJson<SerializedPose>(File.ReadAllText(path));
			StudentCosmeticSheet studentCosmeticSheet = JsonUtility.FromJson<StudentCosmeticSheet>(serializedPose.CosmeticData);
			cosmeticScript.LoadCosmeticSheet(studentCosmeticSheet);
			cosmeticScript.CharacterAnimation.Stop();
			bool flag = cosmeticScript.Male == studentCosmeticSheet.Male;
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			foreach (BoneData boneData2 in serializedPose.BoneData)
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.name == boneData2.BoneName && transform != cosmeticScript.LeftEyeRenderer.transform && transform != cosmeticScript.RightEyeRenderer.transform)
					{
						transform.localRotation = boneData2.LocalRotation;
						if (flag)
						{
							transform.localPosition = boneData2.LocalPosition;
							transform.localScale = boneData2.LocalScale;
						}
					}
					else if (boneData2.BoneName == "StudentRoot" && transform == root)
					{
						transform.localPosition = boneData2.LocalPosition;
						transform.localRotation = boneData2.LocalRotation;
						transform.localScale = boneData2.LocalScale;
					}
				}
			}
		}
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x00129834 File Offset: 0x00127A34
	public static string[] GetSavedPoses()
	{
		string[] files = Directory.GetFiles(string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, ""));
		List<string> list = new List<string>();
		foreach (string text in files)
		{
			if (text.EndsWith(".txt"))
			{
				list.Add(text);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04002D4C RID: 11596
	public const string SavePath = "{0}/Poses/{1}";
}
