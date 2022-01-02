using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002147 RID: 8519 RVA: 0x001E6DD4 File Offset: 0x001E4FD4
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040048F8 RID: 18680
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040048F9 RID: 18681
		public string LastName;

		// Token: 0x040048FA RID: 18682
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040048FB RID: 18683
		public string Tag = "XXXX";

		// Token: 0x040048FC RID: 18684
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
