using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Configuration;
using FlowTestLibrary;

namespace FlowTestLibrary.Epanet
{
    class Epa
    {
        //public const string EPANETDLL = @"J:\HydraulicModel\Software\Epanet\Version2.2\epanet2.2_toolkit\epanet2.dll";
        public const string EPANETDLL = @"epanet2.dll";


        //** @file epanet2_enums.h

        /*
         ******************************************************************************
         Project:      OWA EPANET
         Version:      2.2
         Module:       epanet2_enums.h
         Description:  enumerations of symbolic constants used by the API functions
         Authors:      see AUTHORS
         Copyright:    see AUTHORS
         License:      see LICENSE
         Last Updated: 11/06/2019
         ******************************************************************************
        */


        // --- Define the EPANET toolkit constants

        /// Size Limts
        /**
        Limits on the size of character arrays used to store ID names
        and text messages.
        */
        //typedef enum {
        public const int EN_MAXID = 31;     //!< Max. # characters in ID name
          public const int EN_MAXMSG = 255;     //!< Max. # characters in message text
                                                //}
                                                //EN_SizeLimits;

        /// Node properties
        /**
These node properties are used with @ref EN_getnodevalue and @ref EN_setnodevalue.
Those marked as read only are computed values that can only be retrieved.
*/
        //typedef enum {
        public const int EN_ELEVATION = 0; //!< Elevation
        public const int EN_BASEDEMAND = 1; //!< Primary demand baseline value
        public const int EN_PATTERN = 2; //!< Primary demand time pattern index
        public const int EN_EMITTER = 3; //!< Emitter flow coefficient
        public const int EN_INITQUAL = 4; //!< Initial quality
        public const int EN_SOURCEQUAL = 5; //!< Quality source strength
        public const int EN_SOURCEPAT = 6; //!< Quality source pattern index
        public const int EN_SOURCETYPE = 7; //!< Quality source type (see @ref EN_SourceType)
        public const int EN_TANKLEVEL = 8; //!< Current computed tank water level (read only)
        public const int EN_DEMAND = 9; //!< Current computed demand (read only)
            public const int EN_HEAD = 10; //!< Current computed hydraulic head (read only)
            public const int EN_PRESSURE = 11; //!< Current computed pressure (read only)
            public const int EN_QUALITY = 12; //!< Current computed quality (read only)
            public const int EN_SOURCEMASS = 13; //!< Current computed quality source mass inflow (read only)
            public const int EN_INITVOLUME = 14; //!< Tank initial volume (read only)
            public const int EN_MIXMODEL = 15; //!< Tank mixing model (see @ref public const int EN_MixingModel)
            public const int EN_MIXZONEVOL = 16; //!< Tank mixing zone volume (read only)
            public const int EN_TANKDIAM = 17; //!< Tank diameter
            public const int EN_MINVOLUME = 18; //!< Tank minimum volume
            public const int EN_VOLCURVE = 19; //!< Tank volume curve index
            public const int EN_MINLEVEL = 20; //!< Tank minimum level
            public const int EN_MAXLEVEL = 21; //!< Tank maximum level
            public const int EN_MIXFRACTION = 22; //!< Tank mixing fraction
            public const int EN_TANK_KBULK = 23; //!< Tank bulk decay coefficient
            public const int EN_TANKVOLUME = 24; //!< Current computed tank volume (read only)
            public const int EN_MAXVOLUME = 25; //!< Tank maximum volume (read only)
            public const int EN_CANOVERFLOW = 26; //!< Tank can overflow (= 1) or not (= 0)
        public const int EN_DEMANDDEFICIT = 27; //!< Amount that full demand is reduced under PDA (read only)
        //}
        //EN_NodeProperty;

/// Link properties
/**
These link properties are used with @ref EN_getlinkvalue and @ref EN_setlinkvalue.
Those marked as read only are computed values that can only be retrieved.
*/
//typedef enum {
            public const int EN_DIAMETER = 0; //!< Pipe/valve diameter
            public const int EN_LENGTH = 1; //!< Pipe length
            public const int EN_ROUGHNESS = 2; //!< Pipe roughness coefficient
            public const int EN_MINORLOSS = 3; //!< Pipe/valve minor loss coefficient
            public const int EN_INITSTATUS = 4; //!< Initial status (see @ref public const int EN_LinkStatusType)
            public const int EN_INITSETTING = 5; //!< Initial pump speed or valve setting
            public const int EN_KBULK = 6; //!< Bulk chemical reaction coefficient
            public const int EN_KWALL = 7; //!< Pipe wall chemical reaction coefficient
            public const int EN_FLOW = 8; //!< Current computed flow rate (read only)
            public const int EN_VELOCITY = 9; //!< Current computed flow velocity (read only)
            public const int EN_HEADLOSS = 10; //!< Current computed head loss (read only)
            public const int EN_STATUS = 11; //!< Current link status (see @ref public const int EN_LinkStatusType)
            public const int EN_SETTING = 12; //!< Current link setting
            public const int EN_ENERGY = 13; //!< Current computed pump energy usage (read only)
            public const int EN_LINKQUAL = 14; //!< Current computed link quality (read only)
            public const int EN_LINKPATTERN = 15; //!< Pump speed time pattern index
            public const int EN_PUMP_STATE = 16; //!< Current computed pump state (read only) (see @ref public const int EN_PumpStateType)
            public const int EN_PUMP_EFFIC = 17; //!< Current computed pump efficiency (read only)
            public const int EN_PUMP_POWER = 18; //!< Pump constant power rating
            public const int EN_PUMP_HCURVE = 19; //!< Pump head v. flow curve index
            public const int EN_PUMP_ECURVE = 20; //!< Pump efficiency v. flow curve index
            public const int EN_PUMP_ECOST = 21; //!< Pump average energy price
            public const int EN_PUMP_EPAT = 22;  //!< Pump energy price time pattern index
        //}
        //EN_LinkProperty;

/// Time parameters
/**
These time-related options are used with @ref EN_gettimeparam and@ref EN_settimeparam.
All times are expressed in seconds The parameters marked as read only are
computed values that can only be retrieved.
*/
//typedef enum {
            public const int EN_DURATION = 0; //!< Total simulation duration
            public const int EN_HYDSTEP = 1; //!< Hydraulic time step
            public const int EN_QUALSTEP = 2; //!< Water quality time step
            public const int EN_PATTERNSTEP = 3; //!< Time pattern period
            public const int EN_PATTERNSTART = 4; //!< Time when time patterns begin
            public const int EN_REPORTSTEP = 5; //!< Reporting time step
            public const int EN_REPORTSTART = 6; //!< Time when reporting starts
            public const int EN_RULESTEP = 7; //!< Rule-based control evaluation time step
            public const int EN_STATISTIC = 8; //!< Reporting statistic code (see @ref public const int EN_StatisticType)
            public const int EN_PERIODS = 9; //!< Number of reporting time periods (read only)
            public const int EN_STARTTIME = 10; //!< Simulation starting time of day
            public const int EN_HTIME = 11; //!< Elapsed time of current hydraulic solution (read only)
            public const int EN_QTIME = 12; //!< Elapsed time of current quality solution (read only)
            public const int EN_HALTFLAG = 13; //!< Flag indicating if the simulation was halted (read only)
            public const int EN_NEXTEVENT = 14; //!< Shortest time until a tank becomes empty or full (read only)
        public const int EN_NEXTEVENTTANK = 15;  //!< Index of tank with shortest time to become empty or full (read only)
        //}
        //EN_TimeParameter;

/// Analysis convergence statistics
/**
These statistics report the convergence criteria for the most current hydraulic analysis
and the cumulative water quality mass balance error at the current simulation time. They
can be retrieved with @ref EN_getstatistic.
*/
//typedef enum {
            public const int EN_ITERATIONS = 0; //!< Number of hydraulic iterations taken
            public const int EN_RELATIVEERROR = 1; //!< Sum of link flow changes / sum of link flows
            public const int EN_MAXHEADERROR = 2; //!< Largest head loss error for links
            public const int EN_MAXFLOWCHANGE = 3; //!< Largest flow change in links
            public const int EN_MASSBALANCE = 4; //!< Cumulative water quality mass balance ratio
            public const int EN_DEFICIENTNODES = 5; //!< Number of pressure deficient nodes
            public const int EN_DEMANDREDUCTION = 6;  //!< % demand reduction at pressure deficient nodes
        //}
        //EN_AnalysisStatistic;

/// Types of network objects
/**
The types of objects that comprise a network model.
*/
//typedef enum {
            public const int EN_NODE = 0; //!< Nodes
            public const int EN_LINK = 1; //!< Links
            public const int EN_TIMEPAT = 2; //!< Time patterns
            public const int EN_CURVE = 3; //!< Data curves
            public const int EN_CONTROL = 4; //!< Simple controls
            public const int EN_RULE = 5;   //!< Control rules
        //}
        //EN_ObjectType;

/// Types of objects to count
/**
These options tell @ref EN_getcount which type of object to count.
*/
//typedef enum {
            public const int EN_NODECOUNT = 0; //!< Number of nodes (junctions + tanks + reservoirs)
            public const int EN_TANKCOUNT = 1; //!< Number of tanks and reservoirs
            public const int EN_LINKCOUNT = 2; //!< Number of links (pipes + pumps + valves)
            public const int EN_PATCOUNT = 3; //!< Number of time patterns
            public const int EN_CURVECOUNT = 4; //!< Number of data curves
            public const int EN_CONTROLCOUNT = 5; //!< Number of simple controls
        public const int EN_RULECOUNT = 6;   //!< Number of rule-based controls
        //}
        //EN_CountType;

/// Node Types
/**
These are the different types of nodes that can be returned by calling @ref EN_getnodetype.
*/
//typedef enum {
            public const int EN_JUNCTION = 0; //!< Junction node
            public const int EN_RESERVOIR = 1; //!< Reservoir node
        public const int EN_TANK = 2;    //!< Storage tank node
        //}
        //EN_NodeType;

/// Link types
/**
These are the different types of links that can be returned by calling @ref EN_getlinktype.
*/
//typedef enum {
            public const int EN_CVPIPE = 0; //!< Pipe with check valve
            public const int EN_PIPE = 1; //!< Pipe
            public const int EN_PUMP = 2; //!< Pump
            public const int EN_PRV = 3; //!< Pressure reducing valve
            public const int EN_PSV = 4; //!< Pressure sustaining valve
            public const int EN_PBV = 5; //!< Pressure breaker valve
            public const int EN_FCV = 6; //!< Flow control valve
            public const int EN_TCV = 7; //!< Throttle control valve
        public const int EN_GPV = 8;   //!< General purpose valve
                                       //}
                                       //EN_LinkType;

        /// Link status
        /**
One of these values is returned when @ref EN_getlinkvalue is used to retrieve a link's
initial status ( \b EN_INITSTATUS ) or its current status ( \b EN_STATUS ). These options are
also used with @ref EN_setlinkvalue to set values for these same properties.
*/
        //typedef enum {
        public const int EN_CLOSED = 0;
        public const int EN_OPEN = 1;
        //}
        //EN_LinkStatusType;

/// Pump states
/**
One of these codes is returned when @ref EN_getlinkvalue is used to retrieve a pump's
current operating state ( \b EN_PUMP_STATE ). \b EN_PUMP_XHEAD indicates that the pump has been
shut down because it is being asked to deliver more than its shutoff head. \b EN_PUMP_XFLOW
indicates that the pump is being asked to deliver more than its maximum flow.
*/
//typedef enum {
            public const int EN_PUMP_XHEAD = 0; //!< Pump closed - cannot supply head
            public const int EN_PUMP_CLOSED = 2; //!< Pump closed
            public const int EN_PUMP_OPEN = 3; //!< Pump open
        public const int EN_PUMP_XFLOW = 5;   //!< Pump open - cannot supply flow
        //}
        //EN_PumpStateType;

/// Types of water quality analyses
/**
These are the different types of water quality analyses that EPANET can run. They
are used with @ref EN_getqualinfo, @ref EN_getqualtype, and @ref EN_setqualtype.
*/
//typedef enum {
            public const int EN_NONE = 0; //!< No quality analysis
            public const int EN_CHEM = 1; //!< Chemical fate and transport
            public const int EN_AGE = 2; //!< Water age analysis
        public const int EN_TRACE = 3;    //!< Source tracing analysis
        //}
        //EN_QualityType;

/// Water quality source types
/**
These are the different types of external water quality sources that can be assigned
to a node's \b EN_SOURCETYPE property as used by @ref EN_getnodevalue and @ref EN_setnodevalue.
*/
//typedef enum {
            public const int EN_CONCEN = 0; //!< Sets the concentration of external inflow entering a node
            public const int EN_MASS = 1; //!< Injects a given mass/minute into a node
            public const int EN_SETPOINT = 2; //!< Sets the concentration leaving a node to a given value
        public const int EN_FLOWPACED = 3;    //!< Adds a given value to the concentration leaving a node
        //}
        //EN_SourceType;

/// Head loss formulas
/**
The available choices for the \b EN_HEADLOSSFORM option in @ref EN_getoption and
@ref EN_setoption. They are also used for the head loss type argument in @ref EN_init.
Each head loss formula uses a different type of roughness coefficient ( \b EN_ROUGHNESS )
that can be set with @ref EN_setlinkvalue.
*/
//typedef enum {
            public const int EN_HW = 0; //!< Hazen-Williams
            public const int EN_DW = 1; //!< Darcy-Weisbach
        public const int EN_CM = 2;    //!< Chezy-Manning
        //}
        //EN_HeadLossType;

/// Flow units
/**
These choices for flow units are used with @ref EN_getflowunits and @ref EN_setflowunits.
They are also used for the flow units type argument in @ref EN_init. If flow units are
expressed in US Customary units ( \b EN_CFS through \b EN_AFD ) then all other quantities are
in US Customary units. Otherwise they are in metric units.
*/
//typedef enum {
            public const int EN_CFS = 0; //!< Cubic feet per second
            public const int EN_GPM = 1; //!< Gallons per minute
            public const int EN_MGD = 2; //!< Million gallons per day
            public const int EN_IMGD = 3; //!< Imperial million gallons per day
            public const int EN_AFD = 4; //!< Acre-feet per day
            public const int EN_LPS = 5; //!< Liters per second
            public const int EN_LPM = 6; //!< Liters per minute
            public const int EN_MLD = 7; //!< Million liters per day
            public const int EN_CMH = 8; //!< Cubic meters per hour
        public const int EN_CMD = 9;    //!< Cubic meters per day
        //}
        //EN_FlowUnits;

/// Demand models
/**
These choices for modeling consumer demands are used with @ref EN_getdemandmodel
and @ref EN_setdemandmodel.

A demand driven analysis requires that a junction's full demand be supplied
in each time period independent of how much pressure is available. A pressure
driven analysis makes demand be a power function of pressure, up to the point
where the full demand is met.
*/
//typedef enum {
            public const int EN_DDA = 0; //!< Demand driven analysis
        public const int EN_PDA = 1;    //!< Pressure driven analysis
        //}
        //EN_DemandModel;

/// Simulation options
/**
These constants identify the hydraulic and water quality simulation options
that are applied on a network-wide basis. They are accessed using the
@ref EN_getoption and @ref EN_setoption functions.
*/
//typedef enum {
            public const int EN_TRIALS = 0; //!< Maximum trials allowed for hydraulic convergence
            public const int EN_ACCURACY = 1; //!< Total normalized flow change for hydraulic convergence
            public const int EN_TOLERANCE = 2; //!< Water quality tolerance
            public const int EN_EMITEXPON = 3; //!< Exponent in emitter discharge formula
            public const int EN_DEMANDMULT = 4; //!< Global demand multiplier
            public const int EN_HEADERROR = 5; //!< Maximum head loss error for hydraulic convergence
            public const int EN_FLOWCHANGE = 6; //!< Maximum flow change for hydraulic convergence
            public const int EN_HEADLOSSFORM = 7; //!< Head loss formula (see @ref public const int EN_HeadLossType)
            public const int EN_GLOBALEFFIC = 8; //!< Global pump efficiency (percent)
            public const int EN_GLOBALPRICE = 9; //!< Global energy price per KWH
            public const int EN_GLOBALPATTERN = 10; //!< Index of a global energy price pattern
            public const int EN_DEMANDCHARGE = 11; //!< Energy charge per max. KW usage
            public const int EN_SP_GRAVITY = 12; //!< Specific gravity
            public const int EN_SP_VISCOS = 13; //!< Specific viscosity (relative to water at 20 deg C)
            public const int EN_UNBALANCED = 14; //!< Extra trials allowed if hydraulics don't converge
            public const int EN_CHECKFREQ = 15; //!< Frequency of hydraulic status checks
            public const int EN_MAXCHECK = 16; //!< Maximum trials for status checking
            public const int EN_DAMPLIMIT = 17; //!< Accuracy level where solution damping begins
            public const int EN_SP_DIFFUS = 18; //!< Specific diffusivity (relative to chlorine at 20 deg C)
            public const int EN_BULKORDER = 19; //!< Bulk water reaction order for pipes
            public const int EN_WALLORDER = 20; //!< Wall reaction order for pipes (either 0 or 1)
            public const int EN_TANKORDER = 21; //!< Bulk water reaction order for tanks
            public const int EN_CONCENLIMIT = 22;  //!< Limiting concentration for growth reactions
        //}
        //EN_Option;

/// Simple control types
/**
These are the different types of simple (single statement) controls that can be applied
to network links. They are used as an argument to @ref EN_addcontrol,@ref EN_getcontrol,
and @ref EN_setcontrol.
*/
//typedef enum {
            public const int EN_LOWLEVEL = 0; //!< Act when pressure or tank level drops below a setpoint
            public const int EN_HILEVEL = 1; //!< Act when pressure or tank level rises above a setpoint
            public const int EN_TIMER = 2; //!< Act at a prescribed elapsed amount of time
        public const int EN_TIMEOFDAY = 3;    //!< Act at a particular time of day
        //}
        //EN_ControlType;

/// Reporting statistic choices
/**
These options determine what kind of statistical post-processing should be done on
the time series of simulation results generated before they are reported using
@ref EN_report. An option can be chosen by using \b STATISTIC _option_ as the argument
to @ref EN_setreport.
*/
//typedef enum {
            public const int EN_SERIES = 0; //!< Report all time series points
            public const int EN_AVERAGE = 1; //!< Report average value over simulation period
            public const int EN_MINIMUM = 2; //!< Report minimum value over simulation period
            public const int EN_MAXIMUM = 3; //!< Report maximum value over simulation period
            public const int EN_RANGE = 4;    //!< Report maximum - minimum over simulation period
        //}
        //EN_StatisticType;

/// Tank mixing models
/**
These are the different types of models that describe water quality mixing in storage tanks.
The choice of model is accessed with the \b EN_MIXMODEL property of a Tank node using
@ref EN_getnodevalue and @ref EN_setnodevalue.
*/
//typedef enum {
            public const int EN_MIX1 = 0; //!< Complete mix model
            public const int EN_MIX2 = 1; //!< 2-compartment model
            public const int EN_FIFO = 2; //!< First in, first out model
        public const int EN_LIFO = 3;    //!< Last in, first out model
        //}
        //EN_MixingModel;

/// Hydraulic initialization options
/**
These options are used to initialize a new hydraulic analysis when @ref public const int EN_initH is called.
*/
//typedef enum {
            public const int EN_NOSAVE = 0; //!< Don't save hydraulics; don't re-initialize flows
            public const int EN_SAVE = 1; //!< Save hydraulics to file, don't re-initialize flows
            public const int EN_INITFLOW = 10; //!< Don't save hydraulics; re-initialize flows
        public const int EN_SAVE_AND_INIT = 11;  //!< Save hydraulics; re-initialize flows
        //}
        //EN_InitHydOption;

/// Types of pump curves
/**
@ref EN_getpumptype returns one of these values when it is called.
*/
//typedef enum {
            public const int EN_CONST_HP = 0; //!< Constant horsepower
            public const int EN_POWER_FUNC = 1; //!< Power function
            public const int EN_CUSTOM = 2; //!< User-defined custom curve
        public const int EN_NOCURVE = 3;    //!< No curve
        //}
        //EN_PumpType;

/// Types of data curves
/**
These are the different types of physical relationships that a data curve can
represent as returned by calling @ref EN_getcurvetype.
*/
//typedef enum {
            public const int EN_VOLUME_CURVE = 0; //!< Tank volume v. depth curve
            public const int EN_PUMP_CURVE = 1; //!< Pump head v. flow curve
            public const int EN_EFFIC_CURVE = 2; //!< Pump efficiency v. flow curve
            public const int EN_HLOSS_CURVE = 3; //!< Valve head loss v. flow curve
        public const int EN_GENERIC_CURVE = 4;    //!< Generic curve
        //}
        //EN_CurveType;

/// Deletion action codes
/**
These codes are used in @ref EN_deletenode and @ref EN_deletelink to indicate what action
should be taken if the node or link being deleted appears in any simple or rule-based
controls or if a deleted node has any links connected to it.
*/
//typedef enum {
            public const int EN_UNCONDITIONAL = 0; //!< Delete all controls and connecing links
        public const int EN_CONDITIONAL = 1;  //!< Cancel object deletion if it appears in controls or has connecting links
        //}
        //EN_ActionCodeType;

/// Status reporting levels
/**
These choices specify the level of status reporting written to a project's report
file during a hydraulic analysis. The level is set using the @ref EN_setstatusreport function.
*/
//typedef enum {
            public const int EN_NO_REPORT = 0; //!< No status reporting
            public const int EN_NORMAL_REPORT = 1; //!< Normal level of status reporting
        public const int EN_FULL_REPORT = 2;    //!< Full level of status reporting
        //}
        //EN_StatusReport;

/// Network objects used in rule-based controls
//typedef enum {
            public const int EN_R_NODE = 6; //!< Clause refers to a node
            public const int EN_R_LINK = 7; //!< Clause refers to a link
            public const int EN_R_SYSTEM = 8;    //!< Clause refers to a system parameter (e.g., time)
        //}
        //EN_RuleObject;

/// Object variables used in rule-based controls
//typedef enum {
            public const int EN_R_DEMAND = 0; //!< Nodal demand
            public const int EN_R_HEAD = 1; //!< Nodal hydraulic head
            public const int EN_R_GRADE = 2; //!< Nodal hydraulic grade
            public const int EN_R_LEVEL = 3; //!< Tank water level
            public const int EN_R_PRESSURE = 4; //!< Nodal pressure
            public const int EN_R_FLOW = 5; //!< Link flow rate
            public const int EN_R_STATUS = 6; //!< Link status
            public const int EN_R_SETTING = 7; //!< Link setting
            public const int EN_R_POWER = 8; //!< Pump power output
            public const int EN_R_TIME = 9; //!< Elapsed simulation time
            public const int EN_R_CLOCKTIME = 10; //!< Time of day
            public const int EN_R_FILLTIME = 11; //!< Time to fill a tank
        public const int EN_R_DRAINTIME = 12;   //!< Time to drain a tank
        //}
        //EN_RuleVariable;

/// Comparison operators used in rule-based controls
//typedef enum {
            public const int EN_R_EQ = 0; //!< Equal to
            public const int EN_R_NE = 1; //!< Not equal
            public const int EN_R_LE = 2; //!< Less than or equal to
            public const int EN_R_GE = 3; //!< Greater than or equal to
            public const int EN_R_LT = 4; //!< Less than
            public const int EN_R_GT = 5; //!< Greater than
            public const int EN_R_IS = 6; //!< Is equal to
            public const int EN_R_NOT = 7; //!< Is not equal to
            public const int EN_R_BELOW = 8; //!< Is below
            public const int EN_R_ABOVE = 9;    //!< Is above
        //}
        //EN_RuleOperator;

/// Link status codes used in rule-based controls
//typedef enum {
            public const int EN_R_IS_OPEN = 1; //!< Link is open
            public const int EN_R_IS_CLOSED = 2; //!< Link is closed
            public const int EN_R_IS_ACTIVE = 3;    //!< Control valve is active
                                                    //}
                                                    //EN_RuleStatus;

        //#define EN_MISSING -1.E10  //!< Missing value indicator
        public const float EN_MISSING = -999999;

//#endif //EPANET2_ENUMS_H


        /*
    Project Functions

********************************************************************/

        #region Epanet Imports
        public delegate void UserSuppliedFunction(string param0);
        /// <summary>
        /// Runs a complete EPANET simulation.
        /// </summary>
        /// <param name="f1">name of the input file</param>
        /// <param name="f2">name of an output report file</param>
        /// <param name="f3">name of an output output file </param>
        /// <param name="vfunc">pointer to a user-supplied function which accepts a character string as its argument</param>
        /// <returns>Returns an error code.</returns>
        [DllImport(EPANETDLL, EntryPoint = "ENepanet")]
        public static extern int ENepanet(string f1, string f2, string f3, UserSuppliedFunction vfunc);


        /// </summary>
        /// <param name="f1">name of the input file</param>
        /// <param name="f2">name of an output report file</param>
        /// <param name="f3">name of an output output file </param>
        /// <param name="vfunc">pointer to a user-supplied function which accepts a character string as its argument</param>
        /// <returns>Returns an error code.</returns>
        [DllImport(EPANETDLL, EntryPoint = "ENinit")]
        public static extern int ENinit(string rptFile, string outFile,
               ref int unitsType, int headlossType);


        /// <summary>
        /// Opens the Toolkit to analyze a particular distribution system.
        /// </summary>
        /// <param name="inpFile">name of the input file</param>
        /// <param name="rptFile">name of an output report file</param>
        /// <param name="outFile">name of an output output file</param>
        /// <returns>Returns an error code.</returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENopen")]
        public static extern int ENopen(string inpFile, string rptFile, string outFile);

        /// <summary>
        /// Opens the Toolkit to analyze a particular distribution system.
        /// </summary>
        /// <param name="line1">name of the input file</param>
        /// <param name="line2">name of an output report file</param>
        /// <param name="line3">name of an output output file</param>
        /// <returns>Returns an error code.</returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgettitle")]
        public static extern int ENgettitle([MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder line1,
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder line2,
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder line3);



        /// <summary>
        /// Opens the Toolkit to analyze a particular distribution system.
        /// </summary>
        /// <param name="line1">name of the input file</param>
        /// <param name="line2">name of an output report file</param>
        /// <param name="line3">name of an output output file</param>
        /// <returns>Returns an error code.</returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsettitle")]
        public static extern int ENsettitle(string line1, string line2, string line3);


        /// <summary>
        /// Opens the Toolkit to analyze a particular distribution system.
        /// </summary>
        /// <param name="obj">name of the input file</param>
        /// <param name="index">name of an output report file</param>
        /// <param name="comment">name of an output output file</param>
        /// <returns>Returns an error code.</returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcomment")]
        public static extern int ENgetcomment(int obj, int index, ref string comment);


        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcomment")]
        public static extern int ENsetcomment(int obj, int index, ref string comment);



        /// <summary>
        /// Retrieves the number of network components of a specified type.
        /// </summary>
        /// <param name="countcode">component code</param>
        /// <param name="count">number of countcode components in the network</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcount")]
        public static extern int ENgetcount(int countcode, ref int count);


        /// <summary>
        /// Writes all current network input data to a file using the format of an EPANET input file.
        /// </summary>
        /// <param name="filename">name of the file where data is saved.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsaveinpfile")]
        public static extern int ENsaveinpfile(string filename);

        /// <summary>
        /// Closes down the Toolkit system (including all files being processed).
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENclose")]
        public static extern int ENclose();

        /********************************************************************

            Hydraulic Analysis Functions

        ********************************************************************/

        /// <summary>
        /// Runs a complete hydraulic simulation with results
        /// for all time periods written to the binary Hydraulics file.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsolveH")]
        public static extern int ENsolveH();

        /// <summary>
        /// Transfers results of a hydraulic simulation from the binary Hydraulics file to the binary Output file,
        /// where results are only reported at uniform reporting intervals.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsaveH")]
        public static extern int ENsaveH();

        /// <summary>
        /// Opens the hydraulics analysis system.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENopenH")]
        public static extern int ENopenH();

        /// <summary>
        /// Initializes storage tank levels, link status and settings,
        /// and the simulation clock time prior to running a hydraulic analysis.
        /// </summary>
        /// <param name="saveflag">0-1 flag indicating if hydraulic results will be saved to the hydraulics file.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENinitH")]
        public static extern int ENinitH(int saveflag);

        /// <summary>
        /// Runs a single period hydraulic analysis, retrieving the current simulation clock time t.
        /// </summary>
        /// <param name="t">current simulation clock time in seconds.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENrunH")]
        public static extern int ENrunH(ref long t);

        /// <summary>
        /// Determines the length of time until the next hydraulic event occurs in an extended period simulation.
        /// </summary>
        /// <param name="tstep">time (in seconds) until next hydraulic event occurs or
        /// 0 if at the end of the simulation period.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENnextH")]
        public static extern int ENnextH(ref long tstep);

        /// <summary>
        ///  Closes the hydraulic analysis system, freeing all allocated memory.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENcloseH")]
        public static extern int ENcloseH();

        /// <summary>
        /// Saves the current contents of the binary hydraulics file to a file.
        /// </summary>
        /// <param name="fname">name of the file where the hydraulics results should be saved.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsavehydfile")]
        public static extern int ENsavehydfile(string fname);

        /// <summary>
        /// Uses the contents of the specified file as the current binary hydraulics file.
        /// </summary>
        /// <param name="fname">name of the file containing hydraulic analysis results for the current network.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENusehydfile")]
        public static extern int ENusehydfile(string fname);

        /********************************************************************

            Water Quality Analysis Functions

        ********************************************************************/

        /// <summary>
        /// Runs a complete water quality simulation with results at uniform reporting
        /// intervals written to EPANET's binary Output file.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsolveQ")]
        public static extern int ENsolveQ();

        /// <summary>
        /// Opens the water quality analysis system.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENopenQ")]
        public static extern int ENopenQ();

        /// <summary>
        /// Initializes water quality and the simulation clock time prior to running a water quality analysis.
        /// </summary>
        /// <param name="saveflag">0-1 flag indicating if analysis results
        /// should be saved to EPANET's binary output file at uniform reporting periods.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENinitQ")]
        public static extern int ENinitQ(int saveflag);

        /// <summary>
        /// Makes available the hydraulic and water quality results that occur
        /// at the start of the next time period of a water quality analysis,
        /// where the start of the period is returned in t.
        /// </summary>
        /// <param name="t">current simulation clock time in seconds.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENrunQ")]
        public static extern int ENrunQ(ref long t);

        /// <summary>
        /// Advances the water quality simulation to the start of the next hydraulic time period.
        /// </summary>
        /// <param name="tstep">time (in seconds) until next hydraulic event occurs or
        /// 0 if at the end of the simulation period.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENnextQ")]
        public static extern int ENnextQ(ref long tstep);

        /// <summary>
        /// Advances the water quality simulation one water quality time step.
        /// The time remaining in the overall simulation is returned in tleft.
        /// </summary>
        /// <param name="tleft">seconds remaining in the overall simulation duration.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENstepQ")]
        public static extern int ENstepQ(ref long tleft);

        /// <summary>
        /// Closes the water quality analysis system, freeing all allocated memory.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENcloseQ")]
        public static extern int ENcloseQ();


        /********************************************************************

            Reporting Functions

        ********************************************************************/

        /// <summary>
        /// Writes a line of text to the EPANET report file.
        /// </summary>
        /// <param name="line">text to be written to file.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENwriteline")]
        public static extern int ENwriteline(string line);

        /// <summary>
        /// Writes a formatted text report on simulation results to the Report file.
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENreport")]
        public static extern int ENreport();

        /// <summary>
        /// Copies report to new file.
        /// </summary>
        /// <param name="filename">name of new file.</param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENcopyreport")]
        public static extern int ENcopyreport(ref string filename);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENclearreport")]
        public static extern int ENclearreport();

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENresetreport")]
        public static extern int ENresetreport();

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetreport")]
        public static extern int ENsetreport(ref string format);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetstatusreport")]
        public static extern int ENsetstatusreport(int level);



        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetversion")]
        public static extern int ENgetversion(ref int version);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="errcode"></param>
        /// <param name="id"></param>
        /// <param name="maxLen"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgeterror")]
        //public static extern int ENgeterror(int errcode, ref string errmsg, int maxLen);
        public static extern int ENgeterror(int errcode, [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder id, int maxLen);
        
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetstatistic")]
        public static extern int ENgetstatistic(int type, ref float value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetresultindex")]
        public static extern int ENgetresultindex(int type, int index, ref int value);

        /********************************************************************

            Analysis Options Functions

        ********************************************************************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetoption")]
        public static extern int ENgetoption(int option, ref float value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetoption")]
        public static extern int ENsetoption(int option, float value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetflowunits")]
        public static extern int ENgetflowunits(ref int units);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetflowunits")]
        public static extern int ENsetflowunits(int units);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgettimeparam")]
        public static extern int ENgettimeparam(int param, ref int value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsettimeparam")]
        public static extern int ENsettimeparam(int param, int value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetqualinfo")]
        public static extern int ENgetqualinfo(ref int qualType, ref string chemName, ref string chemUnits,
                      ref int traceNode);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetqualtype")]
        public static extern int ENgetqualtype(ref int qualType, ref int traceNode);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetqualtype")]
        public static extern int ENsetqualtype(int qualType, ref string chemName, ref string chemUnits,
                      ref string traceNode);

        /********************************************************************

            Node Functions

        ********************************************************************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nodeType"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddnode")]
        public static extern int ENaddnode(ref string id, int nodeType, ref int index);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="actionCode"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletenode")]
        public static extern int ENdeletenode(int index, int actionCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetnodeindex")]
        public static extern int ENgetnodeindex(string id, ref int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetnodeid")]
        public static extern int ENgetnodeid(int index, [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder id);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetnodeid")]
        public static extern int ENsetnodeid(int index, ref string newid);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetnodetype")]
        public static extern int ENgetnodetype(int index, ref int nodeType);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetnodevalue")]
        public static extern int ENgetnodevalue(int index, int paramcode, ref float value);
        //public static extern int ENgetnodevalue(int index, int property, ref float value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetnodevalue")]
        public static extern int ENsetnodevalue(int index, int property, float value);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetjuncdata")]
        public static extern int ENsetjuncdata(int index, float elev,
                      float dmnd, ref string dmndpat);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsettankdata")]
        public static extern int ENsettankdata(int index, float elev,
                      float initlvl, float minlvl,
                      float maxlvl, float diam,
                      float minvol, ref string volcurve);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcoord")]
        public static extern int ENgetcoord(int index, ref double x, ref double y);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcoord")]
        public static extern int ENsetcoord(int index, double x, double y);

        /********************************************************************

            Nodal Demand Functions

        ********************************************************************/
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetdemandmodel")]
        public static extern int ENgetdemandmodel(ref int model, ref float pmin,
                      ref float preq, ref float pexp);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetdemandmodel")]
        public static extern int ENsetdemandmodel(int model, float pmin,
                      float preq, float pexp);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENadddemand")]
        public static extern int ENadddemand(int nodeIndex, float baseDemand,
                      ref string demandPattern, ref string demandName);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletedemand")]
        public static extern int ENdeletedemand(int nodeIndex, int demandIndex);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetnumdemands")]
        public static extern int ENgetnumdemands(int nodeIndex, ref int numDemands);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetdemandindex")]
        public static extern int ENgetdemandindex(int nodeIndex, ref string demandName, ref int demandIndex);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetbasedemand")]
        public static extern int ENgetbasedemand(int nodeIndex, int demandIndex,
                      ref float baseDemand);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetbasedemand")]
        public static extern int ENsetbasedemand(int nodeIndex, int demandIndex,
                      float baseDemand);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetdemandpattern")]
        public static extern int ENgetdemandpattern(int nodeIndex, int demandIndex, ref int patIndex);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetdemandname")] 
        public static extern int ENgetdemandname(int nodeIndex, int demandIndex, ref string demandName);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetdemandname")]
        public static extern int ENsetdemandname(int nodeIndex, int demandIndex, ref string demandName);

        /********************************************************************

            Link Functions

        ********************************************************************/
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddlink")]
        public static extern int ENaddlink(ref string id, int linkType, ref string fromNode, ref string toNode, ref int index);


        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletelink")]
        public static extern int ENdeletelink(int index, int actionCode);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetlinkindex")]
        public static extern int ENgetlinkindex(string id, ref int index);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetlinkid")]
        public static extern int ENgetlinkid(int index, [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder id);

        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetlinkid")]
        public static extern int ENsetlinkid(int index, ref string newid);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetlinktype")]
        public static extern int ENgetlinktype(int index, ref int linkType);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetlinktype")]
        public static extern int ENsetlinktype(ref int index, int linkType, int actionCode);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetlinknodes")]
        public static extern int ENgetlinknodes(int index, ref int node1, ref int node2);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetlinknodes")]
        public static extern int ENsetlinknodes(int index, int node1, int node2);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetlinkvalue")]
        public static extern int ENgetlinkvalue(int index, int property, ref float value);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetlinkvalue")]
        public static extern int ENsetlinkvalue(int index, int property, float value);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpipedata")]
        public static extern int ENsetpipedata(int index, float length,
                      float diam, float rough, float mloss);
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetvertexcount")]
        public static extern int ENgetvertexcount(int index, ref int count);

        /// <summary>
        /// Get vertex coordinates.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="vertex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetvertex")]
        public static extern int ENgetvertex(int index, int vertex, ref double x, ref double y);

        /// <summary>
        /// Set coordinates for vertices.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetvertices")]
        public static extern int ENsetvertices(int index, ref double x, ref double y, int count);

        /********************************************************************

            Pump Functions

        ********************************************************************/

        /// <summary>
        /// Get pump type
        /// </summary>
        /// <param name="linkIndex"></param>
        /// <param name="pumpType"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpumptype")]
        public static extern int ENgetpumptype(int linkIndex, ref int pumpType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkIndex"></param>
        /// <param name="curveIndex"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetheadcurveindex")]
        public static extern int ENgetheadcurveindex(int linkIndex, ref int curveIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkIndex"></param>
        /// <param name="curveIndex"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetheadcurveindex")]
        public static extern int ENsetheadcurveindex(int linkIndex, int curveIndex);

        /********************************************************************

            Time Pattern Functions

        ********************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddpattern")]
        public static extern int ENaddpattern(ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletepattern")]
        public static extern int ENdeletepattern(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpatternindex")]
        public static extern int ENgetpatternindex(ref string id, ref int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpatternid")]
        public static extern int ENgetpatternid(int index, [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 16)] StringBuilder id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpatternid")]
        public static extern int ENsetpatternid(int index, ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpatternlen")]
        public static extern int ENgetpatternlen(int index, ref int len);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="period"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpatternvalue")]
        public static extern int ENgetpatternvalue(int index, int period, ref float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="period"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpatternvalue")]
        public static extern int ENsetpatternvalue(int index, int period, float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetaveragepatternvalue")]
        public static extern int ENgetaveragepatternvalue(int index, ref float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetaveragepatternvalue")]
        public static extern int ENsetpattern(int index, ref float values, int len);

        /********************************************************************

            Data Curve Functions

        ********************************************************************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddcurve")]
        public static extern int ENaddcurve(ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletecurve")]
        public static extern int ENdeletecurve(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurveindex")]
        public static extern int ENgetcurveindex(ref string id, ref int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurveid")]
        public static extern int ENgetcurveid(int index, ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcurveid")]
        public static extern int ENsetcurveid(int index, ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurvelen")]
        public static extern int ENgetcurvelen(int index, ref int len);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurvetype")]
        public static extern int ENgetcurvetype(int index, ref int type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curveIndex"></param>
        /// <param name="pointIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurvevalue")]
        public static extern int ENgetcurvevalue(int curveIndex, int pointIndex,
                      ref float x, ref float y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curveIndex"></param>
        /// <param name="pointIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcurvevalue")]
        public static extern int ENsetcurvevalue(int curveIndex, int pointIndex,
                      float x, float y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <param name="nPoints"></param>
        /// <param name="xValues"></param>
        /// <param name="yValues"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcurve")]
        public static extern int ENgetcurve(int index, ref string id, ref int nPoints,
                      ref float xValues, ref float yValues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="xValues"></param>
        /// <param name="yValues"></param>
        /// <param name="nPoints"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcurve")]
        public static extern int ENsetcurve(int index, ref float xValues,
                      ref float yValues, int nPoints);

        /********************************************************************

            Simple Controls Functions

        ********************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="linkIndex"></param>
        /// <param name="setting"></param>
        /// <param name="nodeIndex"></param>
        /// <param name="level"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddcontrol")]
        public static extern int ENaddcontrol(int type, int linkIndex, float setting,
                      int nodeIndex, float level, ref int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeletecontrol")]
        public static extern int ENdeletecontrol(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="type"></param>
        /// <param name="linkIndex"></param>
        /// <param name="setting"></param>
        /// <param name="nodeIndex"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetcontrol")]
        public static extern int ENgetcontrol(int index, ref int type, ref int linkIndex,
                      ref float setting, ref int nodeIndex, ref float level);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="type"></param>
        /// <param name="linkIndex"></param>
        /// <param name="setting"></param>
        /// <param name="nodeIndex"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetcontrol")]
        public static extern int ENsetcontrol(int index, int type, int linkIndex,
                      float setting, int nodeIndex, float level);


        /********************************************************************

            Rule-Based Controls Functions

        ********************************************************************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENaddrule")]
        public static extern int ENaddrule(ref string rule);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENdeleterule")]
        public static extern int ENdeleterule(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="nPremises"></param>
        /// <param name="nThenActions"></param>
        /// <param name="nElseActions"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetrule")]
        public static extern int ENgetrule(int index, ref int nPremises, ref int nThenActions,
                      ref int nElseActions, ref float priority);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetruleID")]
        public static extern int ENgetruleID(int index, ref string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="premiseIndex"></param>
        /// <param name="logop"></param>
        /// <param name="obj"></param>
        /// <param name="objIndex"></param>
        /// <param name="variable"></param>
        /// <param name="relop"></param>
        /// <param name="status"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetpremise")]
        public static extern int ENgetpremise(int ruleIndex, int premiseIndex, ref int logop,
                      ref int obj, ref int objIndex, ref int variable,
                      ref int relop, ref int status, ref float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="premiseIndex"></param>
        /// <param name="logop"></param>
        /// <param name="obj"></param>
        /// <param name="objIndex"></param>
        /// <param name="variable"></param>
        /// <param name="relop"></param>
        /// <param name="status"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpremise")]
        public static extern int ENsetpremise(int ruleIndex, int premiseIndex, int logop,
                      int obj, int objIndex, int variable, int relop,
                      int status, float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="premiseIndex"></param>
        /// <param name="objIndex"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpremiseindex")]
        public static extern int ENsetpremiseindex(int ruleIndex, int premiseIndex, int objIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="premiseIndex"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpremisestatus")]
        public static extern int ENsetpremisestatus(int ruleIndex, int premiseIndex, int status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="premiseIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetpremisevalue")]
        public static extern int ENsetpremisevalue(int ruleIndex, int premiseIndex,
                      float value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="actionIndex"></param>
        /// <param name="linkIndex"></param>
        /// <param name="status"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetthenaction")]
        public static extern int ENgetthenaction(int ruleIndex, int actionIndex, ref int linkIndex,
                      ref int status, ref float setting);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="actionIndex"></param>
        /// <param name="linkIndex"></param>
        /// <param name="status"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetthenaction")]
        public static extern int ENsetthenaction(int ruleIndex, int actionIndex, int linkIndex,
                      int status, float setting);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="actionIndex"></param>
        /// <param name="linkIndex"></param>
        /// <param name="status"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENgetelseaction")]
        public static extern int ENgetelseaction(int ruleIndex, int actionIndex, ref int linkIndex,
                      ref int status, ref float setting);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleIndex"></param>
        /// <param name="actionIndex"></param>
        /// <param name="linkIndex"></param>
        /// <param name="status"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetelseaction")]
        public static extern int ENsetelseaction(int ruleIndex, int actionIndex, int linkIndex,
                      int status, float setting);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        [DllImportAttribute(EPANETDLL, EntryPoint = "ENsetrulepriority")]
        public static extern int ENsetrulepriority(int index, float priority);

        #endregion
    }
}