using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000529 RID: 1321
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x060021BC RID: 8636 RVA: 0x001F2468 File Offset: 0x001F0668
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

		// Token: 0x04004A3C RID: 19004
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A3D RID: 19005
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A3E RID: 19006
		public UILabel MessageLabel;

		// Token: 0x04004A3F RID: 19007
		public UITexture ProfilPictureTexture;
	}
}
