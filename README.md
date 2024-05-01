# Witmotion Data export for OpenXR Motion Compensation
## The background
I am using this tool to compensate the motion of my VR vs my motion rig in DCS.
This little tool is used to read the witmotion data and pass it on to be used in OpenXR Motion Compensation.
**It only send pitch & roll data**
## How it work
There are 2 ways you can consume the information
* Using FlyPT mover and create a custom UDP hook. There are 2 Int32 values send to the IP  and the UDP port set in the screen. In FlyPT consume these. Divide them by 100 to get the actual angle detected
* Use MMF. OpenXR motion compensation will receive the pitch & roll. You can invert the data received (positive vs negative)
## Disclaimer
I am by far a good programmer. Early 40's and my last windows dev was made on Visual Basic 4.0. Yes, I am getting old :-p 
