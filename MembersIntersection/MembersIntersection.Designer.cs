namespace MembersIntersection
{
    partial class MembersIntersection
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupsopen = new System.Windows.Forms.Button();
            this.groupspathbox = new System.Windows.Forms.TextBox();
            this.groupslabel = new System.Windows.Forms.Label();
            this.memberslabel = new System.Windows.Forms.Label();
            this.membersopen = new System.Windows.Forms.Button();
            this.memberspathbox = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.logout = new System.Windows.Forms.Button();
            this.groupscounterlabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.memberscounterlaber = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.Add = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Look = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupsopen
            // 
            this.groupsopen.Location = new System.Drawing.Point(291, 10);
            this.groupsopen.Name = "groupsopen";
            this.groupsopen.Size = new System.Drawing.Size(75, 23);
            this.groupsopen.TabIndex = 12;
            this.groupsopen.Text = "Обзор";
            this.groupsopen.UseVisualStyleBackColor = true;
            this.groupsopen.Click += new System.EventHandler(this.groupsopen_Click);
            // 
            // groupspathbox
            // 
            this.groupspathbox.Location = new System.Drawing.Point(82, 12);
            this.groupspathbox.Name = "groupspathbox";
            this.groupspathbox.ReadOnly = true;
            this.groupspathbox.Size = new System.Drawing.Size(202, 20);
            this.groupspathbox.TabIndex = 11;
            this.groupspathbox.TabStop = false;
            // 
            // groupslabel
            // 
            this.groupslabel.AutoSize = true;
            this.groupslabel.Location = new System.Drawing.Point(12, 15);
            this.groupslabel.Name = "groupslabel";
            this.groupslabel.Size = new System.Drawing.Size(47, 13);
            this.groupslabel.TabIndex = 13;
            this.groupslabel.Text = "Группы:";
            // 
            // memberslabel
            // 
            this.memberslabel.AutoSize = true;
            this.memberslabel.Location = new System.Drawing.Point(12, 44);
            this.memberslabel.Name = "memberslabel";
            this.memberslabel.Size = new System.Drawing.Size(64, 13);
            this.memberslabel.TabIndex = 14;
            this.memberslabel.Text = "Участники:";
            // 
            // membersopen
            // 
            this.membersopen.Location = new System.Drawing.Point(291, 39);
            this.membersopen.Name = "membersopen";
            this.membersopen.Size = new System.Drawing.Size(75, 23);
            this.membersopen.TabIndex = 16;
            this.membersopen.Text = "Обзор";
            this.membersopen.UseVisualStyleBackColor = true;
            this.membersopen.Click += new System.EventHandler(this.membersopen_Click);
            // 
            // memberspathbox
            // 
            this.memberspathbox.Location = new System.Drawing.Point(82, 41);
            this.memberspathbox.Name = "memberspathbox";
            this.memberspathbox.ReadOnly = true;
            this.memberspathbox.Size = new System.Drawing.Size(202, 20);
            this.memberspathbox.TabIndex = 15;
            this.memberspathbox.TabStop = false;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(291, 144);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 17;
            this.start.Text = "Начать";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(274, 343);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(92, 23);
            this.logout.TabIndex = 18;
            this.logout.Text = "Разлогиниться";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // groupscounterlabel
            // 
            this.groupscounterlabel.AutoSize = true;
            this.groupscounterlabel.Location = new System.Drawing.Point(149, 187);
            this.groupscounterlabel.Name = "groupscounterlabel";
            this.groupscounterlabel.Size = new System.Drawing.Size(0, 13);
            this.groupscounterlabel.TabIndex = 19;
            this.groupscounterlabel.TextChanged += new System.EventHandler(this.groupscounterlabel_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 213);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // memberscounterlaber
            // 
            this.memberscounterlaber.AutoSize = true;
            this.memberscounterlaber.Location = new System.Drawing.Point(128, 280);
            this.memberscounterlaber.Name = "memberscounterlaber";
            this.memberscounterlaber.Size = new System.Drawing.Size(0, 13);
            this.memberscounterlaber.TabIndex = 21;
            this.memberscounterlaber.TextChanged += new System.EventHandler(this.memberscounterlaber_TextChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(15, 305);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(349, 23);
            this.progressBar2.TabIndex = 22;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(289, 68);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 23;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(208, 68);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 24;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Look
            // 
            this.Look.Location = new System.Drawing.Point(115, 68);
            this.Look.Name = "Look";
            this.Look.Size = new System.Drawing.Size(87, 23);
            this.Look.TabIndex = 25;
            this.Look.Text = "Посмотреть";
            this.Look.UseVisualStyleBackColor = true;
            this.Look.Click += new System.EventHandler(this.Look_Click);
            // 
            // MembersIntersection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 390);
            this.Controls.Add(this.Look);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.memberscounterlaber);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupscounterlabel);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.start);
            this.Controls.Add(this.membersopen);
            this.Controls.Add(this.memberspathbox);
            this.Controls.Add(this.memberslabel);
            this.Controls.Add(this.groupslabel);
            this.Controls.Add(this.groupsopen);
            this.Controls.Add(this.groupspathbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MembersIntersection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MembersIntersection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MembersIntersection_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button groupsopen;
        private System.Windows.Forms.TextBox groupspathbox;
        private System.Windows.Forms.Label groupslabel;
        private System.Windows.Forms.Label memberslabel;
        private System.Windows.Forms.Button membersopen;
        private System.Windows.Forms.TextBox memberspathbox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label groupscounterlabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label memberscounterlaber;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Look;
    }
}

