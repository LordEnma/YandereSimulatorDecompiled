using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002155 RID: 8533 RVA: 0x001E8C3C File Offset: 0x001E6E3C
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

		// Token: 0x04004910 RID: 18704
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004911 RID: 18705
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004912 RID: 18706
		public UILabel MessageLabel;

		// Token: 0x04004913 RID: 18707
		public UITexture ProfilPictureTexture;
	}
}
