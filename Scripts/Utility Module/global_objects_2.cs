/*******************************************************************************
* Mod Name
*******************************************************************************/
const int Adopted_Dalish = 0;
const int Small_Restoration = 1;
const int Dark_Time = 2;
const int Enigma = 3;
const int Lealion = 4;
const int Party_Recruiting = 5;
const int Raina = 6;
const int Return_to_KW = 7;
const int Tevinter_Warden = 8;
const int Warden_Women = 9;
const int Main_Story = 10;
const int Sapphos_Daughter = 11;
const int Lady_Orand = 12;

/*******************************************************************************
* Map Tag name
*******************************************************************************/
const string Party_Camp_1 = "cam100ar_camp_plains";
const string CORE_RecruitCenter = "mod_recruit_center";
const string RTKW_Korcari = "korcariwilds";
const string TW_Lothering = "lot110ar_chantry";
const string TW_riverton  = "sec200ar_riverton";
const string Enigma_area  = "enigma_area1";

/*******************************************************************************
* Error Message
*******************************************************************************/
const string Msg_SR       = "Follower not found, please install the mod 'Small Restoration' on NexusMod.";
const string Msg_Ado      = "Follower not found, please install the mod 'Adopted Dalish' on NexusMod.";
const string Msg_DarkTime = "Follower not found, please install the mod 'Dark Time Act 1' on NexusMod.";
const string Msg_Enigma   = "Follower not found, please install the mod 'Enigma' on NexusMod.";
const string Msg_Lealion  = "Follower not found, please install the mod 'Lealion & Legion' on NexusMod.";
const string Msg_PRecruit = "Follower not found, please install the mod 'Party Recruiting' on NexusMod.";
const string Msg_Raina    = "Follower not found, please install the mod 'Sappho's Daughter' on NexusMod.";
const string Msg_RTKW     = "Follower not found, please install the mod 'Return to Korcari wild' on NexusMod.";
const string Msg_TWarden  = "Follower not found, please install the mod 'Tevinter Warden' on NexusMod.";
const string Msg_WWoman   = "Follower not found, please install the mod 'Warden's Women' on NexusMod.";

/*******************************************************************************
* Global
*******************************************************************************/

const int Custom_Class = 997;
const string PlotType_Party = "Party";
const string PlotType_Camp  = "Camp";

/*******************************************************************************
* FOLLOWERS -- "Core Story"
*******************************************************************************/
const string GEN_FL_Alistair = "gen00fl_alistair";
const string GEN_FL_Dog = "gen00fl_dog";
const string GEN_FL_Leliana = "gen00fl_leliana";
const string GEN_FL_Loghain = "gen00fl_loghain";
const string GEN_FL_Morrigan = "gen00fl_morrigan";

const string GEN_FL_Oghren = "gen00fl_oghren";
const string GEN_FL_Shale = "gen00fl_shale";
const string GEN_FL_Sten = "gen00fl_sten";
const string GEN_FL_Wynne = "gen00fl_wynne";
const string GEN_FL_Zervan = "gen00fl_zevran";


/*******************************************************************************
* FOLLOWERS -- "Core Story"
*******************************************************************************/
const string GEN_FL_Daveth = "pre100cr_daveth";
const string GEN_FL_Jory = "pre100cr_jory";
const string GEN_FL_Fenarel = "bed200cr_fenarel";
const string GEN_FL_Merrill = "bed200cr_merrill";

const resource R_Daveth  = R"pre100cr_daveth.utc";
const resource R_Jory    = R"pre100cr_jory.utc";
const resource R_Fenarel = R"bed200cr_fenarel.utc";
const resource R_Merrill = R"bed200cr_merrill.utc";

const string Agent_Daveth  = "agent_daveth";
const string Agent_Jory    = "agent_jory";
const string Agent_Fenarel = "agent_fenarel";
const string Agent_Merrill = "agent_merrill";

/*******************************************************************************
* FOLLOWERS -- "Small Restoration"
*******************************************************************************/
const string GEN_FL_Moira = "camp_bloodmage";

const resource R_Moira    = R"camp_bloodmage.utc";

const string Agent_Moira  = "agent_moira";

/*******************************************************************************
* FOLLOWERS -- "Lady Serenity"
*******************************************************************************/
const string GEN_FL_Serenity = "orand_saleserenitydao";
const string GEN_FL_Sylvan   = "se_boss_sylvan";

const resource R_Serenity    = R"orand_saleserenitydao.utc";
const resource R_Sylvan      = R"boss_sylvan.utc";

const string Agent_Serenity  = "agent_serenity";

/*******************************************************************************
* FOLLOWERS -- Mod "Adopted Dalish"
*******************************************************************************/
const string GEN_FL_Ilyana    = "ado_companion_ilyana";
const string GEN_FL_Senros    = "ado_companion_senros";
const string GEN_FL_Anaise    = "ado00fl_anaise";
const string GEN_FL_Dominique = "ado00fl_dominique";
const string GEN_FL_Merrilyla = "ado00fl_merrilyla";

const resource R_Anaise    = R"ado00fl_anaise.utc";
const resource R_Dominique = R"ado00fl_dominique.utc";
const resource R_Ilyana    = R"ado_companion_ilyana.utc";
const resource R_Merrilyla = R"ado00fl_merrilyla.utc";
const resource R_Senros    = R"ado_companion_senros.utc";

const string Agent_Anaise    = "agent_anaise";
const string Agent_Dominique = "agent_dominique";
const string Agent_Ilyana    = "agent_ilyana";
const string Agent_Merrilyla = "agent_merrilyla";
const string Agent_Senros    = "agent_senros";

/*******************************************************************************
* FOLLOWERS -- Mod "Sapphos Daughter"
*******************************************************************************/

const string GEN_FL_Gina  = "gin_hf_gina";

const resource R_Gina = R"gin_hf_gina.utc";

/*******************************************************************************
* FOLLOWERS -- Mod "Party Recruiting"
*******************************************************************************/

const string GEN_FL_Andrastalla = "party_andrastalla";
const string GEN_FL_Troga = "party_troga";
const string GEN_FL_Rikku_Templar = "party_rikku_templar";
const string GEN_FL_Duncan = "party_duncan";
const string GEN_FL_Cailan = "party_cailan";
const string GEN_FL_Anora = "party_anora";
const string GEN_FL_Flemeth = "party_flemeth";
const string GEN_FL_Arl_Eamon = "party_arl_eamon";
const string GEN_FL_LadyOfTheForest = "party_ladyoftheforest";

/*******************************************************************************
* FOLLOWERS -- Mod "Dark Time Act 1"
*******************************************************************************/
const string GEN_FL_Isaac    = "dt_custom_isaac";
const string GEN_FL_Miriam   = "dt_custom_miriam";
const string GEN_FL_Marukhan = "dt_test_marukhan";

const resource R_Marukhan    = R"dt_test_marukhan.utc";
const resource R_Isaac       = R"dt_custom_isaac.utc";
const resource R_Miriam      = R"dt_custom_miriam.utc";

const string Agent_Isaac     = "agent_isaac";
const string Agent_Miriam    = "agent_miriam";

/*******************************************************************************
* FOLLOWERS -- Mod "Tevinter Warden"
*******************************************************************************/
const string GEN_FL_Lanna    = "gen00fl_lanna";
const string GEN_FL_Marric   = "gen00fl_marric";
const string GEN_FL_Martin   = "gen00fl_martin";
const string GEN_FL_Willam   = "gen00fl_willam";

const resource R_Lanna   = R"gen00fl_lanna.utc";
const resource R_Marric  = R"gen00fl_marric.utc";
const resource R_Martin  = R"gen00fl_martin.utc";
const resource R_Willam  = R"gen00fl_willam.utc";

const string Agent_Lanna      = "agent_lanna";
const string Agent_Marric     = "agent_marric";
const string Agent_Martin     = "agent_martin";
const string Agent_Willam     = "agent_willam";


/*******************************************************************************
* FOLLOWERS -- Mod "Lealion and Legend"
*******************************************************************************/
const string GEN_FL_Lealion  = "gen00fl_lealion";
const string GEN_FL_Legion   = "gen00fl_legion";

/*******************************************************************************
* FOLLOWERS -- Mod "Enigma"
*******************************************************************************/
const string GEN_FL_Vekuul      = "enigma_hero3";
const string GEN_FL_Vishala     = "enigma_hero1";
const string GEN_FL_helperlady  = "enigma_helperlady";
const string GEN_FL_EnMerchant  = "enigma_merchant";
const string GEN_FL_RspMerchant = "wrk_respec_vendor_npc";
const string GEN_FL_HighDragon  = "enigma_highdragon";

const resource R_Vekuul         = R"enigma_hero3.utc";
const resource R_Vishala        = R"enigma_hero1.utc";
const resource R_helperlady     = R"enigma_helperlady.utc";
const resource R_HighDragon     = R"enigma_highdragon.utc";

const string Agent_Vekuul       = "agent_vekuul";
const string Agent_Vishala      = "agent_vishala";
const string Agent_helperlady   = "agent_helperlady";

/*******************************************************************************
* FOLLOWERS -- Mod "Warden's Women"
*******************************************************************************/
const string GEN_FL_Mithra      = "ndq_mithra";
const string GEN_FL_Elora       = "ndq_elora";

const resource R_Mithra         = R"ndq_mithra.utc";
const resource R_elora          = R"ndq_elora.utc";

const string Agent_Mithra       = "agent_mithra";
const string Agent_Elora        = "agent_elora";

/*******************************************************************************
* FOLLOWERS -- Mod "In search of Raina"
*******************************************************************************/
const string GEN_FL_Terra      = "terra";
const string GEN_FL_Raina      = "raina";
const string GEN_FL_Pride      = "sdt_pridedemon";

const resource R_Terra         = R"terra.utc";
const resource R_Raina         = R"raina_3.utc";
const resource R_PrideDemon    = R"enemy_pride.utc";

const string Agent_Terra       = "agent_terra";
const string Agent_Raina       = "agent_raina";

/*******************************************************************************
* FOLLOWERS -- Mod "Return to Korcari Wild"
*******************************************************************************/
const string GEN_FL_Ariane     = "party_zaf";
const string GEN_FL_Douglas    = "party_douglas";
const string GEN_FL_Kenneth    = "party_serken";
const string GEN_PL_Books      = "genip_book_pile_4";

const resource R_Douglas_books = R"genip_book_pile_4.utp";
const resource R_Ariane        = R"party_zaf.utc";
const resource R_Douglas       = R"party_douglas.utc";
const resource R_Serkenneth    = R"party_serken.utc";

const string Agent_Douglas     = "agent_douglas";
const string Agent_Kenneth     = "agent_kenneth";
const string Agent_Ariane      = "agent_ariane";