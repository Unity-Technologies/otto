>**Note: Clone the project using git. A download of the project via ZIP will be missing files necessary for the demo scene.**

# Otto
Welcome to the Otto sample project for the [AI Planner](https://docs.unity3d.com/Packages/com.unity.ai.planner@0.1/). Otto derives happiness from working, but must eat, drink, and sleep to stay alive in order to work.

## What is the AI Planner?
The AI Planner includes authoring tools and a system for automated decision-making, which includes:
* Directing agent behavior either in a cooperative, neutral, or adversarial capacity
* Auto-generating storylines or as an online story manager
* Validating game design mechanics
* Assisting in creating tutorials
* Automated testing

Start by defining a planning domain, composed of objects with which your agent may interact. Then, create definitions for what actions or decisions an agent may make. Once the planning problem is defined, the planner system will iteratively build a plan that converges to an optimal solution. Execute these plans by creating an agent script and game code to control your characters.

## Installation Guide
1. Clone this repo using `git lfs clone` (downloading a .zip file will not include [largefiles](https://help.github.com/en/articles/installing-git-large-file-storage) -- e.g. fbx, png)
2. Open the project in Unity version 2019.2

## References
The Otto project shows how to make use of the AI Planner for a specific use case. Useful references include:
* AI.Planner/Actions/*.asset (open this in Unity)
* AI.Planner/Agents/*.asset (open this in Unity)
* AI.Planner/Enums/*.asset (open this in Unity)
* AI.Planner/Termination/*.asset (open this in Unity)
* AI.Planner/Traits/*.asset (open this in Unity)
* [Otto.cs](Assets/Scripts/Otto.cs)
* [UpdateNeeds.cs](Assets/AI.Planner/Workaholic-Custom/UpdateNeeds.cs)
* [Operational Actions](Assets/Scripts/OperationalActions/)

## Documentation
Documentation for the AI Planner is available through the [package documentation](https://docs.unity3d.com/Packages/com.unity.ai.planner@0.1/). No additional documentation exists currently for the Otto project.

For further discussion, [please visit the forum](https://forum.unity.com/forums/ai-navigation-previews.122/).
