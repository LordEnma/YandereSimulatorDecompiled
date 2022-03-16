using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000523 RID: 1315
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x0600218B RID: 8587 RVA: 0x001ECBD4 File Offset: 0x001EADD4
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x040049BC RID: 18876
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x040049BD RID: 18877
		public string LastName;

		// Token: 0x040049BE RID: 18878
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x040049BF RID: 18879
		public string Tag = "XXXX";

		// Token: 0x040049C0 RID: 18880
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
