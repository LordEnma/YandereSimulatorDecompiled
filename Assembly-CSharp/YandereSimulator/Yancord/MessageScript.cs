using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051D RID: 1309
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002170 RID: 8560 RVA: 0x001EABC4 File Offset: 0x001E8DC4
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

		// Token: 0x0400494F RID: 18767
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004950 RID: 18768
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004951 RID: 18769
		public UILabel MessageLabel;

		// Token: 0x04004952 RID: 18770
		public UITexture ProfilPictureTexture;
	}
}
