using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000400 RID: 1024
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C16 RID: 7190 RVA: 0x001470D8 File Offset: 0x001452D8
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

	// Token: 0x06001C17 RID: 7191 RVA: 0x001472E4 File Offset: 0x001454E4
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

	// Token: 0x04003145 RID: 12613
	public int alerts;

	// Token: 0x04003146 RID: 12614
	public int enlightenment;

	// Token: 0x04003147 RID: 12615
	public int enlightenmentBonus;

	// Token: 0x04003148 RID: 12616
	public bool headset;

	// Token: 0x04003149 RID: 12617
	public int kills;

	// Token: 0x0400314A RID: 12618
	public int numbness;

	// Token: 0x0400314B RID: 12619
	public int numbnessBonus;

	// Token: 0x0400314C RID: 12620
	public int pantiesEquipped;

	// Token: 0x0400314D RID: 12621
	public int pantyShots;

	// Token: 0x0400314E RID: 12622
	public IntHashSet photo = new IntHashSet();

	// Token: 0x0400314F RID: 12623
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x04003150 RID: 12624
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x04003151 RID: 12625
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x04003152 RID: 12626
	public float reputation;

	// Token: 0x04003153 RID: 12627
	public int seduction;

	// Token: 0x04003154 RID: 12628
	public int seductionBonus;

	// Token: 0x04003155 RID: 12629
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x04003156 RID: 12630
	public int senpaiShots;

	// Token: 0x04003157 RID: 12631
	public int socialBonus;

	// Token: 0x04003158 RID: 12632
	public int speedBonus;

	// Token: 0x04003159 RID: 12633
	public int stealthBonus;

	// Token: 0x0400315A RID: 12634
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x0400315B RID: 12635
	public IntHashSet studentPantyShot = new IntHashSet();
}
