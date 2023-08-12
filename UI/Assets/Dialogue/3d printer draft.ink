EXTERNAL ShowHints(Hintsnumber)
EXTERNAL LCDHints(Hintsnumber)
EXTERNAL PrinterSetupAnimation(AnimationName)
EXTERNAL PrinterSetupAnimationTrigger(TriggerName)
EXTERNAL ChooseModel(ModelName)
-> menu

=== menu ===
3D Printer Tutorial 

+ Step 1: Intro
  -> step1
+ Step 2: Know about 3D Printer
  -> step2
+ Step 3: Slicer Setup
  -> step3  
+ Step 4: Printer Setup
  -> step4  
+ Step 5: Start Printing
  -> step5  
+ Step 6: Notice when printing
  -> step6
+ Step 7: End Printing
  -> step7

  
=== step1 ===
=s1
Welcome to our augmented reality tutorial for 3D printing! This Tutorial will guide you through the process of using a 3D printer. Let's embark on this journey together and discover the incredible world of 3D printing!
You can save the steps that you think you might want to review next time.
In the connected environments lab, we have Prusa MK3S+ single-filament printer.
->step2
=== step2 ===
Get ready to start your AR 3D printer training experience!#show3DPrinter:Printer
Please align the Prusa MK3S+ single-filament printer with the Printer Guide on the screen.
Before you start 3D printing, let's get to know some of the basic parts of a printer.
~ ShowHints(0)
This is the control panel. (Press the highlighted area to continue.)
~ ShowHints(1)
Controlling the LCD screen is done by a single control element: a rotational knob that you press to confirm the selection.
~ ShowHints(2)
Pressing the reset button equates to quickly toggling the power switch.
~ ShowHints(3)
The filament spool with PLA filament. You can change the filament. And please put the spool back to storage box when not printing.
~ ShowHints(4)
When setting up the slicer, please pay attention to the nozzle diameter of the printer.
->step3
=== step3 ===
Before you start a printing, you need to get the sliced g-code file.
~ ShowHints(5)
Please open the laptop.
Then download and open PrusaSlicer.#ChangeLaptop:PrusaSlicer1
Slicer will convert the 3D model to a set of instructions for the printer.#ChangeLaptop:PrusaSlicer2
Include the following printers in the configuration.#ChangeLaptop:PrusaSlicer3
Select Prusament PLA for the filament choice.#ChangeLaptop:PrusaSlicer4
Click Finish.#ChangeLaptop:PrusaSlicer5
~ ChooseModel("Box")
Let's try to print a box as an example. You can get a printable 3D model from thingverse or sketchfab or create by yourself.#ChangeLaptop:PrusaSlicer6
Now you have the model imported. Check the print settings and click on slice to confirm slicing.#ChangeLaptop:PrusaSlicer8
Export g-code to SD card.
->step4
=== step4 ===
Now you have the file to be printed. 
~ ShowHints(6)
Before you actually start 3D printing, you need to set up the printer.
~ ShowHints(7)
Makesure you have the filament with the spool ready.
~ LCDHints(0)
Then you can goto the LCD screen on the printer. Go down to autoload filament.
~ LCDHints(1)
Click the button and ready to load the filament.
~ PrinterSetupAnimationTrigger(0)
If the end of the filament is curled, you can snip the end to make it sharp.
~ LCDHints(2)
Load the filament into the extruder and select the filament material, press the button to confirm. (Here we have PLA in lab.)
~ PrinterSetupAnimation("HeatNozzle")
Then the printer will start to preheating. Once the preheating is completed, press the knob to load the filament.
~ LCDHints(3)
Look closely to the nozzle. The LCD will ask whether the loading the finished. If the filament haven't coming out with the right color, select 'no' unitil it is fully ready.
->step5
=== step5 ===
Now we are ready to print!
~ PrinterSetupAnimationTrigger(1)
Here we show the example of printing with SD card. Insert the SD card with the G-code file first.
~ LCDHints(4)
Select the file we have just created. Press the knob to confirm.
The printer will calibrate XYZ and preheat the bed before start.
~ LCDHints(5)
On the LCD you can see the progress of printing in % and remaining time estimation.
->step6
=== step6 ===
Even though the 3D printing tech has advanced rapidly, it is not stable yet.
~ ShowHints(8)
Prints fail all the time, especially in the first layer.Watch the first few printed layers to be sure filament has attached to the bed properly (5 to 10 minutes).
Sometimes the results will not be good and you might need to optimise the settings and try multiple times.
~ PrinterSetupAnimation("CompletePrinting")
->step7
=== step7 ===
Now the 3D printing has finished.
~ PrinterSetupAnimation("CoolDown")
When the printing is finished, let both nozzle and heatbed cool down before removing the printed object. 
~ PrinterSetupAnimation("RemovePrint")
Always handle the printed objects when the temperature of the bed and nozzle drop to room temperature. Remove the steel sheet from the printer and bend it slightly; prints should pop off.
~ LCDHints(6)
When not using a 3D printer, please turn down the temperature of the nozzle and bed to 0.
Thank you so much for taking the MARTA 3D printer training!
-> END
