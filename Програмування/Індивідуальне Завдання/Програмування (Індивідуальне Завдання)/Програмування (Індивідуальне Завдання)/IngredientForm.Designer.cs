
namespace Програмування__Індивідуальне_Завдання_
{
    partial class IngredientForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.MassLabel = new System.Windows.Forms.Label();
            this.CaloriesLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.NameIng = new System.Windows.Forms.TextBox();
            this.SaveIngredientButton = new System.Windows.Forms.Button();
            this.CancelIngredientButton = new System.Windows.Forms.Button();
            this.CaloriesIng = new System.Windows.Forms.NumericUpDown();
            this.PriceIng = new System.Windows.Forms.NumericUpDown();
            this.MassIng = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CaloriesIng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceIng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MassIng)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 25);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(149, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Назва інградієнту:";
            // 
            // MassLabel
            // 
            this.MassLabel.AutoSize = true;
            this.MassLabel.Location = new System.Drawing.Point(12, 136);
            this.MassLabel.Name = "MassLabel";
            this.MassLabel.Size = new System.Drawing.Size(122, 20);
            this.MassLabel.TabIndex = 1;
            this.MassLabel.Text = "Вага продукту:";
            // 
            // CaloriesLabel
            // 
            this.CaloriesLabel.AutoSize = true;
            this.CaloriesLabel.Location = new System.Drawing.Point(12, 251);
            this.CaloriesLabel.Name = "CaloriesLabel";
            this.CaloriesLabel.Size = new System.Drawing.Size(162, 20);
            this.CaloriesLabel.TabIndex = 2;
            this.CaloriesLabel.Text = "Калорійність (100 г):";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(12, 369);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(98, 20);
            this.PriceLabel.TabIndex = 3;
            this.PriceLabel.Text = "Ціна (100 г):";
            // 
            // NameIng
            // 
            this.NameIng.Location = new System.Drawing.Point(235, 19);
            this.NameIng.Name = "NameIng";
            this.NameIng.Size = new System.Drawing.Size(211, 26);
            this.NameIng.TabIndex = 4;
            // 
            // SaveIngredientButton
            // 
            this.SaveIngredientButton.Location = new System.Drawing.Point(16, 530);
            this.SaveIngredientButton.Name = "SaveIngredientButton";
            this.SaveIngredientButton.Size = new System.Drawing.Size(146, 41);
            this.SaveIngredientButton.TabIndex = 8;
            this.SaveIngredientButton.Text = "Зберегти дані";
            this.SaveIngredientButton.UseVisualStyleBackColor = true;
            this.SaveIngredientButton.Click += new System.EventHandler(this.SaveIngredientButton_Click);
            // 
            // CancelIngredientButton
            // 
            this.CancelIngredientButton.Location = new System.Drawing.Point(300, 530);
            this.CancelIngredientButton.Name = "CancelIngredientButton";
            this.CancelIngredientButton.Size = new System.Drawing.Size(146, 41);
            this.CancelIngredientButton.TabIndex = 9;
            this.CancelIngredientButton.Text = "Скасувати";
            this.CancelIngredientButton.UseVisualStyleBackColor = true;
            this.CancelIngredientButton.Click += new System.EventHandler(this.CancelIngredientButton_Click);
            // 
            // CaloriesIng
            // 
            this.CaloriesIng.DecimalPlaces = 2;
            this.CaloriesIng.Location = new System.Drawing.Point(235, 245);
            this.CaloriesIng.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CaloriesIng.Name = "CaloriesIng";
            this.CaloriesIng.Size = new System.Drawing.Size(211, 26);
            this.CaloriesIng.TabIndex = 10;
            // 
            // PriceIng
            // 
            this.PriceIng.DecimalPlaces = 2;
            this.PriceIng.Location = new System.Drawing.Point(235, 363);
            this.PriceIng.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PriceIng.Name = "PriceIng";
            this.PriceIng.Size = new System.Drawing.Size(211, 26);
            this.PriceIng.TabIndex = 11;
            // 
            // MassIng
            // 
            this.MassIng.DecimalPlaces = 2;
            this.MassIng.Location = new System.Drawing.Point(235, 130);
            this.MassIng.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MassIng.Name = "MassIng";
            this.MassIng.Size = new System.Drawing.Size(211, 26);
            this.MassIng.TabIndex = 12;
            // 
            // IngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 583);
            this.Controls.Add(this.MassIng);
            this.Controls.Add(this.PriceIng);
            this.Controls.Add(this.CaloriesIng);
            this.Controls.Add(this.CancelIngredientButton);
            this.Controls.Add(this.SaveIngredientButton);
            this.Controls.Add(this.NameIng);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.CaloriesLabel);
            this.Controls.Add(this.MassLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "IngredientForm";
            this.Text = "Редактор інградієнту";
            ((System.ComponentModel.ISupportInitialize)(this.CaloriesIng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceIng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MassIng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label MassLabel;
        private System.Windows.Forms.Label CaloriesLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox NameIng;
        private System.Windows.Forms.Button SaveIngredientButton;
        private System.Windows.Forms.Button CancelIngredientButton;
        private System.Windows.Forms.NumericUpDown CaloriesIng;
        private System.Windows.Forms.NumericUpDown PriceIng;
        private System.Windows.Forms.NumericUpDown MassIng;
    }
}