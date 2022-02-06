using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x0600215D RID: 8541 RVA: 0x001E9200 File Offset: 0x001E7400
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004927 RID: 18727
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004928 RID: 18728
		public string LastName;

		// Token: 0x04004929 RID: 18729
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x0400492A RID: 18730
		public string Tag = "XXXX";

		// Token: 0x0400492B RID: 18731
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
