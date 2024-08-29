namespace CodedDungeon.States.Menus;


public class StateMenus : State { /////// RENDRED LES TRUCS PRIVES


    public int cursorPos;
    public int selectedOption;

    public string title;

    public Dictionary<string, int> mainMenuOptions;


    public StateMenus(Game game) : base(game) { }
}
