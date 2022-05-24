using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052B RID: 1323
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x060021BF RID: 8639 RVA: 0x001F2510 File Offset: 0x001F0710
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004A4A RID: 19018
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004A4B RID: 19019
		public string LastName;

		// Token: 0x04004A4C RID: 19020
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004A4D RID: 19021
		public string Tag = "XXXX";

		// Token: 0x04004A4E RID: 19022
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
