using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051F RID: 1311
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002173 RID: 8563 RVA: 0x001EAC6C File Offset: 0x001E8E6C
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x0400495D RID: 18781
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x0400495E RID: 18782
		public string LastName;

		// Token: 0x0400495F RID: 18783
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004960 RID: 18784
		public string Tag = "XXXX";

		// Token: 0x04004961 RID: 18785
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
