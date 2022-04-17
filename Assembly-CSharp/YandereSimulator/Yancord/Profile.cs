using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000529 RID: 1321
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x060021AA RID: 8618 RVA: 0x001EF3D0 File Offset: 0x001ED5D0
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004A04 RID: 18948
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004A05 RID: 18949
		public string LastName;

		// Token: 0x04004A06 RID: 18950
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004A07 RID: 18951
		public string Tag = "XXXX";

		// Token: 0x04004A08 RID: 18952
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
