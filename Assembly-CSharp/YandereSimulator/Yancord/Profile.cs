using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x0600219B RID: 8603 RVA: 0x001EE444 File Offset: 0x001EC644
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040049EE RID: 18926
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040049EF RID: 18927
		public string LastName;

		// Token: 0x040049F0 RID: 18928
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040049F1 RID: 18929
		public string Tag = "XXXX";

		// Token: 0x040049F2 RID: 18930
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
