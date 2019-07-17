>**Note: Clone the project using git. A download of the project via ZIP will be missing files necessary for the demo scene.**

# Otto
Welcome to the Otto sample project for the [AI Planner](https://docs.unity3d.com/Packages/com.unity.ai.planner@0.0/). Otto is an agent which derives happiness from working, but must eat, drink, and sleep to stay alive in order to work.

## What is the AI Planner?
The AI Planner includes authoring tools and a system for automated decision-making, which includes:
* Directing agent behavior either in a cooperative, neutral, or adversarial capacity
* Auto-generating storylines or as an online story manager
* Validating game design mechanics
* Assisting in creating tutorials
* Automated testing

Start by creating a domain definition in the authoring tool that models the problem space at an abstract level. Then, create one or more plan definitions that provide rules for what actions or decisions can be made. Submit these to the planner system and get back a plan that converges on an optimal solution and can update as changes in the world occur.

## Installation Guide
1. Clone this repo (downloading a .zip file will not include largefiles -- e.g. fbx, png)
2. Open the project in Unity version 2019.1 or later

## References
The Otto project shows how to make use of the AI Planner for a specific use case. Useful references include:
* WorkaholicDomain.asset (open this in Unity)
* WorkaholicActions.asset (open this in Unity)
* [Otto.cs](Assets/Scripts/Otto.cs)
* [NeedsUpdateSystem.cs](Assets/Scripts/NeedsUpdateSystem.cs)
* [Operational Actions](Assets/Scripts/OperationalActions/)

## Documentation
Documentation for the AI Planner is available through the [package documentation](https://docs.unity3d.com/Packages/com.unity.ai.planner@0.0/). No additional documentation exists currently for the Otto project.

For further discussion, [please visit the forum](https://forum.unity.com/forums/ai-navigation-previews.122/).
