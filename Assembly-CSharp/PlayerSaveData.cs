using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000401 RID: 1025
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C25 RID: 7205 RVA: 0x001484B8 File Offset: 0x001466B8
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

	// Token: 0x06001C26 RID: 7206 RVA: 0x001486C4 File Offset: 0x001468C4
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

	// Token: 0x0400318F RID: 12687
	public int alerts;

	// Token: 0x04003190 RID: 12688
	public int enlightenment;

	// Token: 0x04003191 RID: 12689
	public int enlightenmentBonus;

	// Token: 0x04003192 RID: 12690
	public bool headset;

	// Token: 0x04003193 RID: 12691
	public int kills;

	// Token: 0x04003194 RID: 12692
	public int numbness;

	// Token: 0x04003195 RID: 12693
	public int numbnessBonus;

	// Token: 0x04003196 RID: 12694
	public int pantiesEquipped;

	// Token: 0x04003197 RID: 12695
	public int pantyShots;

	// Token: 0x04003198 RID: 12696
	public IntHashSet photo = new IntHashSet();

	// Token: 0x04003199 RID: 12697
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x0400319A RID: 12698
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x0400319B RID: 12699
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x0400319C RID: 12700
	public float reputation;

	// Token: 0x0400319D RID: 12701
	public int seduction;

	// Token: 0x0400319E RID: 12702
	public int seductionBonus;

	// Token: 0x0400319F RID: 12703
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x040031A0 RID: 12704
	public int senpaiShots;

	// Token: 0x040031A1 RID: 12705
	public int socialBonus;

	// Token: 0x040031A2 RID: 12706
	public int speedBonus;

	// Token: 0x040031A3 RID: 12707
	public int stealthBonus;

	// Token: 0x040031A4 RID: 12708
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x040031A5 RID: 12709
	public IntHashSet studentPantyShot = new IntHashSet();
}
