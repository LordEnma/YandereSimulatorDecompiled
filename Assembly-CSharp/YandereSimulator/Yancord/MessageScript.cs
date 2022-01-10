using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x0600214F RID: 8527 RVA: 0x001E76CC File Offset: 0x001E58CC
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

		// Token: 0x040048FE RID: 18686
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048FF RID: 18687
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004900 RID: 18688
		public UILabel MessageLabel;

		// Token: 0x04004901 RID: 18689
		public UITexture ProfilPictureTexture;
	}
}
