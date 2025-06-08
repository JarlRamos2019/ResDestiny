// =============================================================================
// FILE: Constants.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the constants relevant for the game.
// Also contains all relevant enums required by each class.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    /// <summary>
    /// Anatol's first name
    /// </summary>
    public static readonly string NAME_ANATOL = "Anatol";
    /// <summary>
    /// Ariella's first name
    /// </summary>
    public static readonly string NAME_ARIELLA = "Ariella";
    /// <summary>
    /// Bargette's first name
    /// </summary>
    public static readonly string NAME_BARGETTE = "Bargette";
    /// <summary>
    /// Basu's name
    /// </summary>
    public static readonly string NAME_BASU = "Basu";
    /// <summary>
    /// Calista's first name
    /// </summary>
    public static readonly string NAME_CALISTA = "Calista";
    /// <summary>
    /// Delilah's first name
    /// </summary>
    public static readonly string NAME_DELILAH = "Delilah";
    /// <summary>
    /// Diaochan's name
    /// </summary>
    public static readonly string NAME_DIAOCHAN = "Diaochan";
    /// <summary>
    /// Felix's first name
    /// </summary>
    public static readonly string NAME_FELIX = "Felix";
    /// <summary>
    /// Fleurbeau's first name
    /// </summary>
    public static readonly string NAME_FLEURBEAU = "Fleurbeau";
    /// <summary>
    /// Gibb's first name
    /// </summary>
    public static readonly string NAME_GIBB = "Gibb";
    /// <summary>
    /// Gika's first name
    /// </summary>
    public static readonly string NAME_GIKA = "Gika";
    /// <summary>
    /// Harbo's first name
    /// </summary>
    public static readonly string NAME_HARBO = "Harbo";
    /// <summary>
    /// Heiji's first name
    /// </summary>
    public static readonly string NAME_HEIJI = "Heiji";
    /// <summary>
    /// Khadijah's first name
    /// </summary>
    public static readonly string NAME_KHADIJAH = "Khadijah";
    /// <summary>
    /// Kila's name
    /// </summary>
    public static readonly string NAME_KILA = "Kila";
    /// <summary>
    /// Kilroy's first name
    /// </summary>
    public static readonly string NAME_KILROY = "Kilroy";
    /// <summary>
    /// Korus' first name
    /// </summary>
    public static readonly string NAME_KORUS = "Korus";
    /// <summary>
    /// Lah'zaar's first name
    /// </summary>
    public static readonly string NAME_LAHZAAR = "Lah'zaar";
    /// <summary>
    /// Lyna's first name
    /// </summary>
    public static readonly string NAME_LYNA = "Lyna";
    /// <summary>
    /// Mai's first name
    /// </summary>
    public static readonly string NAME_MAI = "Mai";
    /// <summary>
    /// Meepso's name
    /// </summary>
    public static readonly string NAME_MEEPSO = "Meepso";
    /// <summary>
    /// Mona's first name
    /// </summary>
    public static readonly string NAME_MONA = "Mona";
    /// <summary>
    /// Nache's name
    /// </summary>
    public static readonly string NAME_NACHE = "Nache";
    /// <summary>
    /// Nicolette's first name
    /// </summary>
    public static readonly string NAME_NICOLETTE = "Nicolette";
    /// <summary>
    /// Olive's nickname
    /// </summary>
    public static readonly string NAME_OLIVE = "Olive";
    /// <summary>
    /// Rukki's name
    /// </summary>
    public static readonly string NAME_RUKKI = "Rukki";
    /// <summary>
    /// Shay's first name
    /// </summary>
    public static readonly string NAME_SHAY = "Shay";
    /// <summary>
    /// Tavar's first name
    /// </summary>
    public static readonly string NAME_TAVAR = "Tavar";
    /// <summary>
    /// Ted's first name
    /// </summary>
    public static readonly string NAME_TED = "Ted";
    /// <summary>
    /// Trudy's name
    /// </summary>
    public static readonly string NAME_TRUDY = "Trudy";
    /// <summary>
    /// Webster's first name
    /// </summary>
    public static readonly string NAME_WEBSTER = "Webster";
    /// <summary>
    /// Yvonne's first name
    /// </summary>
    public static readonly string NAME_YVONNE = "Yvonne";
    /// <summary>
    /// Anatol Dominczyk's full name
    /// </summary>
    public static readonly string FULL_NAME_ANATOL = "Anatol Dominczyk";
    /// <summary>
    /// Ariella Vini'zam's full name
    /// </summary>
    public static readonly string FULL_NAME_ARIELLA = "Ariella Vini'zam";
    /// <summary>
    /// Bargette Challador's full name
    /// </summary>
    public static readonly string FULL_NAME_BARGETTE = "Bargette Challador";
    /// <summary>
    /// Basu's full name
    /// </summary>
    public static readonly string FULL_NAME_BASU = "Basu";
    /// <summary>
    /// Calista Rydigarn's full name
    /// </summary>
    public static readonly string FULL_NAME_CALISTA = "Calista Rydigarn";
    /// <summary>
    /// Delilah Youngfoot's full name
    /// </summary>
    public static readonly string FULL_NAME_DELILAH = "Delilah Youngfoot";
    /// <summary>
    /// Diaochan's full name
    /// </summary>
    public static readonly string FULL_NAME_DIAOCHAN = "Diaochan";
    /// <summary>
    /// Felix Isheim's full name
    /// </summary>
    public static readonly string FULL_NAME_FELIX = "Felix Isheim";
    /// <summary>
    /// Fleurbeau III's official title
    /// </summary>
    public static readonly string FULL_NAME_FLEURBEAU = "Fleurbeau III";
    /// <summary>
    /// Gibb Truehart's full name
    /// </summary>
    public static readonly string FULL_NAME_GIBB = "Gibb Truehart";
    /// <summary>
    /// Gika Dilwitt's full name
    /// </summary>
    public static readonly string FULL_NAME_GIKA = "Gika Dilwitt";
    /// <summary>
    /// Harbo Bravefoot's full name
    /// </summary>
    public static readonly string FULL_NAME_HARBO = "Harbo Bravefoot";
    /// <summary>
    /// Heiji Fujiwara's full name
    /// </summary>
    public static readonly string FULL_NAME_HEIJI = "Heiji Fujiwara";
    /// <summary>
    /// Khadijah bint Ismail's full name
    /// </summary>
    public static readonly string FULL_NAME_KHADIJAH = "Khadijah bint Ismail";
    /// <summary>
    /// Kila's full name
    /// </summary>
    public static readonly string FULL_NAME_KILA = "Kila";
    /// <summary>
    /// Kilroy Wilde's full name
    /// </summary>
    public static readonly string FULL_NAME_KILROY = "Kilroy Wilde";
    /// <summary>
    /// Korus Wynar's full name
    /// </summary>
    public static readonly string FULL_NAME_KORUS = "Korus Wynar";
    /// <summary>
    /// Lah'zaar Twing'von's full name
    /// </summary>
    public static readonly string FULL_NAME_LAHZAAR = "Lah'zaar Twing'von";
    /// <summary>
    /// Lyna Woolsey's full name
    /// </summary>
    public static readonly string FULL_NAME_LYNA = "Lyna Woolsey";
    /// <summary>
    /// Mai Fujiwara's full name
    /// </summary>
    public static readonly string FULL_NAME_MAI = "Mai Fujiwara";
    /// <summary>
    /// Meepso's full name
    /// </summary>
    public static readonly string FULL_NAME_MEEPSO = "Meepso";
    /// <summary>
    /// Mona Harleigh's full name
    /// </summary>
    public static readonly string FULL_NAME_MONA = "Mona Harleigh";
    /// <summary>
    /// Nache's full name
    /// </summary>
    public static readonly string FULL_NAME_NACHE = "Nache";
    /// <summary>
    /// Nicolette Willoughway's full name
    /// </summary>
    public static readonly string FULL_NAME_NICOLETTE = "Nicolette Willoughway";
    /// <summary>
    /// Olivia (Olive) Mersey's full name
    /// </summary>
    public static readonly string FULL_NAME_OLIVE = "Olivia Mersey";
    /// <summary>
    /// Rukki's full name
    /// </summary>
    public static readonly string FULL_NAME_RUKKI = "Rukki";
    /// <summary>
    /// Shay Ringwald's full name
    /// </summary>
    public static readonly string FULL_NAME_SHAY = "Shay Ringwald";
    /// <summary>
    /// Tavar Lekuton's full name
    /// </summary>
    public static readonly string FULL_NAME_TAVAR = "Tavar Lekuton";
    /// <summary>
    /// Ted Powell's full name
    /// </summary>
    public static readonly string FULL_NAME_TED = "Ted Powell";
    /// <summary>
    /// Trudy's full name
    /// </summary>
    public static readonly string FULL_NAME_TRUDY = "Trudy";
    /// <summary>
    /// Sir Webster Fitzgerald's official title
    /// </summary>
    public static readonly string FULL_NAME_WEBSTER = "Sir Webster Fitzgerald";
    /// <summary>
    /// Yvonne Silang's full name
    /// </summary>
    public static readonly string FULL_NAME_YVONNE = "Yvonne Silang";
    /// <summary>
    /// Exemplar personality name string
    /// </summary>
    public static readonly string EXEMPLAR = "Exemplar";
    /// <summary>
    /// Perfectionist personality name string
    /// </summary>
    public static readonly string PERFECTIONIST = "Perfectionist";
    /// <summary>
    /// Disciplinarian personality name string
    /// </summary>
    public static readonly string DISCIPLINARIAN = "Disciplinarian";
    /// <summary>
    /// Cutthroat personality name string
    /// </summary>
    public static readonly string CUTTHROAT = "Cutthroat";
    /// <summary>
    /// Erudite personality name string
    /// </summary>
    public static readonly string ERUDITE = "Erudite";
    /// <summary>
    /// Eccentric personality name string
    /// </summary>
    public static readonly string ECCENTRIC = "Eccentric";
    /// <summary>
    /// Hermit personality name string
    /// </summary>
    public static readonly string HERMIT = "Hermit";
    /// <summary>
    /// Savant personality name string
    /// </summary>
    public static readonly string SAVANT = "Savant";
    /// <summary>
    /// Valiant personality name string
    /// </summary>
    public static readonly string VALIANT = "Valiant";
    /// <summary>
    /// Hippie personality name string
    /// </summary>
    public static readonly string HIPPIE = "Hippie";
    /// <summary>
    /// Hustler personality name string
    /// </summary>
    public static readonly string HUSTLER = "Hustler";
    /// <summary>
    /// Anarchist personality name string
    /// </summary>
    public static readonly string ANARCHIST = "Anarchist";
    /// <summary>
    /// Protégé personality name string
    /// </summary>
    public static readonly string PROTEGE = "Protégé";
    /// <summary>
    /// Wallflower personality name string
    /// </summary>
    public static readonly string WALLFLOWER = "Wallflower";
    /// <summary>
    /// Schemer persnality name string
    /// </summary>
    public static readonly string SCHEMER = "Schemer";
    /// <summary>
    /// Quixotic personality name string
    /// </summary>
    public static readonly string QUIXOTIC = "Quixotic";
    /// <summary>
    /// Steadfast personality name string
    /// </summary>
    public static readonly string STEADFAST = "Steadfast";
    /// <summary>
    /// Entertainer personality name string
    /// </summary>
    public static readonly string ENTERTAINER = "Entertainer";
    /// <summary>
    /// Muscle-minded personality name string
    /// </summary>
    public static readonly string MUSCLE_MINDED = "Muscle-minded";
    /// <summary>
    /// Warhawk personality name string
    /// </summary>
    public static readonly string WARHAWK = "Warhawk";
    /// <summary>
    /// Stoic personality name string
    /// </summary>
    public static readonly string STOIC = "Stoic";
    /// <summary>
    /// Idealist personality name string
    /// </summary>
    public static readonly string IDEALIST = "Idealist";
    /// <summary>
    /// Trooper personality name string
    /// </summary>
    public static readonly string TROOPER = "Trooper";
    /// <summary>
    /// Uptight personality name string
    /// </summary>
    public static readonly string UPTIGHT = "Uptight";
    /// <summary>
    /// Chivalric personality name string
    /// </summary>
    public static readonly string CHIVALRIC = "Chivalric";
    /// <summary>
    /// Joker personality name string
    /// </summary>
    public static readonly string JOKER = "Joker";
    /// <summary>
    /// Brute personality name string
    /// </summary>
    public static readonly string BRUTE = "Brute";
    /// <summary>
    /// Killjoy personality name string
    /// </summary>
    public static readonly string KILLJOY = "Killjoy";
    /// <summary>
    /// Darling personality name string
    /// </summary>
    public static readonly string DARLING = "Darling";
    /// <summary>
    /// Lecherous personality name string
    /// </summary>
    public static readonly string LECHEROUS = "Lecherous";
    /// <summary>
    /// Loner personality name string
    /// </summary>
    public static readonly string LONER = "Loner";
    /// <summary>
    /// Slacker personality name string
    /// </summary>
    public static readonly string SLACKER = "Slacker";
}

// list of all components in the game; represent
// resistances and weaknesses to elements and physical
// attacks
public enum Comp
{
    Slash,
    Bludgeon,
    Pierce,
    Sonic,
    Force,
    Fire,
    Ice,
    Lightning,
    Wind,
    Water,
    Earth,
    Acid,
    Dark,
    Light,
    Biologic,
    Necrotic,
    Psychic,
    None
}

public enum EquipType
{
    Clothing,
    LightArmor,
    HeavyArmor,
    Robe,
    Sword,
    Axe,
    Spear,
    Dagger,
    Hammer,
    Greatsword,
    Staff,
    Bow,
    Crossbow,
    Shuriken,
    Whip,
    Katana,
    Club,
    Ball,
    Claw,
    Arrow,
    Bolt,
    Shield,
    Buckler,
    Horn,
    Lute,
    Harp,
    Trinket
}

public enum ItemType
{
    Consumable,
    Equipment,
    KeyItem,
    Nonconsumable
}

public enum EquipRegion
{
    Head,
    UpperArmor,
    LowerArmor,
    LeftHand,
    RightHand,
    Trinket
}

public enum InitialSelected
{
    Engage,
    LineUp,
    Brawl,
    Retreat
}

public enum Selected
{
    Inventory,
    Equipment,
    Jobs,
    LineUp,
    Skills,
    Status,
    Misc,
    QuickSave
}

public enum ChooseState
{
    SelectMenu,
    SelectCharacter
}

public enum Menu
{
    MainMenu,
    Inventory,
    Equipment,
    Jobs,
    Skills,
    Status,
    // Journal,
    LineUp,
    Misc,
    QuickSave,
}

// used for the AdvModify() method
public enum Operation
{
    More,
    Less
}

public enum PersonalityTraits
{
    Openness,
    Conscientiousness,
    Extraversion,
    Agreeableness,
    Neuroticism
}
