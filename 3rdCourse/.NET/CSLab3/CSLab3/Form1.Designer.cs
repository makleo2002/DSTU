using System.ComponentModel;

namespace CSLab3
{
    partial class Form1
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            groupBoxAutumn = new GroupBox();
            btnAutumnLab1 = new Button();
            btnAutumnLab2 = new Button();
            btnAutumnLab3 = new Button();
            btnAutumnLab5 = new Button();
            btnAutumnLab6 = new Button();
            groupBoxSpring = new GroupBox();
            btnSpringLab1 = new Button();
            btnSpringLab2 = new Button();
            a = new TextBox();
            b = new TextBox();
            eps = new TextBox();
            lb1= new Label();
            lb2= new Label();
            lb3= new Label();
            lb4 = new Label();
            lb5 = new Label();
            lb6 = new Label();
            lb7 = new Label();
            lb8 = new Label();
            lb9 = new Label();
            lb10 = new Label();
            tb1 = new TextBox();
            tb2 = new TextBox();
            tb3 = new TextBox();
            tb4 = new TextBox();
            tb5 = new TextBox();
            tb6 = new TextBox();
            tb7 = new TextBox();
            submit = new Button();

            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 397);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // groupBoxAutumn
            // 
            groupBoxAutumn.Location = new Point(12, 415);
            groupBoxAutumn.Name = "groupBoxAutumn";
            groupBoxAutumn.Size = new Size(411, 250);
            groupBoxAutumn.TabIndex = 1;
            groupBoxAutumn.TabStop = false;
            groupBoxAutumn.Text = "Осень";
            groupBoxAutumn.Controls.Add(btnAutumnLab6);
            groupBoxAutumn.Controls.Add(btnAutumnLab5);
            groupBoxAutumn.Controls.Add(btnAutumnLab3);
            groupBoxAutumn.Controls.Add(btnAutumnLab2);
            groupBoxAutumn.Controls.Add(btnAutumnLab1);
            groupBoxAutumn.Controls.Add(tb1);
            groupBoxAutumn.Controls.Add(tb2);
            groupBoxAutumn.Controls.Add(tb3);
            groupBoxAutumn.Controls.Add(tb4);
            groupBoxAutumn.Controls.Add(tb5);
            groupBoxAutumn.Controls.Add(tb6);
            groupBoxAutumn.Controls.Add(tb7);
            groupBoxAutumn.Controls.Add(lb4);
            groupBoxAutumn.Controls.Add(lb5);
            groupBoxAutumn.Controls.Add(lb6);
            groupBoxAutumn.Controls.Add(lb7);
            groupBoxAutumn.Controls.Add(lb8);
            groupBoxAutumn.Controls.Add(lb9);
            groupBoxAutumn.Controls.Add(lb10);
            groupBoxAutumn.Controls.Add(submit);

            lb4.Text = "Размеры";
            lb4.Location = new Point(20, 110);
            tb1.Location = new Point(86, 110);
            tb1.Size = new(40, 20);

            lb5.Text = "Массив1";
            lb5.Location = new Point(20, 140);
            tb2.Location = new Point(86, 140);
            tb2.Size = new(40, 20);

            lb6.Text = "Массив2";
            lb6.Location = new Point(20, 170);
            tb3.Location = new Point(86, 170);
            tb3.Size = new(40, 20);

            lb7.Text = "Массив3";
            lb7.Location = new Point(20, 200);
            tb4.Location = new Point(86, 200);
            tb4.Size = new(40, 20);

            lb8.Text = "Выбор";
            lb8.Location = new Point(240, 110);
            tb5.Location = new Point(286, 110);
            tb5.Size = new(40, 20);

            lb9.Text = "Путь1";
            lb9.Location = new Point(246, 140);
            tb6.Location = new Point(286, 140);
            tb6.Size = new(40, 20);

            lb10.Text = "Путь2";
            lb10.Location = new Point(246, 170);
            tb7.Location = new Point(286, 170);
            tb7.Size = new(40, 20);

            submit.Text = "Ввод";
            submit.Location = new Point(266, 200);
            submit.Size = new Size(75, 23);
            submit.Click += new EventHandler(Submit_Click);
            // 
            // btnAutumnLab1
            // 
            btnAutumnLab1.Location = new Point(66, 65);
            btnAutumnLab1.Name = "AutumnLab1";
            btnAutumnLab1.Size = new Size(75, 23);
            btnAutumnLab1.TabIndex = 0;
            btnAutumnLab1.Text = "Лаба 1";
            btnAutumnLab1.UseVisualStyleBackColor = true;
            btnAutumnLab1.Click += new EventHandler(AutumnLab1_Click);
            // 
            // btnAutumnLab2
            // 
            btnAutumnLab2.Location = new Point(87, 19);
            btnAutumnLab2.Name = "AutumnLab2";
            btnAutumnLab2.Size = new Size(75, 23);
            btnAutumnLab2.TabIndex = 1;
            btnAutumnLab2.Text = "Лаба 2";
            btnAutumnLab2.UseVisualStyleBackColor = true;
            btnAutumnLab2.Click += new EventHandler(AutumnLab2_Click);
            // 
            // btnAutumnLab3
            // 
            btnAutumnLab3.Location = new Point(168, 19);
            btnAutumnLab3.Name = "AutumnLab3";
            btnAutumnLab3.Size = new Size(75, 23);
            btnAutumnLab3.TabIndex = 2;
            btnAutumnLab3.Text = "Лаба 3";
            btnAutumnLab3.UseVisualStyleBackColor = true;
            btnAutumnLab3.Click += new EventHandler(AutumnLab3_Click);
            //
            // btnAutumnLab5
            //
            btnAutumnLab5.Location = new Point(249, 19);
            btnAutumnLab5.Name = "AutumnLab5";
            btnAutumnLab5.Size = new Size(75, 23);
            btnAutumnLab5.TabIndex = 3;
            btnAutumnLab5.Text = "Лаба 5";
            btnAutumnLab5.UseVisualStyleBackColor = true;
            btnAutumnLab5.Click += new EventHandler(AutumnLab5_Click);
            //
            // btnAutumnLab6
            //
            btnAutumnLab6.Location = new Point(266, 65);
            btnAutumnLab6.Name = "btnAutumnLab6";
            btnAutumnLab6.Size = new Size(75, 23);
            btnAutumnLab6.TabIndex = 4;
            btnAutumnLab6.Text = "Лаба 6";
            btnAutumnLab6.UseVisualStyleBackColor = true;
            btnAutumnLab6.Click += new EventHandler(AutumnLab6_Click);
            //
            // groupBoxSpring
            //
            groupBoxSpring.Location = new Point(419, 415);
            groupBoxSpring.Name = "groupBoxSpring";
            groupBoxSpring.Size = new Size(380, 250);
            groupBoxSpring.TabIndex = 2;
            groupBoxSpring.TabStop = false;
            groupBoxSpring.Text = "Весна";
            groupBoxSpring.Controls.Add(btnSpringLab1);
            groupBoxSpring.Controls.Add(btnSpringLab2);
            groupBoxSpring.Controls.Add(a);
            groupBoxSpring.Controls.Add(b);
            groupBoxSpring.Controls.Add(eps);
            groupBoxSpring.Controls.Add(lb1);
            groupBoxSpring.Controls.Add(lb2);
            groupBoxSpring.Controls.Add(lb3);
            //
            // btnSpringLab1
            //
            btnSpringLab1.Location = new Point(56, 19);
            btnSpringLab1.Name = "SpringLab1";
            btnSpringLab1.Size = new Size(75, 23);
            btnSpringLab1.TabIndex = 0;
            btnSpringLab1.Text = "Лаба 1";
            btnSpringLab1.UseVisualStyleBackColor = true;
            btnSpringLab1.Click += new EventHandler(SpringLab1_Click);
            //
            // btnSpringLab2
            //
            btnSpringLab2.Location = new Point(250, 19);
            btnSpringLab2.Name = "SpringLab2";
            btnSpringLab2.Size = new Size(75, 23);
            btnSpringLab2.TabIndex = 1;
            btnSpringLab2.Text = "Лаба 2";
            btnSpringLab2.UseVisualStyleBackColor = true;
            btnSpringLab2.Click += new EventHandler(SpringLab2_Click);

            lb1.Text = "a";
            lb1.Location= new Point(250,60);
            a.Location = new Point(270,60);
            a.Size = new(40, 20);

            lb2.Text = "b";
            lb2.Location = new Point(250,90);
            b.Location = new Point(270,90);
            b.Size = new(40, 20);

            lb3.Text = "eps";
            lb3.Location = new Point(240,120);
            eps.Location = new Point(270,120);
            eps.Size = new(40, 20);
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 750);
            Controls.Add(groupBoxSpring);
            Controls.Add(groupBoxAutumn);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);


    }

        private RichTextBox richTextBox1;
        private GroupBox groupBoxAutumn;
        private Button btnAutumnLab1;
        private Button btnAutumnLab2;
        private Button btnAutumnLab3;
        private Button btnAutumnLab5;
        private Button btnAutumnLab6;
        private GroupBox groupBoxSpring;
        private Button btnSpringLab1;
        private Button btnSpringLab2;
        private TextBox a,b,eps;
        private Label lb1,lb2,lb3,lb4,lb5,lb6,lb7,lb8,lb9,lb10;
        private TextBox tb1,tb2,tb3,tb4,tb5,tb6,tb7;
        private Button submit;
    }

}