using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051E RID: 1310
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x0600216D RID: 8557 RVA: 0x001EA294 File Offset: 0x001E8494
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004940 RID: 18752
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004941 RID: 18753
		public string LastName;

		// Token: 0x04004942 RID: 18754
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004943 RID: 18755
		public string Tag = "XXXX";

		// Token: 0x04004944 RID: 18756
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
