
IK Simple Solver 2D is an easy to use, two bone IK solver. 
It is a complete 2 Bone IK solver so no scripting is needed.



- How to Use -

	The IK Controller is very easy to use. Simply:

- Add the "IK" script to your first joint ( The first joint being the one closest to the "shoulder" ) 
- Parent your second joint to the first
- Create a target transform and assign it to the "Target Pos" transform in the IK Editor
- Finally Press the "IK OFF" button to toggle the IK on

	NOTE :  If you change the length of a Bone press the "Update IK" button to fix bone lengths in code.
	NOTE :  The tool works great with mechanim. Just animate the Target Transform position and the IK Should follow.
	NOTE :  If this guide was not enough, the Unity Asset Store page has a detail video that explains how to use the tool and how all of
			the components work.

		
- The Algorithm -
	
	The algorithm behind this solver uses an algebraic approach. The bone angles are calculated using the information given. 
(ie. the length of the bones, the position of the target etc.) All of the algorithm code's accessibility is private because a user should not need to modify
the algorithm source. 

Here is a link to the setup video - https://www.youtube.com/watch?v=JUoVGQa-qU8
For futher support you may contact me at Barry.p.evans@gmail.com
