namespace CookBook
{
    partial class FormMain
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
            this.Recipes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListRecipes = new System.Windows.Forms.ListBox();
            this.ListIngredients = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextRexipeName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ListAllIngredients = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Recipes
            // 
            this.Recipes.AutoSize = true;
            this.Recipes.Location = new System.Drawing.Point(25, 146);
            this.Recipes.Name = "Recipes";
            this.Recipes.Size = new System.Drawing.Size(58, 16);
            this.Recipes.TabIndex = 1;
            this.Recipes.Text = "Recipes";
            this.Recipes.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recipe Ingredients";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ListRecipes
            // 
            this.ListRecipes.AccessibleName = "ListRecipes";
            this.ListRecipes.DataBindings.Add(new System.Windows.Forms.Binding("Name", global::CookBook.Properties.Settings.Default, "ListRecipes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ListRecipes.FormattingEnabled = true;
            this.ListRecipes.ItemHeight = 16;
            this.ListRecipes.Location = new System.Drawing.Point(28, 169);
            this.ListRecipes.Name = "ListRecipes";
            this.ListRecipes.Size = new System.Drawing.Size(210, 196);
            this.ListRecipes.TabIndex = 4;
            this.ListRecipes.SelectedIndexChanged += new System.EventHandler(this.ListRecipes_SelectedIndexChanged);
            // 
            // ListIngredients
            // 
            this.ListIngredients.FormattingEnabled = true;
            this.ListIngredients.ItemHeight = 16;
            this.ListIngredients.Location = new System.Drawing.Point(28, 410);
            this.ListIngredients.Name = "ListIngredients";
            this.ListIngredients.Size = new System.Drawing.Size(213, 196);
            this.ListIngredients.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.AccessibleName = "Add Recipe";
            this.button1.Location = new System.Drawing.Point(28, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Recipe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextRexipeName
            // 
            this.TextRexipeName.Location = new System.Drawing.Point(28, 48);
            this.TextRexipeName.Name = "TextRexipeName";
            this.TextRexipeName.Size = new System.Drawing.Size(210, 22);
            this.TextRexipeName.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.AccessibleName = "UpdateRecipeName";
            this.button2.Location = new System.Drawing.Point(28, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "UpdateRecipeName";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListAllIngredients
            // 
            this.ListAllIngredients.AccessibleName = "ListAllIngredients";
            this.ListAllIngredients.DataBindings.Add(new System.Windows.Forms.Binding("Name", global::CookBook.Properties.Settings.Default, "ListRecipes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ListAllIngredients.FormattingEnabled = true;
            this.ListAllIngredients.ItemHeight = 16;
            this.ListAllIngredients.Location = new System.Drawing.Point(303, 169);
            this.ListAllIngredients.Name = "ListAllIngredients";
            this.ListAllIngredients.Size = new System.Drawing.Size(210, 196);
            this.ListAllIngredients.TabIndex = 10;
            this.ListAllIngredients.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AccessibleName = "All Ingredients";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "All Ingredients";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.AccessibleName = "Add To Recipe";
            this.button3.Location = new System.Drawing.Point(303, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Add To Recipe";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 800);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ListAllIngredients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TextRexipeName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListIngredients);
            this.Controls.Add(this.ListRecipes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Recipes);
            this.Name = "FormMain";
            this.Text = "CookBook";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Recipes;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox ListRecipes;
        private System.Windows.Forms.ListBox ListIngredients;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextRexipeName;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListBox ListAllIngredients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}

