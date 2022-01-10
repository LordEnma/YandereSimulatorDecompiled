using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002152 RID: 8530 RVA: 0x001E7774 File Offset: 0x001E5974
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x0400490C RID: 18700
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x0400490D RID: 18701
		public string LastName;

		// Token: 0x0400490E RID: 18702
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x0400490F RID: 18703
		public string Tag = "XXXX";

		// Token: 0x04004910 RID: 18704
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
