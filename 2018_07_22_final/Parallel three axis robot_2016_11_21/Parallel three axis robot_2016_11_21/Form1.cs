using Advantech.Motion; //Common Motion API
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; //For Marshal
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Parallel_three_axis_robot_2016_11_21
{


    #region Class Form1
    public partial class Form1 : Form
    {
        #region Setting Parameter
        //------宣告------//
        private static ManualResetEvent _ManualWait = new ManualResetEvent(false);
        int interval_rate = 60; // Timer Interval
        Capture cap = null;
        Capture cap1 = null;
        bool captureInPtogress;
        bool captureInPtogress1;
        Image<Bgr, Byte> Image = null;
        Image<Bgr, Byte> Image1 = null;
        Image<Gray, Byte> Image_g = null;
        Image<Gray, Byte> Image_g1 = null;
        Image<Gray, Byte> image_gg = null;
        Image<Gray, Byte> ImageFrameDetection = null;
        Image<Gray, Byte> ImageFrameDetection1 = null;
        int _CameraIndex;
        //HaarCascade
        //int diff_LH;
        int[] ReturnValue = new int[] { };
        Thread CheckEventThread;
        Boolean VersionIsOk = false;
        double[] P = new double[3]; //正運動_給定位置全域宣告  (宣告陣列_建立陣列語法)
        double T0, T1, T2; //逆運動_給定角度全域宣告
        double CmdPos_0, CmdPos_1, CmdPos_2; //給定CmdPos全域宣告
        double TTheta_1 = 0.0, TTheta_2 = 0.0, TTheta_3 = 0.0;   //加減速度用
        double TTX = 0.0, TTY = 0.0, TTZ = 0.0;            //加減速度用
        double AC;//Angle conversion
        double Lr, La, Lb, Lh;
        double ZLimit_up, ZLimit_down, Zinit;
        
        double[] Theta1 = new double[] { };
        double[] Theta2 = new double[] { };
        double[] Theta3 = new double[] { };

        double[] Theta1m2 = new double[] { };
        double[] Theta2m2 = new double[] { };
        double[] Theta3m2 = new double[] { };

        int Search_Standard = 0;
        int Ncount = 0;
        int Ncount_m = 0;
        double M1 = 0.0, M2 = 0.0, M3 = 0.0;
        double CX = 0.0, CY = 0.0, CZ = 0.0;
        double Vel_1 = 0.0, Vel_2 = 0.0, Vel_3 = 0.0;

        int[][] RecordPoint = new int[14][] { new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 },
                                              new[] { 0, 0, 0, 0 }
                                            };
        int recordpoint_num = 0;

        double MMSEC = 0.0;
        double FIXT = 0.0;
        double M1_Pos = new double(); double M2_Pos = new double(); double M3_Pos = new double();
        double M1_Vel = new double(); double M2_Vel = new double(); double M3_Vel = new double();
        double M1_CurCmd = new double(); double M2_CurCmd = new double(); double M3_CurCmd = new double();
        UInt16 M1_AxState = 0; UInt16 M2_AxState = 0; UInt16 M3_AxState = 0;
        int X_Time =0;
        public List<StoreObjectpotion> Object = new List<StoreObjectpotion>();
        public List<StoreObjectpotion> Object2 = new List<StoreObjectpotion>();
        bool Chart_Flag = false;
        double PT = 0.0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            //Skin = new Sunisoft.IrisSkin.SkinEngine();
            //Skin.SkinFile = @"C:\Users\Lab326\Desktop\新增資料夾 (2)\Skins\MacOS.ssk"; //路徑請自行更改
            //Skin.SkinAllForm = true; //系統下所有Form都改為該Skin
            VersionIsOk = GetDevCfgDllDrvVer(); //Get Driver Version Number, this step is not necessary     
            camera_list();
            Track_list();
            //在多螢幕的情況下選出螢幕最大的顯現
            ChooseTheBiggestScreen();
            picB_Motor_2circle();
            

        }
        //計時器(更新介面數值)
        #region Timer1_Tick
        private async void timer1_Tick(object sender, EventArgs e)
        {
            //DEGREE STOP         
            UInt32 Result;
            UInt16 GpState = 0;
            UInt32 IOStatus = new UInt32();

            if (m_bInit)
            {
                //Get the motion I/O status of the axis.
                Result = Motion.mAcm_AxGetMotionIO(m_Axishand[CmbAxes.SelectedIndex], ref IOStatus);
                if (Result == (uint)ErrorCode.SUCCESS)
                { GetMotionIOStatus(IOStatus); }

                //Get current當前 command position of the specified指定 axis
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_CurCmd);
                Tb_Pos_M1.Text = Convert.ToString(M1_CurCmd);
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_CurCmd);
                TB_Pos_M2.Text = Convert.ToString(M2_CurCmd);
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_CurCmd);
                TB_Pos_M3.Text = Convert.ToString(M3_CurCmd);
                //textBoxAxDoneCnt_R.Text = Convert.ToString(m_AxDoneEvtCnt[CmbAxes.FindStringExact("2-Axis")]);
                //textBoxAxDoneCnt_L.Text = Convert.ToString(m_AxDoneEvtCnt[CmbAxes.FindStringExact("0-Axis")]);
                //textBoxAxDoneCnt_M.Text = Convert.ToString(m_AxDoneEvtCnt[CmbAxes.FindStringExact("1-Axis")]);
                //textBoxVHStartCnt.Text = Convert.ToString(m_AxVHStartCnt[CmbAxes.SelectedIndex]);//達到最高速時觸發
                //textBoxVHEndCnt.Text = Convert.ToString(m_AxVHEndCnt[CmbAxes.SelectedIndex]);//開始減速時觸發
                //Get the axis's current state.
                Motion.mAcm_AxGetState(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_AxState);
                TB_State_M1.Text = ((AxisState)M1_AxState).ToString();
                Motion.mAcm_AxGetState(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_AxState);
                TB_State_M2.Text = ((AxisState)M2_AxState).ToString();
                Motion.mAcm_AxGetState(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_AxState);
                TB_State_M3.Text = ((AxisState)M3_AxState).ToString();

                if (TB_State_M1.Text != "STA_AX_READY" && TB_State_M2.Text != "STA_AX_READY" && TB_State_M3.Text != "STA_AX_READY")
                {
                    /*if (Chart_Flag == false)
                    {
                        chart_Data.Series[0].Points.Clear();
                        chart_Data.Series[1].Points.Clear();
                        chart_Data.Series[2].Points.Clear();
                    }*/
                    Chart_Flag = true;

                    //Console.WriteLine("Chart_Flag=" + Convert.ToString(Chart_Flag));
                }
                else
                {
                    Chart_Flag = false;
                    //Console.WriteLine("Chart_Flag=" + Convert.ToString(Chart_Flag));
                }


                if (m_GpHand != IntPtr.Zero)
                {
                    //Get the group's current state
                    Motion.mAcm_GpGetState(m_GpHand, ref GpState);
                    //textBoxGpState.Text = ((GroupState)GpState).ToString();
                    //textBoxGpDoneCnt.Text = Convert.ToString(m_GpDoneEvtCnt);
                    //textBoxGpVHStartCnt.Text = Convert.ToString(m_GpVHStartCnt);
                    //textBoxGpVHEndCnt.Text = Convert.ToString(m_GpVHEndCnt);
                }
                else
                {
                    //textBoxGpID.Text = "";
                    //textBoxAxesInGp.Text = "";
                    //textBoxGpDoneCnt.Text = "";
                    //textBoxGpState.Text = "";
                }
            }

            //Get actual position for the specified axis
            Motion.mAcm_AxGetActualPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_Pos);
            TB_FB_M1.Text = Convert.ToString(M1_Pos);
            Motion.mAcm_AxGetActualPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_Pos);
            TB_FB_M2.Text = Convert.ToString(M2_Pos);
            Motion.mAcm_AxGetActualPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_Pos);
            TB_FB_M3.Text = Convert.ToString(M3_Pos);

            //Get current command velocity of the specified axis
            //double CurVel = new double();
            //Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref CurVel);
            //textBoxVel.Text = Convert.ToString(CurVel);
            //Result = Motion.mAcm_GpMoveLinearRel(m_GpHand, Distance, ref Element);

            Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_Vel);
            TB_Vel_M1.Text = Convert.ToString(M1_Vel);
            Vel_1 = M1_Vel;
            Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_Vel);
            TB_Vel_M2.Text = Convert.ToString(M2_Vel);
            Vel_2 = M2_Vel;
            Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_Vel);
            TB_Vel_M3.Text = Convert.ToString(M3_Vel);
            Vel_3 = M3_Vel;
            MC_update();
            Update_chart();
            if (checkBox_regulate.Checked == true)
            {
                double STOP_R = Convert.ToDouble(TB_M1CDegree.Text);  //R 
                double STOP_POSR = Convert.ToDouble(Tb_Pos_M1.Text);
                //Boolean R;
                double STOP_L = Convert.ToDouble(TB_M2CDegree.Text);  //L
                double STOP_POSL = Convert.ToDouble(TB_Pos_M2.Text);
                //Boolean L;
                double STOP_M = Convert.ToDouble(TB_M3CDegree.Text);  //M
                double STOP_POSM = Convert.ToDouble(TB_Pos_M3.Text);
                //Boolean M;
                double Up = Convert.ToDouble(Limit_Up.Text);
                double Down = Convert.ToDouble(Limit_Down.Text);
                double A = 250000 / 90;   //( 250000/90=2777.777777777778)

                if (STOP_R <= Down && STOP_R >= Up && STOP_POSR <= -Up * A && STOP_POSR >= -Down * A)   //(-25000)
                {//R = true;
                    textBox26.Text = Convert.ToString("Within Limit");
                }
                else
                {//R = false;
                    Result = Motion.mAcm_AxStopEmg(m_Axishand[CmbAxes.FindStringExact("1-Axis")]);
                    textBox26.Text = Convert.ToString("Limit Exceeded");
                }

                if (STOP_L <= Down && STOP_L >= Up && STOP_POSL <= -Up * A && STOP_POSL >= -Down * A)  //(-250000)
                {//L = true;
                    textBox27.Text = Convert.ToString("Within Limit");
                }
                else
                {//L = false;
                    Result = Motion.mAcm_AxStopEmg(m_Axishand[CmbAxes.FindStringExact("0-Axis")]);
                    textBox27.Text = Convert.ToString("Limit Exceeded");
                }

                if (STOP_M <= Down && STOP_M >= Up && STOP_POSM <= -Up * A && STOP_POSM >= -Down * A)   //(-250000)
                {//M = true;
                    textBox28.Text = Convert.ToString("Within Limit");
                }
                else
                {//M = false;
                    Result = Motion.mAcm_AxStopEmg(m_Axishand[CmbAxes.FindStringExact("2-Axis")]);
                    textBox28.Text = Convert.ToString("Limit Exceeded");
                }
            }


            //Motion Done Event

            if (m_bInit)
            {
                AxEnableEvtArray[CmbAxes.FindStringExact("0-Axis")] |= (uint)EventType.EVT_AX_MOTION_DONE;
                AxEnableEvtArray[CmbAxes.FindStringExact("1-Axis")] |= (uint)EventType.EVT_AX_MOTION_DONE;
                AxEnableEvtArray[CmbAxes.FindStringExact("2-Axis")] |= (uint)EventType.EVT_AX_MOTION_DONE;
                Result = Motion.mAcm_EnableMotionEvent(m_DeviceHandle, AxEnableEvtArray, GpEnableEvt, m_ulAxisCount, 3);
            }
            MMSEC = Convert.ToDouble(TBox_mmsec.Text);
            FIXT = Convert.ToDouble(TB_MotionT.Text);
            check_Box_check();
            
            //count_Total_Time();
        }
        #endregion

      
        private async void timer2_Tick(object sender, EventArgs e)
        {
            this.textBox_executiontime.Text = DateTime.Now.ToString();
            //Console.WriteLine("2");
        }

        //追蹤路徑
        #region Track List
        public void Track_list()
        {
            List<cboDataList> Track_List = new List<cboDataList>()
            {
                new cboDataList
                {
                    cbo_Name = "None",
                    cbo_Value= "0"
                },
                new cboDataList
                {   //垂直線路徑
                    cbo_Name = "Vertical Line",
                    cbo_Value= "1"
                },
                new cboDataList
                {
                    //水平圓路徑
                    cbo_Name = "Horizontal Circle",
                    cbo_Value= "2"
                },
                new cboDataList
                {   //下降正方形
                    cbo_Name = "Falling Square",
                    cbo_Value= "3"
                },
                new cboDataList
                {
                    //水平正三角形
                    cbo_Name = "Regular Triangle ",
                    cbo_Value= "4"
                },
                new cboDataList
                {   
                    //螺旋下降
                    cbo_Name = "Falling Spiral",
                    cbo_Value= "5"
                }

            };

            comboBox_track.DataSource = Track_List;
            comboBox_track.DisplayMember = "cbo_Name";
            comboBox_track.ValueMember = "cbo_Value";
        }
        #endregion

        //追蹤路徑資料選擇
        private void Track_data()
        {
            Console.WriteLine(comboBox_track.SelectedValue);
            switch (Convert.ToInt32(comboBox_track.SelectedValue))
            {
                case 0:
                    MessageBox.Show("No");
                    break;

                case 1:
                    Vertical_line();
                    break;

                case 2:
                    Horizontal_circle(); 
                    break;

                case 3:
                    Falling_square();
                    break;

                case 4:
                    Regular_triangle();
                    break;

                case 5:
                    Spiral_drop();
                    break;

                default:
                    MessageBox.Show("Do Nothing");
                    break;
            }
        }

        //1. path list choose
        //2. Data store way and read data
        //3. Perform Data way delay ?  each motion point time
        //4. Go back orginal point way?
        
        //呼叫垂直線
        private void Vertical_line()
        {
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            Console.WriteLine("CT1");
            Thread t1 = new Thread(Vertical_Path);
            t1.Start();
          
            Console.WriteLine("CT1F");
        }
        //執行垂直線
        private void Vertical_Path()
        {
            //data 119
            StreamReader rm1 = new StreamReader(@"C:\5Path\P1_M1.txt");
            StreamReader rm2 = new StreamReader(@"C:\5Path\P1_M2.txt");
            StreamReader rm3 = new StreamReader(@"C:\5Path\P1_M3.txt");

                List<double> M1 = new List<double>();
                List<double> M2 = new List<double>();
                List<double> M3 = new List<double>();

                for (int i = 0; i < 119; i++)
                {
                    M1.Add(Convert.ToDouble(rm1.ReadLine()));
                    M2.Add(Convert.ToDouble(rm2.ReadLine()));
                    M3.Add(Convert.ToDouble(rm3.ReadLine()));
                    //Console.WriteLine("M1[{3:d}]= {0:f} M2[{3:d}] = {1:f} M3[{3:d}] = {2:f}", M1[i], M2[i], M3[i],i);
                }

                rm1.Close();
                rm2.Close();
                rm3.Close();

           Console.WriteLine("Data Read Finish");
           //PT = PT * 100;
           for (int k = 0; k < 119; k++)
           {
             Motor_Positive(M1[k], M2[k], M3[k]);
                    
             //Console.WriteLine("M1= {0:f} M2 = {1:f} M3 = {2:f}", M1[k], M2[k], M3[k]);
           }
               
           return;
        }

        //呼叫水平圓路徑
        private void Horizontal_circle()
        {
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            Thread.Sleep(100);
            Console.WriteLine("CT2");
            Thread t2 = new Thread(Horizontal_circle_Path);
            t2.Start();

            Console.WriteLine("CT2F");
        }
        //執行水平圓路徑
        private void Horizontal_circle_Path()
        {
            
            //147
            StreamReader rm1 = new StreamReader(@"C:\5Path\P2_M1.txt");
            StreamReader rm2 = new StreamReader(@"C:\5Path\P2_M2.txt");
            StreamReader rm3 = new StreamReader(@"C:\5Path\P2_M3.txt");

            List<double> M1 = new List<double>();
            List<double> M2 = new List<double>();
            List<double> M3 = new List<double>();

            for (int i = 0; i < 147; i++)
            {
                M1.Add(Convert.ToDouble(rm1.ReadLine()));
                M2.Add(Convert.ToDouble(rm2.ReadLine()));
                M3.Add(Convert.ToDouble(rm3.ReadLine()));
            }

            rm1.Close();
            rm2.Close();
            rm3.Close();

            Console.WriteLine("Data Read Finish");

            for (int k = 0; k < 147; k++)
            {
                Motor_Positive(M1[k], M2[k], M3[k]);
                //Console.WriteLine("M1= {0:f} M2 = {1:f} M3 = {2:f}", M1[k], M2[k], M3[k]);
            }

            return;
        }

        //呼叫下降正方形
        private void Falling_square()
        {
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            Console.WriteLine("CT3");
            Thread t3 = new Thread(Falling_square_Path);
            //t3.IsBackground = true;
            t3.Start();
           
            Console.WriteLine("CT3F");
        }
        //執行下降正方形
        private void Falling_square_Path()
        {
           //211
            StreamReader rm1 = new StreamReader(@"C:\5Path\P3_M1.txt");
            StreamReader rm2 = new StreamReader(@"C:\5Path\P3_M2.txt");
            StreamReader rm3 = new StreamReader(@"C:\5Path\P3_M3.txt");

            List<double> M1 = new List<double>();
            List<double> M2 = new List<double>();
            List<double> M3 = new List<double>();

            for (int i = 0; i <211 ; i++)
            {
                M1.Add(Convert.ToDouble(rm1.ReadLine()));
                M2.Add(Convert.ToDouble(rm2.ReadLine()));
                M3.Add(Convert.ToDouble(rm3.ReadLine()));
            }

            rm1.Close();
            rm2.Close();
            rm3.Close();

            Console.WriteLine("Data Read Finish");

            for (int k = 0; k <211 ; k++)
            {
                Motor_Positive(M1[k], M2[k], M3[k]);
                //Console.WriteLine("M1= {0:f} M2 = {1:f} M3 = {2:f}", M1[k], M2[k], M3[k]);
            }
            
            return;
        }
        
        //呼叫水平正三角形
        private void Regular_triangle()
        {
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            Console.WriteLine("CT4");
            Thread t4 = new Thread(Regular_Triangle_Path);
            t4.Start();

            Console.WriteLine("CT4F");
        }
       
        //執行水平正三角形
        private void Regular_Triangle_Path()
        {
            
            //165
            StreamReader rm1 = new StreamReader(@"C:\5Path\P4_M1.txt");
            StreamReader rm2 = new StreamReader(@"C:\5Path\P4_M2.txt");
            StreamReader rm3 = new StreamReader(@"C:\5Path\P4_M3.txt");

            List<double> M1 = new List<double>();
            List<double> M2 = new List<double>();
            List<double> M3 = new List<double>();

            for (int i = 0; i < 165; i++)
            {
                M1.Add(Convert.ToDouble(rm1.ReadLine()));
                M2.Add(Convert.ToDouble(rm2.ReadLine()));
                M3.Add(Convert.ToDouble(rm3.ReadLine()));
            }

            rm1.Close();
            rm2.Close();
            rm3.Close();

            Console.WriteLine("Data Read Finish");

            for (int k = 0; k < 165; k++)
            {
                Motor_Positive(M1[k], M2[k], M3[k]);
                //Console.WriteLine("M1= {0:f} M2 = {1:f} M3 = {2:f}", M1[k], M2[k], M3[k]);
            }

            return;
        }


        //呼叫螺旋下降
        private void Spiral_drop()
        {
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            Console.WriteLine("CT5");
            Thread t5 = new Thread(Spiral_drop_Path);
            t5.Start();

            Console.WriteLine("CT5F");
        }

        //執行螺旋下降
        private void Spiral_drop_Path()
        {
            //247
            StreamReader rm1 = new StreamReader(@"C:\5Path\P5_M1.txt");
            StreamReader rm2 = new StreamReader(@"C:\5Path\P5_M2.txt");
            StreamReader rm3 = new StreamReader(@"C:\5Path\P5_M3.txt");

            List<double> M1 = new List<double>();
            List<double> M2 = new List<double>();
            List<double> M3 = new List<double>();

            for (int i = 0; i < 247; i++)
            {
                M1.Add(Convert.ToDouble(rm1.ReadLine()));
                M2.Add(Convert.ToDouble(rm2.ReadLine()));
                M3.Add(Convert.ToDouble(rm3.ReadLine()));
            }

            rm1.Close();
            rm2.Close();
            rm3.Close();

            Console.WriteLine("Data Read Finish");

            for (int k = 0; k < 247; k++)
            {
                Motor_Positive(M1[k], M2[k], M3[k]);
               // Console.WriteLine("M1= {0:f} M2 = {1:f} M3 = {2:f}", M1[k], M2[k], M3[k]);
            }

            return;
        }

        //Motor status light signal
        #region Motor Light
        private void picB_Motor_2circle()
        {
            Rectangle r = new Rectangle(0, 0, picB_Motor1.Width, picB_Motor1.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = picB_Motor1.Width;
            int k = d - 1;
            gp.AddArc(r.X, r.Y, k, k, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, k, k, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, k, k, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, k, k, 90, 90);
            picB_Motor1.Region = new Region(gp);
            picB_Motor2.Region = new Region(gp);
            picB_Motor3.Region = new Region(gp);
        }
        #endregion

        //將介面投放置解析度最大的畫面
        #region Form1 Show in which Screen  

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ChooseTheBiggestScreen()
        {
            int count = 0;
            int max = 0;
            int Index = 0;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
            while (count < Screen.AllScreens.Length)
            {
                if (Screen.AllScreens[count].WorkingArea.Width > max)
                {
                    max = Screen.AllScreens[count].WorkingArea.Width;
                    Index = count;
                }
                count++;
            }
            this.Location = Screen.AllScreens[Index].WorkingArea.Location;
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion


        #region Check The Data File If Using
        [DllImport("kernel32.dll")] public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")] public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1); ///

        public static bool IsFileOccupied(string filePath)
        {
            IntPtr vHandle = _lopen(filePath, OF_READWRITE | OF_SHARE_DENY_NONE); CloseHandle(vHandle);
            return vHandle == HFILE_ERROR ? true : false;
        }
        #endregion

        //Form1 載入時設定初始參數
        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            Lr = Convert.ToDouble(textBox1.Text);
            La = Convert.ToDouble(textBox2.Text);
            Lb = Convert.ToDouble(textBox3.Text);
            Lh = Convert.ToDouble(textBox4.Text);

            ZLimit_up = -Math.Sqrt((Lb * Lb) - (La + Lr - Lh) * (La + Lr - Lh)); //Top:-301.5596
            ZLimit_down = -(La + Lb) + 10;                                       //-453 //Max:-463
            Zinit = ZLimit_up;                                                   //-301.5596
            TTZ = Zinit;                                                         //速度控制

            Console.WriteLine("ZLimit_up=" + ZLimit_up.ToString());
            Console.WriteLine("ZLimit_down=" + ZLimit_down.ToString());
            Console.WriteLine("Zinit=" + Zinit.ToString());

            TB_XCPosition.Text = Convert.ToString(0);
            TB_YCPosition.Text = Convert.ToString(0);
            TB_ZCPosition.Text = Convert.ToString(ZLimit_up);
            hsv_check();
            int Result;
            string strTemp;
            if (VersionIsOk == false)
            {
                return;
            }
            // Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
            //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
            //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite 
            Result = Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount);
            if (Result != (int)ErrorCode.SUCCESS)
            {
                strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, (uint)Result);
                return;
            }
            //If you want to get the device number of fixed equipment，you also can achieve it By adding the API:GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID),
            //The API is defined and illustrates the way of using in this example,but it is not called,you can copy it to your program and
            //don't need to call Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount)
            //GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID) API Variables are stated below:
            //UInt32 DevType : Set Device Type ID of your motion card plug in PC. (Definition is in ..\Public\AdvMotDev.h)
            //UInt32 BoardID : Set Hardware Board-ID of your motion card plug in PC,you can get it from Utility
            //UInt32 MasterRingNo: PCI-Motion card, Always set to 0
            //UInt32 SlaveBoardID : PCI-Motion card,Always set to 0
            CmbAvailableDevice.Items.Clear();

            for (int i = 0; i < deviceCount; i++)
            {
                CmbAvailableDevice.Items.Add(CurAvailableDevs[i].DeviceName);
            }
            if (deviceCount > 0)
            {
                CmbAvailableDevice.SelectedIndex = 0;
                DeviceNum = CurAvailableDevs[0].DeviceNum;
            }
        }
        #endregion

        //HSV打勾
        #region HSV check
        private void hsv_check()
        {

            checkBox_EH.Checked = true;
            checkBox_ES.Checked = true;
            checkBox_EV.Checked = true;
            checkBox_VAr.Checked = true;
            checkBox_scoo.Checked = true;
            ch_lock.Checked = true;
            //ch_Path.Checked = true;
            
        }
        #endregion
        // ---------------- 副程式區 ---------------- //
        #region 副程式
        //-------------------一般運動學控制(同動同停)-------------------//

        //加減速設定(以固定時間決定)
        #region   New Set Vel
        private void newsetvel(double[] Initial, double[] Final)
        {
            //Console.WriteLine("Use Time decision Vel");
            UInt32 Result;
            string strTemp;
            double AxVelLow_0 = 0.0, AxVelLow_1 = 0.0, AxVelLow_2 = 0.0;
            double AxVelHigh_0 = 2000.0, AxVelHigh_1 = 2000.0, AxVelHigh_2 = 2000.0;
            double AxAcc_0 = 6000.0, AxAcc_1 = 6000.0, AxAcc_2 = 6000.0;
            double AxDec_0 = 6000.0, AxDec_1 = 6000.0, AxDec_2 = 6000.0;
            double AxJerk = 0;
            double d_unit = 0.0036;      //d  = degree
            double VH_0 = 0.0;           //VH = 最高單位轉速
            double VH_1 = 0.0;
            double VH_2 = 0.0;
            double T = FIXT;
            double Ts = T * 0.5;
            double Ta = T * 0.25;
            double Td = T * 0.25;
            double Area = 0.0;
            double A = 250000 / 90;   //( 250000/90=2777.777777777778)
            PT = T; 
            if (Final[0] == 0 && Final[1] == 0 && Final[2] == 0 && Initial[0] == 0 && Initial[1] == 0 && Initial[2] == 0)
            {
                Console.WriteLine("All drgee 0");
                AxVelHigh_0 = 50000; AxAcc_0 = 3 * AxVelHigh_0; AxDec_0 = AxAcc_0;
                AxVelHigh_1 = 50000; AxAcc_1 = 3 * AxVelHigh_0; AxDec_1 = AxAcc_1;
                AxVelHigh_2 = 50000; AxAcc_2 = 3 * AxVelHigh_0; AxDec_2 = AxAcc_2;
            }
            else
            {
                if (Final[0] != Initial[0])
                {
                    Area = Math.Abs(Final[0] - Initial[0]) * A;
                    VH_0 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 0, MidpointRounding.AwayFromZero);
                    //Console.WriteLine("VH_0={0:f}", VH_0);
                    AxVelHigh_0 = VH_0; AxAcc_0 = Math.Round((VH_0 / Ta), 0, MidpointRounding.AwayFromZero); AxDec_0 = AxAcc_0;
                    //Console.WriteLine("VH_0={0:f8} AxAcc_0={1:f8} AxDec_0={2:f8}", VH_0, AxAcc_0, AxDec_0);
                }

                if (Final[1] != Initial[1])
                {
                    Area = Math.Abs(Final[1] - Initial[1]) * A;
                    VH_1 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 0, MidpointRounding.AwayFromZero);

                    AxVelHigh_1 = VH_1; AxAcc_1 = Math.Round((VH_1 / Ta), 8, MidpointRounding.AwayFromZero); AxDec_1 = AxAcc_1;
                    //Console.WriteLine("VH_1={0:f8} AxAcc_1={1:f8} AxDec_1={2:f8}", VH_1, AxAcc_1, AxDec_1);
                }

                if (Final[2] != Initial[2])
                {
                    Area = Math.Abs(Final[2] - Initial[2]) * A;
                    VH_2 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 0, MidpointRounding.AwayFromZero);

                    AxVelHigh_2 = VH_2; AxAcc_2 = Math.Round((VH_2 / Ta), 8, MidpointRounding.AwayFromZero); AxDec_2 = AxAcc_2;
                    //Console.WriteLine("VH_2={0:f8} AxAcc_2={1:f8} AxDec_2={2:f8}", VH_2, AxAcc_2, AxDec_2);
                }
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "s32Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_2);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            if (rdb_T.Checked)
            {
                AxJerk = 0;
            }
            else
            {
                AxJerk = 1;
            }

            //Set the type of velocity profile: t-curve or s-curve
            //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

        }
        #endregion

        //加減速度設定(以單位時間距離完成)
        #region Set Vel Acc Dec
        private void Set_Vel_Distance(double[] Initial, double[] Final, double distance)
        {
            UInt32 Result;
            string strTemp;
            double AxVelLow_0 = 0.0, AxVelLow_1 = 0.0, AxVelLow_2 = 0.0;
            double AxVelHigh_0 = 2000.0, AxVelHigh_1 = 2000.0, AxVelHigh_2 = 2000.0;
            double AxAcc_0 = 6000.0, AxAcc_1 = 6000.0, AxAcc_2 = 6000.0;
            double AxDec_0 = 6000.0, AxDec_1 = 6000.0, AxDec_2 = 6000.0;
            double AxJerk = 0;
            double VH_0 = 0.0;           //VH = 最高單位轉速
            double VH_1 = 0.0;
            double VH_2 = 0.0;
            double T = 0.0;
            double Ts = 0.0;
            double Ta = 0.0;
            double Td = 0.0;
            double Area = 0.0;
            double A = 250000 / 90;   //( 250000/90=2777.777777777778)
            //double d_unit = 0.015625;   //d  = degree
            //double VH = 87.5;           //VH = 最高單位轉速
            double mmsec = MMSEC;
            double L = 0.0, M = 0.0, R = 0.0;         // L -> 0, M -> 1, R -> 2

            /* poit to poit speed  |  Total operating time
               VH = 175            |  0.5 sec
               VH = 125            |  0.7 sec   
               VH = 87.5           |  1.0 sec
               VH = 58.3           |  1.5 sec
               VH = 43.75          |  2.0 sec
               VH = 29.1666        |  3.0 sec
               VH = 
            */
            if (distance != 0)
            { T = distance / mmsec; }
            
            Ts = T * 0.5;
            Ta = T * 0.25;
            Td = T * 0.25;
            PT = T;

            if (Final[0] == 0 && Final[1] == 0 && Final[2] == 0 && Initial[0] == 0 && Initial[1] == 0 && Initial[2] == 0)
            {

                L = 50000; AxVelHigh_0 = L; AxAcc_0 = 3 * L; AxDec_0 = AxAcc_0;
                M = 50000; AxVelHigh_1 = M; AxAcc_1 = 3 * M; AxDec_1 = AxAcc_1;
                R = 50000; AxVelHigh_2 = R; AxAcc_2 = 3 * R; AxDec_2 = AxAcc_2;
            }
            else
            {
                if (Final[0] != Initial[0])
                {
                    Area = Math.Abs(Final[0] - Initial[0]) * A;
                    VH_0 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 8, MidpointRounding.AwayFromZero);
                    Console.WriteLine("VH_0={0:f}", VH_0);
                    AxVelHigh_0 = VH_0; AxAcc_0 = Math.Round((VH_0 / Ta), 8, MidpointRounding.AwayFromZero); AxDec_0 = AxAcc_0;
                    Console.WriteLine("VH_0={0:f8} AxAcc_0={1:f8} AxDec_0={2:f8}", VH_0, AxAcc_0, AxDec_0);
                }

                if (Final[1] != Initial[1])
                {
                    Area = Math.Abs(Final[1] - Initial[1]) * A;
                    VH_1 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 8, MidpointRounding.AwayFromZero);

                    AxVelHigh_1 = VH_1; AxAcc_1 = Math.Round((VH_1 / Ta), 8, MidpointRounding.AwayFromZero); AxDec_1 = AxAcc_1;
                    Console.WriteLine("VH_1={0:f8} AxAcc_1={1:f8} AxDec_1={2:f8}", VH_1, AxAcc_1, AxDec_1);
                }

                if (Final[2] != Initial[2])
                {
                    Area = Math.Abs(Final[2] - Initial[2]) * A;
                    VH_2 = Math.Round((Area * 2) / (Ta + Td + 2 * Ts), 8, MidpointRounding.AwayFromZero);

                    AxVelHigh_2 = VH_2; AxAcc_2 = Math.Round((VH_2 / Ta), 8, MidpointRounding.AwayFromZero); AxDec_2 = AxAcc_2;
                    Console.WriteLine("VH_2={0:f8} AxAcc_2={1:f8} AxDec_2={2:f8}", VH_2, AxAcc_2, AxDec_2);
                }
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_0);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "s12Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_1);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "s22Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "s32Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_2);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            if (rdb_T.Checked)
            {
                AxJerk = 0;
            }
            else
            {
                AxJerk = 1;
            }

            //Set the type of velocity profile: t-curve or s-curve
            //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }
        #endregion

        //馬達控制_正運動學Positive kinematics
        #region Motor Positive
        public void Motor_Positive(double M1, double M2, double M3)
        {
            
            if (M1 >= 85)
                M1 = 85;
            else if (M2 >= 85)
                M2 = 85;
            else if (M3 >= 85)
                M3 = 85;

            if (M1 < 0)
                M1 = 0;
            else if (M2 < 0)
                M2 = 0;
            else if (M3 < 0)
                M3 = 0;

            double t1, t2, t3;
            double[] Initial = new double[3];
            double[] Final = new double[3];

            //TB_M1CDegree.Text = Convert.ToString(M1);  //
            //TB_M2CDegree.Text = Convert.ToString(M2);  //
            //TB_M3CDegree.Text = Convert.ToString(M3);  //

            t1 = ((M1) / 180) * Math.PI;// 
            t2 = ((M2) / 180) * Math.PI;//
            t3 = ((M3) / 180) * Math.PI;//
            
            double[] A1 = { 0, -Lr, 0 };
            double[] A2 = { Math.Sqrt(3) * 0.5 * Lr, (Lr / 2), 0 };
            double[] A3 = { -Math.Sqrt(3) * 0.5 * Lr, (Lr / 2), 0 };
            double[] B1 = { 0, -Lr - (La * Math.Cos(t1)), -La * Math.Sin(t1) };
            double[] B2 = { Math.Sqrt(3) * 0.5 * (Lr + La * Math.Cos(t2)), 0.5 * (Lr + La * Math.Cos(t2)), -La * Math.Sin(t2) };
            double[] B3 = { -Math.Sqrt(3) * 0.5 * (Lr + La * Math.Cos(t3)), 0.5 * (Lr + La * Math.Cos(t3)), -La * Math.Sin(t3) };
            double[] Bi1 = { 0, Lh + B1[1], B1[2] };
            double[] Bi2 = { B2[0] - Lh * Math.Cos(Math.PI / 6), B2[1] - (Lh * Math.Sin(Math.PI / 6)), B2[2] };
            double[] Bi3 = { B3[0] + Lh * Math.Cos(Math.PI / 6), B3[1] - (Lh * Math.Sin(Math.PI / 6)), B3[2] };
            double x1, x2, x3, y1, y2, y3, z1, z2, z3, w1, w2, w3, a, b, c, a1, b1, a2, b2, p1, p2;
            x1 = Bi1[0]; x2 = Bi2[0]; x3 = Bi3[0];
            y1 = Bi1[1]; y2 = Bi2[1]; y3 = Bi3[1];
            z1 = Bi1[2]; z2 = Bi2[2]; z3 = Bi3[2];
            w1 = Bi1[0] * Bi1[0] + Bi1[1] * Bi1[1] + Bi1[2] * Bi1[2];
            w2 = Bi2[0] * Bi2[0] + Bi2[1] * Bi2[1] + Bi2[2] * Bi2[2];
            w3 = Bi3[0] * Bi3[0] + Bi3[1] * Bi3[1] + Bi3[2] * Bi3[2];
            a1 = ((Bi3[1] - Bi1[1]) * (Bi2[2] - Bi1[2]) - (Bi2[1] - Bi1[1]) * (Bi3[2] - Bi1[2])) / ((Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]) - (Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]));
            b1 = ((w3 - w1) * (Bi2[1] - Bi1[1]) - (w2 - w1) * (Bi3[1] - Bi1[1])) / (2 * ((Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]) - (Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1])));
            a2 = ((Bi3[0] - Bi1[0]) * (Bi2[2] - Bi1[2]) - (Bi2[0] - Bi1[0]) * (Bi3[2] - Bi1[2])) / ((Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]) - (Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]));
            b2 = ((Bi2[0] - Bi1[0]) * (w3 - w1) - (Bi3[0] - Bi1[0]) * (w2 - w1)) / (2 * ((Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]) - (Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1])));
            a = a1 * a1 + a2 * a2 + 1;
            b = 2 * (a1 * (b1 - Bi1[0]) + a2 * (b2 - Bi1[1]) - Bi1[2]);
            c = (b1 - Bi1[0]) * (b1 - Bi1[0]) + (b2 - Bi1[1]) * (b2 - Bi1[1]) + Bi1[2] * Bi1[2] - Lb * Lb;
            p1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            p2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double sp;
            sp = Math.Sqrt(3) * Lh;
            if (p1 > p2)
                P[2] = p2;
            else P[2] = p1;
            P[0] = a1 * P[2] + b1;
            P[1] = a2 * P[2] + b2;
            
            //TB_XCPosition.Text = Convert.ToString(P[0]);  //x
            //TB_YCPosition.Text = Convert.ToString(P[1]);  //y
            //TB_ZCPosition.Text = Convert.ToString(P[2]);  //z

            //------角度給定------//
            AC = (100000 / 360) * 10;//100000(一圈)/360(度)=> 每度=277.7777777777778
            CmdPos_0 = M2 * AC; //M2
            CmdPos_1 = M1 * AC; //M1
            CmdPos_2 = M3 * AC; //M3
            
            //------加減速設定-----//
            if (checkBox_fixmm.Checked == true)
            {
                double distance = 0.0;

                distance = Math.Sqrt(Math.Pow(P[0] - TTX, 2) + Math.Pow(P[1] - TTY, 2) + Math.Pow(P[2] - TTZ, 2));
                Console.WriteLine("Distance={0:f8}", distance);

                Initial[0] = TTheta_1; Initial[1] = TTheta_2; Initial[2] = TTheta_3;

                Final[0] = M1; Final[1] = M2; Final[2] = M3;

                Set_Vel_Distance(Initial, Final, distance);

                TTheta_1 = M1; TTheta_2 =M2; TTheta_3 = M3;

                TTX = P[0]; TTY = P[1]; TTZ = P[2];

                /*Console.WriteLine("TTX=={0:f4}", TTX);
                Console.WriteLine("TTY=={0:f4}", TTY);
                Console.WriteLine("TTZ=={0:f4}", TTZ);*/

            }

            if (checkBox_finsec.Checked == true)
            {

                //Console.WriteLine("Use finsec");
                Initial[0] = TTheta_1; Initial[1] = TTheta_2; Initial[2] = TTheta_3;
                //Console.WriteLine("Initial[0]={0:f8}，Initial[1] ={1:f8}， Initial[2] = {2:f8}", TTheta_1, TTheta_2, TTheta_3);
                Final[0] = M1; Final[1] = M2; Final[2] = M3;
               //Console.WriteLine("Final[0]={0:f8}，Final[1] ={1:f8}， Final[2] = {2:f8}", M1, M2, M3);
                newsetvel(Initial, Final);

                TTheta_1 = M1; TTheta_2 = M2; TTheta_3 = M3;

                TTX = P[0]; TTY = P[1]; TTZ = P[2];

                /*Console.WriteLine("TTX=={0:f4}", TTX);
                Console.WriteLine("TTY=={0:f4}", TTY);
                Console.WriteLine("TTZ=={0:f4}", TTZ);*/
            }

            //------馬達運轉------//
            UInt32 Result;
            string strTemp;
            if (m_bInit)
            {
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("0-Axis")], -CmdPos_0);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("1-Axis")], -CmdPos_1);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("2-Axis")], -CmdPos_2);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Line Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                }
            }
            Thread.Sleep(Convert.ToInt32(FIXT * 0.82 * 1000));
            //Thread.Sleep(Convert.ToInt32(FIXT * 0.84 * 1000));
            //Thread.Sleep(Convert.ToInt32(FIXT*1000));
            return;
        }
        #endregion

        //馬達控制_逆運動學 (解析法一)Inverse kinematics
        #region Motor Inverse Analysismethod 1
        public void Motor_Inverse(double Px, double Py, double Pz)
        {
            if (Pz < ZLimit_down) { Pz = ZLimit_down; }
            if (Pz > ZLimit_up) { Pz = ZLimit_up; }
            double[] Initial = new double[3];
            double[] Final = new double[3];

            double a, b, c, p2, E1, F1, G1, E2, F2, G2, E3, F3, G3;
            
            //根據文獻需設立a,b,c三個參數
            a = Lr - Lh;
            b = Math.Sqrt(3) * Lh * 0.5 - Math.Sqrt(3) * 0.5 * Lr;
            c = (Lh - Lr) * 0.5;
            p2 = Px * Px + Py * Py + Pz * Pz;
            //第一隻機械手臂
            E1 = 2 * La * (Py + a);
            F1 = 2 * Pz * La;
            G1 = p2 + a * a + La * La + 2 * Py * a - Lb * Lb;
            //第二隻機械手臂
            E2 = -La * (Math.Sqrt(3) * (Px + b) + Py + c);
            F2 = 2 * Pz * La;
            G2 = p2 + b * b + c * c + La * La + 2 * (Px * b + Py * c) - Lb * Lb;
            //第三隻機械手臂
            E3 = La * (Math.Sqrt(3) * (Px - b) - Py - c);
            F3 = F2;
            G3 = p2 + b * b + c * c + La * La + 2 * (Py * c - Px * b) - Lb * Lb;
            //計算Theta角度
            double t11, t12, t21, t22, t23, t31, t32, t1, t2, t3;
            
            //a%b=a除b
            t11 = (360 + 2 * Math.Atan((-F1 + Math.Sqrt(E1 * E1 + F1 * F1 - G1 * G1)) / (G1 - E1))) % 360;
            t12 = (360 + 2 * Math.Atan((-F1 - Math.Sqrt(E1 * E1 + F1 * F1 - G1 * G1)) / (G1 - E1))) % 360;
            t21 = (360 + 2 * Math.Atan((-F2 + Math.Sqrt(E2 * E2 + F2 * F2 - G2 * G2)) / (G2 - E2))) % 360;
            t22 = (360 + 2 * Math.Atan((-F2 - Math.Sqrt(E2 * E2 + F2 * F2 - G2 * G2)) / (G2 - E2))) % 360;
            t23 = 2 * Math.Atan((-F2 - Math.Sqrt(E2 * E2 + F2 * F2 - G2 * G2)) / (G2 - E2));
            t31 = (360 + 2 * Math.Atan((-F3 + Math.Sqrt(E3 * E3 + F3 * F3 - G3 * G3)) / (G3 - E3))) % 360;
            t32 = (360 + 2 * Math.Atan((-F3 - Math.Sqrt(E3 * E3 + F3 * F3 - G3 * G3)) / (G3 - E3))) % 360;

            if (t11 > t12)
                t1 = t12;
            else
                t1 = t11;

            if (t21 > t22)
                t2 = t22;
            else if (t22 > t23)
                t2 = t23;
            else
                t2 = t21;

            if (t31 > t32)
                t3 = t32;
            else
                t3 = t31;

            //徑度轉成角度
            M1 = (t2 * 180 / Math.PI) % 360;  //
            M2 = (t3 * 180 / Math.PI) % 360;  //
            M3 = (t1 * 180 / Math.PI) % 360;  //

            //顯示各軸角度
            TB_M1CDegree.Text = Convert.ToString(M1); //1
            TB_M2CDegree.Text = Convert.ToString(M2); //0
            TB_M3CDegree.Text = Convert.ToString(M3); //2

            //------角度給定------//
            AC = (100000 / 360) * 10;//100000(一圈)/360(度)=> 每度=277.7777777777778
            if (T0 < 0) { T0 = 0; }
            if (T1 < 0) { T1 = 0; }
            if (T2 < 0) { T2 = 0; }
            if (T0 > 85) { T0 = 85; }
            if (T1 > 85) { T1 = 85; }
            if (T2 > 85) { T2 = 85; }
            CmdPos_0 = M1 * AC;   //L
            CmdPos_1 = M2 * AC;   //M
            CmdPos_2 = M3 * AC;   //R

            /*CmdPos_0 = M2 * AC;   //M2
            CmdPos_1 = M1 * AC;   //M1
            CmdPos_2 = M3 * AC;   //M3*/
            

            //-----加減速設定-----//
            if (checkBox_fixmm.Checked == true)
            {
                double distance = 0.0;

                distance = Math.Sqrt(Math.Pow(P[0] - TTX, 2) + Math.Pow(P[1] - TTY, 2) + Math.Pow(P[2] - TTZ, 2));
                Console.WriteLine("Distance={0:f8}", distance);

                Initial[0] = TTheta_1; Initial[1] = TTheta_2; Initial[2] = TTheta_3;

                Final[0] = M1; Final[1] = M2; Final[2] = M3;

                Set_Vel_Distance(Initial, Final, distance);

                TTheta_1 = M1; TTheta_2 = M2; TTheta_3 = M3;

                TTX = P[0]; TTY = P[1]; TTZ = P[2];

                /*Console.WriteLine("TTX=={0:f4}", TTX);
                Console.WriteLine("TTY=={0:f4}", TTY);
                Console.WriteLine("TTZ=={0:f4}", TTZ);*/

            }

            if (checkBox_finsec.Checked == true)
            {

                Console.WriteLine("Use finsec");
                Initial[0] = TTheta_1; Initial[1] = TTheta_2; Initial[2] = TTheta_3;
                Console.WriteLine("Initial[0]={0:f8}，Initial[1] ={1:f8}， Initial[2] = {2:f8}", TTheta_1, TTheta_2, TTheta_3);
                Final[0] = M1; Final[1] = M2; Final[2] = M3;
                Console.WriteLine("Final[0]={0:f8}，Final[1] ={1:f8}， Final[2] = {2:f8}", M1, M2, M3);
                newsetvel(Initial, Final);

                TTheta_1 = M1; TTheta_2 = M2; TTheta_3 = M3;

                TTX = P[0]; TTY = P[1]; TTZ = P[2];

                /*Console.WriteLine("TTX=={0:f4}", TTX);
                Console.WriteLine("TTY=={0:f4}", TTY);
                Console.WriteLine("TTZ=={0:f4}", TTZ);*/
            }
            //------馬達運轉------//
            uint Result;
            //double[] Distance = { CmdPos_1, CmdPos_0, CmdPos_2 };
            string strTemp;
            if (m_bInit)
            {
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("1-Axis")], -CmdPos_0);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("0-Axis")], -CmdPos_1);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("2-Axis")], -CmdPos_2);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Line Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                }
            }
            return;
        }
        #endregion

        //馬達控制_逆運動學 ( 解析法二) Inverse kinematics
        #region Motor Inverse Analysismethod 2
        private void Motor_Inverse_analysismethod(double Px, double Py, double Pz)
        {
            if (Pz < ZLimit_down) { Pz = ZLimit_down; }
            else if (Pz > ZLimit_up) { Pz = ZLimit_up; }

            
            double[] Initial = new double[3];
            double[] Final = new double[3];
            double[] psi = { 0, 120, 240 };
            double[] c_psi = { Math.Cos(0), Math.Cos(120 * Math.PI / 180), Math.Cos(240 * Math.PI / 180) };
            double[] s_psi = { Math.Sin(0), Math.Sin(120 * Math.PI / 180), Math.Sin(240 * Math.PI / 180) };
            double[] P = { Px, Py, Pz };
            double[,] M1 = new double[3, 3] { { c_psi[0], -s_psi[0], 0 }, { s_psi[0], c_psi[0], 0 }, { 0, 0, 1 } };
            double[,] M2 = new double[3, 3] { { c_psi[1], -s_psi[1], 0 }, { s_psi[1], c_psi[1], 0 }, { 0, 0, 1 } };
            double[,] M3 = new double[3, 3] { { c_psi[2], -s_psi[2], 0 }, { s_psi[2], c_psi[2], 0 }, { 0, 0, 1 } };
            double[,] inv_M1 = new double[3, 3] { { c_psi[0], s_psi[0], 0 }, { -s_psi[0], c_psi[0], 0 }, { 0, 0, 1 } };
            double[,] inv_M2 = new double[3, 3] { { c_psi[1], s_psi[1], 0 }, { -s_psi[1], c_psi[1], 0 }, { 0, 0, 1 } };
            double[,] inv_M3 = new double[3, 3] { { c_psi[2], s_psi[2], 0 }, { -s_psi[2], c_psi[2], 0 }, { 0, 0, 1 } };
            double[,] A1 = new double[3, 1] { { 62.899999999999999 }, { 0 }, { 0 } };
            double[,] A2 = new double[3, 1] { { 31.449999999999996 }, { 54.472997898041193 }, { 0 } };
            double[,] A3 = new double[3, 1] { { -31.449999999999996 }, { -54.472997898041193 }, { 0 } };
            double[,] Vector_Bs1 = new double[3, 1] { { 0 }, { 176.12 }, { 0 } };
            double[,] Vector_Bs2 = new double[3, 1] { { -152.5243941145153 }, { -88.06 }, { 0 } };
            double[,] Vector_Bs3 = new double[3, 1] { { 152.5243941145153 }, { -88.06 }, { 0 } };
            double[,] C1 = new double[3, 1];
            double[,] M1LH = new double[3, 1] { { 45 }, { 0 }, { 0 } };
            for (int i = 0; i < 3; i++)
            { C1[i, 0] = P[i] + M1LH[i, 0]; }
            double cx1 = C1[0, 0]; double cy1 = C1[1, 0]; double cz1 = C1[2, 0];
            double[,] Ct = new double[3, 1];
            for (int i = 0; i < 3; i++)
            { Ct[i, 0] = C1[i, 0]; }
            double a = Ct[0, 0]; double b = Ct[1, 0]; double c = Ct[2, 0];
            double alpha = (Lr - a) / c;
            double beta = 0.5 * (a * a + b * b + c * c + La * La - Lb * Lb - Lr * Lr) / c;
            double gamma = Lr - alpha * beta;
            double delta = 1 + alpha * alpha;
            double eta = Math.Sqrt(gamma * gamma - delta * (Lr * Lr + beta * beta - La * La));
            double x_1 = (gamma + eta) / (1 + alpha * alpha);
            double z_1 = alpha * x_1 + beta;
            double theta_1 = -Math.Asin(z_1 / La) / Math.PI * 180;
            double[,] Bt_1 = new double[3, 1] { { Lr + La * Math.Cos(theta_1 * Math.PI / 180) }, { 0 }, { -La * Math.Sin(theta_1 * Math.PI / 180) } };
            double[,] B_1 = new double[3, 1] { { 173.7512523977659 }, { 0 }, { -63.999998764428 } };
            double[,] B1 = B_1;
            double theta1 = theta_1;
            double Theta_R = theta1;
            double[,] C2 = new double[3, 1];
            double[,] M2LH = new double[3, 1];
            M2LH[0, 0] = M2[0, 0] * 45; M2LH[1, 0] = M2[1, 0] * 45; M2LH[2, 0] = M2[2, 0] * 45;
            for (int i = 0; i < 3; i++)
            { C2[i, 0] = P[i] + M2LH[i, 0]; }
            double cx2 = C2[0, 0]; double cy2 = C2[1, 0]; double cz2 = C2[2, 0];
            double[,] Ct2 = new double[3, 1];
            Ct2[0, 0] = inv_M2[0, 0] * C2[0, 0] + inv_M2[0, 1] * C2[1, 0] + inv_M2[0, 2] * C2[2, 0];
            Ct2[1, 0] = inv_M2[1, 0] * C2[0, 0] + inv_M2[1, 1] * C2[1, 0] + inv_M2[1, 2] * C2[2, 0];
            Ct2[2, 0] = inv_M2[2, 0] * C2[0, 0] + inv_M2[2, 1] * C2[1, 0] + inv_M2[2, 2] * C2[2, 0];
            double a2 = Ct2[0, 0]; double b2 = Ct2[1, 0]; double c2 = Ct2[2, 0];
            double alpha2 = (Lr - a2) / c2;
            double beta2 = 0.5 * (a2 * a2 + b2 * b2 + c2 * c2 + La * La - Lb * Lb - Lr * Lr) / c2;
            double gamma2 = Lr - alpha2 * beta2;
            double delta2 = 1 + alpha2 * alpha2;
            double eta2 = Math.Sqrt(gamma2 * gamma2 - delta2 * (Lr * Lr + beta2 * beta2 - La * La));
            double x_12 = (gamma2 + eta2) / (1 + alpha2 * alpha2);
            double z_12 = alpha2 * x_12 + beta2;
            double theta_2 = -Math.Asin(z_12 / La) / Math.PI * 180;
            double[,] Bt_2 = new double[3, 1] { { Lr + La * Math.Cos(theta_2 * Math.PI / 180) }, { 0 }, { -La * Math.Sin(theta_2 * Math.PI / 180) } };
            double[,] B_2 = new double[3, 1] { { 173.7512523977659 }, { 0 }, { -63.999998764428 } };
            double[,] B2 = B_2;
            double theta2 = theta_2;
            double Theta_M = theta2;
            double[,] C3 = new double[3, 1];
            double[,] M3LH = new double[3, 1];
            M3LH[0, 0] = M3[0, 0] * 45; M3LH[1, 0] = M3[1, 0] * 45; M3LH[2, 0] = M3[2, 0] * 45;
            for (int i = 0; i < 3; i++)
            { C3[i, 0] = P[i] + M3LH[i, 0]; }
            double cx3 = C3[0, 0]; double cy3 = C3[1, 0]; double cz3 = C3[2, 0];
            double[,] Ct3 = new double[3, 1];
            Ct3[0, 0] = inv_M3[0, 0] * C3[0, 0] + inv_M3[0, 1] * C3[1, 0] + inv_M3[0, 2] * C3[2, 0];
            Ct3[1, 0] = inv_M3[1, 0] * C3[0, 0] + inv_M3[1, 1] * C3[1, 0] + inv_M3[1, 2] * C3[2, 0];
            Ct3[2, 0] = inv_M3[2, 0] * C3[0, 0] + inv_M3[2, 1] * C3[1, 0] + inv_M3[2, 2] * C3[2, 0];
            double a3 = Ct3[0, 0]; double b3 = Ct3[1, 0]; double c3 = Ct3[2, 0];
            double alpha3 = (Lr - a3) / c3;
            double beta3 = 0.5 * (a3 * a3 + b3 * b3 + c3 * c3 + La * La - Lb * Lb - Lr * Lr) / c3;
            double gamma3 = Lr - alpha3 * beta3;
            double delta3 = 1 + alpha3 * alpha3;
            double eta3 = Math.Sqrt(gamma3 * gamma3 - delta3 * (Lr * Lr + beta3 * beta3 - La * La));
            double x_13 = (gamma3 + eta3) / (1 + alpha3 * alpha3);
            double z_13 = alpha3 * x_13 + beta3;
            double theta_3 = -Math.Asin(z_13 / La) / Math.PI * 180;
            double[,] Bt_3 = new double[3, 1] { { Lr + La * Math.Cos(theta_3 * Math.PI / 180) }, { 0 }, { -La * Math.Sin(theta_3 * Math.PI / 180) } };
            double[,] B_3 = new double[3, 1] { { 173.7512523977659 }, { 0 }, { -63.999998764428 } };
            double[,] B3 = B_3;
            double theta3 = theta_3;
            double Theta_L = theta3;

            //顯示各軸角度
            TB_M1CDegree.Text = Convert.ToString(Theta_L);//R
            TB_M2CDegree.Text = Convert.ToString(Theta_M);//L
            TB_M3CDegree.Text = Convert.ToString(Theta_R);//M
            //------角度給定------//
            AC = (100000 / 360) * 10;//100000(一圈)/360(度)=> 每度=277.7777777777778
            CmdPos_1 = Theta_M * AC;
            CmdPos_2 = Theta_R * AC;
            CmdPos_0 = Theta_L * AC;

            //-----加減速設定-----//
            double distance = 0.0;

            distance = Math.Sqrt(Math.Pow(Px - TTX, 2) + Math.Pow(Py - TTY, 2) + Math.Pow(Pz - TTZ, 2));

            Console.WriteLine("distance = {0:f8}", distance);

            Initial[0] = TTheta_1; Initial[1] = TTheta_2; Initial[2] = TTheta_3;

            Final[0] = T1; Final[1] = T2; Final[2] = T0;

            //Set_Vel_Acc_Dec(Initial, Final, distance);

            TTheta_1 = T1; TTheta_2 = T2; TTheta_3 = T0;

            TTX = Px; TTY = Py; TTZ = Pz;

            //------馬達運轉------//
            uint Result;
            double[] Distance = { CmdPos_1, CmdPos_0, CmdPos_2 };
            string strTemp;
            if (m_bInit)
            {
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("0-Axis")], -CmdPos_0);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("1-Axis")], -CmdPos_1);
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.FindStringExact("2-Axis")], -CmdPos_2);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Line Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                }
            }
            return;
        }
        #endregion

        //正運動學控制
        #region Perform D
        private void bu_perform_D_Click(object sender, EventArgs e)
        {
            double M1, M2, M3;
            TB_XCPosition.Clear(); TB_YCPosition.Clear(); TB_ZCPosition.Clear();  //將textBox方塊值清除
            TB_M1CDegree.Clear(); TB_M2CDegree.Clear(); TB_M3CDegree.Clear();  //將textBox方塊值清除
            chart_Data.Series[0].Points.Clear();
            chart_Data.Series[1].Points.Clear();
            chart_Data.Series[2].Points.Clear();
            X_Time = 1;
            M1 = Convert.ToDouble(TB_Motor1_D.Text);
            M2 = Convert.ToDouble(TB_Motor2_D.Text);
            M3 = Convert.ToDouble(TB_Motor3_D.Text);

            Motor_Positive(M1, M2, M3);
        }
        #endregion

        //-------------------一般運動學控制(同動同停) 結束-------------------//
        // 相加函式
        #region MatrixAdd
        private static double[,] matrixAdd(double[,] a, double[,] b)
        {
            double[,] c = new double[a.GetLength(0), a.GetLength(1)]; // 宣告空陣列C(X向量為3，Y向量為2)
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] + b[i, j]; // 陣列C=陣列A+陣列B
                    //Console.WriteLine("c[" + i + "," + j + "]=" + c[i, j] + " "); // 印出陣列的值
                }
            }
            return c;
        }
        #endregion

        // 相乘函式
        #region MatrixMul
        private static double[,] matrixMul(double[,] a, double[,] b)
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(1)]; // 宣告空陣列C(X向量為2，Y向量為2)
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, i - i] += a[i, j] * b[j, i - i]; // 陣列C=陣列A與陣列B的內積
                    c[i, i - i + 1] += a[i, j] * b[j, i - i + 1];
                }
                //Console.WriteLine("c[" + i + "," + (i - i) + "]=" + c[i, i - i] + " "); // 印出陣列C[i,i-i]
                //Console.WriteLine("c[" + i + "," + (i - i + 1) + "]=" + c[i, i - i + 1] + " "); // 印出陣列C[i,i-i+1]
            }
            return c;
        }
        #endregion

        //LinSpace
        #region LinSpace
        private static double[] linspace(double x1, double x2, int n)
        {                                         //Generate a 1-D array of lineraly spaced values
            double step = (x2 - x1) / (n - 1);    //step size
            double[] y = new double[n];           //1-D array to hold the output values
            for (int i = 0; i < n; i++)           //for loop to populate the array
                y[i] = x1 + step * i;
            return y;
        }
        #endregion

        //ones
        #region Ones
        private static double[,] ones(int x1, int x2)
        {
            //double[,] A = new double[5,1] 
            //{ { 1 }, { 1 }, { 1 }, { 1 }, { 1 } };
            //return A;

            double[,] A = new double[x1, x2];
            for (int i = 0; i < x1; i++)
                for (int j = 0; j < x2; j++)
                {
                    A[i, j] = 1;
                }
            return A;
        }
        #endregion

        //產生0矩陣
        #region Zeros Matrix
        private double[,] Zeros(int n,int i) 
        {
            double[,] T = new double[n,i];
            for (int j = 0; j<n; j++)
            {
                T[j, 0] = 0;
            }
            return T;
        }
        #endregion

        //Transposed Matrix
        #region Transposed Matrix
        private double[,] transposed_matrix(int m0, double[] I00)
        {
            double[,] trans_martix = new double[m0, 1];

            for (int i = 0; i < m0; i++)
            {
                trans_martix[i, 0] = I00[i];
            }

            return trans_martix;
        }
        #endregion

        //產生陣列(陣列數值為浮點數)
        #region Generate Matrix (double type)
        private double[] D_generate_matrix(int initial, int unit, int final)
        {
            int Nmatrix = 0;
            if (initial == 0)
            {
                Nmatrix = (final / unit) + 1;
            }
            else
            {
                Nmatrix = ((final - initial) / unit) + 1;
            }
            double[] T = new double[Nmatrix];
            T[0] = initial;
            for (int i = 1; i < Nmatrix; i++)
            {
                T[i] = T[i - 1] + unit;
            }
            return T;
        }
        #endregion

        //產生陣列(陣列數值為整數)
        #region Generate Matrix (double type)
        private int[] I_generate_matrix(int initial, int unit, int final)
        {
            int Nmatrix = 0;
            if (initial == 0)
            {
                Nmatrix = (final / unit) + 1;
            }
            else
            {
                Nmatrix = ((final - initial) / unit) + 1;
            }

            int[] T = new int[Nmatrix];
            T[0] = initial;
            for (int i = 1; i < Nmatrix; i++)
            {
                T[i] = T[i - 1] + unit;
            }
            return T;
        }
        #endregion

        //結合三組陣列 陣列形式  Nx1 (多載) 
        #region Combin Matrix for Nx1
        public static double[,] combine_matrix(double[,] matrix_1, double[,] matrix_2, double[,] matrix_3)
        {
            Console.WriteLine();
            int total_end = matrix_1.Length + matrix_2.Length + matrix_3.Length;
            int total_m = matrix_1.Length + matrix_2.Length;
            double[,] T = new double[total_end, 1];
            int j = 0, m = 0;
            for (int tt = 0; tt < matrix_1.Length; tt++)
            {
                T[tt, 0] = matrix_1[tt, 0];
            }

            for (int TT = matrix_1.Length; TT < total_m; TT++)
            {
                T[TT, 0] = matrix_2[j, 0];
                j++;
            }

            for (int kk = total_m; kk < total_end; kk++)
            {
                T[kk, 0] = matrix_3[m, 0];
                Console.WriteLine("matrix[{0:d}]={1:f8}", m, matrix_3[m, 0]);
                m++;
            }
            return T;
        }
        #endregion

        //結合兩組陣列 陣列形式  Nx1 (多載)
        #region Combin Matrix for Nx1
        private double[,] combine_matrix(double[,] matrix_1, double[,] matrix_2)
        {
            int total_end = matrix_1.Length + matrix_2.Length;
            double[,] T = new double[total_end, 1];
            int j = 0;
            for (int tt = 0; tt < matrix_1.Length; tt++)
            {
                T[tt, 0] = matrix_1[tt, 0];
            }

            for (int TT = matrix_1.Length; TT < total_end; TT++)
            {
                T[TT, 0] = matrix_2[j, 0];
                j++;
            }
            return T;
        }
        #endregion


        /// 左右交换矩阵元素，返回一个新矩阵       
        /// <param name="mat">输入矩阵</param>
        /// <returns>交换后的矩阵</returns>
        /// <remarks>以矩阵“垂直中线”为对称轴，交换左右对称位置上的元素</remarks>
        /// 

        public static double MM(double[,] mat, int x1, int x2)
        {
            double MM = 0;
            return MM;
        }

        //---清除---//
        private void CLEAR()
        {
            TB_XCPosition.Clear(); TB_YCPosition.Clear(); TB_ZCPosition.Clear();  //將textBox方塊值清除
            TB_M1CDegree.Clear(); TB_M2CDegree.Clear(); TB_M3CDegree.Clear();  //將textBox方塊值清除
        }
        

        private Boolean GetDevCfgDllDrvVer()
        {
            string fileName = "";
            FileVersionInfo myFileVersionInfo;
            string FileVersion = "";
            fileName = Environment.SystemDirectory + "\\ADVMOT.dll";//SystemDirectory指System32 
            myFileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
            FileVersion = myFileVersionInfo.FileVersion;
            string DetailMessage;
            string[] strSplit = FileVersion.Split(',');
            if (Convert.ToUInt16(strSplit[0]) < 2)
            {

                DetailMessage = "The Driver Version  Is Too Low" + "\r\nYou can update the driver through the driver installation package ";
                DetailMessage = DetailMessage + "\r\nThe Current Driver Version Number is " + FileVersion;
                DetailMessage = DetailMessage + "\r\nYou need to update the driver to 2.0.0.0 version and above";
                MessageBox.Show(DetailMessage, "Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        //User-defined API to show error message
        private void ShowMessages(string DetailMessage, uint errorCode)
        {
            StringBuilder ErrorMsg = new StringBuilder("", 100);
            //Get the error message according to error code returned from API
            Boolean res = Motion.mAcm_GetErrorMessage(errorCode, ErrorMsg, 100);
            string ErrorMessage = "";
            if (res)
                ErrorMessage = ErrorMsg.ToString();
            MessageBox.Show(DetailMessage + "\r\nError Message:" + ErrorMessage, "Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //------------------------//
        private void GetMotionIOStatus(uint IOStatus)
        {
            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ALM) > 0)//ALM
            {
                //pictureBoxALM.BackColor = Color.Red;
            }
            else
            {
                //pictureBoxALM.BackColor = Color.Gray;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ORG) > 0)//ORG
            {
                //pictureBoxORG.BackColor = Color.Red;
            }
            else
            {
                // pictureBoxORG.BackColor = Color.Gray;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0)//+EL
            {
                //pictureBoxPosHEL.BackColor = Color.Red;
            }
            else
            {
                //pictureBoxPosHEL.BackColor = Color.Gray;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0)//-EL
            {
                //pictureBoxNegHEL.BackColor = Color.Red;
            }
            else
            {
                //pictureBoxNegHEL.BackColor = Color.Gray;
            }
        }

        //---------------//
        #region Close Board Or Form
        private void CloseBoardOrForm()
        {
            UInt16[] usAxisState = new UInt16[32];
            uint AxisNum;
            //Stop Every Axes
            if (m_bInit == true)
            {
                CheckEventThread.Abort();      //Abort thread
                for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                {
                    //Get the axis's current state.
                    Motion.mAcm_AxGetState(m_Axishand[AxisNum], ref usAxisState[AxisNum]);
                    if (usAxisState[AxisNum] == (uint)AxisState.STA_AX_ERROR_STOP)
                    {
                        // Reset the axis' state. If the axis is in ErrorStop state, the state will
                        //be changed to Ready after calling this function.
                        Motion.mAcm_AxResetError(m_Axishand[AxisNum]);
                    }
                    // To command axis to decelerate to stop.
                    Motion.mAcm_AxStopDec(m_Axishand[AxisNum]);
                }
                //Remove all axis in the group and close the group handle
                Motion.mAcm_GpClose(ref m_GpHand);
                m_GpHand = IntPtr.Zero;
                for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                {
                    //Close Axes
                    Motion.mAcm_AxClose(ref m_Axishand[AxisNum]);
                }
                m_ulAxisCount = 0;
                AxCountInGp = 0;
                //Close Device
                Motion.mAcm_DevClose(ref m_DeviceHandle);
                m_DeviceHandle = IntPtr.Zero;
                timer1.Enabled = false;
                m_bInit = false;
                CmbAxes.Items.Clear();
                CmbAxes.Text = "";
                //textBoxAxDoneCnt_R.Clear();
                //textBoxAxDoneCnt_L.Clear();
                //textBoxAxDoneCnt_M.Clear();
                TB_FB_M1.Clear();
                TB_FB_M2.Clear();
                TB_FB_M3.Clear();
                //textBoxVHStartCnt.Clear();
                //textBoxVHEndCnt.Clear();
                Tb_Pos_M1.Text = Convert.ToString(0);
                TB_State_M2.Clear();
                TB_Pos_M2.Text = Convert.ToString(0);
                TB_State_M1.Clear();
                TB_Pos_M3.Text = Convert.ToString(0);
                TB_State_M3.Clear();
                //textBoxGpID.Clear();
                //textBoxAxesInGp.Clear();
                //textBoxGpDoneCnt.Clear();
                //textBoxGpVHStartCnt.Clear();
                //textBoxGpVHEndCnt.Clear();
                //textBoxGpState.Clear();
                TB_Vel_M1.Clear();
                TB_Vel_M3.Clear();
                TB_Vel_M2.Clear();
                //CheckBoxAxisMotionDone.Checked = false;
                //checkBoxVHStart.Checked = false;
                //checkBoxVHEnd.Checked = false;
                //checkBoxGpMotionDone.Checked = false;
                //checkBoxGpVHEnd.Checked = false;
                //checkBoxGpVHStart.Checked = false;
                TB_M1CDegree.Text = Convert.ToString(0);
                TB_M2CDegree.Text = Convert.ToString(0);
                TB_M3CDegree.Text = Convert.ToString(0);

            }
        }
        #endregion

        //---------------// 
        #region Check Event Thread
        private void CheckEvtThread()
        {
            uint Result;
            UInt32[] AxEvtStatusArray = new UInt32[32];
            UInt32[] GpEvtStatusArray = new UInt32[32];
            UInt32 i;
            while (m_bInit)
            {
                //Check axis and groups enabled motion event status
                //If you want to get event status of axis or groups, you should enable
                //these events by calling Motion.mAcm_EnableMotionEvent
                Result = Motion.mAcm_CheckMotionEvent(m_DeviceHandle, AxEvtStatusArray, GpEvtStatusArray, m_ulAxisCount, 3, 10);
                if (Result == (uint)ErrorCode.SUCCESS)
                {
                    for (i = 0; i < m_ulAxisCount; i++)
                    {

                        if ((AxEvtStatusArray[i] & (uint)EventType.EVT_AX_MOTION_DONE) > 0)
                        {
                            m_AxDoneEvtCnt[i]++;
                        }
                        if ((AxEvtStatusArray[i] & (uint)EventType.EVT_AX_VH_START) > 0)
                        {
                            m_AxVHStartCnt[i]++;
                        }
                        if ((AxEvtStatusArray[i] & (uint)EventType.EVT_AX_VH_END) > 0)
                        {
                            m_AxVHEndCnt[i]++;
                        }

                    }
                    if (m_GpHand != IntPtr.Zero)
                    {
                        //if (textBoxGpID.Text != "")
                        //{
                        //if ((GpEvtStatusArray[0] & ((uint)EventType.EVT_GP1_MOTION_DONE << Convert.ToByte(textBoxGpID.Text))) > 0)
                        //{
                        // m_GpDoneEvtCnt++;
                        //}
                        //if ((GpEvtStatusArray[1] & ((uint)EventType.EVT_GP1_VH_START << Convert.ToByte(textBoxGpID.Text))) > 0)
                        //{
                        //    m_GpVHStartCnt++;
                        //}
                        //if ((GpEvtStatusArray[2] & ((uint)EventType.EVT_GP1_VH_END << Convert.ToByte(textBoxGpID.Text))) > 0)
                        //{
                        //    m_GpVHEndCnt++;
                        //}
                        //}
                    }
                }
            }
        }
        #endregion

        //---------------//
        #region Get Axis Vel Param
        private void GetAxisVelParam()
        {
            double axvellow = new double();
            double axvelhigh = new double();
            double axacc = new double();
            double axdec = new double();
            UInt32 Result;
            string strTemp = "";
            //Get low velocity (start velocity) of this axis (Unit: PPU/S).
            //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref axvellow,ref BufferLength);
            // uint BufferLength;
            // BufferLength = 8; buffer size for the property
            Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref axvellow);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Get low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            textBoxVelL.Text = Convert.ToString(axvellow);
            //get high velocity (driving velocity) of this axis (Unit: PPU/s).
            //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, ref axvelhigh,ref BufferLength);
            // uint BufferLength;
            // BufferLength = 8; buffer size for the property
            Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, ref axvelhigh);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Get High velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            textBoxVelH.Text = Convert.ToString(axvelhigh);
            //get acceleration of this axis (Unit: PPU/s2).
            //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, ref axacc,ref BufferLength);
            // uint BufferLength;
            // BufferLength = 8; buffer size for the property
            Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, ref axacc);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Get acceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            textBoxAcc.Text = Convert.ToString(axacc);
            //get deceleration of this axis (Unit: PPU/s2).
            //You can also use the old API: Motion.mAcm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, ref axdec, ref BufferLength);
            // uint BufferLength;
            // BufferLength = 8; buffer size for the property
            Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, ref axdec);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Get deceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            textBoxDec.Text = Convert.ToString(axdec);
        }
        #endregion

#endregion
        // ---------------- 副程式區  結束 ---------------- //
        
        //顯示可選webcame
        #region Camera List
        private void camera_list()
        {
            List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> ListCamerasData2 = new List<KeyValuePair<int, string>>();
            
            //-> Find systems cameras with DirectShow.Net dll 
            int _DeviceIndex = 0; 
             

            foreach (DirectShowLib.DsDevice _Camera in Global._SystemCamereas)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(_DeviceIndex, _Camera.Name + "   " +Convert.ToString(_DeviceIndex)));
                _DeviceIndex++;
            }
            /*
            foreach (DirectShowLib.DsDevice _Camera in Global._SystemCamereas)
            {
                ListCamerasData2.Add(new KeyValuePair<int, string>(_DeviceIndex2, _Camera.Name + "   " + "2"));
            }
            */
            //-> clear the combobox
            ComboBoxCameraList.DataSource = null;
            ComboBoxCameraList.Items.Clear();

            //-> bind the combobox
            ComboBoxCameraList.DataSource = new BindingSource(ListCamerasData, null);
            ComboBoxCameraList.DisplayMember = "Value";
            ComboBoxCameraList.ValueMember = "Key";

            //-> clear the combobox
            ComboBoxCameraList1.DataSource = null;
            ComboBoxCameraList1.Items.Clear();

            //-> bind the combobox
            ComboBoxCameraList1.DataSource = new BindingSource(ListCamerasData, null);
            ComboBoxCameraList1.DisplayMember = "Value";
            ComboBoxCameraList1.ValueMember = "Key";
        }
        /*
        private void ComboCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-> Get the selected item in the combobox
            KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)ComboBoxCameraList.SelectedItem;
            //-> Assign selected cam index to defined var
            _CameraIndex = SelectedItem.Key;
        }*/
        #endregion
        
        //控制webcam
        #region Webcam Button
        private void btn_web1_Click(object sender, EventArgs e)
        {
            if(cap != null)
            {
                if (captureInPtogress)
                {
                    Application.Idle -= new EventHandler(Application_Idle);
                    cap.Dispose();
                    webcam_1_ori.Image = null;
                    cap = null;
                    btn_web1.Text = "START WEBCAM";
                    
                }
                else
                {
                    
                    btn_web1.Text = "STOP";
                    Application.Idle += new EventHandler(Application_Idle);
                }
                captureInPtogress = !captureInPtogress;
            }
            else
            {
                
                //-> Get the selected item in the combobox
                KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)ComboBoxCameraList.SelectedItem;
                //-> Assign selected cam index to defined var
                _CameraIndex = SelectedItem.Key;
                cap = new Capture(_CameraIndex);
            }
            //webcam_foucus_processinog(_CameraIndex);
        }

        private void btn_web2_Click(object sender, EventArgs e)
        {
            if (cap1 != null)
            {
                if (captureInPtogress1)
                {
                    Application.Idle -= new EventHandler(Application_Idle1);
                    cap1.Dispose();
                    webcam_2_ori.Image = null;
                    cap1 = null;
                    btn_web2.Text = "START WEBCAM";
                    
                }
                else
                {
                    btn_web2.Text = "STOP";
                    Application.Idle += new EventHandler(Application_Idle1);
                }
                captureInPtogress1 = !captureInPtogress1;
            }
            else
            {
                //-> Get the selected item in the combobox
                KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)ComboBoxCameraList1.SelectedItem;
                //-> Assign selected cam index to defined var
                _CameraIndex = SelectedItem.Key;
                cap1 = new Capture(_CameraIndex);
            }
            //webcam_foucus_processinog(_CameraIndex);
        }

        
        public void Application_Idle(object sender, EventArgs e)
        {   
            Image = cap.QueryFrame();
            
            if (Image != null)
            {
                //Image = Image.Rotate(0, new Bgr(System.Drawing.Color.Black));
                Image_g = ImageProcessing(Image);
                Image_g = thresholdValue(Image_g);
                if (checkBox_VAr.Checked) RecDetection(ImageFrameDetection, Image, trackBar_VAr.Value);
                webcam_1_ori.Image = Image.ToBitmap();
                //pictureBox_webcam1.Image = Image_g.ToBitmap();
            }

        }
        public Image<Gray, byte> thresholdValue(Image<Gray, byte> sender)
        {
            //Gray thresholdValue = new Gray(130);

            //Image<Gray, byte> thresholdImage = sender.ThresholdBinary(thresholdValue, new Gray(255));
            Image<Gray, byte> thresholdImage = sender;

            //擴張處理(擴張2像素)
            Image<Gray, byte> dilateImage = thresholdImage.Dilate(2);

            //侵蝕處理(侵蝕2像素)
            Image<Gray, byte> erodeImage = thresholdImage.Erode(2);


            return dilateImage;
        }
        
        //儲存roi影像
        #region Save Roi Image
        private void btn_saveroi_1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\Users\Lab326\Desktop";
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webcam_1_ori.Image.Save(saveFileDialog1.FileName);
            }
        }
        private void btn_saveroi_2_Click(object sender, EventArgs e)
        {
            saveFileDialog2.InitialDirectory = @"C:\Users\Lab326\Desktop";
            saveFileDialog2.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webcam_2_ori.Image.Save(saveFileDialog1.FileName);
            }
        }
        #endregion

        public void applyfilter(int min, int max)
        {
            image_gg = Image.Convert<Gray, Byte>().InRange(new Gray(min), new Gray(max));
        }


        public void Application_Idle1(object sender, EventArgs e)
        {
            Image1 = cap1.QueryFrame();
            if (Image1 != null)
            {
                //Image1 = Image1.Rotate(0, new Bgr(System.Drawing.Color.Black));
                Image_g1 = ImageProcessing1(Image1);
                if (checkBox_VAr.Checked) RecDetection1(ImageFrameDetection1, Image1, trackBar_VAr.Value);
                webcam_2_ori.Image = Image1.ToBitmap();
                //pictureBox_webcam2.Image = Image_g1.ToBitmap();
            }
        }
        #endregion

        //影像處理
        #region Image Preprocessing
        private Image<Gray, Byte> ImageProcessing(Image<Bgr, Byte> image)
        {
            ImageFrameDetection = cvAndHsvImage(
                  image,
                 Convert.ToInt32(numericHL.Value), Convert.ToInt32(numericHH.Value),
                 Convert.ToInt32(numericSL.Value), Convert.ToInt32(numericSH.Value),
                 Convert.ToInt32(numericVL.Value), Convert.ToInt32(numericVH.Value),
                 checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);
            return ImageFrameDetection;
        }

        private Image<Gray, Byte> ImageProcessing1(Image<Bgr, Byte> image)
        {
            ImageFrameDetection1 = cvAndHsvImage(
                  image,
                 Convert.ToInt32(numericHL.Value), Convert.ToInt32(numericHH.Value),
                 Convert.ToInt32(numericSL.Value), Convert.ToInt32(numericSH.Value),
                 Convert.ToInt32(numericVL.Value), Convert.ToInt32(numericVH.Value),
                 checkBox_EH.Checked, checkBox_ES.Checked, checkBox_EV.Checked, checkBox_IV.Checked);
            return ImageFrameDetection1;
        }

        private Image<Gray, Byte> cvAndHsvImage(Image<Bgr, Byte> imgFame, int L1, int H1, int L2, int H2, int L3, int H3, bool H, bool S, bool V, bool I)
        {
            Image<Hsv, Byte> hsvImage = imgFame.Convert<Hsv, Byte>();
            Image<Gray, Byte> ResultImage = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageH = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageS = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> ResultImageV = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);

            Image<Gray, Byte> img1 = inRangeImage(hsvImage, L1, H1, 0);
            Image<Gray, Byte> img2 = inRangeImage(hsvImage, L2, H2, 1);
            Image<Gray, Byte> img3 = inRangeImage(hsvImage, L3, H3, 2);
            Image<Gray, Byte> img4 = inRangeImage(hsvImage, 0, L1, 0);
            Image<Gray, Byte> img5 = inRangeImage(hsvImage, H1, 180, 0);

            #region checkBox Color Mode

            if (H)
            {
                if (I)
                {
                    CvInvoke.cvOr(img4, img5, img4, System.IntPtr.Zero);
                    ResultImageH = img4;
                }
                else { ResultImageH = img1; }
            }

            if (S) ResultImageS = img2;
            if (V) ResultImageV = img3;

            if (H && !S && !V) ResultImage = ResultImageH;
            if (!H && S && !V) ResultImage = ResultImageS;
            if (!H && !S && V) ResultImage = ResultImageV;

            if (H && S && !V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageS, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }

            if (H && !S && V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageV, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }

            if (!H && S && V)
            {
                CvInvoke.cvAnd(ResultImageS, ResultImageV, ResultImageS, System.IntPtr.Zero);
                ResultImage = ResultImageS;
            }

            if (H && S && V)
            {
                CvInvoke.cvAnd(ResultImageH, ResultImageS, ResultImageH, System.IntPtr.Zero);
                CvInvoke.cvAnd(ResultImageH, ResultImageV, ResultImageH, System.IntPtr.Zero);
                ResultImage = ResultImageH;
            }
            #endregion

            CvInvoke.cvErode(ResultImage, ResultImage, (IntPtr)null, 1);

            return ResultImage;
        }

        private Image<Gray, Byte> inRangeImage(Image<Hsv, Byte> hsvImage, int Lo, int Hi, int con)
        {
            Image<Gray, Byte> ResultImage = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);
            Image<Gray, Byte> IlowCh = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(Lo));
            Image<Gray, Byte> IHiCh = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(Hi));
            CvInvoke.cvInRange(hsvImage[con], IlowCh, IHiCh, ResultImage);
            return ResultImage;
        }

       
       
        private void RecDetection(Image<Gray, Byte> img, Image<Bgr, Byte> showRecOnImg, int areaV)
        {
            Image<Gray, Byte> imgForContour = new Image<Gray, byte>(img.Width, img.Height);
            CvInvoke.cvCopy(img, imgForContour, System.IntPtr.Zero);

            imgForContour = thresholdValue(imgForContour);

            IntPtr storage = CvInvoke.cvCreateMemStorage(0);
            IntPtr contour = new IntPtr();

            CvInvoke.cvFindContours(
                imgForContour,
                storage,
                ref contour,
                System.Runtime.InteropServices.Marshal.SizeOf(typeof(MCvContour)),
                Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL,
                Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                new Point(0, 0));

            Seq<Point> seq = new Seq<Point>(contour, null);

            for (; seq != null && seq.Ptr.ToInt64() != 0; seq = seq.HNext)
            {
                Rectangle bndRec = CvInvoke.cvBoundingRect(seq, 2);
                //Console.WriteLine(bndRec);
                double areaC = CvInvoke.cvContourArea(seq, MCvSlice.WholeSeq, 1) * -1;
                if (areaC > areaV)
                {
                    ImageCoordinate.LC_X = bndRec.X + (bndRec.Width / 2);
                    ImageCoordinate.LC_Y = bndRec.Y + (bndRec.Height / 2);
                    
                    if (ch_lock.Checked)
                    {
                        CvInvoke.cvRectangle(showRecOnImg, new Point(bndRec.X, bndRec.Y),
                        new Point(bndRec.X + bndRec.Width, bndRec.Y + bndRec.Height),
                        new MCvScalar(0, 0, 255), 2, LINE_TYPE.CV_AA, 0);
                    }
                    //MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_SIMPLEX, 10.0, 10.0);
                    
                    string h = "x=" + (bndRec.X + (bndRec.Width / 2)).ToString() + "Y=" + (bndRec.Y + (bndRec.Height / 2)).ToString();
                    if (checkBox_scoo.Checked) drawText(showRecOnImg, bndRec, h);

                    if (ch_Path.Checked)
                    {
                        drawPath(showRecOnImg, bndRec);
                    }
                    else
                    {
                        Object.Clear();
                    }
                }
            }

            /*
            MCvMoments moment = new MCvMoments();
            if (contour!= null) CvInvoke.cvMoments(contour, ref moment, 1);
            //Contour<Point> contours = showRecOnImg.FindContours();
            //MCvMoments moment = contour.GetMoments();
            //CvInvoke.cvMoments(showRecOnImg,ref moment,1);
            moment.m00 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 0);
            moment.m10 = CvInvoke.cvGetSpatialMoment(ref moment, 1, 0);
            moment.m01 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 1);
            // double area = CvInvoke.cvGetCentralMoment(ref moment, (int)(moment.m10/moment.m00), (int)(moment.m01/moment.m00));
            Global.centerx = (int)(moment.m10 / moment.m00);
            Global.centery = (int)(moment.m01 / moment.m00);
            //Console.WriteLine(Global.centerx);
            //Console.WriteLine(Global.centery);
            //Console.WriteLine("x"+Global.centerx.ToString()+"Y"+ Global.centery.ToString());
            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_SIMPLEX, 10.0, 10.0);
            CvInvoke.cvPutText(
                  Global.Image,
                  "x=" + cneterx + "y=" + cnetery,
                  new Point(cneterx),
                  ref f,
                  new MCvScalar(0, 0, 255));
            Console.WriteLine(cneterx);
            Console.WriteLine(cnetery);
            */
        }
        private void RecDetection1(Image<Gray, Byte> img, Image<Bgr, Byte> showRecOnImg, int areaV)
        {
            Image<Gray, Byte> imgForContour = new Image<Gray, byte>(img.Width, img.Height);
            CvInvoke.cvCopy(img, imgForContour, System.IntPtr.Zero);
            imgForContour = thresholdValue(imgForContour);
            IntPtr storage = CvInvoke.cvCreateMemStorage(0);
            IntPtr contour = new IntPtr();

            CvInvoke.cvFindContours(
                imgForContour,
                storage,
                ref contour,
                System.Runtime.InteropServices.Marshal.SizeOf(typeof(MCvContour)),
                Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL,
                Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE,
                new Point(0, 0));

            Seq<Point> seq = new Seq<Point>(contour, null);

            for (; seq != null && seq.Ptr.ToInt64() != 0; seq = seq.HNext)
            {
                Rectangle bndRec = CvInvoke.cvBoundingRect(seq, 2);
                //Console.WriteLine(bndRec);
                double areaC = CvInvoke.cvContourArea(seq, MCvSlice.WholeSeq, 1) * -1;
                if (areaC > areaV)
                {
                    ImageCoordinate.RC_X = (bndRec.X + (bndRec.Width / 2));
                    ImageCoordinate.RC_Y = (bndRec.Y + (bndRec.Height / 2));
                   
                    if (ch_lock.Checked)
                    {
                        CvInvoke.cvRectangle(showRecOnImg, new Point(bndRec.X, bndRec.Y),
                           new Point(bndRec.X + bndRec.Width, bndRec.Y + bndRec.Height),
                           new MCvScalar(0, 0, 255), 2, LINE_TYPE.CV_AA, 0);
                    }
                    //MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_SIMPLEX, 10.0, 10.0);
                    
                    string h = "x=" + (bndRec.X + (bndRec.Width / 2)).ToString() + "Y=" + (bndRec.Y + (bndRec.Height / 2)).ToString();
                    if (checkBox_scoo.Checked) drawText(showRecOnImg, bndRec, h);
                   

                    if (ch_Path.Checked)
                    {
                        drawPath2(showRecOnImg, bndRec);
                    }
                    else
                    {
                        Object2.Clear();
                    }

                }
            }

            /*
            MCvMoments moment = new MCvMoments();
            if (contour!= null) CvInvoke.cvMoments(contour, ref moment, 1);
            //Contour<Point> contours = showRecOnImg.FindContours();
            //MCvMoments moment = contour.GetMoments();
            //CvInvoke.cvMoments(showRecOnImg,ref moment,1);
            moment.m00 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 0);
            moment.m10 = CvInvoke.cvGetSpatialMoment(ref moment, 1, 0);
            moment.m01 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 1);
            // double area = CvInvoke.cvGetCentralMoment(ref moment, (int)(moment.m10/moment.m00), (int)(moment.m01/moment.m00));
            Global.centerx = (int)(moment.m10 / moment.m00);
            Global.centery = (int)(moment.m01 / moment.m00);
            //Console.WriteLine(Global.centerx);
            //Console.WriteLine(Global.centery);
            //Console.WriteLine("x"+Global.centerx.ToString()+"Y"+ Global.centery.ToString());
            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_SIMPLEX, 10.0, 10.0);
            CvInvoke.cvPutText(
                  Global.Image,
                  "x=" + cneterx + "y=" + cnetery,
                  new Point(cneterx),
                  ref f,
                  new MCvScalar(0, 0, 255));
            Console.WriteLine(cneterx);
            Console.WriteLine(cnetery);
            */
        }

        private void drawPath(Image<Bgr, Byte> img, Rectangle rect)
        {
            StoreObjectpotion store = new StoreObjectpotion();
            
            store.Center.X = rect.X + rect.Width / 2;
            store.Center.Y = rect.Y + rect.Height / 2;
            if (store.Center.X != ImageCoordinate.LCS_X && store.Center.Y != ImageCoordinate.LCS_Y)
            {
                Object.Add(store);
            }
                
            ImageCoordinate.LCS_X = store.Center.X;
            ImageCoordinate.LCS_X = store.Center.Y;

            for (int i=1; i < Object.Count ;i++)
            {
                if (Object[i].Center == null || Object[i - 1].Center == null)
                {
                    continue;
                }
                else
                { 
                    CvInvoke.cvLine(img, Object[i-1].Center, Object[i].Center, new MCvScalar(0, 0, 255), 2, LINE_TYPE.CV_AA, 0);
                }
                /*if (i > 100)
                    Object.Clear();*/
                Console.WriteLine(i);
            }
        }
        private void drawPath2(Image<Bgr, Byte> img, Rectangle rect)
        {
            StoreObjectpotion store = new StoreObjectpotion();

            store.Center.X = rect.X + rect.Width / 2;
            store.Center.Y = rect.Y + rect.Height / 2;
            if (store.Center.X != ImageCoordinate.RCS_X && store.Center.Y != ImageCoordinate.RCS_Y)
            {
                Object2.Add(store);
            }

            ImageCoordinate.RCS_X = store.Center.X;
            ImageCoordinate.RCS_X = store.Center.Y;

            for (int i = 1; i < Object2.Count; i++)
            {
                if (Object2[i].Center == null || Object2[i - 1].Center == null)
                {
                    continue;
                }
                else
                {
                    CvInvoke.cvLine(img, Object2[i - 1].Center, Object2[i].Center, new MCvScalar(0, 0, 255), 2, LINE_TYPE.CV_AA, 0);
                }
                /*if (i > 100)
                    Object.Clear();*/
                Console.WriteLine(i);
            }
        }


        private void drawText(Image<Bgr, Byte> img, Rectangle rect, string text)
        {
            Graphics g = Graphics.FromImage(img.Bitmap);
            //MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_SIMPLEX, 10.0, 10.0);
            Font f = new Font("Arial", 30, FontStyle.Bold);
            int tWidth = (int)g.MeasureString(text, f).Width;
            int x;
            if (tWidth >= rect.Width)
                x = rect.Left - ((tWidth - rect.Width) / 2);
            else
                x = (rect.Width / 2) - (tWidth / 2) + rect.Left;

            g.DrawString(text, f, Brushes.Red, new PointF(x, rect.Top - 50));
        }


        #endregion
        
        //開關控制板
        #region Cotrol Board Setting
        private void BtnOpenBoard_Click(object sender, EventArgs e) //open board
        {
            int clickTimes;//按下次數
            object tag = this.BtnOpenBoard.Tag;
            if (tag == null)
            {
                clickTimes = 0;
            }
            else
            {
                clickTimes = Convert.ToInt32(tag);
            }
            this.BtnOpenBoard.Tag = ++clickTimes;

            if ((clickTimes % 2) == 1)
            {
                uint Result;
                uint i = 0;
                uint[] slaveDevs = new uint[16];
                uint AxesPerDev = new uint();
                this.BtnOpenBoard.Text = "Board ON";
                checkBox_regulate.Checked = false;
                string strTemp;
                //Open a specified device to get device handle
                //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
                //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);

                Result = Motion.mAcm_DevOpen(DeviceNum, ref m_DeviceHandle);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                //FT_DevAxesCount:Get axis number of this device.
                //if you device is fixed(for example: PCI-1245),You can not get FT_DevAxesCount property value
                //This step is not necessary
                //You can also use the old API: Motion.mAcm_GetProperty(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev, ref BufferLength);
                // UInt32 BufferLength;
                //BufferLength =4;  buffer size for the property
                Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                m_ulAxisCount = AxesPerDev;

                CmbAxes.Items.Clear();
                //if you device is fixed,for example: PCI-1245 m_ulAxisCount =4
                for (i = 0; i < m_ulAxisCount; i++)
                {
                    //Open every Axis and get the each Axis Handle
                    //And Initial property for each Axis 		
                    //Open Axis 
                    Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_Axishand[i]);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        ShowMessages(strTemp, Result);
                        return;
                    }
                    CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
                    double cmdPosition = new double();
                    cmdPosition = 0;
                    //Set command position for the specified axis
                    Motion.mAcm_AxSetCmdPosition(m_Axishand[i], cmdPosition);
                }
                CmbAxes.SelectedIndex = 0;
                m_bInit = true;
                //User should create a new thread to check event status,for example:CheckEvtThread() function.
                CheckEventThread = new Thread(new ThreadStart(CheckEvtThread));
                CheckEventThread.Start();
                timer1.Interval = interval_rate;
                timer1.Enabled  = true;

                //while (BtnOpenBoard.Visible == true)
                //{
                //   label68.Text = "現在時間 : " + DateTime.Now.ToString();
                //   Application.DoEvents();
                //   await Task.Delay(TimeSpan.FromSeconds(1));
                //}
            }
            else
            {
                this.BtnOpenBoard.Text = "Board OFF";
                CloseBoardOrForm();
            }
        }
        #endregion

      

        //計算三軸馬達連續轉動角度和三維空間位置

        #region MC Update
        private void MC_update()
        {
            UInt32 Result;
            UInt16 GpState = 0;
            UInt32 IOStatus = new UInt32();
            double A = 250000 / 90;   //( 250000/90=2777.777777777778)
            double t1, t2, t3;

            if (m_bInit)
            {
                //Get the motion I/O status of the axis.
                Result = Motion.mAcm_AxGetMotionIO(m_Axishand[CmbAxes.SelectedIndex], ref IOStatus);
                if (Result == (uint)ErrorCode.SUCCESS)
                {
                    GetMotionIOStatus(IOStatus);
                }
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_CurCmd);
                M1 = -(M1_CurCmd / A);
                
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_CurCmd);
                M2 = -(M2_CurCmd / A);
                
                Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_CurCmd);
                M3 = -(M3_CurCmd / A);

                Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("1-Axis")], ref M1_Vel);
                Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("0-Axis")], ref M2_Vel);
                Motion.mAcm_AxGetCmdVelocity(m_Axishand[CmbAxes.FindStringExact("2-Axis")], ref M3_Vel);
            }

            t1 = ((M1) / 180) * Math.PI;// 
            t2 = ((M2) / 180) * Math.PI;//
            t3 = ((M3) / 180) * Math.PI;//

            double[] A1 = { 0, -Lr, 0 };
            double[] A2 = { Math.Sqrt(3) * 0.5 * Lr, (Lr / 2), 0 };
            double[] A3 = { -Math.Sqrt(3) * 0.5 * Lr, (Lr / 2), 0 };
            double[] B1 = { 0, -Lr - (La * Math.Cos(t1)), -La * Math.Sin(t1) };
            double[] B2 = { Math.Sqrt(3) * 0.5 * (Lr + La * Math.Cos(t2)), 0.5 * (Lr + La * Math.Cos(t2)), -La * Math.Sin(t2) };
            double[] B3 = { -Math.Sqrt(3) * 0.5 * (Lr + La * Math.Cos(t3)), 0.5 * (Lr + La * Math.Cos(t3)), -La * Math.Sin(t3) };
            double[] Bi1 = { 0, Lh + B1[1], B1[2] };
            double[] Bi2 = { B2[0] - Lh * Math.Cos(Math.PI / 6), B2[1] - (Lh * Math.Sin(Math.PI / 6)), B2[2] };
            double[] Bi3 = { B3[0] + Lh * Math.Cos(Math.PI / 6), B3[1] - (Lh * Math.Sin(Math.PI / 6)), B3[2] };
            double x1, x2, x3, y1, y2, y3, z1, z2, z3, w1, w2, w3, a, b, c, a1, b1, a2, b2, p1, p2;
            x1 = Bi1[0]; x2 = Bi2[0]; x3 = Bi3[0];
            y1 = Bi1[1]; y2 = Bi2[1]; y3 = Bi3[1];
            z1 = Bi1[2]; z2 = Bi2[2]; z3 = Bi3[2];
            w1 = Bi1[0] * Bi1[0] + Bi1[1] * Bi1[1] + Bi1[2] * Bi1[2];
            w2 = Bi2[0] * Bi2[0] + Bi2[1] * Bi2[1] + Bi2[2] * Bi2[2];
            w3 = Bi3[0] * Bi3[0] + Bi3[1] * Bi3[1] + Bi3[2] * Bi3[2];
            a1 = ((Bi3[1] - Bi1[1]) * (Bi2[2] - Bi1[2]) - (Bi2[1] - Bi1[1]) * (Bi3[2] - Bi1[2])) / ((Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]) - (Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]));
            b1 = ((w3 - w1) * (Bi2[1] - Bi1[1]) - (w2 - w1) * (Bi3[1] - Bi1[1])) / (2 * ((Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]) - (Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1])));
            a2 = ((Bi3[0] - Bi1[0]) * (Bi2[2] - Bi1[2]) - (Bi2[0] - Bi1[0]) * (Bi3[2] - Bi1[2])) / ((Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]) - (Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1]));
            b2 = ((Bi2[0] - Bi1[0]) * (w3 - w1) - (Bi3[0] - Bi1[0]) * (w2 - w1)) / (2 * ((Bi2[0] - Bi1[0]) * (Bi3[1] - Bi1[1]) - (Bi3[0] - Bi1[0]) * (Bi2[1] - Bi1[1])));
            a = a1 * a1 + a2 * a2 + 1;
            b = 2 * (a1 * (b1 - Bi1[0]) + a2 * (b2 - Bi1[1]) - Bi1[2]);
            c = (b1 - Bi1[0]) * (b1 - Bi1[0]) + (b2 - Bi1[1]) * (b2 - Bi1[1]) + Bi1[2] * Bi1[2] - Lb * Lb;
            p1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            p2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double sp;
            sp = Math.Sqrt(3) * Lh;
            if (p1 > p2)
                P[2] = p2;
            else P[2] = p1;
            P[0] = a1 * P[2] + b1;
            P[1] = a2 * P[2] + b2;

            CX =-P[0]; CY =P[1]; CZ =P[2];

            TB_M1CDegree.Text = Convert.ToString(M1);//Motor 1
            TB_M2CDegree.Text = Convert.ToString(M2);//Motor 2
            TB_M3CDegree.Text = Convert.ToString(M3);//Motor 3
            
            TB_XCPosition.Text = Convert.ToString(CX);//x
            TB_YCPosition.Text = Convert.ToString(CY);//y
            TB_ZCPosition.Text = Convert.ToString(CZ);//z
            
            TTX = CX;
            TTY = CY;
            TTZ = CZ;
        }
        #endregion

        //
        #region Setting Chart Front
        private void setting_chartfront()
        {
            //chart1;
        }

        #endregion
        
        // Chart Check Box 勾選
        #region Check Box Check
        private void check_Box_check()
        {   //**********************************//
            int c = 0;
            if (checkBox_showcoo.Checked == true)
                c = 1;
            if (checkBox_showde.Checked == true)
                c = 2;
            if (checkBox_showvel.Checked == true)
                c = 3;
            switch (c)
            {
                case 0:
                    checkBox_showcoo.Enabled = true;
                    checkBox_XAxis.Enabled = true;
                    checkBox_YAxis.Enabled = true;
                    checkBox_ZAxis.Enabled = true;
                    checkBox_showde.Enabled = true;
                    checkBox_M1D.Enabled = true;
                    checkBox_M2D.Enabled = true;
                    checkBox_M3D.Enabled = true;
                    checkBox_showvel.Enabled = true;
                    checkBox_M1V.Enabled = true;
                    checkBox_M2V.Enabled = true;
                    checkBox_M3V.Enabled = true;
                    checkBox_showcoo.Checked = false;
                    checkBox_XAxis.Checked = false;
                    checkBox_YAxis.Checked = false;
                    checkBox_ZAxis.Checked = false;
                    checkBox_showde.Checked = false;
                    checkBox_M1D.Checked = false;
                    checkBox_M2D.Checked = false;
                    checkBox_M3D.Checked = false;
                    checkBox_showvel.Checked = false;
                    checkBox_M1V.Checked = false;
                    checkBox_M2V.Checked = false;
                    checkBox_M3V.Checked = false;
                    break;
                case 1:
                    checkBox_XAxis.Checked = true;
                    checkBox_YAxis.Checked = true;
                    checkBox_ZAxis.Checked = true;
                    checkBox_showde.Enabled = false;
                    checkBox_showvel.Enabled = false;
                    checkBox_M1D.Enabled = false;
                    checkBox_M2D.Enabled = false;
                    checkBox_M3D.Enabled = false;
                    checkBox_M1V.Enabled = false;
                    checkBox_M2V.Enabled = false;
                    checkBox_M3V.Enabled = false;
                    break;
                case 2:
                    checkBox_M1D.Checked = true;
                    checkBox_M2D.Checked = true;
                    checkBox_M3D.Checked = true;
                    checkBox_showcoo.Enabled = false;
                    checkBox_showvel.Enabled = false;
                    checkBox_XAxis.Enabled = false;
                    checkBox_YAxis.Enabled = false;
                    checkBox_ZAxis.Enabled = false;
                    checkBox_M1V.Enabled = false;
                    checkBox_M2V.Enabled = false;
                    checkBox_M3V.Enabled = false;
                    break;
                case 3:
                    checkBox_M1V.Checked = true;
                    checkBox_M2V.Checked = true;
                    checkBox_M3V.Checked = true;
                    checkBox_showcoo.Enabled = false;
                    checkBox_showde.Enabled = false;
                    checkBox_XAxis.Enabled = false;
                    checkBox_YAxis.Enabled = false;
                    checkBox_ZAxis.Enabled = false;
                    checkBox_M1D.Enabled = false;
                    checkBox_M2D.Enabled = false;
                    checkBox_M3D.Enabled = false;
                    break;  
            }

            if (checkBox_showcoo.Checked == true)
            {
                chart_Data.Titles[0].Text = "Coordinate";
                chart_Data.Series[0].LegendText = "X_Axis";
                chart_Data.Series[1].LegendText = "Y_Axis";
                chart_Data.Series[2].LegendText = "Z_Axis";
                chart_Data.ChartAreas[0].AxisX.Title = "Point";
                chart_Data.ChartAreas[0].AxisY.Title = "mm";
                //chart_Data.ChartAreas[0].AxisX.Interval = 20;
                //chart_Data.ChartAreas[0].AxisY.Interval = 50;

            }

            if (checkBox_showde.Checked == true)
            {
                chart_Data.Titles[0].Text = "Degree";
                chart_Data.Series[0].LegendText = "Motor1_Degree";
                chart_Data.Series[1].LegendText = "Motor2_Degree";
                chart_Data.Series[2].LegendText = "Motor3_Degree";
                chart_Data.ChartAreas[0].AxisX.Title = "Point";
                chart_Data.ChartAreas[0].AxisY.Title = "Degree";
                //chart_Data.ChartAreas[0].AxisX.Interval = 20;
                //chart_Data.ChartAreas[0].AxisY.Interval = 10;

            }

            if (checkBox_showvel.Checked == true)
            {
                chart_Data.Titles[0].Text = "Velocity";
                chart_Data.Series[0].LegendText = "Motor1_Vel";
                chart_Data.Series[1].LegendText = "Motor2_Vel";
                chart_Data.Series[2].LegendText = "Motor3_Vel";
                chart_Data.ChartAreas[0].AxisX.Title = "Point";
                chart_Data.ChartAreas[0].AxisY.Title = "Velocity";
                //chart_Data.ChartAreas[0].AxisX.Interval = 20;
                //chart_Data.ChartAreas[0].AxisY.Interval = 10;
            }
            //******************************************************//
            chart_Data.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("微軟正黑體", 14F, FontStyle.Bold);
            chart_Data.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("微軟正黑體", 14F, FontStyle.Bold);
            chart_Data.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("微軟正黑體", 14F, FontStyle.Bold);
            chart_Data.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("微軟正黑體", 14F, FontStyle.Bold);
        
        }
        #endregion

        // 更新圖表
        #region Updata Chart
        private void Update_chart()
        {           
            if (checkBox_NRT.Checked == true) //非實時
            {
                checkBox_RT.Enabled = false;
                
                //顯示座標
                if (checkBox_showcoo.Checked ==true)
                {
                    
                    if (Chart_Flag == true)
                    {   
                        chart_Data.Series[0].Points.AddXY(X_Time,CX);
                        chart_Data.Series[1].Points.AddXY(X_Time,CY);
                        chart_Data.Series[2].Points.AddXY(X_Time,CZ);

                        X_Time += 1;
                    }
                }

                //顯示角度
                if (checkBox_showde.Checked== true)
                {
                    if (Chart_Flag == true)
                    {
                        
                        chart_Data.Series[0].Points.AddXY(X_Time, M1);
                        chart_Data.Series[1].Points.AddXY(X_Time, M2);
                        chart_Data.Series[2].Points.AddXY(X_Time, M3);

                        X_Time += 1;
                    }
                    
                }

                // 顯示速度
                if (checkBox_showvel.Checked==true)
                {
                    if (Chart_Flag == true)
                    {
                        chart_Data.Series[0].Points.AddXY(X_Time, Vel_1);
                        chart_Data.Series[1].Points.AddXY(X_Time, Vel_2);
                        chart_Data.Series[2].Points.AddXY(X_Time, Vel_3);

                        X_Time += 1;
                    }
                }
            }
            else { checkBox_RT.Enabled = true; }

            //****************************************//
            if (checkBox_RT.Checked == true)//實時
            {
                checkBox_NRT.Enabled = false;
                
            }
            else { checkBox_NRT.Enabled = true;}
            
        }
        #endregion

       
        //載入配置 此處沒有使用
        #region Load cfg file
        /*
        private void BtnLoadCfg_Click(object sender, EventArgs e)
        {
            UInt32 Result;
            string strTemp;
            if (m_bInit != true)
            {
                return;
            }
            this.openFileDialog.FileName = ".cfg";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //Set all configurations for the device according to the loaded file
            Result = Motion.mAcm_DevLoadConfig(m_DeviceHandle, openFileDialog.FileName);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Load Config Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }*/
        #endregion

        //初始位置設置(復歸位置)
        #region Inistial Position Setting
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string strTemp;
            uint Result;
            //Command axis in this group to stop immediately without deceleration
            Result = Motion.mAcm_GpStopEmg(m_GpHand);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "The group to stop immediately failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
            }
            return;
            */
            //int k = 50;
            uint Result;
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], 0);
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], 0);
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], 0);
            /*CmdPos_0 =k*10;
            CmdPos_1 =k*10;
            CmdPos_2 =k*10;

            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("0-Axis")], CmdPos_0);
            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("1-Axis")], CmdPos_1);
            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("2-Axis")], CmdPos_2);

            Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], 0);
            Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], 0);
            Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], 0);*/

        }
        /*private void button1_Click_1(object sender, EventArgs e)
        {
            uint Result;
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], 0);
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], 0);
            Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], 0);
        }*/
        #endregion

        //伺服啟動
        #region Servo ON OFF
        private void BtnServo_Click(object sender, EventArgs e)
        {
            UInt32 AxisNum;
            UInt32 Result;
            string strTemp;
            //Check the servoOno flag to decide if turn on or turn off the ServoOn output.
            if (m_bInit != true)
            {
                return;
            }
            if (m_bServoOn == false)
            {
                for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                {
                    // Set servo Driver ON,1: On
                    Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 1);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Servo On Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        ShowMessages(strTemp, Result);
                        return;
                    }
                    m_bServoOn = true;
                    BtnServo.Text = "Servo ON";
                }
            }
            else
            {
                for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                {
                    // Set servo Driver OFF,0: Off
                    Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 0);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Servo Off Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        ShowMessages(strTemp, Result);
                        return;
                    }
                    m_bServoOn = false;
                    BtnServo.Text = "Servo OFF";
                }
            }
            //-----------------------//
            double RRR = Convert.ToDouble(TB_FB_M1.Text);
            double LLL = Convert.ToDouble(TB_FB_M2.Text);
            double MMM = Convert.ToDouble(TB_FB_M3.Text);
            Tb_Pos_M1.Text = Convert.ToString(RRR * 10);
            TB_Pos_M2.Text = Convert.ToString(LLL * 10);
            TB_Pos_M3.Text = Convert.ToString(MMM * 10);
        }
        #endregion

        //復歸按鍵
        #region Regulate Button
        private void button_regulate_Click(object sender, EventArgs e)
        {
            //button17  Reversion
            UInt32 Result;
            string strTemp;
            double M1 = Convert.ToDouble(TB_FB_M1.Text);
            double M2 = Convert.ToDouble(TB_FB_M2.Text);
            double M3 = Convert.ToDouble(TB_FB_M3.Text);

            double AxJerk = 0;
            double AxVelLow_0=0.0, AxVelLow_1=0.0, AxVelLow_2=0.0;
            double AxVelHigh_0 = 40000, AxVelHigh_1 = 40000, AxVelHigh_2 = 40000;
            double AxAcc_0 = 120000, AxAcc_1 = 120000, AxAcc_2 = 120000;
            double AxDec_0 = 120000, AxDec_1 = 120000, AxDec_2 = 120000;


            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow_2);

            

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "r2Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc_2);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_0);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_1);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxDec, AxDec_2);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            if (rdb_T.Checked)
            {
                AxJerk = 0;
            }
            else
            {
                AxJerk = 1;
            }

            //Set the type of velocity profile: t-curve or s-curve
            //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
            Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);

            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }

            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("1-Axis")], M2 * 10);
            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("0-Axis")], M1 * 10);
            Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.FindStringExact("2-Axis")], M3 * 10);
           
            TTheta_1 = 0.0; TTheta_2 = 0.0; TTheta_3 = 0.0;
            TTX = 0.0; TTY = 0.0; TTZ = ZLimit_up;

            if (TB_FB_M1.Text == Convert.ToString(0) &&
                TB_FB_M2.Text == Convert.ToString(0) &&
                TB_FB_M3.Text == Convert.ToString(0))
            {
                //Thread.Sleep(2000); //Delay 5秒}
                //Set command position for the specified axis
                Result = Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("1-Axis")], 0);
                Result = Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("0-Axis")], 0);
                Result = Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.FindStringExact("2-Axis")], 0);
                Task.Delay(2500);
                checkBox_regulate.Checked = true;
            }


            TB_XCPosition.Text = Convert.ToString(0);      TB_YCPosition.Text = Convert.ToString(0);  TB_ZCPosition.Text = Convert.ToString(0);  //將textBox方塊值清除
            TB_M1CDegree.Text = Convert.ToString(0);     TB_M2CDegree.Text = Convert.ToString(0); TB_M3CDegree.Text = Convert.ToString(0);  //將textBox方塊值清除
            TB_Motor1_D.Text = Convert.ToString(0);      TB_Motor2_D.Text = Convert.ToString(0);  TB_Motor3_D.Text = Convert.ToString(0);
            TB_Z_I.Text = Convert.ToString(Zinit); TB_Y_I.Text = Convert.ToString(0); TB_X_I.Text = Convert.ToString(0);
            
        }
        #endregion

        private void BtnAddAxis_Click(object sender, EventArgs e)
        {
            uint Result;
            uint AxesInfoInGp = new uint();
            //string strTemp;
            if (m_bInit != true)
            {
                return;
            }
            else//add axis success
            {
                AxCountInGp++;
                //Get the GroupID through GroupHandle
                //You  can also use the old API Motion.mAcm_GetProperty(m_GpHand, (uint)PropertyID.PAR_GpGroupID, ref AxesInfoInGp,ref BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_GetU32Property(m_GpHand, (uint)PropertyID.PAR_GpGroupID, ref AxesInfoInGp);
                if (Result == (uint)ErrorCode.SUCCESS)
                {
                    //textBoxGpID.Text = Convert.ToString(AxesInfoInGp, 10);
                }
                //Get information about which axis is (are) in this group
                //You  can also use the old API Motion.mAcm_GetProperty(m_GpHand, (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInfoInGp,ref BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_GetU32Property(m_GpHand, (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInfoInGp);
                if (Result == (uint)ErrorCode.SUCCESS)
                {
                    //textBoxAxesInGp.Text = Convert.ToString(AxesInfoInGp, 10);
                }
            }
        }
        
        #region NOT Finish Part
        private void BtnAxReset_Click(object sender, EventArgs e)
        {
            double cmdPosition = new double();
            cmdPosition = 0;
            for (UInt32 i = 0; i < m_ulAxisCount; i++)
            {
                m_AxDoneEvtCnt[i] = 0;
                m_AxCmpEvtCnt[i] = 0;
                m_AxVHStartCnt[i] = 0;
                m_AxVHEndCnt[i] = 0;
                m_AxLatchBufCnt[i] = 0;
            }
            if (m_bInit == true)
            {
                //Set command position for the specified axis
                Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.SelectedIndex], cmdPosition);

            }
        }

        private void btn_ResetError_Click(object sender, EventArgs e)
        {
            uint Result;
            UInt16 State = new UInt16();
            string strTemp;
            if (m_bInit == true)
            {

                //Get the group's current state
                Motion.mAcm_AxGetState(m_Axishand[CmbAxes.SelectedIndex], ref State);
                if (State == (UInt16)AxisState.STA_AX_ERROR_STOP)
                {
                    //Reset axis states
                    Result = Motion.mAcm_AxResetError(m_Axishand[CmbAxes.SelectedIndex]);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Reset axis's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        ShowMessages(strTemp, Result);
                        return;
                    }
                }
            }
        }

        private void BtnGpReset_Click(object sender, EventArgs e)
        {
            //m_GpDoneEvtCnt = 0;
            //m_GpVHStartCnt = 0;
            //m_GpVHEndCnt = 0;
        }

        private void btn_GpResetError_Click(object sender, EventArgs e)
        {
            uint Result;
            UInt16 State = new UInt16();
            string strTemp;
            if (m_bInit == true)
            {
                //Get the group's current state
                Motion.mAcm_GpGetState(m_GpHand, ref State);
                if (State == (UInt16)GroupState.STA_Gp_ErrorStop)
                {
                    //Reset group states
                    Result = Motion.mAcm_GpResetError(m_GpHand);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Reset group's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        ShowMessages(strTemp, Result);
                        return;
                    }
                }
            }
        }

        private void button_ExitProgram_Click(object sender, EventArgs e) //
        {
            UInt32 Result;
            UInt32 AxisNum;
            string strTemp;
            UInt32 zero;
            zero = 3;
            double enddd;
            enddd = 0;
            // Set servo Driver OFF,0: Off                    
            for (AxisNum = 0; AxisNum < zero; AxisNum++)
            {
                Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 0);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Servo On Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                m_bServoOn = false;
                BtnServo.Text = "Servo Off";
                enddd = enddd + 1;
            }
            if (enddd == 3)
            {
                CloseBoardOrForm();
                Application.Exit();
                this.Close();
                Environment.Exit(Environment.ExitCode);
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            TB_Motor3_D.Text = Convert.ToString(0);//M
            TB_Motor2_D.Text = Convert.ToString(0);//R
            TB_Motor1_D.Text = Convert.ToString(0);//L  //將textBox方塊值清除
        }

        private void bu_perform_I_Click(object sender, EventArgs e)
        {
                double Px, Py, Pz;
                TB_XCPosition.Clear(); TB_YCPosition.Clear(); TB_ZCPosition.Clear();  //將textBox方塊值清除
                TB_M1CDegree.Clear(); TB_M2CDegree.Clear(); TB_M3CDegree.Clear();  //將textBox方塊值清除

                Px = Convert.ToDouble(TB_X_I.Text);
                Py = Convert.ToDouble(TB_Y_I.Text);
                Pz = Convert.ToDouble(TB_Z_I.Text);

                Motor_Inverse(Px, Py, Pz);
            /*
                if (radioButton1.Checked == true)
                { Motor_Inverse(Px, Py, Pz); }
                if (radioButton2.Checked == true)
                { Motor_Inverse_analysismethod(Px, Py, Pz); }   
            */
        }


        private void button7_Click(object sender, EventArgs e)
        {
            TB_X_I.Text = Convert.ToString(0);
            TB_Y_I.Text = Convert.ToString(0);
            TB_Z_I.Text = Convert.ToString(ZLimit_up);   //將textBox方塊值清除
        }
        
        private void radioButtonAbs_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void btn_SetParam_Click(object sender, EventArgs e)
        {
            UInt32 Result;
            double AxVelLow;
            double AxVelHigh;
            double AxAcc;
            double AxDec;
            double AxJerk;
            string strTemp;
            AxVelLow = Convert.ToDouble(textBoxVelL.Text);
            //Set low velocity (start velocity) of this axis (Unit: PPU/S).
            ////設置該軸的低速度（啟動速度）（單位：PPU / S）
            //This property value must be smaller than or equal to PAR_AxVelHigh
            //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            if (checkBox_fixmm.Checked != true && checkBox_finsec.Checked != true)
            {
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                AxVelHigh = Convert.ToDouble(textBoxVelH.Text);
                // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
                //設置該軸的高速度（驅動速度）（單位：PPU / s）
                //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                AxAcc = Convert.ToDouble(textBoxAcc.Text);
                // Set acceleration of this axis (Unit: PPU/s2).
                //設置該軸的加速度（單位：PPU / s2）。
                //This property value must be smaller than or equal to CFG_AxMaxAcc
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxAcc, AxAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                AxDec = Convert.ToDouble(textBoxDec.Text);
                //Set deceleration of this axis (Unit: PPU/s2).
                //設置該軸的減速度（單位：PPU / s2）。
                //This property value must be smaller than or equal to CFG_AxMaxDec
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxDec, AxDec);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxDec, AxDec);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxDec, AxDec);

                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
                if (rdb_T.Checked)
                {
                    AxJerk = 0;
                }
                else
                {
                    AxJerk = 1;
                }

                //Set the type of velocity profile: t-curve or s-curve
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("0-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("1-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);
                Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.FindStringExact("2-Axis")], (uint)PropertyID.PAR_AxJerk, AxJerk);

                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                    return;
                }
            }

            GetAxisVelParam(); //Get Axis Velocity Param
        }

        private void BtnPTP_Click(object sender, EventArgs e)
        {
            UInt32 Result;
            string strTemp;
            if (m_bInit)
            {
                if (radioButtonRel.Checked)
                {
                    //Start single axis's relative position motion.
                    Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.SelectedIndex], Convert.ToDouble(100000));
                }
                else
                {
                    //Start single axis's absolute position motion.
                    Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.SelectedIndex], Convert.ToDouble(100000));
                }
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "PTP Move Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    ShowMessages(strTemp, Result);
                }
            }
            return;
        }

        private void buttonPTP_Click(object sender, EventArgs e)
        {
            uint Result;
            string strTemp;
            if (radioButtonRel.Checked)
            {
                //Start single axis's relative position motion
                Result = Motion.mAcm_AxMoveRel(m_Axishand[CmbAxes.SelectedIndex], 10000);
            }
            else
            {
                //Start single axis's absolute position motion.
                Result = Motion.mAcm_AxMoveAbs(m_Axishand[CmbAxes.SelectedIndex], 10000);
            }
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "PTP Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
            }
        }

        private void btn_AxStop_Click(object sender, EventArgs e)
        {
            UInt32 Result;
            string strTemp;

            //To command axis to decelerate to stop.
            Result = Motion.mAcm_AxStopEmg(m_Axishand[CmbAxes.SelectedIndex]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            uint Result;
            double[] Distance = { 10000, 10000 };
            uint Element = new uint();
            string strTemp;
            Element = 2;
            if (radioButtonRel.Checked)
            {
                //Command group to execute relative line interpolation
                Result = Motion.mAcm_GpMoveLinearRel(m_GpHand, Distance, ref Element);
            }
            else
            {
                //Command group to execute absolute line interpolation
                Result = Motion.mAcm_GpMoveLinearAbs(m_GpHand, Distance, ref Element);
            }
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Line Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
            }
        }

        private void btn_GpStop_Click(object sender, EventArgs e)
        {
            UInt32 Result;
            string strTemp;

            //To group to decelerate to stop.
            Result = Motion.mAcm_GpStopEmg(m_GpHand);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Gp To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }
        private void button_DirectSTOP_Click(object sender, EventArgs e)
        {
            string strTemp;
            uint Result;
            //Command axis in this group to stop immediately without deceleration
            //Result = Motion.mAcm_GpStopEmg(m_GpHand);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("0-Axis")]);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("1-Axis")]);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("2-Axis")]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "The group to stop immediately failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
            }
            return;
        }
        private void button_InverseSTOP_Click(object sender, EventArgs e)
        {
            string strTemp;
            uint Result;
            //Command axis in this group to stop immediately without deceleration
            //Result = Motion.mAcm_GpStopEmg(m_GpHand);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("0-Axis")]);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("1-Axis")]);
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.FindStringExact("2-Axis")]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "The group to stop immediately failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
            }
            return;
        }

        #endregion

        //********************************單體法程式區塊 開始************************************//
        //單體法計算
        #region Simplex Method Block
        
        //執行路徑搜尋
        #region Search Path Button Call Simplex Method
        public void button_SearchPath_Click(object sender, EventArgs e)
        {   int clickTimes;//按下次數
            object tag = this.BtnOpenBoard.Tag;
            if (tag == null)
            {
                clickTimes = 0;
            }
            else
            {
                clickTimes = Convert.ToInt32(tag);
            }
            
            this.BtnOpenBoard.Tag = ++clickTimes;

            if ((clickTimes % 2) == 1)
            {
                //假如沒有設置初始點和終點則無法執行路徑搜尋 不做任何事
                if (Global.FXu != 0 && Global.FYu != 0 && Global.FXv != 0 && Global.FYv != 0 && Global.IXu != 0 && Global.IYu != 0 && Global.IXv != 0 && Global.IYv != 0)
                {
                    Thread t = new Thread(simplex_method_one);
                    t.Start();
                    Thread.Sleep(10);
                }
                else
                {
                    /*
                    Thread t = new Thread(testcount);
                    t.Start();
                    Thread.Sleep(100);

                    Console.WriteLine("Not Setting Image Data");
                    */
                }
            }
            else
            {
              
            }

        }
        #endregion

        //讀取程式winapp4的影像資訊連接
        #region Get Image Data
        void ReadData()
        {
            /*var t = Task.Run(async delegate
            {
                await Task.Delay(2000);
            });*/

            while (true)
            {
                if (Form1.IsFileOccupied(@"C:\2\ImageData3.txt"))
                {
                    Console.WriteLine("Waiting to read the information.....");
                    break;
                }
            }
            Thread.Sleep(100);
            //t.Wait();

            StreamReader sr = new StreamReader(@"\\Desktop-45lcfok\2\ImageData.txt", false);

            string rx = sr.ReadLine();
            string ry = sr.ReadLine();

            ImageCoordinate.RC_X = Int32.Parse(rx);
            ImageCoordinate.RC_Y = Int32.Parse(ry);
            sr.Close();
        }

        void ReadData2()
        {
            /*  var t = Task.Run(async delegate
              {
                  await Task.Delay(500);
              });*/

            /*while (true)
            {
                if (Form1.IsFileOccupied(@"C:\ImageData4.txt"))
                {
                    Console.WriteLine("Fuck You");
                    break;
                }
            }*/
            // Thread.Sleep(500);
            /*while (true)
            {
                if (Form1.IsFileOccupied(@"C:\2\ImageData3.txt"))
                {
                    Console.WriteLine("Waiting to read the information.....");
                    break;
                }
            }*/
            Thread.Sleep(80);

            StreamReader sr2 = new StreamReader(@"\\Desktop-45lcfok\2\ImageData2.txt", false);

            string lx = sr2.ReadLine();
            string ly = sr2.ReadLine();

            ImageCoordinate.LC_X = Int32.Parse(lx);
            ImageCoordinate.LC_Y = Int32.Parse(ly);
            sr2.Close();
        }
        #endregion

        //計算路徑上的座標點並且儲存 (Method 1)
        #region   Calculate The Points On Path
        public void Points_On_Path(int N, double[] XXu, double[] YYu, double[] XXv, double[] YYv)
        {
            Console.WriteLine("Calculate The Points On Path");
            double FXu = Global.FXu;
            double FYu = Global.FYu;
            double FXv = Global.FXv;
            double FYv = Global.FYv;
            double IXu = Global.IXu;
            double IYu = Global.IYu;
            double IXv = Global.IXv;
            double IYv = Global.IYv;
            double k = N;
            double uXunit = 0.0;//由於影像座標點皆為整數
            double uYunit = 0.0;//所以在計算下一點座標位置前可以先做四捨五入
            double vXunit = 0.0;//
            double vYunit = 0.0;

            uXunit = (FXu - IXu) / k;//計算出下一點座標位置後再做四捨五入
            uYunit = (FYu - IYu) / k;//
            vXunit = (FXv - IXv) / k;//
            vYunit = (FYv - IYv) / k;//

            if (uYunit < 0 && vYunit < 0) //以Y軸像素為基準
            {
                Search_Standard = 1;//代表是向上搜尋
            }
            else
            {
                Search_Standard = 0;//代表是向下搜尋
            }

            int c = N + 1;
            double[] Temp1 = new double[c];
            double[] Temp2 = new double[c];
            double[] Temp3 = new double[c];
            double[] Temp4 = new double[c];

            Console.WriteLine("uXunit=" + uXunit.ToString());
            Console.WriteLine("uYunit=" + uYunit.ToString());
            Console.WriteLine("vXunit=" + vXunit.ToString());
            Console.WriteLine("vYunit=" + vYunit.ToString());


            XXu[0] = Global.IXu;//初始座標已知先儲存
            YYu[0] = Global.IYu;//
            XXv[0] = Global.IXv;//
            YYv[0] = Global.IYv;//

            Console.WriteLine("XXu[0]=" + XXu[0].ToString());
            Console.WriteLine("YYu[0]=" + YYu[0].ToString());
            Console.WriteLine("XXv[0]=" + XXv[0].ToString());
            Console.WriteLine("YYv[0]=" + YYv[0].ToString());


            XXu[N] = Global.FXu;//終點座標已知先儲存
            YYu[N] = Global.FYu;//
            XXv[N] = Global.FXv;//
            YYv[N] = Global.FYv;//

            Console.WriteLine("XXu[N]=" + XXu[N].ToString());
            Console.WriteLine("YYu[N]=" + YYu[N].ToString());
            Console.WriteLine("XXv[N]=" + XXv[N].ToString());
            Console.WriteLine("YYv[N]=" + YYv[N].ToString());

            for (int i = 1; i < N; i++)//透過前面計算出來的單位距離，計算路徑上的每個下一點座標
            {
                if (i <= 1)
                {
                    Temp1[i] = XXu[i - 1] + uXunit;
                    Temp2[i] = YYu[i - 1] + uYunit;
                    Temp3[i] = XXv[i - 1] + vXunit;
                    Temp4[i] = YYv[i - 1] + vYunit;
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("Temp1[" + i.ToString() + "]=" + Temp1[i].ToString());
                    Console.WriteLine("Temp2[" + i.ToString() + "]=" + Temp2[i].ToString());
                    Console.WriteLine("Temp3[" + i.ToString() + "]=" + Temp3[i].ToString());
                    Console.WriteLine("Temp4[" + i.ToString() + "]=" + Temp4[i].ToString());

                    XXu[i] = Math.Round(Temp1[i], 0, MidpointRounding.AwayFromZero);
                    YYu[i] = Math.Round(Temp2[i], 0, MidpointRounding.AwayFromZero);
                    XXv[i] = Math.Round(Temp3[i], 0, MidpointRounding.AwayFromZero);
                    YYv[i] = Math.Round(Temp4[i], 0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    Temp1[i] = Temp1[i - 1] + uXunit;
                    Temp2[i] = Temp2[i - 1] + uYunit;
                    Temp3[i] = Temp3[i - 1] + vXunit;
                    Temp4[i] = Temp4[i - 1] + vYunit;
                    Console.WriteLine("###################################################");
                    Console.WriteLine("Temp1[" + i.ToString() + "]=" + Temp1[i].ToString());
                    Console.WriteLine("Temp2[" + i.ToString() + "]=" + Temp2[i].ToString());
                    Console.WriteLine("Temp3[" + i.ToString() + "]=" + Temp3[i].ToString());
                    Console.WriteLine("Temp4[" + i.ToString() + "]=" + Temp4[i].ToString());
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("Temp1[" + (i - 1).ToString() + "]=" + Temp1[i - 1].ToString());
                    Console.WriteLine("Temp2[" + (i - 1).ToString() + "]=" + Temp2[i - 1].ToString());
                    Console.WriteLine("Temp3[" + (i - 1).ToString() + "]=" + Temp3[i - 1].ToString());
                    Console.WriteLine("Temp4[" + (i - 1).ToString() + "]=" + Temp4[i - 1].ToString());
                    XXu[i] = Math.Round(Temp1[i], 0, MidpointRounding.AwayFromZero);
                    YYu[i] = Math.Round(Temp2[i], 0, MidpointRounding.AwayFromZero);
                    XXv[i] = Math.Round(Temp3[i], 0, MidpointRounding.AwayFromZero);
                    YYv[i] = Math.Round(Temp4[i], 0, MidpointRounding.AwayFromZero);
                }

                Console.WriteLine("XXu[" + i.ToString() + "]=" + XXu[i].ToString() + " ," + "YYu[" + i.ToString() + "]=" + YYu[i].ToString());
                Console.WriteLine("XXv[" + i.ToString() + "]=" + XXv[i].ToString() + " ," + "YYv[" + i.ToString() + "]=" + YYv[i].ToString());
            }
            StreamWriter sw = new StreamWriter(@"C:\Store_Path_Point\Point_Data.txt", false);
            sw.WriteLine("    XXu  YYu  XXv  YYv  ");
            for (int g = 0; g < XXu.Length; g++)
            {
                if (g < 10) { sw.WriteLine(Convert.ToString(g) + " : " + Convert.ToString(XXu[g]) + "  " + Convert.ToString(YYu[g]) + "  " + Convert.ToString(XXv[g]) + "  " + Convert.ToString(YYv[g])); }
                else { sw.WriteLine(Convert.ToString(g) + ": " + Convert.ToString(XXu[g]) + "  " + Convert.ToString(YYu[g]) + "  " + Convert.ToString(XXv[g]) + "  " + Convert.ToString(YYv[g])); }

            }
            sw.Close();
        }
        #endregion

        //計算路徑上的座標點並且儲存 (Method 2)
        #region   Calculate The Points On Path
        public void Points_On_Path_two(int N, double[] XXu, double[] YYu, double[] XXv, double[] YYv)
        {
            Console.WriteLine("Calculate The Points On Path");

            double FXu = 0;
            double FYu = 0;
            double FXv = 0;
            double FYv = 0;
            double IXu = 0;
            double IYu = 0;
            double IXv = 0;
            double IYv = 0;

            double uXunit = 0.0;
            double uYunit = 0.0;
            double vXunit = 0.0;
            double vYunit = 0.0;

            double[] Temp1 = new double[9];
            double[] Temp2 = new double[9];
            double[] Temp3 = new double[9];
            double[] Temp4 = new double[9];

            double[] TXu = new double[10];
            double[] TYu = new double[10];
            double[] TXv = new double[10];
            double[] TYv = new double[10];

            int pointN = Convert.ToInt32(textBox_pointset.Text);
            int partN = Convert.ToInt32(textBox_PartNum2.Text);
            int h = 1;

            XXu[0] = RecordPoint[0][0];
            YYu[0] = RecordPoint[0][1];
            XXv[0] = RecordPoint[0][2];
            YYv[0] = RecordPoint[0][3];

            XXu[N] = RecordPoint[pointN][0];
            YYu[N] = RecordPoint[pointN][1];
            XXv[N] = RecordPoint[pointN][2];
            YYv[N] = RecordPoint[pointN][3];


            for (int g = 0; g <= 11; g++) //共12段  0~11
            {
                FXu = RecordPoint[g + 1][0];
                FYu = RecordPoint[g + 1][1];
                FXv = RecordPoint[g + 1][2];
                FYv = RecordPoint[g + 1][3];

                IXu = RecordPoint[g][0];
                IYu = RecordPoint[g][1];
                IXv = RecordPoint[g][2];
                IYv = RecordPoint[g][3];

                uXunit = (FXu - IXu) / partN;//計算出下一點座標位置後再做四捨五入
                uYunit = (FYu - IYu) / partN;//
                vXunit = (FXv - IXv) / partN;//
                vYunit = (FYv - IYv) / partN;//

                for (int i = 0; i <= (partN - 1); i++)//透過前面計算出來的單位距離，計算路徑上的每個下一點座標
                {
                    if (i < 1)
                    {
                        TXu[i] = RecordPoint[g][0];
                        TYu[i] = RecordPoint[g][1];
                        TXv[i] = RecordPoint[g][2];
                        TYv[i] = RecordPoint[g][3];

                        Temp1[i] = TXu[i] + uXunit;
                        Temp2[i] = TYu[i] + uYunit;
                        Temp3[i] = TXv[i] + vXunit;
                        Temp4[i] = TYv[i] + vYunit;

                        TXu[i + 1] = Math.Round(Temp1[i], 0, MidpointRounding.AwayFromZero);
                        TYu[i + 1] = Math.Round(Temp2[i], 0, MidpointRounding.AwayFromZero);
                        TXv[i + 1] = Math.Round(Temp3[i], 0, MidpointRounding.AwayFromZero);
                        TYv[i + 1] = Math.Round(Temp4[i], 0, MidpointRounding.AwayFromZero);

                    }
                    else
                    {
                        Temp1[i] = Temp1[i - 1] + uXunit;
                        Temp2[i] = Temp2[i - 1] + uYunit;
                        Temp3[i] = Temp3[i - 1] + vXunit;
                        Temp4[i] = Temp4[i - 1] + vYunit;

                        TXu[i + 1] = Math.Round(Temp1[i], 0, MidpointRounding.AwayFromZero);
                        TYu[i + 1] = Math.Round(Temp2[i], 0, MidpointRounding.AwayFromZero);
                        TXv[i + 1] = Math.Round(Temp3[i], 0, MidpointRounding.AwayFromZero);
                        TYv[i + 1] = Math.Round(Temp4[i], 0, MidpointRounding.AwayFromZero);
                    }

                }

                int d = 1;

                while (d < partN)
                {
                    XXu[h] = TXu[d];
                    YYu[h] = TYu[d];
                    XXv[h] = TXv[d];
                    YYv[h] = TYv[d];
                    h += 1;
                    d += 1;
                }

                XXu[h] = RecordPoint[g + 1][0];
                YYu[h] = RecordPoint[g + 1][1];
                XXv[h] = RecordPoint[g + 1][2];
                YYv[h] = RecordPoint[g + 1][3];

                h += 1;
            }

            //寫入值
            StreamWriter sw = new StreamWriter(@"C:\Store_Path_Point_2\Point_Data2.txt", false);
            sw.WriteLine("     XXu  YYu  XXv  YYv  ");
            for (int g = 0; g < XXu.Length; g++)
            {
                if (g < 10) { sw.WriteLine(Convert.ToString(g) + "  : " + Convert.ToString(XXu[g]) + "  " + Convert.ToString(YYu[g]) + "  " + Convert.ToString(XXv[g]) + "  " + Convert.ToString(YYv[g])); }
                else if (g < 100) { sw.WriteLine(Convert.ToString(g) + " : " + Convert.ToString(XXu[g]) + "  " + Convert.ToString(YYu[g]) + "  " + Convert.ToString(XXv[g]) + "  " + Convert.ToString(YYv[g])); }
                else { sw.WriteLine(Convert.ToString(g) + ": " + Convert.ToString(XXu[g]) + "  " + Convert.ToString(YYu[g]) + "  " + Convert.ToString(XXv[g]) + "  " + Convert.ToString(YYv[g])); }
            }
            sw.Close();
        }
        #endregion

        //移動至初始點位置
        #region Move To Initial Pos
        public void Move_To_Initial_Pos(double theta1, double theta2, double theta3)
        {
            Console.WriteLine("Move To Initial Pos");
            Three_Axis_Control(theta1, theta2, theta3);
            Thread.Sleep(3000);// Delay 5 second
        }
        #endregion

        //三軸控制
        #region Three_Axis_Control
        public void Three_Axis_Control(double theta1, double theta2, double theta3)
        {
            Console.WriteLine("Three_Axis_Control");

            //Console.WriteLine("theta1=" + theta1.ToString() + " " + "theta2=" + theta2.ToString() + " " + "theta3=" + theta3.ToString());
            double L, R, M;

            if (theta1 >= 85)
               theta1 = 85;
            
            if (theta2 >= 85)
               theta2 = 85;

            if (theta3 >= 85)
               theta3 = 85;
          
            if (theta1 < 0)
                theta1 = 0;

            if (theta2 < 0)
                theta2 = 0;

            if (theta3 < 0)
               theta3 = 0;

            L = theta2; R = theta1; M = theta3;
            //Console.WriteLine("theta1=" + theta1.ToString() + " " + "theta2=" + theta2.ToString() + " " + "theta3=" + theta3.ToString());

            if (L <= 85 && R <= 85 && M <= 85)
            {
                Motor_Positive(R, L, M);
            }

            Thread.Sleep(50); 
        }
        #endregion

        //三軸控制(without delay)
        #region Three_Axis_Control
        public void Three_Axis_Control_withoutdelay(double theta1, double theta2, double theta3)
        {
            Console.WriteLine("Three_Axis_Control");

            //Console.WriteLine("theta1=" + theta1.ToString() + " " + "theta2=" + theta2.ToString() + " " + "theta3=" + theta3.ToString());
            double L, R, M;

            if (theta1 >= 85)
            {
                theta1 = 80;
            }

            if (theta2 >= 85)
            {
                theta2 = 80;
            }

            if (theta3 >= 85)
            {
                theta3 = 80;
            }


            if (theta1 < 0)
            {
                theta1 = 0;
            }

            if (theta2 < 0)
            {
                theta2 = 0;
            }

            if (theta3 < 0)
            {
                theta3 = 0;
            }

            R = theta1;
            L = theta2;
            M = theta3;

            //Console.WriteLine("theta1=" + theta1.ToString() + " " + "theta2=" + theta2.ToString() + " " + "theta3=" + theta3.ToString());

            if (L <= 85 && R <= 85 && M <= 85)
            {
                Motor_Positive(R, L, M);
            }

            //Thread.Sleep(1000);
            //System.Threading.Thread.Sleep(1500);// Delay 1.5 second
        }
        #endregion

        //插入排序法(以改用氣泡排序法) 
        #region Insertion Sort
        public void Insertion_Sort(double[][] bs_theta, int[] J)//step 3 ,step 15
        {
            /*for (int i = 1; i < J.Length; i++)
            {
                int temp = J[i];
                double[] temp2 = new double[] { 0.0, 0.0, 0.0 };
                temp2[0] = bs_theta[i][0];
                temp2[1] = bs_theta[i][1];
                temp2[2] = bs_theta[i][2];
                //int otemp = oder[i];
                int g = i - 1;
                while (g > -1 && temp < J[g])
                {
                    J[g + 1] = J[g];
                    bs_theta[g + 1][0] = bs_theta[g][0];
                    bs_theta[g + 1][1] = bs_theta[g][1];
                    bs_theta[g + 1][2] = bs_theta[g][2];
                    g--;
                }
                J[g + 1] = temp;
                //oder[j + 1] = otemp;
            }
            return bs_theta;*/
            //排序前
            for (int k = 0; k <= 6; k++)
            {
                Console.WriteLine("j[" + Convert.ToString(k) + "]=" + Convert.ToString(J[k]) + "  "
                    + "Theta1=" + Convert.ToString(bs_theta[k][0]) + "Theta2=" + Convert.ToString(bs_theta[k][1]) + "Theta3=" + Convert.ToString(bs_theta[k][2]));
            }

            //以下為氣泡排序
            for (int h = 0; h <= J.Length; h++)
            {
                for (int c = 0; c <= 5; c++)
                {
                    if (J[c] > J[c + 1])
                    {
                        int temp1 = 0;
                        double[][] temp2 = new double[7][] {new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 },
                                                            new[] { 0.0, 0.0, 0.0 }
                                                            };
                        temp1 = J[c];
                        temp2[c][0] = bs_theta[c][0];
                        temp2[c][1] = bs_theta[c][1];
                        temp2[c][2] = bs_theta[c][2];
                        J[c] = J[c + 1];
                        bs_theta[c][0] = bs_theta[c + 1][0];
                        bs_theta[c][1] = bs_theta[c + 1][1];
                        bs_theta[c][2] = bs_theta[c + 1][2];
                        J[c + 1] = temp1;
                        bs_theta[c + 1][0] = temp2[c][0];
                        bs_theta[c + 1][1] = temp2[c][1];
                        bs_theta[c + 1][2] = temp2[c][2];
                    }
                }
            }

            Console.WriteLine("排序後");
            for (int L = 0; L <= 6; L++)
            {
                Console.WriteLine("j[" + Convert.ToString(L) + "]=" + Convert.ToString(J[L]) + "  "
                    + "Theta1=" + Convert.ToString(bs_theta[L][0]) + "Theta2=" + Convert.ToString(bs_theta[L][1]) + "Theta3=" + Convert.ToString(bs_theta[L][2]));
            }
        }
        #endregion

        //初始四點誤差函數計算
        #region   FError Function Calculate
        public void FError_Function_Calculate(double[][] theta, int[] j, int n, double Xu, double Yu, double Xv, double Yv)
        {
            for (int k = 0; k <= n; k++)//
            {
                /*var t = Task.Run(async delegate
                {
                    await Task.Delay(1000);
                });*/

                Console.WriteLine("FError_Function_Calculate" + "  " + "k=" + k.ToString());
                Three_Axis_Control(theta[k][0], theta[k][1], theta[k][2]);
                //  Console.WriteLine("theta[k][0]=" + theta[k][0].ToString() + " " + "theta[k][1]=" + theta[k][1].ToString() + " " + "theta[k][2]=" + theta[k][2].ToString());

                Thread.Sleep(500);
                ReadData();
                ReadData2();
                //t.Wait();

                Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
                Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
                j[k] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));
                Console.WriteLine("j" + k.ToString() + "=" + j[k].ToString());
            }
        }
        #endregion

        //一般誤差函數計算
        #region   Error Function Calculate
        public void Error_Function_Calculate(double[] theta, int[] j, double Xu, double Yu, double Xv, double Yv)
        {
            

            Console.WriteLine("Error Function Calculate");
            Three_Axis_Control(theta[0], theta[1], theta[2]);
 
            Thread.Sleep(500);
           
            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j[0] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));
        }
        #endregion

        //Jn 誤差函數計算
        #region   For JN Error Function Calculate
        public int JNError_Function_Calculate(double[][] theta, int j, double Xu, double Yu, double Xv, double Yv)
        {
            /*var t = Task.Run(async delegate
            {
                await Task.Delay(1000);
            });*/

            Console.WriteLine("J N Error Function Calculate");
            Three_Axis_Control(theta[6][0], theta[6][1], theta[6][2]);
            Thread.Sleep(1000);
            //t.Wait();
            ReadData();
            ReadData2();

            //t.Wait();
            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));

            return j;
        }
        #endregion

        //計算N的數值
        #region Check Unit
        public int check_unit()
        {
            int N = 0;
            int k = 1;
            double FXu = Global.FXu;
            double FYu = Global.FYu;
            double FXv = Global.FXv;
            double FYv = Global.FYv;
            double IXu = Global.IXu;
            double IYu = Global.IYu;
            double IXv = Global.IXv;
            double IYv = Global.IYv;
            double uXunit = 0.0;
            double uYunit = 0.0;
            double vXunit = 0.0;
            double vYunit = 0.0;

            while (true)
            {
                uXunit = (FXu - IXu) / k;
                uYunit = (FYu - IYu) / k;//
                vXunit = (FXv - IXv) / k;
                vYunit = (FYv - IYv) / k;
                uXunit = Math.Abs(uXunit);
                uYunit = Math.Abs(uYunit);
                vXunit = Math.Abs(vXunit);
                vYunit = Math.Abs(vYunit);
                double p = 1;
                double p2 = 1;

                if ((uXunit <= p && vXunit <= p) || (uYunit <= p && vYunit <= p))
                {
                    if ((uXunit <= p && vXunit <= p) && (uYunit >= p2 || vYunit >= p2))
                    {
                        k++;
                    }
                    else if ((uYunit <= p && vYunit <= p) && (uXunit >= p2 || vXunit >= p2))
                    {
                        k++;
                    }
                    else
                    {
                        N = k;
                        break;
                    }
                }
                else
                {
                    k++;
                }
            }

            return N;
        }
        #endregion

        //計算 theta_bar
        #region Calculate Theta Bar
        public void Theta_Bar(double[] Sum, double[][] as_theta, int n)
        {
            Console.WriteLine("Calculate Theta Bar");
            //陣列元素相加後平均但是只取誤差函數小的前三點座標角度做相加
            //迴圈執行的順序為先取前三個座標點(Q0 Q1 Q2)，再依序取每個座標點的 theta 1 theta 2 theta 3
            Console.WriteLine("Sum[0]=" + Sum[0].ToString() + ", " + "Sum[1]=" + Sum[1].ToString() + ", " + "Sum[2]=" + Sum[2].ToString());
            for (int g = 0; g <= 2; g++)     // g = 0 ~ 2   決定三個選擇的 theta 依序是 theta 1 theta 2 theta 3
            {
                for (int v = 0; v <= n - 1; v++) // v = 0 ~ 2   前三個點座標點 Q0 Q1 Q2 Q3=Qn
                {
                    Sum[g] = Sum[g] + as_theta[v][g];// Sum[] 先將各theta 相加 
                    //Console.WriteLine("Sum["+g.ToString()+"]=" + "  " + Sum[g].ToString());
                }
                //陣列元素平均 但是只取誤差函數小的前三項作相加後除以3 6
                Sum[g] = Sum[g] / 6; // 
                //Console.WriteLine("Sum[" + g.ToString() + "]=" + "  " + Sum[g].ToString()+"  "+"Bar");
            }
            //Console.WriteLine("Sum[0]=" + Sum[0].ToString() + ", " + "Sum[1]=" + Sum[1].ToString() + ", " + "Sum[2]=" + Sum[2].ToString());
        }
        #endregion

        //Theta_n = Theta_new
        #region Theta New To Theta N
        public void ThetaNewToThetaN(int n, double[][] as_theta, double[] theta_new)
        {
            Console.WriteLine("Theta New To Theat N");
            Console.WriteLine("Theta_new1=" + theta_new[0] + "Theta_new2=" + theta_new[1] + "Theta_new3=" + theta_new[2]);
            Console.WriteLine("Theta1_n=" + as_theta[n][0] + "Theta2_n=" + as_theta[n][1] + "Theta3_n=" + as_theta[n][2]);
            for (int A = 0; A <= 2; A++)    //A 依序選擇 theta
            {
                as_theta[n][A] = theta_new[A];  //Let theta_n = theta_new
            }
            Console.WriteLine("Theta1_n=" + as_theta[n][0] + "Theta2_n=" + as_theta[n][1] + "Theta3_n=" + as_theta[n][2]);
        }
        #endregion

        //反射
        #region  Reflection Movement
        //j , theta, 
        public void Reflection_move(int[] j, double[] theta, double[] Sum, double[][] as_theta, double Xu, double Yu, double Xv, double Yv)
        {
            int alpha = 1;

            for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
            {
                //L=n   決定Q座標點持續選擇 Qn = theta_n

                theta[K] = Sum[K] + alpha * (Sum[K] - as_theta[6][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                Console.WriteLine("theta[" + K.ToString() + "]_rrr=" + theta[K].ToString());
            }


            Console.WriteLine("Error Function Calculate");
            Three_Axis_Control(theta[0], theta[1], theta[2]);

            //t.Wait();
            Thread.Sleep(500);
            ReadData();
            ReadData2();
            //t.Wait();

            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j[0] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));
        }
        #endregion

        //擴張
        #region Expansion Movement
        public void Expansion_move(int[] j, double[] theta, double[] Sum, double[][] as_theta, double Xu, double Yu, double Xv, double Yv)
        {
            //int Now = 0;
            //int Old = 0;
            //double gama = 1.1;
            //double bestgama = 0.0;
            //double[] Temp=new double[3];
            double gama = 2.0;
            //典型
            for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
            {
                //L=n   決定Q座標點持續選擇 Qn = theta_n

                theta[K] = Sum[K] + gama * (Sum[K] - as_theta[6][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                Console.WriteLine("theta[" + K.ToString() + "]_eee=" + theta[K].ToString());
            }
            Three_Axis_Control(theta[0], theta[1], theta[2]);

            //t.Wait();
            Thread.Sleep(500);
            ReadData();
            ReadData2();
            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j[0] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));

            //變量
            /*while (gama < 2.1)
            {
                Console.WriteLine("gama=" + gama.ToString());
                for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
                {
                    //L=n   決定Q座標點持續選擇 Qn = theta_n

                    Temp[K] = Sum[K] + gama * (Sum[K] - as_theta[3][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                    //Console.WriteLine("theta[" + K.ToString() + "]=" + Temp[K].ToString());
                }

                //Console.WriteLine("Error Function Calculate");
                Three_Axis_Control(Temp[0], Temp[1], Temp[2]);

                //t.Wait();
                Thread.Sleep(500);
                ReadData();
                ReadData2();
                //t.Wait();

                //Console.WriteLine("Global.rx=" + Global.rx.ToString() + "Xu=" + Xu.ToString() + "Global.ry" + Global.ry.ToString() + "Yu=" + Yu.ToString());
                //Console.WriteLine("Global.lx=" + Global.lx.ToString() + "Xv=" + Xv.ToString() + "Global.ly" + Global.ly.ToString() + "Yv=" + Yv.ToString());
                Now = Convert.ToInt32(Math.Pow((Global.rx - Xu), 2)) + Convert.ToInt32(Math.Pow((Global.ry - Yu), 2)) + Convert.ToInt32(Math.Pow((Global.lx - Xv), 2)) + Convert.ToInt32(Math.Pow((Global.ly - Yv), 2));


                if (Old == 0)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    bestgama = gama;
                }

                if (Now < Old)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    Console.WriteLine("j="+j[0].ToString());
                    bestgama = gama;
                }

                if (j[0]==2)
                {
                    break;
                }

                gama = gama + 0.1;
            }
            Console.WriteLine("Best Gama=" + bestgama.ToString());
            */
        }
        #endregion

        //外收縮
        #region  Outer Shrink
        public void OuterShrink_move(int[] j, double[] theta, double[] Sum, double[][] as_theta, double Xu, double Yu, double Xv, double Yv)
        {
            /*int Now = 0;
            int Old = 0;
            double beta = 0.1;
            double bestbeta = 0.0;
            double[] Temp = new double[3];*/
            double beta = 0.5;
            //典型
            for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
            {
                //L=n   決定Q座標點持續選擇 Qn = theta_n

                theta[K] = Sum[K] + beta * (Sum[K] - as_theta[6][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                Console.WriteLine("theta[" + K.ToString() + "]_c=" + theta[K].ToString());
            }
            Three_Axis_Control(theta[0], theta[1], theta[2]);

            //t.Wait();
            Thread.Sleep(500);
            ReadData();
            ReadData2();
            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j[0] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));

            //變量
            /*while (beta <=0.9)
            {
                Console.WriteLine("beta+=" + beta.ToString());

                for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
                {
                    //L=n   決定Q座標點持續選擇 Qn = theta_n

                    Temp[K] = Sum[K] + beta * (Sum[K] - as_theta[3][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                   //Console.WriteLine("theta[" + K.ToString() + "]=" + Temp[K].ToString());
                }

               

                //Console.WriteLine("Error Function Calculate");
                Three_Axis_Control(Temp[0], Temp[1], Temp[2]);
                Thread.Sleep(500);
                //t.Wait();
                ReadData();
                ReadData2();
                //t.Wait();

                //Console.WriteLine("Global.rx=" + Global.rx.ToString() + "Xu=" + Xu.ToString() + "Global.ry" + Global.ry.ToString() + "Yu=" + Yu.ToString());
                //Console.WriteLine("Global.lx=" + Global.lx.ToString() + "Xv=" + Xv.ToString() + "Global.ly" + Global.ly.ToString() + "Yv=" + Yv.ToString());
                Now = Convert.ToInt32(Math.Pow((Global.rx - Xu), 2)) + Convert.ToInt32(Math.Pow((Global.ry - Yu), 2)) + Convert.ToInt32(Math.Pow((Global.lx - Xv), 2)) + Convert.ToInt32(Math.Pow((Global.ly - Yv), 2));

                if (Old == 0)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    bestbeta= beta;
                }

                if (Now < Old)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    Console.WriteLine("j=" + j[0].ToString());
                    bestbeta = beta;
                }
                
                if (j[0] == 2)
                {
                    break;
                }

                beta = beta + 0.1;
            }
            Console.WriteLine("Best Betaa=" + bestbeta.ToString());
            */

        }
        #endregion

        //內收縮
        #region  Inside Shrink
        public void InsideShrink_move(int[] j, double[] theta, double[] Sum, double[][] as_theta, double Xu, double Yu, double Xv, double Yv)
        {
            /*int Now = 0;
            int Old = 0;
            double beta = 0.1;
            double bestbeta = 0.0;
            double[] Temp = new double[3];*/
            double beta = 0.5;
            //典型
            for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
            {
                //L=n   決定Q座標點持續選擇 Qn = theta_n

                theta[K] = Sum[K] - beta * (Sum[K] - as_theta[6][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                Console.WriteLine("theta[" + K.ToString() + "]_cc=" + theta[K].ToString());
            }
            Three_Axis_Control(theta[0], theta[1], theta[2]);

            //t.Wait();
            Thread.Sleep(500);
            ReadData();
            ReadData2();

            Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
            Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());
            j[0] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));

            //變量
            /*while (beta < 1)
            {
                Console.WriteLine("beta-=" + beta.ToString());

                for (int K = 0; K <= 2; K++)                                     //K     決定選擇哪一個 theta
                {
                    //L=n   決定Q座標點持續選擇 Qn = theta_n

                    Temp[K] = Sum[K] - beta * (Sum[K] - as_theta[3][K]);    //theta_r = theta_bar + alpha*(theta_bar-theta_n)
                    //Console.WriteLine("theta[" + K.ToString() + "]=" + Temp[K].ToString());
                }

                //Console.WriteLine("Error Function Calculate");
                Three_Axis_Control(Temp[0], Temp[1], Temp[2]);

                //t.Wait();
                Thread.Sleep(500);
                ReadData();
                ReadData2();
                //t.Wait();

                //Console.WriteLine("Global.rx=" + Global.rx.ToString() + "Xu=" + Xu.ToString() + "Global.ry" + Global.ry.ToString() + "Yu=" + Yu.ToString());
                //Console.WriteLine("Global.lx=" + Global.lx.ToString() + "Xv=" + Xv.ToString() + "Global.ly" + Global.ly.ToString() + "Yv=" + Yv.ToString());
                Now = Convert.ToInt32(Math.Pow((Global.rx - Xu), 2)) + Convert.ToInt32(Math.Pow((Global.ry - Yu), 2)) + Convert.ToInt32(Math.Pow((Global.lx - Xv), 2)) + Convert.ToInt32(Math.Pow((Global.ly - Yv), 2));

                if (Old == 0)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    bestbeta = beta;
                }

                if (Now < Old)
                {
                    Old = Now;
                    theta[0] = Temp[0];
                    theta[1] = Temp[1];
                    theta[2] = Temp[2];
                    j[0] = Old;
                    Console.WriteLine("j=" + j[0].ToString());
                    bestbeta = beta;
                }
                
                if (j[0] == 2)
                {
                    break;
                }

                beta = beta + 0.1;
            }
            Console.WriteLine("Best Betaa=" + bestbeta.ToString());
            */
        }
        #endregion

        //多維收縮
        #region Multidimensional Contraction
        //Multidimensional_Contraction(n,as_theta,j,XXu[thi],YYu[thi],XXv[thi],YYv[thi]);
        public void Multidimensional_Contraction(int n, double[][] as_theta, int[] j, double Xu, double Yu, double Xv, double Yv)
        {
            Console.WriteLine("Multidimensional Contraction");
            //double g = 0.45;
            //double[][] Temp = new double[][] { };
            //int Temp_E = 0;
            //Temp = as_theta;
            double beta_paramter = 0.0;

            Console.WriteLine("Search_Standard=" + Convert.ToString(Search_Standard));

            if (Search_Standard == 0) //向下搜尋 0
            {
                beta_paramter = 0.55;
            }
            else if (Search_Standard == 1)                    //向上搜尋 1
            {
                beta_paramter = 0.45;
            }
            else
            {
                beta_paramter = 0.55;

            }

            for (int Y = 1; Y <= 6; Y++)            //Y 決定 i 值 ; theta_i ， i = 1, 2, 3....n
            {
                for (int T = 0; T <= 2; T++)    //T 決定 theta 1 theta 2 theta 3 
                {
                    as_theta[Y][T] = beta_paramter * (as_theta[0][T] + as_theta[Y][T]); //theta_i = 0.5 *(theta_0 + theta_i)
                }
                Three_Axis_Control(as_theta[Y][0], as_theta[Y][1], as_theta[Y][2]);

                Thread.Sleep(550);
                ReadData();
                ReadData2();

                Console.WriteLine("Global.rx=" + "" + ImageCoordinate.RC_X.ToString() + "" + "Xu=" + Xu.ToString() + "" + "Global.ry" + ImageCoordinate.RC_Y.ToString() + "" + "Yu=" + Yu.ToString());
                Console.WriteLine("Global.lx=" + "" + ImageCoordinate.LC_X.ToString() + "" + "Xv=" + Xv.ToString() + "" + "Global.ly" + ImageCoordinate.LC_Y.ToString() + "" + "Yv=" + Yv.ToString());

                j[Y] = Convert.ToInt32(Math.Pow((ImageCoordinate.RC_X - Xu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.RC_Y - Yu), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_X - Xv), 2)) + Convert.ToInt32(Math.Pow((ImageCoordinate.LC_Y - Yv), 2));
                Console.WriteLine("j[" + Y.ToString() + "]=" + j[Y].ToString());
            }

            /*
            while (true)
            {
                for (int Y = 1; Y <= n; Y++)            //Y 決定 i 值 ; theta_i ， i = 1, 2, 3....n
                {
                    for (int T = 0; T <= n - 1; T++)    //T 決定 theta 1 theta 2 theta 3 
                    {
                        //as_theta[Y][T] = 0.5 * (as_theta[0][T] + as_theta[Y][T]); //theta_i = 0.5 *(theta_0 + theta_i)
                        Console.WriteLine("Temp" + "[" + Y.ToString() + "]" + "[" + T.ToString() + "]=" + Temp[Y][T].ToString());
                        Console.WriteLine("Temp[0]" + "[" + T.ToString() + "]=" + Temp[0][T].ToString());

                        Temp[Y][T] = g * (Temp[0][T] + Temp[Y][T]);
                        Console.WriteLine("Temp" + "[" + Y.ToString() + "]" + "[" + T.ToString() + "]=" + Temp[Y][T].ToString());
                        //Console.WriteLine("as_theta" + "["+Y.ToString()+"]"+ "[" + T.ToString() + "]="+ as_theta[Y][T].ToString());
                    }

                    //Three_Axis_Control(as_theta[Y][0], as_theta[Y][1], as_theta[Y][2]);
                    Three_Axis_Control(Temp[Y][0], Temp[Y][1], Temp[Y][2]);
                    Thread.Sleep(500);// Delay 0.5 second

                    //j[Y] = Convert.ToInt32(Math.Pow((Global.rx - Xu), 2)) + Convert.ToInt32(Math.Pow((Global.ry - Yu), 2)) + Convert.ToInt32(Math.Pow((Global.lx - Xv), 2)) + Convert.ToInt32(Math.Pow((Global.ly - Yv), 2));
                    Temp_E= Convert.ToInt32(Math.Pow((Global.rx - Xu), 2)) + Convert.ToInt32(Math.Pow((Global.ry - Yu), 2)) + Convert.ToInt32(Math.Pow((Global.lx - Xv), 2)) + Convert.ToInt32(Math.Pow((Global.ly - Yv), 2));
                    Console.WriteLine("Temp_E="+Temp_E.ToString());
                    if (Temp_E < j[Y])
                    {
                        Console.WriteLine("Yes Got It!");
                        Console.WriteLine("j="+ Temp_E.ToString());
                        j[Y] = Temp_E;
                        as_theta[Y][0] = Temp[Y][0];
                        as_theta[Y][1] = Temp[Y][1];
                        as_theta[Y][2] = Temp[Y][2];
                    }
                }

                g = g + 0.01;

                if (g>0.55)
                {
                    break;
                }
            }*/
        }
        #endregion

        //儲存搜尋完成的路徑
        #region Save Path
        public void button_SavePath_Click(object sender, EventArgs e)
        {
            StreamWriter sw1 = new StreamWriter(@"C:\Store_Theta\Theta_Data.txt");     //theta_     
            StreamWriter sw2 = new StreamWriter(@"C:\Store_Theta\Theta_1.txt");        //theta_1
            StreamWriter sw3 = new StreamWriter(@"C:\Store_Theta\Theta_2.txt");        //theta_2
            StreamWriter sw4 = new StreamWriter(@"C:\Store_Theta\Theta_3.txt");        //theta_3
            StreamWriter swm1 = new StreamWriter(@"C:\Store_Theta\Theta_1_m.txt");     //theta_1_m
            StreamWriter swm2 = new StreamWriter(@"C:\Store_Theta\Theta_2_m.txt");     //theta_2_m
            StreamWriter swm3 = new StreamWriter(@"C:\Store_Theta\Theta_3_m.txt");     //theta_3_m
            sw1.WriteLine("   Theta_1             Theta_2             Theta_3             ");
            for (int i = 0; i <= Ncount; i++)
            {
                if (i < 10)
                {
                    sw1.WriteLine(Convert.ToString(i) + " : " + Convert.ToString(Theta1[i]) + "          "
                    + Convert.ToString(Theta2[i]) + "          "
                    + Convert.ToString(Theta3[i]) + "          ");
                }
                else
                {
                    sw1.WriteLine(Convert.ToString(i) + ": " + Convert.ToString(Theta1[i]) + "          "
                     + Convert.ToString(Theta2[i]) + "          "
                     + Convert.ToString(Theta3[i]) + "          ");
                }
            }
            Thread.Sleep(1500);

            for (int L = 0; L <= Ncount; L++)
            {
                sw2.WriteLine(Convert.ToString(Theta1[L]));
                sw3.WriteLine(Convert.ToString(Theta2[L]));
                sw4.WriteLine(Convert.ToString(Theta3[L]));
                swm1.WriteLine(Convert.ToString(L) + " " + Convert.ToString(Theta1[L]));
                swm2.WriteLine(Convert.ToString(L) + " " + Convert.ToString(Theta2[L]));
                swm3.WriteLine(Convert.ToString(L) + " " + Convert.ToString(Theta3[L]));

            }
            Thread.Sleep(1500);

            sw1.Close();
            sw2.Close();
            sw3.Close();
            sw4.Close();
            swm1.Close();
            swm2.Close();
            swm3.Close();

            Console.WriteLine("Save Theta Finish");
        }
        #endregion

        //儲存搜尋完成的路徑 M2
        #region Save Path M2
        private void button_m2savepath_Click(object sender, EventArgs e)
        {
            StreamWriter sw1 = new StreamWriter(@"C:\Store_Theta_2\Theta_DataM2.txt");     //theta_     
            StreamWriter sw2 = new StreamWriter(@"C:\Store_Theta_2\Theta_1_m2.txt");        //theta_1
            StreamWriter sw3 = new StreamWriter(@"C:\Store_Theta_2\Theta_2_m2.txt");        //theta_2
            StreamWriter sw4 = new StreamWriter(@"C:\Store_Theta_2\Theta_3_m2.txt");        //theta_3
            StreamWriter swm1 = new StreamWriter(@"C:\Store_Theta_2\Theta_1_m2m.txt");     //theta_1_m
            StreamWriter swm2 = new StreamWriter(@"C:\Store_Theta_2\Theta_2_m2m.txt");     //theta_2_m
            StreamWriter swm3 = new StreamWriter(@"C:\Store_Theta_2\Theta_3_m2m.txt");     //theta_3_m

            sw1.WriteLine("    Theta_1              Theta_2              Theta_3             ");
            for (int i = 0; i <= Ncount_m; i++)
            {
                if (i < 10)
                {
                    sw1.WriteLine(Convert.ToString(i) + " :  " + Convert.ToString(Theta1m2[i]) + "          "
                    + Convert.ToString(Theta2m2[i]) + "          "
                    + Convert.ToString(Theta3m2[i]) + "          ");
                }
                else if (i < 100)
                {
                    sw1.WriteLine(Convert.ToString(i) + ":  " + Convert.ToString(Theta1m2[i]) + "          "
                     + Convert.ToString(Theta2m2[i]) + "          "
                     + Convert.ToString(Theta3m2[i]) + "          ");
                }
                else
                {
                    sw1.WriteLine(Convert.ToString(i) + ":  " + Convert.ToString(Theta1m2[i]) + "          "
                      + Convert.ToString(Theta2m2[i]) + "          "
                      + Convert.ToString(Theta3m2[i]) + "          ");

                }
            }
            Thread.Sleep(1500);

            for (int L = 0; L <= Ncount_m; L++)
            {
                sw2.WriteLine(Convert.ToString(Theta1m2[L]));
                sw3.WriteLine(Convert.ToString(Theta2m2[L]));
                sw4.WriteLine(Convert.ToString(Theta3m2[L]));
                swm1.WriteLine(Convert.ToString(L) + "    " + Convert.ToString(Theta1m2[L]));
                swm2.WriteLine(Convert.ToString(L) + "    " + Convert.ToString(Theta2m2[L]));
                swm3.WriteLine(Convert.ToString(L) + "    " + Convert.ToString(Theta3m2[L]));
            }
            Thread.Sleep(1500);

            sw1.Close();
            sw2.Close();
            sw3.Close();
            sw4.Close();
            swm1.Close();
            swm2.Close();
            swm3.Close();

            Console.WriteLine("Save Theta Finish");
        }
        #endregion

        //trackBar轉換到numeric
        #region TrackBar Change To Numeric
        private void trackBar_VAr_Scroll(object sender, EventArgs e)
        {
            numeric_VAr.Value = trackBar_VAr.Value;
        }

        private void trackBar_HH_Scroll(object sender, EventArgs e)
        {
            numericHH.Value = trackBar_HH.Value;
        }

        private void trackBar_SH_Scroll(object sender, EventArgs e)
        {
            numericSH.Value = trackBar_SH.Value;
        }

        private void trackBar_VH_Scroll(object sender, EventArgs e)
        {
            numericVH.Value = trackBar_VH.Value;
        }

        private void trackBar_HL_Scroll(object sender, EventArgs e)
        {
            numericHL.Value = trackBar_HL.Value;
        }

        private void trackBar_SL_Scroll(object sender, EventArgs e)
        {
            numericSL.Value = trackBar_SL.Value;
        }

        private void trackBar_VL_Scroll(object sender, EventArgs e)
        {
            numericVL.Value = trackBar_VL.Value;
        }
        #endregion
        
        //numeric 轉換到 trackbar
        #region Numeric Change To TrackBar
        private void numeric_VAr_ValueChanged(object sender, EventArgs e)
        {
            trackBar_VAr.Value = Convert.ToInt32(numeric_VAr.Value);
        }

        private void numericHH_ValueChanged(object sender, EventArgs e)
        {
            trackBar_HH.Value = Convert.ToInt32(numericHH.Value);
        }

        private void numericSH_ValueChanged(object sender, EventArgs e)
        {
            trackBar_SH.Value = Convert.ToInt32(numericSH.Value);
        }

        private void numericVH_ValueChanged(object sender, EventArgs e)
        {
            trackBar_VH.Value = Convert.ToInt32(numericVH.Value);
        }

        private void numericHL_ValueChanged(object sender, EventArgs e)
        {
            trackBar_HL.Value = Convert.ToInt32(numericHL.Value);
        }

        private void numericSL_ValueChanged(object sender, EventArgs e)
        {
            trackBar_SL.Value = Convert.ToInt32(numericSL.Value);
        }

        private void numericVL_ValueChanged(object sender, EventArgs e)
        {
            trackBar_VL.Value = Convert.ToInt32(numericVL.Value);
        }
        #endregion

        //執行搜尋完的路徑(尚未做曲線擬合的路徑)
        #region Path Motion
        private void button_Motion_Click(object sender, EventArgs e)
        {
            StreamReader sr1 = new StreamReader(@"C:\Store_Theta\Theta_1.txt");
            StreamReader sr2 = new StreamReader(@"C:\Store_Theta\Theta_2.txt");
            StreamReader sr3 = new StreamReader(@"C:\Store_Theta\Theta_3.txt");

            Ncount = Convert.ToInt32(textBox_PartNum.Text);
            int c = Ncount + 1;

            double[] m_theta1 = new double[c];
            double[] m_theta2 = new double[c];
            double[] m_theta3 = new double[c];

            string T1 = "0";
            string T2 = "0";
            string T3 = "0";

            //讀取txt檔案數值
            for (int i = 0; i <= Ncount; i++)
            {
                T1 = sr1.ReadLine();
                T2 = sr2.ReadLine();
                T3 = sr3.ReadLine();

                m_theta1[i] = Convert.ToDouble(T1);
                m_theta2[i] = Convert.ToDouble(T2);
                m_theta3[i] = Convert.ToDouble(T3);
            }

            sr1.Close();
            sr2.Close();
            sr3.Close();

            //復歸至路徑起點
            Three_Axis_Control(m_theta1[0], m_theta2[0], m_theta3[0]);
            Thread.Sleep(1000);
            //執行剩下的路徑
            for (int T = 1; T <= Ncount; T++)
            {
                Three_Axis_Control(m_theta1[T], m_theta2[T], m_theta3[T]);
            }
            //
            Console.WriteLine("Path Motion Finish ");
        }

        #endregion

        //執行搜尋完的路徑(尚未做曲線擬合的路徑) M2
        #region Path Motion M2
        private void button_m2motion_Click(object sender, EventArgs e)
        {
            //1. path list choose
            //2. Data store way and read data
            //3. Perform Data way delay ?  each motion point time
            //4. Go back orginal point way?

            Track_data();

            /*
            StreamReader sr1 = new StreamReader(@"C:\Store_Theta_2\Theta_1_m2.txt");
            StreamReader sr2 = new StreamReader(@"C:\Store_Theta_2\Theta_2_m2.txt");
            StreamReader sr3 = new StreamReader(@"C:\Store_Theta_2\Theta_3_m2.txt");

            //Ncount = Convert.ToInt32(textBox_PartNum.Text);

            int c = Convert.ToInt32(textBox_PartNum2.Text) * Convert.ToInt32(textBox_pointset.Text) + 1;
            Console.WriteLine(Convert.ToString(c));
            double[] m_theta1 = new double[c];
            double[] m_theta2 = new double[c];
            double[] m_theta3 = new double[c];

            string T1 = "0";
            string T2 = "0";
            string T3 = "0";

            //讀取txt檔案數值
            for (int i = 0; i < c; i++)
            {
                T1 = sr1.ReadLine();
                T2 = sr2.ReadLine();
                T3 = sr3.ReadLine();

                m_theta1[i] = Convert.ToDouble(T1);
                m_theta2[i] = Convert.ToDouble(T2);
                m_theta3[i] = Convert.ToDouble(T3);
                Console.WriteLine("i=" + Convert.ToInt32(i) + "theta1=" + Convert.ToString(m_theta1[i]) + "theta2=" + Convert.ToString(m_theta2[i]) + "theta3=" + Convert.ToString(m_theta3[i]));
            }

            sr1.Close();
            sr2.Close();
            sr3.Close();

            //復歸至路徑起點
            Three_Axis_Control(m_theta1[0], m_theta2[0], m_theta3[0]);
            Thread.Sleep(1000);
            //執行剩下的路徑
            for (int T = 1; T < c; T++)
            {
                Console.WriteLine("T=" + Convert.ToInt32(T) + "theta1=" + Convert.ToString(m_theta1[T]) + "theta2=" + Convert.ToString(m_theta2[T]) + "theta3=" + Convert.ToString(m_theta3[T]));
                Three_Axis_Control(m_theta1[T], m_theta2[T], m_theta3[T]);
                Thread.Sleep(100);
            }
            */
            Console.WriteLine("Path Motion Finish 2");
        }

        
        #endregion

        //曲線擬和路徑
        #region Curve Path
        private void button_Curve_Click(object sender, EventArgs e)
        {
            StreamReader srr1 = new StreamReader(@"C:\Store_Theta\Theta_1_curve.txt");
            StreamReader srr2 = new StreamReader(@"C:\Store_Theta\Theta_2_curve.txt");
            StreamReader srr3 = new StreamReader(@"C:\Store_Theta\Theta_3_curve.txt");

            Ncount = Convert.ToInt32(textBox_PartNum.Text);
            int h = Ncount * 10;
            int c = h + 1;

            double[] cu_theta1 = new double[c];
            double[] cu_theta2 = new double[c];
            double[] cu_theta3 = new double[c];

            string cuT1 = "";
            string cuT2 = "";
            string cuT3 = "";

            //讀取txt檔案數值
            for (int i = 0; i <= h; i++)
            {
                cuT1 = srr1.ReadLine();
                cuT2 = srr2.ReadLine();
                cuT3 = srr3.ReadLine();

                cu_theta1[i] = Convert.ToDouble(cuT1);
                cu_theta2[i] = Convert.ToDouble(cuT2);
                cu_theta3[i] = Convert.ToDouble(cuT3);
            }

            srr1.Close();
            srr2.Close();
            srr3.Close();

            //復歸至路徑起點
            Three_Axis_Control(cu_theta1[0], cu_theta2[0], cu_theta3[0]);
            Thread.Sleep(1000);

            //執行剩下的路徑
            for (int T = 1; T <= h; T++)
            {
                Three_Axis_Control(cu_theta1[T], cu_theta2[T], cu_theta3[T]);
            }

            Console.WriteLine("Path Curve Finish ");
        }
        #endregion

        //曲線擬和路徑
        #region Curve Path M2
        private void button_curve2_Click(object sender, EventArgs e)
        {
            StreamReader srr1 = new StreamReader(@"C:\Store_Theta_2\Theta_1_m2curve.txt");
            StreamReader srr2 = new StreamReader(@"C:\Store_Theta_2\Theta_2_m2curve.txt");
            StreamReader srr3 = new StreamReader(@"C:\Store_Theta_2\Theta_3_m2curve.txt");

            int P = Convert.ToInt32(textBox_pointset.Text);
            int N = Convert.ToInt32(textBox_PartNum2.Text);
            int h = P * N * 10;
            int c = h + 1;



            double[] cu_theta1 = new double[c];
            double[] cu_theta2 = new double[c];
            double[] cu_theta3 = new double[c];

            string cuT1 = "";
            string cuT2 = "";
            string cuT3 = "";

            //讀取txt檔案數值
            for (int i = 0; i <= h; i++)
            {
                cuT1 = srr1.ReadLine();
                cuT2 = srr2.ReadLine();
                cuT3 = srr3.ReadLine();

                cu_theta1[i] = Convert.ToDouble(cuT1);
                cu_theta2[i] = Convert.ToDouble(cuT2);
                cu_theta3[i] = Convert.ToDouble(cuT3);
            }

            srr1.Close();
            srr2.Close();
            srr3.Close();

            //復歸至路徑起點
            Three_Axis_Control(cu_theta1[0], cu_theta2[0], cu_theta3[0]);
            Thread.Sleep(1300);

            //執行剩下的路徑
            for (int T = 1; T <= h; T++)
            {
                Three_Axis_Control(cu_theta1[T], cu_theta2[T], cu_theta3[T]);
            }
            Thread.Sleep(200);
            Three_Axis_Control_withoutdelay(0, 0, 0);

            Console.WriteLine("Path Curve Finish ");
        }
        #endregion

        //印出搜尋完成的資訊
        #region Information Of Search Result
        public void Information_of_search_result(int N, int thi, int[] error, int[] count, double time)
        {
            string caption = "Information of Simplex Method Result";
            string strMessage = "";
            thi = thi - 1;
            strMessage = strMessage + "Segmentation: " + Convert.ToString(N) + "\n";
            strMessage = strMessage + "Trajectory Poit:";
            for (int i = 1; i <= thi; i++)
            {
                strMessage = strMessage + Convert.ToString(i) + " ";
            }
            strMessage = strMessage + "\n";
            strMessage = strMessage + "Search Times:   ";
            for (int k = 1; k <= thi; k++)
            {
                strMessage = strMessage + " " + Convert.ToString(count[k]) + " ";
            }
            strMessage = strMessage + "\n";
            strMessage = strMessage + "Error Index:      ";
            for (int j = 1; j <= thi; j++)
            {
                strMessage = strMessage + " " + Convert.ToString(error[j]) + " ";
            }
            strMessage = strMessage + "\n";
            //strMessage = strMessage + "Cost Time: " + time.ToString();

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(strMessage, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                this.Close();
            }
        }
        #endregion

        //紀錄規劃的路徑
        #region M2 Write Point Data
        public void Write_Point_Data()
        {
            int N = Convert.ToInt32(textBox_pointset.Text);
            StreamWriter sw1 = new StreamWriter(@"C:\Store_Path_Point_2\I_POINT_DATA.txt");
            StreamWriter sw2 = new StreamWriter(@"C:\Store_Path_Point_2\Point_Xu.txt");
            StreamWriter sw3 = new StreamWriter(@"C:\Store_Path_Point_2\Point_Yu.txt");
            StreamWriter sw4 = new StreamWriter(@"C:\Store_Path_Point_2\Point_Xv.txt");
            StreamWriter sw5 = new StreamWriter(@"C:\Store_Path_Point_2\Point_Yv.txt");

            for (int j = 0; j <= N; j++)
            {
                sw1.WriteLine(Convert.ToString(j) + " " + Convert.ToString(RecordPoint[j][0]) + " " + Convert.ToString(RecordPoint[j][1])
                     + " " + Convert.ToString(RecordPoint[j][2]) + " " + Convert.ToString(RecordPoint[j][3]));
                sw2.WriteLine(Convert.ToString(RecordPoint[j][0]));
                sw3.WriteLine(Convert.ToString(RecordPoint[j][1]));
                sw4.WriteLine(Convert.ToString(RecordPoint[j][2]));
                sw5.WriteLine(Convert.ToString(RecordPoint[j][3]));
            }

            sw1.Close();
            sw2.Close();
            sw3.Close();
            sw4.Close();
            sw5.Close();
        }
        #endregion

        //單體法2規畫路徑點座標儲存
        #region Button Record M2 Point
        private void button_recordpoint_Click(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(textBox_pointset.Text);
            limit += 1;
            int clickTimes;//按下次數
            object tag = this.button_recordpoint.Tag;

            if (tag == null)
            {
                clickTimes = 0;
            }
            else
            {
                clickTimes = Convert.ToInt32(tag);
            }

            if (clickTimes == 0)
            {
                if (System.IO.File.Exists(@"C:\Store_Path_Point_2\I_POINT_DATA.txt"))
                {
                    System.IO.File.Delete(@"C:\Store_Path_Point_2\I_POINT_DATA.txt");
                    System.IO.File.Delete(@"C:\Store_Path_Point_2\Point_Xu.txt");
                    System.IO.File.Delete(@"C:\Store_Path_Point_2\Point_Yu.txt");
                    System.IO.File.Delete(@"C:\Store_Path_Point_2\Point_Xv.txt");
                    System.IO.File.Delete(@"C:\Store_Path_Point_2\Point_Yv.txt");
                }
            }

            if (!System.IO.File.Exists(@"C:\Store_Path_Point_2\I_POINT_DATA.txt"))
            {
                string folderName = @"C:\Store_Path_Point_2";
                string fileName1 = "I_POINT_DATA.txt";
                string fileName2 = "Point_Xu.txt";
                string fileName3 = "Point_Yu.txt";
                string fileName4 = "Point_Xv.txt";
                string fileName5 = "Point_Yv.txt";
                string pathString1 = folderName;
                string pathString2 = folderName;
                string pathString3 = folderName;
                string pathString4 = folderName;
                string pathString5 = folderName;
                pathString1 = System.IO.Path.Combine(pathString1, fileName1);
                pathString2 = System.IO.Path.Combine(pathString2, fileName2);
                pathString3 = System.IO.Path.Combine(pathString3, fileName3);
                pathString4 = System.IO.Path.Combine(pathString4, fileName4);
                pathString5 = System.IO.Path.Combine(pathString5, fileName5);

                System.IO.FileStream fs1 = System.IO.File.Create(pathString1);
                System.IO.FileStream fs2 = System.IO.File.Create(pathString2);
                System.IO.FileStream fs3 = System.IO.File.Create(pathString3);
                System.IO.FileStream fs4 = System.IO.File.Create(pathString4);
                System.IO.FileStream fs5 = System.IO.File.Create(pathString5);

                fs1.Close();
                fs2.Close();
                fs3.Close();
                fs4.Close();
                fs5.Close();
            }

            this.button_recordpoint.Tag = ++clickTimes;

            if (clickTimes <= limit)
            {
                if ((clickTimes % 2) == 1)//奇數次
                {
                    //讀取座標資訊
                    //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v
                    //ReadData();
                    //ReadData2();

                    //顯示記錄到第幾點
                    textBox_pointnum.Text = Convert.ToString(clickTimes);

                    //紀錄對應的規劃目標點
                    RecordPoint[recordpoint_num][0] = ImageCoordinate.LC_X;
                    RecordPoint[recordpoint_num][1] = ImageCoordinate.LC_Y;
                    RecordPoint[recordpoint_num][2] = ImageCoordinate.RC_X;
                    RecordPoint[recordpoint_num][3] = ImageCoordinate.RC_Y;

                    //顯示紀錄的座標
                    textBox_m2Xu.Text = Convert.ToString(ImageCoordinate.LC_X);
                    textBox_m2Yu.Text = Convert.ToString(ImageCoordinate.LC_Y);
                    textBox_m2Xv.Text = Convert.ToString(ImageCoordinate.RC_X);
                    textBox_m2Yv.Text = Convert.ToString(ImageCoordinate.RC_Y);

                    recordpoint_num += 1;
                }
                else if (clickTimes == limit)
                {
                    //顯示記錄到第幾點
                    textBox_pointnum.Text = Convert.ToString(clickTimes);

                    //紀錄對應的規劃目標點
                    RecordPoint[recordpoint_num][0] = RecordPoint[0][0];
                    RecordPoint[recordpoint_num][1] = RecordPoint[1][0];
                    RecordPoint[recordpoint_num][2] = RecordPoint[2][0];
                    RecordPoint[recordpoint_num][3] = RecordPoint[3][0];

                    //顯示紀錄的座標
                    textBox_m2Xu.Text = Convert.ToString(RecordPoint[0][0]);
                    textBox_m2Yu.Text = Convert.ToString(RecordPoint[0][1]);
                    textBox_m2Xv.Text = Convert.ToString(RecordPoint[0][2]);
                    textBox_m2Yv.Text = Convert.ToString(RecordPoint[0][3]);
                }
                else                     //偶數次
                {
                    //讀取座標資訊
                    //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v
                    //ReadData();
                    //ReadData2();

                    //顯示記錄到第幾點
                    textBox_pointnum.Text = Convert.ToString(clickTimes);

                    //紀錄對應的規劃目標點
                    RecordPoint[recordpoint_num][0] = ImageCoordinate.LC_X;
                    RecordPoint[recordpoint_num][1] = ImageCoordinate.LC_Y;
                    RecordPoint[recordpoint_num][2] = ImageCoordinate.RC_X;
                    RecordPoint[recordpoint_num][3] = ImageCoordinate.RC_Y;

                    //顯示紀錄的座標
                    textBox_m2Xu.Text = Convert.ToString(ImageCoordinate.LC_X);
                    textBox_m2Yu.Text = Convert.ToString(ImageCoordinate.LC_Y);
                    textBox_m2Xv.Text = Convert.ToString(ImageCoordinate.RC_X);
                    textBox_m2Yv.Text = Convert.ToString(ImageCoordinate.RC_Y);

                    recordpoint_num += 1;
                }
            }
            else
            {
                Write_Point_Data();
                string caption = "Information of Over Point Store Space";
                string strMessage = "";
                strMessage = strMessage + "Yes: Re-register Coordinates." + "\n";
                strMessage = strMessage + "No:  Finish register function." + "\n";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(strMessage, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //清除顯示記錄到第幾點
                    textBox_pointnum.Text = Convert.ToString(0);
                    //清除紀錄按鈕按下的次數
                    this.button_recordpoint.Tag = 0;
                    clickTimes = 0;
                    //清除顯示紀錄的座標
                    textBox_m2Xu.Text = "";
                    textBox_m2Yu.Text = "";
                    textBox_m2Xv.Text = "";
                    textBox_m2Yv.Text = "";
                    //清除紀錄點座標的陣列
                    for (int i = 0; i < limit; i++)
                    {
                        RecordPoint[i][0] = 0;
                        RecordPoint[i][1] = 0;
                        RecordPoint[i][2] = 0;
                        RecordPoint[i][3] = 0;
                    }
                    //清除標記陣列點數的數值
                    recordpoint_num = 0;
                }
                else
                {

                }
            }
        }
        #endregion

        private void button_searchpathmt_Click(object sender, EventArgs e)
        {
            simplex_method_two(null,null);
        }

        //Topic1 取得雙攝影機畫面上的初始座標位置和當前三顆馬達位置
        //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 
        //Topic2 取得雙攝影機畫面上的終點座標位置和當前三顆馬達位置
        //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 
        #region Initial Pos And Finish Pos Button
        private void button_InitialAndFinish_Click(object sender, EventArgs e)
        {
            
            int clickTimes;//按下次數
            object tag = this.button_InitialAndFinish.Tag;
            if (tag == null)
            {
                clickTimes = 0;
            }
            else
            {
                clickTimes = Convert.ToInt32(tag);
            }
            this.button_InitialAndFinish.Tag = ++clickTimes;

            if ((clickTimes % 2) == 1)
            {
                this.button_InitialAndFinish.Text = "Initial Pos";
                
                //ReadData();
                //ReadData2();
                
                Global.IXu = ImageCoordinate.LC_X;
                Global.IYu = ImageCoordinate.LC_Y;
                Global.IXv = ImageCoordinate.RC_X;
                Global.IYv = ImageCoordinate.RC_Y;

                //此區段要加入當前馬達回授值用於Topic 4
                Global.Itheta1 = Convert.ToInt32(TB_Motor1_D.Text);//R
                Global.Itheta2 = Convert.ToInt32(TB_Motor2_D.Text);//L
                Global.Itheta3 = Convert.ToInt32(TB_Motor3_D.Text);//M

                if (Global.IXu == 0 && Global.IYu == 0 && Global.IXv == 0 && Global.IYv == 0)
                {
                    textBox_IXu.Text = "";
                    textBox_IYu.Text = "";
                    textBox_IXv.Text = "";
                    textBox_IYv.Text = "";
                }
                else
                {
                    textBox_IXu.Text = Global.IXu.ToString();
                    textBox_IYu.Text = Global.IYu.ToString();
                    textBox_IXv.Text = Global.IXv.ToString();
                    textBox_IYv.Text = Global.IYv.ToString();
                }
            }
            else
            {
                this.button_InitialAndFinish.Text = "Finish Pos";
                //ReadData();
                //ReadData2();
                Global.FXu = ImageCoordinate.LC_X;
                Global.FYu = ImageCoordinate.LC_Y;
                Global.FXv = ImageCoordinate.RC_X;
                Global.FYv = ImageCoordinate.RC_Y;

                Global.Ftheta1 = Convert.ToInt32(TB_Motor1_D.Text);//R
                Global.Ftheta2 = Convert.ToInt32(TB_Motor2_D.Text);//L
                Global.Ftheta3 = Convert.ToInt32(TB_Motor3_D.Text);//M

                if (Global.FXu == 0 && Global.FYu == 0 && Global.FXv == 0 && Global.FYv == 0)
                {
                    textBox_FXu.Text = "";
                    textBox_FYu.Text = "";
                    textBox_FXv.Text = "";
                    textBox_FYv.Text = "";
                }
                else
                {
                    textBox_FXu.Text = Global.FXu.ToString();
                    textBox_FYu.Text = Global.FYu.ToString();
                    textBox_FXv.Text = Global.FXv.ToString();
                    textBox_FYv.Text = Global.FYv.ToString();
                }
            }
        }

        #endregion

        //清除儲存的初始座標和終點座標
        #region Clear Pos Data Button
        private void button_ClearPos_Click(object sender, EventArgs e)
        {
            Global.IXu = 0;
            Global.IYu = 0;
            Global.IXv = 0;
            Global.IYv = 0;
            Global.FXu = 0;
            Global.FYu = 0;
            Global.FXv = 0;
            Global.FYv = 0;
            textBox_FXu.Text = "";
            textBox_FYu.Text = "";
            textBox_FXv.Text = "";
            textBox_FYv.Text = "";
            textBox_IXu.Text = "";
            textBox_IYu.Text = "";
            textBox_IXv.Text = "";
            textBox_IYv.Text = "";
        }
        #endregion

        //單體法計算過程主體
        #region Simplex Method
        public void simplex_method_one()
        {
            int N = Convert.ToInt32(textBox_PartNum.Text); //設置路徑共分為幾個段落來做搜尋

            //int N = check_unit();
            Console.WriteLine("!!!!!!!!!!!!!!");
            Console.WriteLine("N="+Convert.ToString(N));
            Console.WriteLine("!!!!!!!!!!!!!!");
            Thread.Sleep(3000);

            int C = 0;
            C = N + 1;
            int K = 0;
            K = N;
            int error_tolerate = 10;
            int number_of_times = 80;

            //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 
            double[] XXu = new double[C];            //儲存完整路徑的right webcam上x座標
            double[] YYu = new double[C];            //儲存完整路徑的right webcam上y座標
            double[] XXv = new double[C];            //儲存完整路徑的left  webcam上x座標
            double[] YYv = new double[C];            //儲存完整路徑的left  webcam上y座標
            double[] theta1 = new double[C];         //儲存完整路徑的theta1的值 從初始點到終點皆紀錄
            double[] theta2 = new double[C];         //儲存完整路徑的theta2的值 從初始點到終點皆紀錄
            double[] theta3 = new double[C];         //儲存完整路徑的theta3的值 從初始點到終點皆紀錄
            
            int[] store_j = new int[K];              //儲存完整路徑的誤差值
            int[] store_count = new int[K];          //儲存完整路徑各點的搜尋次數


            Points_On_Path(N, XXu, YYu, XXv, YYv); //計算路徑上的座標點，此處陣列帶入函數可以不需回傳 如同指標的用法
                                                   //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v

            theta1[0] = Global.Itheta1;//  R
            theta2[0] = Global.Itheta2;//  L
            theta3[0] = Global.Itheta3;//  M

            theta1[N] = Global.Ftheta1;//  R
            theta2[N] = Global.Ftheta2;//  L
            theta3[N] = Global.Ftheta3;//  M
             
            
            //Topic 4
            //透過Topic 1的取值來做歸位的動作，控制機械手臂回到初始位置
            Move_To_Initial_Pos(theta1[0], theta2[0], theta3[0]);
            Console.WriteLine("Move_To_Initial_Pos Finish");
            //Topic 5
            //透過Topic 3已經將P1的座標找出，並且把 P0 點到 PN 點的單位距離求出
            //並且透過Matlab驗證過線段的直線方程式，將P0點到PN點的座標帶入皆符合在直線方程式上
            //Step 01 設置參數值

            int thi = 1;     //決定第幾個點 由於起點與終點已知 所以從第一點開始做計算
            const int n = 6; //由於此參數不會變動所以可以寫為const
            
            //const double alpha = 1.0, gamma = 1.5, beta = 0.2;//由於這些參數不會變動所以可以寫為const
            Console.WriteLine("Initial Const Setting Finish");
            //Topic 6 
            //此步驟為循環步驟的起頭，所以新的初始點都會在此段程式開始計算下一點
            while (thi != N)//會在找到下一點theta時做thi ++，如果已經找到終點的前一點的theta則結束while
            {
                int Count = 0;//計算搜尋次數
                int[] j = new int[7];  //紀錄誤差指標函數 4個誤差值
                int[] je = new int[1];
                int[] jr = new int[1];
                int[] jc = new int[1];
                int[] jcc = new int[1];//四種誤差函數
                double[] theta_r = new double[3];
                double[] theta_e = new double[3];
                double[] theta_c = new double[3];
                double[] theta_cc = new double[3];

                double d_theta1 = (theta1[N] - theta1[0]) / (N*1);//R
                double d_theta2 = (theta2[N] - theta2[0]) / (N*1);//L
                double d_theta3 = (theta3[N] - theta3[0]) / (N*1);//M
                //theta3[N] - theta3[thi-1]/N 

                Console.WriteLine("d_theta1=" + d_theta1);//
                Console.WriteLine("d_theta2=" + d_theta2);//
                Console.WriteLine("d_theta3=" + d_theta3);//

                //隨機移動到附近4個不同位置，我們分別以下列4點來表示
                double[] Q0 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1] + d_theta2, theta3[thi - 1] + d_theta3 };
                double[] Q1 = new double[3] { theta1[thi - 1], theta2[thi - 1] + d_theta2, theta3[thi - 1] + d_theta3 };
                double[] Q2 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1], theta3[thi - 1] + d_theta3 };
                double[] Q3 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1] + d_theta2, theta3[thi - 1] };
                double[] Q4 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1] , theta3[thi - 1] };
                double[] Q5 = new double[3] { theta1[thi - 1] , theta2[thi - 1] + d_theta2, theta3[thi - 1] };
                double[] Q6 = new double[3] { theta1[thi - 1], theta2[thi - 1] , theta3[thi - 1] + d_theta3 };

                //Example
                /* https://stackoverflow.com/questions/36668096/an-array-initializer-of-the-length-of-2-is-expected */

                double[][] bs_theta = new double[7][] { Q0, Q1, Q2, Q3, Q4, Q5, Q6 };//Initial Theta
                double[][] as_theta = new double[7][];                  //After Insertion Sort
                
                //
                Console.WriteLine("Q0=(" + bs_theta[0][0] + "，" + bs_theta[0][1] + "，" + bs_theta[0][2] + ")");
                Console.WriteLine("Q1=(" + bs_theta[1][0] + "，" + bs_theta[1][1] + "，" + bs_theta[1][2] + ")");
                Console.WriteLine("Q2=(" + bs_theta[2][0] + "，" + bs_theta[2][1] + "，" + bs_theta[2][2] + ")");
                Console.WriteLine("Q3=(" + bs_theta[3][0] + "，" + bs_theta[3][1] + "，" + bs_theta[3][2] + ")");
                Console.WriteLine("Q4=(" + bs_theta[4][0] + "，" + bs_theta[4][1] + "，" + bs_theta[4][2] + ")");
                Console.WriteLine("Q5=(" + bs_theta[5][0] + "，" + bs_theta[5][1] + "，" + bs_theta[5][2] + ")");
                Console.WriteLine("Q6=(" + bs_theta[6][0] + "，" + bs_theta[6][1] + "，" + bs_theta[6][2] + ")");

                while (true)
                {
                    //搜尋次數等於零時要先建立初始單體，搜尋一次後不再建立
                    
                    double[] Sum = new double[3];

                    if (Count == 0)
                    {
                        Console.WriteLine("Thi=" + thi.ToString() + "@@@@@@@@@@@@@@@");
                        Console.WriteLine("Count="+Count.ToString());
                        //四點對應誤差函數計算如下:
                        FError_Function_Calculate(bs_theta, j, n, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 當前座標點
                        //Step 03  將 theta0~thetaN 重新排序，排序的依據是個別座標點的誤差函數值做比較
                        Insertion_Sort(bs_theta, j);//引數順序 -> theta , j 回傳排序後的theta 給as_theta
                        as_theta = bs_theta;
                    }
                    else 
                    {
                        Console.WriteLine("Count=" + Count.ToString());
                        Insertion_Sort(as_theta,j);
                    }
                    
                    for (int g=0;g<=n;g++) 
                    {
                        Console.WriteLine("j["+g.ToString()+"]="+j[g]);
                        for(int z=0;z<n;z++) 
                        {
                            //Console.WriteLine("as_theta"+"["+g.ToString()+"]"+"["+z.ToString()+"]="+as_theta[g][z].ToString());
                        }
                    }

                    //Advance Calculate Theta Bar
                    Theta_Bar(Sum, as_theta, n);//陣列元素相加後平均但是只取誤差函數小的前三點座標角度做相加
                    Console.WriteLine("Theta Bar Finish");
                    //step 4-1 
                    //Situation_Theta_Calculate(theta_r, Sum, alpha, as_theta, 1, n);
                    //Console.WriteLine("step 4-1");
                    //step 4-2
                    //Error_Function_Calculate(theta_r, jr, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                    Console.WriteLine("step 4");
                    Reflection_move(jr,theta_r,Sum,as_theta,XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                    Console.WriteLine("jr=" + jr[0].ToString());
                    //Console.WriteLine("step 4-2");
                    //Step 05
                    double[] theta_new = new double[] { };
                    Console.WriteLine("step 5");
                    //Step 06
                    //Strp 06 Y
                    if (jr[0] < j[0])
                    {
                        Console.WriteLine("step 6 Y");
                        //Step 07-1 
                        //Situation_Theta_Calculate(theta_e, Sum, gamma, as_theta, 1, n);
                        //Console.WriteLine("step 7-1");
                        //Step 07-2
                        //Error_Function_Calculate(theta_e, je, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        //Console.WriteLine("step 7-2");
                        Console.WriteLine("step 7");
                        Expansion_move(je,theta_e,Sum,as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        Console.WriteLine("je=" + je[0].ToString());
                        
                        //Step 08
                        if (je[0] < jr[0])//Step 08 Y
                        {
                            Console.WriteLine("step 8 Y");
                            theta_new = theta_e;
                            //Step 16-1
                            ThetaNewToThetaN(n, as_theta, theta_new);
                            Console.WriteLine("step 16-1");
                            //step 16-2
                            j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);

                            Console.WriteLine("jn=" + j[n].ToString());
                            Console.WriteLine("step 16-2");
                            //Step 17
                            if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                            {
                                //j[n] >= j[0] 當確定最新的搜尋值 error index 大於等於 j[0] 時
                                //才停止搜尋，確保最新值不是更好的搜尋角度

                                //紀錄找到新的P點位置當前theta角度的值
                                //直接從j[0] 的 theta 提取
                                theta1[thi] = as_theta[0][0];
                                theta2[thi] = as_theta[0][1];
                                theta3[thi] = as_theta[0][2];
                                //紀錄error
                                store_j[thi] = j[0]; 
                                //紀錄count times
                                store_count[thi] = Count;
                                Console.WriteLine("step 17 Finish");
                                break;
                            }
                            else
                            {
                                Count++;  //累計遞迴次數
                                
                                Console.WriteLine("Before Sort");
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                Console.WriteLine("j[0]=" + j[0].ToString());
                                Console.WriteLine("j[1]=" + j[1].ToString());
                                Console.WriteLine("j[2]=" + j[2].ToString());
                                Console.WriteLine("j[3]=" + j[3].ToString());
                                Console.WriteLine("j[4]=" + j[4].ToString());
                                Console.WriteLine("j[5]=" + j[5].ToString());
                                Console.WriteLine("j[6]=" + j[6].ToString());
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");


                                Console.WriteLine("step 17 Continue");
                                continue;
                            }
                        }
                        // Step 08 N
                        else
                        {
                            Console.WriteLine("step 8 N");
                            //Step 14  theta_new != null
                            theta_new = theta_r;
                            //Step 16-1
                            ThetaNewToThetaN(n, as_theta, theta_new);
                            Console.WriteLine("step 16-1");
                            //step 16-2
                            j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("j[n]=" + j[n].ToString());
                            Console.WriteLine("step 16-2");
                            //Step 17
                            if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                            {
                                //紀錄找到新的P點位置當前theta角度的值
                                //直接從j[0] 的 theta 提取
                                theta1[thi] = as_theta[0][0];
                                theta2[thi] = as_theta[0][1];
                                theta3[thi] = as_theta[0][2];
                                //紀錄error
                                store_j[thi] = j[0];
                                //紀錄count times
                                store_count[thi] = Count;

                                Console.WriteLine("step 17 Finish");
                                break;
                            }
                            else
                            {
                                Count++;  //累計遞迴次數

                                Console.WriteLine("Before Sort");
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                Console.WriteLine("j[0]=" + j[0].ToString());
                                Console.WriteLine("j[1]=" + j[1].ToString());
                                Console.WriteLine("j[2]=" + j[2].ToString());
                                Console.WriteLine("j[3]=" + j[3].ToString());
                                Console.WriteLine("j[4]=" + j[4].ToString());
                                Console.WriteLine("j[5]=" + j[5].ToString());
                                Console.WriteLine("j[6]=" + j[6].ToString());
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                Console.WriteLine("step 17 Continue");
                                continue;
                            }
                        }
                    }
                    //Step 06 N
                    else
                    {
                        Console.WriteLine("step 6 N");
                        //Step 09 Y
                        if (jr[0] < j[n])
                        {
                            Console.WriteLine("step 9 Y");
                            //Step 10-1 
                            //Situation_Theta_Calculate(theta_c, Sum, beta, as_theta, 1, n);
                            //Console.WriteLine("step 10-1");
                            //Step 10-2
                            //Error_Function_Calculate(theta_c, jc, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            //Console.WriteLine("step 10-2");
                            Console.WriteLine("step 10");
                            OuterShrink_move(jc,theta_c,Sum,as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("jc=" + jc[0].ToString());
                            
                            //Step 11 Y
                            if (jc[0] < jr[0])
                            {
                                Console.WriteLine("step 11 Y");
                                theta_new = theta_c;
                                //Step 16-1
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                Console.WriteLine("step 16-1");
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("jn=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    store_j[thi] = j[0];
                                    //紀錄count times
                                    store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                            //Step 11 N
                            else
                            {
                                Console.WriteLine("step 11 N");
                                //Step 14  theta_new != null
                                theta_new = theta_r;
                                //Step 16-1
                                Console.WriteLine("step 16-1");
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("j[n]=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    store_j[thi] = j[0];
                                    //紀錄count times
                                    store_count[thi] = Count;


                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                        }
                        //Step 09 N
                        else
                        {
                            Console.WriteLine("step 9 N");
                            //Step 12-1 
                            //Situation_Theta_Calculate(theta_cc, Sum, beta, as_theta, 0, n);
                            //Console.WriteLine("step 12-1");
                            //Step 12-2
                            //Error_Function_Calculate(theta_cc, jcc, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            //Console.WriteLine("step 12-2");
                            Console.WriteLine("step 12");
                            InsideShrink_move(jcc,theta_cc,Sum,as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("jcc=" + jcc[0].ToString());
                            
                            //Step 13 Y
                            if (jcc[0] < j[n])
                            {
                                Console.WriteLine("step 13 Y");
                                theta_new = theta_cc;
                                //Step 16-1
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                Console.WriteLine("step 16-1");
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("j[n]=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];

                                    //紀錄error
                                    store_j[thi] = j[0];
                                    //紀錄count times
                                    store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }

                            }
                            //Step 13 N
                            else
                            {
                                Console.WriteLine("step 13 N");
                                //Step 15
                                //多維收縮
                                Multidimensional_Contraction(n, as_theta, j, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("step 15");
                                //這邊是否需要加入 sort ?
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    store_j[thi] = j[0];
                                    //紀錄count times
                                    store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數
                                    
                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                        }
                    }
                }
                thi = thi + 1;
            }


            Theta1 = theta1;//路徑上每一點的theta1
            Theta2 = theta2;//路徑上每一點的theta2
            Theta3 = theta3;//路徑上每一點的theta3
            Ncount = N;

            Console.WriteLine("Simplex method Finish");

            Information_of_search_result(N,thi,store_j,store_count,0);
        }
        #endregion

        //單體法2計算過程主體
        #region Simplex Method 2
        public void simplex_method_two(object sender, EventArgs e)
        {
            int pointn = Convert.ToInt32(textBox_pointset.Text);
            int partn  = Convert.ToInt32(textBox_PartNum2.Text);
            
            Console.WriteLine("!!!!!!!!!!!!!!");
            Console.WriteLine("Point set =" + Convert.ToString(pointn));
            Console.WriteLine("Each Point dealing num=" + Convert.ToString(partn));
            Console.WriteLine("!!!!!!!!!!!!!!");
            Thread.Sleep(2500);
           
            Search_Standard = 2;
            
            double[] Itheta = new double[3];
            //初始角度值
            Itheta[0] = Convert.ToDouble(TB_Motor1_D.Text);
            Itheta[1] = Convert.ToDouble(TB_Motor2_D.Text);
            Itheta[2] = Convert.ToDouble(TB_Motor3_D.Text);

            StreamReader sw2 = new StreamReader(@"C:\Store_Path_Point_2\Point_Xu.txt", false);
            StreamReader sw3 = new StreamReader(@"C:\Store_Path_Point_2\Point_Yu.txt", false);
            StreamReader sw4 = new StreamReader(@"C:\Store_Path_Point_2\Point_Xv.txt", false);
            StreamReader sw5 = new StreamReader(@"C:\Store_Path_Point_2\Point_Yv.txt", false);
          

            if (System.IO.File.Exists(@"C:\Store_Path_Point_2\I_POINT_DATA.txt"))
            {
                for(int h =0; h <= pointn; h++)
                {
                    RecordPoint[h][0] = Convert.ToInt32(sw2.ReadLine());
                    RecordPoint[h][1] = Convert.ToInt32(sw3.ReadLine());
                    RecordPoint[h][2] = Convert.ToInt32(sw4.ReadLine());
                    RecordPoint[h][3] = Convert.ToInt32(sw5.ReadLine());
                }
                sw2.Close();
                sw3.Close();
                sw4.Close();
                sw5.Close();
            }

            int error_tolerate = 10;
            int number_of_times = 80;
            int C = (pointn * partn)+1;
            int k = C - 1;

            //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 
            double[] XXu = new double[C];            //儲存完整路徑的right webcam上x座標
            double[] YYu = new double[C];            //儲存完整路徑的right webcam上y座標
            double[] XXv = new double[C];            //儲存完整路徑的left  webcam上x座標
            double[] YYv = new double[C];            //儲存完整路徑的left  webcam上y座標
            double[] theta1 = new double[C];         //儲存完整路徑的theta1的值 從初始點到終點皆紀錄
            double[] theta2 = new double[C];         //儲存完整路徑的theta2的值 從初始點到終點皆紀錄
            double[] theta3 = new double[C];         //儲存完整路徑的theta3的值 從初始點到終點皆紀錄

            //int[] store_j = new int[C];              //儲存完整路徑的誤差值
            //int[] store_count = new int[C];          //儲存完整路徑各點的搜尋次數

            //k=120
            Points_On_Path_two(k, XXu, YYu, XXv, YYv); //計算路徑上的座標點，此處陣列帶入函數可以不需回傳 如同指標的用法
                                                       //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v

            theta1[0] = Itheta[0]; theta1[k] = Itheta[0];
            theta2[0] = Itheta[1]; theta2[k] = Itheta[1];
            theta3[0] = Itheta[2]; theta3[k] = Itheta[2];


            //Topic 4
            //透過Topic 1的取值來做歸位的動作，控制機械手臂回到初始位置
            Move_To_Initial_Pos(theta1[0], theta2[0], theta3[0]);
            Console.WriteLine("Move_To_Initial_Pos Finish");
            //Topic 5
            //透過Topic 3已經將P1的座標找出，並且把 P0 點到 PN 點的單位距離求出
            //並且透過Matlab驗證過線段的直線方程式，將P0點到PN點的座標帶入皆符合在直線方程式上
            //Step 01 設置參數值

            int thi = 1;     //決定第幾個點 由於起點與終點已知 所以從第一點開始做計算
            const int n = 6; //由於此參數不會變動所以可以寫為const

            //const double alpha = 1.0, gamma = 1.5, beta = 0.2;//由於這些參數不會變動所以可以寫為const
            Console.WriteLine("Initial Const Setting Finish");
            //Topic 6 
            //此步驟為循環步驟的起頭，所以新的初始點都會在此段程式開始計算下一點
            while (thi != C)//會在找到下一點theta時做thi ++，如果已經找到終點的前一點的theta則結束while
            {
                int Count = 0;//計算搜尋次數
                int[] j = new int[7];  //紀錄誤差指標函數 4個誤差值
                int[] je = new int[1];
                int[] jr = new int[1];
                int[] jc = new int[1];
                int[] jcc = new int[1];//四種誤差函數
                double[] theta_r = new double[3];
                double[] theta_e = new double[3];
                double[] theta_c = new double[3];
                double[] theta_cc = new double[3];

                double d_theta1 = 0.3;//
                double d_theta2 = 0.3;//
                double d_theta3 = 0.3;//
                //theta3[N] - theta3[thi-1]/N

                Console.WriteLine("d_theta1=" + d_theta1);//
                Console.WriteLine("d_theta2=" + d_theta2);//
                Console.WriteLine("d_theta3=" + d_theta3);//

                //隨機移動到附近4個不同位置，我們分別以下列4點來表示
                double[] Q0 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1] + d_theta2, theta3[thi - 1] + d_theta3 };
                double[] Q1 = new double[3] { theta1[thi - 1], theta2[thi - 1] + d_theta2, theta3[thi - 1] + d_theta3 };
                double[] Q2 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1], theta3[thi - 1] + d_theta3 };
                double[] Q3 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1] + d_theta2, theta3[thi - 1] };
                double[] Q4 = new double[3] { theta1[thi - 1] + d_theta1, theta2[thi - 1]+ d_theta2, theta3[thi - 1]- d_theta3 };
                double[] Q5 = new double[3] { theta1[thi - 1]- d_theta1, theta2[thi - 1] + d_theta2, theta3[thi - 1]+ d_theta3 };
                double[] Q6 = new double[3] { theta1[thi - 1]+ d_theta1, theta2[thi - 1] - d_theta2, theta3[thi - 1] + d_theta3 };

                //Example
                /* https://stackoverflow.com/questions/36668096/an-array-initializer-of-the-length-of-2-is-expected */

                double[][] bs_theta = new double[7][] { Q0, Q1, Q2, Q3, Q4, Q5, Q6 };//Initial Theta
                double[][] as_theta = new double[7][];                  //After Insertion Sort

                //
                Console.WriteLine("Q0=(" + bs_theta[0][0] + "，" + bs_theta[0][1] + "，" + bs_theta[0][2] + ")");
                Console.WriteLine("Q1=(" + bs_theta[1][0] + "，" + bs_theta[1][1] + "，" + bs_theta[1][2] + ")");
                Console.WriteLine("Q2=(" + bs_theta[2][0] + "，" + bs_theta[2][1] + "，" + bs_theta[2][2] + ")");
                Console.WriteLine("Q3=(" + bs_theta[3][0] + "，" + bs_theta[3][1] + "，" + bs_theta[3][2] + ")");
                Console.WriteLine("Q4=(" + bs_theta[4][0] + "，" + bs_theta[4][1] + "，" + bs_theta[4][2] + ")");
                Console.WriteLine("Q5=(" + bs_theta[5][0] + "，" + bs_theta[5][1] + "，" + bs_theta[5][2] + ")");
                Console.WriteLine("Q6=(" + bs_theta[6][0] + "，" + bs_theta[6][1] + "，" + bs_theta[6][2] + ")");

                while (true)
                {
                    //搜尋次數等於零時要先建立初始單體，搜尋一次後不再建立

                    double[] Sum = new double[3];

                    if (Count == 0)
                    {
                        Console.WriteLine("Thi=" + thi.ToString() + "@@@@@@@@@@@@@@@");
                        Console.WriteLine("Count=" + Count.ToString());
                        //四點對應誤差函數計算如下:
                        FError_Function_Calculate(bs_theta, j, n, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        //(Global.rx Global.ry)=u  (Global.lx Global.ly)=v 當前座標點
                        //Step 03  將 theta0~thetaN 重新排序，排序的依據是個別座標點的誤差函數值做比較
                        Insertion_Sort(bs_theta, j);//引數順序 -> theta , j 回傳排序後的theta 給as_theta
                        as_theta = bs_theta;
                    }
                    else
                    {
                        Console.WriteLine("Count=" + Count.ToString());
                        Insertion_Sort(as_theta, j);
                    }

                    for (int g = 0; g <= n; g++)
                    {
                        Console.WriteLine("j[" + g.ToString() + "]=" + j[g]);
                        for (int z = 0; z < n; z++)
                        {
                            //Console.WriteLine("as_theta"+"["+g.ToString()+"]"+"["+z.ToString()+"]="+as_theta[g][z].ToString());
                        }
                    }

                    //Advance Calculate Theta Bar
                    Theta_Bar(Sum, as_theta, n);//陣列元素相加後平均但是只取誤差函數小的前三點座標角度做相加
                    Console.WriteLine("Theta Bar Finish");
                    //step 4-1 
                    //Situation_Theta_Calculate(theta_r, Sum, alpha, as_theta, 1, n);
                    //Console.WriteLine("step 4-1");
                    //step 4-2
                    //Error_Function_Calculate(theta_r, jr, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                    Console.WriteLine("step 4");
                    Reflection_move(jr, theta_r, Sum, as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                    Console.WriteLine("jr=" + jr[0].ToString());
                    //Console.WriteLine("step 4-2");
                    //Step 05
                    double[] theta_new = new double[] { };
                    Console.WriteLine("step 5");
                    //Step 06
                    //Strp 06 Y
                    if (jr[0] < j[0])
                    {
                        Console.WriteLine("step 6 Y");
                        //Step 07-1 
                        //Situation_Theta_Calculate(theta_e, Sum, gamma, as_theta, 1, n);
                        //Console.WriteLine("step 7-1");
                        //Step 07-2
                        //Error_Function_Calculate(theta_e, je, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        //Console.WriteLine("step 7-2");
                        Console.WriteLine("step 7");
                        Expansion_move(je, theta_e, Sum, as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                        Console.WriteLine("je=" + je[0].ToString());

                        //Step 08
                        if (je[0] < jr[0])//Step 08 Y
                        {
                            Console.WriteLine("step 8 Y");
                            theta_new = theta_e;
                            //Step 16-1
                            ThetaNewToThetaN(n, as_theta, theta_new);
                            Console.WriteLine("step 16-1");
                            //step 16-2
                            j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);

                            Console.WriteLine("jn=" + j[n].ToString());
                            Console.WriteLine("step 16-2");
                            //Step 17
                            if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                            {
                                //j[n] >= j[0] 當確定最新的搜尋值 error index 大於等於 j[0] 時
                                //才停止搜尋，確保最新值不是更好的搜尋角度

                                //紀錄找到新的P點位置當前theta角度的值
                                //直接從j[0] 的 theta 提取
                                theta1[thi] = as_theta[0][0];
                                theta2[thi] = as_theta[0][1];
                                theta3[thi] = as_theta[0][2];
                                //紀錄error
                                //store_j[thi] = j[0];
                                //紀錄count times
                                //store_count[thi] = Count;
                                Console.WriteLine("step 17 Finish");
                                break;
                            }
                            else
                            {
                                Count++;  //累計遞迴次數

                                Console.WriteLine("Before Sort");
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                Console.WriteLine("j[0]=" + j[0].ToString());
                                Console.WriteLine("j[1]=" + j[1].ToString());
                                Console.WriteLine("j[2]=" + j[2].ToString());
                                Console.WriteLine("j[3]=" + j[3].ToString());
                                Console.WriteLine("j[4]=" + j[4].ToString());
                                Console.WriteLine("j[5]=" + j[5].ToString());
                                Console.WriteLine("j[6]=" + j[6].ToString());
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");


                                Console.WriteLine("step 17 Continue");
                                continue;
                            }
                        }
                        // Step 08 N
                        else
                        {
                            Console.WriteLine("step 8 N");
                            //Step 14  theta_new != null
                            theta_new = theta_r;
                            //Step 16-1
                            ThetaNewToThetaN(n, as_theta, theta_new);
                            Console.WriteLine("step 16-1");
                            //step 16-2
                            j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("j[n]=" + j[n].ToString());
                            Console.WriteLine("step 16-2");
                            //Step 17
                            if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                            {
                                //紀錄找到新的P點位置當前theta角度的值
                                //直接從j[0] 的 theta 提取
                                theta1[thi] = as_theta[0][0];
                                theta2[thi] = as_theta[0][1];
                                theta3[thi] = as_theta[0][2];
                                //紀錄error
                                //store_j[thi] = j[0];
                                //紀錄count times
                                //store_count[thi] = Count;

                                Console.WriteLine("step 17 Finish");
                                break;
                            }
                            else
                            {
                                Count++;  //累計遞迴次數

                                Console.WriteLine("Before Sort");
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                Console.WriteLine("j[0]=" + j[0].ToString());
                                Console.WriteLine("j[1]=" + j[1].ToString());
                                Console.WriteLine("j[2]=" + j[2].ToString());
                                Console.WriteLine("j[3]=" + j[3].ToString());
                                Console.WriteLine("j[4]=" + j[4].ToString());
                                Console.WriteLine("j[5]=" + j[5].ToString());
                                Console.WriteLine("j[6]=" + j[6].ToString());
                                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                Console.WriteLine("step 17 Continue");
                                continue;
                            }
                        }
                    }
                    //Step 06 N
                    else
                    {
                        Console.WriteLine("step 6 N");
                        //Step 09 Y
                        if (jr[0] < j[n])
                        {
                            Console.WriteLine("step 9 Y");
                            //Step 10-1 
                            //Situation_Theta_Calculate(theta_c, Sum, beta, as_theta, 1, n);
                            //Console.WriteLine("step 10-1");
                            //Step 10-2
                            //Error_Function_Calculate(theta_c, jc, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            //Console.WriteLine("step 10-2");
                            Console.WriteLine("step 10");
                            OuterShrink_move(jc, theta_c, Sum, as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("jc=" + jc[0].ToString());

                            //Step 11 Y
                            if (jc[0] < jr[0])
                            {
                                Console.WriteLine("step 11 Y");
                                theta_new = theta_c;
                                //Step 16-1
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                Console.WriteLine("step 16-1");
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("jn=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    //store_j[thi] = j[0];
                                    //紀錄count times
                                    //store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                            //Step 11 N
                            else
                            {
                                Console.WriteLine("step 11 N");
                                //Step 14  theta_new != null
                                theta_new = theta_r;
                                //Step 16-1
                                Console.WriteLine("step 16-1");
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("j[n]=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    //store_j[thi] = j[0];
                                    //紀錄count times
                                    //store_count[thi] = Count;


                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                        }
                        //Step 09 N
                        else
                        {
                            Console.WriteLine("step 9 N");
                            //Step 12-1 
                            //Situation_Theta_Calculate(theta_cc, Sum, beta, as_theta, 0, n);
                            //Console.WriteLine("step 12-1");
                            //Step 12-2
                            //Error_Function_Calculate(theta_cc, jcc, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            //Console.WriteLine("step 12-2");
                            Console.WriteLine("step 12");
                            InsideShrink_move(jcc, theta_cc, Sum, as_theta, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                            Console.WriteLine("jcc=" + jcc[0].ToString());

                            //Step 13 Y
                            if (jcc[0] < j[n])
                            {
                                Console.WriteLine("step 13 Y");
                                theta_new = theta_cc;
                                //Step 16-1
                                ThetaNewToThetaN(n, as_theta, theta_new);
                                Console.WriteLine("step 16-1");
                                //step 16-2
                                j[n] = JNError_Function_Calculate(as_theta, 0, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("j[n]=" + j[n].ToString());
                                Console.WriteLine("step 16-2");
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];

                                    //紀錄error
                                    //store_j[thi] = j[0];
                                    //紀錄count times
                                    //store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }

                            }
                            //Step 13 N
                            else
                            {
                                Console.WriteLine("step 13 N");
                                //Step 15
                                //多維收縮
                                Multidimensional_Contraction(n, as_theta, j, XXu[thi], YYu[thi], XXv[thi], YYv[thi]);
                                Console.WriteLine("step 15");
                                //這邊是否需要加入 sort ?
                                //Step 17
                                if (j[n] >= j[0] && (j[0] <= error_tolerate || Count >= number_of_times))// 最小的誤差函數 j0 為跳出遞迴程式的條件 or Count 遞迴次數的計算滿足我們設定的計次
                                {
                                    //紀錄找到新的P點位置當前theta角度的值
                                    //直接從j[0] 的 theta 提取
                                    theta1[thi] = as_theta[0][0];
                                    theta2[thi] = as_theta[0][1];
                                    theta3[thi] = as_theta[0][2];
                                    //紀錄error
                                    //store_j[thi] = j[0];
                                    //紀錄count times
                                    //store_count[thi] = Count;

                                    Console.WriteLine("step 17 Finish");
                                    break;
                                }
                                else
                                {
                                    Count++;  //累計遞迴次數

                                    Console.WriteLine("Before Sort");
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
                                    Console.WriteLine("j[0]=" + j[0].ToString());
                                    Console.WriteLine("j[1]=" + j[1].ToString());
                                    Console.WriteLine("j[2]=" + j[2].ToString());
                                    Console.WriteLine("j[3]=" + j[3].ToString());
                                    Console.WriteLine("j[4]=" + j[4].ToString());
                                    Console.WriteLine("j[5]=" + j[5].ToString());
                                    Console.WriteLine("j[6]=" + j[6].ToString());
                                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                                    Console.WriteLine("step 17 Continue");
                                    continue;
                                }
                            }
                        }
                    }
                }
                thi = thi + 1;
            }
            Theta1m2 = theta1;//路徑上每一點的theta1
            Theta2m2 = theta2;//路徑上每一點的theta2
            Theta3m2 = theta3;//路徑上每一點的theta3
            Ncount_m = k;
            Console.WriteLine("Simplex method Finish");
        }



        #endregion

        #endregion // End of Simplex Method Block

        //********************************單體法程式區塊 結束************************************//

        //重置HSV數值
        #region Reset HSV Value
        private void btn_resetHSV_Click(object sender, EventArgs e)
        {
            trackBar_HH.Value = 0;
            trackBar_HL.Value = 0;
            trackBar_SH.Value = 255;
            trackBar_SL.Value = 0;
            trackBar_VH.Value = 255;
            trackBar_VL.Value = 0;
            numericHH.Value = 0;
            numericHL.Value = 0;
            numericSH.Value = 255;
            numericSL.Value = 0;
            numericVH.Value = 255;
            numericVL.Value = 0;
            //checkBox_LH.Checked = false;
            checkBox_IV.Checked = false;
        }
        #endregion
        
        //設定同角度
        #region Set Positive Degree
        private void checkBox_DirectSame_CheckedChanged(object sender, EventArgs e)
        {
            if (TB_Motor1_D.Text != TB_Motor2_D.Text && TB_Motor1_D.Text != TB_Motor3_D.Text)
            {
                TB_Motor2_D.Text = TB_Motor1_D.Text;
                TB_Motor3_D.Text = TB_Motor1_D.Text;
            }
            else if (TB_Motor3_D.Text != TB_Motor2_D.Text && TB_Motor3_D.Text != TB_Motor1_D.Text)
            {
                TB_Motor1_D.Text = TB_Motor3_D.Text;
                TB_Motor2_D.Text = TB_Motor3_D.Text;
            }
            else if (TB_Motor2_D.Text != TB_Motor3_D.Text && TB_Motor2_D.Text != TB_Motor1_D.Text)
            {
                TB_Motor1_D.Text = TB_Motor2_D.Text;
                TB_Motor3_D.Text = TB_Motor2_D.Text;
            }
            else
            {
                TB_Motor1_D.Text = TB_Motor1_D.Text;
                TB_Motor2_D.Text = TB_Motor2_D.Text;
                TB_Motor3_D.Text = TB_Motor3_D.Text;
            }
        }
        #endregion

        //************************************註解******************************************//
        /*
        private void checkBox_LH_CheckedChanged(object sender, EventArgs e)
        {
            diff_LH = trackBar_HH.Value - trackBar_HL.Value;
        }*/
        
        //攝影機焦距(註解)
        #region Webcam Foucus Function
        /*public void webcam_foucus_processinog(int x)
        {
            IFilterGraph2 graphBuilder = new FilterGraph() as IFilterGraph2;
            IBaseFilter capFilter = null;
            int hr;
            CameraControlFlags ioldFlags;
            //iFlags,
            if (graphBuilder != null)
                graphBuilder.AddSourceFilterForMoniker(Global._SystemCamereas[x].Mon, null, Global._SystemCamereas[0].Name, out capFilter); //getting capture filter for converting it into IAMCameraControl
            IAMCameraControl _camera = capFilter as IAMCameraControl;
            hr = _camera.Get(CameraControlProperty.Focus, out Global._ioldvalue[x], out ioldFlags); //Setting focus to macro (in my camera, range between 0 - 250)
            //Console.WriteLine(Global._ioldvalue[x]);
            hr = _camera.Set(CameraControlProperty.Focus, 58, CameraControlFlags.Manual); //Setting focus to macro (in my camera, range between 0 - 250)
            hr = _camera.Get(CameraControlProperty.Focus, out Global._ioldvalue[x], out ioldFlags); //Setting focus to macro (in my camera, range between 0 - 250)
            //Console.WriteLine(Global._ioldvalue[x]);
            // Console.WriteLine(Global._ioldvalue[x] + "  " + "webcam"+(x+1).ToString());
        }*/
        #endregion

    }
    #endregion
    public class StoreObjectpotion
    {
        public Point Center;
    }

    #region ComboBox List Name And Value
    public class cboDataList
    {
        public string cbo_Name  { get; set; }
        public string cbo_Value { get; set; }
    }
    #endregion



    #region Class ImageCoordinate
    public class ImageCoordinate
    {
        public static int RC_X, RC_Y, RCS_X, RCS_Y;
        public static int LC_X, LC_Y, LCS_X, LCS_Y;
    }
    #endregion

    #region Class Global 
    public class Global
    {
        public static Image<Bgr , Byte> Image  = null;
        public static Image<Bgr , Byte> Image1 = null;
        public static int centerx = 0;
        public static int centery = 0;
        public static int[] _ioldvalue = { 0, 0, 0 };
        //public static int rx = 0, ry = 0, lx = 0, ly = 0;
        public static int thrx = 0, thry = 0;
        public static int IXu = 0, IYu = 0, IXv = 0, IYv = 0, FXu = 0, FYu = 0, FXv = 0, FYv = 0;
        public static double Itheta1 = 0.0, Itheta2 = 0.0, Itheta3 = 0.0;
        public static double Ftheta1 = 0.0, Ftheta2 = 0.0, Ftheta3 = 0.0;
        public static DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
    }
    #endregion
}
