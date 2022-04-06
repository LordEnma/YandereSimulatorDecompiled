using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000529 RID: 1321
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x060021A3 RID: 8611 RVA: 0x001EE974 File Offset: 0x001ECB74
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040049F2 RID: 18930
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040049F3 RID: 18931
		public string LastName;

		// Token: 0x040049F4 RID: 18932
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040049F5 RID: 18933
		public string Tag = "XXXX";

		// Token: 0x040049F6 RID: 18934
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
