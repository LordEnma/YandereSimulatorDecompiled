using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
	public string[] Dialogue;

	public int[] Speaker;

	public string[] IdleAnim;

	public string[] CurrentIdleAnim;

	private void Start()
	{
		LoadDialogueFromFile("Ayano Basu Script");
		for (int i = 1; i < IdleAnim.Length; i++)
		{
			IdleAnim[i] = CurrentIdleAnim[Speaker[i]];
		}
	}

	private void LoadDialogueFromFile(string fileName)
	{
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		TextAsset textAsset = Resources.Load<TextAsset>(fileName);
		if (textAsset != null)
		{
			string[] array = textAsset.text.Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				int num = text.IndexOf(":");
				if (num != -1)
				{
					string text2 = text.Substring(0, num).Trim();
					string item = text.Substring(num + 1).Trim();
					list.Add(item);
					int item2 = 0;
					switch (text2)
					{
					case "Ayano":
						item2 = 1;
						break;
					case "Sakyu":
						item2 = 2;
						break;
					case "Inkyu":
						item2 = 3;
						break;
					}
					list2.Add(item2);
				}
			}
			Dialogue = list.ToArray();
			Speaker = list2.ToArray();
			for (int j = 0; j < Dialogue.Length; j++)
			{
				Debug.Log("Dialogue Element " + (j + 1) + ": " + Dialogue[j]);
				Debug.Log("Speaker Element " + (j + 1) + ": " + Speaker[j]);
			}
		}
		else
		{
			Debug.LogError("Text file not found in Resources folder.");
		}
	}
}
