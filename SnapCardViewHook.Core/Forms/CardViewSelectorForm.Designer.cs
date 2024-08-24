namespace SnapCardViewHook.Core.Forms
{
    partial class CardViewSelectorForm
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
            this.surfaceEffectBox = new System.Windows.Forms.ComboBox();
            this.overrideSurfaceEffectCheckBox = new System.Windows.Forms.CheckBox();
            this.overrideRevealEffectCheckBox = new System.Windows.Forms.CheckBox();
            this.revealEffectBox = new System.Windows.Forms.ComboBox();
            this.overrideVariantCheckBox = new System.Windows.Forms.CheckBox();
            this.variantBox = new System.Windows.Forms.ComboBox();
            this.ensureVariantMatchCheckbox = new System.Windows.Forms.CheckBox();
            this.force3DCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // surfaceEffectBox
            // 
            this.surfaceEffectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.surfaceEffectBox.FormattingEnabled = true;
            this.surfaceEffectBox.Location = new System.Drawing.Point(34, 40);
            this.surfaceEffectBox.Name = "surfaceEffectBox";
            this.surfaceEffectBox.Size = new System.Drawing.Size(216, 21);
            this.surfaceEffectBox.TabIndex = 0;
            // 
            // overrideSurfaceEffectCheckBox
            // 
            this.overrideSurfaceEffectCheckBox.AutoSize = true;
            this.overrideSurfaceEffectCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideSurfaceEffectCheckBox.Location = new System.Drawing.Point(34, 14);
            this.overrideSurfaceEffectCheckBox.Name = "overrideSurfaceEffectCheckBox";
            this.overrideSurfaceEffectCheckBox.Size = new System.Drawing.Size(160, 20);
            this.overrideSurfaceEffectCheckBox.TabIndex = 1;
            this.overrideSurfaceEffectCheckBox.Text = "Override surface effect";
            this.overrideSurfaceEffectCheckBox.UseVisualStyleBackColor = true;
            // 
            // overrideRevealEffectCheckBox
            // 
            this.overrideRevealEffectCheckBox.AutoSize = true;
            this.overrideRevealEffectCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideRevealEffectCheckBox.Location = new System.Drawing.Point(34, 77);
            this.overrideRevealEffectCheckBox.Name = "overrideRevealEffectCheckBox";
            this.overrideRevealEffectCheckBox.Size = new System.Drawing.Size(154, 20);
            this.overrideRevealEffectCheckBox.TabIndex = 3;
            this.overrideRevealEffectCheckBox.Text = "Override reveal effect";
            this.overrideRevealEffectCheckBox.UseVisualStyleBackColor = true;
            // 
            // revealEffectBox
            // 
            this.revealEffectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.revealEffectBox.FormattingEnabled = true;
            this.revealEffectBox.Location = new System.Drawing.Point(34, 103);
            this.revealEffectBox.Name = "revealEffectBox";
            this.revealEffectBox.Size = new System.Drawing.Size(216, 21);
            this.revealEffectBox.TabIndex = 2;
            // 
            // overrideVariantCheckBox
            // 
            this.overrideVariantCheckBox.AutoSize = true;
            this.overrideVariantCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideVariantCheckBox.Location = new System.Drawing.Point(34, 141);
            this.overrideVariantCheckBox.Name = "overrideVariantCheckBox";
            this.overrideVariantCheckBox.Size = new System.Drawing.Size(121, 20);
            this.overrideVariantCheckBox.TabIndex = 5;
            this.overrideVariantCheckBox.Text = "Override variant";
            this.overrideVariantCheckBox.UseVisualStyleBackColor = true;
            // 
            // variantBox
            // 
            this.variantBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variantBox.FormattingEnabled = true;
            this.variantBox.Location = new System.Drawing.Point(34, 188);
            this.variantBox.Name = "variantBox";
            this.variantBox.Size = new System.Drawing.Size(216, 21);
            this.variantBox.TabIndex = 4;
            // 
            // ensureVariantMatchCheckbox
            // 
            this.ensureVariantMatchCheckbox.AutoSize = true;
            this.ensureVariantMatchCheckbox.Checked = true;
            this.ensureVariantMatchCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ensureVariantMatchCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ensureVariantMatchCheckbox.Location = new System.Drawing.Point(34, 162);
            this.ensureVariantMatchCheckbox.Name = "ensureVariantMatchCheckbox";
            this.ensureVariantMatchCheckbox.Size = new System.Drawing.Size(195, 20);
            this.ensureVariantMatchCheckbox.TabIndex = 6;
            this.ensureVariantMatchCheckbox.Text = "Ensure variant matches card";
            this.ensureVariantMatchCheckbox.UseVisualStyleBackColor = true;
            // 
            // force3DCheckbox
            // 
            this.force3DCheckbox.AutoSize = true;
            this.force3DCheckbox.Checked = true;
            this.force3DCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.force3DCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.force3DCheckbox.Location = new System.Drawing.Point(34, 231);
            this.force3DCheckbox.Name = "force3DCheckbox";
            this.force3DCheckbox.Size = new System.Drawing.Size(111, 20);
            this.force3DCheckbox.TabIndex = 7;
            this.force3DCheckbox.Text = "Force 3D card";
            this.force3DCheckbox.UseVisualStyleBackColor = true;
            // 
            // CardViewSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 268);
            this.Controls.Add(this.force3DCheckbox);
            this.Controls.Add(this.ensureVariantMatchCheckbox);
            this.Controls.Add(this.overrideVariantCheckBox);
            this.Controls.Add(this.variantBox);
            this.Controls.Add(this.overrideRevealEffectCheckBox);
            this.Controls.Add(this.revealEffectBox);
            this.Controls.Add(this.overrideSurfaceEffectCheckBox);
            this.Controls.Add(this.surfaceEffectBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CardViewSelectorForm";
            this.ShowIcon = false;
            this.Text = "Card view selector";
            this.Load += new System.EventHandler(this.CardViewSelectorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox surfaceEffectBox;
        private System.Windows.Forms.CheckBox overrideSurfaceEffectCheckBox;
        private System.Windows.Forms.CheckBox overrideRevealEffectCheckBox;
        private System.Windows.Forms.ComboBox revealEffectBox;
        private System.Windows.Forms.CheckBox overrideVariantCheckBox;
        private System.Windows.Forms.ComboBox variantBox;
        private System.Windows.Forms.CheckBox ensureVariantMatchCheckbox;
        private System.Windows.Forms.CheckBox force3DCheckbox;
    }
}