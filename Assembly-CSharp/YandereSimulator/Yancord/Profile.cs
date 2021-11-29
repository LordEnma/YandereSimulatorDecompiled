using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000517 RID: 1303
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002133 RID: 8499 RVA: 0x001E50B0 File Offset: 0x001E32B0
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040048B0 RID: 18608
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040048B1 RID: 18609
		public string LastName;

		// Token: 0x040048B2 RID: 18610
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040048B3 RID: 18611
		public string Tag = "XXXX";

		// Token: 0x040048B4 RID: 18612
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
