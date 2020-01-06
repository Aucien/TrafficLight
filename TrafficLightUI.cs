/*
Author: Gordon Dan
Email:  gdan189@csu.fullerton.edu
Course: CPSC 223N
Semester: Fall 2019
Assignment #: 2
Program Name: Traffic Light
 */
 using System;
 using System.Drawing;
 using System.Windows.Forms;
 using System.Timers;

 public class TrafficUI : Form{
    private Label title = new Label();
    private const int formwidth = 1280;
    private const int formheight = 1000;
    private Label ROTlabel = new Label();
    private Button exitbutton = new Button(); 
    private Button startbutton = new Button();
    private Button pausebutton = new Button();
    private RadioButton fastbutton = new RadioButton();
    private RadioButton slowbutton = new RadioButton();
    private const int radius = 125;
    private int Light = 0;
    private int tickcounter = 0;
    private int greenspeed = 3;
    private int yellowspeed = 1;
    private int redspeed = 4;
    private bool startsB = false;
    private bool pausesB = false;
    private static System.Timers.Timer clock = new System.Timers.Timer();
    

    public TrafficUI(){
        //General UI
        Size = new Size(formwidth, formheight);
        Text = "Traffic Light";
        BackColor = Color.ForestGreen;

        //Titles
        title.Text = "Traffic Light by Gordon Dan";
        title.Size = new Size(250, 20);
        title.Location = new Point(560, 0);
        title.BackColor = Color.PaleGreen;
        Controls.Add(title);

        ROTlabel.Text = "Rate of Change";
        ROTlabel.Size = new Size(130, 20);
        ROTlabel.Location = new Point(500, 880);
        ROTlabel.BackColor = Color.Yellow;
        Controls.Add(ROTlabel);

        //RadioButtons
        fastbutton.Text = "Fast";
        fastbutton.Size = new Size(70, 40);
        fastbutton.Location = new Point(560, 900);
        fastbutton.BackColor = Color.Yellow;
        fastbutton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        Controls.Add(fastbutton);

        slowbutton.Text = "Slow";
        slowbutton.Size = new Size(70, 40);
        slowbutton.Location = new Point(500, 900);
        slowbutton.BackColor = Color.Yellow;
        slowbutton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        Controls.Add(slowbutton);

        //Exit Button
        exitbutton.Text = "Exit";
        exitbutton.BackColor = Color.Yellow;
        exitbutton.Size = new Size(100,40);
        exitbutton.Location = new Point(775, 900);
        Controls.Add(exitbutton);
        exitbutton.Click += new EventHandler(stoprun);

        //Timer
        clock.Interval = 1000;
        clock.Enabled = false;
        clock.Elapsed += Signal;

        //Start Button
        startbutton.Text = "Start";
        startbutton.Size = new Size(100,40);
        startbutton.Location = new Point(350, 900);
        Controls.Add(startbutton);
        startbutton.Click += new EventHandler(run);
        startbutton.BackColor = Color.Yellow;
        
        //Pause Button
        pausebutton.Text = "Pause";
        pausebutton.Size = new Size(100,40);
        pausebutton.Location = new Point(660, 900);
        pausebutton.BackColor = Color.Yellow;
        Controls.Add(pausebutton);
        pausebutton.Click += new EventHandler(pausing);
    }//End of TrafficUI constructor

    private void radioButtons_CheckedChanged (object sender, EventArgs e){
        RadioButton radioButton = sender as RadioButton;
        if(slowbutton.Checked){
            greenspeed = 6;
            yellowspeed = 2;
            redspeed = 8;
        }
        else if(fastbutton.Checked){
            greenspeed = 3;
            yellowspeed = 1;
            redspeed = 4;
        }
    }//end of radioButtons_CheckedChanged

    protected void Signal(Object sender, ElapsedEventArgs e){
        if(Light == 0){
            Light = 1;
        }
        tickcounter++;
        System.Console.WriteLine(tickcounter);
        switch(Light){
            //Red Light
            case 1:
                if(tickcounter > redspeed){
                    tickcounter = 0;
                    Light = 3;
                    Invalidate();
                }
                break;
            //Yellow Light
            case 2:
                if(tickcounter > yellowspeed){
                    tickcounter = 0;
                    Light = 1;
                    Invalidate();
                }
                break;
            //Green Light
            case 3:
                if(tickcounter > greenspeed){
                    tickcounter = 0;
                    Light = 2;
                    Invalidate();
                }
                break;
        }//End of Switch
    }//end of Signal

    protected void run(Object sender, EventArgs events){
        tickcounter = 0;
        Light = 0;
        clock.Enabled = true;
        Invalidate();
    }

    protected void pausing(Object sender, EventArgs events){
        if(pausesB == false){
            pausesB = true;
            clock.Enabled = false;
            Invalidate();
        }
        else{
            pausesB = false;
            clock.Enabled = true;
            Invalidate();
        }
    }

   protected override void OnPaint(PaintEventArgs ee){
       Graphics graph = ee.Graphics;
       graph.FillRectangle(Brushes.PaleGreen, 0, 0, 1280, 30);
       graph.FillRectangle(Brushes.LightCyan, 0, 870, 1280, 100);
       switch(Light){
           case 1:  //Red Light
                graph.FillEllipse(Brushes.Red, 500, 50, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 322, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 594, 2 * radius, 2 * radius);
                break;
            case 2: //Yellow Light
                graph.FillEllipse(Brushes.Gray, 500, 50, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Yellow, 500, 322, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 594, 2 * radius, 2 * radius);
                break;
            case 3: //Green Light
                graph.FillEllipse(Brushes.Gray, 500, 50, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 322, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Green, 500, 594, 2 * radius, 2 * radius);
                break;
            default: //No Power
                graph.FillEllipse(Brushes.Gray, 500, 50, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 322, 2 * radius, 2 * radius);
                graph.FillEllipse(Brushes.Gray, 500, 594, 2 * radius, 2 * radius);
                break;
       }
       base.OnPaint(ee);
   }

    protected void stoprun(Object sender, EventArgs events){
        Close();
    }//End of Stop Run
 }//End of TrafficUI Class