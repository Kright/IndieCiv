using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

using IndieCivCore;
using IndieCivCore.Resources;
using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQLoader : IDisposable
    {
        private bool                        mCustomRules    = false;
        private bool                        CustomMap { get; set; }
        private BinaryFormatter             mFormatter = null;

        public int NumPlayers = 0;

        private static List<BIQBuilding>    mBuildings      = null;
        private static List<BIQCitizen>     mCitizens       = null;
        private static List<BIQCulture>     mCultures       = null;
        private static List<BIQDifficulty>  mDifficulties   = null;
        private static List<BIQEra>         mEras           = null;
        private static List<BIQEspionage>   mEspionage      = null;
        private static List<BIQExperience>  mExperience     = null;
        private static List<BIQResource>    mResources      = null;

        private BinaryFormatter Formatter
        {
            get { return mFormatter; }
            set { mFormatter = value; }
        }

        public bool CustomRules
        {
            get { return mCustomRules; }
            set { mCustomRules = value;  }
        }

        #region Custom Rules Lists
        public List<BIQBuilding> Buildings
        {
            get { return mBuildings; }
            set { mBuildings = value;  }
        }
        public List<BIQCitizen> Citizens
        {
            get { return mCitizens; }
            set { mCitizens = value; }
        }
        public List<BIQCulture> Cultures
        {
            get { return mCultures; }
            set { mCultures = value; }
        }
        public List<BIQDifficulty> Difficulties
        {
            get { return mDifficulties; }
            set { mDifficulties = value; }
        }
        public List<BIQEra> Eras
        {
            get { return mEras; }
            set { mEras = value; }
        }
        public List<BIQEspionage> Espionage
        {
            get { return mEspionage; }
            set { mEspionage = value; }
        }
        public List<BIQExperience> Experience
        {
            get { return mExperience; }
            set { mExperience = value; }
        }
        public List<BIQResource> Resources
        {
            get { return mResources; }
            set { mResources = value; }
        }
        public List<BIQGovernment> Governments { get; set; }
        public List<BIQUnit> Units { get; set; }
        public List<BIQCivilization> Civilizations { get; set; }
        public List<BIQAdvance> Advances { get; set; }
        public List<BIQWorkerJob> WorkerJobs { get; set; }
        public List<BIQTerrain> Terrains { get; set; }
        public List<BIQWorldSize> WorldSizes { get; set; }
        public List<BIQFlavour> Flavours { get; set; }
        public List<BIQWorldCharacteristics> WorldCharacteristics { get; set; }
        public List<BIQContinent> Continents { get; set; }
        public List<BIQStartLocation> StartLocations { get; set; }
        public List<BIQCity> Cities { get; set; }
        public List<BIQGameUnit> GameUnits { get; set; }
        public List<BIQGameColony> GameColonies { get; set; }
        public List<BIQGame> Game { get; set; }
        public List<BIQLead> Lead { get; set; }
        #endregion

        public void Dispose()
        {
        }

        public BIQLoader ()
        {
            CustomMap = false;
        }

        public static BIQLoader Create()
        {
            return new BIQLoader();
        }

        #region Main Load Function
        public bool Load( string fileName )
        {
            using ( FileStream stream = File.OpenRead( fileName ) )
            {
                mFormatter = new BinaryFormatter( stream );

                if ( this.LoadHeader() == false )
                    return false;

                CustomRules = false;
                string NextSection = Formatter.ReadString( 4 );
                if ( NextSection.Contains( "BLDG" ) == true )
                {
                    CustomRules = true;

                    this.LoadBuildings();
                    this.LoadCitizens();
                    this.LoadCulture();
                    this.LoadDifficulty();
                    this.LoadEra();
                    this.LoadEspionage();
                    this.LoadExperience();
                    this.LoadResources();
                    this.LoadGovernments();
                    this.LoadGeneral();
                    this.LoadUnits();
                    this.LoadCivilizations();
                    this.LoadAdvances();
                    this.LoadWorkerJobs();
                    this.LoadTerrain();
                    this.LoadWorldSizes();
                    this.LoadFlavors();

                    NextSection = Formatter.ReadString( 4 );
                }
                if ( NextSection.Contains( "WCHR" ) == true )
                {
                    CustomMap = true;

                    this.LoadWorldCharacteristics();
                    this.LoadMap();

                    this.LoadContinents();
                    this.LoadStartLocations();

                    this.LoadCities();

                    this.LoadGameUnits();
                    this.LoadColonies();

                    NextSection = Formatter.ReadString( 4 );
                }
                if ( NextSection.Contains( "GAME" ) == true )
                {
                    this.LoadGame();

                    NextSection = Formatter.ReadString(4);
                }
                if (NextSection.Contains("LEAD") == true)
                {
                    this.LoadLead();

                    NextSection = Formatter.ReadString(4);
                }
				if ( Formatter.EOF() == true )
				{
				}
            }
            
            return true;
        }
        #endregion

        public bool Import() {
            ImportGeneral();
            ImportAdvances();
            //ImportData<BIQCivilization>(this.Civilizations);
            ImportCivilizations();
            ImportResources();

            ImportUnits();

            ImportData<BIQResource>(this.Resources);

            ImportWorldMap();
            ImportStartLocations();

            MapManager.Current.SetReliefTextures();

            ImportGame();
            ImportPlayers();

            return true;
        }

        private void ImportGeneral() { 
            IndieCivCore.Resources.DataGeneral.BorderExpansionMultiplier = BIQGeneral.BorderExpansionMultiplier;
            IndieCivCore.Resources.DataGeneral.BorderFactor = BIQGeneral.BorderFactor;
            IndieCivCore.Resources.DataGeneral.FoodPerCitizen = BIQGeneral.FoodPerCitizen;
            IndieCivCore.Resources.DataGeneral.MinLevel1CitySize = BIQGeneral.MinLevel1CitySize;
            IndieCivCore.Resources.DataGeneral.MinLevel2CitySize = BIQGeneral.MinLevel2CitySize;
        }

        private void ImportData<T>(List<T> List) {
            foreach ( T item in List ) {
                //item.Import();
            }
        }

        private void ImportAdvances() {
            foreach (BIQAdvance item in this.Advances) {
                item.Import();
            }
        }

        private void ImportCivilizations() {
            foreach (BIQCivilization item in this.Civilizations) {
                item.Import();
            }
        }

        private void ImportUnits() {
            foreach (BIQUnit item in this.Units) {
                if (item.OtherStrategy != -1) {
                    UnitData UnitData = ResourceInterface.UnitData[item.OtherStrategy];
                    UnitData.AIStrategies = UnitData.AIStrategies | item.AIStrategy;

                }
                else {
                    List<string> searchPaths = new List<string>();
                    searchPaths.Add(@"D:\Program Files (x86)\Firaxis Games\Civilization III Complete\Art\Units");
                    searchPaths.Add(@"D:\Program Files (x86)\Firaxis Games\Civilization III Complete\civ3PTW\Art\Units");
                    searchPaths.Add(@"D:\Program Files (x86)\Firaxis Games\Civilization III Complete\Conquests\Art\Units");
                    item.Import(searchPaths);
                }
                
            }
        }


        private void ImportResources() {
            foreach (BIQResource item in this.Resources) {
                item.Import();
            }
        }

        private void ImportWorldMap() {
            BIQMap.Import();
        }
        private void ImportStartLocations() {
            foreach (BIQStartLocation sl in this.StartLocations) {
                sl.Import();
            }
        }

        private void ImportGame() {
            foreach (BIQGame item in this.Game) {
                item.Import(this);
            }

        }

        private void ImportPlayers() {
            foreach ( BIQLead lead in this.Lead ) {
                lead.Import();
            }
        }

        /*object LoadPropertyNames ( object obj, Type type, Dictionary<string, Tuple<DataType, Type, int>> propertyNames )
        {
            int iLoopCounter = -1;

            foreach ( KeyValuePair<string, Tuple<DataType, Type, int>> pair in propertyNames )
            {
                PropertyInfo property = type.GetProperty( pair.Key );

                if ( pair.Value.Item1 == DataType.Int )
                {
                    int iValue = Formatter.ReadInt32();

                    property.SetValue( obj, iValue, null );
                }
                else if ( pair.Value.Item1 == DataType.String )
                {
                    string sValue = Formatter.ReadString( pair.Value.Item3 );
                    property.SetValue( obj, sValue, null );
                }
                else if ( pair.Value.Item1 == DataType.LoopCounter )
                {
                    iLoopCounter = Formatter.ReadInt32();

                    property.SetValue( obj, iLoopCounter, null );
                }
                else if ( pair.Value.Item1 == DataType.List )
                {
                    object list = ( object ) property;

                    Type t = pair.Value.Item2;

                    //list = new List<Type>();

                   

                    MethodInfo add = property.PropertyType.GetMethod( "Add" );

                    //object n = property.GetValue(obj, null);
                    //add.Invoke ( n, )

                    //object s = (object)pair.Value.Item2;

                    for ( int i = 0; i < iLoopCounter; i++ )
                    {
                        object governmentsPerformance = Activator.CreateInstance( pair.Value.Item2 );

                        //s governmentsPerformance = new s();
                        governmentsPerformance = this.LoadPropertyNames( governmentsPerformance, governmentsPerformance.GetType(), governmentsPerformance.propertyNames );

                        //government.GovernmentsPerformance.Add( governmentsPerformance );

                        //property.Get
                        Object o = property.GetValue( obj, null );

                        add.Invoke( list, new [] { governmentsPerformance } );

                        
                    }
                }
            }

            return obj;
        }*/

        private void LoadLead()
        {
            NumPlayers = Formatter.ReadInt32();
            Lead = new List<BIQLead>();
            for (int i = 0; i < NumPlayers; i++)
            {
                BIQLead lead = new BIQLead();

                // Read the size
                Formatter.ReadInt32();
                lead.Load(Formatter);
                Lead.Add(lead);
            }
        }

        private void LoadGame()
        {
            int iNumGame = Formatter.ReadInt32();
            Game = new List<BIQGame>();
            for ( int i = 0; i < iNumGame; i++ )
            {
                BIQGame game = new BIQGame();

                // Read the size
                Formatter.ReadInt32();
                game.Load( Formatter );
                Game.Add( game );
            }
        }

        private void LoadColonies()
        {
            string NextSection = Formatter.ReadString( 4 );

            int iNumGameColonies = Formatter.ReadInt32();
            GameColonies = new List<BIQGameColony>();
            for ( int i = 0; i < iNumGameColonies; i++ )
            {
                BIQGameColony gameColony = new BIQGameColony();

                // Read the size
                Formatter.ReadInt32();
                gameColony.Load( Formatter );
                GameColonies.Add( gameColony );
            }
        }

        private void LoadGameUnits()
        {
            string NextSection = Formatter.ReadString( 4 );

            int iNumGameUnits = Formatter.ReadInt32();
            GameUnits = new List<BIQGameUnit>();
            for ( int i = 0; i < iNumGameUnits; i++ )
            {
                BIQGameUnit gameUnit = new BIQGameUnit();

                // Read the size
                Formatter.ReadInt32();
                gameUnit.Load( Formatter );
                GameUnits.Add( gameUnit );
            }
        }

        private void LoadCities()
        {
            string NextSection = Formatter.ReadString( 4 );

            int iNumCities = Formatter.ReadInt32();
            Cities = new List<BIQCity>();
            for ( int i = 0; i < iNumCities; i++ )
            {
                BIQCity city = new BIQCity();

                // Read the size
                Formatter.ReadInt32();
                city.Load( Formatter );
                Cities.Add( city );
            }
        }

        private void LoadStartLocations()
        {
            string NextSection = Formatter.ReadString( 4 );

            int iNumStartLocations = Formatter.ReadInt32();
            StartLocations = new List<BIQStartLocation>();
            for ( int i = 0; i < iNumStartLocations; i++ )
            {
                BIQStartLocation startLocation = new BIQStartLocation();

                // Read the size
                Formatter.ReadInt32();
                startLocation.Load( Formatter );
                StartLocations.Add( startLocation );
            }
        }

        private void LoadContinents()
        {
            string NextSection = Formatter.ReadString( 4 );

            int iNumContinents = Formatter.ReadInt32();
            Continents = new List<BIQContinent>();
            for ( int i = 0; i < iNumContinents; i++ )
            {
                BIQContinent continent = new BIQContinent();

                // Read the size
                Formatter.ReadInt32();
                continent.Load( Formatter );
                Continents.Add( continent );
            }
        }

        private void LoadMap()
        {
            string NextSection = Formatter.ReadString( 4 );
            // Num of maps
            Formatter.ReadInt32();
            // Size
            Formatter.ReadInt32();

            BIQMap.Load( Formatter );



        }

        private void LoadWorldCharacteristics()
        {
            WorldCharacteristics = new List<BIQWorldCharacteristics>();

            int iNumWorldCharacteristics = Formatter.ReadInt32();

            for ( int i = 0; i < iNumWorldCharacteristics; i++ )
            {
                BIQWorldCharacteristics worldCharacteristics = new BIQWorldCharacteristics();

                // Read the size
                Formatter.ReadInt32();
                worldCharacteristics.Load( Formatter );
                WorldCharacteristics.Add( worldCharacteristics );
            }
        }

        private void LoadFlavors()
        {
            Flavours = new List<BIQFlavour>();

            string NextSection = Formatter.ReadString( 4 );

            // Number of flavour groups(1)
            Formatter.ReadInt32();

            // Read the number of units
            int iNumFlavors = Formatter.ReadInt32();

            for ( int i = 0; i < iNumFlavors; i++ )
            {
                BIQFlavour flavour = new BIQFlavour();

                // Read the size
                //Formatter.ReadInt32();
                flavour.Load( Formatter );
                Flavours.Add( flavour );
            }
        }

        private void LoadWorldSizes()
        {
            WorldSizes = new List<BIQWorldSize>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumWorldSizes = Formatter.ReadInt32();

            for ( int i = 0; i < iNumWorldSizes; i++ )
            {
                BIQWorldSize worldSize = new BIQWorldSize();

                // Read the size
                Formatter.ReadInt32();
                worldSize.Load( Formatter );
                WorldSizes.Add( worldSize );
            }
        }

        private void LoadTerrain()
        {
            Terrains = new List<BIQTerrain>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumTerrain = Formatter.ReadInt32();

            for ( int i = 0; i < iNumTerrain; i++ )
            {
                BIQTerrain terrain = new BIQTerrain();

                // Read the size
                Formatter.ReadInt32();
                terrain.Load( Formatter );
                Terrains.Add( terrain );
            }
        }

        private void LoadWorkerJobs()
        {
            WorkerJobs = new List<BIQWorkerJob>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumWorkerJobs = Formatter.ReadInt32();

            for ( int i = 0; i < iNumWorkerJobs; i++ )
            {
                BIQWorkerJob workerJob = new BIQWorkerJob();

                // Read the size
                Formatter.ReadInt32();
                workerJob.Load( Formatter );
                WorkerJobs.Add( workerJob );
            }
        }

        private void LoadAdvances()
        {
            Advances = new List<BIQAdvance>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumAdvance = Formatter.ReadInt32();

            for ( int i = 0; i < iNumAdvance; i++ )
            {
                BIQAdvance advance = new BIQAdvance();

                // Read the size
                Formatter.ReadInt32();
                advance.Load( Formatter );
                Advances.Add( advance );
            }
        }

        private void LoadCivilizations()
        {
            Civilizations = new List<BIQCivilization>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumCivilizations = Formatter.ReadInt32();

            for ( int i = 0; i < iNumCivilizations; i++ )
            {
                BIQCivilization civilization = new BIQCivilization();

                // Read the size
                Formatter.ReadInt32();
                civilization.Load( Formatter );
                Civilizations.Add( civilization );
            }
        }

        private void LoadUnits()
        {
            Units = new List<BIQUnit>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of units
            int iNumUnits = Formatter.ReadInt32();

            for ( int i = 0; i < iNumUnits; i++ )
            {
                BIQUnit unit = new BIQUnit();

                // Read the size
                Formatter.ReadInt32();
                unit.Load( Formatter );
                Units.Add( unit );
            }
        }

        private void LoadGeneral()
        {
            string NextSection = Formatter.ReadString( 4 );
            // Num
            Formatter.ReadInt32();
            // Size
            Formatter.ReadInt32();
            BIQGeneral.Load(Formatter);
        }

        private void LoadGovernments()
        {
            Governments = new List<BIQGovernment>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of governments
            int iNumGovernments = Formatter.ReadInt32();

            for ( int i = 0; i < iNumGovernments; i++ )
            {
                BIQGovernment government = new BIQGovernment();

                // Read the size
                Formatter.ReadInt32();
                government.Load( Formatter );
                Governments.Add( government );
            }
        }

        private void LoadResources()
        {
            Resources = new List<BIQResource>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of resources
            int iNumResources = Formatter.ReadInt32();

            for ( int i = 0; i < iNumResources; i++ )
            {
                BIQResource resource = new BIQResource();

                // Read the size
                Formatter.ReadInt32();
                resource.Load( Formatter );
                //resource = ( BIQResource ) this.LoadPropertyNames( ( object ) resource, resource.GetType(), BIQResource.propertyNames );
                Resources.Add( resource );
            }
        }

        private void LoadExperience()
        {
            Experience = new List<BIQExperience>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of difficulties
            int iNumExperience = Formatter.ReadInt32();

            for ( int i = 0; i < iNumExperience; i++ )
            {
                BIQExperience experience = new BIQExperience();

                // Read the size
                Formatter.ReadInt32();
                experience.Load( Formatter );
                //experience = ( BIQExperience ) this.LoadPropertyNames( ( object ) experience, experience.GetType(), BIQExperience.propertyNames );
                Experience.Add( experience );
            }
        }

        private void LoadEspionage()
        {
            Espionage = new List<BIQEspionage>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of difficulties
            int iNumEspionage = Formatter.ReadInt32();

            for ( int i = 0; i < iNumEspionage; i++ )
            {
                BIQEspionage espionage = new BIQEspionage();

                // Read the size
                Formatter.ReadInt32();
                espionage.Load( Formatter );
                //espionage = ( BIQEspionage ) this.LoadPropertyNames( ( object ) espionage, espionage.GetType(), BIQEspionage.propertyNames );
                Espionage.Add( espionage );
            }
        }

        private void LoadEra()
        {
            Eras = new List<BIQEra>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of difficulties
            int iNumEras = Formatter.ReadInt32();

            for ( int i = 0; i < iNumEras; i++ )
            {
                BIQEra era = new BIQEra();

                // Read the size
                Formatter.ReadInt32();
                era.Load( Formatter );
                //era = ( BIQEra ) this.LoadPropertyNames( ( object ) era, era.GetType(), BIQEra.propertyNames );
                Eras.Add( era );
            }
        }

        private void LoadDifficulty()
        {
            Difficulties = new List<BIQDifficulty>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of difficulties
            int iNumDifficulties = Formatter.ReadInt32();

            for ( int i = 0; i < iNumDifficulties; i++ )
            {
                BIQDifficulty difficulty = new BIQDifficulty();

                // Read the size
                Formatter.ReadInt32();
                difficulty.Load( Formatter );
                //difficulty = ( BIQDifficulty ) this.LoadPropertyNames( ( object ) difficulty, difficulty.GetType(), BIQDifficulty.propertyNames );
                Difficulties.Add( difficulty );
            }
        }

        private void LoadCulture()
        {
            Cultures = new List<BIQCulture>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of cultures
            int iNumCultures = Formatter.ReadInt32();

            for ( int i = 0; i < iNumCultures; i++ )
            {
                BIQCulture culture = new BIQCulture();

                // Read the size
                Formatter.ReadInt32();
                culture.Load( Formatter );
                //culture = ( BIQCulture ) this.LoadPropertyNames( ( object ) culture, culture.GetType(), BIQCulture.propertyNames );
                Cultures.Add( culture );
            }
        }

        private void LoadCitizens()
        {
            Citizens = new List<BIQCitizen>();

            string NextSection = Formatter.ReadString( 4 );

            // Read the number of citizens
            int iNumCitizens = Formatter.ReadInt32();

            for ( int i = 0; i < iNumCitizens; i++ )
            {
                BIQCitizen citizen = new BIQCitizen();

                // Read the size
                Formatter.ReadInt32();
                citizen.Load( Formatter );
                //citizen = ( BIQCitizen ) this.LoadPropertyNames( ( object ) citizen, citizen.GetType(), BIQCitizen.propertyNames );
                Citizens.Add( citizen );
            }
        }

        private void LoadBuildings()
        {
            Buildings = new List<BIQBuilding>();

            // Read the number of buildings
            int iNumBuildings = Formatter.ReadInt32();

            for ( int i = 0; i < iNumBuildings; i++ )
            {
                BIQBuilding building = new BIQBuilding();

                // Read size
                Formatter.ReadInt32();

                building.Load( Formatter );
                //building = ( BIQBuilding ) this.LoadPropertyNames( ( object ) building, building.GetType(), BIQBuilding.propertyNames );
                Buildings.Add( building );
            }
            
        }

        private bool LoadHeader()
        {
            // Read BIQ type
            BIQHeader.Type = Formatter.ReadString(4);

            try
            {
                if ( BIQHeader.IsValid() == false )
                    throw new ApplicationException( string.Format( "BIQ file is either compressed or not a valid BIQ file: '{0}'.", BIQHeader.Type ) );
            }
            catch ( Exception e )
            {
                //Log.Core.WriteError( "Error reading BIQ: {0}", e is ApplicationException ? e.Message : Log.Exception( e ) );
                return false;
            }

            // Read BIQ version - VER#
            Formatter.ReadString( 4 );
            // Read number of headers - 1
            Formatter.ReadInt32();
            // Read header length
            Formatter.ReadInt32();
            // Read unknown
            Formatter.ReadInt32();
            // Read unknown
            Formatter.ReadInt32();
            // Read version
            BIQHeader.MajorVer = Formatter.ReadInt32();
            BIQHeader.MinorVer = Formatter.ReadInt32();
            // Read description
            BIQHeader.Description = Formatter.ReadString( (int)BIQHeader.BIQHeaderSizes.Description );
            // Read title
            BIQHeader.Title = Formatter.ReadString( ( int ) BIQHeader.BIQHeaderSizes.Title );

            return true;
        }
    }
}
