namespace CarRentalSystem2.Views
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bFormDragDashboard = new Bunifu.UI.WinForms.BunifuFormDrag();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnExit = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnCustomer = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnInquiry = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnRentCar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnAvailableCars = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lblUser = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnHome = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuFormDrag1 = new Bunifu.UI.WinForms.BunifuFormDrag();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bFormDragDashboard
            // 
            this.bFormDragDashboard.AllowOpacityChangesWhileDragging = false;
            this.bFormDragDashboard.ContainerControl = this;
            this.bFormDragDashboard.DockIndicatorsOpacity = 0.5D;
            this.bFormDragDashboard.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.bFormDragDashboard.DockingOptions.DockAll = true;
            this.bFormDragDashboard.DockingOptions.DockBottomLeft = true;
            this.bFormDragDashboard.DockingOptions.DockBottomRight = true;
            this.bFormDragDashboard.DockingOptions.DockFullScreen = true;
            this.bFormDragDashboard.DockingOptions.DockLeft = true;
            this.bFormDragDashboard.DockingOptions.DockRight = true;
            this.bFormDragDashboard.DockingOptions.DockTopLeft = true;
            this.bFormDragDashboard.DockingOptions.DockTopRight = true;
            this.bFormDragDashboard.DragOpacity = 0.9D;
            this.bFormDragDashboard.Enabled = true;
            this.bFormDragDashboard.ParentForm = this;
            this.bFormDragDashboard.ShowCursorChanges = true;
            this.bFormDragDashboard.ShowDockingIndicators = true;
            this.bFormDragDashboard.TitleBarOptions.BunifuFormDrag = this.bFormDragDashboard;
            this.bFormDragDashboard.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.bFormDragDashboard.TitleBarOptions.Enabled = true;
            this.bFormDragDashboard.TitleBarOptions.TitleBarControl = this.bunifuPanel1;
            this.bFormDragDashboard.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            this.bFormDragDashboard.FormDragging += new System.EventHandler<Bunifu.UI.WinForms.BunifuFormDrag.FormDraggingEventArgs>(this.bFormDragDashboard_FormDragging);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.bunifuPanel1, "bunifuPanel1");
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 10;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.btnExit);
            this.bunifuPanel1.Controls.Add(this.btnCustomer);
            this.bunifuPanel1.Controls.Add(this.btnInquiry);
            this.bunifuPanel1.Controls.Add(this.btnRentCar);
            this.bunifuPanel1.Controls.Add(this.btnAvailableCars);
            this.bunifuPanel1.Controls.Add(this.lblUser);
            this.bunifuPanel1.Controls.Add(this.btnHome);
            this.bunifuPanel1.Controls.Add(this.pictureBox1);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            // 
            // btnExit
            // 
            this.btnExit.AllowAnimations = true;
            this.btnExit.AllowMouseEffects = true;
            this.btnExit.AllowToggling = false;
            this.btnExit.AnimationSpeed = 200;
            this.btnExit.AutoGenerateColors = false;
            this.btnExit.AutoRoundBorders = false;
            this.btnExit.AutoSizeLeftIcon = true;
            this.btnExit.AutoSizeRightIcon = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnExit.ButtonText = "";
            this.btnExit.ButtonTextMarginLeft = 0;
            this.btnExit.ColorContrastOnClick = 45;
            this.btnExit.ColorContrastOnHover = 45;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnExit.CustomizableEdges = borderEdges1;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnExit.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExit.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExit.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnExit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnExit.IconMarginLeft = 11;
            this.btnExit.IconPadding = 10;
            this.btnExit.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnExit.IconSize = 25;
            this.btnExit.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnExit.IdleBorderRadius = 20;
            this.btnExit.IdleBorderThickness = 2;
            this.btnExit.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnExit.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.logout;
            this.btnExit.IdleIconRightImage = null;
            this.btnExit.IndicateFocus = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnExit.OnDisabledState.BorderRadius = 20;
            this.btnExit.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnExit.OnDisabledState.BorderThickness = 2;
            this.btnExit.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExit.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExit.OnDisabledState.IconLeftImage = null;
            this.btnExit.OnDisabledState.IconRightImage = null;
            this.btnExit.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnExit.onHoverState.BorderRadius = 20;
            this.btnExit.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnExit.onHoverState.BorderThickness = 2;
            this.btnExit.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnExit.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.onHoverState.IconLeftImage = null;
            this.btnExit.onHoverState.IconRightImage = null;
            this.btnExit.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.OnIdleState.BorderRadius = 20;
            this.btnExit.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnExit.OnIdleState.BorderThickness = 2;
            this.btnExit.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnExit.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnExit.OnIdleState.IconLeftImage")));
            this.btnExit.OnIdleState.IconRightImage = null;
            this.btnExit.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnExit.OnPressedState.BorderRadius = 20;
            this.btnExit.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnExit.OnPressedState.BorderThickness = 2;
            this.btnExit.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnExit.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.OnPressedState.IconLeftImage = null;
            this.btnExit.OnPressedState.IconRightImage = null;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.TextMarginLeft = 0;
            this.btnExit.TextPadding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExit.UseDefaultRadiusAndThickness = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.AllowAnimations = true;
            this.btnCustomer.AllowMouseEffects = true;
            this.btnCustomer.AllowToggling = false;
            this.btnCustomer.AnimationSpeed = 200;
            this.btnCustomer.AutoGenerateColors = false;
            this.btnCustomer.AutoRoundBorders = false;
            this.btnCustomer.AutoSizeLeftIcon = true;
            this.btnCustomer.AutoSizeRightIcon = true;
            this.btnCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCustomer.ButtonText = "Customer";
            this.btnCustomer.ButtonTextMarginLeft = 0;
            this.btnCustomer.ColorContrastOnClick = 45;
            this.btnCustomer.ColorContrastOnHover = 45;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnCustomer.CustomizableEdges = borderEdges2;
            this.btnCustomer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCustomer.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCustomer.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCustomer.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCustomer.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnCustomer.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCustomer.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCustomer.IconMarginLeft = 11;
            this.btnCustomer.IconPadding = 10;
            this.btnCustomer.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomer.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCustomer.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnCustomer.IconSize = 25;
            this.btnCustomer.IdleBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.IdleBorderRadius = 20;
            this.btnCustomer.IdleBorderThickness = 2;
            this.btnCustomer.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnCustomer.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.people;
            this.btnCustomer.IdleIconRightImage = null;
            this.btnCustomer.IndicateFocus = false;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCustomer.OnDisabledState.BorderRadius = 20;
            this.btnCustomer.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCustomer.OnDisabledState.BorderThickness = 2;
            this.btnCustomer.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCustomer.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCustomer.OnDisabledState.IconLeftImage = null;
            this.btnCustomer.OnDisabledState.IconRightImage = null;
            this.btnCustomer.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCustomer.onHoverState.BorderRadius = 20;
            this.btnCustomer.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCustomer.onHoverState.BorderThickness = 2;
            this.btnCustomer.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCustomer.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.onHoverState.IconLeftImage = null;
            this.btnCustomer.onHoverState.IconRightImage = null;
            this.btnCustomer.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.OnIdleState.BorderRadius = 20;
            this.btnCustomer.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCustomer.OnIdleState.BorderThickness = 2;
            this.btnCustomer.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnCustomer.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.OnIdleState.IconLeftImage")));
            this.btnCustomer.OnIdleState.IconRightImage = null;
            this.btnCustomer.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCustomer.OnPressedState.BorderRadius = 20;
            this.btnCustomer.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCustomer.OnPressedState.BorderThickness = 2;
            this.btnCustomer.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCustomer.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCustomer.OnPressedState.IconLeftImage = null;
            this.btnCustomer.OnPressedState.IconRightImage = null;
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomer.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCustomer.TextMarginLeft = 0;
            this.btnCustomer.TextPadding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCustomer.UseDefaultRadiusAndThickness = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnInquiry
            // 
            this.btnInquiry.AllowAnimations = true;
            this.btnInquiry.AllowMouseEffects = true;
            this.btnInquiry.AllowToggling = false;
            this.btnInquiry.AnimationSpeed = 200;
            this.btnInquiry.AutoGenerateColors = false;
            this.btnInquiry.AutoRoundBorders = false;
            this.btnInquiry.AutoSizeLeftIcon = true;
            this.btnInquiry.AutoSizeRightIcon = true;
            this.btnInquiry.BackColor = System.Drawing.Color.Transparent;
            this.btnInquiry.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnInquiry, "btnInquiry");
            this.btnInquiry.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnInquiry.ButtonText = "Inquire";
            this.btnInquiry.ButtonTextMarginLeft = 0;
            this.btnInquiry.ColorContrastOnClick = 45;
            this.btnInquiry.ColorContrastOnHover = 45;
            this.btnInquiry.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnInquiry.CustomizableEdges = borderEdges3;
            this.btnInquiry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnInquiry.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnInquiry.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnInquiry.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnInquiry.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnInquiry.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInquiry.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnInquiry.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnInquiry.IconMarginLeft = 11;
            this.btnInquiry.IconPadding = 10;
            this.btnInquiry.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInquiry.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnInquiry.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnInquiry.IconSize = 25;
            this.btnInquiry.IdleBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.IdleBorderRadius = 20;
            this.btnInquiry.IdleBorderThickness = 2;
            this.btnInquiry.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnInquiry.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.inquire;
            this.btnInquiry.IdleIconRightImage = null;
            this.btnInquiry.IndicateFocus = false;
            this.btnInquiry.Name = "btnInquiry";
            this.btnInquiry.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnInquiry.OnDisabledState.BorderRadius = 20;
            this.btnInquiry.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnInquiry.OnDisabledState.BorderThickness = 2;
            this.btnInquiry.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnInquiry.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnInquiry.OnDisabledState.IconLeftImage = null;
            this.btnInquiry.OnDisabledState.IconRightImage = null;
            this.btnInquiry.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnInquiry.onHoverState.BorderRadius = 20;
            this.btnInquiry.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnInquiry.onHoverState.BorderThickness = 2;
            this.btnInquiry.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnInquiry.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.onHoverState.IconLeftImage = null;
            this.btnInquiry.onHoverState.IconRightImage = null;
            this.btnInquiry.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.OnIdleState.BorderRadius = 20;
            this.btnInquiry.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnInquiry.OnIdleState.BorderThickness = 2;
            this.btnInquiry.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnInquiry.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnInquiry.OnIdleState.IconLeftImage")));
            this.btnInquiry.OnIdleState.IconRightImage = null;
            this.btnInquiry.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnInquiry.OnPressedState.BorderRadius = 20;
            this.btnInquiry.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnInquiry.OnPressedState.BorderThickness = 2;
            this.btnInquiry.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnInquiry.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInquiry.OnPressedState.IconLeftImage = null;
            this.btnInquiry.OnPressedState.IconRightImage = null;
            this.btnInquiry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInquiry.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnInquiry.TextMarginLeft = 0;
            this.btnInquiry.TextPadding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnInquiry.UseDefaultRadiusAndThickness = true;
            this.btnInquiry.Click += new System.EventHandler(this.btnInquiry_Click);
            // 
            // btnRentCar
            // 
            this.btnRentCar.AllowAnimations = true;
            this.btnRentCar.AllowMouseEffects = true;
            this.btnRentCar.AllowToggling = false;
            this.btnRentCar.AnimationSpeed = 200;
            this.btnRentCar.AutoGenerateColors = false;
            this.btnRentCar.AutoRoundBorders = false;
            this.btnRentCar.AutoSizeLeftIcon = true;
            this.btnRentCar.AutoSizeRightIcon = true;
            this.btnRentCar.BackColor = System.Drawing.Color.Transparent;
            this.btnRentCar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnRentCar, "btnRentCar");
            this.btnRentCar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRentCar.ButtonText = "Rent";
            this.btnRentCar.ButtonTextMarginLeft = 0;
            this.btnRentCar.ColorContrastOnClick = 45;
            this.btnRentCar.ColorContrastOnHover = 45;
            this.btnRentCar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnRentCar.CustomizableEdges = borderEdges4;
            this.btnRentCar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRentCar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRentCar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRentCar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnRentCar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnRentCar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentCar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnRentCar.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRentCar.IconMarginLeft = 11;
            this.btnRentCar.IconPadding = 10;
            this.btnRentCar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRentCar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnRentCar.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnRentCar.IconSize = 25;
            this.btnRentCar.IdleBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.IdleBorderRadius = 20;
            this.btnRentCar.IdleBorderThickness = 2;
            this.btnRentCar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnRentCar.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.carrent;
            this.btnRentCar.IdleIconRightImage = null;
            this.btnRentCar.IndicateFocus = false;
            this.btnRentCar.Name = "btnRentCar";
            this.btnRentCar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRentCar.OnDisabledState.BorderRadius = 20;
            this.btnRentCar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRentCar.OnDisabledState.BorderThickness = 2;
            this.btnRentCar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRentCar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnRentCar.OnDisabledState.IconLeftImage = null;
            this.btnRentCar.OnDisabledState.IconRightImage = null;
            this.btnRentCar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnRentCar.onHoverState.BorderRadius = 20;
            this.btnRentCar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRentCar.onHoverState.BorderThickness = 2;
            this.btnRentCar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnRentCar.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.onHoverState.IconLeftImage = null;
            this.btnRentCar.onHoverState.IconRightImage = null;
            this.btnRentCar.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.OnIdleState.BorderRadius = 20;
            this.btnRentCar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRentCar.OnIdleState.BorderThickness = 2;
            this.btnRentCar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnRentCar.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnRentCar.OnIdleState.IconLeftImage")));
            this.btnRentCar.OnIdleState.IconRightImage = null;
            this.btnRentCar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnRentCar.OnPressedState.BorderRadius = 20;
            this.btnRentCar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRentCar.OnPressedState.BorderThickness = 2;
            this.btnRentCar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnRentCar.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentCar.OnPressedState.IconLeftImage = null;
            this.btnRentCar.OnPressedState.IconRightImage = null;
            this.btnRentCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRentCar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRentCar.TextMarginLeft = 0;
            this.btnRentCar.TextPadding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRentCar.UseDefaultRadiusAndThickness = true;
            this.btnRentCar.Click += new System.EventHandler(this.btnRentCar_Click);
            // 
            // btnAvailableCars
            // 
            this.btnAvailableCars.AllowAnimations = true;
            this.btnAvailableCars.AllowMouseEffects = true;
            this.btnAvailableCars.AllowToggling = false;
            this.btnAvailableCars.AnimationSpeed = 200;
            this.btnAvailableCars.AutoGenerateColors = false;
            this.btnAvailableCars.AutoRoundBorders = false;
            this.btnAvailableCars.AutoSizeLeftIcon = true;
            this.btnAvailableCars.AutoSizeRightIcon = true;
            this.btnAvailableCars.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnAvailableCars.BackColor = System.Drawing.Color.Transparent;
            this.btnAvailableCars.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnAvailableCars, "btnAvailableCars");
            this.btnAvailableCars.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAvailableCars.ButtonText = "Cars";
            this.btnAvailableCars.ButtonTextMarginLeft = 0;
            this.btnAvailableCars.ColorContrastOnClick = 45;
            this.btnAvailableCars.ColorContrastOnHover = 45;
            this.btnAvailableCars.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnAvailableCars.CustomizableEdges = borderEdges5;
            this.btnAvailableCars.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAvailableCars.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAvailableCars.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAvailableCars.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAvailableCars.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnAvailableCars.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvailableCars.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAvailableCars.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnAvailableCars.IconMarginLeft = 11;
            this.btnAvailableCars.IconPadding = 10;
            this.btnAvailableCars.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAvailableCars.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAvailableCars.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnAvailableCars.IconSize = 25;
            this.btnAvailableCars.IdleBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.IdleBorderRadius = 20;
            this.btnAvailableCars.IdleBorderThickness = 2;
            this.btnAvailableCars.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnAvailableCars.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.car2;
            this.btnAvailableCars.IdleIconRightImage = null;
            this.btnAvailableCars.IndicateFocus = false;
            this.btnAvailableCars.Name = "btnAvailableCars";
            this.btnAvailableCars.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAvailableCars.OnDisabledState.BorderRadius = 20;
            this.btnAvailableCars.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAvailableCars.OnDisabledState.BorderThickness = 2;
            this.btnAvailableCars.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAvailableCars.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAvailableCars.OnDisabledState.IconLeftImage = null;
            this.btnAvailableCars.OnDisabledState.IconRightImage = null;
            this.btnAvailableCars.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAvailableCars.onHoverState.BorderRadius = 20;
            this.btnAvailableCars.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAvailableCars.onHoverState.BorderThickness = 2;
            this.btnAvailableCars.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAvailableCars.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.onHoverState.IconLeftImage = null;
            this.btnAvailableCars.onHoverState.IconRightImage = null;
            this.btnAvailableCars.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.OnIdleState.BorderRadius = 20;
            this.btnAvailableCars.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAvailableCars.OnIdleState.BorderThickness = 2;
            this.btnAvailableCars.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnAvailableCars.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAvailableCars.OnIdleState.IconLeftImage")));
            this.btnAvailableCars.OnIdleState.IconRightImage = null;
            this.btnAvailableCars.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAvailableCars.OnPressedState.BorderRadius = 20;
            this.btnAvailableCars.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAvailableCars.OnPressedState.BorderThickness = 2;
            this.btnAvailableCars.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAvailableCars.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAvailableCars.OnPressedState.IconLeftImage = null;
            this.btnAvailableCars.OnPressedState.IconRightImage = null;
            this.btnAvailableCars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAvailableCars.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAvailableCars.TextMarginLeft = 0;
            this.btnAvailableCars.TextPadding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAvailableCars.UseDefaultRadiusAndThickness = true;
            this.btnAvailableCars.Click += new System.EventHandler(this.btnAvailableCars_Click);
            // 
            // lblUser
            // 
            this.lblUser.AllowParentOverrides = false;
            this.lblUser.AutoEllipsis = false;
            this.lblUser.CursorType = null;
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUser.Name = "lblUser";
            this.lblUser.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblUser.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnHome
            // 
            this.btnHome.AllowAnimations = true;
            this.btnHome.AllowMouseEffects = true;
            this.btnHome.AllowToggling = false;
            this.btnHome.AnimationSpeed = 200;
            this.btnHome.AutoGenerateColors = false;
            this.btnHome.AutoRoundBorders = false;
            this.btnHome.AutoSizeLeftIcon = true;
            this.btnHome.AutoSizeRightIcon = true;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnHome.ButtonText = "Home";
            this.btnHome.ButtonTextMarginLeft = 0;
            this.btnHome.ColorContrastOnClick = 45;
            this.btnHome.ColorContrastOnHover = 45;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnHome.CustomizableEdges = borderEdges6;
            this.btnHome.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHome.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnHome.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnHome.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnHome.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnHome.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnHome.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnHome.IconMarginLeft = 11;
            this.btnHome.IconPadding = 10;
            this.btnHome.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnHome.IconRightPadding = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnHome.IconSize = 25;
            this.btnHome.IdleBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.IdleBorderRadius = 20;
            this.btnHome.IdleBorderThickness = 2;
            this.btnHome.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnHome.IdleIconLeftImage = global::CarRentalSystem2.Properties.Resources.home;
            this.btnHome.IdleIconRightImage = null;
            this.btnHome.IndicateFocus = false;
            this.btnHome.Name = "btnHome";
            this.btnHome.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnHome.OnDisabledState.BorderRadius = 20;
            this.btnHome.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnHome.OnDisabledState.BorderThickness = 2;
            this.btnHome.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnHome.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnHome.OnDisabledState.IconLeftImage = null;
            this.btnHome.OnDisabledState.IconRightImage = null;
            this.btnHome.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnHome.onHoverState.BorderRadius = 20;
            this.btnHome.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnHome.onHoverState.BorderThickness = 2;
            this.btnHome.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnHome.onHoverState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.onHoverState.IconLeftImage = null;
            this.btnHome.onHoverState.IconRightImage = null;
            this.btnHome.OnIdleState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.OnIdleState.BorderRadius = 20;
            this.btnHome.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnHome.OnIdleState.BorderThickness = 2;
            this.btnHome.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnHome.OnIdleState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnHome.OnIdleState.IconLeftImage")));
            this.btnHome.OnIdleState.IconRightImage = null;
            this.btnHome.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnHome.OnPressedState.BorderRadius = 20;
            this.btnHome.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnHome.OnPressedState.BorderThickness = 2;
            this.btnHome.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnHome.OnPressedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHome.OnPressedState.IconLeftImage = null;
            this.btnHome.OnPressedState.IconRightImage = null;
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnHome.TextMarginLeft = 0;
            this.btnHome.TextPadding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHome.UseDefaultRadiusAndThickness = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pictureBox1.BackgroundImage = global::CarRentalSystem2.Properties.Resources.user;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BorderColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderRadius = 3;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShowBorders = true;
            // 
            // bunifuFormDrag1
            // 
            this.bunifuFormDrag1.AllowOpacityChangesWhileDragging = false;
            this.bunifuFormDrag1.ContainerControl = this;
            this.bunifuFormDrag1.DockIndicatorsOpacity = 0.5D;
            this.bunifuFormDrag1.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.bunifuFormDrag1.DockingOptions.DockAll = true;
            this.bunifuFormDrag1.DockingOptions.DockBottomLeft = true;
            this.bunifuFormDrag1.DockingOptions.DockBottomRight = true;
            this.bunifuFormDrag1.DockingOptions.DockFullScreen = true;
            this.bunifuFormDrag1.DockingOptions.DockLeft = true;
            this.bunifuFormDrag1.DockingOptions.DockRight = true;
            this.bunifuFormDrag1.DockingOptions.DockTopLeft = true;
            this.bunifuFormDrag1.DockingOptions.DockTopRight = true;
            this.bunifuFormDrag1.DragOpacity = 0.9D;
            this.bunifuFormDrag1.Enabled = true;
            this.bunifuFormDrag1.ParentForm = this;
            this.bunifuFormDrag1.ShowCursorChanges = true;
            this.bunifuFormDrag1.ShowDockingIndicators = true;
            this.bunifuFormDrag1.TitleBarOptions.BunifuFormDrag = this.bunifuFormDrag1;
            this.bunifuFormDrag1.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.bunifuFormDrag1.TitleBarOptions.Enabled = true;
            this.bunifuFormDrag1.TitleBarOptions.TitleBarControl = this.pictureBox1;
            this.bunifuFormDrag1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // Dashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnHome;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.UI.WinForms.BunifuFormDrag bFormDragDashboard;
        private Bunifu.UI.WinForms.BunifuLabel lblUser;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnInquiry;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnRentCar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAvailableCars;
        private Bunifu.UI.WinForms.BunifuPanel pnlMain;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnExit;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnCustomer;
        private Bunifu.UI.WinForms.BunifuFormDrag bunifuFormDrag1;
    }
}