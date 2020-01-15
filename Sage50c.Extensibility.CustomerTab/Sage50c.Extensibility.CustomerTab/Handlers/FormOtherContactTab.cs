﻿using S50cBL18;
using S50cBO18;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sage50c.Extensibility.CustomerTab.Handlers {
    public partial class FormOtherContactTab : Form, IChildPanel {

        public FormOtherContactTab() {
            InitializeComponent();
        }

        public void SetSize(float Width, float Height) {
            try {
                // Traduzir para pixels
                int tabWidth = (int)(Width / 16);
                int tabHeight = (int)(Height / 16);

                this.SetBounds(0, 0, tabWidth, tabHeight);

                //this.Visible = true;
                //this.BringToFront();
            }
            catch { }
        }

        public void ResetInterface() {
            lblOtherContact.Text = string.Empty;
        }

        public void SetFocus() {
            try {
                this.SetFocus();
            }
            catch { }
        }

        public bool OnMenuItem(string MenuItemID) {
            return false;
        }

        public void OnLoad(OtherContact value) {

            if (value != null) {
                lblOtherContact.Text = value.Name;
            }
        }

        public bool CheckIDValue(string value) {
            return true;
        }

        public void SetBackcolor(int value) {
            this.BackColor = System.Drawing.Color.FromArgb(value);
        }

        public bool BeforeOk() {
            return true;
        }

        public bool BeforeCancel() {
            return true;
        }

        public int Handler => this.Handle.ToInt32();

        public stdole.StdPicture Picture {
            get {
                return null;
                //return (stdole.StdPicture)ImageConverter.GetIPictureDispFromImage(Icon.ToBitmap());
            }
        }
        public string Title => "Custom panel";

        public string Description => "Custom panel long description";

        private void btnOk_Click(object sender, EventArgs e) {
            MessageBox.Show("Hello!");
        }

    }
}
