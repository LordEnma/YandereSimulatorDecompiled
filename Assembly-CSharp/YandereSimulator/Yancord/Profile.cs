using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x0600215A RID: 8538 RVA: 0x001E8FFC File Offset: 0x001E71FC
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004924 RID: 18724
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004925 RID: 18725
		public string LastName;

		// Token: 0x04004926 RID: 18726
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004927 RID: 18727
		public string Tag = "XXXX";

		// Token: 0x04004928 RID: 18728
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
