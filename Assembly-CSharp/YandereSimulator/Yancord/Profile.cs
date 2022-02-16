using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051D RID: 1309
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002164 RID: 8548 RVA: 0x001E96B4 File Offset: 0x001E78B4
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004930 RID: 18736
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004931 RID: 18737
		public string LastName;

		// Token: 0x04004932 RID: 18738
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004933 RID: 18739
		public string Tag = "XXXX";

		// Token: 0x04004934 RID: 18740
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
