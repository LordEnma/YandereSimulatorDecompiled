using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003FA RID: 1018
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001BF0 RID: 7152 RVA: 0x00143548 File Offset: 0x00141748
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

	// Token: 0x06001BF1 RID: 7153 RVA: 0x00143754 File Offset: 0x00141954
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

	// Token: 0x040030E9 RID: 12521
	public int alerts;

	// Token: 0x040030EA RID: 12522
	public int enlightenment;

	// Token: 0x040030EB RID: 12523
	public int enlightenmentBonus;

	// Token: 0x040030EC RID: 12524
	public bool headset;

	// Token: 0x040030ED RID: 12525
	public int kills;

	// Token: 0x040030EE RID: 12526
	public int numbness;

	// Token: 0x040030EF RID: 12527
	public int numbnessBonus;

	// Token: 0x040030F0 RID: 12528
	public int pantiesEquipped;

	// Token: 0x040030F1 RID: 12529
	public int pantyShots;

	// Token: 0x040030F2 RID: 12530
	public IntHashSet photo = new IntHashSet();

	// Token: 0x040030F3 RID: 12531
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x040030F4 RID: 12532
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x040030F5 RID: 12533
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x040030F6 RID: 12534
	public float reputation;

	// Token: 0x040030F7 RID: 12535
	public int seduction;

	// Token: 0x040030F8 RID: 12536
	public int seductionBonus;

	// Token: 0x040030F9 RID: 12537
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x040030FA RID: 12538
	public int senpaiShots;

	// Token: 0x040030FB RID: 12539
	public int socialBonus;

	// Token: 0x040030FC RID: 12540
	public int speedBonus;

	// Token: 0x040030FD RID: 12541
	public int stealthBonus;

	// Token: 0x040030FE RID: 12542
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x040030FF RID: 12543
	public IntHashSet studentPantyShot = new IntHashSet();
}
