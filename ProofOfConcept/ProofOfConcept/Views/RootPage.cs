﻿using Xamarin.Forms;

namespace ProofOfConcept.Views {
	public partial class RootPage : MasterDetailPage {
		public RootPage() {
			InitializeComponent();
			MasterBehavior = MasterBehavior.Popover;
		}
	}
}

