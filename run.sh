#Author: Gordon Dan
#Email:  gdan189@csu.fullerton.edu
#Course: CPSC 223N
#Semester: Fall 2019
#Assignment #: 2
#Program Name: Traffic Light


rm *.dll
rm *.exe

mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:TrafficLightUI.dll TrafficLightUI.cs
mcs -r:System -r:System.Windows.Forms -r:TrafficLightUI.dll -out:TrafficLight.exe TrafficLightMain.cs

./TrafficLight.exe