﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020003B1 RID: 945
public static class PoseSerializer
{
	// Token: 0x06001AD6 RID: 6870 RVA: 0x00128684 File Offset: 0x00126884
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

	// Token: 0x06001AD7 RID: 6871 RVA: 0x001286F4 File Offset: 0x001268F4
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

	// Token: 0x06001AD8 RID: 6872 RVA: 0x0012877C File Offset: 0x0012697C
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

	// Token: 0x06001AD9 RID: 6873 RVA: 0x001288F0 File Offset: 0x00126AF0
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

	// Token: 0x04002D32 RID: 11570
	public const string SavePath = "{0}/Poses/{1}";
}
