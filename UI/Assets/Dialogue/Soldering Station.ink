EXTERNAL ShowObject(objectName)
EXTERNAL Highlight(ObjectName)
EXTERNAL HighlightOff(ObjectName)
EXTERNAL SolderAnimation(ObjectName)

-> menu

=== menu ===
Soldering Tutorial

+ Step 1: Intro
  -> step1
+ Step 2: solder equipment
  -> step2
+ Step 3: Through Hole Soldering
  -> step3  
+ Step 4: Wire Soldering
  -> step4  
+ Step 5: Desoldering
  -> step5  
+ Step 6: After Soldering
  -> step6

  
=== step1 ===
Welcome to the AR Soldering Tutorial! 
Whether you're a beginner or looking to improve your soldering skills, this step-by-step guide will walk you through the fundamentals of soldering. 
Get ready to start a safe virtual soldering experience!
->step2
=== step2 ===
Align yourself with the Guide view of the soldering station.
~ ShowObject("Station")
Let's first familiarize ourselves with the equipment needed for soldering.
~ Highlight("soldering_staion")
This is a digital soldering station.
~ HighlightOff("soldering_staion")
~ Highlight("Soldering_Iron")
The soldering iron. By heating a soldering iron, you can melt solder, a metal alloy with a low melting point, to join wires, circuit boards, and other electrical parts. 
~ HighlightOff("Soldering_Iron")
~ Highlight("bobin")
This is the soldering wire.The solder wire acts as a medium to connect electrical connections by creating a metallurgical bond between the soldering iron tip, the component, and the surface being soldered.
~ HighlightOff("bobin")

->step3
=== step3 ===
Let's start Soldering with a little exercise.
We will start with the throughhole soldering.
~ Highlight("breadboard")
There are some common throughhole components on the breadboard: capacitor, resistor,LED.
~ HighlightOff("breadboard")
~ Highlight("StripBoard")
We have a soldering sation and a strip board.
~ HighlightOff("StripBoard")
~ SolderAnimation("1PlugResistor")
Bend the leg to make the component fit with the board. And sild the components into the pin hole.
~ SolderAnimation("2TurnOnStation")
Turn on the soldering station.
~ SolderAnimation("3ApplySolder")
Prepare a wet sponge. Before you start soldering, apply some solder to the tip of the iron and clean it with the sponge.
Use the tip of the soldering iron to heat up both the pinhole and the leg, and feed the solder onto it.
Soldering a pin/leg usually takes only a few seconds. Do not heat the components for a long time to avoid damage to the components or board.
Trim the leads just above the solder using the wire cutter.
Before you make another connection. It is important to remove any excess solder reamining on the tip of the iron.
->step4
=== step4 ===
Then Let's try to solder the wire to board.
We need to solder the wires to the battery pads.
Firtsly, strip a couple of millimeter of the wire.
Twist and tin the wire.
Haet up the pads and apply some solder on to it.
Heat uo the solder and insert the wire into them.
->step5
=== step5 ===
If you make a bad joint or want to remove a component, you need to do the desoldering.
~ Highlight("Solder Pump")
We can use desoldring pump to help us remove the components.
~ HighlightOff("Solder Pump")
Push done the plunger before desoldering.
Heat the solder directly with the soldering iron with the tip of the pump next to the solder joint.
Press the button.Then the pump sucks up the solder. Sometimes it takes several attempts to remove the component.
->step6
=== step6 ===
When soldering is complete, several steps are required to ensure the safety of the equipment and the user.
When you are not soldering, remember always keep the iron into the holder.
Remember to turn off the soldering station.

-> END
