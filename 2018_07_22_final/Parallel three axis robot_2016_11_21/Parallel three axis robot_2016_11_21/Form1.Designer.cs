using Advantech.Motion;//Common Motion API
using System;
namespace Parallel_three_axis_robot_2016_11_21
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_State_M2 = new System.Windows.Forms.TextBox();
            this.TB_State_M1 = new System.Windows.Forms.TextBox();
            this.TB_State_M3 = new System.Windows.Forms.TextBox();
            this.TB_Pos_M2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_FB_M3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tb_Pos_M1 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.TB_Pos_M3 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.TB_Vel_M1 = new System.Windows.Forms.TextBox();
            this.TB_FB_M1 = new System.Windows.Forms.TextBox();
            this.TB_Vel_M3 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.TB_FB_M2 = new System.Windows.Forms.TextBox();
            this.TB_Vel_M2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CB_XYLOCK = new System.Windows.Forms.CheckBox();
            this.button_InverseSTOP = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.TB_Z_I = new System.Windows.Forms.TextBox();
            this.TB_Y_I = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.TB_X_I = new System.Windows.Forms.TextBox();
            this.bu_perform_I = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_AxisLOCK = new System.Windows.Forms.CheckBox();
            this.button_DirectSTOP = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.bu_perform_D = new System.Windows.Forms.Button();
            this.TB_Motor3_D = new System.Windows.Forms.TextBox();
            this.TB_Motor2_D = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.TB_Motor1_D = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button_ExitProgram = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.TB_ZCPosition = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.TB_YCPosition = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.TB_XCPosition = new System.Windows.Forms.TextBox();
            this.TB_M1CDegree = new System.Windows.Forms.TextBox();
            this.TB_M2CDegree = new System.Windows.Forms.TextBox();
            this.TB_M3CDegree = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.picB_Motor3 = new System.Windows.Forms.PictureBox();
            this.picB_Motor2 = new System.Windows.Forms.PictureBox();
            this.picB_Motor1 = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label68 = new System.Windows.Forms.Label();
            this.TB_MotionT = new System.Windows.Forms.TextBox();
            this.checkBox_finsec = new System.Windows.Forms.CheckBox();
            this.checkBox_fixmm = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButtonAbs = new System.Windows.Forms.RadioButton();
            this.radioButtonRel = new System.Windows.Forms.RadioButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rdb_S = new System.Windows.Forms.RadioButton();
            this.rdb_T = new System.Windows.Forms.RadioButton();
            this.TBox_mmsec = new System.Windows.Forms.TextBox();
            this.textBoxDec = new System.Windows.Forms.TextBox();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.btn_SetParam = new System.Windows.Forms.Button();
            this.textBoxVelH = new System.Windows.Forms.TextBox();
            this.textBoxVelL = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.CmbAvailableDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_regulate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnServo = new System.Windows.Forms.Button();
            this.BtnOpenBoard = new System.Windows.Forms.Button();
            this.groupBox_robotarm = new System.Windows.Forms.GroupBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.checkBox_ = new System.Windows.Forms.CheckBox();
            this.checkBox_regulate = new System.Windows.Forms.CheckBox();
            this.Limit_Up = new System.Windows.Forms.TextBox();
            this.Limit_Down = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.CmbAxes = new System.Windows.Forms.ComboBox();
            this.label_robotAxis = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox_FXu = new System.Windows.Forms.TextBox();
            this.label_FXu = new System.Windows.Forms.Label();
            this.label_FYu = new System.Windows.Forms.Label();
            this.textBox_FYu = new System.Windows.Forms.TextBox();
            this.label_FXv = new System.Windows.Forms.Label();
            this.label_FYv = new System.Windows.Forms.Label();
            this.textBox_FXv = new System.Windows.Forms.TextBox();
            this.textBox_FYv = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_IXu = new System.Windows.Forms.TextBox();
            this.label_IXu = new System.Windows.Forms.Label();
            this.label_IYu = new System.Windows.Forms.Label();
            this.textBox_IYu = new System.Windows.Forms.TextBox();
            this.label_IXv = new System.Windows.Forms.Label();
            this.label_IYv = new System.Windows.Forms.Label();
            this.textBox_IXv = new System.Windows.Forms.TextBox();
            this.textBox_IYv = new System.Windows.Forms.TextBox();
            this.button_Curve = new System.Windows.Forms.Button();
            this.button_Motion = new System.Windows.Forms.Button();
            this.button_SavePath = new System.Windows.Forms.Button();
            this.textBox_PartNum = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.button_SearchPath = new System.Windows.Forms.Button();
            this.button_ClearPos = new System.Windows.Forms.Button();
            this.button_InitialAndFinish = new System.Windows.Forms.Button();
            this.comboBox_track = new System.Windows.Forms.ComboBox();
            this.button_recordpoint = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog4 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label_Xu = new System.Windows.Forms.Label();
            this.textBox_m2Xu = new System.Windows.Forms.TextBox();
            this.textBox_m2Yu = new System.Windows.Forms.TextBox();
            this.textBox_m2Xv = new System.Windows.Forms.TextBox();
            this.textBox_m2Yv = new System.Windows.Forms.TextBox();
            this.label_Yu = new System.Windows.Forms.Label();
            this.label_Xv = new System.Windows.Forms.Label();
            this.label_Yv = new System.Windows.Forms.Label();
            this.button_curve2 = new System.Windows.Forms.Button();
            this.button_openfile2 = new System.Windows.Forms.Button();
            this.button_m2savepath = new System.Windows.Forms.Button();
            this.textBox_PartNum2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pointset = new System.Windows.Forms.TextBox();
            this.label_pointset = new System.Windows.Forms.Label();
            this.label_pointnum = new System.Windows.Forms.Label();
            this.textBox_pointnum = new System.Windows.Forms.TextBox();
            this.button_m2motion = new System.Windows.Forms.Button();
            this.button_searchpathmt = new System.Windows.Forms.Button();
            this.timer_up_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_up_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_down_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_down_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_right_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_right_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_left_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_left_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_forward_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_forward_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_backward_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_backward_2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_VAr = new System.Windows.Forms.CheckBox();
            this.numeric_VAr = new System.Windows.Forms.NumericUpDown();
            this.checkBox_scoo = new System.Windows.Forms.CheckBox();
            this.trackBar_VAr = new System.Windows.Forms.TrackBar();
            this.webcam_1_ori = new System.Windows.Forms.PictureBox();
            this.webcam_2_ori = new System.Windows.Forms.PictureBox();
            this.numericHH = new System.Windows.Forms.NumericUpDown();
            this.numericSH = new System.Windows.Forms.NumericUpDown();
            this.numericVH = new System.Windows.Forms.NumericUpDown();
            this.numericVL = new System.Windows.Forms.NumericUpDown();
            this.numericHL = new System.Windows.Forms.NumericUpDown();
            this.numericSL = new System.Windows.Forms.NumericUpDown();
            this.trackBar_HH = new System.Windows.Forms.TrackBar();
            this.checkBox_EH = new System.Windows.Forms.CheckBox();
            this.checkBox_ES = new System.Windows.Forms.CheckBox();
            this.checkBox_EV = new System.Windows.Forms.CheckBox();
            this.checkBox_IV = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ch_lock = new System.Windows.Forms.CheckBox();
            this.ch_Path = new System.Windows.Forms.CheckBox();
            this.label_ONOFF = new System.Windows.Forms.Label();
            this.label_IV = new System.Windows.Forms.Label();
            this.label_V = new System.Windows.Forms.Label();
            this.label_S = new System.Windows.Forms.Label();
            this.label_H = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_resetHSV = new System.Windows.Forms.Button();
            this.trackBar_VL = new System.Windows.Forms.TrackBar();
            this.trackBar_SL = new System.Windows.Forms.TrackBar();
            this.trackBar_HL = new System.Windows.Forms.TrackBar();
            this.trackBar_VH = new System.Windows.Forms.TrackBar();
            this.trackBar_SH = new System.Windows.Forms.TrackBar();
            this.ComboBoxCameraList1 = new System.Windows.Forms.ComboBox();
            this.btn_web2 = new System.Windows.Forms.Button();
            this.btn_recordW2 = new System.Windows.Forms.Button();
            this.ComboBoxCameraList = new System.Windows.Forms.ComboBox();
            this.btn_web1 = new System.Windows.Forms.Button();
            this.btn_recordW1 = new System.Windows.Forms.Button();
            this.chart_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.checkBox_showvel = new System.Windows.Forms.CheckBox();
            this.label67 = new System.Windows.Forms.Label();
            this.checkBox_M3V = new System.Windows.Forms.CheckBox();
            this.checkBox_M2V = new System.Windows.Forms.CheckBox();
            this.checkBox_M1V = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label61 = new System.Windows.Forms.Label();
            this.checkBox_showde = new System.Windows.Forms.CheckBox();
            this.checkBox_M1D = new System.Windows.Forms.CheckBox();
            this.checkBox_M2D = new System.Windows.Forms.CheckBox();
            this.checkBox_M3D = new System.Windows.Forms.CheckBox();
            this.checkBox_NRT = new System.Windows.Forms.CheckBox();
            this.checkBox_RT = new System.Windows.Forms.CheckBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label60 = new System.Windows.Forms.Label();
            this.checkBox_showcoo = new System.Windows.Forms.CheckBox();
            this.checkBox_XAxis = new System.Windows.Forms.CheckBox();
            this.checkBox_YAxis = new System.Windows.Forms.CheckBox();
            this.checkBox_ZAxis = new System.Windows.Forms.CheckBox();
            this.textBox_executiontime = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_saveroi_1 = new System.Windows.Forms.Button();
            this.btn_saveroi_2 = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox_robotarm.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VAr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VAr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam_1_ori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam_2_ori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HH)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Data)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.TB_State_M2);
            this.groupBox5.Controls.Add(this.TB_State_M1);
            this.groupBox5.Controls.Add(this.TB_State_M3);
            this.groupBox5.Controls.Add(this.TB_Pos_M2);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.TB_FB_M3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.Tb_Pos_M1);
            this.groupBox5.Controls.Add(this.label50);
            this.groupBox5.Controls.Add(this.TB_Pos_M3);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.TB_Vel_M1);
            this.groupBox5.Controls.Add(this.TB_FB_M1);
            this.groupBox5.Controls.Add(this.TB_Vel_M3);
            this.groupBox5.Controls.Add(this.label53);
            this.groupBox5.Controls.Add(this.TB_FB_M2);
            this.groupBox5.Controls.Add(this.TB_Vel_M2);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(950, 469);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(665, 181);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Axis Status";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(228, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 63;
            this.label11.Text = "M_2 Sta";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(12, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "M_1 Sta";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(444, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "M_3 Sta";
            // 
            // TB_State_M2
            // 
            this.TB_State_M2.BackColor = System.Drawing.SystemColors.Window;
            this.TB_State_M2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_State_M2.Location = new System.Drawing.Point(294, 145);
            this.TB_State_M2.Name = "TB_State_M2";
            this.TB_State_M2.ReadOnly = true;
            this.TB_State_M2.Size = new System.Drawing.Size(115, 25);
            this.TB_State_M2.TabIndex = 25;
            this.TB_State_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_State_M1
            // 
            this.TB_State_M1.BackColor = System.Drawing.SystemColors.Window;
            this.TB_State_M1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_State_M1.Location = new System.Drawing.Point(77, 142);
            this.TB_State_M1.Name = "TB_State_M1";
            this.TB_State_M1.ReadOnly = true;
            this.TB_State_M1.Size = new System.Drawing.Size(115, 25);
            this.TB_State_M1.TabIndex = 58;
            this.TB_State_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_State_M3
            // 
            this.TB_State_M3.BackColor = System.Drawing.SystemColors.Window;
            this.TB_State_M3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_State_M3.Location = new System.Drawing.Point(509, 145);
            this.TB_State_M3.Name = "TB_State_M3";
            this.TB_State_M3.ReadOnly = true;
            this.TB_State_M3.Size = new System.Drawing.Size(115, 25);
            this.TB_State_M3.TabIndex = 62;
            this.TB_State_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Pos_M2
            // 
            this.TB_Pos_M2.BackColor = System.Drawing.SystemColors.Window;
            this.TB_Pos_M2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Pos_M2.Location = new System.Drawing.Point(294, 64);
            this.TB_Pos_M2.Name = "TB_Pos_M2";
            this.TB_Pos_M2.ReadOnly = true;
            this.TB_Pos_M2.Size = new System.Drawing.Size(115, 25);
            this.TB_Pos_M2.TabIndex = 56;
            this.TB_Pos_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(443, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 57;
            this.label10.Text = "M_3 Pos";
            // 
            // TB_FB_M3
            // 
            this.TB_FB_M3.BackColor = System.Drawing.SystemColors.Window;
            this.TB_FB_M3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_FB_M3.Location = new System.Drawing.Point(509, 24);
            this.TB_FB_M3.Name = "TB_FB_M3";
            this.TB_FB_M3.Size = new System.Drawing.Size(115, 25);
            this.TB_FB_M3.TabIndex = 88;
            this.TB_FB_M3.TabStop = false;
            this.TB_FB_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "M_ 1 Pos";
            // 
            // Tb_Pos_M1
            // 
            this.Tb_Pos_M1.BackColor = System.Drawing.SystemColors.Window;
            this.Tb_Pos_M1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Tb_Pos_M1.Location = new System.Drawing.Point(77, 64);
            this.Tb_Pos_M1.Name = "Tb_Pos_M1";
            this.Tb_Pos_M1.ReadOnly = true;
            this.Tb_Pos_M1.Size = new System.Drawing.Size(115, 25);
            this.Tb_Pos_M1.TabIndex = 21;
            this.Tb_Pos_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label50.Location = new System.Drawing.Point(12, 28);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(55, 20);
            this.label50.TabIndex = 84;
            this.label50.Text = "M_1 Fb";
            // 
            // TB_Pos_M3
            // 
            this.TB_Pos_M3.BackColor = System.Drawing.SystemColors.Window;
            this.TB_Pos_M3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Pos_M3.Location = new System.Drawing.Point(509, 64);
            this.TB_Pos_M3.Name = "TB_Pos_M3";
            this.TB_Pos_M3.ReadOnly = true;
            this.TB_Pos_M3.Size = new System.Drawing.Size(115, 25);
            this.TB_Pos_M3.TabIndex = 60;
            this.TB_Pos_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label52.Location = new System.Drawing.Point(228, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(55, 20);
            this.label52.TabIndex = 83;
            this.label52.Text = "M_2 Fb";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(228, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 61;
            this.label12.Text = "M_2 Pos";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(228, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 20);
            this.label14.TabIndex = 70;
            this.label14.Text = "M_2 Vel";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label51.Location = new System.Drawing.Point(443, 28);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(55, 20);
            this.label51.TabIndex = 85;
            this.label51.Text = "M_3 Fb";
            // 
            // TB_Vel_M1
            // 
            this.TB_Vel_M1.BackColor = System.Drawing.SystemColors.Window;
            this.TB_Vel_M1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Vel_M1.Location = new System.Drawing.Point(77, 104);
            this.TB_Vel_M1.Name = "TB_Vel_M1";
            this.TB_Vel_M1.ReadOnly = true;
            this.TB_Vel_M1.Size = new System.Drawing.Size(115, 25);
            this.TB_Vel_M1.TabIndex = 30;
            this.TB_Vel_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_FB_M1
            // 
            this.TB_FB_M1.BackColor = System.Drawing.SystemColors.Window;
            this.TB_FB_M1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_FB_M1.Location = new System.Drawing.Point(77, 24);
            this.TB_FB_M1.Name = "TB_FB_M1";
            this.TB_FB_M1.Size = new System.Drawing.Size(115, 25);
            this.TB_FB_M1.TabIndex = 87;
            this.TB_FB_M1.TabStop = false;
            this.TB_FB_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Vel_M3
            // 
            this.TB_Vel_M3.BackColor = System.Drawing.SystemColors.Window;
            this.TB_Vel_M3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Vel_M3.Location = new System.Drawing.Point(509, 104);
            this.TB_Vel_M3.Name = "TB_Vel_M3";
            this.TB_Vel_M3.ReadOnly = true;
            this.TB_Vel_M3.Size = new System.Drawing.Size(115, 25);
            this.TB_Vel_M3.TabIndex = 68;
            this.TB_Vel_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label53.Location = new System.Drawing.Point(12, 108);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(60, 20);
            this.label53.TabIndex = 31;
            this.label53.Text = "M_ 1 Vel";
            // 
            // TB_FB_M2
            // 
            this.TB_FB_M2.BackColor = System.Drawing.SystemColors.Window;
            this.TB_FB_M2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_FB_M2.Location = new System.Drawing.Point(294, 24);
            this.TB_FB_M2.Name = "TB_FB_M2";
            this.TB_FB_M2.Size = new System.Drawing.Size(115, 25);
            this.TB_FB_M2.TabIndex = 86;
            this.TB_FB_M2.TabStop = false;
            this.TB_FB_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Vel_M2
            // 
            this.TB_Vel_M2.BackColor = System.Drawing.SystemColors.Window;
            this.TB_Vel_M2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Vel_M2.Location = new System.Drawing.Point(294, 104);
            this.TB_Vel_M2.Name = "TB_Vel_M2";
            this.TB_Vel_M2.ReadOnly = true;
            this.TB_Vel_M2.Size = new System.Drawing.Size(115, 25);
            this.TB_Vel_M2.TabIndex = 69;
            this.TB_Vel_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(444, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "M_ 3 Vel";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.CB_XYLOCK);
            this.groupBox10.Controls.Add(this.button_InverseSTOP);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.Controls.Add(this.TB_Z_I);
            this.groupBox10.Controls.Add(this.TB_Y_I);
            this.groupBox10.Controls.Add(this.button7);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.TB_X_I);
            this.groupBox10.Controls.Add(this.bu_perform_I);
            this.groupBox10.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox10.Location = new System.Drawing.Point(950, 137);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(325, 175);
            this.groupBox10.TabIndex = 59;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Inverse Kinematics";
            // 
            // CB_XYLOCK
            // 
            this.CB_XYLOCK.AutoSize = true;
            this.CB_XYLOCK.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_XYLOCK.Location = new System.Drawing.Point(5, 142);
            this.CB_XYLOCK.Name = "CB_XYLOCK";
            this.CB_XYLOCK.Size = new System.Drawing.Size(80, 21);
            this.CB_XYLOCK.TabIndex = 112;
            this.CB_XYLOCK.Text = "X-Y Lock";
            this.CB_XYLOCK.UseVisualStyleBackColor = true;
            // 
            // button_InverseSTOP
            // 
            this.button_InverseSTOP.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_InverseSTOP.Location = new System.Drawing.Point(244, 68);
            this.button_InverseSTOP.Name = "button_InverseSTOP";
            this.button_InverseSTOP.Size = new System.Drawing.Size(65, 45);
            this.button_InverseSTOP.TabIndex = 111;
            this.button_InverseSTOP.Text = "STOP";
            this.button_InverseSTOP.UseVisualStyleBackColor = true;
            this.button_InverseSTOP.Click += new System.EventHandler(this.button_InverseSTOP_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(204, 108);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(32, 17);
            this.label30.TabIndex = 57;
            this.label30.Text = "mm";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label31.Location = new System.Drawing.Point(204, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 17);
            this.label31.TabIndex = 56;
            this.label31.Text = "mm";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label32.Location = new System.Drawing.Point(203, 28);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 17);
            this.label32.TabIndex = 55;
            this.label32.Text = "mm";
            // 
            // TB_Z_I
            // 
            this.TB_Z_I.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Z_I.Location = new System.Drawing.Point(66, 105);
            this.TB_Z_I.Name = "TB_Z_I";
            this.TB_Z_I.Size = new System.Drawing.Size(135, 25);
            this.TB_Z_I.TabIndex = 5;
            this.TB_Z_I.Text = "0";
            this.TB_Z_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Y_I
            // 
            this.TB_Y_I.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Y_I.Location = new System.Drawing.Point(66, 65);
            this.TB_Y_I.Name = "TB_Y_I";
            this.TB_Y_I.Size = new System.Drawing.Size(135, 25);
            this.TB_Y_I.TabIndex = 4;
            this.TB_Y_I.Text = "0";
            this.TB_Y_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(244, 120);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(65, 45);
            this.button7.TabIndex = 13;
            this.button7.Text = "CLEAR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label33.Location = new System.Drawing.Point(5, 108);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 17);
            this.label33.TabIndex = 3;
            this.label33.Text = "Z   Axis";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label34.Location = new System.Drawing.Point(5, 68);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 17);
            this.label34.TabIndex = 2;
            this.label34.Text = "Y   Axis";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label35.Location = new System.Drawing.Point(5, 28);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 17);
            this.label35.TabIndex = 1;
            this.label35.Text = "X   Axis";
            // 
            // TB_X_I
            // 
            this.TB_X_I.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_X_I.Location = new System.Drawing.Point(66, 25);
            this.TB_X_I.Name = "TB_X_I";
            this.TB_X_I.Size = new System.Drawing.Size(135, 25);
            this.TB_X_I.TabIndex = 0;
            this.TB_X_I.Text = "0";
            this.TB_X_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bu_perform_I
            // 
            this.bu_perform_I.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bu_perform_I.Location = new System.Drawing.Point(244, 19);
            this.bu_perform_I.Name = "bu_perform_I";
            this.bu_perform_I.Size = new System.Drawing.Size(65, 45);
            this.bu_perform_I.TabIndex = 11;
            this.bu_perform_I.Text = "START";
            this.bu_perform_I.UseVisualStyleBackColor = true;
            this.bu_perform_I.Click += new System.EventHandler(this.bu_perform_I_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.CB_AxisLOCK);
            this.groupBox4.Controls.Add(this.button_DirectSTOP);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.bu_perform_D);
            this.groupBox4.Controls.Add(this.TB_Motor3_D);
            this.groupBox4.Controls.Add(this.TB_Motor2_D);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.TB_Motor1_D);
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(1290, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 175);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Direct Kinematics";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(204, 103);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 26);
            this.label24.TabIndex = 113;
            this.label24.Text = "° ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(204, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 26);
            this.label9.TabIndex = 112;
            this.label9.Text = "° ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(204, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 26);
            this.label8.TabIndex = 111;
            this.label8.Text = "° ";
            // 
            // CB_AxisLOCK
            // 
            this.CB_AxisLOCK.AutoSize = true;
            this.CB_AxisLOCK.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_AxisLOCK.Location = new System.Drawing.Point(5, 144);
            this.CB_AxisLOCK.Name = "CB_AxisLOCK";
            this.CB_AxisLOCK.Size = new System.Drawing.Size(119, 21);
            this.CB_AxisLOCK.TabIndex = 41;
            this.CB_AxisLOCK.Text = "Three Axis Lock";
            this.CB_AxisLOCK.UseVisualStyleBackColor = true;
            this.CB_AxisLOCK.CheckedChanged += new System.EventHandler(this.checkBox_DirectSame_CheckedChanged);
            // 
            // button_DirectSTOP
            // 
            this.button_DirectSTOP.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_DirectSTOP.Location = new System.Drawing.Point(244, 70);
            this.button_DirectSTOP.Name = "button_DirectSTOP";
            this.button_DirectSTOP.Size = new System.Drawing.Size(65, 45);
            this.button_DirectSTOP.TabIndex = 110;
            this.button_DirectSTOP.Text = "STOP";
            this.button_DirectSTOP.UseVisualStyleBackColor = true;
            this.button_DirectSTOP.Click += new System.EventHandler(this.button_DirectSTOP_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(5, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(58, 17);
            this.label29.TabIndex = 15;
            this.label29.Text = "Motor 2";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(245, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 45);
            this.button3.TabIndex = 13;
            this.button3.Text = "CLEAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bu_perform_D
            // 
            this.bu_perform_D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bu_perform_D.Location = new System.Drawing.Point(244, 19);
            this.bu_perform_D.Name = "bu_perform_D";
            this.bu_perform_D.Size = new System.Drawing.Size(65, 45);
            this.bu_perform_D.TabIndex = 11;
            this.bu_perform_D.Text = "START";
            this.bu_perform_D.UseVisualStyleBackColor = true;
            this.bu_perform_D.Click += new System.EventHandler(this.bu_perform_D_Click);
            // 
            // TB_Motor3_D
            // 
            this.TB_Motor3_D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Motor3_D.Location = new System.Drawing.Point(66, 105);
            this.TB_Motor3_D.Name = "TB_Motor3_D";
            this.TB_Motor3_D.Size = new System.Drawing.Size(135, 25);
            this.TB_Motor3_D.TabIndex = 5;
            this.TB_Motor3_D.Text = "0";
            this.TB_Motor3_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Motor2_D
            // 
            this.TB_Motor2_D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Motor2_D.Location = new System.Drawing.Point(66, 65);
            this.TB_Motor2_D.Name = "TB_Motor2_D";
            this.TB_Motor2_D.Size = new System.Drawing.Size(135, 25);
            this.TB_Motor2_D.TabIndex = 4;
            this.TB_Motor2_D.Text = "0";
            this.TB_Motor2_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label27.Location = new System.Drawing.Point(5, 108);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 17);
            this.label27.TabIndex = 3;
            this.label27.Text = "Motor 3";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label28.Location = new System.Drawing.Point(5, 28);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 17);
            this.label28.TabIndex = 2;
            this.label28.Text = "Motor 1";
            // 
            // TB_Motor1_D
            // 
            this.TB_Motor1_D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_Motor1_D.Location = new System.Drawing.Point(66, 25);
            this.TB_Motor1_D.Name = "TB_Motor1_D";
            this.TB_Motor1_D.Size = new System.Drawing.Size(135, 25);
            this.TB_Motor1_D.TabIndex = 0;
            this.TB_Motor1_D.Text = "0";
            this.TB_Motor1_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.textBox4);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.textBox3);
            this.groupBox9.Controls.Add(this.textBox2);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox9.Location = new System.Drawing.Point(1627, 313);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(265, 155);
            this.groupBox9.TabIndex = 57;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Mechanism Parameter";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(229, 118);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 17);
            this.label22.TabIndex = 11;
            this.label22.Text = "mm";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox4.Location = new System.Drawing.Point(168, 114);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(58, 25);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "45";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(10, 118);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(157, 20);
            this.label23.TabIndex = 9;
            this.label23.Text = "Junction to Fixture  (Lp) ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(229, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(229, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 17);
            this.label18.TabIndex = 7;
            this.label18.Text = "mm";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(229, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "mm";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox3.Location = new System.Drawing.Point(168, 84);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 25);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "335";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(168, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "128";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(10, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Lower Arm                 (Lc)";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Upper Arm                 (Lb) ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Platform to Motor   (La)";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(168, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "62.9";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(1779, 561);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 89);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kinematics Method";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton3.Location = new System.Drawing.Point(7, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 21);
            this.radioButton3.TabIndex = 100;
            this.radioButton3.Text = "單體法";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton2.Location = new System.Drawing.Point(7, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 21);
            this.radioButton2.TabIndex = 99;
            this.radioButton2.Text = "解析法二";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton1.Location = new System.Drawing.Point(7, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 21);
            this.radioButton1.TabIndex = 98;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "解析法一";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button_ExitProgram
            // 
            this.button_ExitProgram.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_ExitProgram.Location = new System.Drawing.Point(610, 972);
            this.button_ExitProgram.Name = "button_ExitProgram";
            this.button_ExitProgram.Size = new System.Drawing.Size(118, 31);
            this.button_ExitProgram.TabIndex = 12;
            this.button_ExitProgram.Text = "Exit Program";
            this.button_ExitProgram.UseVisualStyleBackColor = true;
            this.button_ExitProgram.Click += new System.EventHandler(this.button_ExitProgram_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label36.Location = new System.Drawing.Point(616, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(32, 17);
            this.label36.TabIndex = 57;
            this.label36.Text = "mm";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label37.Location = new System.Drawing.Point(401, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 17);
            this.label37.TabIndex = 56;
            this.label37.Text = "mm";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label38.Location = new System.Drawing.Point(183, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(32, 17);
            this.label38.TabIndex = 55;
            this.label38.Text = "mm";
            // 
            // TB_ZCPosition
            // 
            this.TB_ZCPosition.BackColor = System.Drawing.SystemColors.Window;
            this.TB_ZCPosition.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_ZCPosition.Location = new System.Drawing.Point(498, 13);
            this.TB_ZCPosition.Name = "TB_ZCPosition";
            this.TB_ZCPosition.ReadOnly = true;
            this.TB_ZCPosition.Size = new System.Drawing.Size(115, 25);
            this.TB_ZCPosition.TabIndex = 6;
            this.TB_ZCPosition.Text = "0";
            this.TB_ZCPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label39.Location = new System.Drawing.Point(4, 17);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(52, 17);
            this.label39.TabIndex = 1;
            this.label39.Text = "X   Axis ";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label40.Location = new System.Drawing.Point(220, 17);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 17);
            this.label40.TabIndex = 2;
            this.label40.Text = "Y   Axis";
            // 
            // TB_YCPosition
            // 
            this.TB_YCPosition.BackColor = System.Drawing.SystemColors.Window;
            this.TB_YCPosition.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_YCPosition.Location = new System.Drawing.Point(283, 13);
            this.TB_YCPosition.Name = "TB_YCPosition";
            this.TB_YCPosition.ReadOnly = true;
            this.TB_YCPosition.Size = new System.Drawing.Size(115, 25);
            this.TB_YCPosition.TabIndex = 5;
            this.TB_YCPosition.Text = "0";
            this.TB_YCPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label41.Location = new System.Drawing.Point(437, 17);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(49, 17);
            this.label41.TabIndex = 3;
            this.label41.Text = "Z   Axis";
            // 
            // TB_XCPosition
            // 
            this.TB_XCPosition.BackColor = System.Drawing.SystemColors.Window;
            this.TB_XCPosition.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_XCPosition.Location = new System.Drawing.Point(65, 13);
            this.TB_XCPosition.Name = "TB_XCPosition";
            this.TB_XCPosition.ReadOnly = true;
            this.TB_XCPosition.Size = new System.Drawing.Size(115, 25);
            this.TB_XCPosition.TabIndex = 4;
            this.TB_XCPosition.Text = "0";
            this.TB_XCPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_M1CDegree
            // 
            this.TB_M1CDegree.BackColor = System.Drawing.SystemColors.Window;
            this.TB_M1CDegree.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_M1CDegree.Location = new System.Drawing.Point(65, 13);
            this.TB_M1CDegree.Name = "TB_M1CDegree";
            this.TB_M1CDegree.ReadOnly = true;
            this.TB_M1CDegree.Size = new System.Drawing.Size(115, 25);
            this.TB_M1CDegree.TabIndex = 11;
            this.TB_M1CDegree.Text = "0";
            this.TB_M1CDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_M2CDegree
            // 
            this.TB_M2CDegree.BackColor = System.Drawing.SystemColors.Window;
            this.TB_M2CDegree.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_M2CDegree.Location = new System.Drawing.Point(283, 13);
            this.TB_M2CDegree.Name = "TB_M2CDegree";
            this.TB_M2CDegree.ReadOnly = true;
            this.TB_M2CDegree.Size = new System.Drawing.Size(115, 25);
            this.TB_M2CDegree.TabIndex = 15;
            this.TB_M2CDegree.Text = "0";
            this.TB_M2CDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_M3CDegree
            // 
            this.TB_M3CDegree.BackColor = System.Drawing.SystemColors.Window;
            this.TB_M3CDegree.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_M3CDegree.Location = new System.Drawing.Point(498, 11);
            this.TB_M3CDegree.Name = "TB_M3CDegree";
            this.TB_M3CDegree.ReadOnly = true;
            this.TB_M3CDegree.Size = new System.Drawing.Size(115, 25);
            this.TB_M3CDegree.TabIndex = 16;
            this.TB_M3CDegree.Text = "0";
            this.TB_M3CDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(950, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 155);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information Coordinate  Degree  ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label47);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.TB_M3CDegree);
            this.panel2.Controls.Add(this.TB_M2CDegree);
            this.panel2.Controls.Add(this.TB_M1CDegree);
            this.panel2.Controls.Add(this.label46);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Location = new System.Drawing.Point(8, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 50);
            this.panel2.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label47.Location = new System.Drawing.Point(183, 9);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(26, 26);
            this.label47.TabIndex = 18;
            this.label47.Text = "° ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label45.Location = new System.Drawing.Point(401, 9);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(26, 26);
            this.label45.TabIndex = 17;
            this.label45.Text = "° ";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label42.Location = new System.Drawing.Point(616, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(26, 26);
            this.label42.TabIndex = 1;
            this.label42.Text = "° ";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label46.Location = new System.Drawing.Point(437, 15);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(58, 17);
            this.label46.TabIndex = 14;
            this.label46.Text = "Motor 3";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label43.Location = new System.Drawing.Point(220, 17);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(61, 17);
            this.label43.TabIndex = 12;
            this.label43.Text = "Motor 2 ";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label44.Location = new System.Drawing.Point(4, 17);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 17);
            this.label44.TabIndex = 13;
            this.label44.Text = "Motor 1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.TB_XCPosition);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.TB_YCPosition);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.TB_ZCPosition);
            this.panel1.Controls.Add(this.label37);
            this.panel1.Location = new System.Drawing.Point(8, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 50);
            this.panel1.TabIndex = 0;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.SystemColors.Window;
            this.textBox26.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox26.Location = new System.Drawing.Point(105, 24);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(140, 27);
            this.textBox26.TabIndex = 71;
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.SystemColors.Window;
            this.textBox27.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox27.Location = new System.Drawing.Point(105, 54);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(140, 27);
            this.textBox27.TabIndex = 72;
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.SystemColors.Window;
            this.textBox28.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox28.Location = new System.Drawing.Point(105, 84);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(140, 27);
            this.textBox28.TabIndex = 73;
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label62.Location = new System.Drawing.Point(10, 88);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(125, 20);
            this.label62.TabIndex = 22;
            this.label62.Text = "Motor 3 State";
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label63.Location = new System.Drawing.Point(10, 28);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(125, 20);
            this.label63.TabIndex = 20;
            this.label63.Text = "Motor 1 State";
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label64.Location = new System.Drawing.Point(10, 58);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(125, 20);
            this.label64.TabIndex = 21;
            this.label64.Text = "Motor 2 State";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label58);
            this.groupBox15.Controls.Add(this.label26);
            this.groupBox15.Controls.Add(this.label25);
            this.groupBox15.Controls.Add(this.picB_Motor3);
            this.groupBox15.Controls.Add(this.picB_Motor2);
            this.groupBox15.Controls.Add(this.picB_Motor1);
            this.groupBox15.Controls.Add(this.textBox28);
            this.groupBox15.Controls.Add(this.label62);
            this.groupBox15.Controls.Add(this.textBox26);
            this.groupBox15.Controls.Add(this.textBox27);
            this.groupBox15.Controls.Add(this.label63);
            this.groupBox15.Controls.Add(this.label64);
            this.groupBox15.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox15.Location = new System.Drawing.Point(1627, 469);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(265, 181);
            this.groupBox15.TabIndex = 74;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Limit State";
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label58.Location = new System.Drawing.Point(186, 154);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(60, 20);
            this.label58.TabIndex = 79;
            this.label58.Text = "Motor 3";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label26.Location = new System.Drawing.Point(102, 154);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 20);
            this.label26.TabIndex = 78;
            this.label26.Text = "Motor 2";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.Location = new System.Drawing.Point(15, 154);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 20);
            this.label25.TabIndex = 77;
            this.label25.Text = "Motor 1";
            // 
            // picB_Motor3
            // 
            this.picB_Motor3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picB_Motor3.Location = new System.Drawing.Point(200, 122);
            this.picB_Motor3.Name = "picB_Motor3";
            this.picB_Motor3.Size = new System.Drawing.Size(30, 30);
            this.picB_Motor3.TabIndex = 76;
            this.picB_Motor3.TabStop = false;
            // 
            // picB_Motor2
            // 
            this.picB_Motor2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picB_Motor2.Location = new System.Drawing.Point(117, 121);
            this.picB_Motor2.Name = "picB_Motor2";
            this.picB_Motor2.Size = new System.Drawing.Size(30, 30);
            this.picB_Motor2.TabIndex = 75;
            this.picB_Motor2.TabStop = false;
            // 
            // picB_Motor1
            // 
            this.picB_Motor1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picB_Motor1.Location = new System.Drawing.Point(30, 121);
            this.picB_Motor1.Name = "picB_Motor1";
            this.picB_Motor1.Size = new System.Drawing.Size(30, 30);
            this.picB_Motor1.TabIndex = 74;
            this.picB_Motor1.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label68);
            this.groupBox8.Controls.Add(this.TB_MotionT);
            this.groupBox8.Controls.Add(this.checkBox_finsec);
            this.groupBox8.Controls.Add(this.checkBox_fixmm);
            this.groupBox8.Controls.Add(this.label59);
            this.groupBox8.Controls.Add(this.groupBox7);
            this.groupBox8.Controls.Add(this.groupBox13);
            this.groupBox8.Controls.Add(this.TBox_mmsec);
            this.groupBox8.Controls.Add(this.textBoxDec);
            this.groupBox8.Controls.Add(this.textBoxAcc);
            this.groupBox8.Controls.Add(this.btn_SetParam);
            this.groupBox8.Controls.Add(this.textBoxVelH);
            this.groupBox8.Controls.Add(this.textBoxVelL);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.label48);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox8.Location = new System.Drawing.Point(950, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(665, 122);
            this.groupBox8.TabIndex = 94;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Velocity Setting";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label68.Location = new System.Drawing.Point(564, 94);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(27, 17);
            this.label68.TabIndex = 128;
            this.label68.Text = "sec";
            // 
            // TB_MotionT
            // 
            this.TB_MotionT.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_MotionT.Location = new System.Drawing.Point(491, 89);
            this.TB_MotionT.Name = "TB_MotionT";
            this.TB_MotionT.Size = new System.Drawing.Size(70, 25);
            this.TB_MotionT.TabIndex = 127;
            this.TB_MotionT.Text = "0.1";
            this.TB_MotionT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_finsec
            // 
            this.checkBox_finsec.AutoSize = true;
            this.checkBox_finsec.Checked = true;
            this.checkBox_finsec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_finsec.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_finsec.Location = new System.Drawing.Point(379, 91);
            this.checkBox_finsec.Name = "checkBox_finsec";
            this.checkBox_finsec.Size = new System.Drawing.Size(110, 21);
            this.checkBox_finsec.TabIndex = 126;
            this.checkBox_finsec.Text = "Finish Motion";
            this.checkBox_finsec.UseVisualStyleBackColor = true;
            // 
            // checkBox_fixmm
            // 
            this.checkBox_fixmm.AutoSize = true;
            this.checkBox_fixmm.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_fixmm.Location = new System.Drawing.Point(379, 62);
            this.checkBox_fixmm.Name = "checkBox_fixmm";
            this.checkBox_fixmm.Size = new System.Drawing.Size(109, 21);
            this.checkBox_fixmm.TabIndex = 125;
            this.checkBox_fixmm.Text = "Fixed Velocity";
            this.checkBox_fixmm.UseVisualStyleBackColor = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label59.Location = new System.Drawing.Point(564, 63);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(56, 17);
            this.label59.TabIndex = 124;
            this.label59.Text = "mm/sec";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButtonAbs);
            this.groupBox7.Controls.Add(this.radioButtonRel);
            this.groupBox7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox7.Location = new System.Drawing.Point(192, 54);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(167, 61);
            this.groupBox7.TabIndex = 90;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Movement";
            // 
            // radioButtonAbs
            // 
            this.radioButtonAbs.AutoSize = true;
            this.radioButtonAbs.Checked = true;
            this.radioButtonAbs.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonAbs.Location = new System.Drawing.Point(82, 26);
            this.radioButtonAbs.Name = "radioButtonAbs";
            this.radioButtonAbs.Size = new System.Drawing.Size(77, 21);
            this.radioButtonAbs.TabIndex = 42;
            this.radioButtonAbs.TabStop = true;
            this.radioButtonAbs.Text = "A_Mode";
            this.radioButtonAbs.UseVisualStyleBackColor = true;
            // 
            // radioButtonRel
            // 
            this.radioButtonRel.AutoSize = true;
            this.radioButtonRel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonRel.Location = new System.Drawing.Point(8, 26);
            this.radioButtonRel.Name = "radioButtonRel";
            this.radioButtonRel.Size = new System.Drawing.Size(76, 21);
            this.radioButtonRel.TabIndex = 41;
            this.radioButtonRel.Text = "R_Mode";
            this.radioButtonRel.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rdb_S);
            this.groupBox13.Controls.Add(this.rdb_T);
            this.groupBox13.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox13.Location = new System.Drawing.Point(10, 54);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(165, 61);
            this.groupBox13.TabIndex = 89;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Accelerate";
            // 
            // rdb_S
            // 
            this.rdb_S.AutoSize = true;
            this.rdb_S.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdb_S.Location = new System.Drawing.Point(85, 25);
            this.rdb_S.Name = "rdb_S";
            this.rdb_S.Size = new System.Drawing.Size(75, 21);
            this.rdb_S.TabIndex = 40;
            this.rdb_S.Text = "S_Mode";
            this.rdb_S.UseVisualStyleBackColor = true;
            // 
            // rdb_T
            // 
            this.rdb_T.AutoSize = true;
            this.rdb_T.Checked = true;
            this.rdb_T.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdb_T.Location = new System.Drawing.Point(5, 25);
            this.rdb_T.Name = "rdb_T";
            this.rdb_T.Size = new System.Drawing.Size(75, 21);
            this.rdb_T.TabIndex = 39;
            this.rdb_T.TabStop = true;
            this.rdb_T.Text = "T_Mode";
            this.rdb_T.UseVisualStyleBackColor = true;
            // 
            // TBox_mmsec
            // 
            this.TBox_mmsec.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBox_mmsec.Location = new System.Drawing.Point(491, 60);
            this.TBox_mmsec.Name = "TBox_mmsec";
            this.TBox_mmsec.Size = new System.Drawing.Size(70, 25);
            this.TBox_mmsec.TabIndex = 123;
            this.TBox_mmsec.Text = "50";
            this.TBox_mmsec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDec
            // 
            this.textBoxDec.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDec.Location = new System.Drawing.Point(427, 25);
            this.textBoxDec.Name = "textBoxDec";
            this.textBoxDec.Size = new System.Drawing.Size(85, 25);
            this.textBoxDec.TabIndex = 30;
            this.textBoxDec.TabStop = false;
            this.textBoxDec.Text = "8000";
            this.textBoxDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxAcc.Location = new System.Drawing.Point(301, 25);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(85, 25);
            this.textBoxAcc.TabIndex = 29;
            this.textBoxAcc.TabStop = false;
            this.textBoxAcc.Text = "8000";
            this.textBoxAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SetParam
            // 
            this.btn_SetParam.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_SetParam.Location = new System.Drawing.Point(541, 18);
            this.btn_SetParam.Name = "btn_SetParam";
            this.btn_SetParam.Size = new System.Drawing.Size(110, 35);
            this.btn_SetParam.TabIndex = 91;
            this.btn_SetParam.Text = "Setting Velocity";
            this.btn_SetParam.UseVisualStyleBackColor = true;
            this.btn_SetParam.Click += new System.EventHandler(this.btn_SetParam_Click);
            // 
            // textBoxVelH
            // 
            this.textBoxVelH.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxVelH.Location = new System.Drawing.Point(175, 25);
            this.textBoxVelH.Name = "textBoxVelH";
            this.textBoxVelH.Size = new System.Drawing.Size(85, 25);
            this.textBoxVelH.TabIndex = 28;
            this.textBoxVelH.TabStop = false;
            this.textBoxVelH.Text = "100000";
            this.textBoxVelH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxVelL
            // 
            this.textBoxVelL.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxVelL.Location = new System.Drawing.Point(49, 25);
            this.textBoxVelL.Name = "textBoxVelL";
            this.textBoxVelL.Size = new System.Drawing.Size(85, 25);
            this.textBoxVelL.TabIndex = 27;
            this.textBoxVelL.TabStop = false;
            this.textBoxVelL.Text = "30000";
            this.textBoxVelL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(388, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 17);
            this.label19.TabIndex = 26;
            this.label19.Text = "DEC";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(262, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 17);
            this.label20.TabIndex = 24;
            this.label20.Text = "ACC";
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label48.Location = new System.Drawing.Point(136, 28);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(37, 17);
            this.label48.TabIndex = 22;
            this.label48.Text = "VelH";
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label49.Location = new System.Drawing.Point(10, 28);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(37, 17);
            this.label49.TabIndex = 20;
            this.label49.Text = "VelL";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.CmbAvailableDevice);
            this.groupBox14.Controls.Add(this.label1);
            this.groupBox14.Controls.Add(this.button_regulate);
            this.groupBox14.Controls.Add(this.button1);
            this.groupBox14.Controls.Add(this.BtnServo);
            this.groupBox14.Controls.Add(this.BtnOpenBoard);
            this.groupBox14.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox14.Location = new System.Drawing.Point(1627, 5);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(265, 122);
            this.groupBox14.TabIndex = 95;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Control Board Setting";
            // 
            // CmbAvailableDevice
            // 
            this.CmbAvailableDevice.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CmbAvailableDevice.FormattingEnabled = true;
            this.CmbAvailableDevice.Location = new System.Drawing.Point(135, 21);
            this.CmbAvailableDevice.Name = "CmbAvailableDevice";
            this.CmbAvailableDevice.Size = new System.Drawing.Size(119, 25);
            this.CmbAvailableDevice.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available Board :";
            // 
            // button_regulate
            // 
            this.button_regulate.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_regulate.Location = new System.Drawing.Point(134, 84);
            this.button_regulate.Name = "button_regulate";
            this.button_regulate.Size = new System.Drawing.Size(120, 30);
            this.button_regulate.TabIndex = 3;
            this.button_regulate.Text = "Regulate";
            this.button_regulate.UseVisualStyleBackColor = true;
            this.button_regulate.Click += new System.EventHandler(this.button_regulate_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(5, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Initial Position";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnServo
            // 
            this.BtnServo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnServo.Location = new System.Drawing.Point(134, 49);
            this.BtnServo.Name = "BtnServo";
            this.BtnServo.Size = new System.Drawing.Size(120, 30);
            this.BtnServo.TabIndex = 1;
            this.BtnServo.Text = "Servo ";
            this.BtnServo.UseVisualStyleBackColor = true;
            this.BtnServo.Click += new System.EventHandler(this.BtnServo_Click);
            // 
            // BtnOpenBoard
            // 
            this.BtnOpenBoard.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnOpenBoard.Location = new System.Drawing.Point(5, 49);
            this.BtnOpenBoard.Name = "BtnOpenBoard";
            this.BtnOpenBoard.Size = new System.Drawing.Size(120, 30);
            this.BtnOpenBoard.TabIndex = 0;
            this.BtnOpenBoard.Text = "PCIBoard";
            this.BtnOpenBoard.UseVisualStyleBackColor = true;
            this.BtnOpenBoard.Click += new System.EventHandler(this.BtnOpenBoard_Click);
            // 
            // groupBox_robotarm
            // 
            this.groupBox_robotarm.Controls.Add(this.label57);
            this.groupBox_robotarm.Controls.Add(this.label56);
            this.groupBox_robotarm.Controls.Add(this.checkBox_);
            this.groupBox_robotarm.Controls.Add(this.checkBox_regulate);
            this.groupBox_robotarm.Controls.Add(this.Limit_Up);
            this.groupBox_robotarm.Controls.Add(this.Limit_Down);
            this.groupBox_robotarm.Controls.Add(this.label65);
            this.groupBox_robotarm.Controls.Add(this.label66);
            this.groupBox_robotarm.Controls.Add(this.CmbAxes);
            this.groupBox_robotarm.Controls.Add(this.label_robotAxis);
            this.groupBox_robotarm.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_robotarm.Location = new System.Drawing.Point(1627, 137);
            this.groupBox_robotarm.Name = "groupBox_robotarm";
            this.groupBox_robotarm.Size = new System.Drawing.Size(265, 175);
            this.groupBox_robotarm.TabIndex = 96;
            this.groupBox_robotarm.TabStop = false;
            this.groupBox_robotarm.Text = "Delta Robot Arm Setting";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label57.Location = new System.Drawing.Point(217, 137);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(26, 26);
            this.label57.TabIndex = 96;
            this.label57.Text = "° ";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label56.Location = new System.Drawing.Point(216, 106);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(26, 26);
            this.label56.TabIndex = 95;
            this.label56.Text = "° ";
            // 
            // checkBox_
            // 
            this.checkBox_.AutoSize = true;
            this.checkBox_.Checked = true;
            this.checkBox_.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_.Location = new System.Drawing.Point(10, 83);
            this.checkBox_.Name = "checkBox_";
            this.checkBox_.Size = new System.Drawing.Size(121, 21);
            this.checkBox_.TabIndex = 94;
            this.checkBox_.Text = "Graphic Display";
            this.checkBox_.UseVisualStyleBackColor = true;
            // 
            // checkBox_regulate
            // 
            this.checkBox_regulate.AutoSize = true;
            this.checkBox_regulate.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_regulate.Location = new System.Drawing.Point(10, 57);
            this.checkBox_regulate.Name = "checkBox_regulate";
            this.checkBox_regulate.Size = new System.Drawing.Size(142, 21);
            this.checkBox_regulate.TabIndex = 47;
            this.checkBox_regulate.Text = "Regulate Complete";
            this.checkBox_regulate.UseVisualStyleBackColor = true;
            // 
            // Limit_Up
            // 
            this.Limit_Up.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Limit_Up.Location = new System.Drawing.Point(172, 140);
            this.Limit_Up.Name = "Limit_Up";
            this.Limit_Up.Size = new System.Drawing.Size(42, 25);
            this.Limit_Up.TabIndex = 46;
            this.Limit_Up.Text = "0";
            this.Limit_Up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Limit_Down
            // 
            this.Limit_Down.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Limit_Down.Location = new System.Drawing.Point(172, 111);
            this.Limit_Down.Name = "Limit_Down";
            this.Limit_Down.Size = new System.Drawing.Size(42, 25);
            this.Limit_Down.TabIndex = 45;
            this.Limit_Down.Text = "85";
            this.Limit_Down.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label65.Location = new System.Drawing.Point(10, 143);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(145, 17);
            this.label65.TabIndex = 44;
            this.label65.Text = "Motor Angle Min Limit";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label66.Location = new System.Drawing.Point(10, 114);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(150, 17);
            this.label66.TabIndex = 43;
            this.label66.Text = "Motor Angle Max Limit ";
            // 
            // CmbAxes
            // 
            this.CmbAxes.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CmbAxes.FormattingEnabled = true;
            this.CmbAxes.Location = new System.Drawing.Point(49, 25);
            this.CmbAxes.Name = "CmbAxes";
            this.CmbAxes.Size = new System.Drawing.Size(43, 25);
            this.CmbAxes.TabIndex = 42;
            // 
            // label_robotAxis
            // 
            this.label_robotAxis.AutoSize = true;
            this.label_robotAxis.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_robotAxis.Location = new System.Drawing.Point(10, 28);
            this.label_robotAxis.Name = "label_robotAxis";
            this.label_robotAxis.Size = new System.Drawing.Size(38, 17);
            this.label_robotAxis.TabIndex = 41;
            this.label_robotAxis.Text = "Axis :";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.groupBox12);
            this.groupBox16.Controls.Add(this.groupBox2);
            this.groupBox16.Controls.Add(this.button_Curve);
            this.groupBox16.Controls.Add(this.button_Motion);
            this.groupBox16.Controls.Add(this.button_SavePath);
            this.groupBox16.Controls.Add(this.textBox_PartNum);
            this.groupBox16.Controls.Add(this.label54);
            this.groupBox16.Controls.Add(this.button_SearchPath);
            this.groupBox16.Controls.Add(this.button_ClearPos);
            this.groupBox16.Controls.Add(this.button_InitialAndFinish);
            this.groupBox16.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox16.Location = new System.Drawing.Point(610, 313);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(326, 337);
            this.groupBox16.TabIndex = 108;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Simplex Method One ";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox_FXu);
            this.groupBox12.Controls.Add(this.label_FXu);
            this.groupBox12.Controls.Add(this.label_FYu);
            this.groupBox12.Controls.Add(this.textBox_FYu);
            this.groupBox12.Controls.Add(this.label_FXv);
            this.groupBox12.Controls.Add(this.label_FYv);
            this.groupBox12.Controls.Add(this.textBox_FXv);
            this.groupBox12.Controls.Add(this.textBox_FYv);
            this.groupBox12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox12.Location = new System.Drawing.Point(9, 196);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(215, 125);
            this.groupBox12.TabIndex = 75;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Final Point";
            // 
            // textBox_FXu
            // 
            this.textBox_FXu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_FXu.Location = new System.Drawing.Point(48, 32);
            this.textBox_FXu.Name = "textBox_FXu";
            this.textBox_FXu.Size = new System.Drawing.Size(50, 33);
            this.textBox_FXu.TabIndex = 57;
            this.textBox_FXu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FXu
            // 
            this.label_FXu.AutoSize = true;
            this.label_FXu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_FXu.Location = new System.Drawing.Point(10, 40);
            this.label_FXu.Name = "label_FXu";
            this.label_FXu.Size = new System.Drawing.Size(34, 17);
            this.label_FXu.TabIndex = 58;
            this.label_FXu.Text = " FXu";
            // 
            // label_FYu
            // 
            this.label_FYu.AutoSize = true;
            this.label_FYu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_FYu.Location = new System.Drawing.Point(115, 40);
            this.label_FYu.Name = "label_FYu";
            this.label_FYu.Size = new System.Drawing.Size(34, 17);
            this.label_FYu.TabIndex = 59;
            this.label_FYu.Text = " FYu";
            // 
            // textBox_FYu
            // 
            this.textBox_FYu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_FYu.Location = new System.Drawing.Point(152, 32);
            this.textBox_FYu.Name = "textBox_FYu";
            this.textBox_FYu.Size = new System.Drawing.Size(50, 33);
            this.textBox_FYu.TabIndex = 60;
            this.textBox_FYu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FXv
            // 
            this.label_FXv.AutoSize = true;
            this.label_FXv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_FXv.Location = new System.Drawing.Point(10, 83);
            this.label_FXv.Name = "label_FXv";
            this.label_FXv.Size = new System.Drawing.Size(33, 17);
            this.label_FXv.TabIndex = 61;
            this.label_FXv.Text = " FXv";
            // 
            // label_FYv
            // 
            this.label_FYv.AutoSize = true;
            this.label_FYv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_FYv.Location = new System.Drawing.Point(115, 83);
            this.label_FYv.Name = "label_FYv";
            this.label_FYv.Size = new System.Drawing.Size(33, 17);
            this.label_FYv.TabIndex = 62;
            this.label_FYv.Text = " FYv";
            // 
            // textBox_FXv
            // 
            this.textBox_FXv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_FXv.Location = new System.Drawing.Point(48, 74);
            this.textBox_FXv.Name = "textBox_FXv";
            this.textBox_FXv.Size = new System.Drawing.Size(50, 33);
            this.textBox_FXv.TabIndex = 63;
            this.textBox_FXv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FYv
            // 
            this.textBox_FYv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_FYv.Location = new System.Drawing.Point(152, 74);
            this.textBox_FYv.Name = "textBox_FYv";
            this.textBox_FYv.Size = new System.Drawing.Size(50, 33);
            this.textBox_FYv.TabIndex = 64;
            this.textBox_FYv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_IXu);
            this.groupBox2.Controls.Add(this.label_IXu);
            this.groupBox2.Controls.Add(this.label_IYu);
            this.groupBox2.Controls.Add(this.textBox_IYu);
            this.groupBox2.Controls.Add(this.label_IXv);
            this.groupBox2.Controls.Add(this.label_IYv);
            this.groupBox2.Controls.Add(this.textBox_IXv);
            this.groupBox2.Controls.Add(this.textBox_IYv);
            this.groupBox2.Location = new System.Drawing.Point(7, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 125);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Initial Point";
            // 
            // textBox_IXu
            // 
            this.textBox_IXu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_IXu.Location = new System.Drawing.Point(48, 32);
            this.textBox_IXu.Name = "textBox_IXu";
            this.textBox_IXu.Size = new System.Drawing.Size(50, 33);
            this.textBox_IXu.TabIndex = 2;
            this.textBox_IXu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_IXu
            // 
            this.label_IXu.AutoSize = true;
            this.label_IXu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_IXu.Location = new System.Drawing.Point(10, 40);
            this.label_IXu.Name = "label_IXu";
            this.label_IXu.Size = new System.Drawing.Size(31, 17);
            this.label_IXu.TabIndex = 41;
            this.label_IXu.Text = " IXu";
            // 
            // label_IYu
            // 
            this.label_IYu.AutoSize = true;
            this.label_IYu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_IYu.Location = new System.Drawing.Point(115, 40);
            this.label_IYu.Name = "label_IYu";
            this.label_IYu.Size = new System.Drawing.Size(31, 17);
            this.label_IYu.TabIndex = 42;
            this.label_IYu.Text = " IYu";
            // 
            // textBox_IYu
            // 
            this.textBox_IYu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_IYu.Location = new System.Drawing.Point(152, 32);
            this.textBox_IYu.Name = "textBox_IYu";
            this.textBox_IYu.Size = new System.Drawing.Size(50, 33);
            this.textBox_IYu.TabIndex = 43;
            this.textBox_IYu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_IXv
            // 
            this.label_IXv.AutoSize = true;
            this.label_IXv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_IXv.Location = new System.Drawing.Point(10, 83);
            this.label_IXv.Name = "label_IXv";
            this.label_IXv.Size = new System.Drawing.Size(30, 17);
            this.label_IXv.TabIndex = 44;
            this.label_IXv.Text = " IXv";
            // 
            // label_IYv
            // 
            this.label_IYv.AutoSize = true;
            this.label_IYv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_IYv.Location = new System.Drawing.Point(115, 83);
            this.label_IYv.Name = "label_IYv";
            this.label_IYv.Size = new System.Drawing.Size(30, 17);
            this.label_IYv.TabIndex = 45;
            this.label_IYv.Text = " IYv";
            // 
            // textBox_IXv
            // 
            this.textBox_IXv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_IXv.Location = new System.Drawing.Point(48, 74);
            this.textBox_IXv.Name = "textBox_IXv";
            this.textBox_IXv.Size = new System.Drawing.Size(50, 33);
            this.textBox_IXv.TabIndex = 46;
            this.textBox_IXv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_IYv
            // 
            this.textBox_IYv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_IYv.Location = new System.Drawing.Point(152, 74);
            this.textBox_IYv.Name = "textBox_IYv";
            this.textBox_IYv.Size = new System.Drawing.Size(50, 33);
            this.textBox_IYv.TabIndex = 47;
            this.textBox_IYv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_Curve
            // 
            this.button_Curve.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Curve.Location = new System.Drawing.Point(228, 279);
            this.button_Curve.Name = "button_Curve";
            this.button_Curve.Size = new System.Drawing.Size(90, 40);
            this.button_Curve.TabIndex = 73;
            this.button_Curve.Text = "Curve";
            this.button_Curve.UseVisualStyleBackColor = true;
            this.button_Curve.Click += new System.EventHandler(this.button_Curve_Click);
            // 
            // button_Motion
            // 
            this.button_Motion.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Motion.Location = new System.Drawing.Point(228, 227);
            this.button_Motion.Name = "button_Motion";
            this.button_Motion.Size = new System.Drawing.Size(90, 40);
            this.button_Motion.TabIndex = 71;
            this.button_Motion.Text = "Motion";
            this.button_Motion.UseVisualStyleBackColor = true;
            this.button_Motion.Click += new System.EventHandler(this.button_Motion_Click);
            // 
            // button_SavePath
            // 
            this.button_SavePath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SavePath.Location = new System.Drawing.Point(228, 123);
            this.button_SavePath.Name = "button_SavePath";
            this.button_SavePath.Size = new System.Drawing.Size(90, 40);
            this.button_SavePath.TabIndex = 69;
            this.button_SavePath.Text = "Save Path";
            this.button_SavePath.UseVisualStyleBackColor = true;
            this.button_SavePath.Click += new System.EventHandler(this.button_SavePath_Click);
            // 
            // textBox_PartNum
            // 
            this.textBox_PartNum.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_PartNum.Location = new System.Drawing.Point(102, 29);
            this.textBox_PartNum.Name = "textBox_PartNum";
            this.textBox_PartNum.Size = new System.Drawing.Size(40, 25);
            this.textBox_PartNum.TabIndex = 67;
            this.textBox_PartNum.Text = "15";
            this.textBox_PartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label54.Location = new System.Drawing.Point(6, 32);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(90, 17);
            this.label54.TabIndex = 66;
            this.label54.Text = " Part Num (N)";
            // 
            // button_SearchPath
            // 
            this.button_SearchPath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SearchPath.Location = new System.Drawing.Point(229, 75);
            this.button_SearchPath.Name = "button_SearchPath";
            this.button_SearchPath.Size = new System.Drawing.Size(90, 40);
            this.button_SearchPath.TabIndex = 65;
            this.button_SearchPath.Text = "Search Path";
            this.button_SearchPath.UseVisualStyleBackColor = true;
            this.button_SearchPath.Click += new System.EventHandler(this.button_SearchPath_Click);
            // 
            // button_ClearPos
            // 
            this.button_ClearPos.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_ClearPos.Location = new System.Drawing.Point(228, 174);
            this.button_ClearPos.Name = "button_ClearPos";
            this.button_ClearPos.Size = new System.Drawing.Size(90, 40);
            this.button_ClearPos.TabIndex = 56;
            this.button_ClearPos.Text = "Clear";
            this.button_ClearPos.UseVisualStyleBackColor = true;
            this.button_ClearPos.Click += new System.EventHandler(this.button_ClearPos_Click);
            // 
            // button_InitialAndFinish
            // 
            this.button_InitialAndFinish.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_InitialAndFinish.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_InitialAndFinish.Location = new System.Drawing.Point(229, 26);
            this.button_InitialAndFinish.Name = "button_InitialAndFinish";
            this.button_InitialAndFinish.Size = new System.Drawing.Size(90, 40);
            this.button_InitialAndFinish.TabIndex = 0;
            this.button_InitialAndFinish.Text = "Point";
            this.button_InitialAndFinish.UseVisualStyleBackColor = true;
            this.button_InitialAndFinish.Click += new System.EventHandler(this.button_InitialAndFinish_Click);
            // 
            // comboBox_track
            // 
            this.comboBox_track.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_track.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_track.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_track.FormattingEnabled = true;
            this.comboBox_track.Location = new System.Drawing.Point(9, 270);
            this.comboBox_track.Name = "comboBox_track";
            this.comboBox_track.Size = new System.Drawing.Size(213, 32);
            this.comboBox_track.TabIndex = 68;
            // 
            // button_recordpoint
            // 
            this.button_recordpoint.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_recordpoint.Location = new System.Drawing.Point(229, 21);
            this.button_recordpoint.Name = "button_recordpoint";
            this.button_recordpoint.Size = new System.Drawing.Size(90, 40);
            this.button_recordpoint.TabIndex = 76;
            this.button_recordpoint.Text = "Point ";
            this.button_recordpoint.UseVisualStyleBackColor = true;
            this.button_recordpoint.Click += new System.EventHandler(this.button_recordpoint_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "bmp Image|*.bmp";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "bmp Image|*.bmp";
            // 
            // saveFileDialog3
            // 
            this.saveFileDialog3.Filter = "bmp Image|*.bmp";
            // 
            // saveFileDialog4
            // 
            this.saveFileDialog4.Filter = "bmp Image|*.bmp";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox17);
            this.groupBox6.Controls.Add(this.button_curve2);
            this.groupBox6.Controls.Add(this.button_openfile2);
            this.groupBox6.Controls.Add(this.button_m2savepath);
            this.groupBox6.Controls.Add(this.comboBox_track);
            this.groupBox6.Controls.Add(this.textBox_PartNum2);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.textBox_pointset);
            this.groupBox6.Controls.Add(this.label_pointset);
            this.groupBox6.Controls.Add(this.label_pointnum);
            this.groupBox6.Controls.Add(this.textBox_pointnum);
            this.groupBox6.Controls.Add(this.button_m2motion);
            this.groupBox6.Controls.Add(this.button_searchpathmt);
            this.groupBox6.Controls.Add(this.button_recordpoint);
            this.groupBox6.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox6.Location = new System.Drawing.Point(610, 650);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(326, 319);
            this.groupBox6.TabIndex = 120;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Simplex Method Two";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label_Xu);
            this.groupBox17.Controls.Add(this.textBox_m2Xu);
            this.groupBox17.Controls.Add(this.textBox_m2Yu);
            this.groupBox17.Controls.Add(this.textBox_m2Xv);
            this.groupBox17.Controls.Add(this.textBox_m2Yv);
            this.groupBox17.Controls.Add(this.label_Yu);
            this.groupBox17.Controls.Add(this.label_Xv);
            this.groupBox17.Controls.Add(this.label_Yv);
            this.groupBox17.Location = new System.Drawing.Point(9, 126);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(215, 125);
            this.groupBox17.TabIndex = 95;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Now Coordinate";
            // 
            // label_Xu
            // 
            this.label_Xu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Xu.Location = new System.Drawing.Point(10, 40);
            this.label_Xu.Name = "label_Xu";
            this.label_Xu.Size = new System.Drawing.Size(28, 20);
            this.label_Xu.TabIndex = 83;
            this.label_Xu.Text = "Xu";
            // 
            // textBox_m2Xu
            // 
            this.textBox_m2Xu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_m2Xu.Location = new System.Drawing.Point(48, 32);
            this.textBox_m2Xu.Name = "textBox_m2Xu";
            this.textBox_m2Xu.Size = new System.Drawing.Size(50, 33);
            this.textBox_m2Xu.TabIndex = 79;
            this.textBox_m2Xu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_m2Yu
            // 
            this.textBox_m2Yu.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_m2Yu.Location = new System.Drawing.Point(152, 32);
            this.textBox_m2Yu.Name = "textBox_m2Yu";
            this.textBox_m2Yu.Size = new System.Drawing.Size(50, 33);
            this.textBox_m2Yu.TabIndex = 80;
            this.textBox_m2Yu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_m2Xv
            // 
            this.textBox_m2Xv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_m2Xv.Location = new System.Drawing.Point(48, 74);
            this.textBox_m2Xv.Name = "textBox_m2Xv";
            this.textBox_m2Xv.Size = new System.Drawing.Size(50, 33);
            this.textBox_m2Xv.TabIndex = 81;
            this.textBox_m2Xv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_m2Yv
            // 
            this.textBox_m2Yv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_m2Yv.Location = new System.Drawing.Point(152, 74);
            this.textBox_m2Yv.Name = "textBox_m2Yv";
            this.textBox_m2Yv.Size = new System.Drawing.Size(50, 33);
            this.textBox_m2Yv.TabIndex = 82;
            this.textBox_m2Yv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Yu
            // 
            this.label_Yu.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Yu.Location = new System.Drawing.Point(115, 40);
            this.label_Yu.Name = "label_Yu";
            this.label_Yu.Size = new System.Drawing.Size(28, 20);
            this.label_Yu.TabIndex = 84;
            this.label_Yu.Text = "Yu";
            // 
            // label_Xv
            // 
            this.label_Xv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Xv.Location = new System.Drawing.Point(10, 83);
            this.label_Xv.Name = "label_Xv";
            this.label_Xv.Size = new System.Drawing.Size(30, 17);
            this.label_Xv.TabIndex = 85;
            this.label_Xv.Text = "Xv";
            // 
            // label_Yv
            // 
            this.label_Yv.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Yv.Location = new System.Drawing.Point(115, 83);
            this.label_Yv.Name = "label_Yv";
            this.label_Yv.Size = new System.Drawing.Size(28, 20);
            this.label_Yv.TabIndex = 86;
            this.label_Yv.Text = "Yv";
            // 
            // button_curve2
            // 
            this.button_curve2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_curve2.Location = new System.Drawing.Point(229, 265);
            this.button_curve2.Name = "button_curve2";
            this.button_curve2.Size = new System.Drawing.Size(90, 40);
            this.button_curve2.TabIndex = 94;
            this.button_curve2.Text = "Curve";
            this.button_curve2.UseVisualStyleBackColor = true;
            this.button_curve2.Click += new System.EventHandler(this.button_curve2_Click);
            // 
            // button_openfile2
            // 
            this.button_openfile2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_openfile2.Location = new System.Drawing.Point(229, 217);
            this.button_openfile2.Name = "button_openfile2";
            this.button_openfile2.Size = new System.Drawing.Size(90, 40);
            this.button_openfile2.TabIndex = 74;
            this.button_openfile2.Text = " File";
            this.button_openfile2.UseVisualStyleBackColor = true;
            // 
            // button_m2savepath
            // 
            this.button_m2savepath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_m2savepath.Location = new System.Drawing.Point(229, 119);
            this.button_m2savepath.Name = "button_m2savepath";
            this.button_m2savepath.Size = new System.Drawing.Size(90, 40);
            this.button_m2savepath.TabIndex = 93;
            this.button_m2savepath.Text = "Save Path";
            this.button_m2savepath.UseVisualStyleBackColor = true;
            this.button_m2savepath.Click += new System.EventHandler(this.button_m2savepath_Click);
            // 
            // textBox_PartNum2
            // 
            this.textBox_PartNum2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_PartNum2.Location = new System.Drawing.Point(120, 21);
            this.textBox_PartNum2.Name = "textBox_PartNum2";
            this.textBox_PartNum2.Size = new System.Drawing.Size(30, 25);
            this.textBox_PartNum2.TabIndex = 92;
            this.textBox_PartNum2.Text = "5";
            this.textBox_PartNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 91;
            this.label2.Text = "Point Num (N) :";
            // 
            // textBox_pointset
            // 
            this.textBox_pointset.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_pointset.Location = new System.Drawing.Point(88, 57);
            this.textBox_pointset.Name = "textBox_pointset";
            this.textBox_pointset.Size = new System.Drawing.Size(30, 25);
            this.textBox_pointset.TabIndex = 90;
            this.textBox_pointset.Text = "12";
            this.textBox_pointset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_pointset
            // 
            this.label_pointset.AutoSize = true;
            this.label_pointset.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_pointset.Location = new System.Drawing.Point(14, 62);
            this.label_pointset.Name = "label_pointset";
            this.label_pointset.Size = new System.Drawing.Size(68, 17);
            this.label_pointset.TabIndex = 89;
            this.label_pointset.Text = "Point Set :";
            // 
            // label_pointnum
            // 
            this.label_pointnum.AutoSize = true;
            this.label_pointnum.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_pointnum.Location = new System.Drawing.Point(13, 97);
            this.label_pointnum.Name = "label_pointnum";
            this.label_pointnum.Size = new System.Drawing.Size(73, 17);
            this.label_pointnum.TabIndex = 88;
            this.label_pointnum.Text = "Point Num";
            // 
            // textBox_pointnum
            // 
            this.textBox_pointnum.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_pointnum.Location = new System.Drawing.Point(88, 92);
            this.textBox_pointnum.Name = "textBox_pointnum";
            this.textBox_pointnum.Size = new System.Drawing.Size(30, 25);
            this.textBox_pointnum.TabIndex = 87;
            this.textBox_pointnum.Text = "0";
            this.textBox_pointnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_m2motion
            // 
            this.button_m2motion.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_m2motion.Location = new System.Drawing.Point(229, 169);
            this.button_m2motion.Name = "button_m2motion";
            this.button_m2motion.Size = new System.Drawing.Size(90, 40);
            this.button_m2motion.TabIndex = 78;
            this.button_m2motion.Text = "Motion";
            this.button_m2motion.UseVisualStyleBackColor = true;
            this.button_m2motion.Click += new System.EventHandler(this.button_m2motion_Click);
            // 
            // button_searchpathmt
            // 
            this.button_searchpathmt.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_searchpathmt.Location = new System.Drawing.Point(229, 70);
            this.button_searchpathmt.Name = "button_searchpathmt";
            this.button_searchpathmt.Size = new System.Drawing.Size(90, 40);
            this.button_searchpathmt.TabIndex = 77;
            this.button_searchpathmt.Text = "Search Path";
            this.button_searchpathmt.UseVisualStyleBackColor = true;
            this.button_searchpathmt.Click += new System.EventHandler(this.button_searchpathmt_Click);
            // 
            // checkBox_VAr
            // 
            this.checkBox_VAr.AutoSize = true;
            this.checkBox_VAr.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_VAr.Location = new System.Drawing.Point(227, 38);
            this.checkBox_VAr.Name = "checkBox_VAr";
            this.checkBox_VAr.Size = new System.Drawing.Size(15, 14);
            this.checkBox_VAr.TabIndex = 127;
            this.checkBox_VAr.UseVisualStyleBackColor = true;
            // 
            // numeric_VAr
            // 
            this.numeric_VAr.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numeric_VAr.Location = new System.Drawing.Point(212, 53);
            this.numeric_VAr.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numeric_VAr.Name = "numeric_VAr";
            this.numeric_VAr.Size = new System.Drawing.Size(52, 25);
            this.numeric_VAr.TabIndex = 137;
            this.numeric_VAr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeric_VAr.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.numeric_VAr.ValueChanged += new System.EventHandler(this.numeric_VAr_ValueChanged);
            // 
            // checkBox_scoo
            // 
            this.checkBox_scoo.AutoSize = true;
            this.checkBox_scoo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_scoo.Location = new System.Drawing.Point(163, 246);
            this.checkBox_scoo.Name = "checkBox_scoo";
            this.checkBox_scoo.Size = new System.Drawing.Size(95, 21);
            this.checkBox_scoo.TabIndex = 142;
            this.checkBox_scoo.Text = "Coordinate";
            this.checkBox_scoo.UseVisualStyleBackColor = true;
            // 
            // trackBar_VAr
            // 
            this.trackBar_VAr.AutoSize = false;
            this.trackBar_VAr.LargeChange = 2;
            this.trackBar_VAr.Location = new System.Drawing.Point(218, 80);
            this.trackBar_VAr.Maximum = 2000;
            this.trackBar_VAr.Name = "trackBar_VAr";
            this.trackBar_VAr.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_VAr.Size = new System.Drawing.Size(40, 163);
            this.trackBar_VAr.TabIndex = 129;
            this.trackBar_VAr.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_VAr.Value = 450;
            this.trackBar_VAr.Scroll += new System.EventHandler(this.trackBar_VAr_Scroll);
            // 
            // webcam_1_ori
            // 
            this.webcam_1_ori.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.webcam_1_ori.Location = new System.Drawing.Point(5, 5);
            this.webcam_1_ori.Name = "webcam_1_ori";
            this.webcam_1_ori.Size = new System.Drawing.Size(600, 450);
            this.webcam_1_ori.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webcam_1_ori.TabIndex = 129;
            this.webcam_1_ori.TabStop = false;
            // 
            // webcam_2_ori
            // 
            this.webcam_2_ori.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.webcam_2_ori.Location = new System.Drawing.Point(5, 504);
            this.webcam_2_ori.Name = "webcam_2_ori";
            this.webcam_2_ori.Size = new System.Drawing.Size(600, 450);
            this.webcam_2_ori.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webcam_2_ori.TabIndex = 130;
            this.webcam_2_ori.TabStop = false;
            // 
            // numericHH
            // 
            this.numericHH.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericHH.Location = new System.Drawing.Point(7, 53);
            this.numericHH.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.numericHH.Name = "numericHH";
            this.numericHH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericHH.Size = new System.Drawing.Size(50, 25);
            this.numericHH.TabIndex = 131;
            this.numericHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHH.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericHH.ValueChanged += new System.EventHandler(this.numericHH_ValueChanged);
            // 
            // numericSH
            // 
            this.numericSH.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericSH.Location = new System.Drawing.Point(63, 53);
            this.numericSH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericSH.Name = "numericSH";
            this.numericSH.Size = new System.Drawing.Size(50, 25);
            this.numericSH.TabIndex = 132;
            this.numericSH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSH.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericSH.ValueChanged += new System.EventHandler(this.numericSH_ValueChanged);
            // 
            // numericVH
            // 
            this.numericVH.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericVH.Location = new System.Drawing.Point(119, 53);
            this.numericVH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericVH.Name = "numericVH";
            this.numericVH.Size = new System.Drawing.Size(50, 25);
            this.numericVH.TabIndex = 133;
            this.numericVH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericVH.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericVH.ValueChanged += new System.EventHandler(this.numericVH_ValueChanged);
            // 
            // numericVL
            // 
            this.numericVL.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericVL.Location = new System.Drawing.Point(119, 176);
            this.numericVL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericVL.Name = "numericVL";
            this.numericVL.Size = new System.Drawing.Size(50, 25);
            this.numericVL.TabIndex = 134;
            this.numericVL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericVL.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.numericVL.ValueChanged += new System.EventHandler(this.numericVL_ValueChanged);
            // 
            // numericHL
            // 
            this.numericHL.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericHL.Location = new System.Drawing.Point(7, 176);
            this.numericHL.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.numericHL.Name = "numericHL";
            this.numericHL.Size = new System.Drawing.Size(50, 25);
            this.numericHL.TabIndex = 135;
            this.numericHL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHL.ValueChanged += new System.EventHandler(this.numericHL_ValueChanged);
            // 
            // numericSL
            // 
            this.numericSL.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericSL.Location = new System.Drawing.Point(63, 176);
            this.numericSL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericSL.Name = "numericSL";
            this.numericSL.Size = new System.Drawing.Size(50, 25);
            this.numericSL.TabIndex = 136;
            this.numericSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSL.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numericSL.ValueChanged += new System.EventHandler(this.numericSL_ValueChanged);
            // 
            // trackBar_HH
            // 
            this.trackBar_HH.AutoSize = false;
            this.trackBar_HH.Location = new System.Drawing.Point(12, 79);
            this.trackBar_HH.Maximum = 179;
            this.trackBar_HH.Name = "trackBar_HH";
            this.trackBar_HH.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_HH.Size = new System.Drawing.Size(40, 95);
            this.trackBar_HH.TabIndex = 137;
            this.trackBar_HH.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_HH.Value = 40;
            this.trackBar_HH.Scroll += new System.EventHandler(this.trackBar_HH_Scroll);
            // 
            // checkBox_EH
            // 
            this.checkBox_EH.AutoSize = true;
            this.checkBox_EH.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_EH.Location = new System.Drawing.Point(21, 38);
            this.checkBox_EH.Name = "checkBox_EH";
            this.checkBox_EH.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EH.TabIndex = 138;
            this.checkBox_EH.UseVisualStyleBackColor = true;
            // 
            // checkBox_ES
            // 
            this.checkBox_ES.AutoSize = true;
            this.checkBox_ES.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_ES.Location = new System.Drawing.Point(75, 38);
            this.checkBox_ES.Name = "checkBox_ES";
            this.checkBox_ES.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ES.TabIndex = 139;
            this.checkBox_ES.UseVisualStyleBackColor = true;
            // 
            // checkBox_EV
            // 
            this.checkBox_EV.AutoSize = true;
            this.checkBox_EV.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_EV.Location = new System.Drawing.Point(134, 38);
            this.checkBox_EV.Name = "checkBox_EV";
            this.checkBox_EV.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EV.TabIndex = 140;
            this.checkBox_EV.UseVisualStyleBackColor = true;
            // 
            // checkBox_IV
            // 
            this.checkBox_IV.AutoSize = true;
            this.checkBox_IV.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_IV.Location = new System.Drawing.Point(296, 38);
            this.checkBox_IV.Name = "checkBox_IV";
            this.checkBox_IV.Size = new System.Drawing.Size(15, 14);
            this.checkBox_IV.TabIndex = 141;
            this.checkBox_IV.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ch_lock);
            this.groupBox11.Controls.Add(this.ch_Path);
            this.groupBox11.Controls.Add(this.label_ONOFF);
            this.groupBox11.Controls.Add(this.numeric_VAr);
            this.groupBox11.Controls.Add(this.label_IV);
            this.groupBox11.Controls.Add(this.trackBar_VAr);
            this.groupBox11.Controls.Add(this.checkBox_scoo);
            this.groupBox11.Controls.Add(this.label_V);
            this.groupBox11.Controls.Add(this.label_S);
            this.groupBox11.Controls.Add(this.checkBox_VAr);
            this.groupBox11.Controls.Add(this.label_H);
            this.groupBox11.Controls.Add(this.label55);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.btn_resetHSV);
            this.groupBox11.Controls.Add(this.checkBox_IV);
            this.groupBox11.Controls.Add(this.trackBar_VL);
            this.groupBox11.Controls.Add(this.checkBox_EV);
            this.groupBox11.Controls.Add(this.trackBar_SL);
            this.groupBox11.Controls.Add(this.checkBox_ES);
            this.groupBox11.Controls.Add(this.trackBar_HL);
            this.groupBox11.Controls.Add(this.checkBox_EH);
            this.groupBox11.Controls.Add(this.trackBar_VH);
            this.groupBox11.Controls.Add(this.trackBar_SH);
            this.groupBox11.Controls.Add(this.trackBar_HH);
            this.groupBox11.Controls.Add(this.numericHH);
            this.groupBox11.Controls.Add(this.numericVL);
            this.groupBox11.Controls.Add(this.numericSL);
            this.groupBox11.Controls.Add(this.numericSH);
            this.groupBox11.Controls.Add(this.numericHL);
            this.groupBox11.Controls.Add(this.numericVH);
            this.groupBox11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox11.Location = new System.Drawing.Point(610, 5);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(326, 307);
            this.groupBox11.TabIndex = 143;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "HSV Value And Mark Detection";
            // 
            // ch_lock
            // 
            this.ch_lock.AutoSize = true;
            this.ch_lock.Location = new System.Drawing.Point(264, 132);
            this.ch_lock.Name = "ch_lock";
            this.ch_lock.Size = new System.Drawing.Size(56, 21);
            this.ch_lock.TabIndex = 151;
            this.ch_lock.Text = "Lock";
            this.ch_lock.UseVisualStyleBackColor = true;
            // 
            // ch_Path
            // 
            this.ch_Path.AutoSize = true;
            this.ch_Path.Location = new System.Drawing.Point(263, 164);
            this.ch_Path.Name = "ch_Path";
            this.ch_Path.Size = new System.Drawing.Size(55, 21);
            this.ch_Path.TabIndex = 76;
            this.ch_Path.Text = "Path";
            this.ch_Path.UseVisualStyleBackColor = true;
            // 
            // label_ONOFF
            // 
            this.label_ONOFF.AutoSize = true;
            this.label_ONOFF.Location = new System.Drawing.Point(206, 21);
            this.label_ONOFF.Name = "label_ONOFF";
            this.label_ONOFF.Size = new System.Drawing.Size(61, 17);
            this.label_ONOFF.TabIndex = 150;
            this.label_ONOFF.Text = "ON/OFF";
            // 
            // label_IV
            // 
            this.label_IV.AutoSize = true;
            this.label_IV.Location = new System.Drawing.Point(293, 21);
            this.label_IV.Name = "label_IV";
            this.label_IV.Size = new System.Drawing.Size(21, 17);
            this.label_IV.TabIndex = 149;
            this.label_IV.Text = "IV";
            // 
            // label_V
            // 
            this.label_V.AutoSize = true;
            this.label_V.Location = new System.Drawing.Point(133, 21);
            this.label_V.Name = "label_V";
            this.label_V.Size = new System.Drawing.Size(17, 17);
            this.label_V.TabIndex = 148;
            this.label_V.Text = "V";
            // 
            // label_S
            // 
            this.label_S.AutoSize = true;
            this.label_S.Location = new System.Drawing.Point(74, 21);
            this.label_S.Name = "label_S";
            this.label_S.Size = new System.Drawing.Size(16, 17);
            this.label_S.TabIndex = 147;
            this.label_S.Text = "S";
            // 
            // label_H
            // 
            this.label_H.AutoSize = true;
            this.label_H.Location = new System.Drawing.Point(19, 21);
            this.label_H.Name = "label_H";
            this.label_H.Size = new System.Drawing.Size(18, 17);
            this.label_H.TabIndex = 146;
            this.label_H.Text = "H";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(172, 181);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(34, 17);
            this.label55.TabIndex = 145;
            this.label55.Text = "Low";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(171, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 144;
            this.label15.Text = "High";
            // 
            // btn_resetHSV
            // 
            this.btn_resetHSV.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_resetHSV.Location = new System.Drawing.Point(212, 272);
            this.btn_resetHSV.Name = "btn_resetHSV";
            this.btn_resetHSV.Size = new System.Drawing.Size(106, 23);
            this.btn_resetHSV.TabIndex = 143;
            this.btn_resetHSV.Text = "ResetValue";
            this.btn_resetHSV.UseVisualStyleBackColor = true;
            this.btn_resetHSV.Click += new System.EventHandler(this.btn_resetHSV_Click);
            // 
            // trackBar_VL
            // 
            this.trackBar_VL.AutoSize = false;
            this.trackBar_VL.Location = new System.Drawing.Point(124, 202);
            this.trackBar_VL.Maximum = 255;
            this.trackBar_VL.Name = "trackBar_VL";
            this.trackBar_VL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_VL.Size = new System.Drawing.Size(40, 95);
            this.trackBar_VL.TabIndex = 142;
            this.trackBar_VL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_VL.Value = 170;
            this.trackBar_VL.Scroll += new System.EventHandler(this.trackBar_VL_Scroll);
            // 
            // trackBar_SL
            // 
            this.trackBar_SL.AutoSize = false;
            this.trackBar_SL.Location = new System.Drawing.Point(68, 202);
            this.trackBar_SL.Maximum = 255;
            this.trackBar_SL.Name = "trackBar_SL";
            this.trackBar_SL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_SL.Size = new System.Drawing.Size(40, 95);
            this.trackBar_SL.TabIndex = 141;
            this.trackBar_SL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_SL.Value = 160;
            this.trackBar_SL.Scroll += new System.EventHandler(this.trackBar_SL_Scroll);
            // 
            // trackBar_HL
            // 
            this.trackBar_HL.AutoSize = false;
            this.trackBar_HL.Location = new System.Drawing.Point(12, 202);
            this.trackBar_HL.Maximum = 179;
            this.trackBar_HL.Name = "trackBar_HL";
            this.trackBar_HL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_HL.Size = new System.Drawing.Size(40, 95);
            this.trackBar_HL.TabIndex = 140;
            this.trackBar_HL.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_HL.Scroll += new System.EventHandler(this.trackBar_HL_Scroll);
            // 
            // trackBar_VH
            // 
            this.trackBar_VH.AutoSize = false;
            this.trackBar_VH.Location = new System.Drawing.Point(124, 79);
            this.trackBar_VH.Maximum = 255;
            this.trackBar_VH.Name = "trackBar_VH";
            this.trackBar_VH.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_VH.Size = new System.Drawing.Size(40, 95);
            this.trackBar_VH.TabIndex = 139;
            this.trackBar_VH.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_VH.Value = 255;
            this.trackBar_VH.Scroll += new System.EventHandler(this.trackBar_VH_Scroll);
            // 
            // trackBar_SH
            // 
            this.trackBar_SH.AutoSize = false;
            this.trackBar_SH.Location = new System.Drawing.Point(68, 79);
            this.trackBar_SH.Maximum = 255;
            this.trackBar_SH.Name = "trackBar_SH";
            this.trackBar_SH.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_SH.Size = new System.Drawing.Size(40, 95);
            this.trackBar_SH.TabIndex = 138;
            this.trackBar_SH.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_SH.Value = 255;
            this.trackBar_SH.Scroll += new System.EventHandler(this.trackBar_SH_Scroll);
            // 
            // ComboBoxCameraList1
            // 
            this.ComboBoxCameraList1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxCameraList1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComboBoxCameraList1.FormattingEnabled = true;
            this.ComboBoxCameraList1.Location = new System.Drawing.Point(5, 965);
            this.ComboBoxCameraList1.Name = "ComboBoxCameraList1";
            this.ComboBoxCameraList1.Size = new System.Drawing.Size(248, 25);
            this.ComboBoxCameraList1.TabIndex = 150;
            // 
            // btn_web2
            // 
            this.btn_web2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_web2.Location = new System.Drawing.Point(259, 965);
            this.btn_web2.Name = "btn_web2";
            this.btn_web2.Size = new System.Drawing.Size(106, 26);
            this.btn_web2.TabIndex = 151;
            this.btn_web2.Text = "Open Camera";
            this.btn_web2.UseVisualStyleBackColor = true;
            this.btn_web2.Click += new System.EventHandler(this.btn_web2_Click);
            // 
            // btn_recordW2
            // 
            this.btn_recordW2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_recordW2.Location = new System.Drawing.Point(371, 965);
            this.btn_recordW2.Name = "btn_recordW2";
            this.btn_recordW2.Size = new System.Drawing.Size(106, 26);
            this.btn_recordW2.TabIndex = 152;
            this.btn_recordW2.Text = "Record";
            this.btn_recordW2.UseVisualStyleBackColor = true;
            // 
            // ComboBoxCameraList
            // 
            this.ComboBoxCameraList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxCameraList.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComboBoxCameraList.FormattingEnabled = true;
            this.ComboBoxCameraList.Location = new System.Drawing.Point(5, 465);
            this.ComboBoxCameraList.Name = "ComboBoxCameraList";
            this.ComboBoxCameraList.Size = new System.Drawing.Size(254, 25);
            this.ComboBoxCameraList.TabIndex = 153;
            // 
            // btn_web1
            // 
            this.btn_web1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_web1.Location = new System.Drawing.Point(265, 465);
            this.btn_web1.Name = "btn_web1";
            this.btn_web1.Size = new System.Drawing.Size(106, 26);
            this.btn_web1.TabIndex = 154;
            this.btn_web1.Text = "Open Camera";
            this.btn_web1.UseVisualStyleBackColor = true;
            this.btn_web1.Click += new System.EventHandler(this.btn_web1_Click);
            // 
            // btn_recordW1
            // 
            this.btn_recordW1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_recordW1.Location = new System.Drawing.Point(377, 465);
            this.btn_recordW1.Name = "btn_recordW1";
            this.btn_recordW1.Size = new System.Drawing.Size(106, 26);
            this.btn_recordW1.TabIndex = 155;
            this.btn_recordW1.Text = "Record";
            this.btn_recordW1.UseVisualStyleBackColor = true;
            // 
            // chart_Data
            // 
            this.chart_Data.BorderlineWidth = 2;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea1.BorderColor = System.Drawing.Color.Salmon;
            chartArea1.Name = "ChartArea1";
            this.chart_Data.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Name = "Legend1";
            this.chart_Data.Legends.Add(legend1);
            this.chart_Data.Location = new System.Drawing.Point(942, 656);
            this.chart_Data.Name = "chart_Data";
            this.chart_Data.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series2.YValuesPerPoint = 6;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series3.YValuesPerPoint = 6;
            this.chart_Data.Series.Add(series1);
            this.chart_Data.Series.Add(series2);
            this.chart_Data.Series.Add(series3);
            this.chart_Data.Size = new System.Drawing.Size(679, 347);
            this.chart_Data.TabIndex = 157;
            this.chart_Data.Text = "chart2";
            title1.Name = "Title1";
            this.chart_Data.Titles.Add(title1);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.groupBox21);
            this.groupBox18.Controls.Add(this.groupBox20);
            this.groupBox18.Controls.Add(this.checkBox_NRT);
            this.groupBox18.Controls.Add(this.checkBox_RT);
            this.groupBox18.Controls.Add(this.groupBox19);
            this.groupBox18.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox18.Location = new System.Drawing.Point(1627, 650);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(265, 340);
            this.groupBox18.TabIndex = 158;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Conrtol Data Chart";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.checkBox_showvel);
            this.groupBox21.Controls.Add(this.label67);
            this.groupBox21.Controls.Add(this.checkBox_M3V);
            this.groupBox21.Controls.Add(this.checkBox_M2V);
            this.groupBox21.Controls.Add(this.checkBox_M1V);
            this.groupBox21.Location = new System.Drawing.Point(14, 201);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox21.Size = new System.Drawing.Size(240, 90);
            this.groupBox21.TabIndex = 165;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Velocity";
            // 
            // checkBox_showvel
            // 
            this.checkBox_showvel.AutoSize = true;
            this.checkBox_showvel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_showvel.Location = new System.Drawing.Point(218, 42);
            this.checkBox_showvel.Name = "checkBox_showvel";
            this.checkBox_showvel.Size = new System.Drawing.Size(15, 14);
            this.checkBox_showvel.TabIndex = 4;
            this.checkBox_showvel.UseVisualStyleBackColor = true;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label67.Location = new System.Drawing.Point(104, 39);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(92, 17);
            this.label67.TabIndex = 3;
            this.label67.Text = "Show Velocity";
            // 
            // checkBox_M3V
            // 
            this.checkBox_M3V.AutoSize = true;
            this.checkBox_M3V.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M3V.Location = new System.Drawing.Point(15, 63);
            this.checkBox_M3V.Name = "checkBox_M3V";
            this.checkBox_M3V.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M3V.TabIndex = 2;
            this.checkBox_M3V.Text = "Motor 3";
            this.checkBox_M3V.UseVisualStyleBackColor = true;
            // 
            // checkBox_M2V
            // 
            this.checkBox_M2V.AutoSize = true;
            this.checkBox_M2V.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M2V.Location = new System.Drawing.Point(15, 39);
            this.checkBox_M2V.Name = "checkBox_M2V";
            this.checkBox_M2V.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M2V.TabIndex = 1;
            this.checkBox_M2V.Text = "Motor 2";
            this.checkBox_M2V.UseVisualStyleBackColor = true;
            // 
            // checkBox_M1V
            // 
            this.checkBox_M1V.AutoSize = true;
            this.checkBox_M1V.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M1V.Location = new System.Drawing.Point(15, 15);
            this.checkBox_M1V.Name = "checkBox_M1V";
            this.checkBox_M1V.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M1V.TabIndex = 0;
            this.checkBox_M1V.Text = "Motor 1";
            this.checkBox_M1V.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label61);
            this.groupBox20.Controls.Add(this.checkBox_showde);
            this.groupBox20.Controls.Add(this.checkBox_M1D);
            this.groupBox20.Controls.Add(this.checkBox_M2D);
            this.groupBox20.Controls.Add(this.checkBox_M3D);
            this.groupBox20.Location = new System.Drawing.Point(13, 110);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox20.Size = new System.Drawing.Size(240, 90);
            this.groupBox20.TabIndex = 164;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Degree";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label61.Location = new System.Drawing.Point(104, 39);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(88, 17);
            this.label61.TabIndex = 7;
            this.label61.Text = "Show Degree";
            // 
            // checkBox_showde
            // 
            this.checkBox_showde.AutoSize = true;
            this.checkBox_showde.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_showde.Location = new System.Drawing.Point(218, 42);
            this.checkBox_showde.Name = "checkBox_showde";
            this.checkBox_showde.Size = new System.Drawing.Size(15, 14);
            this.checkBox_showde.TabIndex = 6;
            this.checkBox_showde.UseVisualStyleBackColor = true;
            // 
            // checkBox_M1D
            // 
            this.checkBox_M1D.AutoSize = true;
            this.checkBox_M1D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M1D.Location = new System.Drawing.Point(15, 15);
            this.checkBox_M1D.Name = "checkBox_M1D";
            this.checkBox_M1D.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M1D.TabIndex = 3;
            this.checkBox_M1D.Text = "Motor 1";
            this.checkBox_M1D.UseVisualStyleBackColor = true;
            // 
            // checkBox_M2D
            // 
            this.checkBox_M2D.AutoSize = true;
            this.checkBox_M2D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M2D.Location = new System.Drawing.Point(15, 39);
            this.checkBox_M2D.Name = "checkBox_M2D";
            this.checkBox_M2D.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M2D.TabIndex = 4;
            this.checkBox_M2D.Text = "Motor 2";
            this.checkBox_M2D.UseVisualStyleBackColor = true;
            // 
            // checkBox_M3D
            // 
            this.checkBox_M3D.AutoSize = true;
            this.checkBox_M3D.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_M3D.Location = new System.Drawing.Point(15, 63);
            this.checkBox_M3D.Name = "checkBox_M3D";
            this.checkBox_M3D.Size = new System.Drawing.Size(77, 21);
            this.checkBox_M3D.TabIndex = 5;
            this.checkBox_M3D.Text = "Motor 3";
            this.checkBox_M3D.UseVisualStyleBackColor = true;
            // 
            // checkBox_NRT
            // 
            this.checkBox_NRT.AutoSize = true;
            this.checkBox_NRT.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_NRT.Location = new System.Drawing.Point(15, 304);
            this.checkBox_NRT.Name = "checkBox_NRT";
            this.checkBox_NRT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_NRT.Size = new System.Drawing.Size(130, 23);
            this.checkBox_NRT.TabIndex = 163;
            this.checkBox_NRT.Text = "Non Real Time";
            this.checkBox_NRT.UseVisualStyleBackColor = true;
            // 
            // checkBox_RT
            // 
            this.checkBox_RT.AutoSize = true;
            this.checkBox_RT.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_RT.Location = new System.Drawing.Point(157, 304);
            this.checkBox_RT.Name = "checkBox_RT";
            this.checkBox_RT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_RT.Size = new System.Drawing.Size(96, 23);
            this.checkBox_RT.TabIndex = 162;
            this.checkBox_RT.Text = "Real Time";
            this.checkBox_RT.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label60);
            this.groupBox19.Controls.Add(this.checkBox_showcoo);
            this.groupBox19.Controls.Add(this.checkBox_XAxis);
            this.groupBox19.Controls.Add(this.checkBox_YAxis);
            this.groupBox19.Controls.Add(this.checkBox_ZAxis);
            this.groupBox19.Location = new System.Drawing.Point(13, 19);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox19.Size = new System.Drawing.Size(240, 90);
            this.groupBox19.TabIndex = 161;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Coordinate";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label60.Location = new System.Drawing.Point(104, 39);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(112, 17);
            this.label60.TabIndex = 4;
            this.label60.Text = "Show Coordinate";
            // 
            // checkBox_showcoo
            // 
            this.checkBox_showcoo.AutoSize = true;
            this.checkBox_showcoo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_showcoo.Location = new System.Drawing.Point(218, 42);
            this.checkBox_showcoo.Name = "checkBox_showcoo";
            this.checkBox_showcoo.Size = new System.Drawing.Size(15, 14);
            this.checkBox_showcoo.TabIndex = 3;
            this.checkBox_showcoo.UseVisualStyleBackColor = true;
            // 
            // checkBox_XAxis
            // 
            this.checkBox_XAxis.AutoSize = true;
            this.checkBox_XAxis.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_XAxis.Location = new System.Drawing.Point(15, 15);
            this.checkBox_XAxis.Name = "checkBox_XAxis";
            this.checkBox_XAxis.Size = new System.Drawing.Size(77, 21);
            this.checkBox_XAxis.TabIndex = 0;
            this.checkBox_XAxis.Text = "X      Axis";
            this.checkBox_XAxis.UseVisualStyleBackColor = true;
            // 
            // checkBox_YAxis
            // 
            this.checkBox_YAxis.AutoSize = true;
            this.checkBox_YAxis.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_YAxis.Location = new System.Drawing.Point(15, 39);
            this.checkBox_YAxis.Name = "checkBox_YAxis";
            this.checkBox_YAxis.Size = new System.Drawing.Size(77, 21);
            this.checkBox_YAxis.TabIndex = 1;
            this.checkBox_YAxis.Text = "Y      Axis";
            this.checkBox_YAxis.UseVisualStyleBackColor = true;
            // 
            // checkBox_ZAxis
            // 
            this.checkBox_ZAxis.AutoSize = true;
            this.checkBox_ZAxis.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_ZAxis.Location = new System.Drawing.Point(15, 63);
            this.checkBox_ZAxis.Name = "checkBox_ZAxis";
            this.checkBox_ZAxis.Size = new System.Drawing.Size(77, 21);
            this.checkBox_ZAxis.TabIndex = 2;
            this.checkBox_ZAxis.Text = "Z      Axis";
            this.checkBox_ZAxis.UseVisualStyleBackColor = true;
            // 
            // textBox_executiontime
            // 
            this.textBox_executiontime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_executiontime.Location = new System.Drawing.Point(734, 976);
            this.textBox_executiontime.Name = "textBox_executiontime";
            this.textBox_executiontime.Size = new System.Drawing.Size(202, 25);
            this.textBox_executiontime.TabIndex = 159;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btn_saveroi_1
            // 
            this.btn_saveroi_1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_saveroi_1.Location = new System.Drawing.Point(491, 465);
            this.btn_saveroi_1.Name = "btn_saveroi_1";
            this.btn_saveroi_1.Size = new System.Drawing.Size(106, 26);
            this.btn_saveroi_1.TabIndex = 161;
            this.btn_saveroi_1.Text = "Save Image";
            this.btn_saveroi_1.UseVisualStyleBackColor = true;
            this.btn_saveroi_1.Click += new System.EventHandler(this.btn_saveroi_1_Click);
            // 
            // btn_saveroi_2
            // 
            this.btn_saveroi_2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_saveroi_2.Location = new System.Drawing.Point(491, 965);
            this.btn_saveroi_2.Name = "btn_saveroi_2";
            this.btn_saveroi_2.Size = new System.Drawing.Size(106, 26);
            this.btn_saveroi_2.TabIndex = 162;
            this.btn_saveroi_2.Text = "Save Image";
            this.btn_saveroi_2.UseVisualStyleBackColor = true;
            this.btn_saveroi_2.Click += new System.EventHandler(this.btn_saveroi_2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.btn_saveroi_2);
            this.Controls.Add(this.btn_saveroi_1);
            this.Controls.Add(this.textBox_executiontime);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.chart_Data);
            this.Controls.Add(this.ComboBoxCameraList);
            this.Controls.Add(this.btn_web1);
            this.Controls.Add(this.btn_recordW1);
            this.Controls.Add(this.ComboBoxCameraList1);
            this.Controls.Add(this.btn_web2);
            this.Controls.Add(this.btn_recordW2);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.webcam_2_ori);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.webcam_1_ori);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button_ExitProgram);
            this.Controls.Add(this.groupBox_robotarm);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Processing and Simplex Method on the Tracking Control of  Robots";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_Motor1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox_robotarm.ResumeLayout(false);
            this.groupBox_robotarm.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VAr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VAr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam_1_ori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam_2_ori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HH)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_VH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Data)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //------000------//

        DEV_LIST[] CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES];
        uint deviceCount = 0;
        uint DeviceNum = 0;
        IntPtr m_DeviceHandle = IntPtr.Zero;
        IntPtr[] m_Axishand = new IntPtr[32];
        IntPtr m_GpHand = IntPtr.Zero;
        uint m_ulAxisCount = 0;             
        bool m_bInit = false;
        bool m_bServoOn = false;
        uint AxCountInGp = 0;

        uint[] AxEnableEvtArray = new uint[32];
        uint[] GpEnableEvt = new uint[32];

        uint[] m_AxCmpEvtCnt = new uint[32];
        uint[] m_AxDoneEvtCnt = new uint[32];
        uint[] m_AxVHStartCnt = new uint[32];
        uint[] m_AxVHEndCnt = new uint[32];
        uint[] m_AxLatchBufCnt = new uint[32];
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_State_M2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tb_Pos_M1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button bu_perform_I;
        private System.Windows.Forms.TextBox TB_Z_I;
        private System.Windows.Forms.TextBox TB_Y_I;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox TB_X_I;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bu_perform_D;
        private System.Windows.Forms.TextBox TB_Motor3_D;
        private System.Windows.Forms.TextBox TB_Motor2_D;
        private System.Windows.Forms.TextBox TB_Motor1_D;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button_ExitProgram;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox TB_ZCPosition;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox TB_YCPosition;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox TB_XCPosition;
        private System.Windows.Forms.TextBox TB_M1CDegree;
        private System.Windows.Forms.TextBox TB_M2CDegree;
        private System.Windows.Forms.TextBox TB_M3CDegree;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox TB_Vel_M1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TB_State_M3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TB_Pos_M3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_State_M1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_Pos_M2;
        private System.Windows.Forms.TextBox TB_Vel_M3;
        private System.Windows.Forms.TextBox TB_Vel_M2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_SetParam;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioButtonAbs;
        private System.Windows.Forms.RadioButton radioButtonRel;
        private System.Windows.Forms.GroupBox groupBox13;
        public System.Windows.Forms.RadioButton rdb_S;
        public System.Windows.Forms.RadioButton rdb_T;
        private System.Windows.Forms.TextBox TB_FB_M3;
        private System.Windows.Forms.TextBox TB_FB_M1;
        private System.Windows.Forms.TextBox TB_FB_M2;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox textBoxDec;
        private System.Windows.Forms.TextBox textBoxAcc;
        private System.Windows.Forms.TextBox textBoxVelH;
        private System.Windows.Forms.TextBox textBoxVelL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ComboBox CmbAvailableDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_regulate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnServo;
        private System.Windows.Forms.Button BtnOpenBoard;
        private System.Windows.Forms.GroupBox groupBox_robotarm;
        private System.Windows.Forms.CheckBox checkBox_;
        private System.Windows.Forms.CheckBox checkBox_regulate;
        private System.Windows.Forms.TextBox Limit_Up;
        private System.Windows.Forms.TextBox Limit_Down;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox CmbAxes;
        private System.Windows.Forms.Label label_robotAxis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button button_SavePath;
        private System.Windows.Forms.ComboBox comboBox_track;
        private System.Windows.Forms.TextBox textBox_PartNum;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button button_SearchPath;
        private System.Windows.Forms.TextBox textBox_FYv;
        private System.Windows.Forms.TextBox textBox_FXv;
        private System.Windows.Forms.Label label_FYv;
        private System.Windows.Forms.Label label_FXv;
        private System.Windows.Forms.TextBox textBox_FYu;
        private System.Windows.Forms.Label label_FYu;
        private System.Windows.Forms.Label label_FXu;
        private System.Windows.Forms.TextBox textBox_FXu;
        private System.Windows.Forms.Button button_ClearPos;
        private System.Windows.Forms.TextBox textBox_IYv;
        private System.Windows.Forms.TextBox textBox_IXv;
        private System.Windows.Forms.Label label_IYv;
        private System.Windows.Forms.Label label_IXv;
        private System.Windows.Forms.TextBox textBox_IYu;
        private System.Windows.Forms.Label label_IYu;
        private System.Windows.Forms.Label label_IXu;
        private System.Windows.Forms.TextBox textBox_IXu;
        private System.Windows.Forms.Button button_InitialAndFinish;
        private System.Windows.Forms.Button button_InverseSTOP;
        private System.Windows.Forms.Button button_DirectSTOP;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog4;
        private System.Windows.Forms.CheckBox CB_AxisLOCK;
        private System.Windows.Forms.Button button_Motion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_Curve;
        private System.Windows.Forms.Button button_recordpoint;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_m2motion;
        private System.Windows.Forms.Button button_searchpathmt;
        private System.Windows.Forms.TextBox textBox_pointnum;
        private System.Windows.Forms.Label label_Yv;
        private System.Windows.Forms.Label label_Xv;
        private System.Windows.Forms.Label label_Yu;
        private System.Windows.Forms.Label label_Xu;
        private System.Windows.Forms.TextBox textBox_m2Yv;
        private System.Windows.Forms.TextBox textBox_m2Xv;
        private System.Windows.Forms.TextBox textBox_m2Yu;
        private System.Windows.Forms.TextBox textBox_m2Xu;
        private System.Windows.Forms.Label label_pointnum;
        private System.Windows.Forms.Button button_m2savepath;
        private System.Windows.Forms.TextBox textBox_PartNum2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pointset;
        private System.Windows.Forms.Label label_pointset;
        private System.Windows.Forms.Button button_openfile2;
        private System.Windows.Forms.Timer timer_up_1;
        private System.Windows.Forms.Timer timer_up_2;
        private System.Windows.Forms.Timer timer_down_1;
        private System.Windows.Forms.Timer timer_down_2;
        private System.Windows.Forms.Timer timer_right_1;
        private System.Windows.Forms.Timer timer_right_2;
        private System.Windows.Forms.Timer timer_left_1;
        private System.Windows.Forms.Timer timer_left_2;
        private System.Windows.Forms.Timer timer_forward_1;
        private System.Windows.Forms.Timer timer_forward_2;
        private System.Windows.Forms.Timer timer_backward_1;
        private System.Windows.Forms.Timer timer_backward_2;
        private System.Windows.Forms.Button button_curve2;
        private System.Windows.Forms.TextBox TBox_mmsec;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.CheckBox checkBox_VAr;
        private System.Windows.Forms.TrackBar trackBar_VAr;
        private System.Windows.Forms.PictureBox webcam_1_ori;
        private System.Windows.Forms.PictureBox webcam_2_ori;
        private System.Windows.Forms.NumericUpDown numericHH;
        private System.Windows.Forms.NumericUpDown numericSH;
        private System.Windows.Forms.NumericUpDown numericVH;
        private System.Windows.Forms.NumericUpDown numericVL;
        private System.Windows.Forms.NumericUpDown numericHL;
        private System.Windows.Forms.NumericUpDown numericSL;
        private System.Windows.Forms.NumericUpDown numeric_VAr;
        private System.Windows.Forms.TrackBar trackBar_HH;
        private System.Windows.Forms.CheckBox checkBox_EH;
        private System.Windows.Forms.CheckBox checkBox_ES;
        private System.Windows.Forms.CheckBox checkBox_EV;
        private System.Windows.Forms.CheckBox checkBox_IV;
        private System.Windows.Forms.CheckBox checkBox_scoo;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TrackBar trackBar_VH;
        private System.Windows.Forms.TrackBar trackBar_SH;
        private System.Windows.Forms.TrackBar trackBar_VL;
        private System.Windows.Forms.TrackBar trackBar_SL;
        private System.Windows.Forms.TrackBar trackBar_HL;
        private System.Windows.Forms.Button btn_resetHSV;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox CB_XYLOCK;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox checkBox_fixmm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picB_Motor3;
        private System.Windows.Forms.PictureBox picB_Motor2;
        private System.Windows.Forms.PictureBox picB_Motor1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox ComboBoxCameraList1;
        private System.Windows.Forms.Button btn_web2;
        private System.Windows.Forms.Button btn_recordW2;
        private System.Windows.Forms.ComboBox ComboBoxCameraList;
        private System.Windows.Forms.Button btn_web1;
        private System.Windows.Forms.Button btn_recordW1;
        private System.Windows.Forms.Label label_V;
        private System.Windows.Forms.Label label_S;
        private System.Windows.Forms.Label label_H;
        private System.Windows.Forms.Label label_IV;
        private System.Windows.Forms.Label label_ONOFF;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Data;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.CheckBox checkBox_M3D;
        private System.Windows.Forms.CheckBox checkBox_M1D;
        private System.Windows.Forms.CheckBox checkBox_M2D;
        private System.Windows.Forms.CheckBox checkBox_ZAxis;
        private System.Windows.Forms.CheckBox checkBox_YAxis;
        private System.Windows.Forms.CheckBox checkBox_XAxis;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.CheckBox checkBox_showde;
        private System.Windows.Forms.CheckBox checkBox_NRT;
        private System.Windows.Forms.CheckBox checkBox_RT;
        private System.Windows.Forms.CheckBox checkBox_showcoo;
        private System.Windows.Forms.CheckBox checkBox_M3V;
        private System.Windows.Forms.CheckBox checkBox_M2V;
        private System.Windows.Forms.CheckBox checkBox_M1V;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.CheckBox checkBox_showvel;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox textBox_executiontime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_saveroi_1;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox TB_MotionT;
        private System.Windows.Forms.CheckBox checkBox_finsec;
        private System.Windows.Forms.Button btn_saveroi_2;
        private System.Windows.Forms.CheckBox ch_Path;
        private System.Windows.Forms.CheckBox ch_lock;
    }
}

