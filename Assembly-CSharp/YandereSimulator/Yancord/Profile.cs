using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052B RID: 1323
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x060021BE RID: 8638 RVA: 0x001F1FA8 File Offset: 0x001F01A8
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004A41 RID: 19009
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004A42 RID: 19010
		public string LastName;

		// Token: 0x04004A43 RID: 19011
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004A44 RID: 19012
		public string Tag = "XXXX";

		// Token: 0x04004A45 RID: 19013
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
