using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000406 RID: 1030
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C40 RID: 7232 RVA: 0x00149EA4 File Offset: 0x001480A4
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

	// Token: 0x06001C41 RID: 7233 RVA: 0x0014A0B0 File Offset: 0x001482B0
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

	// Token: 0x040031C5 RID: 12741
	public int alerts;

	// Token: 0x040031C6 RID: 12742
	public int enlightenment;

	// Token: 0x040031C7 RID: 12743
	public int enlightenmentBonus;

	// Token: 0x040031C8 RID: 12744
	public bool headset;

	// Token: 0x040031C9 RID: 12745
	public int kills;

	// Token: 0x040031CA RID: 12746
	public int numbness;

	// Token: 0x040031CB RID: 12747
	public int numbnessBonus;

	// Token: 0x040031CC RID: 12748
	public int pantiesEquipped;

	// Token: 0x040031CD RID: 12749
	public int pantyShots;

	// Token: 0x040031CE RID: 12750
	public IntHashSet photo = new IntHashSet();

	// Token: 0x040031CF RID: 12751
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x040031D0 RID: 12752
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x040031D1 RID: 12753
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x040031D2 RID: 12754
	public float reputation;

	// Token: 0x040031D3 RID: 12755
	public int seduction;

	// Token: 0x040031D4 RID: 12756
	public int seductionBonus;

	// Token: 0x040031D5 RID: 12757
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x040031D6 RID: 12758
	public int senpaiShots;

	// Token: 0x040031D7 RID: 12759
	public int socialBonus;

	// Token: 0x040031D8 RID: 12760
	public int speedBonus;

	// Token: 0x040031D9 RID: 12761
	public int stealthBonus;

	// Token: 0x040031DA RID: 12762
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x040031DB RID: 12763
	public IntHashSet studentPantyShot = new IntHashSet();
}
