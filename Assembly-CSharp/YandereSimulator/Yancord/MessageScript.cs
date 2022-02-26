using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x0600216A RID: 8554 RVA: 0x001EA1EC File Offset: 0x001E83EC
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x04004932 RID: 18738
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004933 RID: 18739
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004934 RID: 18740
		public UILabel MessageLabel;

		// Token: 0x04004935 RID: 18741
		public UITexture ProfilPictureTexture;
	}
}
