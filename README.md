# StepOverGap_FOV
 ## Introduction
 This is the program of *Experiment 3* in paper **Gagnon, H.C., Zhao, Y., Richardson, M., Pointon, G., Stefanucci, J.K., Creem-Regehr, S., & Bodenheimer, B. (2021). Gap Affordance Judgments in Mixed Reality: Testing the Role of Display Weight and Field of View. Frontiers in Virtual Reality.** (DOI:10.3389/frvir.2021.654656)
 
 ## Goal
 Manipulate Field of View (Comparing Narrow FOV - 50°Horizontal x 23°Vertical and Wide FOV - Natural HTC Vive Pro FOV) to explore how it affect human affordance judgement when crossing a gap
 
 ## Protocol
 96 trials in total
 
 4 conditions : 2FOV (Wide/Narrow) x 2Directions(0°/90°)
 
 In each condition, 24 trials with gap changing in range from 0.45 to 1.50 with 0.15 increments (for a total of 8 gaps, 3x each, in random order)
 
 ## How to run
To run this project, you can choose "Windows Build" or "Mac Build" according to your OS. You need a Vive HMD and one controller.

Under **Project** file, you can find the source code. 

This project is created using Unity 2019.2.21f1. Any Unity 2019.2.x should work fine with this project. 

Scenes are in StepOverGap_FOV/Project/FOV_HDRP/Assets/MyScenes. 
**StartScene** and **VRScene** are main scenes for recording subject's information and running the experiment. 
**TestFOV** is for getting the parameters of the simulated FOV using the virtual mapping environment as frame of reference. 



