using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000400 RID: 1024
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C18 RID: 7192 RVA: 0x00147614 File Offset: 0x00145814
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

	// Token: 0x06001C19 RID: 7193 RVA: 0x00147820 File Offset: 0x00145A20
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

	// Token: 0x0400315B RID: 12635
	public int alerts;

	// Token: 0x0400315C RID: 12636
	public int enlightenment;

	// Token: 0x0400315D RID: 12637
	public int enlightenmentBonus;

	// Token: 0x0400315E RID: 12638
	public bool headset;

	// Token: 0x0400315F RID: 12639
	public int kills;

	// Token: 0x04003160 RID: 12640
	public int numbness;

	// Token: 0x04003161 RID: 12641
	public int numbnessBonus;

	// Token: 0x04003162 RID: 12642
	public int pantiesEquipped;

	// Token: 0x04003163 RID: 12643
	public int pantyShots;

	// Token: 0x04003164 RID: 12644
	public IntHashSet photo = new IntHashSet();

	// Token: 0x04003165 RID: 12645
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x04003166 RID: 12646
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x04003167 RID: 12647
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x04003168 RID: 12648
	public float reputation;

	// Token: 0x04003169 RID: 12649
	public int seduction;

	// Token: 0x0400316A RID: 12650
	public int seductionBonus;

	// Token: 0x0400316B RID: 12651
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x0400316C RID: 12652
	public int senpaiShots;

	// Token: 0x0400316D RID: 12653
	public int socialBonus;

	// Token: 0x0400316E RID: 12654
	public int speedBonus;

	// Token: 0x0400316F RID: 12655
	public int stealthBonus;

	// Token: 0x04003170 RID: 12656
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x04003171 RID: 12657
	public IntHashSet studentPantyShot = new IntHashSet();
}
