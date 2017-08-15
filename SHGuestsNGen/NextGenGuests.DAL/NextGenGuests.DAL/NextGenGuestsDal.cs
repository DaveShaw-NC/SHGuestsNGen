using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace NextGenGuests.DAL
{
    public class NextGenGuestsDal
    {
        #region Variables and Constants

        private SamHouseGuestsEntities nge_Context;
        private List<Guest> allGuests = new List<Guest> ( );
        private List<Visit> v_List = new List<Visit> ( );
        private DbContext dbCtx;
        private Database thisDb;
        public string connectionString = string.Empty;
        public SqlConnection connection;

        #endregion Variables and Constants

        #region Constructor and Destructor

        public NextGenGuestsDal ( )
        {
            nge_Context = new SamHouseGuestsEntities ( );
            dbCtx = new SamHouseGuestsEntities ( );
            thisDb = dbCtx.Database;
            connectionString = thisDb.Connection.ConnectionString;
            connection = new SqlConnection ( connectionString );
        }

        ~NextGenGuestsDal ( )
        {
        }

        #endregion Constructor and Destructor

        #region Guest Retrievals

        public List<Guest> GuestbyAllRosters ( )
        {
            allGuests = new List<Guest> ( );
            allGuests = ( from g in nge_Context.Guests
                          orderby g.Roster, g.LastName, g.FirstName, g.Visits
                          select g ).ToList ( );
            return allGuests;
        }

        public List<Guest> GuestsAlphabetically ( )
        {
            allGuests = new List<Guest> ( );
            allGuests = ( from g in nge_Context.Guests
                          orderby g.LastName, g.FirstName
                          select g ).ToList ( );
            return allGuests;
        }
        public List<Guest> GuestbySpecificRoster ( string in_Roster )
        {
            allGuests = new List<Guest> ( );
            allGuests = ( from g in nge_Context.Guests
                          orderby g.Roster, g.LastName, g.FirstName, g.Visits
                          where g.Roster == in_Roster
                          select g ).ToList ( );
            return allGuests;
        }

        public List<Guest> GetSpecificGuestFullName ( string lastname, string firstname )
        {
            List<Guest> theGuest = new List<Guest> ( );

            theGuest = ( from g in nge_Context.Guests
                         where g.LastName == lastname && g.FirstName == firstname
                         select g ).ToList ( );
            return theGuest;
        }

        public List<Guest> GetSpecificGuestLastName ( string lastname )
        {
            List<Guest> theGuest = new List<Guest> ( );

            theGuest = ( from g in nge_Context.Guests
                         where g.LastName == lastname
                         select g ).ToList ( );
            return theGuest;
        }

        #endregion Guest Retrievals

        #region Update a Guest and their Visits

        public int UpdateGuestandVisits ( Guest guest_In )
        {
            nge_Context.Entry ( guest_In ).State = EntityState.Modified;
            foreach (Visit v in guest_In.Visits1)
            {
                nge_Context.Entry ( v ).State = EntityState.Modified;
            }
            return nge_Context.SaveChanges ( );
        }

        #endregion Update a Guest and their Visits
    }
}