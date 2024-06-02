using UnityEngine;

public static class PlayerGlobals
{
	private const string Str_Money = "Money";

	private const string Str_Alerts = "Alerts";

	private const string Str_Alarms = "Alarms";

	private const string Str_BullyPhoto = "BullyPhoto_";

	private const string Str_Enlightenment = "Enlightenment";

	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	private const string Str_Friends = "Friends";

	private const string Str_Headset = "Headset";

	private const string Str_DirectionalMic = "DirectionalMic";

	private const string Str_FakeID = "FakeID";

	private const string Str_RaibaruLoner = "RaibaruLoner";

	private const string Str_Kills = "Kills";

	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	private const string Str_Numbness = "Numbness";

	private const string Str_NumbnessBonus = "NumbnessBonus";

	private const string Str_PantiesEquipped = "PantiesEquipped";

	private const string Str_PantyShots = "PantyShots";

	private const string Str_Photo = "Photo_";

	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	private const string Str_PhotoPosition = "PhotoPosition_";

	private const string Str_PhotoRotation = "PhotoRotation_";

	private const string Str_Reputation = "Reputation";

	private const string Str_Seduction = "Seduction";

	private const string Str_SeductionBonus = "SeductionBonus";

	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	private const string Str_SenpaiShots = "SenpaiShots";

	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	private const string Str_SocialBonus = "SocialBonus";

	private const string Str_SpeedBonus = "SpeedBonus";

	private const string Str_StealthBonus = "StealthBonus";

	private const string Str_StudentFriend = "StudentFriend_";

	private const string Str_StudentPantyShot = "StudentPantyShot_";

	private const string Str_StudentSentHome = "StudentSentHome_";

	private const string Str_ShrineCollectible = "ShrineCollectible_";

	private const string Str_UsingGamepad = "UsingGamepad";

	private const string Str_PersonaID = "PersonaID";

	private const string Str_ShrineItems = "ShrineItems";

	private const string Str_BringingItem = "BringingItem";

	private const string Str_CannotBringItem = "CannotBringItem";

	private const string Str_BoughtLockpick = "BoughtLockpick";

	private const string Str_BoughtSedative = "BoughtSedative";

	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	private const string Str_BoughtPoison = "BoughtPoison";

	private const string Str_BoughtExplosive = "BoughtExplosive";

	private const string Str_PoliceVisits = "PoliceVisits";

	private const string Str_BloodWitnessed = "BloodWitnessed";

	private const string Str_WeaponWitnessed = "WeaponWitnessed";

	private const string Str_Meals = "Meals";

	public static float Money
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_Money");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_Money", value);
		}
	}

	public static int Alarms
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Alarms");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Alarms", value);
		}
	}

	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Alerts", value);
		}
	}

	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Enlightenment", value);
		}
	}

	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus", value);
		}
	}

	public static int Friends
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Friends");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Friends", value);
		}
	}

	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Headset", value);
		}
	}

	public static bool DirectionalMic
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_DirectionalMic");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_DirectionalMic", value);
		}
	}

	public static bool FakeID
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_FakeID");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_FakeID", value);
		}
	}

	public static bool RaibaruLoner
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_RaibaruLoner");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_RaibaruLoner", value);
		}
	}

	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Kills", value);
		}
	}

	public static int CorpsesDiscovered
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CorpsesDiscovered");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CorpsesDiscovered", value);
		}
	}

	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Numbness", value);
		}
	}

	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_NumbnessBonus", value);
		}
	}

	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PantiesEquipped", value);
		}
	}

	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PantyShots", value);
		}
	}

	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_Reputation", value);
		}
	}

	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Seduction", value);
		}
	}

	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SeductionBonus", value);
		}
	}

	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiShots", value);
		}
	}

	public static int SenpaiShotsTexted
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiShotsTexted");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiShotsTexted", value);
		}
	}

	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SocialBonus", value);
		}
	}

	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SpeedBonus", value);
		}
	}

	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_StealthBonus", value);
		}
	}

	public static bool UsingGamepad
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_UsingGamepad");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_UsingGamepad", value);
		}
	}

	public static int PersonaID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PersonaID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PersonaID", value);
		}
	}

	public static int ShrineItems
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_ShrineItems");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_ShrineItems", value);
		}
	}

	public static int BringingItem
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BringingItem");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BringingItem", value);
		}
	}

	public static bool BoughtLockpick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BoughtLockpick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BoughtLockpick", value);
		}
	}

	public static bool BoughtSedative
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BoughtSedative");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BoughtSedative", value);
		}
	}

	public static bool BoughtNarcotics
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BoughtNarcotics");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BoughtNarcotics", value);
		}
	}

	public static bool BoughtPoison
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BoughtPoison");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BoughtPoison", value);
		}
	}

	public static bool BoughtExplosive
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BoughtExplosive");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BoughtExplosive", value);
		}
	}

	public static int PoliceVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PoliceVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PoliceVisits", value);
		}
	}

	public static int BloodWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BloodWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BloodWitnessed", value);
		}
	}

	public static int WeaponWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponWitnessed", value);
		}
	}

	public static int Meals
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Meals");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Meals", value);
		}
	}

	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Photo_" + photoID);
	}

	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Photo_" + text, value);
	}

	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_Photo_");
	}

	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_" + photoID);
	}

	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_" + text, value);
	}

	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_");
	}

	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile + "_PhotoPosition_" + photoID);
	}

	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile + "_PhotoPosition_" + text, value);
	}

	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoPosition_");
	}

	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_PhotoRotation_" + photoID);
	}

	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_PhotoRotation_" + text, value);
	}

	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoRotation_");
	}

	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_" + photoID);
	}

	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_" + text, value);
	}

	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BullyPhoto_" + photoID);
	}

	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BullyPhoto_" + text, value);
	}

	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_BullyPhoto_");
	}

	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_");
	}

	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_StudentFriend_" + studentID);
	}

	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_StudentFriend_" + text, value);
	}

	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_StudentFriend_");
	}

	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_StudentPantyShot_" + studentID);
	}

	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_StudentPantyShot_" + text, value);
	}

	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_StudentPantyShot_");
	}

	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile + "_ShrineCollectible_");
	}

	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ShrineCollectible_" + ID);
	}

	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ShrineCollectible_" + text, value);
	}

	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile + "_CannotBringItem");
	}

	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_CannotBringItem" + ID);
	}

	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_CannotBringItem" + text, value);
	}

	public static bool GetStudentSentHome(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_StudentSentHome_" + studentID);
	}

	public static void SetStudentSentHome(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_StudentSentHome_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_StudentSentHome_" + text, value);
	}

	public static int[] KeysOfStudentSentHome()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_StudentSentHome_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Money");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Alerts");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Alarms");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Enlightenment");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Friends");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Headset");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DirectionalMic");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_FakeID");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RaibaruLoner");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Kills");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CorpsesDiscovered");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Numbness");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NumbnessBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PantiesEquipped");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PantyShots");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_Photo_", KeysOfPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_", KeysOfPhotoOnCorkboard());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoPosition_", KeysOfPhotoPosition());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoRotation_", KeysOfPhotoRotation());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Reputation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Seduction");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SeductionBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiShots");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiShotsTexted");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SocialBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SpeedBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_StealthBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PersonaID");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ShrineItems");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_BullyPhoto_", KeysOfBullyPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_", KeysOfSenpaiPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_StudentFriend_", KeysOfStudentFriend());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_StudentPantyShot_", KeysOfStudentPantyShot());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_StudentSentHome_", KeysOfStudentSentHome());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_ShrineCollectible_", KeysOfShrineCollectible());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BringingItem");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_CannotBringItem", KeysOfCannotBringItem());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BoughtLockpick");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BoughtSedative");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BoughtNarcotics");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BoughtPoison");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BoughtExplosive");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PoliceVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BloodWitnessed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponWitnessed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Meals");
	}
}
