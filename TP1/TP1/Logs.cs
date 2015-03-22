using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public class Logs : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public DateTime DateLogin { get; set; }
        public DateTime DateLogout { get; set; }
        public String AdresseIP { get; set; }
        public Logs (String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "JOURNALLOGS";
        }

        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            UserID = long.Parse(FieldsValues[1]);
            DateLogin = DateTime.Parse(FieldsValues[2]);
            DateLogout = DateTime.Parse(FieldsValues[3]);
            AdresseIP = FieldsValues[4];
        }

        public override void Insert()
        {
            InsertRecord(UserID, DateLogin, DateLogout, AdresseIP);
        }

        public override void Update()
        {
            UpdateRecord(UserID, DateLogin, DateLogout, AdresseIP);
        }

        private Panel PN_GridView = null;
        public void MakeGridView(Panel PN_GridView, String EditPage, String UserSelected)
        {
            SqlDataReader reader = FillReader(UserSelected.ToString());
            // Conserver le panneau parent (utilisé dans certaines méthodes de cette classe
            this.PN_GridView = PN_GridView;
            Table Grid = null;

            if (reader.HasRows)
            {
                // Création de l'entête
                Grid = new Table();
                Grid.CssClass = "grid";
                TableRow tr = new TableRow();
                tr.CssClass = "grid";
                AjouterElementHeader(tr, "Utilisateur");
                AjouterElementHeader(tr, "Date Login");
                AjouterElementHeader(tr, "Durée de Session");
                Grid.Rows.Add(tr);

                while (reader.Read())
                {
                    // Insertion des données
                    tr = new TableRow();
                    tr.CssClass = "grid";
                    InsertionUserName(tr, reader.GetString(1));
                    InsertionDateLogin(tr, reader.GetDateTime(2));
                    InsertionDuree(tr, reader.GetDateTime(2), reader.GetDateTime(3));
                    Grid.Rows.Add(tr);
                }
            }
            PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
        }

        private void AjouterElementHeader(TableRow tr, String Titre)
        {
            TableCell td = new TableCell();
            td.CssClass = "grid";
            tr.Cells.Add(td);
            Label LBL_Header = new Label();
            LBL_Header.Text = "<b>" + Titre + "</b>";
            //ImageButton BTN_Sort = new ImageButton();
            //// assignation du delegate du clic (voir sa définition plus bas dans le code)
            //BTN_Sort.Click += new ImageClickEventHandler(SortField_Click);
            //// IMPORTANT!!!
            //// il faut placer dans le répertoire Images du projet l'icône qui représente un tri
            //BTN_Sort.ImageUrl = @"~/Images/Sort.png";
            //// afin de bien reconnaitre quel champ il faudra trier on construit ici un ID
            //// pour le bouton
            //BTN_Sort.ID = "Sort_" + Titre;
            //td.Controls.Add(BTN_Sort);
            td.Controls.Add(LBL_Header);
        }

        private void InsertionUserName(TableRow tr, String UserSelected)
        {
            TableCell td = new TableCell();
            td.CssClass = "grid";
            td.Text = SelectByUserID(UserSelected);

            tr.Cells.Add(td);
        }

        private void InsertionDateLogin(TableRow tr, DateTime LoginDate)
        {
            TableCell td = new TableCell();
            td.Text = LoginDate.ToShortDateString();
            td.CssClass = "grid";

            tr.Cells.Add(td);
        }

        private void InsertionDuree(TableRow tr, DateTime LoginDate, DateTime LogoutDate)
        {
            TableCell td = new TableCell();
            td.Text = LogoutDate.Subtract(LoginDate).ToString();
            td.CssClass = "grid";

            tr.Cells.Add(td);
        }

        public string GetUsername(string ID)
        {
            QuerySQL("Select username from users where id = " + ID);
            if (reader.Read())
            {
                string read = reader.GetString(0);
                return read;
            }
            return "";
        }
    }
}