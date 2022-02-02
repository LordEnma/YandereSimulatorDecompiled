using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002158 RID: 8536 RVA: 0x001E8CE4 File Offset: 0x001E6EE4
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x0400491E RID: 18718
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x0400491F RID: 18719
		public string LastName;

		// Token: 0x04004920 RID: 18720
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004921 RID: 18721
		public string Tag = "XXXX";

		// Token: 0x04004922 RID: 18722
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
