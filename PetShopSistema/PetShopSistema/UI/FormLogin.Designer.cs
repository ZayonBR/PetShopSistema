using System.Drawing;
using System.Windows.Forms;

namespace PetShopSistema.UI
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            senha_textBox = new TextBox();
            usuario_textBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label_usuario = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(senha_textBox);
            panel1.Controls.Add(usuario_textBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label_usuario);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(123, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(555, 393);
            panel1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(275, 334);
            button2.Name = "button2";
            button2.Size = new Size(140, 38);
            button2.TabIndex = 16;
            button2.Text = "Criar conta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(185, 272);
            button1.Name = "button1";
            button1.Size = new Size(230, 58);
            button1.TabIndex = 15;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // senha_textBox
            // 
            senha_textBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            senha_textBox.Location = new Point(185, 219);
            senha_textBox.Name = "senha_textBox";
            senha_textBox.PasswordChar = '*';
            senha_textBox.Size = new Size(230, 38);
            senha_textBox.TabIndex = 14;
            // 
            // usuario_textBox
            // 
            usuario_textBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usuario_textBox.Location = new Point(185, 175);
            usuario_textBox.Name = "usuario_textBox";
            usuario_textBox.Size = new Size(230, 38);
            usuario_textBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(80, 219);
            label2.Name = "label2";
            label2.Size = new Size(99, 41);
            label2.TabIndex = 12;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(60, 161);
            label1.Name = "label1";
            label1.Size = new Size(119, 41);
            label1.TabIndex = 11;
            label1.Text = "Usuário";
            // 
            // label_usuario
            // 
            label_usuario.AutoSize = true;
            label_usuario.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_usuario.ForeColor = Color.SteelBlue;
            label_usuario.Location = new Point(156, 12);
            label_usuario.Name = "label_usuario";
            label_usuario.Size = new Size(281, 81);
            label_usuario.TabIndex = 10;
            label_usuario.Text = "PetShop";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(185, 334);
            label3.Name = "label3";
            label3.Size = new Size(97, 38);
            label3.TabIndex = 17;
            label3.Text = "Não tem uma \r\nconta?\r\n";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 495);
            Controls.Add(panel1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button2;
        private Button button1;
        private TextBox senha_textBox;
        private TextBox usuario_textBox;
        private Label label2;
        private Label label1;
        private Label label_usuario;
        private Label label3;
    }
}
