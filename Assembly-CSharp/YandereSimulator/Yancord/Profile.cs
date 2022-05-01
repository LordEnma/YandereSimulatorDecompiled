using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052A RID: 1322
	[CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
	public class Profile : ScriptableObject
	{
		// Token: 0x060021B3 RID: 8627 RVA: 0x001F085C File Offset: 0x001EEA5C
		public string GetTag(bool WithHashtag)
		{
			string text = this.Tag;
			if (text.Length > 4)
			{
				text = text.Substring(0, 4);
			}
			return WithHashtag ? ("#" + text) : text;
		}

		// Token: 0x04004A1A RID: 18970
		[Header("Personal Information")]
		public string FirstName;

		// Token: 0x04004A1B RID: 18971
		public string LastName;

		// Token: 0x04004A1C RID: 18972
		[Space(20f)]
		[Header("Profile Information")]
		public Texture2D ProfilePicture;

		// Token: 0x04004A1D RID: 18973
		public string Tag = "XXXX";

		// Token: 0x04004A1E RID: 18974
		[Space(20f)]
		[Header("Profile Settings")]
		public Status CurrentStatus;
	}
}
