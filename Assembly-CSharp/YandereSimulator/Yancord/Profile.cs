using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002154 RID: 8532 RVA: 0x001E8444 File Offset: 0x001E6644
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004913 RID: 18707
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004914 RID: 18708
		public string LastName;

		// Token: 0x04004915 RID: 18709
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004916 RID: 18710
		public string Tag = "XXXX";

		// Token: 0x04004917 RID: 18711
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
