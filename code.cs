
SqlConnection connection = new SqlConnection(".");
connection.Open();

string query = "SELECT * FROM Employee";
SqlCommand command = new SqlCommand(query, connection);
SqlDataReader reader = command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader["EmployeeId"]} - {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}, Salary: {reader["Salary"]}");
}

reader.Close();
connection.Close();



SqlConnection connection = new SqlConnection(".");
connection.Open();


string insertQuery = "INSERT INTO Employee VALUES (@FirstName, @LastName, @Age, @Salary)";
SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
insertCommand.Parameters.AddWithValue("@FirstName", "John");
insertCommand.Parameters.AddWithValue("@LastName", "Doe");
insertCommand.Parameters.AddWithValue("@Age", 30);
insertCommand.Parameters.AddWithValue("@Salary", 50000.00);
insertCommand.ExecuteNonQuery();


string updateQuery = "UPDATE Employee SET FirstName = @FirstName WHERE EmployeeId = @EmployeeId";
SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
updateCommand.Parameters.AddWithValue("@FirstName", "UpdatedJohn");
updateCommand.Parameters.AddWithValue("@EmployeeId", 1);
updateCommand.ExecuteNonQuery();


string deleteQuery = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
deleteCommand.Parameters.AddWithValue("@EmployeeId", 1);
deleteCommand.ExecuteNonQuery();

connection.Close();



string displayQuery = "SELECT * FROM Employee";
SqlDataAdapter dataAdapter = new SqlDataAdapter(displayQuery, connection);
DataTable dataTable = new DataTable();
dataAdapter.Fill(dataTable);

dataGridView1.DataSource = dataTable;

