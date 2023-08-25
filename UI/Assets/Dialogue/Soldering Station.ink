EXTERNAL ShowObject(objectName)
EXTERNAL ShowMoveHint(index)
EXTERNAL HideMoveHint(index)
EXTERNAL Highlight(ObjectName)
EXTERNAL HighlightOff(ObjectName)
EXTERNAL SolderAnimation(ObjectName)
EXTERNAL SolderAnimationwithButton(ObjectName)

-> menu

=== menu ===
Soldering Tutorial: Process Introduction (Choose the step to start)

+ Step 1: Intro
  -> step1
+ Step 2: solder equipment
  -> step2
+ Step 3: Through Hole Soldering
  -> step3  
+ Step 4: Desoldering
  -> step4  
+ Step 5: After Soldering
  -> step5  


  
=== step1 ===
Welcome to the AR Soldering Tutorial! 
Whether you're a beginner or looking to improve your soldering skills, this step-by-step guide will walk you through the fundamentals of soldering. 
~ ShowMoveHint(0)
You can save the steps that you think you might want to review next time. In the progress page, you can see and load the progress you saved.
~ HideMoveHint(0)
~ ShowMoveHint(1)
To continue the tutorial, you can press the "next" button on the text panel or press the objects with pulsing effects in some specific steps.
~ HideMoveHint(1)
->step2
=== step2 ===
Get ready to start a safe virtual soldering experience!
~ ShowObject("Station")
Align yourself with the Guide view of the soldering station.
~ ShowMoveHint(2)
Once the target object is aligned, you can move around the camera.
~ HideMoveHint(2)
~ Highlight("soldering_staion")
Let's first familiarize ourselves with the equipment needed for soldering. This is a digital soldering station.
~ HighlightOff("soldering_staion")
~ Highlight("Soldering_Iron")
The soldering iron. By heating a soldering iron, you can melt solder, a metal alloy with a low melting point, to join wires, circuit boards, and other electrical parts. 
~ HighlightOff("Soldering_Iron")
~ Highlight("bobin")
This is the soldering wire.The solder wire acts as a medium to connect electrical connections by creating a metallurgical bond between the soldering iron tip, the component, and the surface being soldered.
~ HighlightOff("bobin")

->step3
=== step3 ===
Let's start Soldering with a little exercise. We will try a example of throughhole soldering.
~ Highlight("breadboard")
There are some common throughhole components on the breadboard: capacitor, resistor,LED.
~ HighlightOff("breadboard")
~ Highlight("StripBoard")
We have a soldering station and a strip board.
~ HighlightOff("StripBoard")
~ SolderAnimationwithButton(0)
Bend the leg to make the component fit with the board. And sild the components into the pin hole.
~ SolderAnimationwithButton(1)
Turn on the soldering station.
~ SolderAnimationwithButton(2)
Prepare a wet sponge. Before you start soldering, apply some solder to the tip of the iron and clean it with the sponge.
~ SolderAnimationwithButton(3)
Use the tip of the soldering iron to heat up both the pinhole and the leg, and feed the solder onto it.
~ SolderAnimationwithButton(4)
Soldering a pin/leg usually takes only a few seconds. Do not heat the components for a long time to avoid damage to the components or board.
~ SolderAnimationwithButton(5)
Trim the leads just above the solder using the wire cutter.
~ SolderAnimationwithButton(6)
Before you make another connection. It is important to remove any excess solder reamining on the tip of the iron.
->step4
=== step4 ===
If you make a bad joint or want to remove a component, you need to do the desoldering.
~ Highlight("Solder Pump")
We can use desoldering pump to help us remove the components.
~ HighlightOff("Solder Pump")
~ SolderAnimationwithButton(7)
Push done the plunger before desoldering.
~ SolderAnimationwithButton(8)
Heat the solder directly with the soldering iron with the tip of the pump next to the solder joint.
~ SolderAnimationwithButton(9)
Press the button.Then the pump sucks up the solder. Sometimes it takes several attempts to remove the component.(Press the button in the scene)
->step5
=== step5 ===
When soldering is complete, several steps are required to ensure the safety of the equipment and the user.
~ SolderAnimationwithButton(10)
When you are not soldering, remember always keep the iron into the holder.
~ SolderAnimationwithButton(11)
Remember to turn off the soldering station.
Thank you so much for taking the MARTA soldering station training!

-> END
