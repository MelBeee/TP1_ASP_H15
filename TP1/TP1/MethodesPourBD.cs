using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public class MethodesPourBD
    {
        public static bool NomUtilisateurExiste(SqlConnection connection, String nomutilisateur)
        {
            bool resultat = false;

            SqlCommand sqlcommand = new SqlCommand("SELECT USERNAME FROM USERS WHERE USERNAME = '" + nomutilisateur + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            if (userReader.Read())
                resultat = userReader.GetString(0) != "";

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static String TrouverAvatar(SqlConnection connection, String nomutilisateur)
        {
            String resultat = @"~\Avatars\Anonymous.png";

            SqlCommand sqlcommand = new SqlCommand("SELECT AVATAR FROM USERS WHERE USERNAME = '" + nomutilisateur + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            if (userReader.Read())
            {
                resultat = @"~\Avatars\" + userReader.GetString(0) + ".png";
            }

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static String TrouverIDAvatar(SqlConnection connection, String nomutilisateur)
        {
            String resultat = "";

            SqlCommand sqlcommand = new SqlCommand("SELECT AVATAR FROM USERS WHERE USERNAME = '" + nomutilisateur + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            if(userReader.Read())
                resultat = userReader.GetString(0);

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static long TrouverIDUtilisateur(SqlConnection connection, String nomutilisateur)
        {
            long resultat;

            SqlCommand sqlcommand = new SqlCommand("SELECT ID FROM USERS WHERE USERNAME = '" + nomutilisateur + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            userReader.Read();
            resultat = userReader.GetInt64(0);

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static string TrouverNomComplet(SqlConnection connection, String nomutilisateur)
        {
            string resultat = "Anonymous";

            SqlCommand sqlcommand = new SqlCommand("SELECT FULLNAME FROM USERS WHERE USERNAME = '" + nomutilisateur + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            if(userReader.Read())
            {
               resultat = userReader.GetString(0);
            }

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static long TrouverIDDiscussion(SqlConnection connection, String titreDiscussion)
        {
            long resultat;

            SqlCommand sqlcommand = new SqlCommand("SELECT ID FROM THREADS WHERE TITLE = '" + titreDiscussion + "'");
            sqlcommand.Connection = connection;
            connection.Open();

            SqlDataReader userReader = sqlcommand.ExecuteReader();

            userReader.Read();
            resultat = userReader.GetInt64(0);

            userReader.Close();
            connection.Close();

            return resultat;
        }

        public static void AppendToTable(Table container, SqlDataAdapter sda, bool wantHeader = false, List<long> OnlineUsers = null)
        {
            DataSet customersSet = new DataSet();
            DataTable customersTable = null;
            sda.Fill(customersSet);
            customersTable = customersSet.Tables[0];

            TableRow tableRow = null;

            if (wantHeader)
            {
                TableRow tableHeader = new TableRow();
                tableHeader.ID = "DynamicTableHeader";
                tableHeader.TableSection = TableRowSection.TableHeader;
                container.Controls.Add(tableHeader);

                foreach (DataColumn col in customersTable.Columns)
                {
                    TableCell cell = new TableCell();
                    cell.Text = col.ColumnName;
                    tableHeader.Controls.Add(cell);
                }
            }

            // Create table rows.

            foreach (DataRow dr in customersTable.Rows)
            {
                tableRow = new TableRow();
                tableRow.TableSection = TableRowSection.TableBody;
                container.Controls.Add(tableRow);
                foreach (DataColumn col in customersTable.Columns)
                {
                    Object dbCell = dr[col];
                    TableCell tableCell = new TableCell();
                    if (!(dbCell is DBNull))
                    {
                        if (col.ColumnName == "Email")
                        {
                            HyperLink link = new HyperLink();
                            link.Text = dbCell.ToString();
                            link.NavigateUrl = "mailto:" + dbCell.ToString();

                            tableCell.Controls.Add(link);
                        }
                        else if (col.ColumnName == "Avatar")
                        {
                           tableCell.Controls.Add(new LiteralControl("<div style='height: 50px; width: 50px'>"));
                            Image imgAvatar = new Image();
                            imgAvatar.CssClass = "inscrip_img_2 img-circle";
                            imgAvatar.ImageUrl = @"~\Avatars\" + dbCell.ToString() + ".png";

                            tableCell.Controls.Add(imgAvatar);
                            tableCell.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (col.ColumnName == "En ligne")
                        {
                            Image imgOnline = new Image();
                            imgOnline.CssClass = "";
                            if (OnlineUsers.Contains(long.Parse(dbCell.ToString())))
                                imgOnline.ImageUrl = "/Images/on.png";
                            else
                                imgOnline.ImageUrl = "/Images/off.png";
                            tableCell.Controls.Add(imgOnline);
                        }
                        else
                            tableCell.Text = dbCell.ToString();
                    }
                    tableRow.Controls.Add(tableCell);
                }
            }
        }
    }
}