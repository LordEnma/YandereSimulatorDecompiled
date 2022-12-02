using UnityEngine;

namespace YandereSimulator.Yancord
{
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		[Header("Personal Information")]
		public string FirstName;

		public string LastName;

		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		public string Tag = "XXXX";

		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;

		public string GetTag(bool WithHashtag)
		{
			string text = Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}
	}
}
