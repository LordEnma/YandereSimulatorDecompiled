using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002157 RID: 8535 RVA: 0x001E8F54 File Offset: 0x001E7154
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

		// Token: 0x04004916 RID: 18710
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004917 RID: 18711
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004918 RID: 18712
		public UILabel MessageLabel;

		// Token: 0x04004919 RID: 18713
		public UITexture ProfilPictureTexture;
	}
}
