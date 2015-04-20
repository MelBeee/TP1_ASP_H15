using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class ThreadsManager : System.Web.UI.Page
   {
      protected void BTN_Return_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         var master = Master as masterpage;
         if (master != null)
            master.SetNomDeLaPage("Gestion des discussions");

         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

         String commandeSQL = "SELECT ID AS 'CheckBox', AVATAR AS 'Avatar', USERNAME FROM USERS WHERE ID != " + MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name);
         SqlDataAdapter sda = new SqlDataAdapter(commandeSQL, (String)Application["MainDB"]);
         MethodesPourBD.AppendToTable(TB_Users, sda, false);

         if (!Page.IsPostBack)
         {
            SqlCommand commandeSQLThread = new SqlCommand("SELECT TITLE AS 'Titre' FROM THREADS WHERE CREATOR = " + MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name) + " OR 'admin' = '" + HttpContext.Current.User.Identity.Name + "'");
            commandeSQLThread.Connection = connection;

            connection.Open();

            SqlDataReader reader = commandeSQLThread.ExecuteReader();
            LB_Thread.Items.Clear();

            while (reader.Read())
            {
               ListItem item = new ListItem();
               item.Text = item.Value = reader.GetString(0);
               LB_Thread.Items.Add(item);
            }

            reader.Close();
            connection.Close();
         }

         if (!Page.IsPostBack)
            Session["isModifying"] = false;
      }


      protected void BTN_Delete_Click(object sender, EventArgs e)
      {
         if (LB_Thread.SelectedIndex != -1)
         {
            SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

            TB_Titre.Text = LB_Thread.SelectedValue;
            ModifyRightsToThread(true);
            SqlCommand sqlcmdDeleteThread = new SqlCommand("DELETE FROM THREADS WHERE TITLE = '" + LB_Thread.SelectedValue + "'");
            sqlcmdDeleteThread.Connection = connection;

            connection.Open();

            sqlcmdDeleteThread.ExecuteNonQuery();
            connection.Close();

            Response.Redirect(Request.Url.ToString());
         }
         else
         {
            ClientAlert(this, "Il faut selectionner une discussion pour en supprimer une.");
         }
      }

      public static void ClientAlert(System.Web.UI.Page page, string message)
      {
         page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
      }

      protected void CB_AllUsers_CheckedChanged(object sender, EventArgs e)
      {
         foreach (TableRow tr in TB_Users.Rows)
         {
            foreach (TableCell tc in tr.Cells)
            {
               if (tc.Controls.Count > 0)
               {
                  var chkBox = tc.Controls[0] as CheckBox;
                  if (chkBox != null)
                     chkBox.Enabled = !CB_AllUsers.Checked;
               }
            }
         }
         UP_CBUser.Update();
      }

      protected void ModifyRightsToThread(bool deleting = false)
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         long currentUsersId = MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name);

         connection.Open();

         SqlCommand getThreadID = new SqlCommand("SELECT ID FROM THREADS WHERE TITLE = '" + TB_Titre.Text + "'");
         getThreadID.Connection = connection;
         SqlDataReader threadIDReader = getThreadID.ExecuteReader();
         threadIDReader.Read();
         long threadID = threadIDReader.GetInt64(0);
         threadIDReader.Close();

         SqlCommand deleteAllMessagesFromThread = new SqlCommand("DELETE FROM THREADS_MESSAGES WHERE THREAD_ID = " + threadID.ToString());
         deleteAllMessagesFromThread.Connection = connection;
         deleteAllMessagesFromThread.ExecuteNonQuery();

         SqlCommand deleteAllPermissionsToThread = new SqlCommand("DELETE FROM THREADS_ACCESS WHERE THREAD_ID = " + threadID.ToString());
         deleteAllPermissionsToThread.Connection = connection;
         deleteAllPermissionsToThread.ExecuteNonQuery();

         if (!deleting && !CB_AllUsers.Checked)
         {
            List<long> usersToAdd = new List<long>();

            if (CB_AllUsers.Checked)
            {
               usersToAdd.Add(0);
            }
            else
            {
               usersToAdd.Add(currentUsersId);
               foreach (TableRow tr in TB_Users.Rows)
               {
                  foreach (TableCell tc in tr.Cells)
                  {
                     if (tc.Controls.Count > 0)
                     {
                        var chkBox = tc.Controls[0] as CheckBox;
                        if (chkBox != null)
                        {
                           if (chkBox.Checked)
                           {
                              String userID = chkBox.ID.Remove(0, 7);
                              usersToAdd.Add(long.Parse(userID));
                           }
                        }
                     }
                  }
               }
            }

            SqlCommand sqlInsert = new SqlCommand();
            sqlInsert.Connection = connection;
            if (!deleting)
            {
               foreach (long id in usersToAdd)
               {
                  sqlInsert.CommandText = "INSERT INTO THREADS_ACCESS VALUES(" + threadID.ToString() + ", " + id.ToString() + ")";
                  sqlInsert.ExecuteNonQuery();
               }
            }
         }
         connection.Close();
      }

      protected void CV_Titre_ServerValidate(object source, ServerValidateEventArgs args)
      {
         args.IsValid = TB_Titre.Text != "";
      }

      protected bool DiscussionExiste()
      {
         bool result;

         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

         SqlCommand sqlcmdDeleteThread = new SqlCommand("SELECT TITLE FROM THREADS WHERE TITLE = '" + TB_Titre.Text + "'");
         sqlcmdDeleteThread.Connection = connection;
         connection.Open();

         SqlDataReader reader = sqlcmdDeleteThread.ExecuteReader();

         result = reader.Read();

         connection.Close();

         return result;
      }

      protected void BTN_Clear_Click(object sender, EventArgs e)
      {
         BTN_ModCre.Text = "Créer";
         TB_Titre.Text = "";

         Session["isModifying"] = false;

         CB_AllUsers.Checked = false;

         foreach (TableRow tr in TB_Users.Rows)
         {
            foreach (TableCell tc in tr.Cells)
            {
               if (tc.Controls.Count > 0)
               {
                  var chkBox = tc.Controls[0] as CheckBox;
                  if (chkBox != null)
                  {
                     chkBox.Checked = false;
                  }
               }
            }
         }
      }

      protected void BTN_ModCre_Click(object sender, EventArgs e)
      {
         if (PageValide())
         {
            if (Session["isModifying"] == null || (bool)Session["isModifying"] == false && !DiscussionExiste())
            {
               SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

               int accessToAll = CB_AllUsers.Checked ? 1 : 0;

               SqlCommand sqlcmdInsertThread = new SqlCommand("INSERT INTO THREADS VALUES(" + MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name) + ", '" + TB_Titre.Text + "', '" + DateTime.Now + "', " + accessToAll + ")");
               sqlcmdInsertThread.Connection = connection;
               connection.Open();

               sqlcmdInsertThread.ExecuteNonQuery();

               connection.Close();
               ModifyRightsToThread();

            }
            else if (!DiscussionExiste() || TB_Titre.Text == LB_Thread.SelectedValue)
            {
               SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

               int accessToAll = CB_AllUsers.Checked ? 1 : 0;

               SqlCommand sqlcmdUpdateThread = new SqlCommand("UPDATE THREADS SET TITLE = '" + TB_Titre.Text + "', ACCESS_TO_ALL = " + accessToAll + " WHERE TITLE = '" + LB_Thread.SelectedValue + "'");
               sqlcmdUpdateThread.Connection = connection;
               connection.Open();

               sqlcmdUpdateThread.ExecuteNonQuery();

               connection.Close();
               ModifyRightsToThread();
            }
            Response.Redirect("ChatRoom.aspx");
         }

      }

      protected void CV_NbreUser_ServerValidate(object source, ServerValidateEventArgs args)
      {
         args.IsValid = CB_AllUsers.Checked || AuMoinsUnInviteEstCoché();
      }

      private bool PageValide()
      {
         bool valide = true;
         Valid_Titre.Text = "";
         Valid_Users.Text = "";

         if(TB_Titre.Text == "")
         {
            valide = false;
            Valid_Titre.Text = "Titre obligatoire !";
         }
         if (!CB_AllUsers.Checked && !AuMoinsUnInviteEstCoché())
         {
            valide = false;
            Valid_Users.Text = "Minimum un usager doit être selectionné !";
         }
         UP_Titre.Update();
         UP_CBUser.Update();
         return valide;
      }

      protected bool AuMoinsUnInviteEstCoché()
      {
         bool result = false;
         foreach (TableRow tr in TB_Users.Rows)
         {
            foreach (TableCell tc in tr.Cells)
            {
               if (tc.Controls.Count > 0)
               {
                  var chkBox = tc.Controls[0] as CheckBox;
                  if (chkBox != null)
                  {
                     result |= chkBox.Checked;
                  }
               }
            }
         }

         return result;
      }

      protected void LB_Thread_SelectedIndexChanged(object sender, EventArgs e)
      {

         Session["isModifying"] = true;
         BTN_ModCre.Text = "Modifier";
         TB_Titre.Text = LB_Thread.SelectedValue;
         UP_BTNModCre.Update();
         UP_Titre.Update();

         CB_AllUsers.Checked = false;

         foreach (TableRow tr in TB_Users.Rows)
         {
            foreach (TableCell tc in tr.Cells)
            {
               if (tc.Controls.Count > 0)
               {
                  var chkBox = tc.Controls[0] as CheckBox;
                  if (chkBox != null)
                  {
                     chkBox.Checked = false;
                  }
               }
            }
         }

         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

         int count = LB_Thread.Items.Count;
         String titre = LB_Thread.Items[LB_Thread.SelectedIndex].Text;

         String threadID = MethodesPourBD.TrouverIDThread(connection, LB_Thread.SelectedValue).ToString();
         List<String> usersID = new List<String>();

         SqlCommand fetchIDs = new SqlCommand();
         fetchIDs.Connection = connection;
         fetchIDs.CommandText = "select user_id from THREADS_ACCESS where THREAD_ID = " + threadID;

         connection.Open();

         SqlDataReader reader = fetchIDs.ExecuteReader();


         while (reader.Read())
            usersID.Add(reader.GetInt64(0).ToString());

         reader.Close();
         connection.Close();

         if (usersID.Count == 0)
         {
            CB_AllUsers.Checked = true;
         }
         else
         {
            CB_AllUsers.Checked = false;
            foreach (TableRow tr in TB_Users.Rows)
            {
               foreach (TableCell tc in tr.Cells)
               {
                  if (tc.Controls.Count > 0)
                  {
                     var chkBox = tc.Controls[0] as CheckBox;
                     if (chkBox != null)
                     {
                        String userID = chkBox.ID.Remove(0, 7);
                        chkBox.Checked = usersID.Contains(userID);
                     }
                  }
               }
            }
         }
         UP_CBUser.Update();
         UP_Titre.Update();
         TB_Titre.Focus();
      }
   }
}