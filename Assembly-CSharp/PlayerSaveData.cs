using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000405 RID: 1029
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C39 RID: 7225 RVA: 0x00149668 File Offset: 0x00147868
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

	// Token: 0x06001C3A RID: 7226 RVA: 0x00149874 File Offset: 0x00147A74
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

	// Token: 0x040031B6 RID: 12726
	public int alerts;

	// Token: 0x040031B7 RID: 12727
	public int enlightenment;

	// Token: 0x040031B8 RID: 12728
	public int enlightenmentBonus;

	// Token: 0x040031B9 RID: 12729
	public bool headset;

	// Token: 0x040031BA RID: 12730
	public int kills;

	// Token: 0x040031BB RID: 12731
	public int numbness;

	// Token: 0x040031BC RID: 12732
	public int numbnessBonus;

	// Token: 0x040031BD RID: 12733
	public int pantiesEquipped;

	// Token: 0x040031BE RID: 12734
	public int pantyShots;

	// Token: 0x040031BF RID: 12735
	public IntHashSet photo = new IntHashSet();

	// Token: 0x040031C0 RID: 12736
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x040031C1 RID: 12737
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x040031C2 RID: 12738
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x040031C3 RID: 12739
	public float reputation;

	// Token: 0x040031C4 RID: 12740
	public int seduction;

	// Token: 0x040031C5 RID: 12741
	public int seductionBonus;

	// Token: 0x040031C6 RID: 12742
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x040031C7 RID: 12743
	public int senpaiShots;

	// Token: 0x040031C8 RID: 12744
	public int socialBonus;

	// Token: 0x040031C9 RID: 12745
	public int speedBonus;

	// Token: 0x040031CA RID: 12746
	public int stealthBonus;

	// Token: 0x040031CB RID: 12747
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x040031CC RID: 12748
	public IntHashSet studentPantyShot = new IntHashSet();
}
