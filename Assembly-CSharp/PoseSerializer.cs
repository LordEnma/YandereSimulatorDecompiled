using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PoseSerializer
{
	public const string SavePath = "{0}/Poses/{1}";

	public static void SerializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		StudentCosmeticSheet studentCosmeticSheet = cosmeticScript.CosmeticSheet();
		SerializedPose serializedPose = default(SerializedPose);
		serializedPose.CosmeticData = JsonUtility.ToJson(studentCosmeticSheet);
		serializedPose.BoneData = getBoneData(root);
		string contents = JsonUtility.ToJson(serializedPose);
		string text = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		new FileInfo(text).Directory.Create();
		File.WriteAllText(text, contents);
	}

	private static BoneData[] getBoneData(Transform root)
	{
		List<BoneData> list = new List<BoneData>();
		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
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

	public static void DeserializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		string path = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		if (!File.Exists(path))
		{
			return;
		}
		SerializedPose serializedPose = JsonUtility.FromJson<SerializedPose>(File.ReadAllText(path));
		StudentCosmeticSheet studentCosmeticSheet = JsonUtility.FromJson<StudentCosmeticSheet>(serializedPose.CosmeticData);
		cosmeticScript.CharacterAnimation.Stop();
		bool flag = cosmeticScript.Male == studentCosmeticSheet.Male;
		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
		BoneData[] boneData = serializedPose.BoneData;
		for (int i = 0; i < boneData.Length; i++)
		{
			BoneData boneData2 = boneData[i];
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				Transform transform2 = null;
				transform2 = (cosmeticScript.Male ? cosmeticScript.MaleHair[cosmeticScript.Hairstyle].transform : ((!cosmeticScript.Teacher) ? cosmeticScript.FemaleHair[cosmeticScript.Hairstyle].transform : cosmeticScript.TeacherHair[cosmeticScript.Hairstyle].transform));
				if (transform.name == boneData2.BoneName && transform != cosmeticScript.LeftEyeRenderer.transform && transform != cosmeticScript.RightEyeRenderer.transform && transform != transform2 && transform != cosmeticScript.HairRenderer.transform && transform != cosmeticScript.ScarfRenderer.gameObject.transform.parent)
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

	public static string[] GetSavedPoses()
	{
		string[] files = Directory.GetFiles(string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, ""));
		List<string> list = new List<string>();
		string[] array = files;
		foreach (string text in array)
		{
			if (text.EndsWith(".txt"))
			{
				list.Add(text);
			}
		}
		return list.ToArray();
	}
}
