using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSaveData
{
	public int alerts;

	public int enlightenment;

	public int enlightenmentBonus;

	public bool headset;

	public int kills;

	public int numbness;

	public int numbnessBonus;

	public int pantiesEquipped;

	public int pantyShots;

	public IntHashSet photo = new IntHashSet();

	public IntHashSet photoOnCorkboard = new IntHashSet();

	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	public float reputation;

	public int seduction;

	public int seductionBonus;

	public IntHashSet senpaiPhoto = new IntHashSet();

	public int senpaiShots;

	public int socialBonus;

	public int speedBonus;

	public int stealthBonus;

	public IntHashSet studentFriend = new IntHashSet();

	public IntHashSet studentPantyShot = new IntHashSet();

	public static PlayerSaveData ReadFromGlobals()
	{
		PlayerSaveData playerSaveData = new PlayerSaveData();
		playerSaveData.alerts = PlayerGlobals.Alerts;
		playerSaveData.enlightenment = PlayerGlobals.Enlightenment;
		playerSaveData.enlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
		playerSaveData.headset = PlayerGlobals.Headset;
		playerSaveData.kills = PlayerGlobals.Kills;
		playerSaveData.numbness = PlayerGlobals.Numbness;
		playerSaveData.numbnessBonus = PlayerGlobals.NumbnessBonus;
		playerSaveData.pantiesEquipped = PlayerGlobals.PantiesEquipped;
		playerSaveData.pantyShots = PlayerGlobals.PantyShots;
		int[] array = PlayerGlobals.KeysOfPhoto();
		foreach (int num in array)
		{
			if (PlayerGlobals.GetPhoto(num))
			{
				playerSaveData.photo.Add(num);
			}
		}
		array = PlayerGlobals.KeysOfPhotoOnCorkboard();
		foreach (int num2 in array)
		{
			if (PlayerGlobals.GetPhotoOnCorkboard(num2))
			{
				playerSaveData.photoOnCorkboard.Add(num2);
			}
		}
		array = PlayerGlobals.KeysOfPhotoPosition();
		foreach (int num3 in array)
		{
			playerSaveData.photoPosition.Add(num3, PlayerGlobals.GetPhotoPosition(num3));
		}
		array = PlayerGlobals.KeysOfPhotoRotation();
		foreach (int num4 in array)
		{
			playerSaveData.photoRotation.Add(num4, PlayerGlobals.GetPhotoRotation(num4));
		}
		playerSaveData.reputation = PlayerGlobals.Reputation;
		playerSaveData.seduction = PlayerGlobals.Seduction;
		playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
		array = PlayerGlobals.KeysOfSenpaiPhoto();
		foreach (int num5 in array)
		{
			if (PlayerGlobals.GetSenpaiPhoto(num5))
			{
				playerSaveData.senpaiPhoto.Add(num5);
			}
		}
		playerSaveData.senpaiShots = PlayerGlobals.SenpaiShots;
		playerSaveData.socialBonus = PlayerGlobals.SocialBonus;
		playerSaveData.speedBonus = PlayerGlobals.SpeedBonus;
		playerSaveData.stealthBonus = PlayerGlobals.StealthBonus;
		array = PlayerGlobals.KeysOfStudentFriend();
		foreach (int num6 in array)
		{
			if (PlayerGlobals.GetStudentFriend(num6))
			{
				playerSaveData.studentFriend.Add(num6);
			}
		}
		array = PlayerGlobals.KeysOfStudentPantyShot();
		foreach (int num7 in array)
		{
			if (PlayerGlobals.GetStudentPantyShot(num7))
			{
				playerSaveData.studentPantyShot.Add(num7);
			}
		}
		return playerSaveData;
	}

	public static void WriteToGlobals(PlayerSaveData data)
	{
		PlayerGlobals.Alerts = data.alerts;
		PlayerGlobals.Enlightenment = data.enlightenment;
		PlayerGlobals.EnlightenmentBonus = data.enlightenmentBonus;
		PlayerGlobals.Headset = data.headset;
		PlayerGlobals.Kills = data.kills;
		PlayerGlobals.Numbness = data.numbness;
		PlayerGlobals.NumbnessBonus = data.numbnessBonus;
		PlayerGlobals.PantiesEquipped = data.pantiesEquipped;
		PlayerGlobals.PantyShots = data.pantyShots;
		Debug.Log("Is this being called anywhere?");
		foreach (int item in data.photo)
		{
			PlayerGlobals.SetPhoto(item, true);
		}
		foreach (int item2 in data.photoOnCorkboard)
		{
			PlayerGlobals.SetPhotoOnCorkboard(item2, true);
		}
		foreach (KeyValuePair<int, Vector2> item3 in data.photoPosition)
		{
			PlayerGlobals.SetPhotoPosition(item3.Key, item3.Value);
		}
		foreach (KeyValuePair<int, float> item4 in data.photoRotation)
		{
			PlayerGlobals.SetPhotoRotation(item4.Key, item4.Value);
		}
		PlayerGlobals.Reputation = data.reputation;
		PlayerGlobals.Seduction = data.seduction;
		PlayerGlobals.SeductionBonus = data.seductionBonus;
		foreach (int item5 in data.senpaiPhoto)
		{
			PlayerGlobals.SetSenpaiPhoto(item5, true);
		}
		PlayerGlobals.SenpaiShots = data.senpaiShots;
		PlayerGlobals.SocialBonus = data.socialBonus;
		PlayerGlobals.SpeedBonus = data.speedBonus;
		PlayerGlobals.StealthBonus = data.stealthBonus;
		foreach (int item6 in data.studentFriend)
		{
			PlayerGlobals.SetStudentFriend(item6, true);
		}
		foreach (int item7 in data.studentPantyShot)
		{
			PlayerGlobals.SetStudentPantyShot(item7, true);
		}
	}
}
