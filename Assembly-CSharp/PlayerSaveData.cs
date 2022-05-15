using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000407 RID: 1031
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C46 RID: 7238 RVA: 0x0014AB24 File Offset: 0x00148D24
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
		foreach (int num in PlayerGlobals.KeysOfPhoto())
		{
			if (PlayerGlobals.GetPhoto(num))
			{
				playerSaveData.photo.Add(num);
			}
		}
		foreach (int num2 in PlayerGlobals.KeysOfPhotoOnCorkboard())
		{
			if (PlayerGlobals.GetPhotoOnCorkboard(num2))
			{
				playerSaveData.photoOnCorkboard.Add(num2);
			}
		}
		foreach (int num3 in PlayerGlobals.KeysOfPhotoPosition())
		{
			playerSaveData.photoPosition.Add(num3, PlayerGlobals.GetPhotoPosition(num3));
		}
		foreach (int num4 in PlayerGlobals.KeysOfPhotoRotation())
		{
			playerSaveData.photoRotation.Add(num4, PlayerGlobals.GetPhotoRotation(num4));
		}
		playerSaveData.reputation = PlayerGlobals.Reputation;
		playerSaveData.seduction = PlayerGlobals.Seduction;
		playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
		foreach (int num5 in PlayerGlobals.KeysOfSenpaiPhoto())
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
		foreach (int num6 in PlayerGlobals.KeysOfStudentFriend())
		{
			if (PlayerGlobals.GetStudentFriend(num6))
			{
				playerSaveData.studentFriend.Add(num6);
			}
		}
		foreach (int num7 in PlayerGlobals.KeysOfStudentPantyShot())
		{
			if (PlayerGlobals.GetStudentPantyShot(num7))
			{
				playerSaveData.studentPantyShot.Add(num7);
			}
		}
		return playerSaveData;
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x0014AD30 File Offset: 0x00148F30
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
		foreach (int photoID in data.photo)
		{
			PlayerGlobals.SetPhoto(photoID, true);
		}
		foreach (int photoID2 in data.photoOnCorkboard)
		{
			PlayerGlobals.SetPhotoOnCorkboard(photoID2, true);
		}
		foreach (KeyValuePair<int, Vector2> keyValuePair in data.photoPosition)
		{
			PlayerGlobals.SetPhotoPosition(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (KeyValuePair<int, float> keyValuePair2 in data.photoRotation)
		{
			PlayerGlobals.SetPhotoRotation(keyValuePair2.Key, keyValuePair2.Value);
		}
		PlayerGlobals.Reputation = data.reputation;
		PlayerGlobals.Seduction = data.seduction;
		PlayerGlobals.SeductionBonus = data.seductionBonus;
		foreach (int photoID3 in data.senpaiPhoto)
		{
			PlayerGlobals.SetSenpaiPhoto(photoID3, true);
		}
		PlayerGlobals.SenpaiShots = data.senpaiShots;
		PlayerGlobals.SocialBonus = data.socialBonus;
		PlayerGlobals.SpeedBonus = data.speedBonus;
		PlayerGlobals.StealthBonus = data.stealthBonus;
		foreach (int studentID in data.studentFriend)
		{
			PlayerGlobals.SetStudentFriend(studentID, true);
		}
		foreach (int studentID2 in data.studentPantyShot)
		{
			PlayerGlobals.SetStudentPantyShot(studentID2, true);
		}
	}

	// Token: 0x040031DA RID: 12762
	public int alerts;

	// Token: 0x040031DB RID: 12763
	public int enlightenment;

	// Token: 0x040031DC RID: 12764
	public int enlightenmentBonus;

	// Token: 0x040031DD RID: 12765
	public bool headset;

	// Token: 0x040031DE RID: 12766
	public int kills;

	// Token: 0x040031DF RID: 12767
	public int numbness;

	// Token: 0x040031E0 RID: 12768
	public int numbnessBonus;

	// Token: 0x040031E1 RID: 12769
	public int pantiesEquipped;

	// Token: 0x040031E2 RID: 12770
	public int pantyShots;

	// Token: 0x040031E3 RID: 12771
	public IntHashSet photo = new IntHashSet();

	// Token: 0x040031E4 RID: 12772
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x040031E5 RID: 12773
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x040031E6 RID: 12774
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x040031E7 RID: 12775
	public float reputation;

	// Token: 0x040031E8 RID: 12776
	public int seduction;

	// Token: 0x040031E9 RID: 12777
	public int seductionBonus;

	// Token: 0x040031EA RID: 12778
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x040031EB RID: 12779
	public int senpaiShots;

	// Token: 0x040031EC RID: 12780
	public int socialBonus;

	// Token: 0x040031ED RID: 12781
	public int speedBonus;

	// Token: 0x040031EE RID: 12782
	public int stealthBonus;

	// Token: 0x040031EF RID: 12783
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x040031F0 RID: 12784
	public IntHashSet studentPantyShot = new IntHashSet();
}
