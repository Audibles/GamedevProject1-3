## Project 1-3 Spec [Due 2/16]:

### How to get the project

1. Clone the repo with 
  ``git clone https://github.com/berkeleyGamedev/Project1-3.git``
2. Check Piazza for bug fixes!

### About the Project

This project is for teams of 1-2 (we would prefer teams of 2). Every team must have at least 1 programmer. Every team must do the Editor and Programming sections, and the Art section is optional.

### Grade Breakdown:

Requirements: 100%

### Project Specification

**A note on UIManager:** ``UIManager`` uses the **Singleton** pattern. This pattern declares a static member variable to be the single instance of the class, so that it can be accessed globally through ```UIManager.uiManager``` (``uiManager`` is the name of our static member variable). In ``Start()``, we enforce this pattern by checking if an instance already exists, and destroying any new ``UIManager`` objects that are created. 

**A note on SceneManager.LoadScene:** ``SceneManager.LoadScene(string scene name)`` would be the normal way to load a scene in Unity. For "Main Scene" (our World 1-1 scene), we have abstracted it in ``UIManager.LoadScene()`` to make sure that the Loading Screen shows up using a coroutine. When you want to reload the Main Scene, please use ```UIManager.LoadScene()```, but the menu can be reloaded in the normal way.

**Some helpful links:** [Unity UI Tutorial Videos](https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-canvas). You'll probably only need 1-4. [Singleton Pattern](http://gameprogrammingpatterns.com/singleton.html), and optional reading about the [State pattern](http://gameprogrammingpatterns.com/state.html) you saw in Project 1-1. The whole book is really useful. 

#### Unity Editor:  

1. In the 1Player GameObject, make the button component interact with ``LoadOnClick`` component attached to its parent. Specifically, it should call ``LoadOnClick.LoadScene()``.

**Note:** The buttons are just the two cursor positions next to "1 Player" and "2 Player" on the Title Screen.

#### Programming:  

1. UIManager.cs
   1. ``TakeLife()``
1. LoadOnClick.cs
   1. ``LoadScene()``
1. PlayerController.cs
   1. ``Shrink()`` 

#### Art (Optional):

1. Feel free to replace any of the font sprites or any of the buttons. Please make sure your sprites are 8x8 so that they'll easily fit in the UI framework we've created. (Or not, but you'll have to move things around yourself.) Buttons can be any size, but for reference, our button sprites are 55x55. Also make sure to put them in the Assets/Resources folder so that they can be accessed at runtime. 

### Submission:

* Place a copy of all your art files into a separate folder.

* Make sure you have added us as collaborators

* Add a commit with a final submission tag
