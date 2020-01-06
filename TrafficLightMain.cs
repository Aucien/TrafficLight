/*
Author: Gordon Dan
Email:  gdan189@csu.fullerton.edu
Course: CPSC 223N
Semester: Fall 2019
Assignment #: 2
Program Name: TrafficLight
 */
using System;
using System.Windows.Forms;

public class ButtonMain
{
    static void Main(){
        System.Console.WriteLine("Welcome to the Main Method of the Traffic Light Program");
        TrafficUI app = new TrafficUI();
        Application.Run(app);
        System.Console.WriteLine("Main method of Traffic light will now shutdown.");
    }
}