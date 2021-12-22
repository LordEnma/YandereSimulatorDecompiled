using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x06002144 RID: 8516 RVA: 0x001E67E4 File Offset: 0x001E49E4
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040048EF RID: 18671
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040048F0 RID: 18672
		public string LastName;

		// Token: 0x040048F1 RID: 18673
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040048F2 RID: 18674
		public string Tag = "XXXX";

		// Token: 0x040048F3 RID: 18675
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
