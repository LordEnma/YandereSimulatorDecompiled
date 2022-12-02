using UnityEngine;

namespace YandereSimulator.Yancord
{
	public static class PlayerPrefsHelper
	{
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		public static bool GetBool(string name)
		{
			if (PlayerPrefs.GetInt(name) != 1)
			{
				return false;
			}
			return true;
		}
	}
}
