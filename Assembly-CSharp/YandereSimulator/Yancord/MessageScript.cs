using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x0600215A RID: 8538 RVA: 0x001E9158 File Offset: 0x001E7358
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

		// Token: 0x04004919 RID: 18713
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400491A RID: 18714
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400491B RID: 18715
		public UILabel MessageLabel;

		// Token: 0x0400491C RID: 18716
		public UITexture ProfilPictureTexture;
	}
}
