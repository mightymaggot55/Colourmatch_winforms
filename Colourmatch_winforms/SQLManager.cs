using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourmatch_winforms
{
    public class SQLManager
    {
        //CreateColourMatch
        private static readonly string selectSQLProcess = "SELECT Process FROM Colourmatch.dbo.[Process Specifications];";
        private static readonly string selectSQLColourPrefix = "SELECT [Colour Effect] FROM Colourmatch.dbo.[Colour Effects];";
        private static readonly string selectSQLColour = "SELECT Colour FROM Colourmatch.dbo.Colours;";
        private static readonly string selectSQLMouldingMaterial = "SELECT Material FROM Colourmatch.dbo.[Moulding Material];";
        private static readonly string selectSQLCustomers = "SELECT Customer FROM Colourmatch.dbo.Customers;";
        private static readonly string selectSQLSalesContact = "SELECT Contact FROM Colourmatch.dbo.[Sales Contacts];";
        private static readonly string selectSQLPurchasingContact = "SELECT Contact FROM Colourmatch.dbo.[Purchasing Contacts]";
        private static readonly string selectSQLMatchStatus = "SELECT [Match Status] FROM Colourmatch.dbo.[Match Status's]";

        public static string SelectSQLMatchStatus
        {
            get { return selectSQLMatchStatus; }
        }
        public static string SelectSQLPurchasingContact
        {
            get { return selectSQLPurchasingContact; }
        }
        public static string SelectSQLProcess
        {
            get { return selectSQLProcess; }
        }
        public static string SelectSQLColourPrefix
        {
            get { return selectSQLColourPrefix; }
        }
        public static string SelectSQLColour
        {
            get { return selectSQLColour; }
        }
        public static string SelectSQLMouldingMaterial
        {
            get { return selectSQLMouldingMaterial; }
        }
        public static string SelectSQLCustomers
        {
            get { return selectSQLCustomers; }
        }
        public static string SelectSalesContact
        {
            get { return selectSQLSalesContact; }
        }

        private static readonly string selectSQLMaxRequestNo = "SELECT MAX([Match Request No]) FROM Colourmatch.dbo.[MatchRequest_Sales]";

        public static string SelectSQLMaxRequestNo
        {
            get { return selectSQLMaxRequestNo; }
        }

        public static string SQLInsertSalesTable(string FieldString) { return "INSERT INTO Colourmatch.dbo.MatchRequest_Sales ([Match No], [Match Request No], [Match Stroke No], [Sales Contact], [Customer], [Customer Contact], [Project Reference], [Process], [Moulding Material], [Colour], [Colour Prefix One], [Colour Prefix Two], [Light Source], [Plaques], [Colour Target], [Pellet Size], [Heat Stability], [Sample Quantity], [Light Fastness], [Addition Rate], [Notes], [Sample Type]) VALUES(" + FieldString + ");"; }
        
        public static string SQLInsertPurchasingTable(string MatchNo, int MatchRequestNo, int MatchStrokeNo) { return "INSERT INTO Colourmatch.dbo.MatchRequest_Purchasing ([Match No], [Match Request No], [Match Stroke No]) Values ('" + MatchNo + "'," + MatchRequestNo + "," + MatchStrokeNo + ");"; }




        //ReviewColourMatch
        private static readonly string _SQLSelectSetDropDown_ReceivedBy = "SELECT [Contact] FROM Colourmatch.dbo.[Purchasing Contacts]";
        
        private static readonly string _SQLSelectSetDropDown_HeatStability = "SELECT [Heat Stability] FROM Colourmatch.dbo.[Process Specifications] ORDER BY 1";
        
        private static readonly string _SQLSelectSetDropDown_LightFastness = "SELECT DISTINCT [Light Fastness] FROM Colourmatch.dbo.[Process Specifications]";
        
        private static readonly string _SQLSelectSetDropDown_Supplier = "SELECT Suppliers FROM Colourmatch.dbo.[Masterbatch Suppliers]";
        
        public static string SQLSelectSetDropDown_ReceivedBy
        {
            get { return _SQLSelectSetDropDown_ReceivedBy; }
        }
        public static string SQLSelectSetDropDown_HeatStability
        {
            get { return _SQLSelectSetDropDown_HeatStability; }
        }
        public static string SQLSelectSetDropDown_LightFastness
        {
            get { return _SQLSelectSetDropDown_LightFastness; }
        }
        public static string SQLSelectSetDropDown_Supplier
        {
            get { return _SQLSelectSetDropDown_Supplier; }
        }

        public static string SQLSelectExtract(string MatchNo) { return "SELECT * FROM(SELECT * FROM[MatchRequest_Sales]) A LEFT JOIN(SELECT * FROM MatchRequest_Purchasing) B ON A.[Match No] = B.[Match No] WHERE A.[Match No] = '" + MatchNo + "';"; }
        
        public static string SQLUpdatePurchasing(params string[] args) { return "UPDATE Colourmatch.dbo.MatchRequest_Purchasing SET[Masterbatch Reference Two] = '" + args[0] + "', " +
                                                                                "[Addition Rate Received Two] = '" + args[1] + "', [Light Fastness Received Two] = '" + args[2] + "', [Heat Stability Received Two] = '" + args[3] + "', " +
                                                                                "[Date Received Two] = '" + args[4] + "', [Match Status Two] = '" + args[5] + "', [Purchasing Notes] = '" + args[6] + "', [Received By Two] = '" + args[7] + "', " +
                                                                                "[Processed By] = '" + args[8] + "', [Supplier Two] = '" + args[9] + "', [Supplier Date Confirmed Two] = '" + args[10] + "' " +
                                                                                "WHERE Colourmatch.dbo.MatchRequest_Purchasing.[Match Request No] = '" + args[11] + "' AND Colourmatch.dbo.MatchRequest_Purchasing.[Match Stroke No] = '" + args[12] + "'"; }

        public static string SQLUpdatePurchasingTwo(params string[] args)
        {
            return "UPDATE Colourmatch.dbo.MatchRequest_Purchasing SET[Masterbatch Reference] = '" + args[0] + "', " +
                                                                        "[Addition Rate Received] = '" + args[1] + "', [Light Fastness Received] = '" + args[2] + "', [Heat Stability Received] = '" + args[3] + "', " +
                                                                        "[Date Received] = '" + args[4] + "', [Match Status] = '" + args[5] + "', [Purchasing Notes] = '" + args[6] + "', [Received By] = '" + args[7] + "', " +
                                                                        "[Processed By] = '" + args[8] + "', [Supplier] = '" + args[9] + "', [Supplier Date Confirmed] = '" + args[10] + "' " +
                                                                        "WHERE Colourmatch.dbo.MatchRequest_Purchasing.[Match Request No] = '" + args[11] + "' AND Colourmatch.dbo.MatchRequest_Purchasing.[Match Stroke No] = '" + args[12] + "'";
        }

        public static string SQLGetMaxStroke(string MatchRequestNo) { return "SELECT MAX([Match Stroke No]) FROM Colourmatch.dbo.MatchRequest_Sales WHERE[Match Request No] = '" + MatchRequestNo + "'"; }
        
        public static string SQLInsertRematch(string NewMatchNo, string NewMatchRequestNo, int NewMatchStrokeNo) { return string.Format("INSERT INTO [MatchRequest_Sales] ([Match No], [Match Request No], [Match Stroke No]) VALUES ('{0}', {1}, {2})", NewMatchNo, NewMatchRequestNo, NewMatchStrokeNo); }
        
        public static string SQLInsertPurchasingRematch(string NewMatchNo, string NewMatchRequestNo, int NewMatchStrokeNo) { return string.Format("INSERT INTO [MatchRequest_Purchasing] ([Match No], [Match Request No], [Match Stroke No]) VALUES ('{0}', {1}, {2})", NewMatchNo, NewMatchRequestNo, NewMatchStrokeNo); }
        
        public static string SQLSelectSalesInformation(string MatchRequestNo, string MatchStrokeNo) { return string.Format("SELECT [Project Reference], [Sales Contact], [Customer], [Customer Contact] FROM [MatchRequest_Sales] " +
                                                                                                                           "WHERE [Match Request No] = {0} AND [Match Stroke No] = {1}", MatchRequestNo, MatchStrokeNo); }
        public static string SQLUpdateSalesInformation(string projectRef, string salesContact, string customer, string customerContact, string MatchRequestNo, int NewStrokeNo) { return string.Format("UPDATE [MatchRequest_Sales] SET [Project Reference] = '{0}', " +
                                                                                                                                                                                                     "[Sales Contact] = '{1}', Customer = '{2}', [Customer Contact] = '{3}' " +
                                                                                                                                                                                                       "WHERE [Match Request No] = {4} AND [Match Stroke No] = {5}", projectRef, salesContact, customer, customerContact, MatchRequestNo, NewStrokeNo); }
        
        public static string SQLUpdateSalesButton(params string[] args) { return string.Format("UPDATE [MatchRequest_Sales] SET [Date Created] = '{0}', " +
                                                                                               "[Date Required] = '{1}', [Sales Contact] = '{2}', [Customer] = '{3}', [Customer Contact] = '{4}', " +
                                                                                               "[Project Reference] = '{5}', [Process] = '{6}', [Moulding Material] = '{7}', [Colour] = '{8}', [Colour Prefix One] = '{9}', " +
                                                                                               "[Colour Prefix Two] = '{10}', [Light Source] = '{11}', [Plaques] = '{12}', [Notes] = '{13}', [Colour Target] = '{14}', [Pellet Size] = '{15}', " +
                                                                                               "[Heat Stability] = '{16}', [Sample Quantity] = '{17}', [Light Fastness] = '{18}', [Addition Rate] = '{19}', [Sample Type] = '{20}' FROM [Colourmatch].[dbo].[MatchRequest_Sales] WHERE [Match No] = '{21}'", 
                                                                                               args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13], args[14], args[15], args[16], args[17], args[18], args[19], args[20], args[21]); 
        }





        
        
        //OverviewColourMatch
        private static readonly string _SQLDataAdapter = "SELECT TOP (100) [Match No], [Match Request No], [Match Stroke No], [Date Created], [Date Required], [Sales Contact], [Customer], [Customer Contact], [Project Reference], [Process], [Moulding Material], [Colour], [Colour Prefix One], [Colour Prefix Two], [Light Source], [Plaques], [Notes], [Colour Target], [Pellet Size], [Heat Stability], [Sample Quantity], [Light Fastness] FROM Colourmatch.dbo.[MatchRequest_Sales] ORDER BY [Match Request No];";
        public static string SQLDataAdapter
        {
            get { return _SQLDataAdapter; }
        }
            
    }
}
