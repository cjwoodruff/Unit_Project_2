/* This is just a simple text adventure room escape for Unity.
 * All initial states of items are noted with the '_0' in their name.
 * Altered states will show with a number higher than 0.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell,         mirror,         sheets_0,
                          lock_0,       cell_mirror,    sheets_1,
                          lock_1,       floor,        	corridor_0,
                          corridor_1,   corridor_2,     corridor_3,
                          stairs_0,     stairs_1,       stairs_2,
                          courtyard,    closet_door,    in_closet
                          };
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if      (myState == States.cell)        { cell(); }
        else if (myState == States.sheets_0)    { sheets_0(); }
        else if (myState == States.sheets_1)    { sheets_1();  }
        else if (myState == States.lock_0)      { lock_0(); }
        else if (myState == States.lock_1)      { lock_1(); }
        else if (myState == States.mirror)      { mirror(); }
        else if (myState == States.cell_mirror) { cell_mirror(); }
        else if (myState == States.corridor_0)  { corridor_0(); }
        else if (myState == States.corridor_1)  { corridor_1(); }
        else if (myState == States.corridor_2)  { corridor_2(); }
        else if (myState == States.corridor_3)  { corridor_3(); }
        else if (myState == States.stairs_0)    { stairs_0(); }
        else if (myState == States.stairs_1)    { stairs_1(); }
        else if (myState == States.stairs_2)    { stairs_2(); }
        else if (myState == States.courtyard)   { courtyard(); }
        else if (myState == States.closet_door) { closet_door(); }
        else if (myState == States.in_closet)   { in_closet(); }
        else if (myState == States.floor)       { floor(); }
    }

    void cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the " +
                    "door is locked from the outside.\n\n" +
                    "Press S to view the sheets\n" +
                    "Press M to view the mirror\n" +
                    "Press L to view the lock\n";

        if      (Input.GetKeyDown(KeyCode.S))   { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.L))   { myState = States.lock_0; }
        else if (Input.GetKeyDown(KeyCode.M))   { myState = States.mirror; }
    }

    void sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to return to roaming your cell.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.cell; }
    }

    void sheets_1()
    {
        text.text = "Holding the mirror in your hand doesn't make the sheets look " +
                    "any better.\n\n" +
                    "Press R to Return to roaming your cell.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_mirror; }
    }

    void lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.cell; }
    }

    void lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it around " +
                    "so you can see the lock. You can just make out the fingerprints around " +
                    "the buttons. You press the dirty buttons, and here a click.\n\n" +
                    "Press O to Open, or R to Return to your cell.";
        if      (Input.GetKeyDown(KeyCode.O))   { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_mirror; }
    }

    void mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the Mirror, or R to Return to your cell.";
        if      (Input.GetKeyDown(KeyCode.T))   { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.cell; }
    }

    void cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There " +
                    "are some dirty sheets on the bed, a faded spot on the wall where " +
                    "where the mirror was, and the pesky door is still there, and " +
                    "firmly locked!\n\n" +
                    "Press S to view the sheets, or L to view the Lock";
        if (Input.GetKeyDown(KeyCode.S))        { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))   { myState = States.lock_1; }
    }

    void corridor_0()
    {
        text.text = "You've managed to get out of that tiny cell. Now, you need to " +
                    "make your way into the courtyard if you're going to have a chance " +
                    "to escape. You see a set of stairs that will lead out, a closet " +
                    "door, and something sitting on the floor\n\n" +
                    "Press C to view the Closet door, F to examine the Floor, and S to" +
                    "head to the Stairs";
        if (Input.GetKeyDown(KeyCode.C))        { myState = States.closet_door; }
        else if (Input.GetKeyDown(KeyCode.F))   { myState = States.floor; }
        else if (Input.GetKeyDown(KeyCode.S))   { myState = States.stairs_0; }
    }

    void corridor_1()
    {
        text.text = "The floor is clear of debris. There are still the stairs and the " +
                    "closet that is locked.\n\n" +
                    "Press S to go to the Stairs, or C to try and unlock the Closet.";
        if      (Input.GetKeyDown(KeyCode.S))   { myState = States.stairs_1; }
        else if (Input.GetKeyDown(KeyCode.C))   { myState = States.in_closet; }
    }

    void corridor_2()
    {
        text.text = "You were obviously too good to dress as a cleaner. You are back in " +
                    "corridor.\n\n" +
                    "Press S to go to the Stairs, of C to go back in the closet.";
        if      (Input.GetKeyDown(KeyCode.S))   { myState = States.stairs_2; }
        else if (Input.GetKeyDown(KeyCode.C))   { myState = States.in_closet; }
    }

    void corridor_3()
    {
        text.text = "You're standing in the corridor in a cleaner's uniform. You fight " +
                    "the urge to bolt through to freedom.\n\n" +
                    "Press S to take the Stairs, or U to Undress";
        if      (Input.GetKeyDown(KeyCode.S))   { myState = States.courtyard; }
        else if (Input.GetKeyDown(KeyCode.U))   { myState = States.in_closet; }
    }

    void closet_door()
    {
        text.text = "The door is locked. If only there was something that you " +
                    "could use to pick the lock.\n\n" +
                    "Press R to Return the corridor.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_0; }
    }

    void in_closet()
    {
        text.text = "Insode the closet is a cleaner's uniform that looks like " +
                    "it will fit!\n\n" +
                    "Press D to Dress up, or R to Return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.D))   { myState = States.corridor_3; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_2; }
    }

    void stairs_0()
    {
        text.text = "You can hear some of the guards chatting it up. It probably " +
                    "wouldn't be wise to just walk on by looking like that.\n\n" +
                    "Press R to Return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_0; }
    }

    void stairs_1()
    {
        text.text = "Although the hairpin would make a nice accessory, I don't " +
                    "think it will make you look THAT much different.\n\n" +
                    "Press R to Return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_1; }
    }

    void stairs_2()
    {
        text.text = "You've managed to pick the lock, but there doesn't seem to " +
                    "be a good reason to go tell the guards that at the moment.\n\n" +
                    "Press R to return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_2; }
    }

    void floor()
    {
        text.text = "You take a closer look at the floor, and you see a hairpin. " +
                    "That may be useful to pick a lock with.\n\n" +
                    "Press T to Take the hairpin, or R to Return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.T))   { myState = States.corridor_1; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.corridor_0; }
    }

    void courtyard()
    {
        text.text = "You calmly walk out onto the courtyard dressed as a cleaner. " +
                    "The guard eyes you but let's you pass. Your heart pounds in " +
                    "your chest as you take your first steps out of the prison as a " +
                    "freed man.\n\n" +
                    "Press P to Play again.";
        if      (Input.GetKeyDown(KeyCode.P))   { myState = States.cell; }
    }
}
