using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003FB RID: 1019
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x00143E08 File Offset: 0x00142008
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

	// Token: 0x06001BF9 RID: 7161 RVA: 0x00144014 File Offset: 0x00142214
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

	// Token: 0x04003113 RID: 12563
	public int alerts;

	// Token: 0x04003114 RID: 12564
	public int enlightenment;

	// Token: 0x04003115 RID: 12565
	public int enlightenmentBonus;

	// Token: 0x04003116 RID: 12566
	public bool headset;

	// Token: 0x04003117 RID: 12567
	public int kills;

	// Token: 0x04003118 RID: 12568
	public int numbness;

	// Token: 0x04003119 RID: 12569
	public int numbnessBonus;

	// Token: 0x0400311A RID: 12570
	public int pantiesEquipped;

	// Token: 0x0400311B RID: 12571
	public int pantyShots;

	// Token: 0x0400311C RID: 12572
	public IntHashSet photo = new IntHashSet();

	// Token: 0x0400311D RID: 12573
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x0400311E RID: 12574
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x0400311F RID: 12575
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x04003120 RID: 12576
	public float reputation;

	// Token: 0x04003121 RID: 12577
	public int seduction;

	// Token: 0x04003122 RID: 12578
	public int seductionBonus;

	// Token: 0x04003123 RID: 12579
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x04003124 RID: 12580
	public int senpaiShots;

	// Token: 0x04003125 RID: 12581
	public int socialBonus;

	// Token: 0x04003126 RID: 12582
	public int speedBonus;

	// Token: 0x04003127 RID: 12583
	public int stealthBonus;

	// Token: 0x04003128 RID: 12584
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x04003129 RID: 12585
	public IntHashSet studentPantyShot = new IntHashSet();
}
