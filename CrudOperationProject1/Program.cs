using System.Data.SqlClient;

namespace CrudOperationProject1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=LOKESH\SQLEXPRESS;Initial Catalog=CoDB;Integrated Security=True";
            SqlConnection con=new SqlConnection(connectionString);
            con.Open();
            try
            {
                Console.WriteLine("Connection successfull");
                string answer;
                do
                {
                    Console.WriteLine("Select the option:\n 1. insert\n 2. Retrieve\n 3. update\n 4. Delete");
                    int choice=int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        // Insert
                        case 1:
                            Console.WriteLine("Enter the name");
                            string username=Console.ReadLine();
                            Console.WriteLine("Enter the salary");
                            int usersal=int.Parse(Console.ReadLine());
                            string insertQuery = "insert into emp(Ename,Sal) values('" + username + "'," + usersal + ")";
                            SqlCommand insertCommand=new SqlCommand(insertQuery,con);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data inserted successfully");
                            break;
                        // Retrieve    
                        case 2:
                            string displayQuery = "select * from emp";
                            SqlCommand displayCommand=new SqlCommand(displayQuery,con);
                            SqlDataReader dataReader=displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Id: "+dataReader.GetValue(0).ToString());
                                Console.WriteLine("Ename: "+dataReader.GetValue(1).ToString());
                                Console.WriteLine("Sal: "+dataReader.GetValue(2).ToString());
                            }
                            dataReader.Close();
                            break;
                            //update
                        case 3:
                            Console.WriteLine("Enter the id u want to update");
                            int u_id=int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the sal of the user to update");
                            int u_sal=int.Parse(Console.ReadLine());
                            string updateQuery = "update emp set Sal= " + u_sal + "where Id= " + u_id + " ";
                            SqlCommand updateCommand=new SqlCommand(updateQuery,con);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data updated successfully");
                            break;
                        //Delete
                        case 4:
                            Console.WriteLine("Enter the id of the record that is to be deleted");
                                int d_id=int.Parse(Console.ReadLine());
                            string deleteQuery = "delete from emp where Id= " + d_id;
                            SqlCommand deleteCommand=new SqlCommand(deleteQuery,con);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deleted successfully");
                            break;
                    }
                    Console.WriteLine("Do u want to continue");
                    answer = Console.ReadLine();
                } while (answer.ToLower() != "no");

            }catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }

            finally
            {
                con.Close();
            }
        }
    }
}
